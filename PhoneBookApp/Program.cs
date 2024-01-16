using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Select Operation");
            Console.WriteLine("1.Add Contact");
          
            Console.WriteLine("2.View all Contacts");
            Console.WriteLine("3.Search Contact");
            Console.WriteLine("4.Press x to exit the program");

            var userInput=Console.ReadLine();

            IContactDisplayer contactDisplay = new ContactDisplay();
            IContactSearch contactSearch = new ContactSearch();
            IPhoneBook contactAdder = new ContactAdder();
            



            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Contact name:");
                        var name = Console.ReadLine();
                        Console.WriteLine("Contact number:");
                        var number = Console.ReadLine();

                        var newContact = new Contact(name, number);
                        contactAdder.AddContacts(newContact);

                        break;
                    
                    case "2":
                        contactDisplay.DisplayAllContacts();

                        break;
                    case "3":
                        Console.WriteLine("Name search phrase");
                        var searchPhrase = Console.ReadLine();
                        contactSearch.SearchContact(searchPhrase);
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Select valid operation");
                        break;

                }

                Console.WriteLine("Select operation:");
                userInput = Console.ReadLine();
            }
        }
    }
}
