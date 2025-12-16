# DataNaut  
# A database-driven project and time management platform for DataNaut AB
## Built with SQL Server and  Entity Framework Core


### Description
DataNaut is a school project developed by students enrolled in a Fullstack Development program. The goal of the project is to build a database-driven system for project administration, time tracking, and reporting, designed around a real-world business case for DataNaut AB.
The application is built using SQL Server and Entity Framework Core, which together handle the full data flow from storage to querying and reporting. The system is structured to support clear data models, reliable data access, and LINQ-based reporting.
The project was developed over six weeks using a weekly planning approach, with the team meeting once per week to review progress and plan next steps. GitHub was used to manage the workflow and collaboration. The instructor acted as both Product Owner and reviewer, continuously inspecting and guiding the development to ensure structure, quality, and adherence to project standards.

### Technical Solution
- C# / .NET
- SQL Server
- Entity Framework Core (Database First with Code First extensions)
- LINQ to Entities for reporting queries
- Repository pattern (implemented as an additional challenge)
- GitHub used for version control and team collaboration


### Database
- The database is built in SQL Server and designed based on an ER diagram normalized to Third Normal Form (3NF).
- It models core project management concepts such as projects, team members, roles, resources, time logs and reports.
- Relationships are enforced using primary and foreign keys to ensure data integrity.
- Constraints and triggers are used where appropriate to validate data and support time logging.
- The database serves as the foundation of the system and is accessed through Entity Framework Core,
  with data retrieval and reporting handled using LINQ queries.


### Features
- Project Management
      . Create and manage projects with name, status, budget, start and end dates, and assigned project manager.
- Team & Role Management
      . Assign team members to projects with defined roles and skill areas, enabling clear responsibility and structure.
- Time Logging
      . Team members can log working time per project and activity, including date and duration.
- Reporting
      . Generate reports based on projects, team members, and time periods using LINQ to Entities.
- Resource Management
      . Track resources such as equipment, software, and licenses linked to projects.
- Relational & Normalized Data Model
      . All data is stored in a normalized SQL Server database designed according to third normal form (3NF).
- Entity Framework Core Integration
      . Data access is handled using Entity Framework Core with a combination of Database First and Code First approaches, allowing both schema-driven development and code-based extensions.
- Extensible Backend Architecture
      . The project is designed to support future extensions such as role-based access and additional reporting features.


### Reporting (LINQ)

Reporting functionality is implemented using LINQ to Entities and operates directly on the database model via Entity Framework Core.
The reporting layer focuses on validating that data can be queried and aggregated correctly without a graphical user interface. Reports are executed through LINQ queries in Visual Studio or SQL Server–backed contexts.
Example reports include:
  - Total worked time per project
  - Worked hours per team member
  - Time logs filtered by project and date range


### Testing
Unit tests have been implemented to validate LINQ-based reporting functionality.
The tests verify query correctness, data aggregation and expected result output.


### Development Process
- The project has been developed collaboratively by the team members using GitHub.
- Work was divided between database design, backend logic and reporting.
- Students met weekly to build the project collectively, with the instructor reviewing progress each week to ensure correct direction and quality.

### Team
- Abdalle Abdulkadir
- Jordan Foose
- Lukas Karlsson


















  
