using UnityEngine;

public sealed class BTAction_Wait : ActionTask
{ 
    public override void Reset()
    {
        
    }

    public override TaskStatus Execute(iBlackBoard blackBoard_)
    {
        Debug.Log("Wait");
        
        var blackBoard = blackBoard_ as BlackBoard_AI;
        if (blackBoard == null)
        {
            return TaskStatus.Failure;
        }

        return TaskStatus.Success;
    }
}