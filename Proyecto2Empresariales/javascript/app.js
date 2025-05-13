import datos from "../data/data.json" with { type: "json" };
import { Cel } from "./clases.js";

const myModal = document.getElementById("modalCel") ? new bootstrap.Modal(document.getElementById("modalCel")) : null;
let idCelUpdate = null;

/**
 * Función para mostrar el modal de edición
 */
window.mostrarModal = (id) => {
    if (!myModal) return; // Evita errores si no existe el modal
    console.log(id);
    idCelUpdate = id;
    let index = datos.findIndex((item) => item.id == idCelUpdate);

    if (index !== -1) {
        document.querySelector("#nombreCelModal").value = datos[index].nombre;
        document.querySelector("#descripcionCelModal").value = datos[index].descripcion;
        document.querySelector("#stockCelModal").value = datos[index].stock;
        document.querySelector("#marcaCelModal").value = datos[index].marca;
        document.querySelector("#precioCelModal").value = datos[index].precio;
        document.querySelector("#fechaCelModal").value = datos[index].fecha_lanzamiento;
        document.querySelector("#capacidadCelModal").value = datos[index].capacidad;

        myModal.show();
    }
};

/**
 * Función para actualizar un celular en la lista
 */
const celUpdate = (e) => {
    e.preventDefault();
    let index = datos.findIndex((item) => item.id == idCelUpdate);

    if (index !== -1) {
        datos[index].nombre = document.querySelector("#nombreCelModal").value;
        datos[index].descripcion = document.querySelector("#descripcionCelModal").value;
        datos[index].stock = document.querySelector("#stockCelModal").value;
        datos[index].marca = document.querySelector("#marcaCelModal").value;
        datos[index].precio = document.querySelector("#precioCelModal").value;
        datos[index].fecha_lanzamiento = document.querySelector("#fechaCelModal").value;
        datos[index].capacidad = document.querySelector("#capacidadCelModal").value;

        cargarTabla();
        myModal.hide();
    }
};

/**
 * Función para cargar la tabla en la página de "Listar"
 */
const cargarTabla = () => {
    const cuerpoTabla = document.querySelector("#cuerpo-tabla");
    if (!cuerpoTabla) return; // Evita errores si la tabla no existe

    cuerpoTabla.innerHTML = "";

    datos.forEach((item) => {
        const fila = document.createElement("tr");

        fila.innerHTML = `
            <th>${item.nombre}</th>
            <td>${item.descripcion}</td>
            <td>${item.stock}</td>
            <td>${item.marca}</td>
            <td>${item.precio}</td>
            <td>${item.fecha_lanzamiento}</td>
            <td>${item.capacidad}</td>
            <td>
                <div class="d-flex gap-2">
                    <button class="btn btn-outline-warning" onclick="mostrarModal(${item.id})">
                        <i class="fa fa-pencil" aria-hidden="true"></i>
                    </button>
                    <button class="btn btn-outline-danger" onclick="borrarCel(${item.id})">
                        <i class="fa fa-times" aria-hidden="true"></i>
                    </button>
                </div>
            </td>
        `;

        cuerpoTabla.appendChild(fila);
    });
};

/**
 * Función para agregar un nuevo celular en la página de "Crear"
 */
const agregarCel = async (event) => {
    event.preventDefault();

    let form = document.querySelector("#formCel");
    if (!form) return; // Evita errores si el formulario no existe
    
    let sku = document.querySelector("#skuCel").value;
    let nombre = document.querySelector("#nombreCel").value;
    let descripcion = document.querySelector("#descripcionCel").value;   
    let precio = document.querySelector("#precioCel").value;
    let stock = document.querySelector("#stockCel").value;
    let marca = document.querySelector("#marcaCel").value;
    let capacidad = document.querySelector("#capacidadCel").value;   
    let fecha_lanzamiento = document.querySelector("#fechaCel").value;


    let nuevoCelular = {
        sku,
        nombre,
        descripcion,
        precio: parseFloat(precio),  // Convertimos a número decimal
        stock: parseInt(stock),  // Convertimos a número si es necesario
        marca,
        capacidad,
        fechaLanzamiento: fecha_lanzamiento
    };

    try {
        let response = await fetch("http://127.0.0.1:8000/celulares/create", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(nuevoCelular)
        });
    
        let data = await response.json();
        console.log("Respuesta del servidor:", data);  // 🔍 Para ver el error exacto
    
        if (response.ok) {
            alert("Celular agregado exitosamente");
            form.reset();
        } else {
            alert(`Error al agregar el celular: ${JSON.stringify(data)}`);
        }
    } catch (error) {
        console.error("Error en la solicitud:", error);
        alert("Error al conectar con el servidor");
    }
    
};


/**
 * Función para borrar un celular en la página de "Listar"
 */
window.borrarCel = (id) => {
    let index = datos.findIndex((item) => item.id == id);

    if (index !== -1) {
        let confirmar = confirm(`¿Está seguro de que quiere eliminar el celular ${datos[index].nombre}?`);
        if (confirmar) {
            datos.splice(index, 1);
            cargarTabla();
        }
    }
};

// Solo ejecuta funciones si los elementos existen en la página actual
if (document.querySelector("#cuerpo-tabla")) {
    cargarTabla();
}

if (document.querySelector("#formCel")) {
    document.querySelector("#formCel").addEventListener("submit", agregarCel);
}

if (document.querySelector("#formModal")) {
    document.querySelector("#formModal").addEventListener("submit", celUpdate);
}
