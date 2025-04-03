from datetime import datetime
from .producto_tecnologico import ProductoTecnologico
from ..interfaces.iencender import ICelular
from django.utils import timezone
import pytz

class Celular(ProductoTecnologico, ICelular):
    def __init__(self, sku, nombre, descripcion, precio, stock, marca, capacidad, fechaLanzamiento, fechaRegistro=None, is_new=True):
        """
        is_new (bool): Indica si el celular es nuevo (True) o reacondicionado (False).
        Por defecto, asumimos que es nuevo (True).
        """
        super().__init__(nombre, descripcion, precio, stock, marca)
        self.set_capacidad(capacidad)
        self.set_fechaLanzamiento(fechaLanzamiento)
        self.set_is_new(is_new)
        self.set_sku(sku)
        self.set_fechaRegistro(fechaRegistro)

    def __str__(self):
        base_str = super().__str__()
        extra_info = (f"\nCapacidad: {self.capacidad}\n"
                      f"Fecha de lanzamiento: {self.fechaLanzamiento}\n"
                      f"¿Es nuevo?: {self.is_new}\n"
                      f"SKU: {self.sku}\n"
                      f"Fecha de registro: {self.fechaRegistro}\n"
                      )
        return base_str + extra_info

    # GETTERS
    def get_nombre(self):
        return self.nombre
    
    def get_sku(self):
        return self.sku

    def get_descripcion(self):
        return self.descripcion

    def get_precio(self):
        return self.precio

    def get_stock(self):
        return self.stock

    def get_marca(self):
        return self.marca

    def get_capacidad(self):
        return self.capacidad

    def get_fechaLanzamiento(self):
        return self.fechaLanzamiento
    
    def get_fechaRegistro(self):
        return self.fechaRegistro

    def get_is_new(self) -> bool:
        return self.is_new

    # SETTERS

    def set_sku(self, sku):
        """
        Asigna un SKU. Podrías agregar validaciones (e.g. no vacío).
        """
        if not sku:
            raise ValueError("El SKU no puede ser vacío")
        self.sku = sku

    def set_marca(self, marca):
        self.marca = marca

    def set_capacidad(self, capacidad):
        if capacidad <= 0:
            raise ValueError("La capacidad de almacenamiento no puede ser menor o igual a 0")
        self.capacidad = capacidad

    def set_fechaLanzamiento(self, fechaLanzamiento):
        self.fechaLanzamiento = fechaLanzamiento

    def set_fechaRegistro(self, fechaRegistro):
        """
        - Si es None, tomamos la hora local (timezone.now()).
        - Si es string, intentamos parsear en formato ISO (YYYY-MM-DD o YYYY-MM-DD HH:MM:SS).
        - Si es datetime pero naive, lo convertimos a UTC.
        - Si es datetime con tz, lo guardamos tal cual.
        - Si no se puede parsear, usamos la hora local actual.
        """
        if fechaRegistro is None:
            # Usamos hora local
            self.fechaRegistro = timezone.localtime(timezone.now())  # con tz local/definida en Django
            return

        # Si nos llega algo, chequeamos su tipo
        if isinstance(fechaRegistro, datetime):
            # Revisa si ya tiene tz
            if fechaRegistro.tzinfo is None:
                # Estaba naive, la hacemos aware en UTC
                self.fechaRegistro = timezone.make_aware(fechaRegistro, timezone.get_current_timezone())
            else:
                # Ya tiene tz
                self.fechaRegistro = fechaRegistro
            return

        if isinstance(fechaRegistro, str):
            try:
                # Intentamos parsear ISO8601 o un formato conocido
                # Ejemplo: "2025-04-03 15:30:00"
                dt = datetime.fromisoformat(fechaRegistro)
                if dt.tzinfo is None:
                    dt = timezone.make_aware(dt, timezone.get_current_timezone())
                self.fechaRegistro = dt
                return
            except ValueError:
                pass  # fallará al final

        # Si llegó un bool, un int, o string no parseable => fallback
        self.fechaRegistro = timezone.localtime(timezone.now())

    def set_descripcion(self, descripcion):
        self.descripcion = descripcion

    def set_precio(self, precio):
        if precio < 0:
            raise ValueError("el precio no puede ser negativo")
        self.precio = precio

    def set_stock(self, stock):
        if stock < 0:
            raise ValueError("no puede haber cantidades negativas en el stock")
        self.stock = stock

    def set_nombre(self, nombre):
        self.nombre = nombre

    def set_is_new(self, is_new: bool):
        self.is_new = bool(is_new)

    def calcularPrecio(self):
        return self.precio + self.precio * 0.19

    def encender(self):
        print("Encendiendo celular")