# About Catnap

Catnap is a basic lightweight ORM for .NET. It uses the ADO.NET API. The project includes an adapter for Sqlite, and it 
is tested with ```System.Data.Sqlite``` and ```Mono.Data.Sqlite```.

Catnap was created to alleviate the of pain hand-rolling data access and dynamic SQL for applications that target an 
environment where a full featured ORM (such as NHibernate) is incompatible or too heavy. More specifically Catnap was created to 
work with MonoTouch on the IPhone, which explicitly disallows any runtime compilation.

We actively seek contributors to make Catnap better and more robust while remaining lightweight and able to work with MonoTouch.

For a list of features and some code samples read the [Introduction](https://github.com/timscott/catnap/wiki/Introduction) in the [Wiki](https://github.com/timscott/catnap/wiki/Introduction).

Discuss Catnap [here](http://groups.google.com/group/catnap-orm-discuss).
