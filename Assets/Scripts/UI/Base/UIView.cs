public class UIView : UIBase
{
    public virtual void Show(params object[] args_)
    {
        gameObject.Show();
    }
    
    public virtual void Hide()
    {
        gameObject.Hide();
    }

    protected bool IsParams(params object[] args_) => !args_.ReferenceEquals(null) || args_.Length > 0;
}