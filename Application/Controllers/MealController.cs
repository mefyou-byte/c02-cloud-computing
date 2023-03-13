using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private static List<MealModel> Meals = new List<MealModel>();

        private IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<OkObjectResult> Post(FilterMeals filter)
        {
            var meals = await _mealService.getMealsFromAPI(filter);

            Meals.AddRange(meals);

            return Ok(meals);
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public List<MealModel> Get()
        {
            return Meals;
        }

        [HttpPut]
        public IActionResult Update(MealModel meal)
        {
            var existingItem = Meals.FirstOrDefault(x => x.Id == meal.Id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Title = meal.Title;
            existingItem.Thumb = meal.Thumb;

            return Ok(existingItem);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var existingItem = Meals.FirstOrDefault(x => x.Id == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            Meals.Remove(existingItem);

            return NoContent();
        }
    }
}
