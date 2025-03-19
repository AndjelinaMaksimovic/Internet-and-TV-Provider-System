[Serbian](paterni.md)

# Design Patterns

### Creational Design Patterns

* Singleton

*Creational Pattern*

<div>
  <img src="./resources/images/singleton.png" alt="Singleton logo" height=150>
</div>

Used to create a database connection to avoid multiple calls to the class constructor, which would result in creating different instances of the _Database_ class. Instead, an instance of the class can be obtained by calling the _GetInstance_ method, which will return the instance if it already exists, or create a new one if it is being called for the first time. To ensure this behavior works properly, the Database class constructor is private and can only be called by the _GetInstance_ method if the instance hasn't been created yet.

* Factory Method

*Creational Pattern*

<div>
  <img src="./resources/images/factory_method.png" alt="Factory method logo" height=150>
</div>

Used to elegantly solve the problem of whether to establish a connection with an **SQLite** database or a **MySQL** database. This decision can be made using simple _if_ statements, but this approach allows for future expansion by adding a new class to handle connections with other databases, without altering the existing code. Additionally, this approach hides from the user how the connection is established and which database is used, as everything is handled in the private constructor of the class while the necessary data is obtained from the configuration file.

* Prototype

*Creational Pattern*

<div>
  <img src="./resources/images/prototype.png" alt="Prototype method logo" height=150>
</div>

The Prototype pattern is used in this project to allow efficient creation of copies of _Client_ and _Packet_ objects. This pattern allows new instances of objects to be created by cloning existing ones, rather than creating new objects through constructors. It improves the efficiency and flexibility of object creation within the project, contributing to better organization and performance of the application.

* Builder

*Creational Pattern*

<div>
  <img src="./resources/images/builder.png" alt="Builder method logo" height=150>
</div>

The Builder design pattern allows flexible and clean construction and configuration of complex _Packet_ objects. This avoids unnecessary complexity and reduces code for users who construct packets. It is implemented by separating the construction process from the representation, meaning it separates the process of constructing _Packet_ objects from their internal representation. Each specific builder (**InternetPacketBuilder**, **TVPacketBuilder**, and **CombinedPacketBuilder**) defines how a specific type of packet is constructed, while the _DirectorPacketBuilder_ coordinates the described process.

* Decorator

*Structural Pattern*

<div>
  <img src="./resources/images/decorator.png" alt="Decorator method logo" height=150>
</div>

The Decorator pattern is used in this project to dynamically add new behaviors, like **logging**, to objects. This is achieved by implementing **wrapper** classes that contain these additional behaviors, allowing for flexible extension of the logger functionality. This results in a modular and extendable design for the logger functionality. New behaviors can easily be incorporated into logger objects, making customization and scalability easier while adhering to object-oriented design principles.

* Facade

*Structural Pattern*

<div>
  <img src="./resources/images/facade.png" alt="Facade method logo" height=150>
</div>

In this project, the Facade pattern is used to provide a simple and cohesive interface to access a complex subsystem, making it easier to use multiple components from a central location. Methods like _getProviderName()_, _getAllClients(string like)_ and _registerClient(string username, string firstName, string lastName)_ provide a simple interface for reading provider data, getting all clients, or registering new clients. These methods delegate complex tasks to specialized classes like **ClientLogic** for working with clients and **PacketLogic** for working with packets.

* Command

*Behavioral Pattern*

<div>
  <img src="./resources/images/command.png" alt="Command method logo" height=150>
</div>

The Command pattern is used in this project to separate the invocation of activating and deactivating packets from the objects that perform these actions. This results in increased flexibility and extensibility, enabling easy addition of new actions.

* Memento

*Behavioral Pattern*

<div>
  <img src="./resources/images/memento.png" alt="Memento method logo" height=150>
</div>

The Memento pattern is used in this project to allow the saving and restoration of the state of the Database subsystem. The Snapshot class stores the previous system state, including changes made to the database. With it, it is possible to save the current state of the system (CreateSnapshot), restore the subsystem to a previous state (RestoreSnapshot), and re-execute actions (RedoSnapshot). The ICommandMemento interface provides methods for redo and undo, implemented by the ConcreteCommand class, defining the actual actions of re-executing or reverting a previous command.

This pattern allows for efficient state management of the system, enabling its saving at different points and restoration to previous states when needed.
