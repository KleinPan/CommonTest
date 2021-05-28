using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using static Vanara.PInvoke.Kernel32.COPYFILE2_MESSAGE;

namespace CommonTest
{
    class ConsoleManager
    {

        public static bool HasConsole
        {
            get { return PInvoke.Kernel32.GetConsoleWindow() != IntPtr.Zero; }
        }


        /// <summary>
        /// Creates a new console instance if the process is not attached to a console already.
        /// </summary>
        public static void Show()
        {
         
            if (!HasConsole)
            {
                PInvoke.Kernel32.AllocConsole();
                //InvalidateOutAndError();
                
            }
       
        }

        /// <summary>
        /// If the process has a console attached to it, it will be detached and no longer visible. Writing to the System.Console is still possible, but no output will be shown.
        /// </summary>
        public static void Hide()
        {
            //#if DEBUG
            if (HasConsole)
            {
                SetOutAndErrorNull();
                PInvoke.Kernel32.FreeConsole();
            }
            //#endif
        }

        public static void Toggle()
        {
            if (HasConsole)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        static void InvalidateOutAndError()
        {
            //Type type = typeof(System.Console);

            //System.Reflection.FieldInfo _out = type.GetField("_out",
            //        System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);


            //System.Reflection.FieldInfo _error = type.GetField("_error",
            //    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            //System.Reflection.MethodInfo _InitializeStdOutError = type.GetMethod("InitializeStdOutError",
            //    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);



            //Debug.Assert(_out != null);
            //Debug.Assert(_error != null);

            //Debug.Assert(_InitializeStdOutError != null);

            //_out.SetValue(null, null);
            //_error.SetValue(null, null);

            //_InitializeStdOutError.Invoke(null, new object[] { true });

            System.Console.Clear();
        }

        static void SetOutAndErrorNull()
        {
            Console.SetOut(TextWriter.Null);
            Console.SetError(TextWriter.Null);
        }
    }
}
