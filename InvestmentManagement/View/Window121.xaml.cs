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
    /// Логика взаимодействия для Window121.xaml
    /// </summary>
    public partial class Window121 : Window
    {
        VkladDb db;
        int index;

        Vklad n = new Vklad();
        Prog m = new Prog();
        public Window121(int ind)
        {
            index = ind;            
            InitializeComponent();
            db = new VkladDb();
            db.Vklads.Load();
            db.Progs.Load();
            n = db.Vklads.Find(ind);
            m = db.Progs.Find(n.Prog_FK);
            n8.Text = n.DateOpen.ToString();
            n9.Text = n.Balance.ToString();
            n10.Text = m.name;
            n11.Text = m.percent.ToString();
            n12.Text = "";
            m12.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (m1.SelectedDate == null) return;
            int mon =(m1.SelectedDate.Value.Year - DateTime.Now.Year) * 12;
            int non = (mon +   m1.SelectedDate.Value.Month- DateTime.Now.Month) * n.Balance * m.percent / 12;
            n12.Text = non.ToString();
            m12.Text = "Итоговая сумма";
        }
    }
}
