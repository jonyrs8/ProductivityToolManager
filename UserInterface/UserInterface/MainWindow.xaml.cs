using BusinessLayer.Collections;
using BusinessLayer.Enumerations;
using BusinessLayer.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UserInterface.ChartsUC;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region GLOBAL VARIABELS
        //CONTAINS THE CONTENT OF THE CHECK BOXES SELECTED TO MANAGE CARDS
        List<string> departmentSelectedList = new List<string>(); 
        CheckBox geralCheckBox = new CheckBox();
        //CONTAINS ALL EFFICIENCIES BY ALL DEPARTMENTS
        DepartmentEfficiencyCollection efficiencyDepartmentsList;
        //CONTAINS THE GREATEST PART OF CARDS INFORMATIONS OF ALL USERS
        UserInformationCollection allUsersInformationList;
        //CONTAINS ALL DEPARTMENTS WITH TASKS DONE
        DepartmentTaskManagerCollection allDepartmentsInTasksList;
        TasksDoneByUserCollection userList;
        IEnumerable<string> distinctDepartmentsList;
        IEnumerable<string> distinctUserList;
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
            distinctDepartmentsList 
                = BusinessLayer.Collections.DepartmentTaskManagerCollection.DistinctDepartments(allDepartmentsInTasksList);
            userList = TasksDoneByUserCollection.ListNumberOfTasksDoneByUser();
            distinctUserList = BusinessLayer.Collections.DepartmentTaskManagerCollection.DistinctUsers(userList);
            EmployCardsFiltersCreate();
        }

        private void Main_Unloaded(object sender, RoutedEventArgs e)
        {
            efficiencyDepartmentsList = null;
            allUsersInformationList = null;
            allDepartmentsInTasksList = null;
            distinctDepartmentsList = null;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string departmentName = checkBox.Content.ToString();

            bool? isChecked = checkBox.IsChecked;
            if (departmentName != "GERAL" && isChecked == true)
            {
                geralCheckBox.IsChecked = false;
            }

            else if (departmentName == "GERAL" && isChecked == true)
            {
                foreach (CheckBox checkBoxChildren in checkBoxDadWrapPanel.Children)
                {
                    if (checkBoxChildren.Content.ToString() != "GERAL")
                    {
                        checkBoxChildren.IsChecked = false;
                    }
                }
            }

            ManageDepartmentCheckBoxes(departmentName, isChecked);

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
        /// THIS METHOD CREATE CHECKBOXES OF ALL DEPARTMENTS EXISTIS IN DATABASE WITH TASKS DONE - OTIMIZADA
        /// AND CHARGE OPTIONS TO THE TOP COMBO BOX
        /// </summary>
        private void EmployCardsFiltersCreate()
        {
            ComboBoxCreate(2, 10, IntervaloComboBox.Pair);

            GeralCheckBoxStaticCreate("GERAL", Brushes.White);

            CheckBoxCreate(distinctDepartmentsList);
        }

        private void ComboBoxCreate(int firstNumber, int lastNumber, IntervaloComboBox intervalo)
        {
            //WILL CHARGE TOP COMBO BOX WITH PAIR NUMBERS UNTIL 10 INCLUDE
            //AND WIL DEFINE FIRST RECORD(INDEX 0 = NUMBER 2) IN COMBO BOX

            ComboBox comboBox = topComboBox;

            for (int i = firstNumber; i <= lastNumber; i++)
            {
                if (intervalo == IntervaloComboBox.Pair && i % 2 == 0)
                {
                    comboBox.Items.Add(i);
                }

                else if (intervalo == IntervaloComboBox.Impair && i % 2 != 0)
                {
                    comboBox.Items.Add(i);
                }

                else if (intervalo == IntervaloComboBox.Normal)
                {
                    comboBox.Items.Add(i);
                }
            }

            comboBox.SelectedItem = lastNumber;
        }

        private void GeralCheckBoxStaticCreate(string name, SolidColorBrush color)
        {
            //WILL CREATE "GERAL" DEPARTMENTS CHECK BOX AND ADD AN CHECKED CHANGED EVENT 
            geralCheckBox.Content = name;
            geralCheckBox.Foreground = color;
            geralCheckBox.Margin = new Thickness(5);
            checkBoxDadWrapPanel.Children.Add(geralCheckBox);
            geralCheckBox.Checked += CheckBox_CheckedChanged;
            geralCheckBox.Unchecked += CheckBox_CheckedChanged;

            geralCheckBox.IsChecked = true;
        }

        private void CheckBoxCreate(IEnumerable<string> list)
        {
            //CREATE THE REST OF CHECK BOXES FOR ALL DISTINCT DEPARTMENTS IN THE DATABASE
            foreach (string items in list)
            {
                CheckBox item = new CheckBox();
                item.Content = items;
                item.Foreground = Brushes.White;
                item.Margin = new Thickness(5);
                checkBoxDadWrapPanel.Children.Add(item);
                item.Checked += CheckBox_CheckedChanged;
                item.Unchecked += CheckBox_CheckedChanged;
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
            IEnumerable<UserInformationModel> userInformationList 
            = UserInformationCollection.UsersByDepartment(departmentSelectedList, allUsersInformationList);

            //CLEAN PANEL
            cardsDadWrapPanel.Children.Clear();
            int counter = 0;
            string employNumber = "1"; //STARTS IN 1
            object topComboBoxSelectedObjects = topComboBox.SelectedItem;

            if (userInformationList != null && topComboBoxSelectedObjects != null)
            {
                foreach (UserInformationModel user in userInformationList)
                {
                    //IF COUNTER IS LESS THAN NUMBER YOU SELECTED IN COMBO BOX CREATE A CARD
                    if (counter < (int)topComboBoxSelectedObjects)
                    {
                        EmployCardsUC cardsUC 
                            = new EmployCardsUC(user.FullName, user.TasksDone, user.DepartmentName, 
                                employNumber, efficiencyDepartmentsList);

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
        public void ManageDepartmentCheckBoxes(string department, bool? isChecked)
        {

            if (isChecked == true)
            {
                departmentSelectedList.Add(department);
            }

            else
            {
                if (departmentSelectedList.Contains(department))
                {
                    departmentSelectedList.Remove(department);
                }
            }
        }
        #endregion
    }
}
