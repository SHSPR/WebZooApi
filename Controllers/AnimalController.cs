using Microsoft.AspNetCore.Mvc;

namespace WebZoo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            var animalList = _animalService.GetAllAnimals();
            if (animalList == null)
            {
                return NotFound("Зоопарк пуст");
            }
            else
            {
                return Ok(animalList);
            }
        }

        [HttpGet("/{id}")]
        public IActionResult GetAnimal(int id)
        {
            var exactAnimal = _animalService.GetAnimalById(id);

            if (exactAnimal == null)
            {
                return NotFound($"Животного с номером: {id} не существует");
            }
            else
            {
                return Ok(exactAnimal);
            }
        }

        [HttpPost]
        public IActionResult AddAnimal(string animalType, string name)
        {
            var newAnimal = _animalService.AddAnimal(animalType, name);

            if (name != null && animalType != null)
            {
                return Ok(newAnimal);
            }
            else
            {
                return BadRequest("Неверное имя или вид животного");
            }            
        }

        [HttpPut("/{id}/feed")]
        public IActionResult FeedAnimal(int id, int foodQuantity)
        {        
            if (_animalService.GetAnimalById(id) == null)
            {
                return NotFound($"Не найдено животного с номером: {id}");
            }
            else if (foodQuantity <= 0) 
            { 
                return BadRequest("Количество еды не может быть отрицательным");
            }
            else
            {
                _animalService.FeedAnimal(id, foodQuantity);

                return Ok();
            }
        }

        [HttpDelete("/{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            if (_animalService.GetAnimalById(id) != null)
            {
                _animalService.RemoveAnimal(id);
                return NoContent();
            }
            else { return NotFound(); }
        }
    }
}
