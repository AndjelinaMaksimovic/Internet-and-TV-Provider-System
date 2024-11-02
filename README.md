[Serbian](README.srb.md)

# System for Internet and TV Providers

### Project Description

The project "System for Internet and TV Providers" is a project developed by five students in their third year of the **Software Design** course at the _Faculty of Natural Sciences and Mathematics_. The project requirements specification can be found [here](https://gitlab.pmf.kg.ac.rs/ds/projekat-2023/tim-01/-/blob/master/docs/opisProjekta.md). The team consists of:
- Radovan Drašković
- Marija Jolović
- Damjan Pavlović
- Anđelina Maksimović
- Uroš Mladenović

The project can be cloned using the following git command:
`git clone http://gitlab.pmf.kg.ac.rs/ds/projekat-2023/tim-01.git`
or by downloading the .zip folder with the project content.

# Requirements for Running the Application in a Development Environment

The required packages for connecting to the appropriate database type are listed in the _requirements.txt_ file, whose content can be viewed [here](https://gitlab.pmf.kg.ac.rs/ds/projekat-2023/tim-01/-/blob/master/requirements.txt).
Since the project consists of a _class library_ and a _Windows Forms app_, you need to build the library before using the project and modify the path in the _config_ file to the appropriate database on your computer (in case of connection to an SQLite database) or specify the server and appropriate credentials (in case of connection to a MySQL database).

# Database Support
- SQLite
- MySQL

The UML diagram representing the structure of the library can be downloaded [here](https://gitlab.pmf.kg.ac.rs/ds/projekat-2023/tim-01/-/blob/master/docs/UML_packet_providers.png).
<div>
  <img src="../docs/UML_packet_providers.png" alt="UML diagram" height=700>
</div>

Example of application usage:
https://gitlab.pmf.kg.ac.rs/ds/projekat-2023/tim-01/-/blob/master/docs/vid.mp4?expanded=true&viewer=rich
