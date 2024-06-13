using System.Runtime.InteropServices;

namespace SGS.OAD.TscPrinter;

/*
 * 從 .NET 6 開始引入了新的 LibraryImport Attribute，一個更高效替代 DllImport 的方式。
 * 它可以在編譯時生成封送處理代碼，從而提高性能和可靠性。
 * P/Invoke 方法應該是 private 或 private，以限制其可見性，防止不必要的訪問。
 */

/// <summary>
/// 使用 LibraryImport Attribute 匯入 TSCLIB.dll
/// </summary>
public partial class TSC
{
    [LibraryImport("TSCLIB.dll", EntryPoint = "about")]
    private static partial int about();

    [LibraryImport("TSCLIB.dll", EntryPoint = "openport", StringMarshalling = StringMarshalling.Utf8)]
    private static partial int openport(string printername);

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "barcode", StringMarshalling = StringMarshalling.Utf8)]
    private static partial int barcode(string x, string y, string type, string height, string readable, string rotation, string narrow, string wide, string code);

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "clearbuffer")]
    private static partial int clearbuffer();

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "closeport")]
    private static partial int closeport();

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "downloadpcx", StringMarshalling = StringMarshalling.Utf8)]
    private static partial int downloadpcx(string filename, string image_name);

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "formfeed")]
    private static partial int formfeed();

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "nobackfeed")]
    private static partial int nobackfeed();

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "printerfont", StringMarshalling = StringMarshalling.Utf8)]
    private static partial int printerfont(string x, string y, string fonttype, string rotation, string xmul, string ymul, string text);

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "printlabel", StringMarshalling = StringMarshalling.Utf8)]
    private static partial int printlabel(string set, string copy);

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "sendcommand", StringMarshalling = StringMarshalling.Utf8)]
    private static partial int sendcommand(string printercommand);

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "setup", StringMarshalling = StringMarshalling.Utf8)]
    private static partial int setup(string width, string height, string speed, string density, string sensor, string vertical, string offset);

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "windowsfont", StringMarshalling = StringMarshalling.Utf8)]
    private static partial int windowsfont(int x, int y, int fontheight, int rotation, int fontstyle, int fontunderline, string szFaceName, string content);

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "windowsfontUnicode", StringMarshalling = StringMarshalling.Utf8)]
    private static partial int windowsfontUnicode(int x, int y, int fontheight, int rotation, int fontstyle, int fontunderline, string szFaceName, byte[] content);

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "sendBinaryData")]
    private static partial int sendBinaryData([In] byte[] content, int length);

    [LibraryImport(libraryName: "TSCLIB.dll", EntryPoint = "usbportqueryprinter")]
    private static partial byte usbportqueryprinter();
}
