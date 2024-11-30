using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConstructDeconstruct
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

        public void OnAddPressed(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string priceText = PriceTextBox.Text;
            string quantityText = QuantityTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(priceText))
            {
                MessageBox.Show("Необходимо заполнить поля \"Имя\" и \"Цена\".");
                return;
            }
            else if(FindDuplicatedName(name))
            {
                MessageBox.Show("Товар с таким именем уже есть.");
                return;
            }
            try
            {
                if (string.IsNullOrWhiteSpace(quantityText) && !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(priceText))
                {
                    Product product = new Product(name, Convert.ToDouble(priceText));
                    MainListBox.Items.Add(product);   
                }
                else if (!string.IsNullOrWhiteSpace(quantityText) && !string.IsNullOrWhiteSpace(name) && priceText != null)
                {
                    Product product = new Product(name, Convert.ToDouble(priceText), Convert.ToInt32(quantityText));
                    MainListBox.Items.Add(product);
                }

            }//Git you are here?
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool FindDuplicatedName(string name) 
        {
            bool duplicateFound = false;
            foreach (Product product in MainListBox.Items)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) 
                {
                    duplicateFound = true;
                    return duplicateFound;
                }
            }
            return duplicateFound;
        }
        public void OnGetInfoPressed(object sender, RoutedEventArgs e) 
        {
            if(MainListBox.SelectedItem != null) 
            {
                Product product = (Product)MainListBox.SelectedItem;

                (string name, double price, int quantity) = product;
                MessageBox.Show($"Название: {name}, Цена: {price} руб, Количество: {quantity} шт");
            }
            else if(MainListBox.Items.Count == 0)
            {
                MessageBox.Show("Нет ни одного добавленного товара.");
            }
        }


    }
}