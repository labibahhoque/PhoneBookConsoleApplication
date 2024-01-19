using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class ContactAdder:IPhoneBook
    {
        private List<Contact> contacts { get; set; } = new List<Contact>();

       

        public void AddContacts(Contact contact)
        {
           
            LoadContactsFromFile(filePath);
            contacts.Add(contact);
            SaveContactsToFile(filePath);
        }
        string filePath= @"C:\\Users\\User\\source\\repos\\PhoneBookApp\\PhoneBookApp\\Contacts.txt";
        public void SaveContactsToFile(string filePath)
        {
            
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var contact in contacts)
                    {
                        writer.WriteLine($"{contact.Name},{contact.Number}");
                    }
                }

                Console.WriteLine("Contacts saved to the file successfully.");
            
           
        }
        private void LoadContactsFromFile(string filePath)
        {
            
            
                string[] lines = File.ReadAllLines(filePath);
                contacts.Clear(); 

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
            }
           
           
    }
}
