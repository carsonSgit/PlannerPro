# PlannerPro
Coded in collaboration with Xuli Ma (@XULIM on github)

## App Contributions 

- **Carson:**
  - Formal document, UML diagrams, part of C# for WPF, error resolution, part of Task class, app beautification.
  
- **[Xuli Ma](https://github.com/XULIM):**
  - WPF GUI, some background methods, part of Task class, GenerateReport window, Save & Load.
 
# Project Description

This project is a simple personal agenda designed to meet the basic needs of anyone. Instead of relying on a physical notepad and pen, users can access their personal agenda on their computer, making it especially convenient for those working in the tech industry. The current features of the project include:

- **List of Tasks and Dates**
  - A list displaying the user's tasks and deadlines. By default, they are unsorted.

- **Organize Your Daily Activities**
  - A "Sort" button that, when clicked, arranges tasks chronologically (by date, soonest first, latest last).

- **Generate Report for Tasks Due Today**
  - A button that, when clicked, pops up a new window showing tasks and notes due today.

- **Generate Report for Overdue Activities**
  - A button that, when clicked, displays a new window with the task's name, notes, and due date.

- **Save and Load**
  - Save button: Saves tasks and data to a project file.
  - Load button: Checks for the file's existence; if not, prompts the user with a message like "You have not saved previously."

- **Notes for a Task**
  - A section for users to write notes about their tasks. Notes are optional.

- **Set a Deadline for the Activity**
  - A calendar for setting the task's due date. If no date is provided, it won't be added.

# Development Approach

## Problem Comprehension
- Reviewed project information and requirements to understand the task.

## Analysis, Identifying Concepts
- Considered the elements necessary for completing the project and identified parameters to meet project requirements.

## Define Requirements and Results
- Determined data types and functions needed for executing features.

## Design a Strategy
- Outlined desired features and graphical interface before sketching the GUI.

## Research and Modification
- Explored references like Microsoft's To-Do and simple notepad tools for inspiration.

## Testing
- Due to the simplicity of XAML and the background code, testing focused on design preferences and trial-and-error.

# OOP Design

For this straightforward project, we implemented two classes:

1. **XAML.cs Class**
   - Responsible for GUI functionality to give purpose to the graphical interface.

2. **Task Class**
   - Allows users to create planned tasks with constructors for various cases: task name only, task name and due date, or name, due date, and note. This class facilitates all desired functionalities in the program.

# Screenshots

If you would like a more detailed version, here is an imgur with some more screenshots: https://imgur.com/a/0uMokn2

## Default Screen

Landing page.

![defaultScreen](https://github.com/carsonSgit/PlannerPro/assets/92652800/724c36dc-0a69-4f53-a4a2-2c192d37c3c1)

## Filled-in Task

All fields function as needed. 

![filledInTask](https://github.com/carsonSgit/PlannerPro/assets/92652800/51b80b0f-e9ef-41c9-b630-bff203851f4a)

## Save Tasks

For here, we save the data in the current task list in a CSV file.

![clickSave](https://github.com/carsonSgit/PlannerPro/assets/92652800/b4eeceb2-b8cd-460f-a255-687a797453a7)

![saveFileExplorer](https://github.com/carsonSgit/PlannerPro/assets/92652800/58e57023-3983-4c5a-9d70-3c440c379958)

## Load Tasks

To load a task list, we simple click the Load button and it prompts us to select a saved CSV.

![clickLoad](https://github.com/carsonSgit/PlannerPro/assets/92652800/ad1b17c6-9bcc-433a-b3b0-ace9ce16a4e7)

![selectLoadExplorer](https://github.com/carsonSgit/PlannerPro/assets/92652800/fe08f69b-e92d-411f-b5ca-9dfd39d41d2d)


## Due Today Report

Click on the Due Today button to display a report of tasks due today.

### If there are tasks due today, we display this report
![dueToday](https://github.com/carsonSgit/PlannerPro/assets/92652800/53e42f75-985f-4537-b9c9-f19efc7d3f4e)

### If there are none, we see this
![nothingDueToday](https://github.com/carsonSgit/PlannerPro/assets/92652800/1c23db33-9702-4896-9916-771599b9dbc2)

## Overdue Report

Click on the Overdue button to display a report of tasks that have passed the due date

### If there are tasks that are Overduee, we display this report
![overDueTask](https://github.com/carsonSgit/PlannerPro/assets/92652800/466b73c7-c1c8-4abc-9e49-b6a669cdc606)

### If we have no overdue tasks, we see this
![nothingOverdue](https://github.com/carsonSgit/PlannerPro/assets/92652800/6173ef3b-784e-4fc7-a143-92875ad06613)




