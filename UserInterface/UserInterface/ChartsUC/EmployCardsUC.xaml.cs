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
        #region CONSTRUCTORES
        public EmployCardsUC()
        {
            InitializeComponent();
            DataContext = this.DataContext;
        }
        public EmployCardsUC(string name, int tasksNumber, string departmentName, string employNumber, DepartmentEfficiencyCollection departmentEfficiencyList) 
            :this()
        {
            InitializeComponent();
            DataContext = this.DataContext;
            ChargeCardInformation(name,tasksNumber,departmentName, employNumber, departmentEfficiencyList);

        }
        #endregion

        #region METHODS
        /// <summary>
        /// METHOD TO CHARGE CARD INFORMATION
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tasksNumber"></param>
        /// <param name="departmentName"></param>
        /// <param name="employNumber"></param>
        /// <param name="departmentEfficiencyList"></param>
        public void ChargeCardInformation(string name, int tasksNumber, string departmentName, string employNumber, DepartmentEfficiencyCollection departmentEfficiencyList) 
        {
            string departmentEfficiency = DepartmentEfficiencyCollection.GetDepartmentEfficiency(departmentName, departmentEfficiencyList).ToString();
            name = NameValidation(name);

            employNumberTextBlock.Text = $"EMPLOY NUMBER {employNumber}";
            userNameTextBlock.Text = $"NAME: {name}";
            userDepartmentTextBlock.Text = $"DEPARTMENT: {departmentName}";
            tasksNumberTextBlock.Text = tasksNumber.ToString();
            efficienceTextBlock.Text = $"DEPARTMENT EFFICIENCY: {departmentEfficiency}%";
        }

        /// <summary>
        /// THIS METHOD IS USED TO VERIFY IF FULL NAME HAS MORE THAN MAX CHARCTERS ALLOWED
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        private string NameValidation(string fullName)
        {
            int maxCharacteres = 12;

            if (fullName.Length > maxCharacteres)
            {
                string[] nameParts = fullName.Split(' ');
 
                if (nameParts[0].Length <= maxCharacteres) 
                {
                    return nameParts[0];
                }

                //IF FIRST NAME IS BIGGER THAN MAX CHARACTERS WILL RETUN "-"
                else {return "-";}
            }

            return fullName;
        }
        #endregion
    }
}
