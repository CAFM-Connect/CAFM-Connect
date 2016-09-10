using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CafmConnect;

namespace Ifc.Net.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Workspace cc = new Workspace();

            string filename = @"c:\\tmp\\MyFirstEmptyCafmConnectFile.ifcxml";
            cc.CreateFile(filename);

        }
    }
}
