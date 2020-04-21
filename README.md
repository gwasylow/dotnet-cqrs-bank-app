# dotnet-cqrs-bank-app
dotnet-cqrs-bank-app


User Story:
As a user I would like to:
  - login/log off to a system
  - read the balance amount
  - read the latest 10 transacations history 
  - send the money transfer to a different account
  - to be notyfied about incoming transfer on my account

Tech background:
  - Mock Database Objects (shared in memory)
  - Hosting: Azure Free WebApp plan
  - .NET Core MVC + built-in DI mechnism
  - CQRS/CQS Pattern + Mediator Pattern (Mediator# - if applicable)
  - Event Storming method
  - DDD (Domain Driven Development - if applicable)
  - TDD (if applicable)
  - Simple xHTML/Razor/CSS Forms (bootstrap if applicable)
  - GitHub (CI/CD if applicable)
  - User Manual/Documentation on GitHub
  
  
  
  
  
CQS: Command Query Separation (CQS)
Each method in the object must belong to only one category out of the following two:
- command – a method which changes an object’s state,
-	query – a method which returns the data.
It means that all the queries should return the same result as long as you didn’t change the object’s state with a command.

  
CQRS: Command Query Responsibility Segregation
CQRS is a style of application’s architecture which separates the “read” operations and the “write” operations on the bounded context level.
Implementation of a logic responsible for writing is independent of an implementation of a logic responsible for reading.
All the changes are done in a write model. It generates the events which inform about the changes, then these are consumed by a read model.




