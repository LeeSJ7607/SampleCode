using UnityEngine;

public sealed class BTCondition_IsNotFindTarget : iConditionTask
{
    private readonly float _distance;

    public BTCondition_IsNotFindTarget(float distance_)
    {
        _distance = distance_;
    }

    public void Reset()
    {
        
    }

    public TaskStatus Execute(iBlackBoard blackBoard_)
    {
        Debug.Log("IsNotFindTarget");

        var blackBoard = blackBoard_ as BlackBoard_AI;
        if (blackBoard == null)
        {
            return TaskStatus.Failure;
        }

        var dis = Vector3.Distance(blackBoard.EnemyTm.position, blackBoard.TargetTm.position);
        return dis > _distance ? TaskStatus.Success : TaskStatus.Failure;
    }
}