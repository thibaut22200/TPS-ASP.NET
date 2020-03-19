using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace TP02Module05_Partie_1.Controllers
{
    public class PizzaController : Controller
    {
        private static List<Pizza> pizzas = new List<Pizza>();
        private static List<Ingredient> ingredients = Pizza.IngredientsDisponibles;
        private static List<Pate> pates = Pizza.PatesDisponibles;

        // GET: Pizza
        public ActionResult Index()
        {
            return View(pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = getPizzaById(id);
            if(pizza == null)
            {
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            var pizzaVM = new CreateEditPizzaVM { Ingredients = ingredients, Pates = pates };
            return View(pizzaVM);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(CreateEditPizzaVM pizzaVM)
        {
            try
            {
                Pizza pizza = new Pizza {
                    Id = pizzas.OrderByDescending(p => p.Id).Select(p => p.Id).FirstOrDefault() + 1,
                    Pate = pates.First(p => p.Id == pizzaVM.IdSelectedPate),
                    Nom = pizzaVM.Pizza.Nom
                };
                foreach (var idIngredient in pizzaVM.IdSelectedIngredients)
                {
                    pizza.Ingredients.Add(ingredients.First(i => i.Id == idIngredient));
                }

                pizzas.Add(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            Pizza pizza = getPizzaById(id);

            if(pizza != null)
            {
                var pizzaVM = new CreateEditPizzaVM { Pizza = pizza, Ingredients = ingredients, Pates = pates };
                return View(pizzaVM);
            }
            return View("Index");
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateEditPizzaVM pizzaVM)
        {
            try
            {
                Pizza pizza = pizzas.SingleOrDefault(p => p.Id == pizzaVM.Pizza.Id);

                pizza.Nom = pizzaVM.Pizza.Nom;
                pizza.Ingredients.Clear();
                foreach (var idIngredient in pizzaVM.IdSelectedIngredients)
                {
                    pizza.Ingredients.Add(ingredients.First(i => i.Id == idIngredient));
                }
                pizza.Pate = pates.First(p => p.Id == pizzaVM.IdSelectedPate);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = getPizzaById(id);
            if(pizza == null)
            {
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(Pizza pizza)
        {
            try
            {
                pizzas.Remove(pizzas.FirstOrDefault(p => p.Id == pizza.Id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // METHODES PRIVEES
        private Pizza getPizzaById(int id)
        {
            var pizza = pizzas.FirstOrDefault(c => c.Id == id);

            return pizza;
        }
    }
}
