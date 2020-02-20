using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using lab3.Estructura;
 

namespace lab3.Controllers
{
  
    public class BebidasController : ControllerBase
    {
        int order = 7;
        // Tree for the meds
        private static BTree<Bebidas, string> tree = new BTree<Bebidas, string>(5);

        [HttpPost]
        [Route("api/insertar")]
        public  ActionResult Insertar([FromBody] Bebidas Soda)
        {
            if (ModelState.IsValid)
            {
                tree.Insert(Soda.Nombre, Soda);
                return Ok();
            }
            return BadRequest(ModelState);
        }

    }
}