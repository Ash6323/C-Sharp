namespace PracticeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //QueueTest queue = new QueueTest();
            //queue.runQueue();

            //FileHandlingClass fileHandling = new FileHandlingClass();
            //fileHandling.runFileHandler();

            //ParentClass a = new ChildClass();
            //ChildClass b = new ParentClass();     //Gives Compiler Error

            //AsyncAndAwait runnableObject = new AsyncAndAwait();
            //runnableObject.MainMethod();

            LINQDemo linqDemo = new();
            linqDemo.LINQ();
        }
    }
}