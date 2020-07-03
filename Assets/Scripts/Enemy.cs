using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTm;
    [SerializeField] private Transform[] _wayPoint;
    
    private void Awake()
    {
        SetBT();
    }
    
    private void SetBT()
    {
        var root = new SelectorTask();
        var seq1 = new SequenceTask();
        var seq2 = new SequenceTask();
    
        root.AddTask(seq1);
        seq1.AddTask(new BTAction_Patrol());
        seq1.AddTask(new BTDecorator_IsWeapon(new BTAction_Attack()));
        seq1.AddTask(new BTCondition_IsDeadTarget());

        seq1.AddTask(seq2);
        seq2.AddTask(new BTAction_Patrol(new BTCondition_IsNotFindTarget(20f)));
        seq2.AddTask(new BTAction_Wait());
        
        BTProcess(root, GetBlackBoard());
    }

    private async void BTProcess(CompositeTask root_, iBlackBoard blackBoard_)
    {
        while (true)
        {
            var status = root_.Execute(blackBoard_);
            if (status == TaskStatus.Success)
            {
                break;
            }
            else if (status == TaskStatus.Failure)
            {
                root_.Reset();
            }
            
            await YieldInstructionCache.WaitForEndOfFrame;
        }
    }

    private iBlackBoard GetBlackBoard()
    {
        return new BlackBoard_AI(this, _playerTm, _wayPoint);
    }
}