using UnityEngine;

public sealed class LogManager : Singleton<LogManager>
{
    public void LogError(string msg_)
    {
        Debug.LogError(msg_);

        EMailManager.Instance.Sender(new EMailManager.SenderData(msg_));
    }

    public void LogError(string msg_, string subject_)
    {
        Debug.LogError(msg_ + ", " + subject_);

        EMailManager.Instance.Sender(new EMailManager.SenderData(msg_, subject_));
    }

    public void LogError(string msg_, string subject_, string attachmentPath_)
    {
        Debug.LogError(msg_ + ", " + subject_ + ", " + attachmentPath_);
        
        EMailManager.Instance.Sender(new EMailManager.SenderData(msg_, subject_, attachmentPath_));
    }
}