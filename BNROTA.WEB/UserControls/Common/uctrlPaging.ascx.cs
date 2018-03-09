using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControls_uctrlPaging : System.Web.UI.UserControl
{
    #region Properties
    public int CurrentPage
    {
        get
        {
            return (ViewState["CurrentPage"] ==null ? 1 : int.Parse(ViewState["CurrentPage"].ToString()));
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    public int PageSize
    {
        get
        {
            return (ViewState["PageSize"] ==null ? 10 : int.Parse(ViewState["PageSize"].ToString()));
        }
        set
        {
            ViewState["PageSize"] = value;
        }
    }
    public int RecordCount
    {
        get
        {
            return (ViewState["RecordCount"] ==null ? 0 : int.Parse(ViewState["RecordCount"].ToString()));
        }
        set
        {
            ViewState["RecordCount"] = value;
        }
    }
    public int MaxPageShowCount
    {
        get
        {
            return (ViewState["MaxPageShowCount"] ==null ? 5 : int.Parse(ViewState["MaxPageShowCount"].ToString()));
        }
        set
        {
            ViewState["MaxPageShowCount"] = value;
        }
    }
    public int MaxPageCount
    {
        get
        {
            return (ViewState["MaxPageCount"] ==null ? 0 : int.Parse(ViewState["MaxPageCount"].ToString()));
        }
        set
        {
            ViewState["MaxPageCount"] = value;
        }
    }
    public int CurrentPageGroup
    {
        get
        {
            return (ViewState["CurrentPageGroup"] ==null ? 0 : int.Parse(ViewState["CurrentPageGroup"].ToString()));
        }
        set
        {
            ViewState["CurrentPageGroup"] = value;
        }
    }
    private int PagerShowSize
    {
        get
        {
            return (ViewState["PagerShowSize"] ==null ? 5 : int.Parse(ViewState["PagerShowSize"].ToString()));
        }
        set
        {
            ViewState["PagerShowSize"] = value;
        }
    }
    public string ItemName
    {
        get
        {
            return (ViewState["ItemName"] ==null ? "" : ViewState["ItemName"].ToString());
        }
        set
        {
            ViewState["ItemName"] = value;
        }
    }
    #endregion    


    #region STYLE_PROPERTIES

    #region Arrow

    private string m_NextIcon = "»";
	public string p_NextIcon
	{
		get { return m_NextIcon;}
		set { m_NextIcon = value;}
	}

    private string m_LastIcon = "»»";
    public string p_LastIcon
    {
        get { return m_LastIcon; }
        set { m_LastIcon = value; }
    }

    private string m_PrevIcon = "«";
    public string p_PrevIcon
    {
        get { return m_PrevIcon; }
        set { m_PrevIcon = value; }
    }

    private string m_FirstIcon = "««";
    public string p_FirstIcon
    {
        get { return m_FirstIcon; }
        set { m_FirstIcon = value; }
    }
    #endregion

    #region CssClass

    private string m_ActivePageTd = "turuncuKoyu";
    public string p_ActivePageTd
    {
        get { return m_ActivePageTd; }
        set { m_ActivePageTd = value; }
    }

    private string m_ActivePageText = "Tahoma11pxSiyahKoyu";
    public string p_ActivePageText
    {
        get { return m_ActivePageText; }
        set { m_ActivePageText = value; }
    }

    private string m_PageTd = "turuncuPaging";
    public string p_PageTd
    {
        get { return m_PageTd; }
        set { m_PageTd = value; }
    }

    private string m_PageText = "Tahoma11pxTuruncuKoyu";
    public string p_PageText
    {
        get { return m_PageText; }
        set { m_PageText = value; }
    }

    #endregion

    #endregion

    public event EventHandler PagerChanged; 
    protected void Page_Load(object sender, EventArgs e)
    {
        GeneratePager();
    }

    #region Private Functions
    protected void ddl_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        CurrentPage = 1;
        CurrentPageGroup = 0;
        PageSize = int.Parse(((DropDownList)(sender)).SelectedItem.Text);
        GeneratePager();
        OnPagerChangedEvent(e);
    }

    protected virtual void OnPagerChangedEvent(EventArgs e)
    {
        // Check if there are any subscribers before throwing the Event
        if (PagerChanged != null)
        {
            PagerChanged(this, e);
        }
    }

    protected void lb_Click(object sender, System.EventArgs e)
    {
        CurrentPage = int.Parse(((LinkButton)(sender)).Text);
        GeneratePager();
        OnPagerChangedEvent(e);
    }
    protected void lbChangeGroup_Click(object sender, System.EventArgs e)
    {
        if (((LinkButton)(sender)).CommandArgument == "Next")
        {
            CurrentPageGroup += 1;
            CurrentPage = (CurrentPageGroup * PagerShowSize) + 1;
        }
        else if (((LinkButton)(sender)).CommandArgument == "Back")
        {
            CurrentPageGroup -= 1;
            CurrentPage = (CurrentPageGroup * PagerShowSize) + 1;
        }
        else if (((LinkButton)(sender)).CommandArgument == "First")
        {
            CurrentPageGroup = 0;
            CurrentPage = (CurrentPageGroup * PagerShowSize) + 1;
        }
        else if (((LinkButton)(sender)).CommandArgument == "Last")
        {
            double DMaxPageCount = MaxPageCount;
            double DPagerShowSize = PagerShowSize;
            CurrentPageGroup = (int)(Math.Ceiling((double)(MaxPageCount / PagerShowSize)) - 1);
            CurrentPage = MaxPageCount;
        }
        GeneratePager();
        OnPagerChangedEvent(e);
    }
    #endregion

    #region Public Functions
    public void GeneratePager()
    {
        double DRecordCount = RecordCount;
        double DPageSize = PageSize;
        MaxPageCount = (int)(Math.Ceiling(((double)(DRecordCount / DPageSize))));

        phContent.Controls.Clear();

        Table tablePaging = new Table();
        tablePaging.BorderWidth = 0;
        tablePaging.CellPadding = 2;
        tablePaging.CellSpacing = 5;

        TableRow tableRow = new TableRow();
        bool MoreThenShow;
        MoreThenShow = false;
        int sayac = MaxPageCount;
        if (MaxPageCount > PagerShowSize)
        {
            sayac = (PagerShowSize * (CurrentPageGroup + 1));
            MoreThenShow = true;
        }

        if (sayac > MaxPageCount)
        {
            sayac = MaxPageCount;
            MoreThenShow = false;
        }

        TableCell tdPaging1 = new TableCell();
        tdPaging1.Width = 150;
        tdPaging1.HorizontalAlign = HorizontalAlign.Center;
        Label lbl = new Label();
        lbl.ID = "lbSayi";

        double DMaxPageCount = MaxPageCount;
        double DPagerShowSize = PagerShowSize;

        lbl.Text = "(Toplam: " + RecordCount.ToString() + " " + ItemName + (Math.Floor((double)(DMaxPageCount / DPagerShowSize)) == 0 ? ")" : " / " + MaxPageCount.ToString() + " sayfa)&nbsp;&nbsp;");
        lbl.CssClass = "Tahoma10pxSiyah";
        lbl.Width = 250;
        lbl.Style.Add("text-align", "right");
        tdPaging1.Controls.Add(lbl);
        tableRow.Controls.Add(tdPaging1);

        if (RecordCount > 5)
        {
            TableCell tdPaging2 = new TableCell();
            tdPaging2.Style.Add("padding-left", "5px");
            tdPaging2.Style.Add("padding-right", "5px");
            tdPaging2.HorizontalAlign = HorizontalAlign.Center;
            DropDownList drplist = new DropDownList();
            drplist.ID = "ddlPageCount";
            drplist.AutoPostBack = true;
            drplist.CssClass = "Tahoma10pxSiyah";
            drplist.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
            for (int i = 5; i <= 30; i += 5)
            {
                ListItem ddlitem = new ListItem();
                ddlitem.Text = i.ToString();
                ddlitem.Value = i.ToString();
                if (i == PageSize)
                {
                    ddlitem.Selected = true;
                }
                else
                {
                    ddlitem.Selected = false;
                }
                drplist.Items.Add(ddlitem);

                if (PageSize < i + 5 & PageSize > i)
                {
                    ListItem ddlitemps = new ListItem();
                    ddlitemps.Text = PageSize.ToString();
                    ddlitemps.Value = PageSize.ToString();
                    ddlitemps.Selected = true;
                    drplist.Items.Add(ddlitemps);
                }
            }
            tdPaging2.Controls.Add(drplist);
            tableRow.Controls.Add(tdPaging2);
        }

        if (CurrentPageGroup > 1)
        {
            TableCell tdPaging = new TableCell();
            tdPaging.CssClass = "turuncuPaging"; // 
            tdPaging.Width = 20;
            tdPaging.HorizontalAlign = HorizontalAlign.Center;
            LinkButton lb = new LinkButton();
            lb.ID = "lbGroupFirst";
            lb.Text = "<<";
            lb.CommandArgument = "First";
            lb.CssClass = "Tahoma11pxTuruncuKoyu";
            lb.Click += new EventHandler(lbChangeGroup_Click);
            tdPaging.Controls.Add(lb);
            tableRow.Controls.Add(tdPaging);
        }

        if (CurrentPageGroup > 0)
        {
            TableCell tdPaging = new TableCell();
            tdPaging.CssClass = "turuncuPaging"; //
            tdPaging.Width = 20;
            tdPaging.HorizontalAlign = HorizontalAlign.Center;
            LinkButton lb = new LinkButton();
            lb.ID = "lbGroupBack";
            lb.Text = "<-";
            lb.CommandArgument = "Back";
            lb.CssClass = "Tahoma11pxTuruncuKoyu"; // 
            lb.Click += new EventHandler(lbChangeGroup_Click);
            tdPaging.Controls.Add(lb);
            tableRow.Controls.Add(tdPaging);
        }
        if (sayac == 1)
        {
            sayac = 0;
        }

        for (int i = ((CurrentPageGroup * PagerShowSize) + 1); i <= sayac; i++)
        {
            TableCell tdPaging = new TableCell();
            tdPaging.Width = 20;
            tdPaging.HorizontalAlign = HorizontalAlign.Center;
            LinkButton lb = new LinkButton();
            lb.ID = i.ToString();
            lb.Text = i.ToString();
            lb.Click += new EventHandler(lb_Click);
            if (i == CurrentPage)
            {
                tdPaging.CssClass = p_ActivePageTd.ToString();
                lb.CssClass =p_ActivePageText.ToString();
            }
            else
            {
                tdPaging.CssClass = p_PageTd.ToString();
                lb.CssClass = p_PageText.ToString();
            }
            tdPaging.Controls.Add(lb);
            tableRow.Controls.Add(tdPaging);
        }


        DMaxPageCount = MaxPageCount;
        DPagerShowSize = PagerShowSize;
        if (CurrentPageGroup + 1 < Math.Ceiling((double)(DMaxPageCount / DPagerShowSize)))
        {
            TableCell tdPaging = new TableCell();
            tdPaging.CssClass = p_PageTd.ToString();
            tdPaging.Width = 20;
            tdPaging.HorizontalAlign = HorizontalAlign.Center;
            LinkButton lb = new LinkButton();
            lb.ID = "lbGroupNext";
            lb.Text = "->";
            lb.CommandArgument = "Next";
            lb.CssClass = p_PageText.ToString();
            lb.Click += new EventHandler(lbChangeGroup_Click);
            tdPaging.Controls.Add(lb);
            tableRow.Controls.Add(tdPaging);
        }

        if (CurrentPageGroup + 1 < Math.Ceiling((double)(DMaxPageCount / DPagerShowSize)))
        {
            TableCell tdPaging = new TableCell();
            tdPaging.CssClass = p_PageTd.ToString();
            tdPaging.Width = 20;
            tdPaging.HorizontalAlign = HorizontalAlign.Center;
            LinkButton lb = new LinkButton();
            lb.ID = "lbGroupLast";
            lb.Text = p_LastIcon.ToString();
            lb.CommandArgument = "Last";
            lb.CssClass = p_PageText.ToString();
            lb.Click += new EventHandler(lbChangeGroup_Click);
            tdPaging.Controls.Add(lb);
            tableRow.Controls.Add(tdPaging);
        }

        tablePaging.Controls.Add(tableRow);
        phContent.Controls.Add(tablePaging);
    }
    #endregion

}
