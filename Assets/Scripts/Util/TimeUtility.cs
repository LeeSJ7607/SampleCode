using System;
using UniRx;

public static class TimeUtility
{
    public static void OnUpdateRemaindTime(ref ReactiveProperty<float> remaindTime_, float resetTime_, Action act_)
    {
        if (act_ == null) 
            return;

        --remaindTime_.Value;

        if (remaindTime_.Value >= 0f)
        {
            remaindTime_.Value = resetTime_;
            
            act_.Invoke();
        }
    }
}