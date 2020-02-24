using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

public class EmailSender
{
    //从Web.config中的<appSettings>配置节获取相应的键值
    private string mailFromAddress = ConfigurationManager.AppSettings["MailFromAddress"];
    private bool useSsl = bool.Parse(ConfigurationManager.AppSettings["UseSsl"]);
    private string userName = ConfigurationManager.AppSettings["UserName"];
    private string password = ConfigurationManager.AppSettings["Password"];
    private string serverName = ConfigurationManager.AppSettings["ServerName"];
    private int serverPort = int.Parse(ConfigurationManager.AppSettings["ServerPort"]);
                                        
    /// <summary>
    /// 自定义方法，根据设置的SMTP服务器名、端口号、账户名、授权码等信息发送给定发件人邮箱、收件人邮箱、电子邮件主题、电子邮件内容等信息的邮件
    /// </summary>
    public void PsdSend(string mailToAddress, string newPwd)
    {
        //新建SmtpClient类实例smtpClient对象，using语句块结束时释放smtpClient对象
        using (var smtpClient = new SmtpClient())
        {
            //设置是否使用SSL协议连接
            smtpClient.EnableSsl = useSsl;
            //设置SMTP服务器名
            smtpClient.Host = serverName;
            //设置SMTP服务器的端口号
            smtpClient.Port = serverPort;
            //设置SMTP服务器发送邮件的凭据（用户名和授权码)
            smtpClient.Credentials = new NetworkCredential(userName, password);
            string body = "您登录BookShop的密码已重置为：" + newPwd;
            MailMessage mailMessage = new MailMessage(
                                   mailFromAddress,   // 发件人邮箱
                                   mailToAddress,     // 收件人邮箱
                                   "BookShop用户密码重置",  // 电子邮件主题
                                   body);  // 电子邮件内容
                                           //调用smtpClient对象的Send()方法发送邮件
            smtpClient.Send(mailMessage);
        }
    }

    //验证码发送
    public string VerificationCodeSend(string mailToAddress)
    {
        //伪随机生成6位数字验证码
        Random rand = new Random();
        string code = rand.Next(100000, 999999).ToString();

        //新建SmtpClient类实例smtpClient对象，using语句块结束时释放smtpClient对象
        using (var smtpClient = new SmtpClient())
        {
            //设置是否使用SSL协议连接
            smtpClient.EnableSsl = useSsl;
            //设置SMTP服务器名
            smtpClient.Host = serverName;
            //设置SMTP服务器的端口号
            smtpClient.Port = serverPort;
            //设置SMTP服务器发送邮件的凭据（用户名和授权码)
            smtpClient.Credentials = new NetworkCredential(userName, password);
            string body = "你的验证码为：" + code+" ，用于进行密码重置验证，请勿转发！";
            MailMessage mailMessage = new MailMessage(
                                   mailFromAddress,   // 发件人邮箱
                                   mailToAddress,     // 收件人邮箱
                                   "BookShop验证码",  // 电子邮件主题
                                   body);  // 电子邮件内容
            //调用smtpClient对象的Send()方法发送邮件
            smtpClient.Send(mailMessage);
        }
        return code;
    }

}
