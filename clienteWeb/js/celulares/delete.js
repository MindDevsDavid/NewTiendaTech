import Api from "../api.js"; import {qs, filaTabla, alerta} from "../ui.js";

const f=qs("#fBuscar"); const res=qs("#resultado");
let encontrado=null;

f.onsubmit=async e=>{
  e.preventDefault(); res.innerHTML="";
  const sku=qs("#skuBuscar").value.trim();
  try{
    encontrado=await Api.obtenerCel(sku);
    const tabla=document.createElement("table");
    tabla.className="table mb-3";
    const tbody=document.createElement("tbody");
    tabla.innerHTML=`<thead><tr><th>SKU</th><th>Nombre</th><th>Marca</th><th>Acción</th></tr></thead>`;
    const btn=document.createElement("button");
    btn.className="btn btn-danger btn-sm"; btn.textContent="Borrar";
    btn.onclick=borrar;
    tbody.append(filaTabla(encontrado,["sku","nombre","marca"],[btn]));
    tabla.append(tbody); res.append(tabla);
  }catch(err){ alerta(err); }
};

async function borrar(){
  if(!confirm(`¿Eliminar celular ${encontrado.sku}?`)) return;
  try{
    await Api.delCel(encontrado.sku);
    alerta("Eliminado ✓","success"); location.hash = "#/celulares/list";
  }catch(e){ alerta(e); }
}