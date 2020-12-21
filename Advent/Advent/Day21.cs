using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day21
    {
        public int CountNonAllergens(string input)
        {
            var (foods, allIngredients, matrix) = Decode(input);

            return allIngredients
                .Where(ingredient => !matrix.ContainsIngredient(ingredient))
                .Sum(ingredient => foods.Count(food => food.ContainsIngredient(ingredient)));
        }

        public string Dangerous(string input)
        {
            var matrix = Decode(input).matrix;

            var ingredientAllergen = new Dictionary<string, string>();
            
            while (matrix.AnyWithIngredients())
            {
                var single = matrix.FirstWithSingleIngredient();
                ingredientAllergen[single.allergen] = single.ingredient;
                matrix.RemoveIngredient(single.ingredient);
            }

            var inOrder = ingredientAllergen
                .Select(kp => (allergen: kp.Key, ingredient: kp.Value))
                .OrderBy(kp => kp.allergen)
                .Select(kp => kp.ingredient);

            return string.Join(',', inOrder);
        }

        private (Food[] foods, HashSet<string> allIngredients, Matrix matrix) Decode(string input)
        {
            var foods = input
                .Split(Environment.NewLine)
                .Select(l => new Food(l))
                .ToArray();

            var allCombos = new Matrix();

            var allIngredients = new HashSet<string>();

            foreach (var food in foods)
            {
                foreach (var allergen in food.Allergens)
                {
                    foreach (var ingredient in food.Ingredients)
                    {
                        allCombos.AddToAllergen(allergen, ingredient);
                    }
                }
            }

            foreach (var food in foods)
            {
                foreach (var ingredient in food.Ingredients)
                {
                    allIngredients.Add(ingredient);
                }
            }

            var matrix = new Matrix();

            foreach (var pair in allCombos.Pairs())
            {
                foreach (var ingredient in pair.Ingredients
                    .Where(ingredient => foods.Where(food => food.ContainsAllergen(pair.Allergen))
                        .All(food => food.ContainsIngredient(ingredient))))
                {
                    matrix.AddToAllergen(pair.Allergen, ingredient);
                }
            }

            return (foods, allIngredients, matrix);
        }

        private class Matrix : Dictionary<string, HashSet<string>>
        {
            public void AddToAllergen(string allergen, string ingredient)
            {
                if (!ContainsKey(allergen))
                    this[allergen] = new HashSet<string>();
                this[allergen].Add(ingredient);
            }

            public bool ContainsIngredient(string ingredient) => Values.Any(v => v.Contains(ingredient));

            public bool AnyWithIngredients() => Values.Any(v => v.Count > 0);

            public (string allergen, string ingredient) FirstWithSingleIngredient()
            {
                var (allergen, ingredients) = this.First(p => p.Value.Count == 1);
                return (allergen, ingredients.First());
            }

            public IEnumerable<AllergenIngredients> Pairs() =>
                this.Select(kp => new AllergenIngredients(kp.Key, kp.Value));
            
            public void RemoveIngredient(string ingredient)
            {
                foreach (var pair in this)
                {
                    pair.Value.Remove(ingredient);
                }
            }
        }

        private class AllergenIngredients
        {
            public readonly string Allergen;
            public readonly HashSet<string> Ingredients;

            public AllergenIngredients(string allergen, HashSet<string> ingredients)
            {
                Allergen = allergen;
                Ingredients = ingredients;
            }
        }

        private class Food
        {
            public readonly HashSet<string> Ingredients;
            public readonly HashSet<string> Allergens;

            public Food(string data)
            {
                var split = data.Split(" (contains ");
                Ingredients = split[0].Split(' ').ToHashSet();
                Allergens = split[1]
                    .Replace(",", "")
                    .Replace(")", "")
                    .Split(' ')
                    .ToHashSet();
            }

            public bool ContainsIngredient(string ingredient) => Ingredients.Contains(ingredient);

            public bool ContainsAllergen(string allergen) => Allergens.Contains(allergen);
        }
    }
}
