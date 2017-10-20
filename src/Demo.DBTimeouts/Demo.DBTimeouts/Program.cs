using System;
using System.Data.Entity.Infrastructure;

namespace Demo.DBTimeouts
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var context = new TestContext())
                {
                    //context.Database.CommandTimeout = 7;
                    context.Database.ExecuteSqlCommand("exec dbo.DelayInSeconds @delayInSeconds = 6");
                    //context.Database.CommandTimeout = 30;
                }

                Console.WriteLine("Success!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failure:  \r\n\r\n{e.Message}");
            }

            Console.ReadLine();
        }
    }

    public class TestContext : System.Data.Entity.DbContext
    {
        public TestContext() :
            base("TestContext")
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = 2;
        }
    }
}
