using ElementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorShoppingCart;
public class CalorieVisitor : IVisitor
{
    int calories = 0;

    public string ResultString => $"Calories {calories} kcal";

    public IVisitor Reset()
    {
        calories = 0;
        return this;
    }
    public void VisitBeverage(Beverage beverage)
    {
        calories += beverage.Calories;
    }

    public void VisitCosmetic(Cosmetic cosmetic) {
    }

    public void VisitFood(Food food) {
        calories += food.Calories;
    }
}
