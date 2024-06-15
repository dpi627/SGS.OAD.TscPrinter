using System.Text;

namespace SGS.OAD.TscPrinter
{
    /// <summary>
    /// 重新封裝 dll 方法，部分公開
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
        public static int OpenPort(string printerName) => openport(printerName);

        /// <summary>
        /// 關閉連接埠
        /// </summary>
        public static int ClosePort() => closeport();

        /// <summary>
        /// 清除緩衝區
        /// 如列印(呼叫PrintLabel)多種不同標籤，每次列印前須清除緩衝區
        /// 如同一份標籤連續列印多份(多次呼叫PrintLabel)，不須清除
        /// </summary>
        public static int ClearBuffer() => clearbuffer();

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
        public static int Setup(int width, int height, int speed = 2, int density = 4, int sensor = 0, int vertical = 3, int offset = 0) =>
                setup($"{width}", $"{height}", $"{speed}", $"{density}", $"{sensor}", $"{vertical}", $"{offset}");

        public static int SendCommand(string command) => sendcommand(command);

        /// <summary>
        /// 列印標籤，預設一組一份
        /// </summary>
        /// <param name="set">列印幾組</param>
        /// <param name="copy">每組列印幾份</param>
        public static int PrintLabel(int set = 1, int copy = 1) => printlabel($"{set}", $"{copy}");

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
        public static int Barcode(int x, int y, string date, int narrow = 1, int wide = 1, int height = 50, int type = 128, int readable = 0, int rotation = 0) =>
            barcode($"{x}", $"{y}", $"{type}", $"{height}", $"{readable}", $"{rotation}", $"{narrow}", $"{wide}", $"{date}");

        /// <summary>
        /// 列印 QR Code (使用 sendcommand)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="data"></param>
        /// <param name="eccLevel">錯誤修正等級 (L, M, Q, H)</param>
        /// <param name="size">單元寬度</param>
        /// <param name="mode">模式 (A: 自動模式)</param>
        /// <param name="rotation">旋轉角度</param>
        public static int Qrcode(int x, int y, string data, int size = 2, string eccLevel = "L", string mode = "A", int rotation = 0) =>
            sendcommand(@$"QRCODE {x},{y},{eccLevel},{size},{mode},{rotation},""{data}""");

        /// <summary>
        /// 使用 Windows 字型列印文字
        /// </summary>
        /// <param name="x">起始點的 X 座標。</param>
        /// <param name="y">起始點的 Y 座標。</param>
        /// <param name="data">要列印的文字內容。</param>
        /// <param name="fontSize">字型的高度。</param>
        /// <param name="fontFamily">字型的名稱。</param>
        /// <param name="rotation">文字的旋轉角度。</param>
        /// <param name="style">字型的樣式。</param>
        /// <param name="underline">指定字型是否要有底線。</param>
        /// <returns>操作的結果代碼。</returns>
        public static int WindowsFont(int x, int y, string data, int fontSize = 32, string fontFamily = "Times New Roman", int rotation = 0, int style = 0, int underline = 0) =>
            windowsfont(x, y, fontSize, rotation, style, underline, fontFamily, data);

        /// <summary>
        /// 使用 Windows 字型列印文字
        /// </summary>
        /// <param name="x">起始點的 X 座標。</param>
        /// <param name="y">起始點的 Y 座標。</param>
        /// <param name="data">要列印byte[]?內容。</param>
        /// <param name="fontSize">字型的高度。</param>
        /// <param name="fontFamily">字型的名稱。</param>
        /// <param name="rotation">文字的旋轉角度。</param>
        /// <param name="style">字型的樣式。</param>
        /// <param name="underline">指定字型是否要有底線。</param>
        /// <returns>操作的結果代碼。</returns>
        public static int WindowsFontUnicode(int x, int y, string data, int fontSize = 32, string fontFamily = "Times New Roman", int rotation = 0, int style = 0, int underline = 0)
        {
            byte[]? bytes = Encoding.Unicode.GetBytes(data);
            return windowsfontUnicode(x, y, fontSize, rotation, style, underline, fontFamily, bytes);
        }
    }
}
