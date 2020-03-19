using System.Collections.Generic;

namespace TP02Module05_Partie_1
{
    public class CreateEditPizzaVM
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Pate> Pates { get; set; } = new List<Pate>();

        public int IdSelectedPate { get; set; }
        public List<int> IdSelectedIngredients { get; set; } = new List<int>();
    }
}
