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

    public void SearchContacts()
    {

    }

    public void MainMenu()
    {

        Console.WriteLine("(1) Lägg till ny kontakt (2) Sök kontakt (3) Visa alla kontakter (4) Avsluta");
        ShowAllContacts(); //Visar alla kontakter direkt när programmet öppnar. 

        while (true)
        {
            string val = Console.ReadLine() ?? "";

            switch (val)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    SearchContacts();
                    break;
                case "3":
                    ShowAllContacts();
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Ogiltligt val, försök igen");
                    break;

            }

            Console.WriteLine("(1) Lägg till ny kontakt (2) Sök kontakt (3) Visa alla kontakter (4) Avsluta");

        }


    }

}