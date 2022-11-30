using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class AddressBook
    {
        public static string csvpath = @"C:\Users\NRP\Desktop\BATCH_207\GIT\AddressBook_System\AddressBook_System\AddressBook_System\DataFiles\Contacts.csv";

        public List<Contact> Details;
        public AddressBook()
        {
            Details = new  List<Contact>() ;
        }

        //Method to Add Contact
        public void AddContact()
        {
            Contact contact = new Contact();
            Console.WriteLine("\n\tEnter The Following Details\n");

            Console.Write("First Name       :  ");
            string firstName = Console.ReadLine();
            bool duplicate = equals(firstName);
            contact.FirstName = firstName;

            Console.Write("Last Name        :  ");
            contact.LastName = Console.ReadLine();

            Console.Write("Contact No       :  ");
            contact.MobNumber = Console.ReadLine();

            Console.Write("E@mail           :  ");
            contact.Email = Console.ReadLine();

            Console.Write("Address          :  ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter City       :  ");
            contact.City = Console.ReadLine();

            Console.Write("Enter State      :  ");
            contact.State = Console.ReadLine();

            Console.Write("Enter Zip        :  ");
            contact.Zip = Console.ReadLine();

            if (!duplicate)
            {
                Details.Add(contact);
                Console.WriteLine("\n---- Contact Added SuccessFully ----");
            }
            else
            {
                Console.WriteLine("Contact Can't be Added !");
                Console.WriteLine("Cannot Add Contact With Duplicate First Name !");
            }
        }

        //overriding equals method to avoid Duplicate Entries in AddressBook
        private bool equals(string name)
        {
            if (this.Details.Any(e => e.FirstName.ToLower() == name.ToLower()))
                return true;
            else
                return false;
        }

        //Method to Editing Existing Contact Details From Addressbook
        public void Edit(string firstName)
        {
            //Contact contact = null;

            foreach (Contact contact in Details)
            {


                if (firstName.Equals(contact.FirstName))
                {

                editor:
                    Console.WriteLine("\nChoose From Following List");
                    Console.WriteLine("\n1) FirstName \n2) Last Name\n" +
                                        "3) Contact No\n4) E@mail\n" +
                                        "5) City\n6) State\n7) ZipCode");
                    Console.Write("\nEnter Your Choice  :  ");
                    int choice = 0;
                    try { choice = Convert.ToInt32(Console.ReadLine()); }
                    catch (FormatException e) { Console.WriteLine(e.Message); }
                    switch (choice)
                    {
                        case 1:

                            Console.Write("Enter New First Name : ");
                            string FirstName = Console.ReadLine();
                            bool duplicate = equals(FirstName);
                            if (duplicate)
                            {
                                Console.WriteLine($"Contact {FirstName} Already Present !");
                                goto editor;
                            }
                            else
                            contact.FirstName = FirstName;
                            break;
                        case 2:
                            Console.Write("New Last Name    : ");
                            contact.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("New Contact No   : ");
                            contact.MobNumber = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("New E@mail       : ");
                            contact.Email = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("New City Name    : ");
                            contact.City = Console.ReadLine();
                            break;
                        case 6:
                            Console.Write("New State Name   : ");
                            contact.State = Console.ReadLine();
                            break;
                        case 7:
                            Console.Write("New Zip Code     : ");
                            contact.Zip = Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Wrong Input !");
                            break;
                    }
                    Console.WriteLine("\nContact Edited SucessFully  ! \n");

                    //Details.Add(contact);

                    Console.WriteLine($"\nContact of {firstName} has been edited");

                    string option;
                    Console.Write("\n\nDo You Want to Edit Another Detail (Y/N) : ");
                    option = Console.ReadLine();
                    if (option == "y" || option == "Y") { goto editor; }
                }
                else
                    Console.WriteLine($"No Contact With {firstName} Name ");
            }

        }

        //Method to Delete Contact From AddressBook
        public void delete(string name)
        {
            bool status = false;
            Contact RemoveContact = null;
            foreach (Contact contact in Details)
            {
                if (contact.FirstName.Contains(name))
                {
                    RemoveContact = contact;
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            Details.Remove(RemoveContact);
            if (status == true)
            {
                Console.WriteLine($"Contact of {name} has been deleted");
            }
            else
                Console.WriteLine($"No Contact with Name {name}");

        }

        //method to print Contacts From AddressBook
        public void displayContact()
        {
            if (Details.Count > 0)
            {
                int count = 1;
                foreach (Contact contact in Details)
                {
                    Console.WriteLine("Contact No : " + count);
                    Console.WriteLine("\nFirst Name       : " + contact.FirstName);
                    Console.WriteLine("Last Name        : " + contact.LastName);
                    Console.WriteLine("Contact No       : " + contact.MobNumber);
                    Console.WriteLine("E-Mail           : " + contact.Email);
                    Console.WriteLine("City             : " + contact.City);
                    Console.WriteLine("State            : " + contact.State);
                    Console.WriteLine("Zip Code         : " + contact.Zip);

                    Console.WriteLine("\n--------------------------------");
                    count++;
                }
            }
            else { Console.WriteLine("\nNo Contact To Display !"); }
        }

        //Method to only show First name and Last Name of Contact
        public void show()
        {
            foreach (Contact contact in Details)
            {
                Console.WriteLine("\n" + contact.FirstName + "   " + contact.LastName);

            }
        }

        //method to return list of Contacts from perticular city or state
        public List<string> findPersons(string place)
        {
            List<string> personFounded = new List<string>();
            foreach (Contact contacts in Details.FindAll(e => (e.City.ToLower().Equals(place.ToLower()))).ToList())
            {
                string name = contacts.FirstName + " " + contacts.LastName;
                personFounded.Add(name);
            }
            if (personFounded.Count == 0)
            {
                foreach (Contact contacts in Details.FindAll(e => (e.State.ToLower().Equals(place.ToLower()))).ToList())
                {
                    string name = contacts.FirstName + " " + contacts.LastName;
                    personFounded.Add(name);
                }
            }
            return personFounded;
        }

        //method to sort contact by name
        public void SortByName()
        { 
            bool check=false;
            List<string> sortList = new List<string>();
            foreach (Contact contact in Details)
            {
                string sort = contact.toString();
                sortList.Add(sort);
                check = true;
            }
            sortList.Sort();
            foreach (string sort in sortList)
            {
                Console.WriteLine(sort);
            }
            if (check == false)
            {
                Console.WriteLine("\n No Contact Available in AddressBook !");
            }
        }

        // Sort methode for sort entites in adress book by city.
        public void SortByCity()
        {
            bool check = false;

            Details.Sort(new Comparison<Contact>((a, b) => string.Compare(a.City, b.City)));
            Console.WriteLine("\nContacts after Sorting By City : \n");
            foreach (Contact contact in Details)
            {
                string sort = contact.toString();
                Console.WriteLine(sort);
                check = true;

            }
        }

        // Sort methode for sort entites in adress book by state.
        public void SortByState()
        {
            bool check = false;

            Details.Sort(new Comparison<Contact>((a, b) => string.Compare(a.State, b.State)));
            Console.WriteLine("\nContacts After Aorting By State : \n");
            foreach (Contact contact in Details)
            {
                string sort = contact.toString();
                Console.WriteLine(sort); check = true;

            }
            if (check == false)
            {
                Console.WriteLine("\n No Contact Available in AddressBook !");
            }
        }

        // Sort methode for sort entites in adress book by zip.
        public void SortByZip()
        {
            bool check = false;

            Details.Sort(new Comparison<Contact>((a, b) => string.Compare(a.Zip, b.Zip)));
            Console.WriteLine("\nContacts After Sorting By Zip : \n");
            foreach (Contact contact in Details)
            {
                string sort = contact.toString();
                Console.WriteLine(sort);
                check = true;
            }
            if (check == false)
            {
                Console.WriteLine("\n No Contact Available in AddressBook !");
            }
        }

        public void WriteToTXT_File()
        {
            FileReadORWrite.WriteFile(this.Details);
        }
        public void ReadFromTXt_File()
        {
            FileReadORWrite.readFile();
        }
        public void WriteToCSV_File()
        {
            FileReadORWrite.WriteToCSV(this.Details);
        }
        public void ReadFromCSV_File()
        {
            FileReadORWrite.ReadFromCSV();
        }
        public void WriteToJSON_File()
        {
            FileReadORWrite.WriteToJSON(this.Details);
        }
        public void ReadFromJSON_File()
        {
            FileReadORWrite.ReadFromJSON();
        }



    }

}
