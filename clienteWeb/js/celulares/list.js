import Api from "../api.js"; import {qs, filaTabla, alerta} from "../ui.js";

async function cargar(){
  const cont=document.createElement("div");
  cont.innerHTML=`<h2>Lista de celulares</h2>
                  <table class="table"><thead>
                    <tr><th>SKU</th><th>Nombre</th><th>Marca</th><th>Stock</th><th></th></tr>
                  </thead><tbody></tbody></table>`;
  qs("main").append(cont);
  const tbody=cont.querySelector("tbody");
  try{
    const lista=await Api.listarCels();
    lista.forEach(c=>{
      const btnCar=document.createElement("a");
      btnCar.className="btn btn-sm btn-secondary";
      btnCar.textContent="Cargadores";
      btnCar.href=`#/car/list?sku=${c.sku}`;
      tbody.append(filaTabla(c,["sku","nombre","marca","stock"],[btnCar]));
    });
  }catch(e){ alerta(e); }
}
cargar();