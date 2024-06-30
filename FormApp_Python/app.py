from flask import Flask, render_template, request, redirect, url_for
import mysql.connector

app = Flask(__name__)

# Configure MySQL
db_config = {
    'user': 'root',
    'password': '2522',
    'host': '127.0.0.1',
    'port': '3306',
    'database': 'tech_requests'
}

# Function to get data from the database
def fetch_data():
    conn = mysql.connector.connect(**db_config)
    cursor = conn.cursor()
    query = "SELECT email, description, dueDate FROM request_list ORDER BY dueDate ASC"
    cursor.execute(query)
    data = cursor.fetchall()
    cursor.close()
    conn.close()
    return data

@app.route('/')
def index():
    success_message = request.args.get('success') # Show success after submission
    return render_template('form.html', success_message=success_message)


@app.route('/submit', methods=['POST'])
def submit():
    email = request.form['email']
    description = request.form['description']
    dueDate = request.form['dueDate']

    # Connect to MySQL
    conn = mysql.connector.connect(**db_config)
    cursor = conn.cursor()

    # Insert data into the database
    query = "INSERT INTO request_list (email, description, dueDate) VALUES (%s, %s, %s)"
    cursor.execute(query, (email, description, dueDate))
    conn.commit()

    cursor.close()
    conn.close()

    return redirect(url_for('index', success='Your request has been submitted!'))


@app.route('/reqList')
def reqList():
    # Get data from the database to show request list
    data = fetch_data()
    return render_template('requestList.html', data=data)


if __name__ == '__main__':
    app.run(debug=True)

