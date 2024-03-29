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
        public EmployCardsUC(string userID, int tasksNumer)
        {
            InitializeComponent();
            DataContext = this.DataContext;

            userNameTextBlock.Text = $"NAME: {userID}";
            tasksNumberTextBlock.Text = tasksNumer.ToString();
        }
    }
}
