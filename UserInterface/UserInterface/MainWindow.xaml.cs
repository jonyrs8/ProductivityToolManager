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

    //IDEIA PARA MOSTRAR DADOS:

    //TAREFAS POR FAZER, FEITAS E ACABADAS AO DIA DE HOJE


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IEnumerable<UserInformationModel> userInformationList;
        List<string> departmentSelected = new List<string>();
        CheckBox geralCheckBox = new CheckBox();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            EmployCardsFiltersCreate();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EmployCardsFiltersCreate() 
        {
            for (int i = 2; i <= 10; i++)
            {
                if (i % 2 == 0) // Verifica se o número é par
                {
                    topComboBox.Items.Add(i);
                }
            }

            topComboBox.SelectedIndex = 0;
            geralCheckBox.Content = "GERAL";
            geralCheckBox.Foreground = Brushes.White;
            geralCheckBox.Margin = new Thickness(5);
            checkBoxDadWrapPanel.Children.Add(geralCheckBox);

            geralCheckBox.Checked += CheckBox_CheckedChanged;
            geralCheckBox.Unchecked += CheckBox_CheckedChanged;

            IEnumerable<string> distinctDepartments = BusinessLayer.Collections.DepartmentTaskManagerCollection.DistinctDepartments();

            foreach (var department in distinctDepartments)
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

        private void EmployCardsCreate()
        {
            cardsDadWrapPanel.Children.Clear();
            int counter = 0;
            string employNumber = "1";

            if (userInformationList != null) 
            {
                foreach (UserInformationModel user in userInformationList)
                {
                    if (counter < (int)topComboBox.SelectedItem && topComboBox.SelectedItem != null)
                    {
                        EmployCardsUC cardsUC = new EmployCardsUC(user.FullName, user.TasksDone, user.DepartmentName, employNumber); //PASSAR LISTA DE SECÇOES SELECIONADAS
                        cardsUC.Margin = new Thickness(5);
                        cardsDadWrapPanel.Children.Add(cardsUC);
                        counter++;
                        employNumber = (counter + 1).ToString();
                    }
                }
            }
        }

        private void topComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userInformationList = UserInformationCollection.UsersByDepartment(departmentSelected); //CHARGE CHOSEN DEPARTMENTS IN TEXT BOXES
            EmployCardsCreate();
        }

        private void CheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string checkBoxSelected = checkBox.Content.ToString();

            if (checkBox.IsChecked == true) 
            { 
                departmentSelected.Add(checkBoxSelected);
            }

            else 
            {
                if (departmentSelected.Contains(checkBoxSelected)) 
                {
                    departmentSelected.Remove(checkBoxSelected);
                }
            }

             if (checkBoxSelected != "GERAL" && checkBox.IsChecked == true)
             {
                geralCheckBox.IsChecked = false;
             }

             else if (checkBoxSelected == "GERAL" && checkBox.IsChecked == true) 
                {
                foreach (CheckBox control in checkBoxDadWrapPanel.Children)
                {
                    if (control.Content.ToString() != "GERAL")
                    {
                        control.IsChecked = false;
                    }
                }
            }




            userInformationList = UserInformationCollection.UsersByDepartment(departmentSelected); //CHARGE CHOSEN DEPARTMENTS IN TEXT BOXES
            EmployCardsCreate();
        }
    }
}
