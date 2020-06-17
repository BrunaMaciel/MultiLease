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
using System.ComponentModel;
using System.Collections;
using System.Data.Objects;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MultiLease
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewLease : Window
    {
        private MultiLeaseEntities multileaseContext = null;
        private DetailedVehicle vehicle = null;
        private LeaseTerm term = null;
        private Customer customer = null;

        public NewLease()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.multileaseContext = new MultiLeaseEntities();
            customersList.DataContext = this.multileaseContext.Customers;
            termsList.DataContext = this.multileaseContext.LeaseTerms;
            vehiclesList.DataContext = this.multileaseContext.DetailedVehicles;
            contractDate.SelectedDate = DateTime.Today;
            firstPaymentDate.SelectedDate = contractDate.SelectedDate.Value.AddMonths(1);
            amount_textBox.Text = "$0.00";
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string value = amount_textBox.Text.Replace(",", "").Replace("$", "").TrimStart('0');
                LeasesP newLease = new LeasesP();

                newLease.LeaseID = int.Parse(leaseID_textbox.Text);

                newLease.ContractDate = contractDate.SelectedDate.Value;

                newLease.FirstPaymentDate = firstPaymentDate.SelectedDate.Value;

                newLease.MonthlyPayment = decimal.Parse(value);

                if (months12.IsChecked == true)
                    newLease.NumOfPayments = 12;
                if (months24.IsChecked == true)
                    newLease.NumOfPayments = 24;
                if (months36.IsChecked == true)
                    newLease.NumOfPayments = 36;
                if (months48.IsChecked == true)
                    newLease.NumOfPayments = 48;

                this.vehicle = vehiclesList.SelectedItem as DetailedVehicle;
                newLease.VehicleID = this.vehicle.VIN;

                this.term = termsList.SelectedItem as LeaseTerm;
                newLease.TermsID = this.term.LeaseTermID;

                this.customer = customersList.SelectedItem as Customer;
                newLease.CustomerID = this.customer.CustomerID;

                newLease.StatusID = 1;

                var confirmSave = MessageBox.Show("LeaseID: " + newLease.LeaseID + "\n" +
                                             "Contract Date: " + newLease.ContractDate + "\n" +
                                             "Vehicle ID: " + newLease.VehicleID + "\n" +
                                             "Terms ID: " + newLease.TermsID + "\n" +
                                             "CustomerID: " + newLease.CustomerID + "\n" +
                                             "First Payment Date: " + newLease.FirstPaymentDate + "\n" +
                                             "Amount: " + newLease.MonthlyPayment + "\n" +
                                             "Num of Payments: " + newLease.NumOfPayments + "\n",
                                             "Save the following new listing?", MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (confirmSave == MessageBoxResult.Yes)
                {
                    ObjectSet<LeasesP> leases = multileaseContext.LeasesPs;
                    leases.AddObject(newLease);
                    multileaseContext.SaveChanges();
                    MessageBox.Show("New lease saved successfully!", "New Lease Saved",MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving new lease", MessageBoxButton.OK, MessageBoxImage.Error);
            }            

        }
        
        private void Amount_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail including leading zeros
            string value = amount_textBox.Text.Replace(",", "").Replace("$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(value, out ul))
            {
                ul /= 100;
                //Unsub the event so we don't enter a loop
                amount_textBox.TextChanged -= Amount_textBox_TextChanged;
                //Format the text as currency
                amount_textBox.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", ul);
                amount_textBox.TextChanged += Amount_textBox_TextChanged;
                amount_textBox.Select(amount_textBox.Text.Length, 0);
            }

            bool validInput = AmountisValid(amount_textBox.Text);

            if (!validInput)
            {
                amount_textBox.Text = "$0.00";
                amount_textBox.Select(amount_textBox.Text.Length, 0);
            }
        }

        private bool AmountisValid(string text)
        {
            Regex money = new Regex(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$");
            return money.IsMatch(text);
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
}
