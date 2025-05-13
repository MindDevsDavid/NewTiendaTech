import Api from "../api.js"; import {qs, alerta} from "../ui.js";

const html=`<h2>Actualizar celular</h2>
<form id="findSku" class="input-group mb-3" style="max-width:400px">
  <input class="form-control" placeholder="SKU…" id="skuB">
  <button class="btn btn-primary">Buscar</button></form>
<form id="fUpd" class="row g-3 d-none">
  <div class="col-md-4"><label class="form-label">Nombre</label><input id="nombre" class="form-control"></div>
  <div class="col-md-4"><label class="form-label">Precio</label><input id="precio" type="number" step="0.01" class="form-control"></div>
  <div class="col-md-4"><label class="form-label">Stock</label><input id="stock" type="number" class="form-control"></div>
  <div class="col-12"><button class="btn btn-warning">Actualizar</button></div></form>`;
qs("main").innerHTML=html;

const fBuscar=qs("#findSku"), fUpd=qs("#fUpd");
let skuSel=null;

fBuscar.onsubmit=async e=>{
  e.preventDefault();
  skuSel=qs("#skuB").value.trim();
  try{
    const cel=await Api.obtenerCel(skuSel);
    fUpd.classList.remove("d-none");
    qs("#nombre").value=cel.nombre;
    qs("#precio").value=cel.precio;
    qs("#stock").value=cel.stock;
  }catch(err){ alerta(err); }
};

fUpd.onsubmit=async e=>{
  e.preventDefault();
  try{
    await Api.actCel(skuSel,{
      nombre:qs("#nombre").value.trim(),
      precio:Number(qs("#precio").value),
      stock :Number(qs("#stock").value),
    });
    alerta("Actualizado ✓","success");
    location.hash = "#/celulares/list";
  }catch(err){ alerta(err); }
};