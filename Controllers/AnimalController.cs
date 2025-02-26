using Microsoft.AspNetCore.Mvc;

namespace WebZoo.Controllers
{
    [ApiController]
    [Route("api/animals/")]
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

            if (!animalList.Any())
            {
                return NotFound("Зоопарк пуст");
            }

            return Ok(animalList);
        }

        [HttpGet("{id}")]
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

            if (name == null && animalType == null)
            {
                return BadRequest("Неверное имя или вид животного");                
            }

            return Ok(newAnimal);
        }

        [HttpPut("{id}/feed")]
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

                return Ok("Покормили с кайфом");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            if (_animalService.GetAnimalById(id) != null)
            {
                _animalService.RemoveAnimal(id);
                return NoContent();
            }
            else { return NotFound("Нечего удалять"); }
        }
    }
}
