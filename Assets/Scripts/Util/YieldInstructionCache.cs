using UnityEngine;
using System.Collections.Generic;

public static class YieldInstructionCache
{
    public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
    public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();
    private static readonly Dictionary<float, WaitForSeconds> _timeInverval = new Dictionary<float, WaitForSeconds>(new FloatComparer());
    
    private class FloatComparer : IEqualityComparer<float>
    {
        bool IEqualityComparer<float>.Equals(float x_, float y_)
        {
            return x_ == y_;
        }

        int IEqualityComparer<float>.GetHashCode(float obj_)
        {
            return obj_.GetHashCode();
        }
    }

    public static WaitForSeconds WaitForSeconds(float seconds_)
    {
        WaitForSeconds waitForSeconds = null;

        if (_timeInverval.TryGetValue(seconds_, out waitForSeconds) == false)
        {
            _timeInverval.Add(seconds_, waitForSeconds = new WaitForSeconds(seconds_));
        }

        return waitForSeconds;
    }
}