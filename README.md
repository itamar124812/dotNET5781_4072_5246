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
This layer is implement with WPF and use: multi threading, event-oriented programming and implementaion of obsever disgn pattern.
<br>When the user who is the system manger can enter his user name and password and see the stations and lines that exisits in the system.
The user can also start and control the lines trips.
<br>In previous exercises(like dotnet_3B_4072_5246) we built a system to monitor the buses themselves and we plane to extands the system that will support in those actions.
<br>Another extension we are planning is to add a user interface for a user who wants to use this bus service.
<h3>exercises</h3>
So far the presentation of the project, I will briefly describe here what each exercise we did on the way to the project contains:
<br>dotnet_00_4072_5246: Our first use in c# and our first joint work at github as well.
<br>dotnet_01_4072_5246: In this exercise we improved our skills in c # and wrote simple software that manages an array of buses between there exit trips and treatments.
<br>dotnet_02_4072_5246: If the previous exercise is about buses this exercise is about lines.
<br>dotnet_3A_4072_5246: Our first wpf work and all the rest is in the previous exercise.
<br>dotnet_3B_4072_5246: Our first use in events and multi threading programming. We bulit program that mange bus system and like in dotnet_01_4072_5246:(but much more complicated) we need to divide the trips between treatments and refueling so that each bus will undergo treatment after 20,000 kilometers or after a year and will refuel every 1000 km while refueling of course he can not make trips and while traveling he can only make one trip.
