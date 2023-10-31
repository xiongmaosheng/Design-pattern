// See https://aka.ms/new-console-template for more information
using 简单工厂模式;

Console.WriteLine("Hello, World!");
NameFactory nameFactory = new NameFactory();
Namer namer = nameFactory.getName("Hello, World!");
Console.WriteLine(namer.getFrname()); 
Console.WriteLine(namer.getLname()); 
