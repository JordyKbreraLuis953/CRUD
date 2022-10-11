using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4toTI.Models;
using _4toTI.Services;
using Microsoft.AspNetCore.Mvc;

namespace _4toTI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController ()
    {

    }
      
     [HttpGet]

     public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
   
     [HttpGet("{Id}")]  

      public ActionResult<Pizza> Get (int Id)
    {
       var pizza = PizzaService.Get(Id);
        if (pizza == null)
          
        
            return NotFound();
            return pizza; 
    }
     
      [HttpPost]

      public IActionResult Create(Pizza pizza)   
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new {Id = pizza}, pizza);
    }
     [HttpDelete("{Id}")]

     public IActionResult   Delete(int Id)   
     {
     var pizza = PizzaService.Get(Id);
     if(pizza is null)
     return NotFound();

     PizzaService.Delete(Id);
     
     return NoContent();
     }
[HttpPut("{Id}")]
 public IActionResult Update(int Id, Pizza pizza)
{
     if(Id != pizza.Id)
     return BadRequest();

     var existingPizza = PizzaService.Get(Id);
     if(existingPizza is null)
     return NotFound();

     PizzaService.Update(pizza);
     return NoContent();
}
}
}