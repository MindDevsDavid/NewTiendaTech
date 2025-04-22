# productos/model/cargador.py
from datetime import datetime, date
from django.utils import timezone
from .producto_tecnologico import ProductoTecnologico


class Cargador(ProductoTecnologico):
    """
    Detalle del celular.
    Atributos propios:
      • id            : int          (único dentro del celular)
      • capVoltaje    : float        (capacidad en voltios)
      • cableLength   : float        (longitud en metros)
      • fechaGarantia : date         (vence la garantía)
    Los atributos heredados (nombre, descripcion, precio, stock, marca)
    se inicializan con valores por defecto —pero puedes sobre‑escribirlos.
    """

    def __init__(
        self,
        id_: int,
        capVoltaje: float,
        marca: str,
        cableLength: float,
        fechaGarantia,                 # str «YYYY‑MM‑DD» ó date
        nombre: str = "Cargador",
        descripcion: str = "Cargador estándar",
        precio: float = 0.0,
        stock: int = 0,
    ):
        super().__init__(nombre, descripcion, precio, stock, marca)

        self.set_id(id_)
        self.set_capVoltaje(capVoltaje)
        self.set_cableLength(cableLength)
        self.set_fechaGarantia(fechaGarantia)

    # ----------- getters obligatorios (heredados) -----------
    def get_nombre(self):        return self.nombre
    def get_descripcion(self):   return self.descripcion
    def get_precio(self):        return self.precio
    def get_stock(self):         return self.stock
    def get_marca(self):         return self.marca

    # ----------- setters obligatorios -----------------------
    def set_nombre(self, nombre):              self.nombre = nombre
    def set_descripcion(self, descripcion):    self.descripcion = descripcion
    def set_precio(self, precio):
        if float(precio) < 0:
            raise ValueError("precio no puede ser negativo")
        self.precio = float(precio)
    def set_stock(self, stock):
        if int(stock) < 0:
            raise ValueError("stock no puede ser negativo")
        self.stock = int(stock)
    def set_marca(self, marca):                self.marca = marca

    # ----------- atributos propios del cargador -------------
    def get_id(self):              return self.id
    def set_id(self, id_):
        if int(id_) < 0: raise ValueError("id debe ser ≥ 0")
        self.id = int(id_)

    def get_capVoltaje(self):      return self.capVoltaje
    def set_capVoltaje(self, v):
        v = float(v)
        if v <= 0: raise ValueError("capVoltaje debe ser > 0")
        self.capVoltaje = v

    def get_cableLength(self):     return self.cableLength
    def set_cableLength(self, l):
        l = float(l)
        if l <= 0: raise ValueError("longCable debe ser > 0")
        self.cableLength = l

    def get_fechaGarantia(self):   return self.fechaGarantia
    def set_fechaGarantia(self, f):
        if isinstance(f, str):
            try:
                f = datetime.strptime(f, "%Y-%m-%d").date()
            except ValueError:
                raise ValueError("fechaGarantia debe tener formato YYYY‑MM‑DD")
        if not isinstance(f, date):
            raise ValueError("fechaGarantia debe ser date o str YYYY‑MM‑DD")
        self.fechaGarantia = f

    # ----------- lógica de negocio --------------------------
    def calcularPrecio(self):
        """IVA 19 % sobre el precio base"""
        return self.precio * 1.19

    def __str__(self):
        return (
            f"Cargador id={self.id} • {self.capVoltaje} V • "
            f"{self.cableLength} m • Garantía hasta {self.fechaGarantia}"
        )