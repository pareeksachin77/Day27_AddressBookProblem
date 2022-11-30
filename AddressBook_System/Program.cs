namespace AddressBook_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

        Home:
            Menu();
                        int option = 0;
            try{ option=Convert.ToInt32(Console.ReadLine());}
            catch (FormatException) { Console.WriteLine("\nWrong Input  !");goto Home; }             
            switch (option)
            {

                case 0:
                    break;

                case 1:
                    Operations.AddAddressBooks();
                    goto Home;
                    break;

                case 2:
                    Operations.MultiContact();
                    goto Home;
                    break;

                case 3:
                    Operations.DisplayContacts();
                    goto Home;
                    break;

                case 4:
                    Operations.EditContact();
                    goto Home;
                    break;

                case 5:
                    Operations.RemoveContact();
                    goto Home;
                    break;

                case 6:
                    Operations.Search();
                    goto Home;
                    break;

                case 7:
                    Operations.SortAll();
                    goto Home;
                    break;

                case 8:
                    Operations.ReadAndWrite();
                    goto Home;
                    break;

                default:
                    Console.WriteLine(" Wrong Input !");
                    goto Home;
                    return;




             }

        }
        public static void Menu()
        {
            Console.WriteLine("\n---- WELCOME TO ADDRESSBOOK SYSTEM ----");

            Console.WriteLine("\n1) Add AddressBook");
            Console.WriteLine("2) Add Contacts");
            Console.WriteLine("3) Display Contacts");
            Console.WriteLine("4) Edit Contact");
            Console.WriteLine("5) Delete Contact");
            Console.WriteLine("6) Search Contact By State or City");
            Console.WriteLine("7) View Sorted Contacts");
            Console.WriteLine("8) Read And Write Into File");
            Console.WriteLine("\n\nPress 0 To Exit ! ");
            Console.Write("Enter Your Choice    : ");
        }
    }
}
