using BusinessLayer;
using BusinessLayer.Collections;
using BusinessLayer.Model;
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
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CheckBox geral = new CheckBox();
            geral.Content = "GERAL";
            geral.Foreground = Brushes.White;
            geral.Margin = new Thickness(5);
            checkBoxDadWrapPanel.Children.Add(geral);
            geral.IsChecked = true;

            IEnumerable<string> distinctDepartments = BusinessLayer.Collections.DepartmentTaskManagerCollection.DistinctDepartments();

            foreach(var department in distinctDepartments) 
            { 
                CheckBox depart = new CheckBox();
                depart.Content = department;
                depart.Foreground = Brushes.White;
                depart.Margin = new Thickness(5);
                checkBoxDadWrapPanel.Children.Add(depart);
            }

            for (int i = 2; i <= 10; i++)
            {
                if (i % 2 == 0) // Verifica se o número é par
                {
                    topComboBox.Items.Add(i);
                }
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
