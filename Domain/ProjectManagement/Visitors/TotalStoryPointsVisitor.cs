using Domain.ProjectManagement.BacklogItems;
using Domain.ProjectManagement.Export;

namespace Domain.ProjectManagement.Visitors;

public class TotalStoryPointsVisitor : Visitor
{
    private int _totalStoryPoints = 0;
    private readonly IExportMethod _exportMethod;
    
    public TotalStoryPointsVisitor(IExportMethod exportMethod)
    {
        this._exportMethod = exportMethod;
    }
    
    public int GetTotalStoryPoints()
    {
        return _totalStoryPoints;
    }
    
    public new void VisitBacklogItem(BacklogItem backlogItem)
    {
        _totalStoryPoints += backlogItem.StoryPoints;
    }
    
    public void Export()
    {
        this._exportMethod.Export($"total story points: {_totalStoryPoints}");
    }
}