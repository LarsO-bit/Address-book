
public class Contact
{

    public string Name { get; set; } = "";

    public string Address { get; set; } = "";

    public string PostalCode { get; set; } = "";

    public string City { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public string Email { get; set; } = "";


    public Contact(string name, string address, string postalcode, string city, string phonenumber, string email)
    {
        Name = name;
        Address = address;
        PostalCode = postalcode;
        City = city;
        PhoneNumber = phonenumber;
        Email = email;

    }

    public string FormatForFile()
    {
        return $"{Name},{Address},{PostalCode},{City},{PhoneNumber},{Email}";

    }

    public static Contact FromFileString(string line)
    {
        
    var parts = line.Split(',');

    return new Contact(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);

    }
}