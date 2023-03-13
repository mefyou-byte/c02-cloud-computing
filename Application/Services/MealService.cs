using Application.Models;
using Newtonsoft.Json;

namespace Application.Services
{
    public class MealService : IMealService
    {
        public async Task<MealModel[]> getMealsFromAPI(FilterMeals filterMeals)
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://www.themealdb.com/api/json/v1/1/filter.php?i=" + filterMeals.Title);
            var responseContent = await response.Content.ReadAsStringAsync();

            var meals = JsonConvert.DeserializeObject<TheMealDbResponse>(responseContent);

            return meals?.meals
                .Take(filterMeals.Count)
                .Select(meal => MealModel.FromTheMealDb(meal))
                .ToArray() ?? new MealModel[0];
        }
    }
}
