public sealed class SelectorTask : CompositeTask
{
    public override TaskStatus Execute(iBlackBoard blackBoard_)
    {
        while (_taskIdx < _tasks.Count)
        {
            var task = _tasks[_taskIdx];
            var status = task.Execute(blackBoard_);

            if (status != TaskStatus.Failure)
            {
                return status;
            }

            _taskIdx++;
        }

        return TaskStatus.Failure;
    }
}