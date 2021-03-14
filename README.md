[![Made with](https://img.shields.io/badge/Made%20with-.NET%20ASP%20MVC5-yellowgreen)](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started)

# CarpAssociationWebsite
Carp Association Website - Made with ASP .NET MVC5

Carp Associations are similar to banks just that they are dedicated to retired people. They provide their members with possiblity to start a savings account (single account, different than banks where you can have one or many accounts) or to get a loan.

The user of this webiste is the actual employee of the Carp Association.
The main functionalities provided to employees are:
  - Add new members to association
  - Give a loan to a member
  - Start a savings account for a member
  - Generate all the documents from the website as PDF files

# Design Patterns

* Model View View-Model

# TODO: Items that need to be implemented
- [x] Update menu to work in Boostrap 4.6
- [x] Add Entity Framework 6 to project
- [x] create the DbContext;
- [ ] Model the entities
- [x] Create Log in functionality
- [ ] Create a better UI for the login screen
- [ ] Design the home dashboard
- [ ] About page
- [ ] Contact Page
- [ ] CRUD member operations
- [ ] Acoount operations for member (create, deposit, withdraw, all those should generate PDF files)
- [ ] Loan operations

# Problems and or improvements
- the current version uses Session as a login/logout mechanism a big improvment would be moving this to ASP .NET Identity
- decide if macking the controllers (some ) async will speed up the website
- in the future, the controllers will have some very complex lines of code (complex data retrieval from the db and such), in order to keep the controllers thin a service layer could be implemented, then the controllers will only be focused on making the call and handling the result.
# Status of the project 

The project is at the initial phase.

## Technologies

| Dependency | Version*
| :--- | ---:
| .NET Framework | 4.7.2
| ASP.NET MVC | 5.2.7
| Bootstrap | 4.6.0
| C# | 6
| Entity Framework | 6.4.4
