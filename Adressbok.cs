using System;

class Adressbok
{

    List<Contact> contactList = new(); //Skapa ny lista med objekt av klassen som Andres skapar? Gissar "Contact"

    public void AddContact()
    {
        Contact contact = new(); //Skapar ett nytt objekt av klassen

        Console.WriteLine("Lägg till en kontakt!");

        Console.Write("Namn: ");
        Contact.Namn = Console.ReadLine() ?? "";

        Console.Write("Efternamn: ");
        Contact.Efternamn = Console.ReadLine() ?? "";

        Console.Write("Adress: ");
        Contact.Adress = Console.ReadLine() ?? "";

        Console.Write("Postort: ");
        Contact.Postort = Console.ReadLine() ?? "";

        Console.Write("Postnummer: ");
        Contact.Postnr = Console.ReadLine() ?? "";

        Console.Write("Email: ");
        Contact.Email = Console.ReadLine() ?? "";

        Console.Write("Telefonnummer: ");
        Contact.Telefonnummer = Console.ReadLine() ?? "";

        Console.WriteLine($"Ny kontakt sparad, {*Förnamn och efternamn här*}.\n"); //Lägg till förnamn efternamn
        contactList.Add(contact);

    }

    public void LoadContacts(Contact contact)
    {
        Console.WriteLine
        (@$"
        Namn: {contact.Förnamn} Efternamn: {contact.Efternamn}
        Adress: {contact.Adress}
        Postort: {contact.Postort}
        Postnummer: {contact.Postnr}
        Email: {contact.Email}
        Telefonnummer: {contact.Telefonnummer}
        ");
    }


}