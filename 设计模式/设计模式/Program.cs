// See https://aka.ms/new-console-template for more information

using 装饰器模式;

Console.WriteLine("Hello, World!");
IText text = new TextObject();
text = new BlodDecorator(text);
text = new ColorDecorator(text);
Console.WriteLine(text.Content);

text = new TextObject();
text = new ColorDecorator(text);
Console.WriteLine(text.Content);

text = new TextObject();
text = new BlockAllDecorator(text);
Console.WriteLine(text.Content);