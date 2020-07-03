public sealed class LoginScene : BaseScene
{
    protected override void Awake()
    {
        base.Awake();
        
        Instance = this;
    }

    protected override void Start()
    {
        base.Start();
        
        ShowView<UIPopup_Login>();
    }
}