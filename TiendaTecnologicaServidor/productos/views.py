import traceback
from django.shortcuts import render

import json
from django.http import JsonResponse
from django.views.decorators.http import require_http_methods
from .controller.controlador_tienda import ControladorTienda
from django.views.decorators.csrf import csrf_exempt
from datetime import datetime
from .model.cargador import Cargador 
from django.http import JsonResponse
from supabase import create_client, Client


url = 'https://aufgljqmpzaxqoyyqkwa.supabase.co'
key = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImF1ZmdsanFtcHpheHFveXlxa3dhIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDcwNzUzNDAsImV4cCI6MjA2MjY1MTM0MH0.TuBANuhMS9UfQz2OHLMkvkffEdV36TRsGLWauAQJx_4'
supabase: Client = create_client(url, key)
# ---------- Validacion de Url presente ----------

def custom_404(request, exception):
    return JsonResponse(
        {"error": "La URL ingresada no pertenece a este servicio"},
        status = 404



)

# ---------- Utilidades de validación para Cargador  ### NEW ----------
def _validar_double(valor, campo):
    try:
        v = str(valor)
        if not isinstance(v, str) or not v.strip():
            raise ValueError("capVoltaje debe ser una cadena no vacía")
          
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


    ## (1) Validar obligatorios: sku, nombre, marca, precio, stock, fecha
    if not sku or not nombre or not marca or precio is None or stock is None or not fecha:
        return JsonResponse({"error": "Campos obligatorios faltantes (sku, nombre, marca, precio, stock o fecha)."}, status=400)

    if isinstance(sku, int):
        return JsonResponse({"error": "sku no puede ser un numero"}, status=400)

    if isinstance(sku, float):
        return JsonResponse({"error": "sku no puede ser un decimal"}, status=400)


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

    # 4) Validar tipos numéricos y rangos
    try:
        stock = int(stock)
        if stock < 0:
            raise ValueError
    except (TypeError, ValueError):
        return JsonResponse({"error": "El campo 'stock' debe ser entero ≥ 0."}, status=400)

    try:
        capacidad = int(capacidad)
        if capacidad < 0:
            raise ValueError
    except (TypeError, ValueError):
        return JsonResponse({"error": "El campo 'capacidad' debe ser entero ≥ 0."}, status=400)

    try:
        precio = float(precio)
        if precio < 0:
            raise ValueError
    except (TypeError, ValueError):
        return JsonResponse({"error": "El campo 'precio' debe ser decimal ≥ 0."}, status=400)

    # 4) Insertar en Supabase
    payload = {
        "sku": sku,
        "nombre": nombre,
        "description": descripcion,
        "precio": precio,
        "stock": stock,
        "marca": marca,
        "capacidad": capacidad,
        "fechalanzamiento": fecha,
        "is_new": is_new
    }

    resp = supabase.table("celulares").insert(payload).execute()

    # supabase-py v1+ devuelve un APIResponse que NO tiene atributo .error, 
    # sino que el “error” viene en el diccionario interno.
    # Vamos a extraer primero el JSON crudo:
    raw = None
    if hasattr(resp, "_response"):  # si estás usando httpx bajo el capó
        raw = resp._response.json()
    else:
        # si resp ya es dict-like:
        try:
            raw = dict(resp)
        except Exception:
            raw = {}

    # ahora, fíjate si en raw vino un “error”
    if raw.get("error"):
        msg = raw["error"].get("message") or str(raw["error"])
        return JsonResponse({"error": msg}, status=400)

    # caso feliz: devolvemos la fila recién insertada
    data = raw.get("data") or getattr(resp, "data", None)
    if isinstance(data, list) and data:
        return JsonResponse(data[0], status=201)

    # por si acaso la forma cambió nuevamente:
    return JsonResponse({"error": "No se obtuvo data de inserción"}, status=500)



@require_http_methods(["GET"])
def list_celulares(request):
    """
    Lista todos los celulares en el controlador.
    Retorna un arreglo JSON.
   
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
    """

    
# Fetch data from the database  
    response = supabase.table('celulares').select('*').execute()
    print(response.data)
    respuesta = response.data
    return JsonResponse( respuesta, safe=False,  status=200)
    


@csrf_exempt
@require_http_methods(["GET"])
def get_celular_by_sku(request, sku):
    """
    GET /celulares/<sku>
    Busca un celular en la tabla 'celulares' de Supabase y devuelve sus datos.
    """
    import traceback

    # 1) Intentar consultar Supabase
    try:
        resp = supabase \
            .from_("celulares") \
            .select("*") \
            .eq("sku", sku) \
            .execute()
    except Exception as e:
        traceback.print_exc()
        return JsonResponse(
            {"error": f"Error al conectar con la base de datos: {e}"},
            status=500
        )

    # 2) Revisar si Supabase devolvió un error
    error = getattr(resp, "error", None)
    if error:
        # resp.error es un objeto con .message
        return JsonResponse({"error": error.message}, status=400)

    # 3) Obtener los datos
    data = getattr(resp, "data", None)
    if not data:
        return JsonResponse(
            {"error": f"No se encontró celular con SKU '{sku}'"},
            status=404
        )

    # 4) Devolver el primer (y único) registro encontrado
    celular = data[0]
    return JsonResponse(celular, status=200)

@csrf_exempt
@require_http_methods(["PUT"])
def update_celular(request, sku):
    """
    Actualiza un celular existente buscándolo por SKU, usando Supabase.
    Sólo los campos presentes en el JSON serán modificados.
    """
    # 1) Parsear JSON
    try:
        data = json.loads(request.body)
    except json.JSONDecodeError:
        return JsonResponse(
            {"error": "JSON inválido. Asegurate de verificar los valores que ingresas"},
            status=400
        )

    # 2) Sólo permitimos estas claves y mapeamos al nombre de columna
    mapeo = {
        "nombre": "nombre",
        "description": "description",
        "precio": "precio",
        "stock": "stock",
        "marca": "marca",
        "capacidad": "capacidad",
        "fechalanzamiento": "fechalanzamiento",
        "is_new": "is_new"
    }

    update_payload = {}
    for key, col in mapeo.items():
        if key in data:
            update_payload[col] = data[key]

    if not update_payload:
        return JsonResponse(
            {"error": "No hay campos para actualizar"},
            status=400
        )

    # 3) Ejecutar el UPDATE en Supabase
    resp = (
        supabase
        .table("celulares")
        .update(update_payload)
        .eq("sku", sku)
        .execute()
    )

    # 4) Chequear errores (supabase-py v2.x)
    if hasattr(resp, "error") and resp.error:
        return JsonResponse({"error": resp.error.message}, status=400)

    # 4b) En supabase-py v1.x el error viene embebido en _response:
    if not hasattr(resp, "error") and getattr(resp, "_response", None):
        raw = resp._response.json()
        if raw.get("error"):
            msg = raw["error"].get("message", str(raw["error"]))
            return JsonResponse({"error": msg}, status=400)
        resp_data = raw.get("data", [])
    else:
        resp_data = getattr(resp, "data", [])

    # 5) Si no devolvió ninguna fila, es porque no existía ese SKU
    if not resp_data:
        return JsonResponse(
            {"error": f"No se encontró un celular con SKU '{sku}'"},
            status=404
        )

    # 6) Caso feliz: devolvemos la fila actualizada
    return JsonResponse(resp_data[0], status=200)



@csrf_exempt
@require_http_methods(["DELETE"])
def delete_celular(request, sku):
    """
    Elimina un celular de la tabla 'celulares' de Supabase, buscándolo por SKU.
    """
    try:
        # ejecuta DELETE ... WHERE sku = '...'
        resp = supabase\
            .table("celulares")\
            .delete()\
            .eq("sku", sku)\
            .execute()

        # Supabase v1+ no expone resp.error; lo leemos del JSON bruto:
        if hasattr(resp, "_response"):
            raw = resp._response.json()
        else:
            try:
                raw = dict(resp)
            except:
                raw = {}

        # 1) Error de Supabase
        if raw.get("error"):
            msg = raw["error"].get("message") or str(raw["error"])
            return JsonResponse({"error": msg}, status=400)

        # 2) filas afectadas
        data = raw.get("data") or getattr(resp, "data", None)
        if not data:
            return JsonResponse(
                {"error": f"No se encontró un celular con SKU '{sku}'"},
                status=404
            )

        # 3) Eliminación exitosa
        return JsonResponse(
            {"message": f"Celular con SKU '{sku}' eliminado con éxito"},
            status=200
        )

    except Exception as e:
        traceback.print_exc()
        return JsonResponse({"error": str(e)}, status=500)



@require_http_methods(["GET"])
def buscar_por_marca(request):
    """
    GET /celulares/buscar-por-marca?marca=Samsung
    Busca en Supabase los celulares cuya marca contiene el término (ILIKE).
    """
    import traceback

    marca = request.GET.get("marca", "").strip()
    if not marca:
        return JsonResponse(
            {"error": "El parámetro 'marca' es obligatorio"},
            status=400
        )

    # 1) Llamada a Supabase filtrando marca case-insensitive
    try:
        resp = (
            supabase
            .from_("celulares")
            .select("*")
            .ilike("marca", f"%{marca}%")
            .execute()
        )
    except Exception as e:
        traceback.print_exc()
        return JsonResponse(
            {"error": f"Error al conectar con la base de datos: {e}"},
            status=500
        )

    # 2) Manejo unificado de errores de Supabase
    error = getattr(resp, "error", None) or (resp.get("error") if isinstance(resp, dict) else None)
    if error:
        # puede venir como objeto con .message o como dict
        msg = getattr(error, "message", None) or (error.get("message") if isinstance(error, dict) else str(error))
        return JsonResponse({"error": msg}, status=400)

    # 3) Extraer datos
    data = getattr(resp, "data", None) or (resp.get("data") if isinstance(resp, dict) else None)
    if not data:
        return JsonResponse(
            {"error": "No se encontraron celulares con esa marca"},
            status=404
        )

    # 4) Caso de éxito
    return JsonResponse(data, safe=False, status=200)


@require_http_methods(["GET"])
def buscar_por_rango_precio(request):
    """
    GET /celulares/buscar-por-precio?min=1000&max=3000
    Filtra en Supabase los celulares cuyo precio esté entre 'min' y 'max'.
    """
    import traceback

    # 1) Validar parámetros
    try:
        minimo = float(request.GET.get("min"))
        maximo = float(request.GET.get("max"))
    except (TypeError, ValueError):
        return JsonResponse({"error": "Parámetros 'min' o 'max' inválidos o ausentes"}, status=400)

    # 2) Ejecutar consulta en Supabase
    try:
        resp = (
            supabase
            .from_("celulares")
            .select("*")
            .gte("precio", minimo)
            .lte("precio", maximo)
            .execute()
        )
    except Exception as e:
        traceback.print_exc()
        return JsonResponse(
            {"error": f"Error al conectar con la base de datos: {e}"},
            status=500
        )

    # 3) Manejar posible error devuelto por Supabase
    error = getattr(resp, "error", None) or (resp.get("error") if isinstance(resp, dict) else None)
    if error:
        msg = getattr(error, "message", None) or (error.get("message") if isinstance(error, dict) else str(error))
        return JsonResponse({"error": msg}, status=400)

    # 4) Extraer los datos y comprobar si hay resultados
    data = getattr(resp, "data", None) or (resp.get("data") if isinstance(resp, dict) else None)
    if not data:
        return JsonResponse({"error": "No se encontraron celulares en ese rango de precio"}, status=404)

    # 5) Devolver la lista filtrada
    return JsonResponse(data, safe=False, status=200)


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
       "capVoltaje": "20V",
       "marca": "Anker",
       "longCable": 1.2,
       "fechaGarantia": "2026-05-01"
    }
    """
    # 1) Parsear JSON
    try:
        data = json.loads(request.body)
    except json.JSONDecodeError:
        return JsonResponse({"error": "JSON inválido"}, status=400)

    # 2) Validaciones básicas
    #   – id
    id_ = data.get("id")
    if id_ is None or not isinstance(id_, int) or id_ < 0:
        return JsonResponse({"error": "El campo 'id' es obligatorio y debe ser un entero ≥ 0"}, status=400)
    #   – capVoltaje (ahora string)
    capV = data.get("capVoltaje")
    if not capV or not isinstance(capV, str):
        return JsonResponse({"error": "El campo 'capVoltaje' es obligatorio y debe ser texto"}, status=400)
    #   – marca
    if not data.get("marca"):
        return JsonResponse({"error": "El campo 'marca' es obligatorio"}, status=400)
    #   – longCable
    longC = data.get("longCable")
    try:
        longC = float(longC)
        if longC < 0:
            raise ValueError
    except Exception:
        return JsonResponse({"error": "El campo 'longCable' debe ser un número ≥ 0"}, status=400)
    #   – fechaGarantia
    fecha = data.get("fechaGarantia")
    try:
        datetime.strptime(fecha, "%Y-%m-%d")
    except Exception:
        return JsonResponse({"error": "El campo 'fechaGarantia' debe usar formato YYYY-MM-DD"}, status=400)

    # 3) Payload que vamos a insertar
    payload = {
        "sku_celular": sku,
        "id_": id_,
        "capvoltaje": capV,
        "marca": data["marca"],
        "cablelength": longC,
        "fechagarantia": fecha
    }

    # 4) Insertar en Supabase
    try:
        resp = supabase.from_("cargadores").insert(payload).execute()
    except Exception as e:
        traceback.print_exc()
        return JsonResponse(
            {"error": f"Error de conexión con la base de datos: {str(e)}"},
            status=500
        )

    # 5) Revisar si Supabase devolvió error en la respuesta
    error = getattr(resp, "error", None) or (resp.get("error") if isinstance(resp, dict) else None)
    if error:
        msg = getattr(error, "message", None) or (error.get("message") if isinstance(error, dict) else str(error))
        return JsonResponse({"error": msg}, status=400)

    # 6) Devolver el registro recién creado
    data_created = getattr(resp, "data", None) or (resp.get("data") if isinstance(resp, dict) else None)
    if not data_created:
        return JsonResponse({"error": "No se pudo crear el cargador"}, status=500)

    creado = data_created[0] if isinstance(data_created, list) else data_created
    return JsonResponse(creado, status=201)




@require_http_methods(["GET"])
def list_cargadores(request, sku):
    """
    GET /celulares/<sku>/cargadores
    Soporta filtros: ?voltaje_min&voltaje_max
    """
    import traceback
    # 1) Verificar que el celular existe en la tabla "celulares"
    try:
        resp_c = (
            supabase
            .from_("celulares")
            .select("sku")
            .eq("sku", sku)
            .execute()
        )
    except Exception as e:
        traceback.print_exc()
        return JsonResponse(
            {"error": f"Error de conexión a la base de datos: {str(e)}"},
            status=500
        )

    #  → Si no existe el celular, devolvemos 404
    if not getattr(resp_c, "data", None):
        return JsonResponse(
            {"error": f"No existe un celular con SKU '{sku}'"},
            status=404
        )

    # 2) Construir la consulta a "cargadores" con filtros opcionales
    vmin = request.GET.get("voltaje_min")
    vmax = request.GET.get("voltaje_max")
    try:
        query = supabase.from_("cargadores").select("*").eq("sku_celular", sku)
        if vmin is not None:
            query = query.gte("capvoltaje", float(vmin))
        if vmax is not None:
            query = query.lte("capvoltaje", float(vmax))
        resp = query.execute()
    except ValueError:
        return JsonResponse({"error": "voltaje_* deben ser numéricos"}, status=400)
    except Exception as e:
        traceback.print_exc()
        return JsonResponse(
            {"error": f"Error al consultar cargadores: {str(e)}"},
            status=500
        )

    # 3) Verificar errores de Supabase en la consulta de cargadores
    error = getattr(resp, "error", None)
    if error:
        return JsonResponse({"error": error.message}, status=400)

    # 4) Si no hay cargadores asociados
    if not getattr(resp, "data", None):
        return JsonResponse({"message": "Sin cargadores"}, status=200)

    # 5) Devolver el array tal cual viene de la base
    return JsonResponse(resp.data, safe=False, status=200)

@csrf_exempt
@require_http_methods(["PUT"])
def update_cargador(request, sku, id):
    """
    Actualiza un cargador en la tabla 'cargadores' filtrando por sku_celular e id.
    """
    import traceback

    # 1) Parsear JSON
    try:
        data = json.loads(request.body)
    except json.JSONDecodeError:
        return JsonResponse({"error": "JSON inválido"}, status=400)

    # 2) No permitimos modificar la clave primaria
    if "id" in data or "sku_celular" in data:
        return JsonResponse({"error": "No se puede actualizar 'id' ni 'sku_celular'"}, status=400)

    # 3) Validar que el celular maestro exista
    try:
        resp_c = (
            supabase
            .from_("celulares")
            .select("sku")
            .eq("sku", sku)
            .execute()
        )
    except Exception as e:
        traceback.print_exc()
        return JsonResponse({"error": f"Error al conectar con la DB de celulares: {e}"}, status=500)

    if not getattr(resp_c, "data", None):
        return JsonResponse({"error": f"No existe celular con SKU '{sku}'"}, status=404)

    # 4) Ejecutar el UPDATE en Supabase
    try:
        resp = (
            supabase
            .from_("cargadores")
            .update(data)
            .eq("sku_celular", sku)
            .eq("id_", id)
            .execute()
        )
    except Exception as e:
        traceback.print_exc()
        return JsonResponse({"error": f"Error al conectar con la DB de cargadores: {e}"}, status=500)

    # 5) Chequear respuesta de Supabase
    error = getattr(resp, "error", None)
    if error:
        return JsonResponse({"error": error.message}, status=400)

    updated = getattr(resp, "data", None)
    if not updated:
        return JsonResponse({"error": f"No se encontró un cargador con id {id} para el SKU '{sku}'"}, status=404)

    # 6) Retornar el registro actualizado
    return JsonResponse(updated[0], status=200) 


@csrf_exempt
@require_http_methods(["DELETE"])
def delete_cargador(request, sku, id):
    """
    Elimina un cargador de la tabla 'cargadores' filtrando por sku_celular e id.
    """
    import traceback

    # 1) Verificar que el celular maestro exista
    try:
        resp_c = (
            supabase
            .from_("celulares")
            .select("sku")
            .eq("sku", sku)
            .execute()
        )
    except Exception as e:
        traceback.print_exc()
        return JsonResponse({"error": f"Error al conectar con la DB de celulares: {e}"}, status=500)

    # Si no existe ese SKU en 'celulares'
    if not getattr(resp_c, "data", None):
        return JsonResponse({"error": f"No existe celular con SKU '{sku}'"}, status=404)

    # 2) Intentar borrar el cargador
    try:
        resp = (
            supabase
            .from_("cargadores")
            .delete()
            .eq("sku_celular", sku)
            .eq("id_", id)
            .execute()
        )
    except Exception as e:
        traceback.print_exc()
        return JsonResponse({"error": f"Error al conectar con la DB de cargadores: {e}"}, status=500)

    # 3) Revisar si Supabase devolvió un error
    error = getattr(resp, "error", None)
    if error:
        return JsonResponse({"error": error.message}, status=400)

    # 4) Si no afectó filas, ese cargador no existe
    deleted = getattr(resp, "data", None)
    if not deleted:
        return JsonResponse({"error": f"No se encontró un cargador con id {id} para el SKU '{sku}'"}, status=404)

    # 5) Todo OK
    return JsonResponse({"message": f"Cargador con id {id} del celular '{sku}' eliminado con éxito"}, status=200)







