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
    public partial class EditByLeaseID : Window
    {
        private MultiLeaseEntities multileaseContext = null;

        public EditByLeaseID()
        {
            InitializeComponent();
            this.multileaseContext = new MultiLeaseEntities();
        }

        private void Confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            if (leaseID_textBox.Text != "")
            {
                int leaseID = int.Parse(leaseID_textBox.Text);
                try
                {
                    var lease = multileaseContext.LeasesPs.Where(l => l.LeaseID == leaseID).First();
                    if (lease != null)
                    {
                        ViewLease vl = new ViewLease(leaseID_textBox.Text);
                        vl.Show();
                        Close();
                    }
                }
                catch (Exception)
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
