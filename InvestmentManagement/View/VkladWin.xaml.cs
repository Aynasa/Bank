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
    /// Логика взаимодействия для VkladWin.xaml
    /// </summary>
    public partial class VkladWin : Window
    {
        VkladDb db;
        int index;
        public VkladWin(int ind)
        {
            index = ind;
            InitializeComponent();
            db = new VkladDb();
            db.Vklads.Load();
            FillDataGrid(ind);
        }

        public void FillDataGrid(int ind)
        {
            var resultGrid = from r in db.Vklads.Local.ToList()
                             join b in db.Progs on r.Prog_FK equals b.ProgId
                             join d in db.Clients on r.Client_FK equals d.ClientId

                             where d.ClientId == ind
                             select new
                             {
                                 DateOpen = r.DateOpen.ToShortDateString(),
                                 Client = d.FIO,
                                 Value = r.Balance,
                                 Prog = b.name,
                                 Percent = b.percent,

                                 Vklad_id = r.VkladId,
                                 Prog_id = r.Prog_FK,
                                 Client_id = r.Client_FK,


                             };
            Vklads.ItemsSource = resultGrid.ToList();
            Vklads.Items.Refresh();

        }
    


private void Button_click(object sender, RoutedEventArgs e)
        {
            if (Vklads.SelectedItem == null) return;

            dynamic p = Vklads.SelectedItem;
            Window121 m = new Window121(db.Vklads.Find(p.Vklad_id).VkladId);
             m.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VkladAdding m = new VkladAdding(index);
            m.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Vklads.SelectedItem == null) return;

            dynamic p = Vklads.SelectedItem;
            db.Clients.Find(p.Client_id).MainBalance += p.Value;
            db.Vklads.Remove(db.Vklads.Find(p.Vklad_id));
            db.SaveChanges();
            Vklads.Items.Refresh();

            VkladWin ret = new VkladWin(index);
            ret.Show();
            Close();
        }
    }
}
