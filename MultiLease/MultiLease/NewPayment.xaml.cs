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
using System.Windows.Shapes;
using System.Data.Objects;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MultiLease
{
    /// <summary>
    /// Interaction logic for NewPayment.xaml
    /// </summary>
    public partial class NewPayment : Window
    {
        private MultiLeaseEntities multileaseContext = null;
        public NewPayment()
        {
            InitializeComponent();
            this.multileaseContext = new MultiLeaseEntities();
            paymentDate.SelectedDate = DateTime.Today;
            amount_textBox.Text = "$0.00";
        }
        public NewPayment(string leaseID)
        {
            InitializeComponent();
            this.multileaseContext = new MultiLeaseEntities();
            leaseID_textBox.Text = leaseID;
            leaseID_textBox.IsEnabled = false;
            lease_lb.IsEnabled = false;
            paymentDate.SelectedDate = DateTime.Today;
            amount_textBox.Text = "$0.00";
        }

        private void Confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string value = amount_textBox.Text.Replace(",", "").Replace("$", "").TrimStart('0');
                Payment newPay = new Payment();

                newPay.Amount = decimal.Parse(value);
                newPay.PaymentDate = paymentDate.SelectedDate;
                newPay.LeaseID = int.Parse(leaseID_textBox.Text);
                newPay.ContractDate = contractDate.SelectedDate;
                newPay.Valid = "Yes";

                var confirmSave = MessageBox.Show("LeaseID: " + newPay.LeaseID + "\n" +
                                             "Contract Date: " + newPay.ContractDate + "\n" +
                                             "Payment Date: " + newPay.PaymentDate + "\n" +
                                             "Amount: " + newPay.Amount,
                                             "Save the following new payment?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmSave == MessageBoxResult.Yes)
                {
                    ObjectSet<Payment> pays = multileaseContext.Payments;
                    pays.AddObject(newPay);
                    multileaseContext.SaveChanges();
                    MessageBox.Show("New payment saved successfully!", "New Payment Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving new payment", MessageBoxButton.OK, MessageBoxImage.Error);
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
            EnableConfirm();
        }

        private bool AmountisValid(string text)
        {
            Regex money = new Regex(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$");
            return money.IsMatch(text);
        }


        private void PaymentDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableConfirm();
        }

        private void EnableConfirm()
        {
            if(leaseID_textBox.Text != "" && contractDate.Text!="" && amount_textBox.Text!= "$0.00" && paymentDate.Text != "")
            {
                confirm_btn.IsEnabled = true;
            }
        }

        private void LeaseID_textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (leaseID_textBox.Text != "")
            {
                int leaseID = int.Parse(leaseID_textBox.Text);
                try
                {
                    var lease = multileaseContext.LeasesPs.Where(l => l.LeaseID == leaseID).First();
                    if (lease != null)
                    {
                        contractDate.SelectedDate = lease.ContractDate;
                        EnableConfirm();
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Invalid LeaseID");
                    leaseID_textBox.Text = "";
                }
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
