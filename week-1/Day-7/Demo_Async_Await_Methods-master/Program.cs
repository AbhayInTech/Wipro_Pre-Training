using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Async_Await_Methods
{
    internal class Program
        //Non -Blocking execution
        //Prallel task 
        //Efficient reosurce management 
        //Improved performance
                //Why we should use task as compared to thread/threadpool
                // Task simplifies code using async and await
                // it automatically cpaures exception
                // Beter scalibiltiy in async enviornments
                // It easier to combine, chain or cancel task
                // While ordering apizza (a Task) ... When pizza is done ( You await it)

    {
        static async Task Main(string[] args) // async makes a method asynchronous
        {
            Console.WriteLine(  "Async and Await Methods..!!!");
            Console.WriteLine(  " Fetch studnt data....!!!");
            //call async method
            string result = await FetchStudentDataAsync(); //await tells compiler to pause the method execution unitl awaited task completes 
            Console.WriteLine(  result);
            Console.WriteLine("Process completed ..!!");
        }

        static async Task<string> FetchStudentDataAsync()
        {
            await Task.Delay(2000);//Simulating Delay// Here Task represents async operation
            return "Student data fetched suceesfully !";
        }
    }
}
