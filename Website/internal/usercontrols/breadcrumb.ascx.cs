﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class internal_usercontrols_breadcrumb : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string physicalPath = Request.ServerVariables["script_name"].Replace("default.aspx", "");
        //string[] tree = physicalPath.Split(["/"]);
        litBreadcrumb.Text = physicalPath;
    }
}
