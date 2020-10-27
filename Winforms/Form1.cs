using DemoCommon.Grid;
using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.DataGrid.Styles;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.WinForms.ListView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.XlsIO;
using Syncfusion.Windows.Forms.Tools;
using System.Drawing;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.Styles;

namespace AddNewRow
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();

            sfDataGrid.AutoGenerateColumns = false;
            sfDataGrid.DataSource = new ViewModel().Orders;
            sfDataGrid.LiveDataUpdateMode = LiveDataUpdateMode.AllowDataShaping;
            sfDataGrid.ShowGroupDropArea = true;

            this.sfDataGrid.Columns.Add(new GridProgressBarColumn() { MappingName = "OrderID", HeaderText = "Order ID", Maximum = 150, Minimum = 0, ValueMode = ProgressBarValueMode.None });
            this.sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            this.sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "CustomerName", HeaderText = "Customer Name" });
            this.sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Country", HeaderText = "Country" });
            this.sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ShipCity", HeaderText = "Ship City" });
            this.sfDataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = "IsShipped", HeaderText = "Is Shipped" });                      
           
            this.sfDataGrid.CellRenderers.Remove("ProgressBar");
            this.sfDataGrid.CellRenderers.Add("ProgressBar", new GridProgressBarColumnExt(new ProgressBarAdv()));
        }        
    }

    public class GridProgressBarColumnExt : GridProgressBarCellRenderer
    {
        ProgressBarAdv ProgressBar;
        public GridProgressBarColumnExt(ProgressBarAdv progressBar) : base(progressBar)
        {
            ProgressBar = progressBar;
        }

        protected override void OnRender(Graphics paint, Rectangle cellRect, string cellValue, CellStyleInfo style, DataColumnBase column, RowColumnIndex rowColumnIndex)
        {
            ProgressBar.CustomText = cellValue + "%";
            ProgressBar.TextStyle = ProgressBarTextStyles.Custom;
            decimal decimalvalue = decimal.Parse(cellValue);
            var intvalue = decimal.ToInt32(decimalvalue);
            cellValue = intvalue.ToString();
            base.OnRender(paint, cellRect, cellValue, style, column, rowColumnIndex);
        }
    }
    public class OrderInfo : INotifyPropertyChanged
    {
        decimal? orderID;
        string customerId;
        string country;
        string customerName;
        string shippingCity;
        bool isShipped;

        public OrderInfo()
        {

        }

        public decimal? OrderID
        {
            get { return orderID; }
            set { orderID = value; this.OnPropertyChanged("OrderID"); }
        }

        public string CustomerID
        {
            get { return customerId; }
            set { customerId = value; this.OnPropertyChanged("CustomerID"); }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; this.OnPropertyChanged("CustomerName"); }
        }

        public string Country
        {
            get { return country; }
            set { country = value; this.OnPropertyChanged("Country"); }
        }

        public string ShipCity
        {
            get { return shippingCity; }
            set { shippingCity = value; this.OnPropertyChanged("ShipCity"); }
        }

        public bool IsShipped
        {
            get { return isShipped; }
            set { isShipped = value; this.OnPropertyChanged("IsShipped"); }
        }


        public OrderInfo(decimal? orderId, string customerName, string country, string customerId, string shipCity, bool isShipped)
        {
            this.OrderID = orderId;
            this.CustomerName = customerName;
            this.Country = country;
            this.CustomerID = customerId;
            this.ShipCity = shipCity;
            this.IsShipped = isShipped;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ViewModel
    {
        private ObservableCollection<OrderInfo> orders;
        public ObservableCollection<OrderInfo> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public ViewModel()
        {
            orders = new ObservableCollection<OrderInfo>();
            orders.Add(new OrderInfo(10, "Thomas Hardy", "Germany", "ALFKI", "Berlin", true));
            orders.Add(new OrderInfo(30, "Laurence Lebihan", "Mexico", "ANATR", "Mexico", false));
            orders.Add(new OrderInfo(50, "Antonio Moreno", "Mexico", "ANTON", "Mexico", true));
            orders.Add(new OrderInfo(100, "Thomas Hardy", "UK", "AROUT", "London", true));
            orders.Add(new OrderInfo(150, "Christina Berglund", "Sweden", "BERGS", "Lula", false));
        }
    }

}
