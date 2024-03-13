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
using BusinessLayer;
using BusinessLayer.Collections;
using BusinessLayer.Model;
using LiveCharts;
using LiveCharts.Wpf;

namespace UserInterface.ChartsUC
{
    /// <summary>
    /// Interaction logic for PieChartsUC.xaml
    /// </summary>
    public partial class PieChartsUC : UserControl
    {
        public string ViewType { get; set; }
        public PieChartsUC()
        {
            InitializeComponent();
            PointLabel = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            //DepartmentEfficienceCollection deparEfficices = DepartmentEfficienceCollection.ListDepartmentCollection();

            //foreach (var  department in deparEfficices) 
            //{
            //    PieSeries pieSeries = new PieSeries
            //    {
            //        Title = department.Area,
            //        DataLabels = true,
            //        Values = new ChartValues<double> { department.Efficience }
            //    };

            //    ChartUC.Series.Add(pieSeries);
            //}

            DepartmentTasksCollection deparEfficices = DepartmentTasksCollection.ListDepartmentTasksCollection();

            foreach (var department in deparEfficices)
            {
                PieSeries pieSeries = new PieSeries
                {
                    Title = department.Area,
                    DataLabels = true,
                    Values = new ChartValues<double> { department.TasksNumber }
                };

                ChartUC.Series.Add(pieSeries);
            }



            DataContext = this;
        }


        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {

            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
