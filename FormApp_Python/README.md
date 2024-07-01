# FormCode-Exercise
## Overview
This application leverages Flask as the backend framework and MySQL as the database management system to create a simple yet functional web application for submitting and viewing technical support requests. It incorporates both server-side (Python, Flask) and client-side (JavaScript) functionalities to provide a responsive and user-friendly experience.

### Project Structure
```
/FormApp
├── venv
├── app.py
├── templates
│   ├── form.html
│   └── requestList.html
└── static
    └── stylesheet.css
```

### Application Overview:
- **Programming Language**: Python  
- **Web Framework**: Flask

### Backend:
- **Flask Framework**: Flask is a lightweight and flexible Python web framework that provides tools and libraries to build web applications. It handles routing, HTTP requests, and responses.

- **Database Management System**: MySQL

  - **MySQL Connector**: Used to connect Flask with MySQL database.
  - **Database Schema** : Created a database named tech_requests.
  - **Table**: Created a table named request_list with columns email, description, and dueDate with character and non null constraints.  

    | Field | Type | NULL |  
    | ---- | ------ | ----- |
    | PK: id | INT | No |
    | email | varchar(100) |  No |
    | description | varchar(1000) | No |
    | dueDate | date | No |


### Frontend:
- **HTML Templates**: Used Jinja2 templating engine with Flask for rendering HTML templates dynamically.
- **CSS**: Custom stylesheet (static/stylesheet.css) for styling the HTML templates.

### Functionality:
**Request Form (/ and /submit routes)**:
- Renders a form (form.html) where users can submit technical support requests.
- Validates user input for email format, length constraints for email and description fields, and due date validation using JavaScript.
- On form submission (POST request to /submit), inserts user data into the MySQL database (request_list table) and redirects back to the form page with a success message.

**Request List (/reqList route)**:
- Fetches data from the MySQL database (request_list table) to display a list of technical support requests.
- Renders the list (requestList.html) as an HTML table with columns for email, description, and dueDate.

### Technical Specifications:
**Python Libraries Used**:
- Flask (flask): Web framework for Python.
- MySQL Connector (mysql-connector-python): Python driver for MySQL.  

**JavaScript**:
- Used for client-side form validation (email format, length checks, date validation).
- Character counter for the description field (description).

### Deployment:
- **Development Server**: Flask's built-in development server (app.run(debug=True)) for testing and development purposes.



## Run the Application
### Prerequisites
- Install MySQL
- Install virtualevn
- Install Python
- Install Flask

### Commands
```
# Install virtualenv (if not installed)
pip install virtualenv

# Navigate to project directory
cd /path/to/your/project

# Create virtual environment
virtualenv venv

# Activate virtual environment
source venv/bin/activate  # On macOS/Linux
venv\Scripts\activate     # On Windows

# Install dependencies
brew install python
pip install flask
pip install Flask mysql-connector-python


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

# Run Flask application
python app.py

```
Open your web browser and navigate to http://127.0.0.1:5000/ to access the application. You should see the form for submitting technical support requests.

Navigate to http://127.0.0.1:5000/reqList to see the list of submitted forms.