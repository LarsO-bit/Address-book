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

    public void DeleteContact()
    {
        if (contactList.Count == 0)
        {
            Console.WriteLine("Det finns inga kontakter att ta bort");
            return;
        }

        for (int i = 0; i < contactList.Count; i++)
        {
            Console.WriteLine($"{i}: {contactList[i].Name}");
        }

        while (true)
        {


            Console.Write("Ange numret på kontakten du vill ta bort: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                int index = choice;

                if (index >= 0 && index < contactList.Count)
                {
                    var removed = contactList[index];
                    contactList.RemoveAt(index);

                    Console.WriteLine($"Kontakten {removed.Name} har tagits bort");
                    break;
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


        for (int i = 0; i < contactList.Count; i++)
        {
            Console.WriteLine($"Nr {i + 1}."); //Ger varje kontakt en siffra (Förhoppningsvis rätt index som på lista??.sara)
            ShowContact(contactList[i]);
        }

    }

    public void SearchContacts()
    {

    }

    public void UpdateContact()
    {
        ShowAllContacts();

        Console.Write("\nAnge numret på kontakten du vill uppdatera: ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0 || index > contactList.Count)
        {
            Console.WriteLine("Ogiltigt val.");
            return;
        }

        var contact = contactList[index - 1];
        Console.WriteLine($"\nDu redigerar: {contact.Name}\n");

        bool done = false;
        while (!done)
        {
            Console.WriteLine("Vad vill du uppdatera?");
            Console.WriteLine("1. Namn");
            Console.WriteLine("2. Adress");
            Console.WriteLine("3. Postnummer");
            Console.WriteLine("4. Postort");
            Console.WriteLine("5. Telefonnummer");
            Console.WriteLine("6. E-post");
            Console.WriteLine("7. Avsluta uppdatering");
            Console.Write("\nVälj ett alternativ: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Console.Write($"Nytt namn (nuvarande: {contact.Name}): ");
                    string newName = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(newName))
                        contact.Name = newName;
                    break;

                case "2":
                    Console.Write($"Ny adress (nuvarande: {contact.Address}): ");
                    string newAddress = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(newAddress))
                        contact.Address = newAddress;
                    break;

                case "3":
                    Console.Write($"Nytt postnummer (nuvarande: {contact.PostalCode}): ");
                    string newPostal = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(newPostal))
                        contact.PostalCode = newPostal;
                    break;

                case "4":
                    Console.Write($"Ny postort (nuvarande: {contact.City}): ");
                    string newCity = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(newCity))
                        contact.City = newCity;
                    break;

                case "5":
                    Console.Write($"Nytt telefonnummer (nuvarande: {contact.PhoneNumber}): ");
                    string newPhoneNumber = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(newPhoneNumber))
                        contact.PhoneNumber = newPhoneNumber;
                    break;

                case "6":
                    Console.Write($"Ny e-post (nuvarande: {contact.Email}): ");
                    string newEmail = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(newEmail))
                        contact.Email = newEmail;
                    break;

                case "7":
                    done = true;
                    break;

                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }

            if (!done)
            {
                Console.WriteLine("\nFält uppdaterat! Vill du ändra något mer? (7 för att avsluta)\n");
            }
        }

        Console.WriteLine($"\n✅ Kontakt uppdaterad: {contact.Name}\n");
    }

    public void MainMenu()
    {
        ShowAllContacts(); //Visar alla kontakter direkt när programmet öppnar. 

        while (true)
        {
            Console.WriteLine("(1) Lägg till ny kontakt \n(2) Sök kontakt \n(3) Visa alla kontakter \n(4) Radera kontakt \n(5) Uppdatera kontakt\n(6) Avsluta");
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
                    DeleteContact();
                    break;
                case "5":
                    UpdateContact();
                    break;
                case "6":
                    return;

                default:
                    Console.WriteLine("Ogiltligt val, försök igen");
                    break;
            }

        }



    }

}