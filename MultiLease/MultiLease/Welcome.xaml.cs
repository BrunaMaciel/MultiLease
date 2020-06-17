using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace MultiLease
{
    /// <summary>
    /// Interaction logic for MultiLease.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }
        
        private void MenuNewLease_Click(object sender, RoutedEventArgs e)
        {
            NewLease newLease = new NewLease();
            newLease.ShowDialog();
        }

        private void MenuSearchLease_Click(object sender, RoutedEventArgs e)
        {
            SearchLeases searchLease = new SearchLeases();
            searchLease.Show();
        }

        private void MenuSearchPayment_Click(object sender, RoutedEventArgs e)
        {
            SearchPayments searchPayments = new SearchPayments();
            searchPayments.Show();
        }

        private void MenuNewPayment_Click(object sender, RoutedEventArgs e)
        {
            NewPayment np = new NewPayment();
            np.Show();
        }

        private void MenuEditLease_Click(object sender, RoutedEventArgs e)
        {
            EditByLeaseID ef = new EditByLeaseID();
            ef.Show();
        }
        
    }
    [ValueConversion(typeof(string), typeof(Decimal))]
    class PriceConverter : IValueConverter
    {

        object IValueConverter.Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
                return String.Format("{0:C}", value);
            else
                return "";
        }

        object IValueConverter.ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
