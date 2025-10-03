using System;

class AddressBook
{

    List<Contact> contactList = new(); //Skapa ny lista 

    public void AddContact()
    {
        Console.Write("Namn: ");
        string name = (Console.ReadLine() ?? "").Trim();

        Console.Write("Adress: ");
        string address = (Console.ReadLine() ?? "").Trim();

        Console.Write("Postnummer: ");
        string postalcode = (Console.ReadLine() ?? "").Trim();

        Console.Write("Postort: ");
        string city = (Console.ReadLine() ?? "").Trim();

        Console.Write("Telefonnummer: ");
        string phone = (Console.ReadLine() ?? "").Trim();

        Console.Write("Email: ");
        string email = (Console.ReadLine() ?? "").Trim();

        var contact = new Contact(name, address, postalcode, city, phone, email); //Skapar ett objekt av klassen Contact
        contactList.Add(contact); //Lägger till contacten i listan 

        Console.WriteLine($"Ny kontakt sparad: {contact.Name}.\n");
    }


    public void ShowContact(Contact contact)
    {
        Console.WriteLine($"Namn: {contact.Name}");
        Console.WriteLine($"Adress: {contact.Address}");
        Console.WriteLine($"Postnummer: {contact.PostalCode}");
        Console.WriteLine($"Postort: {contact.City}");
        Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
        Console.WriteLine($"Email: {contact.Email}");
        Console.WriteLine();
    }

    public void ShowAllContacts()

    {
        if (contactList.Count == 0)
        {
            Console.WriteLine("Du har inga kontakter att visa.");
            return;
        }

        foreach (var c in contactList)
        {
            ShowContact(c);
        }


    }

    public void SaveContactToFile()
    {
        List<string> lines = new List<string>();

        foreach (var c in contactList)
        {
            lines.Add(c.FormatForFile());
        }

    }

    

    

    public void DeleteContact()
    {
        if (contactList.Count == 0)
        {
            Console.WriteLine("Det finns inga kontakter att ta bort");
            return;
        }

        for (int i = 0; i < contactList.Count; i++)
        {
            Console.WriteLine($"{i}: {contactList[i].Name}"); // Utskriften blir att börjar på index 1 istället för 0.
        }

        bool valid = false;

        while (!valid)
        {


            Console.Write("Ange numret på kontakten du vill ta bort: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                int index = choice; // List börjar på index 0.

                if (index >= 0 && index < contactList.Count)
                {
                    var removed = contactList[index];
                    contactList.RemoveAt(index);

                    ///// Här ska det in en delete för text filen, just nu raderas bara kontakten i programmet////

                    Console.WriteLine($"Kontakten {removed.Name} har tagit bort");
                }
                else
                {
                    Console.WriteLine("Ogiltigt nummer.");
                }
            }
            else
            {
                Console.WriteLine("Felaktigt inmatning, vänligen skriv ett nummer");
            }

        }

    }

}