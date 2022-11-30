using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace AddressBook_System
{
    internal class FileReadORWrite
    {
        public static string path = @"C:\Users\NRP\Desktop\BATCH_207\GIT\AddressBook_System\AddressBook_System\AddressBook_System\DataFiles\Contacts.txt";
        public static string csvpath = @"C:\Users\NRP\Desktop\BATCH_207\GIT\AddressBook_System\AddressBook_System\AddressBook_System\DataFiles\Contacts.csv";
        public static string jsonpath = @"C:\Users\NRP\Desktop\BATCH_207\GIT\AddressBook_System\AddressBook_System\AddressBook_System\DataFiles\Contacts.json";

        // Writes the file.
        public static void WriteFile(List<Contact> contacts)
        {
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    foreach (Contact contact in contacts)
                    {
                        streamWriter.WriteLine(contact.toString()); ;
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("\n Data SucessFully Written Into Text File !");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nFile Not Found !");
            }
        }

        // Reads the file.
        public static void readFile()
        {
            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string data = String.Empty;
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(data);
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("\nFile Not Found !");
            }
        }

        public static void WriteToCSV(List<Contact> contacts)
        {
            if (File.Exists(csvpath))
            {
                AddressBook addressBook = new AddressBook();
                
                using (StreamWriter sw = new StreamWriter(csvpath))
                using (CsvWriter csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                   
                    csv.WriteRecords(contacts);
                    Console.WriteLine("\n Data SucessFully Written Into CSV File !");
                }

            }
            else
                Console.WriteLine("\nFile Not Found !");

        }


        public static void ReadFromCSV()
        {

            using (StreamReader sr = new StreamReader(csvpath))
            using (CsvReader reader = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                var records = reader.GetRecords<Contact>().ToList();

                Console.WriteLine("Reading records from address book csv file...");
                foreach (Contact item in records)
                {
                    Console.Write(item.FirstName);
                    Console.Write("\t" + item.LastName);
                    Console.Write("\t" + item.MobNumber);
                    Console.Write("\t" + item.Email);
                    Console.Write("\t" + item.Address);
                    Console.Write("\t" + item.City);
                    Console.Write("\t" + item.State);
                    Console.Write("\t" + item.Zip);

                    Console.WriteLine();
                }
            }

        }
        //alternate way to read from csv file

        //public static void ReadFromCsvFile()
        //{
        //    string path = @"";
        //    string[] data = File.ReadAllLines(path);
        //    string[] header = { "First Name", "LastName", "Address", "City", "State", "Zip Code", "Phone Number", "Email" };

        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        string[] person = data[i].Split(",");
        //        for (int j = 0; j < person.Length; j++)
        //        {
        //            Console.WriteLine(header[j] + " : " + person[j]);
        //        }
        //    }

        //}


        // Writes the into json file.

        public static void WriteToJSON(List<Contact> contacts)
        {
            if (File.Exists(jsonpath))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(jsonpath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, contacts);
                }
                Console.WriteLine("\n Data SucessFully Written Into CSV File !");
            }
            else
            {
                Console.WriteLine("\nFile Not Found !");
            }
        }

        // Reads from json file.
        public static void ReadFromJSON()
        {
            if (File.Exists(jsonpath))
            {
                List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(jsonpath));
                foreach (Contact contact in contacts)
                {
                    Console.Write("\n" + contact.FirstName);
                    Console.Write("\n" + contact.LastName);
                    Console.Write("\n" + contact.MobNumber);
                    Console.Write("\n" + contact.Email);
                    Console.Write("\n" + contact.Address);
                    Console.Write("\n" + contact.City);
                    Console.Write("\n" + contact.State);
                    Console.Write("\n" + contact.Zip);
                    
                }
            }
            else
            {
                Console.WriteLine("\nFile Not Found !");
            }
        }

    }
}
