public static class ObjectExtension
{
    public static bool ReferenceEquals<T>(this T this_, object target_) where T : class
    {
        return object.ReferenceEquals(this_, target_);
    }
}