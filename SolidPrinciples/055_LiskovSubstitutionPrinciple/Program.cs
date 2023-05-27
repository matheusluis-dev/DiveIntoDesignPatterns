// Liskov Substitution Principle
// Page 55
//
// ==================================================
//
// The Liskov Substitution Principle (LSP) is a principle in object-oriented programming that states 
// that objects of a superclass should be replaceable with objects of its subclasses without altering the
// correctness of the program. In simpler terms, if a program is designed to work with a certain type of object, 
// it should also work correctly with any subtype of that object. LSP ensures that subclasses adhere to the same 
// contract as their superclasses, preventing unexpected behavior or violations of expected behavior. By following LSP, 
// developers can create more flexible, modular, and interchangeable code, promoting code reuse and maintainability.

Document doc1 = new("doc1Data", "doc1.txt");
WritableDocument doc2 = new("doc2Data", "doc2.txt");

Project project = new(new List<Document> { doc1, doc2 }, new List<WritableDocument> { doc2 });
project.SaveAll();
project.OpenAll();











class Document
{
    public string Data { get; set; }
    public string FileName { get; set; }

    public Document(string data, string fileName)
    {
        Data = data;
        FileName = fileName;
    }

    public void Open()
    {
        Console.WriteLine($"Opening file: {FileName}...");
        Console.WriteLine(Data);
        Console.WriteLine(new string('=', 50));
    }
}

class WritableDocument : Document
{
    public WritableDocument(string data, string fileName) : base(data, fileName)
    {
        Data = data;
        FileName = fileName;
    }

    public void Save()
    {
        Console.WriteLine($"Saving file... {FileName}");
        Console.WriteLine(new string('=', 50));
    }
}

class Project
{
    public List<Document> AllDocs;
    public List<WritableDocument> WritableDocs;

    public Project(List<Document> allDocs, List<WritableDocument> writableDocs)
    {
        AllDocs = allDocs;
        WritableDocs = writableDocs;
    }

    public void OpenAll()
    {
        foreach (var doc in AllDocs)
        {
            doc.Open();
        }
    }

    public void SaveAll()
    {
        foreach (var writableDoc in WritableDocs)
        {
            writableDoc.Save();
        }
    }
}