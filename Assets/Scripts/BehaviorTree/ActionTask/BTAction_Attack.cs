using UnityEngine;

public sealed class BTAction_Attack : ActionTask
{
    public override void Reset()
    {
        
    }

    public override TaskStatus Execute(iBlackBoard blackBoard_)
    {
        Debug.Log("Attack");
        
        var blackBoard = blackBoard_ as BlackBoard_AI;
        if (blackBoard == null)
        {
            return TaskStatus.Failure;
        }

        var attackCtrl = blackBoard.AttackController;
        if (attackCtrl.TryAttack() == false)
        {
            return TaskStatus.Failure;
        }

        if (IsConditionTask(blackBoard_) == TaskStatus.Success)
        {
            return TaskStatus.Success;
        }

        return attackCtrl.TryEndAttack() ? TaskStatus.Success : TaskStatus.Running;
    }
}