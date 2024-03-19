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
        TasksYearObjectivesCollection tasksYearObjectives = TasksYearObjectivesCollection.ListAllTasksYearObjectives();

        int objective; //RECIBE OBJECTIVE FROM COLLECTION IN COMBO SELECTED CHANGE, AND IS USED TO CONSTRUCT DINAMIC CHART
        public AngularGaugeChartsUC()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void LoadSections()
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
        }

        private void comboYearObjectives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int YearObjectives = (int)comboYearObjectives.SelectedItem;
            objective = TasksYearObjectivesCollection.YearObjective(YearObjectives);
            LoadSections();
            //CHART CONSTRUCTION
            angularGauge.Value = 50; //NUMBER OF TASKS DONE IN A YEAR
            angularGauge.FromValue = 0;
            angularGauge.ToValue = objective; //OBJECTIVE IN THIS YEAR
            angularGauge.LabelsStep = objective / 5; //OBJECTIVE/5
            angularGauge.TicksStep = objective; //OBJECTIVE/10
            angularGauge.Wedge = 200;

        }

        private void angularGauge_Loaded(object sender, RoutedEventArgs e)
        {
            angularGauge.FontSize = 12;
            int countYears = 0;
            //YEARS
            foreach (var task in tasksYearObjectives)
            {
                comboYearObjectives.Items.Add(task.Year);
                countYears++;
            }

            comboYearObjectives.SelectedIndex = countYears - 1; //CHART WILL ALWAYS SHOW THE CURRENT YEAR
        }
    }
}
