# Design patterns

### Creational design patterns

* Singleton

<div>
  <img src="./resources/images/singleton.png" alt="Singleton logo" height=150>
</div>

Korscen za potrebe kreiranja konekcije sa bazom podataka kako bi se izbeglo visestruko pozivanje konstruktora klase i na taj nacin rezultovalo kreiranjem vise instanci klase _Database_. Umesto toga, instanca klase se moze dobiti pozivanjem medote _GetInstance_ koja ce samo vratiti instancu klase ukoliko je vec napravljena, odnosno kreirati instancu ukoliko se poziva prvi put. Da bi navedeno adekvatno radilo, konstruktor klase Database je privatan i poziva ga samo metoda _GetInstance_ ukoliko instanca nije kreirana.

* Factory Method

<div>
  <img src="./resources/images/factory_method.png" alt="Factory method logo" height=150>
</div>

Koriscen kako bi se na lepsi nacin resilo pitanje da li je potrebno napraviti konekciju sa **SQLite** bazom podataka ili **MySQL** bazom podataka. Ova odluka se moze resiti i preko jednostavnih if naredbi ali nam je na ovaj nacin omoguceno da u buducnosti dodamo konekciju sa nekom novom bazom bez da menjamo postojeci kod vec samo dodavanjem nove klase koja ce obradjivati konekciju sa tom bazom. Takodje, od korisnika je na ovaj nacin sakriveno kako se uspostavlja konekcija i sa kojom bazom jer se sve navedeno radi u privatnom konstruktoru klase dok se potrebni podaci dobijaju iz konfiguracionog fajla.

* Decorator 

<div>
  <img src="./resources/images/decorator.png" alt="Factory method logo" height=150>
</div>

Koriscen kako bi se dodalo novo ponasanje na logger objekte, koristeci wrapper klasu koja sadrzi ponasanja.

