
using Application.Models;

namespace Application.Services
{
    public interface IMealService
    {
        Task<MealModel[]> getMealsFromAPI(FilterMeals filterMeals);
    }
}