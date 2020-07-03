public sealed class AttackController : iController
{
    private readonly BlackBoard_AI _blackBoard;

    public AttackController(BlackBoard_AI blackBoard_)
    {
        _blackBoard = blackBoard_;
    }

    public bool TryAttack()
    {
        // 타겟이 사정거리 안에 들어오지 않았으면 패스.
        //return false;
        
        return true;
    }

    public bool TryEndAttack()
    {
        Attack();

        return IsDeadTarget();
    }

    private void Attack() => _blackBoard.TargetTm.gameObject.SetActive(false);

    private bool IsDeadTarget() => !_blackBoard.TargetTm.gameObject.activeSelf;
}