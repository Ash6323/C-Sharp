using System;

public class ParentClass
{
	public ParentClass()
	{
		Console.WriteLine("Parent Class Constructor");
	}
}
public class ChildClass : ParentClass
{
	public ChildClass()
	{
		Console.WriteLine("Child Class Constructor");
	}
}
