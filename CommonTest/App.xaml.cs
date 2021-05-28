using System;
using System.Windows;

using CommonTest.ThreadTest;

namespace CommonTest
{
    /// <summary> Interaction logic for App.xaml </summary>
    public partial class App  :Application
    {


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CPlusPlusInteropTest.InteropTest.PinvokeTest();

            ManualResetEventTest.ThreadTest();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleManager.Show();
            Console.WriteLine("在wpf中显示控制台");


            ManualResetEventTest.ThreadTest();
            ConsoleManager.Hide();
        }
    }
}