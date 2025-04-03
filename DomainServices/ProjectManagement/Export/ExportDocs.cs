using Domain.ProjectManagement.Export;

namespace DomainServices.ProjectManagement.Export;

// Strategy pattern
public class ExportDocs : IExportMethod
{
    public void Export(string rapport, bool includeHeader, bool includeFooter)
    {
        Console.WriteLine("[ExportDocs] Exporting rapport to docs... " +
                          (includeHeader ? "AvansDevops Rapport " : "") +
                          $"Content: {rapport} " +
                          (includeFooter ? "Date " + DateTime.Now.ToShortDateString() : ""));
    }
}