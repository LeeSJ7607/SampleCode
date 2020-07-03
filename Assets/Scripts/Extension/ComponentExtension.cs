using UnityEngine;

public static class ComponentExtension
{
    public static void Show(this GameObject this_)
    {
        if (this_.ReferenceEquals(null) == false)
        {
            this_.SetActive(true);
        }
    }

    public static void Hide(this GameObject this_)
    {
        if (this_.ReferenceEquals(null) == false)
        {
            this_.SetActive(false);
        }
    }
}