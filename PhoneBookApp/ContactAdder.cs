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
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var contact in contacts)
                    {
                        writer.WriteLine($"Name:{contact.Name},Number:{contact.Number}");
                    }
                }

                Console.WriteLine("Contacts saved to the file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private void LoadContactsFromFile(string filePath)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading contacts: {ex.Message}");
            }
        }
    }
}
