using System;
using System.Collections.Generic;
using System.Text;

namespace TODOApp
{
    public class Task
    {
        #region Fields

        private string _notes;
        private string _name;
        private DateTime _dueDate;

        #endregion

        #region Constructors

        public Task()
        {
            // Default constructor to display an example task, will be overwritten when a task is inputted
            Name = "Sample Task";
            Notes = String.Empty;
            DueDate = DateTime.Now;
        }
        public Task(string name)
        {
            // Sets task name and if no date was inputted, gives a default of the time it was inputted at
            Name = name;
            DueDate = DateTime.Now;
        }
        public Task(string name, DateTime dueDate)
        {
            // Sets task name and date to user value
            Name = name;
            DueDate = dueDate;
        }

        public Task(string name, DateTime dueDate, string notes)
        {
            // Sets task name, date, and note to user value
            Name = name;
            DueDate = dueDate;
            Notes = notes;
        }

        #endregion

        #region Properties
        // Missing validation, will be added ... WIP
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
            set
            {   
                // If no datetime, set as Today (Shouldn't ever be used but if case arises ...
                if (value == null)
                {
                    value = DateTime.Today;
                }
                _dueDate = value;
            }
        }
        #endregion
    }
}
