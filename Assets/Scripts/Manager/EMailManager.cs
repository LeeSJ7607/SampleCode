using System;
using System.Net;
using System.Net.Mail;
using UnityEngine;

public sealed class EMailManager : Singleton<EMailManager>
{
   public sealed class SenderData
   {
      public string Body { get; }
      public string Subject { get; }
      public string AttachmentPath { get; }

      public SenderData(string body_, string subject_ = "Error Message", string attachmentPath_ = "")
      {
         Body = body_;
         Subject = subject_;
         AttachmentPath = attachmentPath_;
      }
   }
   
   private const string ProjectName = "LeeSJ";
   private const string EMailAddress = "gkqxhq324456@naver.com";
   private const string Password = "gozld132";
   private const string Host_Naver = "smtp.naver.com";
   private const string Host_Google = "smtp.gmail.com";
   private const int Port = 587;

   // 받는 이메일 주소.
   private static readonly string[] Receive_EMailAddress = new[]
   {
      "gkqxhq324456@naver.com"
   };

   // 참조 이메일 주소.
   private static readonly string[] Reference_EMailAddress = new[]
   {
      "gkqxhq324456@naver.com"
   };

   public void Sender(SenderData senderData_)
   {
      try
      {
         var smtpClient = new SmtpClient(Host_Naver, Port);
         smtpClient.Credentials = new NetworkCredential(EMailAddress, Password);
         smtpClient.EnableSsl = true;
         smtpClient.Send(GetMailMessage(senderData_));
      }
      catch (Exception e)
      {
         Debug.LogError(e.Message);
      }
   }

   private MailMessage GetMailMessage(SenderData senderData_)
   {
      var mail = new MailMessage();  
      mail.From = new MailAddress(EMailAddress, ProjectName);
      
      foreach (var address in Receive_EMailAddress)
      {
         mail.To.Add(address);
      }

      foreach (var address in Reference_EMailAddress)
      {
         mail.CC.Add(address);
      }

      mail.Subject = senderData_.Subject;
      mail.Body = senderData_.Body;

      if (senderData_.AttachmentPath.Equals(string.Empty) == false)
      {
         mail.Attachments.Add(new Attachment(senderData_.AttachmentPath));
      }

      return mail;
   }
}