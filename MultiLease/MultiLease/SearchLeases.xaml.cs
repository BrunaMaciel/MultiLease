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
    public partial class SearchLeases : Window
    {
        SqlConnection dataConnection = new SqlConnection("Data Source=(local);Initial Catalog=MultiLease;Integrated Security=SSPI");
        SqlDataAdapter da;
        DataSet ds;
        MultiLeaseEntities context;
        string command = "SELECT * FROM LeasesDetails";

        public SearchLeases()
        {
            InitializeComponent();
            this.context = new MultiLeaseEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLeasesList(command);

        }
        private void LoadLeasesList(string command)
        {
            ds = new DataSet();
            da = new SqlDataAdapter(command, dataConnection);
            da.Fill(ds, "LeasesDetails");
            leasesList.DataContext = ds.Tables["LeasesDetails"].DefaultView;
        }

        private void NewLease_btn_Click(object sender, RoutedEventArgs e)
        {
            NewLease newLease = new NewLease();
            newLease.ShowDialog();
            LoadLeasesList(command);
        }

        void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView oDataRowView = leasesList.SelectedItem as DataRowView;
            string svalue;

            if (oDataRowView != null)
            {
              svalue = oDataRowView.Row["LeaseID"].ToString();
                ViewLease view = new ViewLease(svalue);
                view.Title = "MultiLease MS - View Lease ID " + svalue;
                view.Closing += Updates;
                view.Show();
                LoadLeasesList(command);
            }        
        }
        public void Updates(object sender, System.EventArgs e)
        {
            LoadLeasesList(command);
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
            string status = "";
            if (start_rad.IsChecked == true)
                status = start_rad.Content.ToString();
            if (compl_rad.IsChecked == true)
                status = compl_rad.Content.ToString();
            if (status != "")
            {
                if (first)
                {
                    searchCommand += " where Status LIKE '%" + status+"'";
                    first = false;
                }
                else
                    searchCommand += " AND Status LIKE '%" + status+"'";
            }
            LoadLeasesList(searchCommand);
        }

        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            leaseID_search.Text = "";
            nameSearch_textBox.Text = "";
            contractDate_search.Text = "";
            start_rad.IsChecked = false;
            compl_rad.IsChecked = false;
            
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
