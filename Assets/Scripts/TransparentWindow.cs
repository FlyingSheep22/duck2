using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TransparentWindow : MonoBehaviour
{

    // ---------- CONSTANTS AND VARIABLES ----------
    
    // imma be honest i do not know what these mean
    const int GWL_EXSTYLE = -20;
    const uint WS_EX_LAYERED = 0x00080000;
    const uint WS_EX_TRANSPARENT = 0x00000020;
    const uint LWA_COLORKEY = 0X00000001;

    static readonly IntPtr PTR_TOP = new IntPtr(-1);

    // Struct for mapping margin sizes 
    private struct MARGINS{
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    // ---------- EXTERN FUNCTION CALLS/REFERENCES ----------

    // Initial test, with a default message box
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    private static extern int SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);
    

    /*
    Controls access to the current window frame based on size in struct.

    @param hWnd - Pointer handle to the active window frame
    */
    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    



    // ---------- RUNTIME FUNCTIONS, START AND UPDATE ----------
    void Start(){

#if !UNITY_EDITOR
        IntPtr ptr = GetActiveWindow();

        MARGINS margins = new MARGINS { cxLeftWidth = -1 };
        DwmExtendFrameIntoClientArea(ptr, ref margins);

        SetWindowLong(ptr, GWL_EXSTYLE, WS_EX_LAYERED);
        SetLayeredWindowAttributes(ptr,0,0,LWA_COLORKEY);

        SetWindowPos(ptr,PTR_TOP,0,0,0,0,0);

#endif

    Application.runInBackground = true;

    }

}
