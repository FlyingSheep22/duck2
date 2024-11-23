using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TransparentWindow : MonoBehaviour
{
    // Initial test, with a default message box
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();


    // Struct for mapping margin sizes 
    private struct MARGINS{
        public int LEFT;
        public int RIGHT;
        public int TOP;
        public int BOTTOM;
    }

    /*
    Controls access to the current window frame based on size in struct.

    @param hWnd - Pointer handle to the active window frame
    */
    [DllImport("Dwmapi.ll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

}
