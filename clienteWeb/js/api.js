/* ----------------- SINGLETON que habla con el backend ----------------- */
const BASE = "http://127.0.0.1:8000";          // ← edita si cambias host

function req(method, url, body){
  return fetch(BASE+url,{
      method,
      headers:{ "Content-Type":"application/json" },
      body: body ? JSON.stringify(body) : undefined
  }).then(async r=>{
      if(!r.ok){
        const d = await r.json().catch(()=>({error:r.statusText}));
        throw d.error || `Error ${r.status}`;
      }
      return r.status===204 ? null : r.json();
  });
}

export const Api = {
  /* celulares ---------------------------------------------------------- */
  crearCel : d      => req("POST"  , "/celulares/create", d),
  obtenerCel:sku    => req("GET"   , `/celulares/${sku}`),
  listarCels:()     => req("GET"   , "/celulares"),
  actCel   :(sku,d) => req("PUT"   , `/celulares/${sku}/update`, d),
  delCel   :sku     => req("DELETE", `/celulares/${sku}/delete`),

  /* cargadores --------------------------------------------------------- */
  crearCar :(sku,d)    => req("POST"  , `/celulares/${sku}/cargadores/create`, d),
  listarCar: sku       => req("GET"   , `/celulares/${sku}/cargadores`),
  actCar   :(sku,id,d) => req("PUT"   , `/celulares/${sku}/cargadores/${id}/update`, d),
  delCar   :(sku,id)   => req("DELETE", `/celulares/${sku}/cargadores/${id}/delete`),
};
export default Api;