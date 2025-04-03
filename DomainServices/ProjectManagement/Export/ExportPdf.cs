using Domain.ProjectManagement.Export;

namespace DomainServices.ProjectManagement.Export;

// Strategy pattern
public class ExportPdf : IExportMethod
{
    public void Export(string rapport, bool includeHeader, bool includeFooter)
    {
        Console.WriteLine("[ExportPdf] Exporting rapport to pdf... " +
                          (includeHeader ? "AvansDevops Rapport " : "") +
                          $"Content: {rapport} " +
                          (includeFooter ? "Date " + DateTime.Now.ToShortDateString() : ""));
    }
}