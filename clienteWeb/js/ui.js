export const qs = (sel, ctx=document) => ctx.querySelector(sel);

export function alerta(msg, tipo="danger"){
  const div=document.createElement("div");
  div.className=`alert alert-${tipo} position-fixed top-0 start-50 translate-middle-x mt-2`;
  div.textContent=msg;
  document.body.append(div);
  setTimeout(()=>div.remove(),3500);
}

export function filaTabla(obj, campos, acciones=[]){
  const tr=document.createElement("tr");
  campos.forEach(k=>{
     const td=document.createElement("td");
     td.textContent=obj[k] ?? ""; tr.append(td);
  });
  const td=document.createElement("td"); acciones.forEach(a=>td.append(a));
  tr.append(td); return tr;
}