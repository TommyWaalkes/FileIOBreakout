using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //We need to create a reader and read to end to the get data out 
            //That data comes back as a big string, so we'll need our string methods 
            Console.WriteLine("Sup");
            Console.WriteLine("Please input a country name");
            string inputCountry = Console.ReadLine();
            List<string> countries;
            string filePath = @"C:\Users\Tommy\Documents\Visual Studio 2017\Projects\_Breakouts\FileIO\Countries.txt";
            //Lastly to save, we need save, the way you do that is via a streamWriter 
            StreamReader reader;
            StreamWriter writer;
            try
            {

                //Man readers are cool!!
                //Read is my file IO Reader

                reader = new StreamReader(filePath);
                string fileOutput = reader.ReadToEnd();
                
                if (!fileOutput.Contains(inputCountry))
                {
                    fileOutput += $", {inputCountry}";
                    Console.WriteLine("New Country added!");
                    Console.WriteLine(fileOutput);
                }
                else
                {
                    Console.WriteLine("That country already exists, the file has not been changed");
                    Console.WriteLine(fileOutput);
                }
                countries = fileOutput.Split(',').ToList();
                reader.Close();

                writer = new StreamWriter(filePath);
                writer.Write(fileOutput);

                writer.Close();
                PrintCountryList(countries);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            //Where have we seen read and write before?

           
        }

        public static void PrintCountryList(List<string> countries)
        {
            foreach(string country in countries)
            {                
                Console.WriteLine(country.Trim());
            }
        }
    }
}
