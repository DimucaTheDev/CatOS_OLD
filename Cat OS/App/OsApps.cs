using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CatOS.util;

namespace CatOS.App
{
    class OsApps
    {
        public static string[] value;
        public static void ExecuteCommand(string[] command)
        {
            value = command;
            #region Included
            if (value[0] == "calc")
                OsApps.calc();
            #endregion
            #region Util
            if (value[0] == "exit" || value[0] == "leave" || value[0] == "shutdown")
            {
                Logger.log("Shutting down...");
                Cosmos.System.Power.Shutdown();
            }
            if (value[0] == "reboot" || value[0] == "restart")
            {
                Logger.log("Rebooting...");
                Cosmos.System.Power.Reboot();
            }
            if (value[0] == "dir")
            {
                try
                {
                    foreach (var item in Directory.GetFiles("0:\\"))
                        Console.WriteLine(item);
                    Console.WriteLine();
                    foreach (var item in Directory.GetDirectories("0:\\"))
                        Console.WriteLine(item);
                }
                catch(Exception e) { Logger.log(e.Message); }
            }
            if (value[0] == "mkfile") File.Create(@"0:\" + value[1]).Close();
            if (value[0] == "help")
            {
                Console.WriteLine
                (
                    "exit / leave / shutdown | Shutting down the system\n" +
                    "reboot / restart        | Restarting the system\n" +
                    ""
                );
            }
            #endregion
        }
        public static void calc()
        {
            int latest = 0;
            switch (value[2])
            {
                case "+":
                    Console.WriteLine((int.Parse(value[1]) + int.Parse(value[3])));
                    latest = int.Parse(value[1]) + int.Parse(value[3]);
                    break;
                case "-":
                    Console.WriteLine((int.Parse(value[1]) - int.Parse(value[3])));
                    latest = int.Parse(value[1]) - int.Parse(value[3]);
                    break;
                case "*":
                    Console.WriteLine((int.Parse(value[1]) * int.Parse(value[3])));
                    latest = int.Parse(value[1]) * int.Parse(value[3]);
                    break;
                case "/":
                    Console.WriteLine((int.Parse(value[1]) / int.Parse(value[3])));
                    latest = int.Parse(value[1]) / int.Parse(value[3]);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: '" + value[1] + "' is not an operator");
                    Console.ResetColor();
                    break;
            }
/*            File.Create("latest.txt").Close();
            File.WriteAllText("latest.txt", latest.ToString());*/
        }
    }
}
