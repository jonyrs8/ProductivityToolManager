using BusinessLayer;
using BusinessLayer.Collections;
using BusinessLayer.Model;
using BusinessLayer.Models;
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
using UserInterface.ChartsUC;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region GLOBAL VARIABELS
        List<string> departmentSelectedList = new List<string>(); //CONTAINS THE CONTENT OF THE CHECK BOXES SELECTED TO MANAGE CARDS
        CheckBox geralCheckBox = new CheckBox(); //CHECKBOX GERAL
        DepartmentEfficiencyCollection efficiencyDepartmentsList; //CONTAINS ALL EFFICIENCIES BY ALL DEPARTMENTS
        UserInformationCollection allUsersInformationList; //CONTAINS THE GREATEST PART OF CARDS INFORMATIONS OF ALL USERS
        DepartmentTaskManagerCollection allDepartmentsInTasksList; //CONTAINS ALL DEPARTMENTS WITH TASKS DONE
        #endregion

        #region CONSTRUCTORES
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        #region EVENTS

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            efficiencyDepartmentsList = DepartmentEfficiencyCollection.ListDepartmentEfficiencyCollection();
            allUsersInformationList = UserInformationCollection.ListUserInformation();
            allDepartmentsInTasksList = DepartmentTaskManagerCollection.ListDepartmentTasksCollection();
            EmployCardsFiltersCreate();
        }

        private void Main_Unloaded(object sender, RoutedEventArgs e)
        {
            efficiencyDepartmentsList = null;
            allUsersInformationList = null;
            allDepartmentsInTasksList = null;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            ManageDepartmentCheckBoxes(checkBox);
            EmployCardsCreate(departmentSelectedList);
        }

        private void topComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (departmentSelectedList.Count != 0)
            {
                EmployCardsCreate(departmentSelectedList);
            }

        }

        #endregion

        #region METHODS
        /// <summary>
        /// THIS METHOD CREATE CHECKBOXES OF ALL DEPARTMENTS EXISTIS IN DATABASE WITH TASKS DONE
        /// AND CHARGE OPTIONS TO THE TOP COMBO BOX
        /// </summary>
        private void EmployCardsFiltersCreate() 
        {
            //WILL CHARGE TOP COMBO BOX WITH PAIR NUMBERS UNTIL 10 INCLUDE
            //AND WIL DEFINE FIRST RECORD(INDEX 0 = NUMBER 2) IN COMBO BOX
            for (int i = 2; i <= 10; i++)
            {
                if (i % 2 == 0) //IF PAIR
                {
                    topComboBox.Items.Add(i);
                }
            }
            topComboBox.SelectedIndex = 0;

            //WILL CREATE "GERAL" DEPARTMENTS CHECK BOX AND ADD AN CHECKED CHANGED EVENT 
            geralCheckBox.Content = "GERAL";
            geralCheckBox.Foreground = Brushes.White;
            geralCheckBox.Margin = new Thickness(5);
            checkBoxDadWrapPanel.Children.Add(geralCheckBox);
            geralCheckBox.Checked += CheckBox_CheckedChanged;
            geralCheckBox.Unchecked += CheckBox_CheckedChanged;

            IEnumerable<string> distinctDepartmentsList = BusinessLayer.Collections.DepartmentTaskManagerCollection.DistinctDepartments(allDepartmentsInTasksList);

            //CREATE THE REST OF CHECK BOXES FOR ALL DISTINCT DEPARTMENTS IN THE DATABASE
            foreach (var department in distinctDepartmentsList)
            {
                CheckBox depart = new CheckBox();
                depart.Content = department;
                depart.Foreground = Brushes.White;
                depart.Margin = new Thickness(5);
                checkBoxDadWrapPanel.Children.Add(depart);
                depart.Checked += CheckBox_CheckedChanged;
                depart.Unchecked += CheckBox_CheckedChanged;
            }
        }

        /// <summary>
        /// THIS METHOD CREATE EMPLOY CARDS BASED ON CHECK BOXES
        /// AND NUMBER SELECTED IN TOP COMBO BOX
        /// </summary>
        /// <param name="departmentSelectedList"></param>
        private void EmployCardsCreate(List<string> departmentSelectedList)
        {
            //CONTAINS THE GREATEST PART OF CARD INFORMATION OF ONE USER
            IEnumerable<UserInformationModel> userInformationList = UserInformationCollection.UsersByDepartment(departmentSelectedList, allUsersInformationList);
            //CLEAN PANEL
            cardsDadWrapPanel.Children.Clear();
            int counter = 0;
            string employNumber = "1";
            object topComboBoxSelectedObject = topComboBox.SelectedItem;

            if (userInformationList != null && topComboBoxSelectedObject != null) 
            {
                foreach (UserInformationModel user in userInformationList)
                {
                    //IF COUNTER IS LESS THAN NUMBER YOU SELECTED IN COMBO BOX CREATE A CARD
                    if (counter < (int)topComboBox.SelectedItem)
                    {
                        EmployCardsUC cardsUC = new EmployCardsUC(user.FullName, user.TasksDone, user.DepartmentName, employNumber, efficiencyDepartmentsList); //PASSAR LISTA DE SECÇOES SELECIONADAS
                        cardsUC.Margin = new Thickness(5);
                        //ADD TO INTERFACE PANEL
                        cardsDadWrapPanel.Children.Add(cardsUC);
                        counter++;
                        employNumber = (counter + 1).ToString(); //WILL BE ALWAYS COUNTER + 1
                    }
                }
            }
        }

        /// <summary>
        /// METHOD WITH ALL THE LOGIC TO MANAGE THE DEPARTMENTS CHECKBOXES 
        /// </summary>
        /// <param name="checkBox"></param>
        public void ManageDepartmentCheckBoxes(CheckBox checkBox)
        {
            string checkBoxSelected = checkBox.Content.ToString();

            if (checkBox.IsChecked == true)
            {
                departmentSelectedList.Add(checkBoxSelected);
            }

            else
            {
                if (departmentSelectedList.Contains(checkBoxSelected))
                {
                    departmentSelectedList.Remove(checkBoxSelected);
                }
            }

            if (checkBoxSelected != "GERAL" && checkBox.IsChecked == true)
            {
                geralCheckBox.IsChecked = false;
            }

            else if (checkBoxSelected == "GERAL" && checkBox.IsChecked == true)
            {
                foreach (CheckBox checkBoxChildren in checkBoxDadWrapPanel.Children)
                {
                    if (checkBoxChildren.Content.ToString() != "GERAL")
                    {
                        checkBoxChildren.IsChecked = false;
                    }
                }
            }
        }
        #endregion
    }
}
