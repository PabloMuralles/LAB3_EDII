using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace lab3.Controllers
{
  
    public class BebidasController : ControllerBase
    {
        [HttpPost]
        [Route("api/insertar")]
        public  ActionResult Insertar([FromBody] Bebidas Soda)
        {
            if (ModelState.IsValid)
            {
                Estructura.ArbolB_Estrella_.Instance.Creacion(Soda.Nombre, Soda.Sabor, Soda.Volumen, Soda.Precio, Soda.Casa_Productora);
                return Ok();
            }
            return BadRequest(ModelState);
        }




        [HttpGet]
        [Route("api/registro")]
        public ActionResult<string> Registro()
        {



            var json = JsonConvert.SerializeObject(Estructura.ArbolB_Estrella_.Instance.IngresarRetorno());
            return json;


        }

        [HttpGet]
        [Route("api/buscar/{nombre}")]
        public ActionResult Buscar(string nombre)
        {
            if (ModelState.IsValid)
            {
                Bebidas bebida = Estructura.ArbolB_Estrella_.Instance.Buscar(nombre);
                if (bebida != null)
                    return Ok(bebida);
                return NotFound();
            }
            return BadRequest(ModelState);
        }


    }
}