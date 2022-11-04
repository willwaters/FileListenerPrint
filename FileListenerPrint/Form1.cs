using System;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using ESCPOS_NET;
using ESCPOS_NET.Emitters;
using ESCPOS_NET.Utilities;
using Microsoft.VisualBasic.FileIO;


namespace FileListenerPrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SerialPort aeaPrinter;

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cmbDestination.Items.Add(printer);
            }
            cmbDestination.SelectedIndex = 0;
        }

        private void tFileChecker_Tick(object sender, EventArgs e)
        {
            var s = FileSystem.ReadAllText(txtFileName.Text);
            if(s != "")
            {
                RawPrinterHelper.SendStringToPrinter(cmbDestination.SelectedItem.ToString() ?? "", s + "\n");
                FileSystem.WriteAllText(txtFileName.Text, "", false);
            }

            if (chkBPP.Checked)
            {
                var ts = FileSystem.ReadAllText(txtBPPFile.Text);
                if (ts != "")
                {
                    printAEA(ts);
                    FileSystem.WriteAllText(txtBPPFile.Text, "", false);
                }
            }
        }

        public void printAEA(string text)
        {
            if(chkBPP.Checked)
            {
                if(aeaPrinter.IsOpen)
                {
                    aeaPrinter.Write($"{(Char)2}{text.Trim()}{(Char)3}");
                }
            }
        }

        private void btnTog_Click(object sender, EventArgs e)
        {
            if (btnTog.Text == "Start")
            {
                FileSystem.WriteAllText(txtFileName.Text, "", false);
                if(chkBPP.Checked)
                {
                    try
                    {
                        FileSystem.WriteAllText(txtBPPFile.Text, "", false);
                        aeaPrinter = new SerialPort();
                        aeaPrinter.PortName = txtBPPPort.Text;
                        aeaPrinter.Open();
                    } catch
                    {
                        MessageBox.Show("AEA Printer initialised fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                chkBPP.Enabled = false;
                btnTog.Text = "Stop";
                pbMarquee.Visible = true;
                tFileChecker.Start();
            } else
            {
                btnTog.Text = "Start";
                pbMarquee.Visible = false;
                chkBPP.Enabled = true;
                if (chkBPP.Checked)
                {
                    aeaPrinter.Close();
                    aeaPrinter.Dispose();
                }
                tFileChecker.Stop();
            }
        }

        private void btnSelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName ?? "";
            }
        }

        private void chkBPP_CheckedChanged(object sender, EventArgs e)
        {
            txtBPPFile.Enabled = chkBPP.Checked;
            txtBPPPort.Enabled = chkBPP.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtBPPFile.Text = ofd.FileName ?? "";
            }
        }
    }
}
public class RawPrinterHelper
{
    // Structure and API declarions:
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class DOCINFOA
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string pDocName;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pOutputFile;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pDataType;
    }
    [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

    [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool ClosePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

    [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool EndDocPrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool StartPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool EndPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
    public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

    // SendBytesToPrinter()
    // When the function is given a printer name and an unmanaged array
    // of bytes, the function sends those bytes to the print queue.
    // Returns true on success, false on failure.
    public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
    {
        Int32 dwError = 0, dwWritten = 0;
        IntPtr hPrinter = new IntPtr(0);
        DOCINFOA di = new DOCINFOA();
        bool bSuccess = false; // Assume failure unless you specifically succeed.

        di.pDocName = "My C#.NET RAW Document";
        di.pDataType = "RAW";

        // Open the printer.
        if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
        {
            // Start a document.
            if (StartDocPrinter(hPrinter, 1, di))
            {
                // Start a page.
                if (StartPagePrinter(hPrinter))
                {
                    // Write your bytes.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                    EndPagePrinter(hPrinter);
                }
                EndDocPrinter(hPrinter);
            }
            ClosePrinter(hPrinter);
        }
        // If you did not succeed, GetLastError may give more information
        // about why not.
        if (bSuccess == false)
        {
            dwError = Marshal.GetLastWin32Error();
        }
        return bSuccess;
    }

    public static bool SendFileToPrinter(string szPrinterName, string szFileName)
    {
        // Open the file.
        FileStream fs = new FileStream(szFileName, FileMode.Open);
        // Create a BinaryReader on the file.
        BinaryReader br = new BinaryReader(fs);
        // Dim an array of bytes big enough to hold the file's contents.
        Byte[] bytes = new Byte[fs.Length];
        bool bSuccess = false;
        // Your unmanaged pointer.
        IntPtr pUnmanagedBytes = new IntPtr(0);
        int nLength;

        nLength = Convert.ToInt32(fs.Length);
        // Read the contents of the file into the array.
        bytes = br.ReadBytes(nLength);
        // Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
        // Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
        // Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
        // Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes);
        return bSuccess;
    }
    public static bool SendStringToPrinter(string szPrinterName, string szString)
    {
        IntPtr pBytes;
        Int32 dwCount;
        // How many characters are in the string?
        dwCount = szString.Length;
        // Assume that the printer is expecting ANSI text, and then convert
        // the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString);
        // Send the converted ANSI string to the printer.
        bool success = SendBytesToPrinter(szPrinterName, pBytes, dwCount);
        Marshal.FreeCoTaskMem(pBytes);
        return success;
    }
}
