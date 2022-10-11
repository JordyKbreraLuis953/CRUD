using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _4toTI.Models;
using _4toTI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _4toTI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidasController : ControllerBase
    {
        public BebidasController ()
    {

    }
      
     [HttpGet]

     public ActionResult<List<Bebidas>> GetAll() => BebidasService.GetAll();
   
     [HttpGet("{Id}")]  

      public ActionResult<Bebidas> Get (int Id)
    {
       var Bebidas = BebidasService.Get(Id);
        if (Bebidas == null)
          
        
            return NotFound();
            return  Bebidas; 
    }
     
      [HttpPost]

      public IActionResult Create(Bebidas bebidas)   
    {
        BebidasService.Add(bebidas);
        return CreatedAtAction(nameof(Create), new {Id = bebidas}, bebidas);
    }
     [HttpDelete("{Id}")]

     public IActionResult   Delete(int Id)   
     {
     var bebidas = BebidasService.Get(Id);
     if(bebidas is null)
     return NotFound();

     BebidasService.Delete(Id);
     
     return NoContent();
     }
[HttpPut("{Id}")]
 public IActionResult Update(int Id, Bebidas Bebidas)
{
     if(Id != Bebidas.Id)
     return BadRequest();

     var existingBebidas = BebidasService.Get(Id);
     if(existingBebidas is null)
     return NotFound();

     BebidasService.Update(Bebidas);
     return NoContent();
}
}
}