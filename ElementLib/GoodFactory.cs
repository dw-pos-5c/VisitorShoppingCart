using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementLib
{
    public class GoodFactory
    {
        public static Good Create(string name)
        {
            switch (name)
            {
                case "Beverage":
                    return new Beverage();
                case "Cosmetic":
                    return new Cosmetic();
                case "Food":
                    return new Food();
            }

            throw new Exception("Not implemented");
        }
    }
}
