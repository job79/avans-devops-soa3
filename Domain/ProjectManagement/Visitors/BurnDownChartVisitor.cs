using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Export;

namespace Domain.ProjectManagement.Visitors;

public class BurnDownChartVisitor : Visitor
{
    private int _totalStoryPoints = 0;
    private readonly IExportMethod _exportMethod;
    
    public BurnDownChartVisitor(IExportMethod exportMethod)
    {
        this._exportMethod = exportMethod;
    }
    
    public new void VisitBacklogItem(BacklogItem backlogItem)
    {
        _totalStoryPoints += backlogItem.StoryPoints;
    }

    public void Export()
    {
        this._exportMethod.Export("burndown chart of story points");
    }
}