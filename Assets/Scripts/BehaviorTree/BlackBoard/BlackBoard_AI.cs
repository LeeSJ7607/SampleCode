using UnityEngine;

public sealed class BlackBoard_AI : iBlackBoard
{
    private readonly PatrolController _patrolController;
    public PatrolController PatrolController => _patrolController;

    private readonly AttackController _attackController;
    public AttackController AttackController => _attackController;

    private readonly Enemy _enemy;
    public Enemy Enemy => _enemy;
    public Transform EnemyTm => _enemy.transform;

    private readonly Transform _targetTm;
    public Transform TargetTm => _targetTm;

    private readonly Transform[] _wayPoints;
    public Transform[] WayPoints => _wayPoints;

    public BlackBoard_AI(Enemy enemy_, Transform targetTm_, Transform[] wayPoints_)
    {
        _enemy = enemy_;
        _targetTm = targetTm_;
        _wayPoints = wayPoints_;
        
        _patrolController = new PatrolController(this);
        _attackController = new AttackController(this);
    }
}