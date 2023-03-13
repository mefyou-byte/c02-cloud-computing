namespace Application.Models
{
    public class TheMealDbResponse
    {
        public MealItem[] meals { get; set; }

        public class MealItem
        {
            public string strMeal { get; set; }
            public string strMealThumb { get; set; }
            public string idMeal { get; set; }
        }
    }
}