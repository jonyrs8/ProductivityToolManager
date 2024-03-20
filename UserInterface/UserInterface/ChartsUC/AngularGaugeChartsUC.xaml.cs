using BusinessLayer.Collections;
using LiveCharts.Wpf.Charts.Base;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UserInterface.ChartsUC
{
    /// <summary>
    ///
    /// </summary>
    public partial class AngularGaugeChartsUC : UserControl
    {
        TasksYearObjectivesCollection yearList; //YEAR LIST WITH DEFINED OBJECTIVES IN DATABASE

        TaskCollection allTasksList; //ALL TASKS IN THE DATABASE

        int objective; //RECIBE OBJECTIVE FROM COLLECTION IN COMBO SELECTED CHANGE, AND IS USED TO CONSTRUCT DYNAMIC CHART

        int tasksDoneInTheYear = 0; //RECIBE TASK DONE IN A SPECIFIC YEAR FROM COLLECTION IN COMBO SELECTED CHANGE,
                                    //AND IS USED TO CONSTRUCT DYNAMIC CHART
        public AngularGaugeChartsUC()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// METHOD TO CONSTRUCT AND MAKE ALL LOGIC BEHIND CHART BASED IN OBJECTIVE AND TASKS DONE
        /// </summary>
        public void LoadChart()
        {
            angularGauge.Sections.Clear();

            AngularSection angularSectionDarkGreen = new AngularSection()
            {
                FromValue = objective * 0.8, //OBJECTIVE*0.8 = 80%
                ToValue = objective, //OBJECTIVE
                Fill = new SolidColorBrush(Colors.DarkGreen)
            };


            AngularSection angularSectionLimeGreen = new AngularSection()
            {
                FromValue = objective * 0.6, //OBJECTIVE*0.6 = 60%
                ToValue = objective * 0.8, //OBJECTIVE*0.8 = 80%
                Fill = new SolidColorBrush(Colors.LimeGreen)
            };

            AngularSection angularSectionLightGreen = new AngularSection()
            {
                FromValue = objective * 0.4, //OBJECTIVE*0.4 = 40%
                ToValue = objective * 0.6, //OBJECTIVE*0.6 = 60%
                Fill = new SolidColorBrush(Colors.LightGreen)
            };

            AngularSection angularSectionOrange = new AngularSection()
            {
                FromValue = objective * 0.2, //OBJECTIVE*0.2 = 20%
                ToValue = objective * 0.4, //OBJECTIVE*0.4 = 40%
                Fill = new SolidColorBrush(Colors.Orange)
            };

            AngularSection angularSectionRed = new AngularSection()
            {
                FromValue = 0, //0
                ToValue = objective * 0.2, //OBJECTIVE*0.2 = 20%
                Fill = new SolidColorBrush(Colors.Red)
            };

            angularGauge.Sections.Add(angularSectionDarkGreen);
            angularGauge.Sections.Add(angularSectionLimeGreen);
            angularGauge.Sections.Add(angularSectionLightGreen);
            angularGauge.Sections.Add(angularSectionOrange);
            angularGauge.Sections.Add(angularSectionRed);

            //CHART CONSTRUCTION
            angularGauge.Value = tasksDoneInTheYear; //NUMBER OF TASKS DONE IN A YEAR
            angularGauge.FromValue = 0;
            angularGauge.ToValue = objective; //OBJECTIVE IN THIS YEAR
            angularGauge.LabelsStep = objective / 5; //OBJECTIVE/5
            angularGauge.TicksStep = objective; //OBJECTIVE/10
            angularGauge.Wedge = 200;
        }

        private void comboYearObjectives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int _yearObjectivesComboSelected = (int)comboYearObjectives.SelectedItem;
            int year = _yearObjectivesComboSelected;
            objective = TasksYearObjectivesCollection.YearObjective(year, yearList);
            tasksDoneInTheYear = TaskCollection.TasksDoneInTheYear(year, allTasksList);
            LoadChart();
        }

        private void angularGauge_Loaded(object sender, RoutedEventArgs e)
        {
            yearList = TasksYearObjectivesCollection.ListAllTasksYearObjectives();
            allTasksList = TaskCollection.ListAllTasks();
            int countYearsInComboBox = 0;
            //YEARS
            foreach (var task in yearList)
            {
                comboYearObjectives.Items.Add(task.Year);
                countYearsInComboBox++;
            }
            //CHART WILL ALWAYS SHOW THE CURRENT YEAR,
            //THIS CREATE A TRIGGER
            //FOR COMBO BOX EVENT - SELECTION CHANGED
            comboYearObjectives.SelectedIndex = (countYearsInComboBox - 1); 
        }

        private void angularGauge_Unloaded(object sender, RoutedEventArgs e)
        {
            yearList = null;
            allTasksList = null;
        }
    }
}
