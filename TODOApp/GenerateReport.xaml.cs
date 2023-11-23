using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace TODOApp
{
    /// <summary>
    /// Interaction logic for GenerateReport.xaml
    /// </summary>
    public partial class GenerateReport : Window
    {
        public GenerateReport()
        {
            InitializeComponent();
        }

        public GenerateReport(List<Task> tasks)
        {
            InitializeComponent();
            
            // Just print tasks to report screen
            liv_tasks.ItemsSource = tasks.ToList();
        }


    }
}
