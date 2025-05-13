/* Router SPA simple por hash */
const views={};
export function defineRuta(hash, loader){ views[hash]=loader; }

async function navegar(){
  const h=location.hash || "#/";
  if(!views[h]){location.hash="#/";return;}
  const htmlPath = "./html/"+h.slice(2)+".html";
  const resp = await fetch(htmlPath); document.querySelector("main").innerHTML = await resp.text();
  views[h]();           // carga módulo JS asociado
}
addEventListener("DOMContentLoaded", navegar);
addEventListener("hashchange"     , navegar);