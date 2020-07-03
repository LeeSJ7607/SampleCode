using System.Collections.Generic;

public abstract class CompositeTask : iTask
{
    protected readonly List<iTask> _tasks = new List<iTask>();
    protected int _taskIdx;

    public abstract TaskStatus Execute(iBlackBoard blackBoard_);

    public void Reset()
    {
        _taskIdx = 0;

        foreach (var task in _tasks)
        {
            task.Reset();
        }
    }

    public void AddTask(iTask task_)
    {
        _tasks.Add(task_);
    }
}