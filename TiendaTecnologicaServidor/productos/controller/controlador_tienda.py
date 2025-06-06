from ..model.cargador import Cargador 
from ..model.celular import Celular

class ControladorTienda:
    def __init__(self, productos):
        self.productos = productos

    def agregar_producto(self, sku, nombre, descripcion, precio, stock, marca, capacidad, fechaLanzamiento, fechaRegistro=None, is_new=True):
        """
        Crea un Celular y lo agrega a self.productos. 
        is_new indica si el celular es nuevo (True) o reacondicionado (False).
        Por defecto, asumimos que es nuevo.
        """
        try:
            # Aquí pasamos is_new al constructor de Celular:
            celular = Celular(sku, nombre, descripcion, precio, stock, marca, capacidad, fechaLanzamiento,  is_new=is_new, fechaRegistro=fechaRegistro)
            self.productos.append(celular)
        except ValueError as e:
            print(e)

    def listar_productos(self):
        """
        Muestra todos los productos de la tienda en consola,
        incluyendo si son nuevos o reacondicionados (si su __str__ lo indica).
        """
        for producto in self.productos:
            print(producto.__str__())

    def get_producto(self, index):
        """ 
        Muestra el producto en la posición 'index'. 
        """
        print(self.productos[index].__str__())

        
    def buscar_producto(self, sku):
        """
        Busca en la lista self.productos por 'sku' en lugar de 'nombre'.
        """
        for prod in self.productos:
            if prod.get_sku() == sku:   
                return prod
        return None

    def actualizar_celular(self, sku, nuevo_nombre=None, nuevo_precio=None, nueva_descripcion=None, 
                          nuevo_stock=None, nueva_marca=None, nueva_capacidad=None, 
                          nueva_fecha_lanzamiento=None, es_nuevo=None):
        """
        Actualiza un celular buscándolo por SKU.
        Solo modifica los atributos que reciban un valor distinto de None.
        El SKU no se actualiza.
        """
        celular_obj = self.buscar_producto(sku)
        if celular_obj is None:
            print(f"No se encontró un celular con el sku: {sku}")
            return 

        # Si se envía un nombre en la petición, se actualiza:
        if nuevo_nombre is not None:
            celular_obj.set_nombre(nuevo_nombre)

        if nuevo_precio is not None:
            celular_obj.set_precio(nuevo_precio)
        if nueva_descripcion is not None:
            celular_obj.set_descripcion(nueva_descripcion)
        if nuevo_stock is not None:
            celular_obj.set_stock(nuevo_stock)
        if nueva_marca is not None:
            celular_obj.set_marca(nueva_marca)
        if nueva_capacidad is not None:
            celular_obj.set_capacidad(nueva_capacidad)
        if nueva_fecha_lanzamiento is not None:
            celular_obj.set_fechaLanzamiento(nueva_fecha_lanzamiento)
        if es_nuevo is not None:
            celular_obj.set_is_new(es_nuevo)

        print(f"Celular con SKU '{sku}' actualizado correctamente.")

    def eliminar_producto(self, producto):
        """ 
        Elimina un producto de la lista self.productos.
        """
        self.productos.remove(producto)

    # ---------- CRUD Cargador  ### NEW ----------
    def agregar_cargador(self, sku_cel, id_carg, nombre, descripcion,
                         precio, stock, marca, capVoltaje, cableLength,
                         fechaGarantia, sku_celular):
        cel = self.buscar_producto(sku_cel)
        if cel is None:
            raise ValueError(f"Celular {sku_cel} no existe")
        # unicidad del id
        if cel.buscar_cargador(id_carg):
            raise ValueError(f"Ya existe cargador {id_carg} en {sku_cel}")
        carg = Cargador(id_carg, nombre, descripcion, precio, stock,
                        marca, capVoltaje, cableLength, fechaGarantia, sku_celular)
        cel.add_cargador(carg)

    def buscar_cargador(self, sku_cel, id_carg):
        cel = self.buscar_producto(sku_cel)
        if cel:
            return cel.buscar_cargador(id_carg)
        return None

    def actualizar_cargador(self, sku_cel, id_carg, **kwargs):
        carg = self.buscar_cargador(sku_cel, id_carg)
        if carg is None:
            raise ValueError("No existe el cargador")
        # Cada atributo es opcional
        if 'nombre'         in kwargs and kwargs['nombre']  is not None: carg.set_nombre(kwargs['nombre'])
        if 'descripcion'    in kwargs and kwargs['descripcion'] is not None: carg.set_descripcion(kwargs['descripcion'])
        if 'precio'         in kwargs and kwargs['precio']   is not None: carg.set_precio(kwargs['precio'])
        if 'stock'          in kwargs and kwargs['stock']    is not None: carg.set_stock(kwargs['stock'])
        if 'marca'          in kwargs and kwargs['marca']    is not None: carg.set_marca(kwargs['marca'])
        if 'capVoltaje'     in kwargs and kwargs['capVoltaje'] is not None: carg.set_capVoltaje(kwargs['capVoltaje'])
        if 'cableLength'    in kwargs and kwargs['cableLength'] is not None: carg.set_cableLength(kwargs['cableLength'])
        if 'fechaGarantia'  in kwargs and kwargs['fechaGarantia'] is not None: carg.set_fechaGarantia(kwargs['fechaGarantia'])
        if  'sku_cel'       in kwargs and kwargs['sku_cel'] is not None: carg.set_sku_celular(kwargs['sku_cel'])
    def eliminar_cargador(self, sku_cel, id_carg):
        cel = self.buscar_producto(sku_cel)
        if cel is None:
            raise ValueError("Celular no existe")
        cel.remove_cargador(id_carg)
    
    
    def calcular_total(self):
        """ 
        Retorna la suma de (precioCalculado * stock) de todos los productos.
        """
        total = 0
        for i in self.productos:
            total += i.calcularPrecio() * i.get_stock()
        return total
