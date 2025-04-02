namespace Domain.SourceManagement;

public class File
{
    public string Path { get; }
    public string Data { get; }

    public File(string path, string data)
    {
        this.Path = path;
        this.Data = data;
    }
}