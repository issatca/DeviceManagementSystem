# Device Management System

This project is a full-stack application for managing hardware devices, featuring an **Angular** frontend, a **.NET Core Web API** backend, and a **SQL Server** database.

---

## Prerequisites
* **.NET 8.0 SDK** or later
* **Node.js** (v16+) and **npm**
* **Angular CLI** (`npm install -g @angular/cli`)
* **SQL Server** (LocalDB or Express)

---

## 1. Database Setup
The application uses a SQL Server database named `DeviceManagement`.

1.  Open **SQL Server Management Studio (SSMS)** or your preferred SQL tool.
2.  Run the script in `DeviceDb.sql` to create the database and tables.
    * *Note:* The `type` column is stored as `NVARCHAR` because the API maps string values ("Phone", "Tablet") from the database to numeric Enums in the frontend.
3.  Run the script in `data.sql` to populate the tables with initial users and devices.

---

## 2. Backend Setup (.NET Web API)
The backend handles authentication and device logic.

1.  Navigate to the backend project folder:
    ```bash
    cd Device.API
    ```
2.  Restore dependencies:
    ```bash
    dotnet restore
    ```
3.  Update the connection string in `appsettings.json` (if necessary) to match your local SQL Server instance.
4.  Run the application:
    ```bash
    dotnet run
    ```
    * The API will be available at `http://localhost:5265`.

---

## 3. Frontend Setup (Angular)
The frontend provides a dashboard to view, claim, and edit devices.

1.  Navigate to the frontend project folder:
    ```bash
    cd device-management-ui
    ```
2.  Install dependencies:
    ```bash
    npm install
    ```
3.  Run the development server:
    ```bash
    ng serve
    ```
4.  Open your browser to `http://localhost:4200`.

For more details, in FrontEnd folder is a README file