using ElementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorShoppingCart;
internal class HTMLVisitor : IVisitor
{
    string html = "";

    public string ResultString => $"<table><td><th>Produkt</th><th>Preis</th><th>Gewicht</th><th>Info</th></td>{html}</table>";

    public IVisitor Reset()
    {
        html = "";
        return this;
    }
    public void VisitBeverage(Beverage beverage)
    {
        html += $"<tr><td>{beverage.Name}</td><td>{beverage.PricePerUnit}</td><td>{beverage.Weight}</td><td>{beverage.Alcohol}% Alc.</td></tr>";
    }
    public void VisitCosmetic(Cosmetic cosmetic)
    {
        html += $"<tr><td>{cosmetic.Name}</td><td>{cosmetic.PricePerUnit}</td><td>{cosmetic.Weight}</td><td></td></tr>";
    }

    public void VisitFood(Food food)
    {
        html += $"<tr><td>{food.Name}</td><td>{food.PricePerUnit}</td><td>{food.Weight}</td><td>{food.Calories} kcal</td></tr>";
    }
}
