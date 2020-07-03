public enum TaskStatus
{
    Success,
    Failure,
    Running
}

public interface iTask
{
    void Reset();
    TaskStatus Execute(iBlackBoard blackBoard_);
}