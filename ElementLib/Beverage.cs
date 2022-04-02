using System;

namespace ElementLib
{
  public class Beverage : Good
  {
        public Beverage()
        {
            Calories = new Random().Next(5, 100);
            Alcohol = new Random().Next(1, 700) / 10; 
        }

    public int Calories { get; set; }
    public double Alcohol { get; set; }
    public override void Accept(IVisitor visitor)
    {
      visitor.VisitBeverage(this);
    }
  }
}
