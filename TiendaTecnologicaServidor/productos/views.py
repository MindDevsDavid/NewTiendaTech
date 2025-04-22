from django.shortcuts import render

import json
from django.http import JsonResponse
from django.views.decorators.http import require_http_methods
from .controller.controlador_tienda import ControladorTienda
from django.views.decorators.csrf import csrf_exempt
from datetime import datetime
from .model.cargador import Cargador 

# ---------- Utilidades de validación para Cargador  ### NEW ----------
def _validar_double(valor, campo):
    try:
        v = float(valor)
        if v < 0:
            raise ValueError
        return v
    except (ValueError, TypeError):
        raise ValueError(f"{campo} debe ser un número decimal ≥ 0")

def _validar_int(valor, campo):
    try:
        v = int(valor)
        if v < 0:
            raise ValueError
        return v
    except (ValueError, TypeError):
        raise ValueError(f"{campo} debe ser un entero ≥ 0")
    

# Creamos un controlador en memoria.
controlador = ControladorTienda([])

@csrf_exempt
@require_http_methods(["POST"])
def create_celular(request):
    """
    Crea un celular a partir de datos JSON en el cuerpo de la petición.
    Ejemplo de JSON:
    {
      "sku": "SAMS20-BLACK",
      "nombre": "Samsung S20",
      "descripcion": "Celular gama alta",
      "precio": 2000,
      "stock": 10,
      "marca": "Samsung",
      "capacidad": 128,
      "fechaLanzamiento": "2025-03-20",
      "is_new": true
    }
    """
    try:
        data = json.loads(request.body)
    except json.JSONDecodeError:
        return JsonResponse({"error": "JSON inválido. Asegurate de verificar los valores que ingresas"}, status=400)

    sku = data.get("sku")
    nombre = data.get("nombre")
    descripcion = data.get("descripcion")
    precio = data.get("precio")
    stock = data.get("stock")
    marca = data.get("marca")
    capacidad = data.get("capacidad")
    fecha = data.get("fechaLanzamiento")
    is_new = data.get("is_new", True)  # Por defecto True

    # (1) Validar obligatorios: sku, nombre, marca, precio, stock, fecha
    if not sku or not nombre or not marca or precio is None or stock is None or not fecha:
        return JsonResponse({"error": "Campos obligatorios faltantes (sku, nombre, marca, precio, stock o fecha)."}, status=400)

    # (2) Validar formato de fecha => "YYYY-MM-DD"
    from datetime import datetime
    try:
        datetime.strptime(fecha, "%Y-%m-%d")  # Si no cumple, lanza ValueError
    except ValueError:
        return JsonResponse({"error": "Formato de fecha invalido (use YYYY-MM-DD)."}, status=400)
    
    try:
        stock = int(stock)
        if stock < 0:
            return JsonResponse({"error": "El stock no puede ser negativo."}, status=400)
    except ValueError:
        return JsonResponse({"error": "Stock debe ser un numero entero valido."}, status=400)
    
    try:
        capacidad = int(capacidad)
        if capacidad < 0:
            return JsonResponse({"error": "La capacidad no puede ser negativo."}, status=400)
    except ValueError:
        return JsonResponse({"error": "Capacidad debe ser un número entero valido."}, status=400)
    
    try:
        precio = float(precio)
        if precio < 0:
            return JsonResponse({"error": "El precio no puede ser negativo."}, status=400)
    except ValueError:
        return JsonResponse({"error": "Precio debe ser un numero decimal valido."}, status=400)


    # (3) Verificamos si ya existe un celular con ese SKU
    celular_existente = controlador.buscar_producto(sku)
    if celular_existente is not None:
        return JsonResponse({"error": f"Ya existe un celular con el SKU '{sku}'"}, status=400)

    # (4) Crear el celular
    controlador.agregar_producto(
        sku, nombre, descripcion, precio, stock, marca, 
        capacidad, fecha, is_new=is_new
    )
    return JsonResponse({"message": "Celular creado con exito"}, status=201)


@require_http_methods(["GET"])
def list_celulares(request):
    """
    Lista todos los celulares en el controlador.
    Retorna un arreglo JSON.
    """
    if len(controlador.productos) == 0:
        return JsonResponse({"message": "Lista vacia"}, status=200)
    
    resultado = []
    for prod in controlador.productos:
        # Formatea la fecha para JSON si es un objeto datetime
        fecha_registro = prod.get_fechaRegistro()
        if hasattr(fecha_registro, 'strftime'):
            fecha_str = fecha_registro.strftime("%Y-%m-%d %H:%M:%S %Z")
        else:
            fecha_str = str(fecha_registro)
        # Convertimos el objeto a dict
        item = {
            "nombre": prod.get_nombre(),
            "sku": prod.get_sku(),
            "descripcion": prod.get_descripcion(),
            "precio": prod.get_precio(),
            "stock": prod.get_stock(),
            "marca": prod.get_marca(),
            "capacidad": prod.get_capacidad(),
            "fechaLanzamiento": prod.get_fechaLanzamiento(),
            "fechaRegistro": fecha_str,
            "isNew": getattr(prod, "is_new", True),  # si no existe, asume True
            "precio Con Iva": prod.calcularPrecio()
        }
        resultado.append(item)
    return JsonResponse(resultado, safe=False, status=200)

@csrf_exempt
@require_http_methods(["GET"])
def get_celular_by_sku(request, sku):
    producto = controlador.buscar_producto(sku)
    if producto is None:
        return JsonResponse({"error": "No se encontró celular con ese SKU"}, status=404)
    
# Formatea la fecha para JSON si es un objeto datetime
    fecha_registro = producto.get_fechaRegistro()
    if hasattr(fecha_registro, 'strftime'):
        fecha_str = fecha_registro.strftime("%Y-%m-%d %H:%M:%S %Z")
    else:
        fecha_str = str(fecha_registro)
        # Convertimos el objeto a dict

    # Retorna todos los atributos
    item = {
        "sku": producto.get_sku(),
        "nombre": producto.get_nombre(),
        "descripcion": producto.get_descripcion(),
        "precio": producto.get_precio(),
        "stock": producto.get_stock(),
        "marca": producto.get_marca(),
        "capacidad": producto.get_capacidad(),
        "fechaLanzamiento": producto.get_fechaLanzamiento(),
        "fechaRegistro": fecha_str,
        "isNew": getattr(producto, "is_new", True),
        "precioConIva": producto.calcularPrecio()
    }
    return JsonResponse(item, status=200)

@csrf_exempt
@require_http_methods(["PUT"])
def update_celular(request, sku):
    """
    Actualiza un celular existente buscándolo por SKU.
    Datos en JSON (solo lo que se desee actualizar):
    {
      "nombre": "Samsung S22 PLUS",
      "precio": 3000,
      "stock": 5,
      "marca": "Samsung",
      ...
    }
    El 'sku' no se actualiza (es inmutable).
    """
    try:
        data = json.loads(request.body)
    except json.JSONDecodeError:
        return JsonResponse({"error": "JSON inválido. Asegurate de verificar los valores que ingresas"}, status=400)

    # 1. Verificar si el celular con ese SKU existe
    celular_obj = controlador.buscar_producto(sku)
    if celular_obj is None:
        return JsonResponse({"error": f"No se encontró el celular con SKU '{sku}'"}, status=404)

    # 2. Extraer campos a actualizar (si existen en el JSON)
    nuevo_nombre = data.get("nombre")
    nuevo_precio = data.get("precio")
    nueva_descripcion = data.get("descripcion")
    nuevo_stock = data.get("stock")
    nueva_marca = data.get("marca")
    nueva_capacidad = data.get("capacidad")
    nueva_fecha_lanzamiento = data.get("fechaLanzamiento")
    es_nuevo = data.get("is_new")

    # 3. Llamar al controlador para efectuar la actualización
    controlador.actualizar_celular(
        sku,
        nuevo_nombre=nuevo_nombre,
        nuevo_precio=nuevo_precio,
        nueva_descripcion=nueva_descripcion,
        nuevo_stock=nuevo_stock,
        nueva_marca=nueva_marca,
        nueva_capacidad=nueva_capacidad,
        nueva_fecha_lanzamiento=nueva_fecha_lanzamiento,
        es_nuevo=es_nuevo
    )

    # 4. Responder éxito
    return JsonResponse({"message": f"Celular '{sku}' actualizado."}, status=200)



@csrf_exempt
@require_http_methods(["DELETE"])
def delete_celular(request, sku):
    """
    Elimina un celular buscándolo por nombre.
    """
    producto = controlador.buscar_producto(sku)
    if producto is None:
        return JsonResponse({"error": "No se encontró un celular con ese SKU"}, status=404)

    controlador.eliminar_producto(producto)
    return JsonResponse({"message": f"Celular con SKU '{sku}' eliminado con éxito"}, status=200)


@require_http_methods(["GET"])
def buscar_por_marca(request):
    """
    Ejemplo de uso: GET /celulares/buscar-por-marca?marca=Samsung
    Retorna lista de celulares coincidientes.
    """
    marca = request.GET.get("marca", None)
    if not marca:
        return JsonResponse({"error": "El parámetro 'marca' es obligatorio"}, status=400)

    # Creamos método en el controlador (o lo definimos inline):
    resultado = []
    for prod in controlador.productos:
        # Formatea la fecha para JSON si es un objeto datetime
        fecha_registro = prod.get_fechaRegistro()
        if hasattr(fecha_registro, 'strftime'):
            fecha_str = fecha_registro.strftime("%Y-%m-%d %H:%M:%S %Z")
        else:
            fecha_str = str(fecha_registro)
        
        if prod.get_marca().lower() == marca.lower():
            
            item = {
            "nombre": prod.get_nombre(),
            "sku": prod.get_sku(),
            "descripcion": prod.get_descripcion(),
            "precio": prod.get_precio(),
            "stock": prod.get_stock(),
            "marca": prod.get_marca(),
            "capacidad": prod.get_capacidad(),
            "fechaLanzamiento": prod.get_fechaLanzamiento(),
            "fechaRegistro": fecha_str,
            "isNew": getattr(prod, "is_new", True),  # si no existe, asume True
            "precio Con Iva": prod.calcularPrecio()
        }
            resultado.append(item)
    if len(resultado) == 0:
        return JsonResponse({"error": "No se encontraron celulares con esa marca"}, status=404)

    return JsonResponse(resultado, safe=False, status=200)


@require_http_methods(["GET"])
def buscar_por_rango_precio(request):
    """
    Ejemplo de uso: GET /celulares/buscar-por-precio?min=1000&max=3000
    """
    try:
        minimo = float(request.GET.get("min"))
        maximo = float(request.GET.get("max"))
    except (TypeError, ValueError):
        return JsonResponse({"error": "Parámetros 'min' o 'max' inválidos o ausentes"}, status=400)

    resultado = []
    for prod in controlador.productos:
        # Formatea la fecha para JSON si es un objeto datetime
        fecha_registro = prod.get_fechaRegistro()
        if hasattr(fecha_registro, 'strftime'):
            fecha_str = fecha_registro.strftime("%Y-%m-%d %H:%M:%S %Z")
        else:
            fecha_str = str(fecha_registro)
        # Convertimos el objeto a dict
        precio_base = prod.get_precio()
        if minimo <= precio_base <= maximo:
            item = {
            "nombre": prod.get_nombre(),
            "sku": prod.get_sku(),
            "descripcion": prod.get_descripcion(),
            "precio": prod.get_precio(),
            "stock": prod.get_stock(),
            "marca": prod.get_marca(),
            "capacidad": prod.get_capacidad(),
            "fechaLanzamiento": prod.get_fechaLanzamiento(),
            "fechaRegistro": fecha_str,
            "isNew": getattr(prod, "is_new", True),  # si no existe, asume True
            "precio Con Iva": prod.calcularPrecio()
        }
            resultado.append(item)

    if not resultado:
        return JsonResponse({"error": "No se encontraron celulares en ese rango de precio"}, status=404)

    return JsonResponse(resultado, safe=False, status=200)


# =====================================================
#                CRUD Cargador (detalle)       ### NEW
# =====================================================

@csrf_exempt
@require_http_methods(["POST"])
def create_cargador(request, sku):
    """
    Crea un cargador y lo asocia al celular con el SKU dado.
    JSON esperado:
    {
       "id": 1,
       "capVoltaje": 20.5,
       "marca": "Anker",
       "longCable": 1.2,
       "fechaGarantia": "2026-05-01"
    }
    """
    # 1. Parsear JSON
    try:
        data = json.loads(request.body)
    except json.JSONDecodeError:
        return JsonResponse({"error": "JSON inválido"}, status=400)

    # 2. Validar campos
    try:
        id_             = _validar_int   (data.get("id"),          "id")
        cap_voltaje     = _validar_double(data.get("capVoltaje"),  "capVoltaje")
        marca           = data.get("marca")
        long_cable      = _validar_double(data.get("longCable"),   "longCable")
        fecha_garantia  = data.get("fechaGarantia")

        if not marca:
            raise ValueError("marca es obligatoria")

        # validar fecha
        datetime.strptime(fecha_garantia, "%Y-%m-%d")

    except ValueError as e:
        return JsonResponse({"error": str(e)}, status=400)

    # 3. Verificar que el celular exista
    celular = controlador.buscar_producto(sku)
    if celular is None:
        return JsonResponse({"error": f"No existe celular con SKU '{sku}'"}, status=404)

    # 4. Crear Cargador y añadirlo
    try:
        cargador = Cargador(id_, cap_voltaje, marca, long_cable, fecha_garantia)
        celular.add_cargador(cargador)
    except ValueError as e:  # id duplicado, etc.
        return JsonResponse({"error": str(e)}, status=400)

    return JsonResponse({"message": "Cargador creado"}, status=201)


@require_http_methods(["GET"])
def list_cargadores(request, sku):
    """
    GET /celulares/<sku>/cargadores
    Soporta ?voltaje_min&voltaje_max
    """
    cel = controlador.buscar_producto(sku)
    if cel is None:
        return JsonResponse({"error": "Celular no existe"}, status=404)

    vmin = request.GET.get("voltaje_min")
    vmax = request.GET.get("voltaje_max")
    try:
        vmin = float(vmin) if vmin is not None else None
        vmax = float(vmax) if vmax is not None else None
    except ValueError:
        return JsonResponse({"error": "voltaje_* deben ser numéricos"}, status=400)

    resultado = []
    for c in cel.listar_cargadores():
        if vmin is not None and c.get_capVoltaje() < vmin: continue
        if vmax is not None and c.get_capVoltaje() > vmax: continue
        resultado.append({
            "id":           c.get_id(),
            "nombre":       c.get_nombre(),
            "descripcion":  c.get_descripcion(),
            "precio":       c.get_precio(),
            "stock":        c.get_stock(),
            "marca":        c.get_marca(),
            "capVoltaje":   c.get_capVoltaje(),
            "cableLength":  c.get_cableLength(),
            "fechaGarantia": c.get_fechaGarantia().strftime("%Y-%m-%d"),
            "precioConIva": c.calcularPrecio()
        })
    if not resultado:
        return JsonResponse({"message": "Sin cargadores"}, status=200)
    return JsonResponse(resultado, safe=False, status=200)

@csrf_exempt
@require_http_methods(["PUT"])
def update_cargador(request, sku, id):
    """
    Actualiza un cargador asociado a un celular.
    """
    try:
        data = json.loads(request.body)
    except json.JSONDecodeError:
        return JsonResponse({"error": "JSON inválido"}, status=400)

    celular = controlador.buscar_producto(sku)
    if celular is None:
        return JsonResponse({"error": f"No existe celular con SKU '{sku}'"}, status=404)

    cargador = celular.buscar_cargador(id)
    if cargador is None:
        return JsonResponse({"error": f"No existe cargador con id {id}"}, status=404)

    # Actualizaciones parciales
    try:
        if "capVoltaje" in data:
            cargador.set_capVoltaje(_validar_double(data["capVoltaje"], "capVoltaje"))
        if "marca" in data:
            if not data["marca"]:
                raise ValueError("marca no puede ser vacía")
            cargador.set_marca(data["marca"])
        if "longCable" in data:
            cargador.set_cableLength(_validar_double(data["longCable"], "longCable"))
        if "fechaGarantia" in data:
            datetime.strptime(data["fechaGarantia"], "%Y-%m-%d")
            cargador.set_fechaGarantia(data["fechaGarantia"])
    except ValueError as e:
        return JsonResponse({"error": str(e)}, status=400)

    return JsonResponse({"message": "Cargador actualizado"}, status=200)


@csrf_exempt
@require_http_methods(["DELETE"])
def delete_cargador(request, sku, id):
    """
    Elimina un cargador de un celular.
    """
    celular = controlador.buscar_producto(sku)
    if celular is None:
        return JsonResponse({"error": f"No existe celular con SKU '{sku}'"}, status=404)

    try:
        celular.remove_cargador(id)
    except ValueError as e:
        return JsonResponse({"error": str(e)}, status=404)

    return JsonResponse({"message": "Cargador eliminado"}, status=200)