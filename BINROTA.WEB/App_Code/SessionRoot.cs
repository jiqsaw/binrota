using System;
using System.Data;
using System.Collections;


public class SessionRoot
{
    private int m_intUserID;
    private string m_FullName;
    private int m_LoginType;

    public SessionRoot(int UserID)
    {
        this.m_intUserID = UserID;
    }

    public string FullName
    {
        get { return m_FullName; }
        set { m_FullName = value; }
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
