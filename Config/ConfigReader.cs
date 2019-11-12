using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using GlobalAutoFramework.Base;

namespace GlobalAutoFramework.Config
{
    public class ConfigReader
    {

        public static void SetFrameworkSettings()
        {

            XPathItem aut;
            XPathItem testtype;
            XPathItem islog;
            XPathItem isreport;
            XPathItem buildname;
            XPathItem logPath;
            XPathItem appConnection;
            XPathItem browsertype;

            string strFilename = @"C:\VS\TestAutomation\Config\GlobalConfig.xml";
            FileStream stream = new FileStream(strFilename, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Get XML Details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("GlobalAutoFramework/RunSettings/AUT");
            buildname = navigator.SelectSingleNode("GlobalAutoFramework/RunSettings/BuildName");
            testtype = navigator.SelectSingleNode("GlobalAutoFramework/RunSettings/TestType");
            islog = navigator.SelectSingleNode("GlobalAutoFramework/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("GlobalAutoFramework/RunSettings/IsReport");
            logPath = navigator.SelectSingleNode("GlobalAutoFramework/RunSettings/LogPath");
            appConnection = navigator.SelectSingleNode("GlobalAutoFramework/RunSettings/ApplicationDb");
            browsertype = navigator.SelectSingleNode("GlobalAutoFramework/RunSettings/Browser");

            //Set XML Details in the property to be used accross framework
            Settings.AUT = aut.Value.ToString();
            Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsLog = islog.Value.ToString();
            Settings.IsReporting = isreport.Value.ToString();
            Settings.LogPath = logPath.Value.ToString();
            Settings.AppConnectionString = appConnection.Value.ToString();
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), browsertype.Value.ToString());


        }

    }
}
