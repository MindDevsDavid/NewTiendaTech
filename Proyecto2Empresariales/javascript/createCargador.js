import datos from "../data/data.json" with { type: "json" };
import { Cargador } from "./clases.js";

/**
 * Función para agregar un nuevo cargador en la página de "Crear"
 */
const agregarCargador = async (event) => {
    event.preventDefault();

    const form = document.querySelector("#formCargador");
    if (!form) return; // si no existe el formulario, salimos

    // Tomamos valores de los inputs
    const id = document.querySelector("#idCarg").value;
    const capacidadVoltaje = document.querySelector("#capacidadVoltaje").value;
    const marca = document.querySelector("#marcaCarg").value;
    const largoCable = document.querySelector("#largoCable").value;
    const fechaGarantia = document.querySelector("#fechaGarantia").value;

    // Creamos el objeto a enviar
    const nuevoCargador = {
        id,
        capacidadVoltaje: parseFloat(capacidadVoltaje),
        marca,
        largoCable: parseFloat(largoCable),
        fechaGarantia
    };

    try {
        const response = await fetch("http://127.0.0.1:8000/cargadores/create", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(nuevoCargador)
        });

        const data = await response.json();
        console.log("Respuesta del servidor:", data);

        if (response.ok) {
            alert("Cargador agregado exitosamente");
            form.reset();
        } else {
            alert(`Error al agregar el cargador: ${JSON.stringify(data)}`);
        }
    } catch (error) {
        console.error("Error en la solicitud:", error);
        alert("Error al conectar con el servidor");
    }
};

// Vinculamos el listener si estamos en la página de creación de cargador
if (document.querySelector("#formCargador")) {
    document.querySelector("#formCargador")
            .addEventListener("submit", agregarCargador);
}
