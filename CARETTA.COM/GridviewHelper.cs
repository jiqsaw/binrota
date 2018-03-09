using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;

namespace CARETTA.COM
{
    public class GridviewHelper
    {
        public static void BindGridview(ref GridView gvControl, DataTable dt)
        {
            gvControl.DataSource = dt;
            gvControl.DataBind();
        }
    }
}
