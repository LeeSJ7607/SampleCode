using System;
using System.Linq;
using UniRx;

public interface iTicketData
{
    IReadOnlyReactiveProperty<int> CurTicket { get; }
    IReadOnlyReactiveProperty<float> RemaindTime { get; }
    IReadOnlyReactiveProperty<int> ChargeCnt { get; }
}

public sealed class CMTicket : Model, iTicketData, iBindingModel
{
    private ReactiveProperty<int> _curTicket = new ReactiveProperty<int>(); 
    IReadOnlyReactiveProperty<int> iTicketData.CurTicket => _curTicket;
    
    private ReactiveProperty<float> _remaindTime = new ReactiveProperty<float>(); 
    IReadOnlyReactiveProperty<float> iTicketData.RemaindTime => _remaindTime;
    
    private ReactiveProperty<int> _chargeCnt = new ReactiveProperty<int>(); 
    IReadOnlyReactiveProperty<int> iTicketData.ChargeCnt => _chargeCnt;
    
    private readonly TableTicket _tableTicket;

    private int _maxTicket;

    public CMTicket(int ticket_, 
        float remaindTime_,
        int chargeCnt_,
        TableTicket tableTicket_)
    {
        _curTicket.Value = ticket_;
        _remaindTime.Value = remaindTime_;
        _chargeCnt.Value = chargeCnt_;
        _tableTicket = tableTicket_;

        var userLevel = this.GetModel<CMUser>().LevelData.Level;
        userLevel.SubscribeAndActionInvoke(SetMaxTicket, userLevel.Value).AddTo(_disposable);
        
        Observable.Interval(TimeSpan.FromSeconds(1f)).Subscribe(_ => OnUpdateRemaindTime()).AddTo(_disposable);
    }

    private void SetMaxTicket(int userLevel_) => _maxTicket = _tableTicket.Datas.Where(_ => _.Level == userLevel_).FirstOrDefault()?.Ticket ?? 0;

    private void OnUpdateRemaindTime()
    {
        if (_maxTicket <= _curTicket.Value) 
            return;
        
        const float ResetTime = 60f; // 임시.
        
        TimeUtility.OnUpdateRemaindTime(ref _remaindTime, ResetTime, () => { _curTicket.Value += 1; });
    }
}