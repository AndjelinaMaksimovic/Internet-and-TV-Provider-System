# Design patterns

### Creational design patterns

* Singleton

*kreacioni patern*

<div>
  <img src="./resources/images/singleton.png" alt="Singleton logo" height=150>
</div>

Korišćen za potrebe kreiranja konekcije sa bazom podataka kako bi se izbeglo višestruko pozivanje konstruktora klase i na taj način rezultovalo kreiranjem više različitih instanci klase _Database_. Umesto toga, instanca klase se može dobiti pozivanjem medote _GetInstance_ koja će samo vratiti instancu klase ukoliko je već napravljena, odnosno kreirati instancu ukoliko se poziva prvi put. Da bi prethodno navedeno ponašanje radilo adekvatno, konstruktor klase Database je privatan i poziva ga samo metoda _GetInstance_ ukoliko instanca nije već kreirana.

* Factory Method

*kreacioni patern*

<div>
  <img src="./resources/images/factory_method.png" alt="Factory method logo" height=150>
</div>

Korišćen kako bi se na lepši način rešilo pitanje da li je potrebno napraviti konekciju sa **SQLite** bazom podataka ili **MySQL** bazom podataka. Ova odluka se moze rešiti i preko jednostavnih _if_ naredbi, ali na ovaj način, omogućeno nam je da u budućnosti dodamo konekciju sa nekom novom bazom bez da menjamo postojeći kod, već samo dodavanjem nove klase koja ce obrađivati konekciju sa tom bazom. Takođe, od korisnika je na ovaj način sakriveno kako se uspostavlja konekcija i sa kojom bazom, jer se sve navedeno radi u privatnom konstruktoru klase dok se potrebni podaci dobijaju iz konfiguracionog fajla.

* Prototype

*kreacioni patern*

<div>
  <img src="./resources/images/prototype.png" alt="Prototype method logo" height=150>
</div>

Prototype patern se u okviru ovog projekta koristi kako bi se omogućilo efikasno kreiranje kopija objekata tipova _Client_ i _Packet_. Ovaj šablon omogućava kreiranje novih instanci objekata kroz kloniranje postojećih, umesto kreiranja novih objekata pozivanjem konstruktora. Unapređuje efikasnost i fleksiblnost kreiranja novih instanci objekata u okviru projekta, i doprinosi boljoj organizaciji i performansama aplikacije.

* Builder

*kreacioni patern*

<div>
  <img src="./resources/images/builder.png" alt="Prototype method logo" height=150>
</div>

Builder dizajn obrazac omogućava fleksibilnu i čistu izgradnju i konfiguraciju složenih objekata _Packet_, čime se izbegava nepotrebna složenost i smanjuje kod za korisnike koji konstruišu pakete. Implementira se kroz separaciju konstrukcije i reprezentacije, tako što razdvaja proces konstrukcije objekata _Packet_ od njihove interne reprezentacije. Svaki konkretki builder **InternetPacketBuilder**, **TVPacketBuilder**, i **CombinedPacketBuilder** definiše kako se konkretan tip paketa gradi, dok _DirectorPacketBuilder_ koordinira opisanim procesom.

* Decorator 

*strukturni patern*

<div>
  <img src="./resources/images/decorator.png" alt="Decorator method logo" height=150>
</div>

Dekorator šablon se koristi u ovom projektu kako bi se dinamički dodala nova ponašanja **logger** objektima. To se postiže implementacijom **omotačkih** klasa koje sadrže ova dodatna ponašanja, omogućavajući fleksibilno proširenje funkcionalnosti logger-a. Ovime se postiže modularan i proširiv dizajn za funkcionalnost logger-a. Nova ponašanja mogu se lako uključiti u logger objekte, olakšavajući prilagođavanje i skalabilnost, uz poštovanje principa objekto-orijentisanog dizajna.

* Facade 

*strukturni patern*

<div>
  <img src="./resources/images/facade.png" alt="Facade method logo" height=150>
</div>

U ovom projektu se koristi Facade šablon kako bi se obezbedio jednostavan i kohezivan interfejs za pristup složenom podsistemu, čime se olakšava korišćenje više komponenti iz jednog centralnog mesta. Metode kao što su _getProviderName()_, _getAllClients(string like)_ i _registerClient(string username, string firstName, string lastName)_ pružaju jednostavan interfejs za čitanje podataka o pružaocu usluge, dobijanje svih klijenata ili registrovanje novih klijenata.
Ove metode delegiraju složene zadatke specijalizovanim klasama poput **ClientLogic** za rad sa klijentima i **PacketLogic** za rad sa paketima.

_TO DO_

_minimum 2 od behavioural patterna osim Iterator-a_