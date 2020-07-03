public sealed class SequenceTask : CompositeTask
{
    public override TaskStatus Execute(iBlackBoard blackBoard_)
    {
        while (_taskIdx < _tasks.Count)
        {
            var task = _tasks[_taskIdx];
            var status = task.Execute(blackBoard_);

            if (status != TaskStatus.Success)
            {
                return status;
            }
            
            _taskIdx++;
        }

        return TaskStatus.Success;
    }
}