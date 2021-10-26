using Cosmos.System.Graphics;
using System;
using System.Drawing;
using Sys = Cosmos.System;

namespace Cat_OS
{
    public class Kernel : Sys.Kernel
    {
        public static Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        
        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            Console.WriteLine("\nBooted successfully. Type \"help\" to show command list");
        }
        protected override void Run()
        {
            while (true)
            {
                Console.Write(">");
                string _temp = Console.ReadLine();
                //CatOS.App.OsApps.value = _temp.Split(' ');
                CatOS.App.OsApps.ExecuteCommand(_temp.Split(' '));
            }
        }
    }
}
