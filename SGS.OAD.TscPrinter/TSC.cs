
namespace SGS.OAD.TscPrinter;

/// <summary>
/// 封裝 TSC 標籤機列印方法
/// </summary>
public partial class TSC
{
    /// <summary>
    /// 建置並初始化標籤機列印
    /// </summary>
    /// <param name="printerName">印表機名稱</param>
    /// <param name="labelWidth">標籤寬度</param>
    /// <param name="labelHeight">標籤高度</param>
    /// <param name="option">其他列印選項(非必要)</param>
    public static void Build(string printerName, int labelWidth, int labelHeight, BuildOption? option = default)
    {
        option = (option == default) ? new BuildOption() : option;

        OpenPort(printerName);
        Setup(labelWidth, labelHeight, option.speed, option.density, option.sensor, option.vertical, option.offset);
        ClearBuffer();
    }

    /// <summary>
    /// 列印標籤
    /// </summary>
    /// <param name="set">列印組數</param>
    /// <param name="copy">列印份數</param>
    /// <param name="IsClearBuffer">是否清除緩衝</param>
    public static void Print(int set = 1, int copy = 1, bool IsClearBuffer = true)
    {
        PrintLabel(set, copy);
        if (IsClearBuffer)
            ClearBuffer();
    }

    /// <summary>
    /// 釋放標籤機列印資源
    /// </summary>
    public static void Dispose()
    {
        ClearBuffer();
        ClosePort();
    }
}
