using UnityEngine;

public sealed class BTDecorator_IsWeapon : DecoratorTask
{
    public BTDecorator_IsWeapon(ActionTask actionTask_) : base(actionTask_)
    {
        
    }

    public override void Reset()
    {
        
    }

    public override TaskStatus Execute(iBlackBoard blackBoard_)
    {
        Debug.Log("IsWeapon");
        
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

        return ExecuteChildTask(blackBoard_);
    }
}