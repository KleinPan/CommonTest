using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CommonTest.CPlusPlusInteropTest
{
  public  class InteropTest
    {

        // Define a delegate that corresponds to the unmanaged function.
        public delegate bool EnumWC(IntPtr hwnd, IntPtr lParam);

        // Import user32.dll (containing the function we need) and define the method corresponding to the native function.
        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWC lpEnumFunc, IntPtr lParam);

        // Define the implementation of the delegate; here, we simply output the window handle.
        public static bool OutputWindow(IntPtr hwnd, IntPtr lParam)
        {
            Console.WriteLine(hwnd.ToInt64());
            return true;
        }


        // Invoke the method; note the delegate as a first parameter.
        //CSharpCPlusPlusInterop. EnumWindows(CSharpCPlusPlusInterop.OutputWindow, IntPtr.Zero);
        public static void PinvokeTest()
        {
            PInvoke.User32.EnumWindows(OutputWindow, IntPtr.Zero);
        }
    }

      
}
