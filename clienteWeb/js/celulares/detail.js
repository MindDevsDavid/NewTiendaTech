import Api from "../api.js"; import {qs, filaTabla, alerta} from "../ui.js";

const skuPrompt = prompt("Ingrese SKU del celular:");
if(!skuPrompt){ location.hash="#/"; throw ""; }

async function cargar(){
  const cel = await Api.obtenerCel(skuPrompt);
  let html=`<h2>Detalle celular ${cel.sku}</h2>
  <ul class="list-group mb-3">
    <li class="list-group-item">Nombre: ${cel.nombre}</li>
    <li class="list-group-item">Marca : ${cel.marca}</li>
    <li class="list-group-item">Precio: $${cel.precio}</li>
  </ul>
  <h4>Cargadores</h4>
  <a href="#/car/create?sku=${cel.sku}" class="btn btn-sm btn-success mb-2">Añadir cargador</a>
  <table class="table"><thead>
   <tr><th>ID</th><th>Marca</th><th>Voltaje</th><th>Cable (m)</th></tr>
  </thead><tbody></tbody></table>`;
  qs("main").innerHTML=html;

  const tbody=qs("tbody");
  (await Api.listarCar(cel.sku)).forEach(c=>{
     tbody.append(filaTabla(c,["id","marca","capVoltaje","cableLength"]));
  });
}
cargar().catch(alerta);