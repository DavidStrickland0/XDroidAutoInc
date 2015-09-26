using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XDroidAutoInc
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Count<string>()!=1)
            {
                DisplayHelp();
            }
            string filepath = args[0];
            filepath = filepath.Trim('"');
            if(!System.IO.File.Exists(filepath))
            {
                DisplayHelp();
            }
            try
            {
                var manifestReader = new XmlTextReader(filepath);
                manifestReader.Read();

                manifestReader.Close();
            }
            catch
            {
                DisplayHelp();
            }
            AndroidManifestManager.IncrementVersion(filepath);
        }

        private static void DisplayHelp()
        {
            System.Console.WriteLine("You must specify the full path to the Android Manifest.");
            System.Console.WriteLine("Example: XDroidAutoInc \"C:\\SourceCode\\MyProject\\Droid\\Properties\\AndroidManifest.xml");
            Environment.Exit(0);
        }
    }
}
