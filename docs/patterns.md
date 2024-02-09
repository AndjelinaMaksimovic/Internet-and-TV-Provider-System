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

* Decorator 
*strukturni patern*
<div>
  <img src="./resources/images/decorator.png" alt="Factory method logo" height=150>
</div>

Dekorator šablon se koristi u ovom projektu kako bi se dinamički dodala nova ponašanja **logger** objektima. To se postiže implementacijom **omotačkih** klasa koje sadrže ova dodatna ponašanja, omogućavajući fleksibilno proširenje funkcionalnosti logger-a. Ovime se postiže modularan i proširiv dizajn za funkcionalnost logger-a. Nova ponašanja mogu se lako uključiti u logger objekte, olakšavajući prilagođavanje i skalabilnost, uz poštovanje principa objekto-orijentisanog dizajna.

* Prototype
*kreacioni patern*
<div>
  <img src="./resources/images/prototype.png" alt="Factory method logo" height=150>
</div>