import Api from "../api.js"; import {qs, alerta} from "../ui.js";

qs("#fCelCreate").onsubmit=async e=>{
  e.preventDefault();
  const data={
    sku      : qs("#sku").value.trim(),
    nombre   : qs("#nombre").value.trim(),
    marca    : qs("#marca").value.trim(),
    descripcion:qs("#desc").value.trim(),
    precio   : Number(qs("#precio").value),
    stock    : Number(qs("#stock").value),
    capacidad: Number(qs("#cap").value),
    fechaLanzamiento: qs("#fecha").value,
  };
  try{
    await Api.crearCel(data);
    alerta("Creado ✓","success");  location.hash = "#/celulares/list";
  }catch(err){ alerta(err); }
};