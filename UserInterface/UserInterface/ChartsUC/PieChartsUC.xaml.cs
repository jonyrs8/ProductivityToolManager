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
        DepartmentTasksCollection departementTasksDone;
        DepartmentEfficiencyCollection departmentEfficiency; //SHOW THE MOST EFFICIENT DEPARTMENT DURING TASKS
        public string ViewType { get; set; } //RECIBE THE VIEW TYPE SELECTED IN COMBOX
        public Func<ChartPoint, string> PointLabel { get; set; }
        public PieChartsUC()
        {
            InitializeComponent();
            PointLabel = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }

        /// <summary>
        /// METHOD TO CHARGE DATA FOR CHART FROM VIEW TYPE SELECTED
        /// </summary>
        public void LoadData()
        {
            if (ViewType == "TAREFAS")
            {
                foreach (var department in departementTasksDone)
                {
                    PieSeries pieSeries = new PieSeries
                    {
                        FontSize = 8,
                        Title = department.Area,
                        DataLabels = true,
                        Values = new ChartValues<double> { department.TasksNumber },
                        LabelPoint = PointLabel
                    };

                    ChartUC.Series.Add(pieSeries);
                }
            }
            else if (ViewType == "EFICIENCIA" || ViewType == null)
            {
                foreach (var department in departmentEfficiency)
                {
                    PieSeries pieSeries = new PieSeries
                    {
                        FontSize = 8,
                        Title = department.Area,
                        DataLabels = true,
                        Values = new ChartValues<double> { department.Efficiency },
                        LabelPoint = PointLabel
                    };

                    ChartUC.Series.Add(pieSeries);
                }
            }
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        private void ViewType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string _selectedViewInComboBox = Filter.SelectedItem as string;
            ViewType = _selectedViewInComboBox;
            ChartUC.Series.Clear();
            LoadData();
        }

        private void ChartUC_Loaded(object sender, RoutedEventArgs e)
        {
            departementTasksDone = DepartmentTasksCollection.ListDepartmentTasksCollection();
            departmentEfficiency = DepartmentEfficiencyCollection.ListDepartmentEfficiencyCollection();
            Filter.Items.Add("EFICIENCIA");
            Filter.Items.Add("TAREFAS");
            Filter.SelectedIndex = 0; //DEFINE COMBO SELECTED ITEM AS THE FIRST VIEW - EFFICIENCY
        }

        private void ChartUC_Unloaded(object sender, RoutedEventArgs e)
        {
            departementTasksDone = null;
            departmentEfficiency = null;
        }
    }
}
