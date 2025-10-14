using System;

class AddressBook
{
    List<Contact> contactList = new(); //Skapa ny lista 
    private readonly FileManager fileManager;
    public AddressBook()
    {
        fileManager = new FileManager("Addressbook.txt");
        LoadContactFile();
    }

    private string ReadLineWithEscapeToMainMenu()
    {
        var input = new System.Text.StringBuilder();    //Skapa en StringBuilder för att lagra inmatningen

        while (true)
        {
            var key = Console.ReadKey(intercept: true); //Läser en tangenttryckning utan att visa den i konsolen

            if (key.Key == ConsoleKey.Enter)            //Om Enter trycks, returnera den insamlade strängen
            {
                Console.WriteLine();
                return input.ToString();
            }
            else if (key.Key == ConsoleKey.Backspace)   //Om Backspace trycks, ta bort sista tecknet från strängen och uppdatera konsolen
            {
                if (input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            else if (key.Key == ConsoleKey.Escape)       //Om Escape trycks, kasta ett undantag för att indikera avbrott
            {
                throw new OperationCanceledException("Användaren avbröt inmatningen.");
            }
            else
            {
                input.Append(key.KeyChar);
                Console.Write(key.KeyChar);
            }
        }
    }

    public void AddContact()
    {
        try
        {
            Console.Write("Namn: ");
            string name = (ReadLineWithEscapeToMainMenu() ?? "").Trim();

            Console.Write("Adress: ");
            string address = (ReadLineWithEscapeToMainMenu() ?? "").Trim();

            Console.Write("Postnummer: ");
            string postalcode = (ReadLineWithEscapeToMainMenu() ?? "").Trim();

            Console.Write("Postort: ");
            string city = (ReadLineWithEscapeToMainMenu() ?? "").Trim();

            Console.Write("Telefonnummer: ");
            string phone = (ReadLineWithEscapeToMainMenu() ?? "").Trim();

            Console.Write("Email: ");
            string email = (ReadLineWithEscapeToMainMenu() ?? "").Trim();

        var contact = new Contact(name, address, postalcode, city, phone, email); //Skapar ett objekt av klassen Contact
        contactList.Add(contact); //Lägger till contacten i listan 

        Console.WriteLine($"Ny kontakt sparad: {contact.Name}.\n");
        SaveContactsToFile();
    }

            Console.WriteLine($"\n Ny kontakt sparad: {contact.Name}.\n");
            SaveContactsToFile();
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\n Tillbaka till huvudmenyn.\n");
            return; // Simply return to main menu
        }
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

        for (int i = 0; i < contactList.Count; i++)
        {
            Console.WriteLine($"\n===== Kontakt nr: {i + 1} =====");
            ShowContact(contactList[i]);
        }
    }

    public void LoadContactFile()
    {
        contactList = new List<Contact>();
        List<string> lines = fileManager.ReadLinesFromFile();

        foreach (var line in lines)
        {
            Contact contact = Contact.FromFileString(line);
            contactList.Add(contact);
        }

    }

    public void DeleteContact()
    {
        try
        {
            if (contactList.Count == 0)
        {
            Console.WriteLine("Det finns inga kontakter att ta bort");
            return;
        }

        for (int i = 0; i < contactList.Count; i++)
        {
            ShowAllContacts();
        }

        while (true)
        {


            Console.Write("Ange numret på kontakten du vill ta bort: ");

            if (int.TryParse(ReadLineWithEscapeToMainMenu(), out int choice))
            {
                int index = choice - 1;

                if (index >= 0 && index < contactList.Count)
                {
                    var removed = contactList[index];
                    contactList.RemoveAt(index);
                    SaveContactsToFile();

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
            Console.WriteLine($"\n===== Kontakt nr: {i + 1} =====");
            ShowContact(contactList[i]);
        }
        SaveContactsToFile();
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\n Tillbaka till huvudmenyn.\n");
            return; // Simply return to main menu
        }
        

    }

    public void SearchContacts()
    {
        try
        {
            Console.Write("Sök kontakt: ");
        string searchWord = (ReadLineWithEscapeToMainMenu() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(searchWord))
        {
            Console.WriteLine("Du har gjort en felaktig inmatning. Försök igen.");
            return;
        }

        var result = contactList
            .Select((Contact, OriginalIndex) => new { Contact, OriginalIndex })
            .Where(x =>
                x.Contact.Name.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
                x.Contact.Address.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
                x.Contact.PostalCode.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
                x.Contact.City.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
                x.Contact.PhoneNumber.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
                x.Contact.Email.Contains(searchWord, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (result.Count == 0)
        {
            Console.WriteLine("Du har inga kontakter att visa.");
            return;
        }

        Console.WriteLine($"\nTräffar: {result.Count}\n");

        foreach (var foundContact in result)
        {
            Console.WriteLine($"\n===== Kontakt nr: {foundContact.OriginalIndex + 1} =====");
            ShowContact(foundContact.Contact);
        }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\n Tillbaka till huvudmenyn.\n");
            return; // Simply return to main menu
        }
        
        }

    public void UpdateContact()
    {
        try
        {
            ShowAllContacts();

        Console.Write("\nAnge numret på kontakten du vill uppdatera: ");
        if (!int.TryParse(ReadLineWithEscapeToMainMenu(), out int index) || index <= 0 || index > contactList.Count)
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

            string choice =ReadLineWithEscapeToMainMenu()?? "";

            switch (choice)
            {
                case "1":
                    Console.Write($"Nytt namn (nuvarande: {contact.Name}): ");
                    string newName =ReadLineWithEscapeToMainMenu().Trim();
                    if (!string.IsNullOrEmpty(newName))
                        contact.Name = newName;
                    break;

                case "2":
                    Console.Write($"Ny adress (nuvarande: {contact.Address}): ");
                    string newAddress =ReadLineWithEscapeToMainMenu().Trim();
                    if (!string.IsNullOrEmpty(newAddress))
                        contact.Address = newAddress;
                    break;

                case "3":
                    Console.Write($"Nytt postnummer (nuvarande: {contact.PostalCode}): ");
                    string newPostal =ReadLineWithEscapeToMainMenu().Trim();
                    if (!string.IsNullOrEmpty(newPostal))
                        contact.PostalCode = newPostal;
                    break;

                case "4":
                    Console.Write($"Ny postort (nuvarande: {contact.City}): ");
                    string newCity =ReadLineWithEscapeToMainMenu().Trim();
                    if (!string.IsNullOrEmpty(newCity))
                        contact.City = newCity;
                    break;

                case "5":
                    Console.Write($"Nytt telefonnummer (nuvarande: {contact.PhoneNumber}): ");
                    string newPhoneNumber =ReadLineWithEscapeToMainMenu().Trim();
                    if (!string.IsNullOrEmpty(newPhoneNumber))
                        contact.PhoneNumber = newPhoneNumber;
                    break;

                case "6":
                    Console.Write($"Ny e-post (nuvarande: {contact.Email}): ");
                    string newEmail =ReadLineWithEscapeToMainMenu().Trim();
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

        Console.WriteLine($"\n Kontakt uppdaterad: {contact.Name}\n");
        SaveContactsToFile();
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\n Tillbaka till huvudmenyn.\n");
            return; // Simply return to main menu
        }
        
    }

    public void SaveContactsToFile() // Sparar alla kontakter i listan till filen, anropas när en ny kontakt skapas, tas bort eller uppdateras.
    {
        var lines = contactList.Select(c => c.FormatForFile());
        fileManager.WriteLinesToFile(lines);
    }

    public void MainMenu()
    {


        while (true)
        {
            Console.WriteLine("(1) Lägg till ny kontakt \n(2) Sök kontakt \n(3) Visa alla kontakter \n(4) Radera kontakt \n(5) Uppdatera kontakt\n(6) Avsluta \nTryck på Escape för att återgå till huvudmenyn när som helst.");
            string val =ReadLineWithEscapeToMainMenu()?? "";

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