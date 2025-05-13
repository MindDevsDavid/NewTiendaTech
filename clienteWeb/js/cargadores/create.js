import Api from "../api.js"; import {qs, alerta} from "../ui.js";
qs("#fCarCreate").onsubmit=async e=>{
  e.preventDefault();
  try{
    await Api.crearCar(qs("#sku").value.trim(),{
      id           : Number(qs("#id").value),
      marca        : qs("#marca").value.trim(),
      capVoltaje   : Number(qs("#volt").value),
      longCable    : Number(qs("#cable").value),
      fechaGarantia: qs("#fecha").value
    });
    alerta("Cargador creado ✓","success"); const params = new URLSearchParams(location.hash.split("?")[1]);
    const skuParam = params.get("sku");
    location.hash = `#/cargadores/list?sku=${skuParam}`;
  }catch(err){ alerta(err); }
};