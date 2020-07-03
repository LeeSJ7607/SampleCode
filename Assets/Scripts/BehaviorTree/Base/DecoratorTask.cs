public abstract class DecoratorTask : iTask
{
    private readonly ActionTask _childActionTask;

    protected DecoratorTask(ActionTask actionTask_)
    {
        _childActionTask = actionTask_;
    }
    
    public abstract void Reset();
    public abstract TaskStatus Execute(iBlackBoard blackBoard_);
    
    protected TaskStatus ExecuteChildTask(iBlackBoard blackBoard_) => _childActionTask.Execute(blackBoard_);
}