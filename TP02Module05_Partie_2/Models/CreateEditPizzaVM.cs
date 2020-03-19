using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP02Module05_Partie_2
{
    public class CreateEditPizzaVM
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Pate> Pates { get; set; } = new List<Pate>();
        [Required(ErrorMessage = "Veuillez sélectionnez une pate")]
        public int IdSelectedPate { get; set; }
        public List<int> IdSelectedIngredients { get; set; } = new List<int>();
    }
}
