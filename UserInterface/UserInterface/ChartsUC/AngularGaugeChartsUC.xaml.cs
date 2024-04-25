using BusinessLayer.Collections;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UserInterface.ChartsUC
{
    /// <summary>
    ///
    /// </summary>
    public partial class AngularGaugeChartsUC : UserControl
    {
        #region GLOBAL VARIAVELS
        TaskYearObjectivesCollection yearObjectivesList; //YEAR LIST WITH DEFINED OBJECTIVES IN DATABASE

        TaskManagerCollection allTasksList; //ALL TASKS IN THE DATABASE

        int objective; //RECIBE OBJECTIVE FROM COLLECTION IN COMBO SELECTED CHANGE, AND IS USED TO CONSTRUCT DYNAMIC CHART

        int tasksDoneInTheYear = 0; //RECIBE TASK DONE IN A SPECIFIC YEAR FROM COLLECTION IN COMBO SELECTED CHANGE,
                                    //AND IS USED TO CONSTRUCT DYNAMIC CHART
        #endregion

        #region CONSTRUCTORES
        public AngularGaugeChartsUC()
        {
            InitializeComponent();
            DataContext = this;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// METHOD TO CONSTRUCT CHART
        /// </summary>
        public void LoadTasksYearObjectivesChart()
        {
            angularGauge.Sections.Clear();

            List<SolidColorBrush> colorList = this.sectionsColorsYearObjectivesListCreator();

            LoadSections(colorList);

            //CHART CONSTRUCTION
            angularGauge.Value = tasksDoneInTheYear; //NUMBER OF TASKS DONE IN A YEAR
            angularGauge.FromValue = 0;
            angularGauge.ToValue = objective; //OBJECTIVE IN THIS YEAR
            angularGauge.LabelsStep = (double)objective / 5; //OBJECTIVE/5
            angularGauge.TicksStep = (double)objective / 10; //OBJECTIVE/10
            angularGauge.Wedge = 325;
        }

        /// <summary>
        /// METHOD TO CREATE COLORS THAT WE WILL USE IN YEAR OBJECTIVES CHART
        /// </summary>
        /// <returns></returns>
        public List<SolidColorBrush> sectionsColorsYearObjectivesListCreator()
        {
            List<SolidColorBrush> colorList = new List<SolidColorBrush>();
            colorList.Add(new SolidColorBrush(Colors.Red));
            colorList.Add(new SolidColorBrush(Colors.Orange));
            colorList.Add(new SolidColorBrush(Colors.LightGreen));
            colorList.Add(new SolidColorBrush(Colors.LimeGreen));
            colorList.Add(new SolidColorBrush(Colors.DarkGreen));

            return colorList;
        }

        /// <summary>
        /// METHOD TO CREATE CHART SECTIONS BASED ON A COLOR LIST RECEIVED
        /// </summary>
        /// <param name="colorList"></param>
        public void LoadSections(List<SolidColorBrush> colorList)
        {
            List<AngularSection> sectionsList = new List<AngularSection>();

            double calcPercentage = 0.2;
            double initValue = 0;
            double finalValue = objective * calcPercentage;

            foreach (SolidColorBrush color in colorList)
            {
                AngularSection section = new AngularSection();
                section.FromValue = initValue;
                section.ToValue = finalValue;
                section.Fill = color;

                initValue = finalValue;
                calcPercentage = calcPercentage + 0.2;
                finalValue = objective * calcPercentage;

                angularGauge.Sections.Add(section);
            }
        }

        #endregion

        #region EVENTS

        private void comboYearObjectives_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int year = (int)comboYearObjectives.SelectedItem;

            objective = TaskYearObjectivesCollection.YearObjective(year, yearObjectivesList);
            tasksDoneInTheYear = TaskManagerCollection.TasksDoneInTheYear(year, allTasksList);
            tasksDoneLabel.Content = $"TASKS DONE: {tasksDoneInTheYear.ToString()}";

            //IF TASKS DONE IS GREATER THAN OBJECTIVE, TASKS DONE WILL BE THE OBJECTIVE
            if (tasksDoneInTheYear > objective)
            {
                tasksDoneInTheYear = objective;
            }

            LoadTasksYearObjectivesChart();
        }

        private void angularGauge_Loaded(object sender, RoutedEventArgs e)
        {
            yearObjectivesList = TaskYearObjectivesCollection.ListAllTasksYearObjectives();
            allTasksList = TaskManagerCollection.ListAllTasks();
            YearComboBoxCreate();
        }

        public void YearComboBoxCreate() 
        {
            int countYearsInComboBox = 0;
            //YEARS
            foreach (BusinessLayer.Models.TaskYearObjectivesModel yearAndObjectives in yearObjectivesList)
            {
                comboYearObjectives.Items.Add(yearAndObjectives.Year);
                countYearsInComboBox++;
            }
            //CHART WILL ALWAYS SHOW THE CURRENT YEAR,
            //THIS CREATE A TRIGGER
            //FOR COMBO BOX EVENT - SELECTION CHANGED
            comboYearObjectives.SelectedIndex = (countYearsInComboBox - 1); //NEXT STEP IS SELECTION CHANGED EVENT
        }

        private void angularGauge_Unloaded(object sender, RoutedEventArgs e)
        {
            yearObjectivesList = null;
            allTasksList = null;
        }
        #endregion
    }
}
