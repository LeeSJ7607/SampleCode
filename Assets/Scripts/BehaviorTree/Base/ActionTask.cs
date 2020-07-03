public abstract class ActionTask : iTask
{
    private readonly iConditionTask _conditionTask;

    protected ActionTask(iConditionTask conditionTask_ = null)
    {
        _conditionTask = conditionTask_;
    }
    
    public abstract void Reset();
    public abstract TaskStatus Execute(iBlackBoard blackBoard_);

    protected TaskStatus IsConditionTask(iBlackBoard blackBoard_) => _conditionTask?.Execute(blackBoard_) ?? TaskStatus.Failure;
}