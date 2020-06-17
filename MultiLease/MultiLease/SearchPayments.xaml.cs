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
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;

namespace MultiLease
{
    /// <summary>
    /// Interaction logic for Leases.xaml
    /// </summary>
    public partial class SearchPayments : Window
    {
        SqlConnection dataConnection = new SqlConnection("Data Source=(local);Initial Catalog=MultiLease;Integrated Security=SSPI");
        SqlDataAdapter da;
        DataSet ds;
        MultiLeaseEntities context;
        string command = "SELECT * FROM LeasesPayments";

        public SearchPayments()
        {
            InitializeComponent();
            this.context = new MultiLeaseEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPaymentsList(command);

        }
        private void LoadPaymentsList(string command)
        {
            ds = new DataSet();
            da = new SqlDataAdapter(command, dataConnection);
            da.Fill(ds, "LeasesPayments");
            paymentList.DataContext = ds.Tables["LeasesPayments"].DefaultView;
        }

        private void Search_btn_Click(object sender, RoutedEventArgs e)
        {
            string searchCommand = command;
            bool first = true;

            if (leaseID_search.Text != "")
            {
                if (first)
                {
                    searchCommand += " where LeaseID = " + leaseID_search.Text;
                    first = false;
                }
                else
                    searchCommand += " AND LeaseID = " + leaseID_search.Text;
            }
            if (paymentID_search.Text != "")
            {
                if (first)
                {
                    searchCommand += " where PaymentID = " + paymentID_search.Text;
                    first = false;
                }
                else
                    searchCommand += " AND PaymentID = " + paymentID_search.Text;
            }
            if (nameSearch_textBox.Text != "")
            {
                if (first)
                {
                    searchCommand += " where Customer LIKE '%" + nameSearch_textBox.Text + "%'";
                    first = false;
                }
                else
                    searchCommand += " AND Customer LIKE '%" + nameSearch_textBox.Text + "%'";
            }
            if (contractDate_search.Text != "")
            {
                if (first)
                {
                    searchCommand += " where ContractDate ='" + contractDate_search.Text+"'";
                    first = false;
                }
                else
                    searchCommand += " AND ContractDate ='" + contractDate_search.Text+"'";
            }
            if (paymentDate_search.Text != "")
            {
                if (first)
                {
                    searchCommand += " where PaymentDate ='" + paymentDate_search.Text + "'";
                    first = false;
                }
                else
                    searchCommand += " AND PaymentDate ='" + paymentDate_search.Text + "'";
            }

            LoadPaymentsList(searchCommand);
        }

        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            leaseID_search.Text = "";
            nameSearch_textBox.Text = "";
            contractDate_search.Text = "";
            paymentDate_search.Text = "";
            paymentID_search.Text = "";

        }
        void PaymentItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView oDataRowView = paymentList.SelectedItem as DataRowView;
            string svalue;

            if (oDataRowView != null)
            {
                svalue = oDataRowView.Row["PaymentID"].ToString();
                //command to void Payment
                MessageBoxResult confirmation = MessageBox.Show("Are you sure you want to void the payment bellow?\n" +
                                    "\nPayment " + svalue + " of Lease " + oDataRowView.Row["LeaseID"].ToString() +
                                    "\nAmount: " + oDataRowView.Row["Amount"].ToString() +
                                    "\nPaymentDate: " + oDataRowView.Row["PaymentDate"].ToString() +
                                    "\n\nThis action can't be reverted. Confirm?"
                                    , "Void payment Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (confirmation == MessageBoxResult.Yes)
                {
                    dataConnection.Open();
                    try
                    {
                        String sqlComm = "UPDATE Payments set Amount=0, Valid='No' WHERE PaymentID=" + svalue;

                        SqlCommand dataCommand = new SqlCommand(sqlComm, dataConnection);
                        dataCommand.ExecuteNonQuery();
                        MessageBox.Show("Payment voided successfully!", "Lease Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadPaymentsList(command);
                    }
                    catch (SqlException sqle)
                    {
                        Console.WriteLine("Error accessing the database: {0}", sqle.Message);
                    }
                    finally
                    {
                        dataConnection.Close();
                    }
                }
            }
        }

        private void NewPayment_btn_Click(object sender, RoutedEventArgs e)
        {
            NewPayment np = new NewPayment();
            np.Show();
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
