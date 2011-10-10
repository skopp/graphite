﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class blocks_nav_menu : System.Web.UI.Page
{
    // Demo data
    string[] demos = new string[]
    {
        "Horizontal",
        "Vertical"
    };
    
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set page title
        PageTitle.InnerHtml = this.Title;
        
        CreateDemo();
    }

    private void CreateDemo()
    {
        CreateMenu();
    }
    
    private void CreateMenu()
    {
        // Create menu
        for (int i = 0; i <= demos.GetUpperBound(0); i++)
        {
            HyperLink link = new HyperLink();
            link.Text = demos[i];
            link.NavigateUrl = Request.ServerVariables["SCRIPT_NAME"] + "?type=" + i;
            Types.Controls.Add(link);
        }
        
        // Set HTML CSS class
        DemoHTML1.CssType = "gp_" + demos[0].ToLower();
        if (String.IsNullOrEmpty(Request.QueryString["type"]) == false)
        {
            Regex regxNum = new Regex(@"^\d+$");
            bool isNumeric = regxNum.Match(Request.QueryString["type"].ToString()).Success;
            
            if (isNumeric == true)
            {
                int type = Convert.ToInt32(Request.QueryString["type"]);
                DemoHTML1.CssType = "gp_" + demos[type].ToLower();
            }
        }
        DemoHTML2.CssType = DemoHTML1.CssType;
    }
}
