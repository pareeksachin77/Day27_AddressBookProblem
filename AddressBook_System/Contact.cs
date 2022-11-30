using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string toString()
        {
            return "\nName : " + FirstName + "  " + LastName + "\tContact No.: " + MobNumber + "\tEmail : " + Email + "\tAddress : " + Address + "\tCity : " + City + "\tState : " + State + "\tZipCode : " + Zip;
        }
        public string ToString()
        {
            return FirstName + LastName + MobNumber + Email + Address + City + State + Zip;
        }
       

    }
}
