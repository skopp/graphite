﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Web;

namespace Graphite.Internal
{
    /// <summary>
    /// Summary description for Graphite
    /// </summary>
    public class Config
    {
        private System.Xml.XmlNodeList demo;
        
        public Config(string demosClasses)
	    {
            System.Xml.XmlDocument demos = new System.Xml.XmlDocument();
            demos.Load(HttpContext.Current.Server.MapPath(@"~\App_Data\Graphite\Internal\Sitemaps\demos.xml"));
            demo = demos.SelectNodes(demosClasses);
        }

        public int Index(string name)
        {
            int index = -1;
            int count = 0;
            foreach (XmlNode node in demo[0].ChildNodes)
            {
                if (name == node.Name)
                {
                    index = count;
                }
                count++;
            }
            return index;
        }
        
        public string[,] Types()
	    {
	        string[,] types = new string[demo[0].ChildNodes.Count,2];
	        int count = 0;
            foreach (XmlElement node in demo[0].ChildNodes)
            {
                types[count,0] = node.Name;
                if (node.HasAttribute("humanname"))
                {
                    types[count,1] = node.Attributes["humanname"].Value;
                }
                else
                {
                    types[count, 1] = node.Name;
                }
                count++;
            }
            return types;
	    }

        public Dictionary<string, Boolean> Files(int index)
        {
            Dictionary<string, Boolean> defaultCode = new Dictionary<string, Boolean>();
            
            // Get references to HTML, CSS and JS
            foreach (XmlElement node in demo[0].ChildNodes[index].SelectSingleNode("files"))
            {
                bool defaultBool = false;
                if (node.HasAttribute("use_default_code"))
                {
                    defaultBool = true;
                }
                defaultCode.Add(node.Name, defaultBool);
            }
            
            // Check if demo is set as an external demo
            XmlElement RootElement = demo[0].ChildNodes[index].SelectSingleNode("files") as XmlElement;
            defaultCode.Add("externalDemo", false);
            if (RootElement.HasAttribute("externalDemo") == true)
            {
                if (RootElement.Attributes["externalDemo"].Value == "true")
                {
                    defaultCode["externalDemo"] = true;
                }
            }
            return defaultCode;
        }

        public Dictionary<string, string> SupportedBrowsers(int index)
        {
            Dictionary<string, string> supportedBrowsers = new Dictionary<string, string>();
            if (demo[0].ChildNodes[index].SelectSingleNode("browsers") != null)
            {
                foreach (XmlElement node in demo[0].ChildNodes[index].SelectSingleNode("browsers"))
                {
                    string browserVersion = "";
                    if (node.HasAttribute("supports"))
                    {
                        browserVersion = node.Attributes["supports"].Value;
                    }
                    supportedBrowsers.Add(node.Name, browserVersion);
                }
            }
            return supportedBrowsers;
        }

        public Dictionary<string, string> GetStageDimension(int index)
        {
            Dictionary<string, string> getStageDimension = new Dictionary<string, string>();
            getStageDimension.Add("width", "auto");
            getStageDimension.Add("height", "auto");
            XmlElement node = demo[0].ChildNodes[index] as XmlElement;
            if (node.HasAttribute("width") == true && node.Attributes["width"].Value != "")
            {
                getStageDimension["width"] = node.Attributes["width"].Value;
            }
            if (node.HasAttribute("height") == true && node.Attributes["height"].Value != "")
            {
                getStageDimension["height"] = node.Attributes["height"].Value;
            }
            return getStageDimension;
        }

        public string Type(int index)
        {
            return demo[0].ChildNodes[index].Name;
        }

        public string CssClass(int index)
        {
            string cssClass = "";
            XmlElement selectedElement = demo[0].ChildNodes[index] as XmlElement;
            if (selectedElement.HasAttribute("cssclass") == true)
            {
                cssClass = selectedElement.Attributes["cssclass"].Value;
            }
            return cssClass;
        }
    }
}