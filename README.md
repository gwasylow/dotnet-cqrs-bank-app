# dotnet-cqrs-bank-app
dotnet-cqrs-bank-app


## User Story:
As a user I would like to:
  - [x] login/log off to a system
  - [ ] read the balance amount
  - [ ] read the latest 10 transacations history 
  - [ ] send the money transfer to a different account
  - [ ] to be notyfied about incoming transfer on my account

## Tech background:
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
  
  
  
# CQS: Command Query Separation:
Design pattern introduced in 1986 by Bertrand Meyer, still in use and very valid approach, where any mathed in a system should be classyfied in one of two groups:
 - `Command` - these methods change the state of application but return nothing, a method which changes an object’s state.
 - `Query` - these methods return data, but don't change the application state. It means that all the queries should return the same result as long as you didn’t change the object’s state with a command.

The idea is here:
"Your question should not modify the answer"

What is wrong then?
```
public Item GetOrCreate(Item item)
{
	//Get or Create object
}
```

What will be correct:
```
public Item Get() 
{
	//get the object
}

public void Create(Item item)
{
	//create the object
}
```



# CQRS - Command Query Responsibility Segregation
20 yers later after CQS has been predefined, Greg Young and Udi Dahan proposed **CQRS**. Let's make it simple:
 - Why we need to split methods between those who get the data and modify the application state? We can achieve redesign our way of thinking and introduce classes to perform such tasks - and that's exactly the difference between CQS and CQRS.

`When we speak of CQS we consider methods, but speaking in a matter of CQRS we always consider objects.`

Let's make it clear, this is not application architecure but a deisign pattern way if implementation:
"CQRS and Event Sourcing are not architectural styles. Service Oriented Architecture, Event Driven Architecture are examples of architectural styles."
 
CQRS is a style of application’s architecture which separates the “read” operations and the “write” operations on the bounded context level.
Implementation of a logic responsible for writing is independent of an implementation of a logic responsible for reading.
All the changes are done in a write model. It generates the events which inform about the changes, then these are consumed by a read model.

**Commands**: The basics elements of CQRS is `Command` (all necessary actions should be capsulated into a single dedictaed command class). We can follow regular Command Design Pattern principles.
```
public interface ICommand
{
  //command
}
```

**Handlers**: Each `Command` must have a `one handler`, not zero, not many - just one in particular.
```
public interface IHandleCommand<TCommand> : IHandleCommand where TCommand : ICommand
{
  void Handle(TCommand command);
}
```

**Command Bus**: Now we need to manage the Command and Handlers, the best idea would be to introdue a `Command Bus`. First of all to manage, second of all, to creae a Bus for commands.
```
public class CommandsBus : ICommandsBus
{
  private readonly Func<Type, IHandleCommand> _handlersFactory;
 
  public CommandsBus(Func<Type, IHandleCommand> handlersFactory)
  {
	_handlersFactory = handlersFactory;
  }
 
  public void Send<TCommand>(TCommand command) where TCommand : ICommand
  {
	var handler = (IHandleCommand<TCommand>)_handlersFactory(typeof(TCommand));
	handler.Handle(command);
  }
}
```

**Events**: We can extend CQRS concept by introducing an `Events`, we can use this approach for `EventSourcing`. The main resposnilibity of Events in CQRS is about to `inform rest of a system that **something has happened**`:
```
public interface IEvent
{
  //Event 
}

public interface IHandleEvent
{
  //Handler
}

public interface IHandleEvent<TEvent> : IHandleEvent where TEvent : IEvent
{
  void Handle(TEvent @event);
}

public interface IEventsBus
{
  void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
}

public class EventsBus : IEventsBus
{
  private readonly Func<Type, IEnumerable<IHandleEvent>> _handlersFactory;
 
  public EventsBus(Func<Type, IEnumerable<IHandleEvent>> handlersFactory)
  {
	_handlersFactory = handlersFactory;
  }
 
  public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
  {
	var handlers = _handlersFactory(typeof(TEvent))
		.Cast<IHandleEvent<TEvent>>();
 
	foreach (var handler in handlers)
	{
		handler.Handle(@event);
	}
  }
}
```

## Basic CQRS architecture diagram:
![alt text](https://github.com/gwasylow/dotnet-cqrs-bank-app/blob/master/Images/cqrs-basic-architecture.PNG)	



# Summarizing CQS, CQRS and CQRS Event Store:

| CQS  | CQRS | CQRS Event Store |
| ------------- | ------------- | ------------- |
| Command [ **Create, Update, Delete** ] Does something, Modifies state, Should not return value | **CQRS 1D**: Commands use domain, Queries use database, Simple to implement | **Pros**: Scalability, Flexibility, Event Sourcing |
| Query [ **Read** ] Answers a question, Does not modify state, Should return value | **CQRS 2DB**: Queries use read database, Eventual consistency, Can be faster, Better scalability, Commands use write database | **Cons**: More complex than other patterns,Does not modify state, Event Sourcing costs |


  



