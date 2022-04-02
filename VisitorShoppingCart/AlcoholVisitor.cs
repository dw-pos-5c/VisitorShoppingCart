using ElementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorShoppingCart;
internal class AlcoholVisitor : IVisitor
{
    int count = 0;
    double alcohol = 0;

    public string ResultString => $"Average Alcohol of Beverages: {alcohol/count}";

    public IVisitor Reset()
    {
        count = 0;
        alcohol = 0;
        return this;
    }
    public void VisitBeverage(Beverage beverage) {
        count++;
        alcohol += beverage.Alcohol;
    }
    public void VisitCosmetic(Cosmetic cosmetic) { }
    public void VisitFood(Food food) { }
}
