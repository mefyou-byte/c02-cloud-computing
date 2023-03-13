namespace Application.Models
{
    public class MealModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Thumb { get; set; }

        public MealModel(string id, string title, string thumb)
        {
            Id = id;
            Title = title;
            Thumb = thumb;
        }

        public static MealModel FromTheMealDb(TheMealDbResponse.MealItem meal)
        {
            return new MealModel(meal.idMeal, meal.strMeal, meal.strMealThumb);
        }
    }
}