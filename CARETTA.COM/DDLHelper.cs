using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CARETTA.COM
{
    public class DDLHelper
    {


        /// <summary>
        /// DropDown Bound Ba�lang�� Item YOK
        /// </summary>
        /// <param name="ddlControl">Dropdownlist</param>
        /// <param name="dt">Datasource Datatable</param>
        /// <param name="DataTextField">G�r�nt�lenecek H�cre</param>
        /// <param name="DataValueField">Value H�cre</param>
        /// <param name="SelectedValue">Se�ili H�cre</param>
        public static void BindDDL(ref System.Web.UI.WebControls.DropDownList ddlControl, DataTable dt, string DataTextField, string DataValueField, string SelectedValue)
        {
            BindDDL(ref ddlControl, dt, DataTextField, DataValueField, SelectedValue, "", "");
        }

        /// <summary>
        /// DropDown Bound Ba�lang�� Item VAR
        /// </summary>
        /// <param name="ddlControl">Dropdownlist</param>
        /// <param name="dt">Datasource Datatable</param>
        /// <param name="DataTextField">G�r�nt�lenecek H�cre</param>
        /// <param name="DataValueField">Value H�cre</param>
        /// <param name="SelectedValue">Se�ili H�cre</param>
        /// <param name="InitialValueText">Ba�lang�� Item Text</param>
        /// <param name="InitialValue">Ba�lang�� item value</param>
        public static void BindDDL(ref System.Web.UI.WebControls.DropDownList ddlControl, DataTable dt, string DataTextField, string DataValueField, string SelectedValue, string InitialValueText, string InitialValue)
        {
            ddlControl.DataTextField = DataTextField;
            ddlControl.DataValueField = DataValueField;
            ddlControl.DataSource = dt;
            ddlControl.DataBind();
            if (InitialValueText != "")
            {
                ddlControl.Items.Insert(0, new System.Web.UI.WebControls.ListItem(InitialValueText, InitialValue));
            }
            if (SelectedValue != "")
            {
                ddlControl.SelectedValue = SelectedValue;
            }
        }

        /// <summary>
        /// DROPDOWNLIST I VALUE �LE TEXT AYNI OLACAK �EK�LDE RAKAM �LE DOLDURUR.
        /// </summary>
        /// <param name="ddl">DropDownlList Ref Parametre</param>
        /// <param name="count">Ka�a kadar?</param>
        public static void LoadNumberDDL(ref System.Web.UI.WebControls.DropDownList ddl, int count)
        {
            LoadNumberDDL(ref ddl, count, 1, 1);
        }

        /// <summary>
        /// DROPDOWNLIST I VALUE �LE TEXT AYNI OLACAK �EK�LDE RAKAM �LE �STENEN SAYIDA ARTARAK DOLDURUR.
        /// </summary>
        /// <param name="ddl">DropDownlList Ref Parametre</param>
        /// <param name="Count">Ka�a kadar?</param>
        /// <param name="Step">Ka� Ka� Arts�n?</param>
        /// <param name="StartNumber">Ka�tan Ba�las�n?</param>
        public static void LoadNumberDDL(ref System.Web.UI.WebControls.DropDownList ddl, int Count, int Step, int StartNumber) {
            ddl.Items.Clear();
            for (int i = StartNumber; i <= Count; i += Step) {
                ddl.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
            }
        }

    }
}
