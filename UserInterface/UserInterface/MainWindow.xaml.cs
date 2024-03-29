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
        TasksDoneByUserCollection tasksDoneByUsers;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tasksDoneByUsers = TasksDoneByUserCollection.ListNumberOfTasksDoneByUser();
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

            CheckBox geralComboBox = new CheckBox();
            geralComboBox.Content = "GERAL";
            geralComboBox.Foreground = Brushes.White;
            geralComboBox.Margin = new Thickness(5);
            checkBoxDadWrapPanel.Children.Add(geralComboBox);
            geralComboBox.IsChecked = true;

            geralComboBox.Checked += CheckBox_CheckedChanged;
            geralComboBox.Unchecked += CheckBox_CheckedChanged;

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
            foreach (TasksDoneByUserModel user in tasksDoneByUsers)
            {
                if (counter < (int)topComboBox.SelectedItem)
                {
                    EmployCardsUC cardsUC = new EmployCardsUC(user.UserID, user.TasksNumber); //PASSAR LISTA DE SECÇOES SELECIONADAS
                    cardsUC.Margin = new Thickness(5);
                    cardsDadWrapPanel.Children.Add(cardsUC);
                    counter++;
                }
            }
        }

        private void topComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployCardsCreate();
        }

        private void CheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            List<string> departmentSelected = new List<string>();
            string checkBoxSelected = checkBox.Content.ToString();

            if (checkBox.IsChecked == true) 
            { 
                labelTeste.Text = checkBoxSelected;
                departmentSelected.Add(checkBoxSelected);
            }

            else 
            {
                if (departmentSelected.Contains(checkBoxSelected)) 
                {
                    departmentSelected.Remove(checkBoxSelected);
                }
            }
        }
    }
}
