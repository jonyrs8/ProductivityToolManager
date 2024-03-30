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
using BusinessLayer.Enumerations;
using BusinessLayer.Interfaces;
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
        #region GLOBAL VARIAVELS
        DepartmentTaskManagerCollection departmentTasks;
        DepartmentEfficiencyInCompanyColection departmentEfficiency; //SHOW THE MOST EFFICIENT DEPARTMENT DURING TASKS
        ViewType viewType;
        #endregion

        #region PROPERTIES
        public Func<ChartPoint, string> PointLabel { get; set; }
        #endregion

        #region CONSTRUCTORES
        public PieChartsUC()
        {
            InitializeComponent();
            PointLabel = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }
        #endregion

        #region METHODS

        /// <summary>
        /// METHOD TO CHARGE VIEW FOR CHART FROM VIEW TYPE SELECTED
        /// </summary>
        public void LoadData()
        {
            if (viewType == ViewType.Task)
            {
                LoadChart(departmentTasks);
            }
            else if (viewType == ViewType.Efficiency)
            {
                LoadChart(departmentEfficiency);
            }
        }

        /// <summary>
        /// METHOD TO RECIBE 2 DIFERENT LIST WITH SAME OBJECT INTERFACE IMPLEMENTED, AND MAKE CHART
        /// </summary>
        /// <param name="list"></param>
        public void LoadChart(List<IAreaValue> list) 
        {
            foreach (IAreaValue department in list)
            {
                PieSeries pieSeries = new PieSeries
                {
                    FontSize = 9,
                    Title = department.Area,
                    DataLabels = true,
                    Values = new ChartValues<double> { department.Value },
                    LabelPoint = PointLabel
                };

                ChartUC.Series.Add(pieSeries);
            }

        }
        #endregion

        #region EVENTS

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
            BusinessLayer.Models.ViewTypeDescription selectedViewType = filterComboBox.SelectedItem as BusinessLayer.Models.ViewTypeDescription;
            if(selectedViewType != null) 
            {
                viewType = selectedViewType.ViewType;
                ChartUC.Series.Clear();
                LoadData();
            }
        }

        private void ChartUC_Loaded(object sender, RoutedEventArgs e)
        {
            departmentTasks = DepartmentTaskManagerCollection.ListDepartmentTasksCollection();
            departmentEfficiency = DepartmentEfficiencyInCompanyColection.ListDepartmentEfficienceInCompanyColection();

            filterComboBox.DisplayMemberPath = "Description"; //MOSTRA A PROPRIEDADE DESCRIPTION DO ITEM SELECIONADO
            filterComboBox.SelectedValuePath = "ViewType"; //SELECIONA INTERNAMENTE A PROPRIEDADE VIEWTYPE DO OBJETO

            filterComboBox.Items.Add(new BusinessLayer.Models.ViewTypeDescription(ViewType.Efficiency));
            filterComboBox.Items.Add(new BusinessLayer.Models.ViewTypeDescription(ViewType.Task));

            filterComboBox.SelectedIndex = 0; //DEFINE COMBO SELECTED ITEM AS THE FIRST VIEW - EFFICIENCY
        }

        private void ChartUC_Unloaded(object sender, RoutedEventArgs e)
        {
            departmentTasks = null;
            departmentEfficiency = null;
        }
        #endregion
    }
}
