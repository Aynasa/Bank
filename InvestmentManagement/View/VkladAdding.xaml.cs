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
    /// Логика взаимодействия для VkladAdding.xaml
    /// </summary>
    public partial class VkladAdding : Window
    {
        public VkladDb db;
        public Vklad r;
        public VkladAdding(int index)
        {
            InitializeComponent();
            db = new VkladDb();
            db.Vklads.Load();
            db.Progs.Load();
            db.Clients.Load();
            k = db.Clients.ToList();

            ind = index;
            fill_addPage();
        }
        int ind;
        List<Client> k = new List<Client>();
        void fill_addPage()
        {
            comboboxProg.ItemsSource = db.Progs.Local;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Client p in k)
            {
                if (ind == p.ClientId)
                {
                    if (int.Parse(Bal.Text) > p.MainBalance)
                        MessageBox.Show("Недостаточно средств на счету!");
                    else
                    {
                        r = new Vklad();
                        r.Balance = int.Parse(Bal.Text);
                        dynamic d = comboboxProg.SelectedItem;
                        r.Client_FK = p.ClientId;
                        db.Clients.Find(ind).MainBalance = db.Clients.Find(ind).MainBalance - r.Balance;
                        
                        r.Prog_FK = d.ProgId;
                        r.DateOpen = DateTime.Now;
                        db.Vklads.Add(r);
                        db.SaveChanges();
                        MessageBox.Show("Вклад добавлен!");
                        VkladWin m = new VkladWin(ind);
                        m.Show();
                        Close();
                    }
                }

            }



            

        }
    }
}
