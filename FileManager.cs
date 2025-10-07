public class FileManager
{
    private readonly string _filePath;

    public FileManager(string filePath)
    {
        _filePath = filePath;                           // Constructor to initialize file path
    }

    public List<string> ReadLinesFromFile()
    {
        if (!File.Exists(_filePath))                    // Check if file exists, if not, return empty list
            return new List<string>();

        return File.ReadAllLines(_filePath).ToList();
    }

    public void WriteLinesToFile(IEnumerable<string> lines)
    {
        File.WriteAllLines(_filePath, lines);
    }
}