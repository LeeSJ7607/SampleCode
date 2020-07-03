public interface iBindingModel { }
public interface iBindingTable { }

public static class CoreExtension
{
    public static T GetModel<T>(this iBindingModel this_) where T : Model
    {
        return ModelManager.Instance.GetModel<T>();
    }

    // public static T GetTable<T>(this iBindingTable this_) where T :
    // {
    //     
    // }
}