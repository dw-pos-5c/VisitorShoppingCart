using ElementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisitorShoppingCart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Good> cart = new List<Good>();
        List<Good> bag = new List<Good>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstCart.ItemsSource = cart;
            lstBag.ItemsSource = bag;
        }

        private void panButtons_Click(object sender, RoutedEventArgs e)
        {
            var source = e.OriginalSource as Button;
            IVisitor? visitor = null;
            switch (source.Name)
            {
                case "cal":
                    visitor = new CalorieVisitor();
                    break;
                case "alc":
                    visitor = new AlcoholVisitor();
                    break;
                case "price":
                    visitor = new PriceVisitor();
                    break;
                case "html":
                    visitor = new HTMLVisitor();
                    break;
                case "weight":
                    visitor = new WeightVisitor();
                    break;
            }

            if (visitor == null) return;

            foreach (Good g in cart)
            {
                g.Accept(visitor);
            }
            foreach (Good g in bag)
            {
                g.Accept(visitor);
            }

            MessageBox.Show(visitor.ResultString);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            string cat = "";
            if (rbBeverage.IsChecked == true)
            {
                cat = "Beverage";
            } else if (rbBCosmetic.IsChecked == true)
            {
                cat = "Cosmetic";
            } else if (rbFood.IsChecked == true)
            {
                cat = "Food";
            }

            var name = txtName.Text;
            var isparsed = double.TryParse(txtPricePerUnit.Text, out double pricePerUnit);

            bool isCart;
            if (rdoBag.IsChecked == true)
            {
                isCart = false;
            } else if (rdoCart.IsChecked == true)
            {
                isCart = true;
            } else
            {
                return;
            }
            if (cat.Count() == 0 || name.Count() == 0 || !isparsed) return;

            var good = GoodFactory.Create(cat);

            good.Name = name;
            good.NrUnits = (int) sldUnits.Value;
            good.PricePerUnit = pricePerUnit;
            good.Weight = (int) sldWeight.Value;

            if (isCart)
            {
                cart.Add(good);
            } else
            {
                bag.Add(good);
            }

            lstCart.Items.Refresh();
            lstBag.Items.Refresh();
        }
    }
}
