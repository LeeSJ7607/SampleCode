using UnityEngine;

public sealed class BTAction_Patrol : ActionTask
{
    public BTAction_Patrol(iConditionTask conditionTask_ = null) : base(conditionTask_)
    {
        
    }

    public override void Reset()
    {
        
    }

    public override TaskStatus Execute(iBlackBoard blackBoard_)
    {
        Debug.Log("Patrol");

        var blackBoard = blackBoard_ as BlackBoard_AI;
        if (blackBoard == null)
        {
            return TaskStatus.Failure;
        }

        var patrolCtrl = blackBoard.PatrolController;
        if (patrolCtrl.TryPatrol() == false)
        {
            return TaskStatus.Failure;
        }

        if (IsConditionTask(blackBoard_) == TaskStatus.Success)
        {
            return TaskStatus.Success;
        }
        
        return patrolCtrl.TryEndPatrol() ? TaskStatus.Success : TaskStatus.Running;
    }
}