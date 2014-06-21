Hodorizer
=========
Wcf service hosted in a windows service. It intercepts all keyboard input from user and outputs 'hodor' instead.


About
=====
This little weekend project actually started because I wanted to pull a prank on my wife, so that's why the projects are quick and dirty without any code refactoring or design patterns or best practices.
Included folders are as follows:
 - CSharpHodor: the console app I made as a proof of concept
 - Hodor.Interception: the class library project that's just a c# wrapper for a c++ library interception.dll
 - Hodor.Service: WCF service library in which the magic happens
 - Hodor.WinService: basically just a windows service which hosts the WCF service library
 - Hodor.Client: WPF application which is a client which I used to turn Hodorization on and off
