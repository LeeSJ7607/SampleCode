using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public static BaseScene Instance { get; protected set; }
    private readonly Stack<UIView> _viewStack = new Stack<UIView>();
    private UIContainer _uiContainer;

    protected virtual void Awake()
    {
        _uiContainer = gameObject.AddComponent<UIContainer>();
    }

    protected virtual void Start()
    {
        
    }

    private void Update()
    {
        OnUpdate();
    }
    
    protected virtual void OnUpdate()
    {
        OnEscapeKey();
    }
    
    private void OnEscapeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PopView();
        }
    }

    public void ShowView<T>(params object[] args_) where T : UIView
    {
        _uiContainer.GetView<T>((view_) =>
        {
            view_.Show(args_);
            PushView(view_);
        });
    }

    private void PushView<T>(T view_) where T : UIView
    {
        _viewStack.Push(view_);
    }

    private void PopView()
    {
        if (_viewStack.isEmpty())
        {
            Debug.Log("Quit");
        }
        else
        {
            var view = _viewStack.Pop();
            view.Hide();
        }
    }
}