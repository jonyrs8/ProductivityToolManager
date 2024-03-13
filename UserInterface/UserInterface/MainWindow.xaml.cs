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

namespace UserInterface
{

    //IDEIA PARA MOSTRAR DADOS:

    //TAREFAS POR FAZER, FEITAS E ACABADAS AO DIA DE HOJE


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public TaskCollection taskslist;
        public IEnumerable<string> areas;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //TaskCollection _taskslist = TaskModel.ListAllTasks(); //CARREGA A TABELA DE UMA VEZ SÓ
            ////IEnumerable<string> _areas = DepartmentEfficience.GetDistinctAreas(taskslist);
            //taskslist = _taskslist;
            //var taskRealTime = DepartmentEfficience.GetTasksRealTime(taskslist).ToList();
            //var displayData = taskRealTime.Select(item => new {
            //    Area = item.Area,
            //    TeoricalTimeInTasks = item.TeoricalTimeInTasks
            //}).ToList();

            //this.datagrid.ItemsSource = DepartmentEfficience.depCollection() ;

            //areas = _areas;
        }

        
    }
}
