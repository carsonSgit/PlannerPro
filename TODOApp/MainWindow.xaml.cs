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
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using System.Windows.Automation;

namespace TODOApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int liState = 0;
        private List<Task> sampleTasks = new List<Task>();
        private string saveLocation;


        public MainWindow()
        {
            InitializeComponent();
            if (sampleTasks.Count == 0 )
                PopulateSampleData();

            liv_tasks.ItemsSource = sampleTasks.ToList();
        }

        private void btn_sort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Orders the task list by DateTime value (this way is less efficient)
                /*sampleTasks = sampleTasks.OrderBy(task => task.Date).ToList();
                liv_tasks.ItemsSource = sampleTasks;*/

                // More "efficient" way of going about things
                liv_tasks.ItemsSource = sampleTasks.OrderBy(task => task.DueDate).ToList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(saveLocation))
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "CSV File | *.csv | All Files | *.*";

                    if ((bool)sfd.ShowDialog())
                    {
                        saveLocation = sfd.FileName;
                    }
                }

                ConvertToCSV(sampleTasks, saveLocation);
            }
            catch (Exception err) 
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            // source code from CSConferenceApp: https://github.com/arefmourtada/PIII22Sec1/blob/master/CSConferenceApp/CSConferenceApp/
            // open file dialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV File | *.csv";

            // open file dialog
            if ((bool)ofd.ShowDialog())
            {
                // change save location to the file that was opened
                saveLocation = ofd.FileName;

                PopulateSampleData(saveLocation);

                //liv_tasks.ItemsSource = sampleTasks.ToList();

                // reload the items
                liv_tasks.Items.Refresh();
            }

            //// check if file exists
            //if (File.Exists(filePath))
            //{
            //    PopulateSampleData(filePath);
            //}
            //else
            //{
            //    // Show message to user if file does not exist
            //    MessageBox.Show($"Error: file \"{filePath}\" does not exist", "Error",
            //        MessageBoxButton.OK, MessageBoxImage.Error);
                
            //}

            liv_tasks.ItemsSource = sampleTasks.ToList();
        }

        private void btn_dueToday_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Task> dueToday = sampleTasks.Where(task => task.DueDate.Date == DateTime.Today.Date).ToList();
            //string message = null;

            //if(dueToday.Count > 0)
            //{
            //    foreach (Task t in dueToday)
            //    {
            //        // no need for printing task date as it's known it's today
            //        message += t.Name + " | " + t.Notes + Environment.NewLine;
            //    }
            //    message += $"\nYou have {dueToday.Count} thing(s) left to do!";
            //    MessageBox.Show(message, "Due Today",
            //        MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //}
            //else
            //{
            //    MessageBox.Show("You have nothing due today!", "Due Today",
            //        MessageBoxButton.OK, MessageBoxImage.Information);
            //}

                // ONLY if there are tasks due today create an overdue window
                if (dueToday.Count() > 0)
                {
                    GenerateReport gr = new GenerateReport(dueToday);

                    gr.Show();
                }
                // if no tasks due today, just give a MessageBox popup
                else
                {
                    MessageBox.Show("You have nothing due today!", "Due Today",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_overdue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Very slight difference between this and dueToday
                List<Task> overdue = sampleTasks.Where(task => task.DueDate.Date < DateTime.Today.Date).ToList();

                //string message = null;
                //if(overdue.Count > 0)
                //{
                //    foreach (Task t in overdue)
                //    {
                //        message += t.Name + " | " + t.Date + " | " + t.Notes + Environment.NewLine;
                //    }
                //    message += $"\nYou have {overdue.Count} thing(s) overdue!";
                //    MessageBox.Show(message, "Overdue",
                //        MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //}
                //else
                //{
                //    MessageBox.Show("You're all caught up!", "Overdue",
                //        MessageBoxButton.OK, MessageBoxImage.Information);
                //}

                // ONLY if there are overdue tasks create an overdue window
                if (overdue.Count() > 0)
                {
                    GenerateReport gr = new GenerateReport(overdue);

                    gr.Show();
                }
                // if no overdue tasks, just give a MessageBox popup
                else
                {
                    MessageBox.Show("You're all caught up!", "Overdue",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_addTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // if displaying sample data 
                if (liState == 0)
                {
                    // clear all sample data
                    sampleTasks.Clear();
                }

                // change list state to 1
                liState = 1;

                // add new task
                sampleTasks.Add(new Task() { Name = txb_taskName.Text, DueDate = (DateTime)dtp_dueDate.SelectedDate, Notes = txb_notes.Text });

                liv_tasks.ItemsSource = sampleTasks.ToList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_eraseContent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Sets values to default
                txb_notes.Text = txb_taskName.Text = string.Empty;
                dtp_dueDate.SelectedDate = DateTime.Now;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PopulateSampleData()
        {
            try
            {
                // Sample data
                sampleTasks.Clear();
                sampleTasks.Add(new Task() { Name = "Water Plants", DueDate = DateTime.Now, Notes = "Check the soil as well" });
                sampleTasks.Add(new Task() { Name = "Go to gym", DueDate = (DateTime.Now).AddDays(1), Notes = "Get fit" });
                sampleTasks.Add(new Task() { Name = "Sample overdue task", DueDate = (DateTime.Now).AddDays(-1), Notes = "it is overdue" });
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PopulateSampleData(string filePath)
        {
            string header = "Name, Due Date, Notes";
            try
            {
                // read the file using stream reader if it exists
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;

                    // read till EOF
                    while ((line = sr.ReadLine()) != null)
                    {
                        // split each line into an array of data for object creation
                        string[] data = (line.Trim()).Split(",");

                        // if name and due date (required fields) are specified
                        if (data.Length > 1)
                        {
                            // clear the tasks lists first if it is displaying sample tasks
                            if (liState == 0)
                                sampleTasks.Clear();

                            // change list state since it is populated with meaningful data
                            liState = 1;

                            if (line == header)
                            {
                                continue;
                            }

                            // populate data accordingly
                            if (data.Length == 2)
                            {
                                sampleTasks.Add(new Task(data[0], DateTime.Parse(data[1])));
                            }
                            else if (data.Length == 3)
                            {
                                // Add new task
                                sampleTasks.Add(new Task(data[0], DateTime.Parse(data[1]), data[2]));
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ConvertToCSV(List<Task> tasks, string filePath)
        {
            try
            {
                List<string> strings = new List<string>();

                // hard code value, PropertyInfo[] can also be used
                string header = "Name, Due Date, Notes";

                // append header
                strings.Add(header);

                // append each object
                foreach (Task task in tasks)
                {
                    strings.Add($"{task.Name}, {task.DueDate}, {task.Notes}");
                }

                // write to file
                File.WriteAllLines(filePath, strings.ToArray());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
