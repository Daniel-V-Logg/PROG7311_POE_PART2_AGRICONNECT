# PROG7311_POE_PART2_AGRICONNECT

# AgriEnergyConnect - Employee Management System

This repository contains the code for **AgriEnergyConnect**, a simple web-based application designed to manage employee and farmer data. It allows admins to add, edit, and delete farmer details, and display them in a table for easy management.

## Table of Contents
1. [Setup Instructions](#setup-instructions)
2. [Running the Application](#running-the-application)
3. [Features and Functionalities](#features-and-functionalities)
4. [System User Roles](#system-user-roles)
5. [License](#license)

## Setup Instructions

### Prerequisites
Before setting up the development environment, ensure you have the following installed on your system:
- [Visual Studio](https://visualstudio.microsoft.com/) (for C#/.NET development)
- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other compatible database

### Cloning the Repository
1. Open a terminal or command prompt.
2. Clone the repository using the command:
   ```
   git clone https://github.com/Daniel-V-Logg/PROG7311_POE_PART2_AGRICONNECT.git
   ```

### Setting up the Development Environment
1. Open the cloned repository in Visual Studio.
2. Restore the project dependencies:
   - In the **Solution Explorer**, right-click on the solution and select **Restore NuGet Packages**.
3. Configure the database:
   - Update the `ConnectionStrings` section in `appsettings.json` to point to your local or cloud database.
   - Run the database migrations to set up the schema:
     ```
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```

### Running the Application
1. Press `Ctrl + F5` (or click **Run** in Visual Studio) to start the application.
2. Open a browser and navigate to:
   ```
   http://localhost:5000
   ```
   The application should now be running locally.

## Running the Prototype

Once the application is up and running, follow these steps to test the prototype:

1. **Add a Farmer**: Navigate to the *Add Farmer* section and fill out the form with the necessary information. Click **Add Farmer** to submit.
2. **Edit a Farmer**: In the *All Farmers* table, click **Edit** next to a farmer to modify their details.
3. **Delete a Farmer**: Click **Delete** next to a farmer to remove them from the database.

## Features and Functionalities

- **Farmer Management**: Admins can add, edit, and delete farmer information.
- **Role-Based Selection**: When adding or editing a farmer, users can select a role for the farmer (e.g., Crop Farmer, Livestock Farmer, Mixed Farmer).
- **Farmer Table**: A list of all farmers with their details (Name, Surname, Role) is displayed in a table, with options to edit or delete.

## System User Roles

- **Admin**: The primary role responsible for adding, editing, and deleting farmer data. They can also view all farmer details.
  
## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
