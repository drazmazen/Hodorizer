Hodorizer
=========
Wcf service hosted in a windows service. It intercepts all keyboard input from user and outputs 'hodor' instead. There is also a WPF client used to call the service.


About
=====
This little weekend project actually started because I wanted to play a prank on my wife, so the code is quick and dirty without any refactoring, design patterns or best practices.
It uses the [interception.dll](http://oblita.com/interception.html) c++ library to intercept keyboard input. See [here](https://gist.github.com/candera/1959219#file-interception-xy-cs) to see how to wrap the library with c#.
Included folders are as follows:
 - CSharpHodor: the console app I made as a proof of concept
 - Hodor.Interception: the class library project that's just a c# wrapper for a c++ library interception.dll
 - Hodor.Service: WCF service library in which the magic happens
 - Hodor.WinService: basically just a windows service which hosts the WCF service library
 - Hodor.Client: WPF application which is a client which I used to turn Hodorization on and off
