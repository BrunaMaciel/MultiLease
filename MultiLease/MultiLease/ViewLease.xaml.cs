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
using System.Data;
using System.Data.SqlClient;

namespace MultiLease
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ViewLease : Window
    {
        private MultiLeaseEntities multileaseContext = null;
        SqlConnection dataConnection = new SqlConnection("Data Source=(local);Initial Catalog=MultiLease;Integrated Security=SSPI");
        SqlCommand dataCommand;
        SqlDataAdapter da;
        DataSet ds;
        string paymentsSQLCommand;

        public ViewLease(string leaseID)
        {
            InitializeComponent();
            multileaseContext = new MultiLeaseEntities();
            FillCombos();
            leaseID_textbox.Text = leaseID;
        }
        private void FillCombos()
        {
            dataConnection.Open();
            try
            {
                dataCommand = new SqlCommand("SELECT * FROM DetailedVehicle", dataConnection);
   
                using (var reader = dataCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader.GetString(0);
                        vehicles.Items.Add(item);
                    }
                }

                //fill Customers combo box
                dataCommand.CommandText = "SELECT * FROM Customers";
                using (var reader = dataCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int item = reader.GetInt32(0);
                        customersList.Items.Add(item);
                    }
                }
                
                //fill Terms combo box
                dataCommand.CommandText = "SELECT * FROM LeaseTerms";
                using (var reader = dataCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int item = reader.GetInt32(0);
                        termsList.Items.Add(item);
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error accessing the database");
            }
            finally
            {
                dataConnection.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            paymentsSQLCommand = "SELECT * FROM Payments where LeaseID=" + this.leaseID_textbox.Text;

            LoadLeaseInfo();
            LoadPaymentsList(paymentsSQLCommand);
        }

        private void LoadLeaseInfo()
        {
            int status = 1;

            dataConnection.Open();
            try
            {
                dataCommand = new SqlCommand("SELECT * FROM LeasesP WHERE LeaseID = @LeaseIDParam",dataConnection);
                SqlParameter param = new SqlParameter("@LeaseIDParam", SqlDbType.Int, 4);
                param.Value = int.Parse(leaseID_textbox.Text);
                dataCommand.Parameters.Add(param);

                using (var reader = dataCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        contractDate.SelectedDate = reader.GetDateTime(1);
                        firstPaymentDate.SelectedDate = reader.GetDateTime(2);
                        amount_textBox.Text = reader.GetSqlMoney(3).ToString();
                        int months = reader.GetInt32(4);
                        switch (months)
                        {
                            case 12:
                                months12.IsChecked = true;
                                break;
                            case 24:
                                months24.IsChecked = true;
                                break;
                            case 36:
                                months36.IsChecked = true;
                                break;
                            case 48:
                                months48.IsChecked = true;
                                break;
                        }

                        vehicles.SelectedItem = reader.GetString(5);
                        customersList.SelectedItem = reader.GetInt32(6);
                        termsList.SelectedItem = reader.GetInt32(7);
                        status = reader.GetInt32(8);
                        if (status == 2)
                        {
                            this.edit_btn.IsEnabled = false;
                            this.terminate_btn.IsEnabled = false;
                        }
                    }
                }

                dataCommand = new SqlCommand("SELECT * FROM LeaseStatus", dataConnection);

                using (var dReader = dataCommand.ExecuteReader())
                {
                    while (dReader.Read())
                    {
                        if (dReader.GetInt32(0) == status)
                        {
                            status_textBox.Text = dReader.GetString(1);
                            break;
                        }
                    }
                }

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
        private void LoadPaymentsList(string command)
        {
            ds = new DataSet();
            da = new SqlDataAdapter(command, dataConnection);
            da.Fill(ds, "Payments");
            paymentList.DataContext = ds.Tables["Payments"].DefaultView;
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
                        SqlCommand dataCommand = new SqlCommand("VoidPayment", dataConnection);
                        SqlParameter param;
                        param = dataCommand.Parameters.Add("@PaymentID", SqlDbType.Int);
                        param.Value = svalue;
                        dataCommand.CommandType = CommandType.StoredProcedure;
                        dataCommand.ExecuteNonQuery();

                        MessageBox.Show("Payment voided successfully!", "Lease Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadPaymentsList(paymentsSQLCommand);
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
        private void NewLease_Click(object sender, RoutedEventArgs e)
        {
            NewLease newLease = new NewLease();
            newLease.ShowDialog();
        }
        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            DisableEdit();
        }
        private void DisableEdit()
        {
            vehicles.IsEnabled = false;
            customersList.IsEnabled = false;
            termsList.IsEnabled = false;
            amount_textBox.IsEnabled = false;
            numOfPayments.IsEnabled = false;
            save_btn.IsEnabled = false;
            cancel_btn.IsEnabled = false;
            edit_btn.IsEnabled = true;
        }
        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {   
            string value = amount_textBox.Text.Replace(",", "").Replace("$", "").TrimStart('0');
            string months = "36";
            if (months12.IsChecked == true)
                months = "12";
            if (months24.IsChecked == true)
                months = "24";
            if (months36.IsChecked == true)
                months = "36";
            if (months48.IsChecked == true)
                months = "48";

            MessageBoxResult confirmSave = MessageBox.Show("LeaseID: " + leaseID_textbox.Text + "\n" +
                                                 "Contract Date: " + contractDate.Text + "\n" +
                                                 "Vehicle ID: " + vehicles.SelectedItem.ToString() + "\n" +
                                                 "Terms ID: " + termsList.SelectedItem.ToString() + "\n" +
                                                 "CustomerID: " + customersList.SelectedItem.ToString() + "\n" +
                                                 "First Payment Date: " + firstPaymentDate.Text + "\n" +
                                                 "Amount: " + value + "\n" +
                                                 "Num of Payments: " + months + "\n",
                                                 "Save the following new listing?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            string vehicleID = vehicles.SelectedItem.ToString();
            if (confirmSave == MessageBoxResult.Yes)
            {
                dataConnection.Open();
                try
                {
                    SqlCommand dataCommand = new SqlCommand("UpdateLease", dataConnection);

                    SqlParameter param;
                    param = dataCommand.Parameters.Add("@LeaseID", SqlDbType.Int);
                    param.Value = leaseID_textbox.Text;

                    param = dataCommand.Parameters.Add("@MonthlyPayment", SqlDbType.Money);
                    param.Value = value;

                    param = dataCommand.Parameters.Add("@NumOfPayments", SqlDbType.Int);
                    param.Value = months;

                    param = dataCommand.Parameters.Add("@VehicleID", SqlDbType.NVarChar);
                    param.Value = vehicleID;

                    param = dataCommand.Parameters.Add("@CustomerID", SqlDbType.NVarChar);
                    param.Value = customersList.SelectedItem.ToString();

                    param = dataCommand.Parameters.Add("@TermsID", SqlDbType.NVarChar);
                    param.Value = termsList.SelectedItem.ToString();

                    dataCommand.CommandType = CommandType.StoredProcedure;
                    dataCommand.ExecuteNonQuery();
                    MessageBox.Show("Lease: "+leaseID_textbox.Text+ " updated successfully!", "Lease Updated",MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Lease: " + leaseID_textbox.Text + " can not be updated.","Lease Not Updated", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    dataConnection.Close();
                }
                LoadLeaseInfo();
                DisableEdit();
            }
            else return;
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


        private void Terminate_btn_Click(object sender, RoutedEventArgs e)
        {
            
            if (!status_textBox.Text.Equals("Started"))
            {
                MessageBox.Show("Lease can't be terminated! Lease already finished.", "Terminate Lease Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int id = int.Parse(leaseID_textbox.Text);
                TerminateLease tl = new TerminateLease(multileaseContext.LeasesPs.Where(l => l.LeaseID == id).FirstOrDefault());
                tl.Closing += UpdateWindow;
                tl.Show();
            }
        }
        public void UpdateWindow(object sender, System.EventArgs e)
        {
            LoadLeaseInfo();
            LoadPaymentsList(paymentsSQLCommand);
            this.edit_btn.IsEnabled = false;
            this.terminate_btn.IsEnabled = false;
        }

        private void NewPayment_btn_Click(object sender, RoutedEventArgs e)
        {
            NewPayment pf = new NewPayment(leaseID_textbox.Text);
            pf.Title = "New Payment for LeaseID" + leaseID_textbox.Text;
            pf.contractDate.SelectedDate = this.contractDate.SelectedDate;
            pf.ShowDialog();
            LoadPaymentsList(paymentsSQLCommand);
        }
        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            vehicles.IsEnabled = true;
            customersList.IsEnabled = true;
            termsList.IsEnabled = true;
            amount_textBox.IsEnabled = true;
            numOfPayments.IsEnabled = true;
            save_btn.IsEnabled = true;
            cancel_btn.IsEnabled = true;
            edit_btn.IsEnabled = false;
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
