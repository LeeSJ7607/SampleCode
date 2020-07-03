using UnityEngine;

public sealed class UIPopup_Login : UIPopup
{
    [SerializeField] private UIButton _clickBtn;
    
    protected override void Awake()
    {
        base.Awake();

        _clickBtn.OnClick = OnLogin;
    }

    public override void Show(params object[] args_)
    {
        base.Show(args_);
    }

    private void OnLogin()
    {
        GameMain.Instance.ProcessLogin();
    }
}