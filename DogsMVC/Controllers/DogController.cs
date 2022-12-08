using AspNetCore;
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

        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            var model = service.GetAllDogs();
            return View(model);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Dog dog)
        {
            service.AddDog(dog);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("index/{id}")]
        public IActionResult Index(int id)
        {
            var modelLista = service.GetAllDogs();
            var model = modelLista.FirstOrDefault(b => b.ID == id);
            return View(model);
        }
    }
}
