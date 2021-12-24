# ContactApp
 


This project created for Rise Technology's assesment requirements.


Used Technologies;

Language: C#

Framework: .NET 5

Database:PostgreSQL

Queue Builder: RabbitMQ

Architect & Struct : Microservices & N-Tier Structure

Test: Xunit Test ( Microsoft Technology ) 

ORM : EntityFramework Core

Object Mappers : AutoMapper

Identity : Not used but can be prefer Microsoft Identity

API security : Not used but can be prefer JWT basically



Project Info:

Contact & Report Creator.



RT.Contact : 

Basically Contact CRUD operations 

RT.Report :

Basically Report CRUD operations





How to setup & Install 


1) Download & Setup VSCode or Visual Studio ( IDE )
2) Download  & Setup PostgreSQL for database.
3) Download & Setup RabbitMQ




How to migrate project for first run :

Database;

Open the NPM console and run on RT.Contact and run dotnet ef database update
Open the NPM console and run on RT.Report and run dotnet ef database update


Queue Manager

Create a RabbitMQ user with command promp. Create a Queue as a named customQueue 





API & CRUD operations

The project has include swagger for API usage information and default examples. You can use swagger or Postman (optional )

