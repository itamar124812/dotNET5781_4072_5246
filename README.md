# dotNET5781_4072_5246
<br>In this project we created an application that allows you to manage a bus system using the three-tier model(data layer,logic/business layer and User interface layer).</br>
<h2>Our three-tier model</h2>
Each layer has an interface that describes the actions that the layer can do (except for the user interface layer which is itself an interface).
In the logic layer and the data layer there are also different data classes that help to organize the data within the class according to the needs of each layer. (The user interface layer uses the data classes of the logic layer).
<h2>Our data Layer</h2>
All data organization class in this layer are in the DO folder and are passively maintained.</br>
Our data layer consists of two separate systems that give two different ways to store the data:</br>
1. In xml files (this way saves all the data even when the program is not running and is the default of the program) all the methods related to this way are implemented in dalxml.
<br>2. Save in data structures (deleted when the program stops running) implemented in DalObject.</br>
The two layers implement one common interface called IDal and it is the interface of the data layer.
The factory template is the one that allows a convenient alternative between the two ways. Another important detail is that the data layer is of the singelton type in order to maintain that there will be only one such system.
<h2>Our logic layer</h2>
The structure of this layer is very similar to the one below which it also has an operations interface (IBl) and also has its own data organization classes that are in the BO folder.<br/>
Our logic layer has two jobs:<br/>
1. Operate while running the bus simulator as if they are really moving.<br/>
2. Bridge between the data layer and the user interface layer.
This layer is also use factory and singelton disgn pattern.
<h2>Our User Intarface layer</h2>
This layer is implement with WPF when the user who is the system manger can enter his user name and password and see the stations and lines that exisits in the system.
he can also start and control the lines trips.


