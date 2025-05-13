"""
URL configuration for tienda_backend project.

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/5.2/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""

from django.contrib import admin
from django.urls import path
from productos.views import (
    create_cargador, create_celular, delete_cargador, list_cargadores, list_celulares, update_cargador, update_celular, 
    delete_celular, buscar_por_marca, buscar_por_rango_precio, get_celular_by_sku, custom_404
)

handler404 = custom_404

urlpatterns = [
    path("admin/", admin.site.urls),

    path('celulares/create', create_celular, name='create_celular'),       # POST
    path('celulares', list_celulares, name='list_celulares'),             # GET
    path('celulares/<str:sku>/update', update_celular, name='update_celular'),   # PUT
    path('celulares/<str:sku>/delete', delete_celular, name='delete_celular'),   # DELETE

    # Búsquedas
    path('celulares/buscar-por-marca', buscar_por_marca, name='buscar_marca'),     
    path('celulares/buscar-por-precio', buscar_por_rango_precio, name='buscar_precio'),
    path('celulares/<str:sku>', get_celular_by_sku, name='get_celular'),

    # ---------- Rutas para Cargador  ### NEW ----------
    path('celulares/<str:sku>/cargadores',           list_cargadores,  name='list_cargadores'),     # GET
    path('celulares/<str:sku>/cargadores/create',    create_cargador,  name='create_cargador'),     # POST
    path('celulares/<str:sku>/cargadores/<int:id>/update', update_cargador, name='update_cargador'),# PUT
    path('celulares/<str:sku>/cargadores/<int:id>/delete', delete_cargador, name='delete_cargador'),# DELETE
]
