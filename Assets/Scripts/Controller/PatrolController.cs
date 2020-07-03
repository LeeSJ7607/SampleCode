using UnityEngine;
using Random = UnityEngine.Random;

public sealed class PatrolController : iController
{
    private const float SPEED = 10f;

    private readonly BlackBoard_AI _blackBoard;
    private int _wayPointIdx;

    public PatrolController(BlackBoard_AI blackBoard_)
    {
        _blackBoard = blackBoard_;

        SetWayPointIdx();
    }

    public bool TryPatrol()
    {
        // 주체가 죽었으면 패스.
        //return false;

        return true;
    }

    public bool TryEndPatrol()
    {
        Patrol();

        return IsFindTarget();
    }

    private void Patrol()
    {
        var wayPoint = _blackBoard.WayPoints[_wayPointIdx];
        var dir = Quaternion.LookRotation(wayPoint.position - _blackBoard.EnemyTm.position);
        _blackBoard.EnemyTm.rotation = Quaternion.Slerp(_blackBoard.EnemyTm.rotation, dir, SPEED * Time.deltaTime);
        _blackBoard.EnemyTm.Translate(Vector3.forward * (SPEED * Time.deltaTime));
        
        if (Vector3.Distance(_blackBoard.EnemyTm.position, wayPoint.position) < 3f)
        {
            SetWayPointIdx();
        }
    }

    private void SetWayPointIdx() => _wayPointIdx = Random.Range(0, _blackBoard.WayPoints.Length);

    private bool IsFindTarget()
    {
        var activeTarget = _blackBoard.TargetTm.gameObject.activeSelf;
        var dis = Vector3.Distance(_blackBoard.EnemyTm.position, _blackBoard.TargetTm.position);

        return activeTarget && dis < 3f;
    }
}