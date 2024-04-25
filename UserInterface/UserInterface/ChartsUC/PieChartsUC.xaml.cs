using BusinessLayer.Collections;
using BusinessLayer.Enumerations;
using BusinessLayer.Interfaces;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace UserInterface.ChartsUC
{
    /// <summary>
    /// Interaction logic for PieChartsUC.xaml
    /// </summary>
    public partial class PieChartsUC : UserControl
    {
        #region GLOBAL VARIAVELS
        DepartmentTaskManagerCollection departmentTasksList;
        DepartmentEfficiencyInCompanyColection departmentEfficiencyList; //SHOW THE MOST EFFICIENT DEPARTMENT DURING TASKS
        ViewType viewType;
        string topDepartment = string.Empty;
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
                LoadChart(departmentTasksList);
            }
            else if (viewType == ViewType.Efficiency)
            {
                LoadChart(departmentEfficiencyList);
            }

            topDepartmentLabel.Content = topDepartment;
        }

        public void MakePieSeries(List<IAreaValue> list) 
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

        /// <summary>
        /// METHOD TO RECIBE 2 DIFERENT LIST WITH SAME OBJECT INTERFACE IMPLEMENTED, AND MAKE CHART
        /// </summary>
        /// <param name="list"></param>
        public void LoadChart(List<IAreaValue> list)
        {

            MakePieSeries(list);


            TopDepartmentLabel(list);

        }

        public void TopDepartmentLabel(List<IAreaValue> list) 
        {
            IAreaValue area = list.Select(k => k).OrderByDescending(k => k.Value).FirstOrDefault();
            if (area != null)
            {
                this.topDepartment = $"TOP DEPARTMENT: {area.Area}";
            }
        }

        public void Label(string departmentArea, List<IAreaValue> list)
        {
            double value = 0;
            string topDepartmentLabelName = topDepartmentLabel.Content.ToString();

            foreach (IAreaValue departmentAreas in list)
            {
                if (departmentArea == departmentAreas.Area)
                {
                    value = departmentAreas.Value;
                    break;
                }

            }

            topDepartmentLabel.Content = topDepartmentLabelName + departmentArea + " " + value;

      

            if (viewType == ViewType.Efficiency)
            {
                topDepartmentLabel.Content += "%";
            }
        }
        #endregion

        #region EVENTS

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
            {
                series.PushOut = 0;
            }

            var selectedSeries = (PieSeries)chartpoint.SeriesView;

            if (viewType == ViewType.Task)
            {
                topDepartmentLabel.Content = "TASKS DONE: ";
                Label(selectedSeries.Title.ToString(), departmentTasksList);

            }
            else if (viewType == ViewType.Efficiency)
            {
                topDepartmentLabel.Content = "EFFICIENCY: ";
                Label(selectedSeries.Title.ToString(), departmentEfficiencyList);

            }

            selectedSeries.PushOut = 8;

        }

        private void ViewType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusinessLayer.Models.ViewTypeDescription selectedViewType = filterComboBox.SelectedItem as BusinessLayer.Models.ViewTypeDescription;
            if (selectedViewType != null)
            {
                viewType = selectedViewType.ViewType;
                ChartUC.Series.Clear();
                LoadData();
            }
        }

        private void ChartUC_Loaded(object sender, RoutedEventArgs e)
        {
            departmentTasksList = DepartmentTaskManagerCollection.ListDepartmentTasksCollection();
            departmentEfficiencyList = DepartmentEfficiencyInCompanyColection.ListDepartmentEfficienceInCompanyColection();

            filterComboBox.DisplayMemberPath = "Description"; //MOSTRA A PROPRIEDADE DESCRIPTION DO ITEM SELECIONADO
            filterComboBox.SelectedValuePath = "ViewType"; //SELECIONA INTERNAMENTE A PROPRIEDADE VIEWTYPE DO OBJETO

            filterComboBox.Items.Add(new BusinessLayer.Models.ViewTypeDescription(ViewType.Efficiency));
            filterComboBox.Items.Add(new BusinessLayer.Models.ViewTypeDescription(ViewType.Task));

            filterComboBox.SelectedIndex = 0; //DEFINE COMBO SELECTED ITEM AS THE FIRST VIEW - EFFICIENCY

        }

        private void ChartUC_Unloaded(object sender, RoutedEventArgs e)
        {
            departmentTasksList = null;
            departmentEfficiencyList = null;
        }
        #endregion
    }
}
