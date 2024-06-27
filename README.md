ToDo Project

Once upon a time, there was a busy professional named Sarah. Sarah had so many tasks to juggle every day – from work assignments and meetings to grocery shopping and household chores. With all these responsibilities piling up, she found it increasingly challenging to keep track of everything she needed to do.

One day, Sarah missed an important deadline because she forgot about a crucial task buried deep in her long list of to-dos. That's when she realized she needed a better way to manage her tasks and stay organized.

That's where our ToDo application comes in! It's like having a personal assistant that helps Sarah keep track of all her tasks in one place. With our app, Sarah can easily add new tasks, set priorities, assign due dates, and even categorize them based on different projects or areas of her life.

Whenever Sarah completes a task, she can simply mark it as done, and the app will update her list accordingly. No more forgetting important deadlines or feeling overwhelmed by endless to-do lists!

Our ToDo application simplifies Sarah's life by providing a centralized hub for managing her tasks efficiently. Now, she can focus on what truly matters without worrying about missing deadlines or forgetting important tasks.

Model (M):
TaskModel.cs: Represents the data model for tasks in the application.
Properties:
TaskID: int
Description: string
Status: bool
Priority: string
DueDate: DateTime
Category: string
Service (s)
TaskService.cs

Methods:
CRUD operations to interact with the database (e.g., AddTask(), GetAllTasks(), UpdateTask(), DeleteTask()).

View (V):
- Index.cshtml: Displays the list of tasks.
- Create.cshtml: Form for creating a new task.
- Edit.cshtml: Form for editing an existing task.
- Delete.cshtml: Confirmation page for deleting a task.
- Layout.cshtml: Defines the layout structure shared across multiple views.
  
Controller (C):
TaskController.cs: Handles user interactions and serves as the intermediary between the model and the views.

Actions:
Index(): Retrieves all tasks from the database and renders the Index view.
Create(): Displays the Create view for adding a new task.
Add(TaskModel task): Processes the form submission for adding a new task.
Edit(int id): Displays the Edit view for modifying an existing task.
Update(TaskModel task): Processes the form submission for updating a task.
Delete(int id): Displays the Delete view for confirming the deletion of a task.
ConfirmDelete(int id): Processes the deletion of a task.
Database structure
CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY AUTO_INCREMENT,
    Description VARCHAR(255) NOT NULL,
    Status VARCHAR(20) NOT NULL DEFAULT 'Incomplete',
    Priority VARCHAR(20),
    DueDate DATE,
    Category VARCHAR(50)
);
TaskID: A unique identifier for each task.
Description: A field to store the description of the task.
Status: Indicates whether the task is complete or incomplete.
Priority: Represents the priority level of the task (e.g., high, medium, low).
DueDate: Stores the due date of the task.
Category: Represents the category or project to which the task belongs.

User Stories
As a user, I want to be able to add a new task to my ToDo list so that I can keep track of things I need to do.

Acceptance criteria:
User should be able to input a task description.
Task should be successfully added to the ToDo list.
The added task should be displayed in the list of tasks.
As a user, I want to be able to view all the tasks in my ToDo list so that I can see what I need to accomplish.

Acceptance criteria:
User should be able to see a list of all tasks currently in the ToDo list.
Each task should display its description and status (completed or not).
The list should be displayed in a clear and organized manner.
As a user, I want to be able to mark a task as complete so that I can keep track of what I've accomplished.

Acceptance criteria:
User should be able to select a task from the ToDo list.
User should be able to mark the selected task as complete.
Completed tasks should be visually distinguished from incomplete tasks in the list.
As a user, I want to be able to edit the details of a task in my ToDo list so that I can update it if necessary.

Acceptance criteria:
User should be able to select a task from the ToDo list.
User should be able to edit the description of the selected task.
Changes made to the task details should be saved successfully.
As a user, I want to be able to delete a task from my ToDo list so that I can remove tasks that are no longer relevant.

Acceptance criteria:
User should be able to select a task from the ToDo list.
User should be able to delete the selected task.
Deleted task should be removed from the list.
As a user, I want to be able to prioritize tasks in my ToDo list so that I can focus on the most important ones first.

Acceptance criteria:
User should be able to assign a priority level (e.g., high, medium, low) to each task.
Tasks should be sorted based on their priority level in the ToDo list.
As a user, I want to be able to organize tasks into different categories or projects so that I can manage them more effectively.

Acceptance criteria:
User should be able to assign a category or project to each task.
User should be able to filter tasks based on their assigned category or project.
As a user, I want to be able to set due dates for tasks in my ToDo list so that I can prioritize my work and meet deadlines.

Acceptance criteria:
User should be able to specify a due date for each task.
Overdue tasks should be visually distinguished from tasks with upcoming or past due dates.
User should be able to sort tasks based on their due dates.
As a user, I want to be able to search for tasks in my ToDo list so that I can quickly find what I'm looking for.

Acceptance criteria:
User should be able to enter a search query.
Tasks matching the search query should be displayed in the list.
Search results should update dynamically as the user types.
As a user, I want to be able to filter tasks in my ToDo list based on criteria such as priority, due date, or category so that I can focus on specific tasks at a time.

Acceptance criteria:
User should be able to apply filters based on priority, due date, or category.
Only tasks matching the selected filter criteria should be displayed in the list.
User should be able to clear filters to view all tasks again.
