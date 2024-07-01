## Overview

The **FormApp_CS** .NET web application utilizes ASP.NET Core MVC framework with C# for server-side operations and MySQL for database management. It allows users to submit technical support requests via a form and view the list of submitted requests.

### Project Structure
```
/FormApp_CS
├── Controllers
│   └── HomeController.cs
├── Data
│   └── RequestRepository.cs
├── Models
│   └── RequestModel.cs
│   └── ErrorViewModel.cs
├── Views
│   ├── Home
│   │   ├── Index.cshtml
│   │   └── RequestList.cshtml
│   ├── Shared
│   │   └── _Layout.cshtml
│   │   └── Error.cshtml
├── wwwroot
|    └── css
|        └── site.css
├── appsettings.Develoment.json
├── appsettings.json
├── FormApp.csproj
└── Program.cs

```

### Application Overview

- **Framework:** ASP.NET Core MVC (Model-View-Controller) with C#
- **Backend:** Utilizes controllers, models, and services for handling requests and interacting with the database.
- **Database:** MySQL for storing technical support requests.

#### Controllers

- **HomeController.cs:**
  - Manages HTTP requests, handles form submissions (`Index` and `Form` actions), and displays the list of requests (`RequestList` action).
  - Integrates with `RequestRepository` for database operations.

#### Data Access

- **RequestRepository.cs:**
  - Handles database operations (adding requests, fetching request list) using MySQL data connector.

#### Models

- **RequestModel.cs:**
  - Defines the structure (`Email`, `Description`, `DueDate`) and validation rules for technical support requests.

#### Views

- **Home/Index.cshtml:**
  - Form for submitting technical support requests.
  - Validates input using client-side JavaScript and displays server-side validation messages.

- **Home/RequestList.cshtml:**
  - Displays a table listing submitted technical support requests.

- **Shared/_Layout.cshtml:**
  - Shared layout for all pages.

#### Frontend

- **CSS:** `wwwroot/css/site.css` for custom styling.

### Technical Specifications

#### Libraries and Dependencies

- **ASP.NET Core MVC:** Framework for building web applications.
- **MySQL Connector:** Connects ASP.NET Core with MySQL database.

## Run The Application
### Prerequisites
- Install .NET SDK
- Install MySQL

### Commands
```
# Navigate to project directory
cd /path/to/your/project

# Install packages
dotnet add package Microsoft EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package MySql.Data

# Start MySQL service
brew services start mysql # On macOS
net start mysql # On Windows
sudo service mysql start # On Linux

# Set up MySQL database
mysql -u root -p
CREATE DATABASE tech_requests;
USE tech_requests;
CREATE TABLE request_list (
    id INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(100) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    dueDate DATE NOT NULL
);
exit

# Run .NET Application
dotnet restore
dotnet run

```

Open your web browser and navigate to the URL noted in your terminal to access the application. You should see the form for submitting technical support requests.