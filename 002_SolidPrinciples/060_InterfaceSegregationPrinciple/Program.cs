// Interface Segregation Principle
// Page 60
//
// ==================================================
//
// The Interface Segregation Principle (ISP) is a principle in software development that 
// emphasizes the importance of designing small, cohesive interfaces rather than large, monolithic ones. 
// It states that clients should not be forced to depend on interfaces they do not use. In other words, 
// classes should have specific interfaces tailored to their needs instead of being forced to implement irrelevant methods. 
// By adhering to ISP, we prevent interface pollution and the coupling of unrelated components. 
// It promotes code decoupling, modularity, and flexibility, allowing clients to depend only on the interfaces that are relevant 
// to their specific requirements, resulting in more maintainable and scalable systems.

Amazon amazon = new();
amazon.CreateServer("CreateServer");
amazon.ListServers("ListServers");
amazon.GetCDNAddress();
amazon.StoreFile("Name");
amazon.GetFile("Name");

Dropbox dropbox = new();
dropbox.StoreFile("Name");
dropbox.GetFile("Name");











interface ICloudHostingProvider
{
    void CreateServer(string region);
    void ListServers(string region);
}

interface ICDNProvider
{
    void GetCDNAddress();
}

interface ICloudStorageProvider
{
    void StoreFile(string name);
    void GetFile(string name);
}

class Amazon : ICloudHostingProvider, ICDNProvider, ICloudStorageProvider
{
    public void CreateServer(string region)
    {
        //
    }

    public void ListServers(string region)
    {
        //
    }

    public void GetCDNAddress()
    {
        //
    }

    public void StoreFile(string name)
    {
        //
    }

    public void GetFile(string name)
    {
        //
    }
}

class Dropbox : ICloudStorageProvider{
    public void StoreFile(string name)
    {
        //
    }

    public void GetFile(string name)
    {
        //
    }
}