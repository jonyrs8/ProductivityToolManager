using BusinessLayer.Collections;
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

namespace UserInterface.ChartsUC
{
    /// <summary>
    /// Interaction logic for EmployCardsUC.xaml
    /// </summary>
    public partial class EmployCardsUC : UserControl
    {
        public EmployCardsUC()
        {
            InitializeComponent();
            DataContext = this.DataContext;
        }
        public EmployCardsUC(string name, int tasksNumber, string departmentName, string employNumber, DepartmentEfficiencyCollection list) 
            :this()
        {
            InitializeComponent();
            DataContext = this.DataContext;

            string departmentEfficiency = DepartmentEfficiencyCollection.GetDepartmentEfficiency(departmentName, list).ToString();
            name = NameValidation(name);

            employNumberTextBlock.Text = $"EMPLOY NUMBER {employNumber}";
            userNameTextBlock.Text = $"NAME: {name}";
            userDepartmentTextBlock.Text = $"DEPARTMENT: {departmentName}";
            tasksNumberTextBlock.Text = tasksNumber.ToString();
            efficienceTextBlock.Text = $"DEPARTMENT EFFICIENCY: {departmentEfficiency}%";
        }

        private string NameValidation(string fullName)
        {

            if (fullName.Length > 12)
            {

                string[] nameParts = fullName.Split(' ');
                return nameParts[0];
            }

            return fullName;
        }
    }
}
