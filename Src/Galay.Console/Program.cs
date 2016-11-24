using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Galaxy.Repository.SystemManage;
using Galaxy.Entity.SystemManage;
using Galaxy.Data;


namespace Galay.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new Task(() =>
           {
               System.Console.WriteLine("Task1");
               using (var rb = new RepositoryBase().BeginTrans())
               {
                   User ue = rb.FindEntity<User>("5c873bcf-f84a-4805-b888-32592ae38a5f");
                   ue.ManagerId = "aaaa";
                   rb.Update<User>(ue);
                   Thread.Sleep(5000);
                   rb.Commit();
                   System.Console.WriteLine("aa");
               }
           }).Start();


            new Task(() =>
            {
                System.Console.WriteLine("Task2");
                using (var rb = new RepositoryBase().BeginTrans())
                {
                    Thread.Sleep(1000);
                    User ue = rb.FindEntity<User>("5c873bcf-f84a-4805-b888-32592ae38a5f");
                    rb.Delete<User>(ue);
                    Thread.Sleep(2000);
                    rb.Commit();
                }
            }).Start();

            System.Console.WriteLine("ok");

            System.Console.Read();
        }
    }
}
