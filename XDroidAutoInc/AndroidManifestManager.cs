using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace https://github.com/DavidStrickland0/XDroidAutoInc.git
{
    class AndroidManifestManager
    {
        public static void IncrementVersion(string filePath)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            var versionNode = doc.SelectSingleNode("manifest");
            XmlNode androidversionCode = versionNode.Attributes["android:versionCode"];
            XmlNode androidversionName = versionNode.Attributes["android:versionName"];
            
            var androidversionNameSplit = androidversionName.Value.Split('.');
            string truncatedVersionName;
             
            if(androidversionNameSplit.Count<string>() >1)
                truncatedVersionName =   string.Join(".",androidversionNameSplit.Take(androidversionNameSplit.Length - 1));
            else
                truncatedVersionName = androidversionName.Value;

            int androidVersionNumber=0;
            int.TryParse(androidversionCode.Value,out androidVersionNumber);

            androidVersionNumber++;
            androidversionCode.Value = androidVersionNumber.ToString();
            androidversionName.Value = string.Concat(truncatedVersionName, ".", androidVersionNumber.ToString());
            doc.Save(filePath);
            
        }
    }
}
