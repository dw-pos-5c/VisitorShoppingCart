using ElementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorShoppingCart;
internal class PriceVisitor: IVisitor
{
    double price = 0;

    public string ResultString => $"Total price: {price}";

    public IVisitor Reset()
    {
        price = 0;
        return this;
    }
    public void VisitBeverage(Beverage beverage)
    {
        price += beverage.PricePerUnit * beverage.NrUnits;
    }
    public void VisitCosmetic(Cosmetic cosmetic)
    {
        price += cosmetic.PricePerUnit * cosmetic.NrUnits;
    }
    public void VisitFood(Food food)
    {
        price += food.PricePerUnit * food.NrUnits;
    }
}
