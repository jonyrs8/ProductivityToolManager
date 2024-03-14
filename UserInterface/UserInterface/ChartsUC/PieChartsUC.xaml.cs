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

        public Func<ChartPoint, string> PointLabel { get; set; }
        public PieChartsUC()
        {
            InitializeComponent();
            PointLabel = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            Filter.Items.Add("EFICIENCIA");
            Filter.Items.Add("TAREFAS");

            DataContext = this;
        }

        // Método para carregar os dados com base na ViewType recebida
        public void LoadData()
        {
            if (ViewType == "TAREFAS")
            {
                DepartmentTasksCollection deparEfficices = DepartmentTasksCollection.ListDepartmentTasksCollection();

                foreach (var department in deparEfficices)
                {
                    PieSeries pieSeries = new PieSeries
                    {
                        Title = department.Area,
                        DataLabels = true,
                        Values = new ChartValues<double> { department.TasksNumber },
                        LabelPoint = PointLabel
                    };

                    ChartUC.Series.Add(pieSeries);
                }
            }
            else if (ViewType == "EFICIENCIA")
            {
                DepartmentEfficienceCollection deparEfficices = DepartmentEfficienceCollection.ListDepartmentEfficienceCollection();

                foreach (var department in deparEfficices)
                {
                    PieSeries pieSeries = new PieSeries
                    {
                        Title = department.Area,
                        DataLabels = true,
                        Values = new ChartValues<double> { department.Efficience },
                        LabelPoint = PointLabel
                    };

                    ChartUC.Series.Add(pieSeries);
                }
            }
            // Adicione mais lógica conforme necessário
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
            ViewType = Filter.SelectedItem as string;
            Title.Text = ViewType;
            ChartUC.Series.Clear();
            LoadData();
        }
    }
}
