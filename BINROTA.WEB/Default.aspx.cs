using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CARETTA.COM;
using BINROTA.COM;

public partial class _Default : BasePage
{
    private DataTable GetSubjectForDDL(int SubjectTypeID) {

        DataTable dt = BINROTA.BUS.Subjects.GetSubjectForDDL(SubjectTypeID);
        return dt;
    }

    private DataTable GetSubjectBySubjectID(int SubjectID, int SubjectTypeID) {

        DataTable dt = BINROTA.BUS.Subjects.GetSubjectBySubjectID(SubjectID, SubjectTypeID);
        return dt;
    }

    private void GetUserPageDetail() {

        DataTable dt = new DataTable();
        dt = BINROTA.BUS.Pages.GetPageForExistanceControl(SessRoot.UserID, int.Parse(tvSubjects.SelectedValue.ToString()), int.Parse(drpCategories.SelectedValue.ToString()));
        if (dt.Rows.Count != 0)
        {
            txtTitle.Text = dt.Rows[0]["Title"].ToString();
            ftbPageContent.Text = dt.Rows[0]["PageContent"].ToString();
        }
        else {
            lbMessage.Text = "Daha önce eklediðiniz böyle bir kayýt yoktur";
            txtTitle.Text = "";
            ftbPageContent.Text = "";
        }
    }

    private void FillSubjectTree() {
        tvSubjects.Nodes.Clear();
        tvSubjects.Nodes.Add(new TreeNode("Root", "0"));
        PopulateTreeView(tvSubjects.Nodes[0], 0);
    }

    void PopulateTreeView(TreeNode tn, int ParentSubjectID)
    {
        DataTable dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(ParentSubjectID);
        TreeNode objTreeNode;

        foreach (DataRow dr in dt.Rows)
        {
            if (((Enumerations.SubjectType)int.Parse(dr["SubjectTypeID"].ToString())) == Enumerations.SubjectType.Sehir)
            {
                DataTable dtSubject = new DataTable();
                dtSubject = BINROTA.BUS.Pages.GetPageForExistanceControl(SessRoot.UserID, int.Parse(dr["SubjectID"].ToString()));
                if (dtSubject.Rows.Count > 0)
                {
                    objTreeNode = new TreeNode(dr["Name"].ToString(), dr["SubjectID"].ToString());
                    tn.ChildNodes.Add(objTreeNode);
                    PopulateTreeView(objTreeNode, int.Parse(dr["SubjectID"].ToString()));
                }
            }
            else
            {
                objTreeNode = new TreeNode(dr["Name"].ToString(), dr["SubjectID"].ToString());
                tn.ChildNodes.Add(objTreeNode);
                PopulateTreeView(objTreeNode, int.Parse(dr["SubjectID"].ToString()));
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillSubjectTree();
                DDLHelper.BindDDL(ref drpCategories, BINROTA.BUS.Categories.GetCategories(), "Name", "CategoryID", "");
            }
            catch (Exception)
            {
                throw;
            }

        }
    }

    protected void tvSubjects_SelectedNodeChanged(object sender, EventArgs e)
    {
        GetUserPageDetail();
    }

    protected void drpCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetUserPageDetail();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int PageID = 0;
        DataTable dt = BINROTA.BUS.Pages.GetPageForExistanceControl(SessRoot.UserID, int.Parse(tvSubjects.SelectedValue.ToString()), int.Parse(drpCategories.SelectedValue));
        if (dt.Rows.Count <= 0) Common.GotoDefaultPage(this.Response);

        PageID = int.Parse( dt.Rows[0]["PageID"].ToString());
        BINROTA.BUS.Pages.PagesUpdate(PageID, txtTitle.Text, ftbPageContent.Text);
        lbMessage.Text = "Güncelleme iþlemi geçekleþmiþtir";
    }
}
