using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace InvestmentManagement.View
{
    /// <summary>
    /// Логика взаимодействия для MainMenu1.xaml
    /// </summary>
    public partial class MainMenu1 : Window
    {
        VkladDb db;
        Client n = new Client();
        public MainMenu1(int Index)
        {
            ind = Index;
            db = new VkladDb();
            db.Clients.Load();
            FindFIO();
           // FindBal();

            InitializeComponent();
        }
     
        public void FindFIO()
        {

            n = db.Clients.Find(ind);
            this.jojo.Text = n.FIO;
            //jojo.Text = n.FIO;
            Balance.Text = n.MainBalance.ToString();
        }
        int ind;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProgWin m = new ProgWin(ind);
            m.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VkladWin m = new VkladWin(ind);
            m.Show();
            Close();
        }
    }
}
