# Design Patterns

### Creational Design Patterns

* Singleton

*creational pattern*

<div>
  <img src="./resources/images/singleton.png" alt="Singleton logo" height=150>
</div>

Used to create the database connection to avoid multiple calls to the class constructor, which would result in creating multiple different instances of the _Database_ class. Instead, an instance of the class can be obtained by calling the _GetInstance_ method, which returns the instance if it already exists or creates one if it's being called for the first time. To ensure this behavior, the Database class constructor is private and is only called by the _GetInstance_ method if the instance hasn't already been created.

* Factory Method

*creational pattern*

<div>
  <img src="./resources/images/factory_method.png" alt="Factory method logo" height=150>
</div>

Used to elegantly resolve whether to connect to a **SQLite** database or a **MySQL** database. This decision could be handled with simple _if_ statements, but this approach allows for future additions of new database connections without changing existing code. Instead, a new class that handles the connection to the new database type would be added. Additionally, the connection process and the type of database being used are hidden from the user, as everything is handled within the private constructor of the class, with the necessary data being retrieved from the configuration file.

* Prototype

*creational pattern*

<div>
  <img src="./resources/images/prototype.png" alt="Prototype method logo" height=150>
</div>

The Prototype pattern is used in this project to enable efficient creation of copies of _Client_ and _Packet_ objects. This pattern allows the creation of new object instances by cloning existing ones rather than calling the constructor for new objects. It enhances the efficiency and flexibility of creating new instances within the project and contributes to better organization and performance of the application.

* Builder

*creational pattern*

<div>
  <img src="./resources/images/builder.png" alt="Builder method logo" height=150>
</div>

The Builder design pattern allows for flexible and clean construction and configuration of complex _Packet_ objects. This avoids unnecessary complexity and reduces the code for users constructing packets. It is implemented through the separation of construction and representation, separating the process of building _Packet_ objects from their internal representation. Each concrete builder, **InternetPacketBuilder**, **TVPacketBuilder**, and **CombinedPacketBuilder**, defines how a specific type of packet is built, while the _DirectorPacketBuilder_ coordinates the described process.

* Decorator

*structural pattern*

<div>
  <img src="./resources/images/decorator.png" alt="Decorator method logo" height=150>
</div>

The Decorator pattern is used in this project to dynamically add new behaviors to **logger** objects. This is achieved through the implementation of **wrapper** classes that contain these additional behaviors, allowing for flexible extension of logger functionality. This results in a modular and extensible design for logger functionality. New behaviors can be easily incorporated into logger objects, facilitating customization and scalability while adhering to object-oriented design principles.

* Facade

*structural pattern*

<div>
  <img src="./resources/images/facade.png" alt="Facade method logo" height=150>
</div>

The Facade pattern is used in this project to provide a simple and cohesive interface for accessing a complex subsystem, making it easier to use multiple components from a central point. Methods such as _getProviderName()_, _getAllClients(string like)_, and _registerClient(string username, string firstName, string lastName)_ provide a simple interface for retrieving provider data, obtaining all clients, or registering new clients. These methods delegate complex tasks to specialized classes like **ClientLogic** for working with clients and **PacketLogic** for working with packages.

* Command

*behavioral pattern*

<div>
  <img src="./resources/images/command.png" alt="Command method logo" height=150>
</div>

The Command pattern is used in this project to decouple the activation and deactivation of packages from the objects that execute them. This achieves greater flexibility and extensibility, allowing for the easy addition of new actions.

* Memento

*behavioral pattern*

<div>
  <img src="./resources/images/memento.png" alt="Memento method logo" height=150>
</div>

The Memento pattern is used in this project to enable saving and restoring the state of the Database subsystem. The Snapshot class stores the previous state of the system, i.e., changes made to the database. It allows saving the current system state (CreateSnapshot), restoring the subsystem to a previous state (RestoreSnapshot), and re-executing actions (RedoSnapshot). The ICommandMemento interface ensures the existence of methods for redo and undo, whose implementation is handled by the ConcreteCommand class, defining specific actions for re-executing the previous command or undoing it.

This pattern enables efficient management of system states, allowing the state to be saved at different points and restored to previous states as needed.
