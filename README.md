# fsad-g53-llp-user-api

[![.NET](https://github.com/DevendraKumarG/fsad-g53-llp-user-api/actions/workflows/dotnet.yml/badge.svg)](https://github.com/DevendraKumarG/fsad-g53-llp-user-api/actions/workflows/dotnet.yml)

## Prerequisites
- **.NET 8 SDK**: [Download here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- **MySQL Server**: [Download here](https://dev.mysql.com/downloads/mysql/)
- **MySQL Workbench**: [Download here](https://dev.mysql.com/downloads/workbench/)
- **Git**: [Download here](https://git-scm.com/downloads)

## Setup Instructions

### Clone the Repository
git clone https://github.com/DevendraKumarG/fsad-g53-llp-user-api.git
cd fsad-g53-llp-user-api

### Database Setup
1. Open MySQL Workbench and connect to your local server.
2. Create a new schema via **Server > Data Import** and select the SQL file in the cloned directory.

### Configure Application
Update the `appsettings.json` with your database connection details:

 "DefaultConnection": "server=localhost;port=3306;database=llp-dev;uid=root;pwd=your_password"
 
Replace your_password with your MySQL root password.

### Build and Run

Run the following commands to build and run the API:

dotnet build

dotnet run

To Access API
Visit https://localhost:7008/swagger/index.html
