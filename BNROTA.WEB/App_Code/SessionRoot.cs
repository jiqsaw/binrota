using System;
using System.Data;
using System.Collections;


public class SessionRoot
{
    private int m_intUserID;
    private string m_FullName;
    private string m_NickName;
    private int m_LoginType;

    public SessionRoot()
    {
        this.m_intUserID = -1;
    }

    public SessionRoot(int UserID)
    {
        this.m_intUserID = UserID;
    }

    public string FullName
    {
        get { return m_FullName; }
        set { m_FullName = value;}
    }

    public string NickName
    {
        get { return m_NickName; }
        set { m_NickName = value; }
    }

    public int LoginType
    {
        get { return m_LoginType; }
        set { m_LoginType = value; }
    }

    public int UserID
    {
        get { return m_intUserID; }
        set { m_intUserID = value; }
    }
}
