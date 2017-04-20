using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace Asyncprogram
{
    class Program
    {
        static void Main(string[] args)
        {
             asyncfunctioncall();
            Console.ReadLine();
        }
        static async void asyncfunctioncall()
        {
            int contentLength = await AccessTheWebAsync();
            Console.WriteLine($"The content length of the page is {contentLength}");
        }
        static async Task<int> AccessTheWebAsync()
        {
            DateTime time = DateTime.Now;
            HttpClient client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
            DoIndependentWork();
            string urlContents = await getStringTask;
            Console.WriteLine("----- " + (DateTime.Now - time).Milliseconds + "ms passed");
            return urlContents.Length;
        }

        static void DoIndependentWork()
        {
            Console.WriteLine("It is working.....");
        }


        //static void Main(String[] args)
        //{
        //    HttpClient client = new HttpClient();
        //    Console.WriteLine("Calling the asynchronous function");
        //    Task<string> urlcontents = client.GetStringAsync("http://msdn.microsoft.com");
        //    int length= urlcontents.ToString().Length;
        //    Console.WriteLine($"Length of the string is",length);

        //    Console.ReadLine();
        //}
    }
}
