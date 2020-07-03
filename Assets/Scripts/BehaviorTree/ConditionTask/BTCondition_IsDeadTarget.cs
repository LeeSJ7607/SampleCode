using UnityEngine;

public sealed class BTCondition_IsDeadTarget : iConditionTask
{
    public void Reset()
    {
        
    }
    
    public TaskStatus Execute(iBlackBoard blackBoard_)
    {
        Debug.Log("IsDeadTarget");
        
        var blackBoard = blackBoard_ as BlackBoard_AI;
        if (blackBoard == null)
        {
            return TaskStatus.Failure;
        }

        return !blackBoard.TargetTm.gameObject.activeSelf ? TaskStatus.Success : TaskStatus.Failure;
    }
}