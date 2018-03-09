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

public partial class UserControls_Common_uctrlSearchMap : BaseUserControl
{
    //#region Properties
    //public int DivWidth
    //{
    //    get
    //    {
    //        return (int)(ViewState["DW"] == null ? 528 : ViewState["DW"]);
    //    }
    //    set
    //    {
    //        ViewState["DW"] = value;
    //    }
    //}
    //public int DivHeight
    //{
    //    get
    //    {
    //        return (int)(ViewState["DH"] == null ? 277 : ViewState["DH"]);
    //    }
    //    set
    //    {
    //        ViewState["DH"] = value;
    //    }
    //}
    //#endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCountries();
        }
    }

    private void FillCountries()
    {
        DataTable dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID((int)Enumerations.ContinentSubjectID.Avrupa);
        dlCountries82.DataSource = dt;
        dlCountries82.DataBind();
        dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID((int)Enumerations.ContinentSubjectID.Asya);
        dlCountries102.DataSource = dt;
        dlCountries102.DataBind();
        dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID((int)Enumerations.ContinentSubjectID.Afrika);
        dlCountries103.DataSource = dt;
        dlCountries103.DataBind();
        dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID((int)Enumerations.ContinentSubjectID.GuneyAmerika);
        dlCountries151.DataSource = dt;
        dlCountries151.DataBind();
        dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID((int)Enumerations.ContinentSubjectID.KuzeyAmerika);
        dlCountries150.DataSource = dt;
        dlCountries150.DataBind();
        dt = BINROTA.BUS.Subjects.GetSubjectByParentSubjectID((int)Enumerations.ContinentSubjectID.Okyanusya);
        dlCountries152.DataSource = dt;
        dlCountries152.DataBind();
        dt = BINROTA.BUS.Subjects.GetSubjectForDDL((int)Enumerations.SubjectType.Ulke);
        dlCountriesAll.DataSource = dt;
        dlCountriesAll.DataBind();
    }
}
