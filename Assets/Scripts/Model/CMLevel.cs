using System;
using System.Linq;
using UniRx;

public interface iLevelData
{
    IReadOnlyReactiveProperty<int> Level { get; }
    IReadOnlyReactiveProperty<long> Exp { get; }
}

public sealed class CMLevel : Model, iLevelData
{
    private ReactiveProperty<int> _level = new ReactiveProperty<int>();
    IReadOnlyReactiveProperty<int> iLevelData.Level => _level;

    private ReactiveProperty<long> _exp = new ReactiveProperty<long>();
    IReadOnlyReactiveProperty<long> iLevelData.Exp => _exp;

    private readonly TableLevel _tableLevel;
    
    private int _maxLevel => _tableLevel.Datas[_tableLevel.Datas.Count - 1].Level;
    private long _maxExp => _tableLevel.Datas.Sum(_ => _.MaxExp);

    public CMLevel(int level_, TableLevel tableLevel_)
    {
        _level.Value = level_;
        _tableLevel = tableLevel_;
    }

    public void AddExp(long exp_)
    {
        var totalExp = _exp.Value + exp_;
        var remaindTotalExp = totalExp;
        var level = 0;
        long accumExp = 0;

        var tableDataList = _tableLevel.Datas;
        foreach (var tableData in tableDataList)
        {
            accumExp += tableData.MaxExp;

            var isLevelUp = totalExp >= accumExp;
            level = isLevelUp ? ++level : level;
            remaindTotalExp = isLevelUp ? remaindTotalExp - tableData.MaxExp : remaindTotalExp;

            if (accumExp >= totalExp)
                break;
        }
        
        _level.Value = Math.Min(_maxLevel, _level.Value + level);
        _exp.Value = _level.Value >= _maxLevel ? 0 : remaindTotalExp;
    }
}