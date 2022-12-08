using DogsMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogsMVC.Controllers
{
    public class DogController : Controller
    {
        DogsList service;
        public DogController()
        {
            service = new DogsList(); //nyas upp vid varje anrop. så varje gång får vi en ny lista och när dem fyller i listan sparas det inte.

        }

        [HttpGet("index")] 
        public IActionResult Index() 
        {
            return View();
        }

        [HttpPost("index")]
        public IActionResult Index(Dog dog)  
        {
            service.AddDog(dog);
            return RedirectToAction(nameof(Index)); 
        }
    }
}
