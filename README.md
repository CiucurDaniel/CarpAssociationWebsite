[![Made with](https://img.shields.io/badge/Made%20with-.NET%20ASP%20MVC5-yellowgreen)](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started)

# CarpAssociationWebsite
Carp Association Website - Made with ASP .NET MVC5

Carp Associations are similar to banks just that they are dedicated to retired people. They provide their members with possiblity to start a savings account (single account, different than banks where you can have one or many accounts) or to get a loan.

The user of this website is the actual employee of the Carp Association.
The main functionalities provided to employees are:
  - Add new members to association
  - Give a loan to a member
  - Start a savings account for a member
  - Generate all the documents from the website as PDF files

# Author of the project 

 * Ciucur Daniel

 *"This project represents my BSc thesis, the project aims to provide a form of digitalization to Carp Associations.
 Even nowadays Carp Association use Excel or handwritten notebooks in order to perform their activities. Those solutions are inefficient and error-prone, therefore, my application wants to improve this aspect by providing a web application from where those associations can manage their operations."*  - July 2021

<br>

<img src="CarpAssociationWebsite/Documentation/Images/uvt_logo.png" width="300">

<br><br>
# Status of the project 

The project is finished, an application with core features of CARP Associations is made available.

![Login page](CarpAssociationWebsite/Documentation/Images/AppScreenshots/Homepage.JPG?raw=true "Login page")

# Use cases

The bellow diagram illustrates the use cases of the application. 
The user is the CARP employee, however for many interactions the CARP member is also present as he is the one requesting some of the operations.

![Use case Diagram](CarpAssociationWebsite/Documentation/VisioDiagrams/VisioDiagramsImages/UseCaseDiagram2.png?raw=true "App Models")

# Models Overview 
Bellow you can see the entities that a typical CARP Association uses and with our application has. This ERD diagram reflects our database schema. 
**Note:** The database was created using **Code-First approach** which means we first created the entities and then EF6 generated our database.

![ERD Diagram](CarpAssociationWebsite/Documentation/VisioDiagrams/VisioDiagramsImages/DatabaseERDiagram.png?raw=true "App Models")

## Technologies

| Dependency | Version*
| :--- | ---:
| .NET Framework | 4.7.2
| ASP.NET MVC | 5.2.7
| Bootstrap | 4.6.0
| C# | 6
| Entity Framework | 6.4.4
