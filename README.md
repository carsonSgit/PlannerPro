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

