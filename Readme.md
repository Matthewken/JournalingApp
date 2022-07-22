# JournalingApp
A basic journaling web app API using .NET 6 Core

## Development Environment Used
Windows 10
Visual Studio 2022
SQL Server
Chrome

## Web Stack
ASP.NET 6 Core Web API with Entity Framework
AngularJS

## Database Requirement
It is required that you setup a SQL Server Database and use the .sql files in the sql folder within the JournalingAppBackEnd project to create the required tables. You must also rename the **appsettings.json.example** file to **appsettings.json** and replace ***<SQL_CONNECTION_STRING>*** with your SQL Server's connection string.

## API Usage Instructions

### Journals
POST GET /journals
GET PUT DELETE /journals/{journal}

### PUT and POST JSON Example
```
{
  "name": "Journal Name Example"
}
```

### Entries
POST GET /journals/{journal}/entries
GET PUT DELETE /journals/{journal}/entries/{entry}

### PUT and POST JSON Example
```
{
  "text": "Entry Text Example"
}
```

## Final Questions

1. **What's your evaluation of this exercise? Is it a reasonable and valuable skills test? Like it,
hate it?**
I really enjoyed this exercise. I belive it aligns with what I expect the skill requirements of the job would be. Allowing for the flexibility to perform optional tasks really made me feel in control over my success and inspired me to be creative in the choices I made on how I would like to implmeent the project.
2. **Briefly describe how you'd accomplish this in another tech stack (Node, Laravel, AWS Lambdas,
etc)**
Using Laravel, I'd setup a mysql database and create migrations using the same design as the SqlServer DB but a different naming convention to follow the standard.
I would then created Eloquent Models and Controllers for both tables. The controllers would be generated using the artisan resource command to quickly scaffold all the crud. After adding the resource routes to the api.php file I would implement the frontend using vue.js as that would work nicely with Laravel tooling.

## Dockerized

```
$ docker compose up -d
$ docker compose exec -it mssql /opt/mssql-tools/bin/sqlcmd -U SA -P Password1 -i /sql/init.sql
```