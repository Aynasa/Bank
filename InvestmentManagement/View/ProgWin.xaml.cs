using BLL.Interfaces;
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
    /// Логика взаимодействия для ProgWin.xaml
    /// </summary>
    public partial class ProgWin : Window
    {

        public VkladDb db;
        public IDbCrud dboperations;

        public ProgWin(int ind)
        {
            InitializeComponent();
         
            db = new VkladDb();
            db.Progs.Load();
           // FillDataGrid(ind);
            Progs.ItemsSource = db.Progs.ToList();
            Progs.Items.Refresh();
        }

        //public void FillDataGrid(int ind)
        //{
        //    var resultGrid = from r in db.Progs.Local.ToList()
        //                     join b in db.Progs on r.Prog_FK equals b.ProgId
        //                     join d in db.Clients on r.Client_FK equals d.ClientId

        //                     where d.ClientId == ind
        //                     select new
        //                     {
        //                         DateOpen = r.DateOpen.ToShortDateString(),
        //                         Client = d.FIO,
        //                         Value = r.Balance,
        //                         Prog = b.name,
        //                         Percent = b.percent,
                             
        //                         Vklad_id = r.VkladId,
        //                         Prog_id = r.Prog_FK,
        //                         Client_id = r.Client_FK,


        //                     };
        //    Progs.ItemsSource = resultGrid.ToList();
        //    Progs.Items.Refresh();

        //}
        }
}
