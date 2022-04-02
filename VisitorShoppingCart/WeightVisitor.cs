using ElementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorShoppingCart;
internal class WeightVisitor : IVisitor
{
    double weight = 0;

    public string ResultString => $"Total weight: {weight}";

    public IVisitor Reset()
    {
        weight = 0;
        return this;
    }
    public void VisitBeverage(Beverage beverage)
    {
        weight += beverage.Weight; ;
    }
    public void VisitCosmetic(Cosmetic cosmetic)
    {
        weight += cosmetic.Weight;
    }
    public void VisitFood(Food food)
    {
        weight += food.Weight;
    }
}
