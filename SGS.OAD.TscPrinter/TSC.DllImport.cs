using System.Runtime.InteropServices;

namespace SGS.OAD.TscPrinter;

/// <summary>
/// 使用 DllImport Attribute 匯入 TSCLIB.dll
/// </summary>
public partial class TSC
{
    private const string _dll = "TSCLIB.dll";

    [DllImport(_dll)]
    private static extern int about();

    [DllImport(_dll)]
    private static extern int openport(string printername);

    [DllImport(_dll)]
    private static extern int barcode(string x, string y, string type, string height, string readable, string rotation, string narrow, string wide, string code);

    [DllImport(_dll)]
    private static extern int clearbuffer();

    [DllImport(_dll)]
    private static extern int closeport();

    [DllImport(_dll)]
    private static extern int printlabel(string set, string copy);

    [DllImport(_dll)]
    private static extern int sendcommand(string printercommand);

    [DllImport(_dll)]
    private static extern int setup(string width, string height, string speed, string density, string sensor, string vertical, string offset);

    [DllImport(_dll)]
    private static extern int windowsfont(int x, int y, int fontheight, int rotation, int fontstyle, int fontunderline, string szFaceName, string content);

    [DllImport(_dll, CharSet = CharSet.Unicode)]
    private static extern int windowsfontUnicode(int x, int y, int fontheight, int rotation, int fontstyle, int fontunderline, string szFaceName, byte[] content);

    [DllImport(_dll)]
    private static extern int downloadpcx(string filename, string image_name);

    [DllImport(_dll)]
    private static extern int formfeed();

    [DllImport(_dll)]
    private static extern int nobackfeed();

    [DllImport(_dll)]
    private static extern int printerfont(string x, string y, string fonttype, string rotation, string xmul, string ymul, string text);

    [DllImport(_dll)]
    private static extern int sendBinaryData([In] byte[] content, int length);

    [DllImport(_dll)]
    private static extern byte usbportqueryprinter();
}
