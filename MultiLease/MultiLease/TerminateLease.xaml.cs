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
using System.Data;
using System.Data.SqlClient;

namespace MultiLease
{
    /// <summary>
    /// Interaction logic for TerminateLease.xaml
    /// </summary>
    public partial class TerminateLease : Window
    {
        private MultiLeaseEntities multileaseContext = null;
        SqlConnection dataConnection = new SqlConnection("Data Source=(local);Initial Catalog=MultiLease;Integrated Security=SSPI");
        SqlCommand dataCommand;
        LeasesP lease;
        int km;

        public TerminateLease(LeasesP l)
        {
            InitializeComponent();
            multileaseContext = new MultiLeaseEntities();
            lease = l;
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            if (kilometers.Text == "" || !int.TryParse(kilometers.Text, out int result))
            {
                MessageBox.Show("Must enter the vehicles kilometers.");
            }
            else
            {
                MessageBoxResult confirmation = MessageBox.Show("Are you sure you wanto to terminate the lease: " + lease.LeaseID.ToString() + "? \nThis action can not be reverted!", "Terminate Lease Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (confirmation == MessageBoxResult.Yes)
                {
                    km = int.Parse(kilometers.Text);
                    Terminate();
                }

            }
        }
        private decimal CalculatePremiumFee()
        {
            dataConnection.Open();
            dataCommand = new SqlCommand("select dbo.CalculatePremiumFee(@LeaseID,@KM)", dataConnection);
            SqlParameter param;
            param = dataCommand.Parameters.Add("@LeaseID", SqlDbType.Int);
            param.Value = lease.LeaseID;
            param = dataCommand.Parameters.Add("@KM", SqlDbType.Int);
            param.Value = km;

            try
            {
                decimal amount = Convert.ToDecimal(string.Format("{0:F2}", dataCommand.ExecuteScalar()));
                return amount;

            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                dataConnection.Close();
            }
        }
        private void UpdateAfterTerminate()
        {
            try
            {
                dataConnection.Open();

                SqlCommand dataCommand = new SqlCommand("TerminateLeaseUpdates", dataConnection);
                dataCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter param;

                param = dataCommand.Parameters.Add("@LeaseID", SqlDbType.Int);
                param.Value = lease.LeaseID;
                param = dataCommand.Parameters.Add("@KM", SqlDbType.Int);
                param.Value = km;

                dataCommand.ExecuteNonQuery();

                MessageBox.Show("Lease: " + lease.LeaseID.ToString() + " was terminated successfully", "Lease terminated", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lease can't be terminated!", "Terminate Lease Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                dataConnection.Close();
            }
        }
        public void Updates(object sender, System.EventArgs e)
        {
            UpdateAfterTerminate();
        }
        private void Terminate()
        {
                decimal fee = CalculatePremiumFee();
                if ( fee > 0)
                {
                    MessageBox.Show("Customer exceeded the MaxKM for these lease. Add a new payment for the premium fee");
                    NewPayment newPayment = new NewPayment(lease.LeaseID.ToString());
                    newPayment.contractDate.SelectedDate = lease.ContractDate;
                    newPayment.amount_textBox.Text = fee.ToString();
                    newPayment.amount_textBox.IsEnabled = false;
                    newPayment.confirm_btn.Click += Updates;
                    newPayment.Show();
                }
            else
            {
                UpdateAfterTerminate();
            }
            
        }

    }
}
