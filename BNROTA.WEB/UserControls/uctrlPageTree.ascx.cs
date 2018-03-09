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
using BINROTA.COM;

public delegate void ChildChangeEventHandler(int SubjectID);

public partial class UserControls_uctrlPageTree : BaseUserControl 
{
    public event ChildChangeEventHandler ChildChange;

    public int SelectedSubjectID
    {
        get { return int.Parse(tvSubjects.SelectedValue); }
    }

    private DataTable GetSubjectBySubjectID(int SubjectID, int SubjectTypeID)
    {

        DataTable dt = BINROTA.BUS.Subjects.GetSubjectBySubjectID(SubjectID, SubjectTypeID);
        return dt;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (SessRoot == null) Common.GotoDefaultPage(this.Response);

            try
            {
             //   FillSubjectTree();
                FillSubjectTree();
                   
            }
            catch (Exception)
            {
                throw;
            }

        }
    }

    //private void FillSubjectTree()
    //{
    //    tvSubjects.Nodes.Clear();
    //    tvSubjects.Nodes.Add(new TreeNode("Root", "0"));
    //    PopulateTreeView(tvSubjects.Nodes[0], 0);
    //}

    private void FillSubjectTree()
    {
        DataTable dt = BINROTA.BUS.Pages.GetUserPages(SessRoot.UserID, (int)Enumerations.PageType.TravelPage);
        DataTable dtSubjectIDsToBeAdd = new DataTable();
        dtSubjectIDsToBeAdd.Columns.Add("SubjectID");
        int SubjectType = 0;
        foreach (DataRow dr in dt.Rows)
        {
            int SubjectID = int.Parse(dr["SubjectID"].ToString());

            DataRow dr1 = dtSubjectIDsToBeAdd.NewRow();
            dr1["SubjectID"] = SubjectID;
            dtSubjectIDsToBeAdd.Rows.Add(dr1);

            do
            {
                DataTable dt1 = BINROTA.BUS.Subjects.GetParentSubjectBySubjectID(SubjectID);
                SubjectID = int.Parse(dt1.Rows[0]["SubjectID"].ToString());
                DataRow dr2 = dtSubjectIDsToBeAdd.NewRow();
                dr2["SubjectID"] = SubjectID;
                dtSubjectIDsToBeAdd.Rows.Add(dr2);
                SubjectType = int.Parse(dt1.Rows[0]["SubjectTypeID"].ToString());

            } while (SubjectType != (int)Enumerations.SubjectType.Kita);
        }

        tvSubjects.Nodes.Clear();
        tvSubjects.Nodes.Add(new TreeNode("Root", "0"));
        PopulateTreeView(tvSubjects.Nodes[0], 0, dtSubjectIDsToBeAdd);
    }

    void PopulateTreeView(TreeNode tn, int ParentSubjectID, DataTable dtSubjectIDsToBeAdd)
    {
        DataTable dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(ParentSubjectID);
        TreeNode objTreeNode;
        foreach (DataRow dr in dt.Rows)
        {
            int Exists = 0;
            for (int i = 0; i < dtSubjectIDsToBeAdd.Rows.Count; i++)
            {
                if (dr["SubjectID"].ToString() == dtSubjectIDsToBeAdd.Rows[i]["SubjectID"].ToString())
                    Exists = 1;
            }
            if (Exists == 1)
            {
                objTreeNode = new TreeNode(dr["Name"].ToString(), dr["SubjectID"].ToString());
                tn.ChildNodes.Add(objTreeNode);

                if (int.Parse(dr["SubjectTypeID"].ToString()) == (int)Enumerations.SubjectType.Sehir)
                {
                    DataTable dtPage = BINROTA.BUS.Pages.GetPageForExistanceControl(SessRoot.UserID, int.Parse(dr["SubjectID"].ToString()), (int)Enumerations.PageType.TravelPage);
                    foreach (DataRow drPage in dtPage.Rows)
                    {
                        TreeNode objTreeNodePage = new TreeNode(drPage["Title"].ToString(), drPage["PageID"].ToString());
                        objTreeNode.ChildNodes.Add(objTreeNodePage);
                    }
                }
                PopulateTreeView(objTreeNode, int.Parse(dr["SubjectID"].ToString()), dtSubjectIDsToBeAdd);
            }
        }
    }



    //void PopulateTreeView(TreeNode tn, int ParentSubjectID)
    //{
    //    DataTable dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID(ParentSubjectID);
    //    TreeNode objTreeNode;

    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        if (((Enumerations.SubjectType)int.Parse(dr["SubjectTypeID"].ToString())) == Enumerations.SubjectType.Sehir)
    //        {
    //            DataTable dtSubject = new DataTable();
    //            dtSubject = BINROTA.BUS.Pages.GetPageForExistanceControl(SessRoot.UserID, int.Parse(dr["SubjectID"].ToString()), (int)Enumerations.PageType.TravelPage);
    //            if (dtSubject.Rows.Count > 0)
    //            {
    //                objTreeNode = new TreeNode(dr["Name"].ToString(), dr["SubjectID"].ToString());
    //                tn.ChildNodes.Add(objTreeNode);
    //                PopulateTreeView(objTreeNode, int.Parse(dr["SubjectID"].ToString()));
    //            }
    //        }
    //        else
    //        {
    //            objTreeNode = new TreeNode(dr["Name"].ToString(), dr["SubjectID"].ToString());
    //            tn.ChildNodes.Add(objTreeNode);
    //            PopulateTreeView(objTreeNode, int.Parse(dr["SubjectID"].ToString()));
    //        }
    //    }
    //    dt = BINROTA.BUS.Subjects.GetSubject(ParentSubjectID);
    //    if (dt.Rows.Count > 0)
    //    {
    //        if (int.Parse(dt.Rows[0]["SubjectTypeID"].ToString()) == (int)Enumerations.SubjectType.Sehir)
    //        {
    //            DataTable dtPage = new DataTable();
    //            dtPage = BINROTA.BUS.Pages.GetPageForExistanceControl(SessRoot.UserID, ParentSubjectID, (int)Enumerations.PageType.TravelPage);
    //            foreach (DataRow drPage in dtPage.Rows)
    //            {
    //                DataTable dtPageCategory = BINROTA.BUS.PageCategories.GetPageCategoriesByPageCategoryID(int.Parse(drPage["PageCategoryID"].ToString()));
    //                if (dtPageCategory.Rows.Count > 0)
    //                {
    //                    string PageCategoryName = dtPageCategory.Rows[0]["PageCategoryName"].ToString();
    //                    objTreeNode = new TreeNode(PageCategoryName, drPage["PageID"].ToString());
    //                    tn.ChildNodes.Add(objTreeNode);
    //                }
    //            }
    //        }
    //    }
    //}


    protected void tvSubjects_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (ChildChange!=null) ChildChange(int.Parse(tvSubjects.SelectedNode.Value));
    }
}
