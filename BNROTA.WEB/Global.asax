<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        BINROTA.BUS.Mail myMail = new BINROTA.BUS.Mail();
        myMail.AddToList(ConfigurationManager.AppSettings["SMTPErrorToAddress"].ToString());

        string subject = "Binrota hata maili";

        Exception ex = Server.GetLastError().GetBaseException();
        string msgBody = ex.ToString();

        myMail.SendEmail(subject, subject, msgBody);
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
    }

    void Session_End(object sender, EventArgs e) 
    {
        if (Session["SessionRoot"] != null)
        {
            int UserID = Convert.ToInt32(((SessionRoot)Session["SessionRoot"]).UserID);
            int LoginID = BINROTA.BUS.Login.GetLoginIDByUserID(UserID);
            if (LoginID > 0)
            {
                SerializeLogin objser = new SerializeLogin();
                string result = objser.SerializeObject(Session["SessionRoot"]);
                BINROTA.BUS.Login.LoginUpdate(LoginID, result);
            }
        }
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
