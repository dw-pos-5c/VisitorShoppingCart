using System;

namespace ElementLib
{
    public class Food : Good
    {
        public Food()
        {
            Calories = new Random().Next(80, 1200);
        }

        public int Calories { get; set; }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitFood(this);
        }
    }
}
