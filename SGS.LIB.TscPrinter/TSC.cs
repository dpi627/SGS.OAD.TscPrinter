using System.Text;

namespace SGS.LIB.TscPrinter;

/// <summary>
/// 封裝 TSCLIB.dll 的所有方法為 public static 方法
/// 包含部分自定義方法並將參數轉型與添加預設值
/// </summary>
public partial class TSC
{
    /// <summary>
    /// 顯示DLL版本
    /// </summary>
    public static int About() => about();

    /// <summary>
    /// 指定電腦端的輸出連接埠
    /// </summary>
    /// <param name="printername">本機印表機請直接填入名稱，網路印表機請填路徑與共享名稱，例如「\\SERVER\TTP245」</param>
    public static int OpenPort(string printername) => openport(printername);

    /// <summary>
    /// 使用條碼機內建條碼列印
    /// </summary>
    /// <param name="x">條碼 X 方向起始點，以點(POINT)表示。</param>
    /// <param name="y">條碼 X 方向起始點，以點(POINT)表示。</param>
    /// <param name="type">字串型別 (用什麼字型，例如 39 或 128)</param>
    /// <param name="height">條碼高度</param>
    /// <param name="readable">是否印條碼碼文 (0：不印｜1:印)</param>
    /// <param name="rotation">條碼旋轉角度 (0, 90, 180, 270)</param>
    /// <param name="narrow">設定條碼窄bar比例因子 (詳細請參考TSPL)</param>
    /// <param name="wide">設定條碼寬bar比例因子 (詳細請參考TSPL)</param>
    /// <param name="data">條碼內容 (輸出的內容字串，例如報告編號)</param>
    public static int Barcode(
        int x,
        int y,
        string data,
        int narrow = 2,
        int wide = 2,
        int height = 40,
        int type = 128,
        int readable = 0,
        int rotation = 0

        ) =>
        barcode(x.ToString(), y.ToString(), type.ToString(), height.ToString(), readable.ToString(), rotation.ToString(), narrow.ToString(), wide.ToString(), data ?? "");

    /// <summary>
    /// 清除緩衝區
    /// 如列印(呼叫PrintLabel)多種不同標籤，每次列印前須清除緩衝區
    /// 如同一份標籤連續列印多份(多次呼叫PrintLabel)，不須清除
    /// </summary>
    /// <returns></returns>
    public static int ClearBuffer() => clearbuffer();

    /// <summary>
    /// 關閉連接埠
    /// </summary>
    /// <returns></returns>
    public static int ClosePort() => closeport();

    public static int DownloadPCX(string filename, string image_name) => downloadpcx(filename, image_name);

    public static int FormFeed() => formfeed();

    public static int NobackFeed() => nobackfeed();

    public static int PrinterFont(string x, string y, string fonttype, string rotation, string xmul, string ymul, string text) =>
        printerfont(x, y, fonttype, rotation, xmul, ymul, text);

    /// <summary>
    /// 列印標籤，預設一組一份
    /// </summary>
    /// <param name="set">列印幾組</param>
    /// <param name="copy">每組列印幾份</param>
    /// <returns></returns>
    public static int PrintLabel(
        int set = 1,
        int copy = 1)
    {
        return printlabel(set.ToString(), copy.ToString());
    }

    public static int SendCommand(string printercommand) => sendcommand(printercommand);

    /// <summary>
    /// 列印 QR Code (使用 sendcommand)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="data"></param>
    /// <param name="eccLevel">錯誤修正等級 (L, M, Q, H)</param>
    /// <param name="cellWidth">單元寬度</param>
    /// <param name="mode">模式 (A: 自動模式)</param>
    /// <param name="rotation">旋轉角度</param>
    /// <returns></returns>
    public static int QRCode(
        int x,
        int y,
        string data,
        int cellWidth = 3,
        string eccLevel = "L",
        string mode = "A",
        int rotation = 0)
    {
        string cmd = $"QRCODE {x},{y},{eccLevel},{cellWidth},{mode},{rotation},\"{data}\"";
        return sendcommand(cmd);
    }

    /// <summary>
    /// Setup printer
    /// </summary>
    /// <param name="width">標籤紙寬(mm)</param>
    /// <param name="height">標籤紙高(mm)</param>
    /// <param name="speed">列印速度，單位為英吋/秒</param>
    /// <param name="density">列印濃度，範圍從 0 到 15</param>
    /// <param name="sensor">感測器類型，0 表示間隙感測器，1 表示黑標感測器</param>
    /// <param name="vertical"></param>
    /// <param name="offset">感測器偏移量，單位為點</param>
    /// <returns></returns>
    public static int Setup(
        int width,
        int height,
        int speed = 3,
        int density = 4,
        int sensor = 0,
        int vertical = 3,
        int offset = 0)
    {
        // 標籤寬高 80點/cm = 8點/mm)
        width *= 8;
        height *= 8;
        return setup(width.ToString(), height.ToString(), speed.ToString(), density.ToString(), sensor.ToString(), vertical.ToString(), offset.ToString());
    }

    /// <summary>
    /// 使用 Windows 字型列印文字
    /// </summary>
    /// <param name="x">起始點的 X 座標。</param>
    /// <param name="y">起始點的 Y 座標。</param>
    /// <param name="content">要列印的文字內容。</param>
    /// <param name="fontheight">字型的高度。</param>
    /// <param name="szFaceName">字型的名稱。</param>
    /// <param name="rotation">文字的旋轉角度。</param>
    /// <param name="fontstyle">字型的樣式。</param>
    /// <param name="fontunderline">指定字型是否要有底線。</param>
    /// <returns>操作的結果代碼。</returns>
    public static int WindowsFont(
        int x,
        int y,
        string content,
        int fontheight = 24,
        string szFaceName = "Consolas",
        int rotation = 0,
        int fontstyle = 0,
        int fontunderline = 0)
    {
        return windowsfont(x, y, fontheight, rotation, fontstyle, fontunderline, szFaceName, content);
    }

    /// <summary>
    /// 使用Windows字型列印Unicode文字
    /// </summary>
    /// <param name="x">起始點的X座標。</param>
    /// <param name="y">起始點的Y座標。</param>
    /// <param name="fontheight">字型的高度。</param>
    /// <param name="rotation">文字的旋轉角度。</param>
    /// <param name="fontstyle">字型的樣式。</param>
    /// <param name="fontunderline">指定字型是否要有底線。</param>
    /// <param name="szFaceName">字型的名稱。</param>
    /// <param name="content">要列印的文字內容。</param>
    /// <returns>操作的結果代碼。</returns>
    public static int WindowsFontUnicode(
        int x,
        int y,
        string content,
        int fontheight = 24,
        string szFaceName = "Microsoft JhengHei UI",
        int rotation = 0,
        int fontstyle = 0,
        int fontunderline = 0)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(content);
        return windowsfontUnicode(x, y, fontheight, rotation, fontstyle, fontunderline, szFaceName, bytes);
    }

    public static int SendBinaryData(byte[] content, int length) => sendBinaryData(content, length);

    public static byte UsbPortQueryPrinter() => usbportqueryprinter();
}
