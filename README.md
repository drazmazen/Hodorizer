Hodorizer
=========
An application for when you want to make someone's computer able to type __only__ the word *'hodor'*, all in good fun.
Server side is a Wcf service hosted in a console application. It intercepts all keyboard input from user and outputs 'hodor' instead. There is also a WPF client used to call the service.


##About
This little weekend project was actually started because I wanted to play a prank on my wife, so the code is quick and dirty without any refactoring, design patterns or best practices.
It uses [SetWindowHookEx](http://www.pinvoke.net/default.aspx/user32.setwindowshookex) to install the hook and intercept keyboard input and [SendInput](http://www.pinvoke.net/default.aspx/user32.sendinput) to inject some Hodor into your life.
Included folders are as follows:
 - CSharpHodor: a proof of concept console app
 - Hodor.Interception: the class library project that contains WinApiInputIntercept, class that's a Win Api wrapper
 - Hodor.Service: WCF service library in which the magic happens
 - Hodor.WinService: basically just a windows service which hosts the WCF service library(does not work because windows services don't catch keyboard events)
 - Hodor.Client: WPF application which is a client that is used to turn Hodorization on and off
 - Hodor.ConsoleServiceHost: a console application that acts as host for the Hodor.Service WCF library
 - Hodor.Scheduler: a console application that schedules the ConsoleServiceHost application to be started on user logon
 - Hodor.ServiceInstaller: installer for the ConsoleServiceHost. Also triggers the scheduler at the end of installation. Needs to be run as administrator

##Quick How To
*Note: I have tested the application only on a 64 bit Windows 7.*

After building the solution in the Visual Studio, Hodor.ServiceInstaller folder will contain the installer for the service. It needs to be run as administrator. It will install Hodor.ConsoleServiceHost and schedule it to be started when the user logs on. 

