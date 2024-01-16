using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PhoneBookApp
{
     public class ContactSearch:IContactSearch
    {
        private List<Contact> contacts { get; set; }=new List<Contact>();

        string filePath = @"C:\\Users\\User\\source\\repos\\PhoneBookApp\\PhoneBookApp\\Contacts.txt";
        public void SearchContact(string searchPhrase)
        {
            try
            {
               
                string[] lines = File.ReadAllLines(filePath);

                
                List<Contact> contacts = new List<Contact>();

               
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string name = parts[0].Trim();
                        string number = parts[1].Trim();
                        contacts.Add(new Contact(name, number));
                    }
                }

                
                var matchingContacts = contacts.Where(c => c.Name.Contains(searchPhrase)).ToList();

                
                if (matchingContacts.Any())
                {
                    foreach (var contact in matchingContacts)
                    {
                        Console.WriteLine($"Contact: {contact.Name}, {contact.Number}");
                    }
                }
                else
                {
                    Console.WriteLine("No matching contacts found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    
}
