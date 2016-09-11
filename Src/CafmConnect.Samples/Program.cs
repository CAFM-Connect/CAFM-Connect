using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ifc.NET;
using Workspace = CafmConnect.Workspace;

namespace Ifc.Net.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
 
            Workspace cc = new Workspace();        
            cc.CreateFile( "MyName", "MyCompany", "MySoftware", "MyAuthorization");

            IfcProject ifcProject = new IfcProject {Name = "MyProject",LongName = "MyProject Description"};
            IfcSite site = new IfcSite {Name = "MySite",LongName = "MySite Description"};

            ifcProject.Sites.AddNewSite();

            string checksum = cc.Ifc4Document.Checksum.ToString();

            string filename = @"c:\\tmp\\MyFirstEmptyCafmConnectFile.xy";
            cc.SaveFile(filename);



        }
    }
}
