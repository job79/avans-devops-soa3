namespace Domain.ProjectManagement.Export;

// Strategy pattern
public interface IExportMethod
{
    public void Export(string rapport, bool includeHeader, bool includeFooter);
}