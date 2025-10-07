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








}