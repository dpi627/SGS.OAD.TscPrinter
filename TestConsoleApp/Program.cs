using SGS.OAD.TscPrinter;

namespace TestConsoleApp;

internal class Program
{
    static void Main()
    {
        TSC.About(); // 顯示 DLL 版本(可測試串 DLL 是否正常)

        // 確認街上印表機才可啟用測試，注意印表機名稱要一致
        //PrintLimsLabelFormat1();
    }

    /// <summary>
    /// 列印 LIMS 標籤格式一
    /// </summary>
    private static void PrintLimsLabelFormat1()
    {
        bool IsDualPrint = true;
        PrintParam pp = SetPrintParam("AVO24600467", "(6/21)");

        try
        {
            // 初始化標籤機
            TSC.Build("TSC TTP-245", 73, 15);

            #region 設定列印內容
            SetContent_01(pp, 10, 10);
            if (IsDualPrint)
                SetContent_01(pp, 314, 10);
            #endregion

            // 列印標籤
            TSC.Print();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            // 釋放資源
            TSC.Dispose();
        }
    }

    /// <summary>
    /// 設定格式一列印內容
    /// </summary>
    private static void SetContent_01(PrintParam pp, int offsetX, int offsetY)
    {
        TSC.Qrcode(offsetX, offsetY, pp.Qrcode);
        TSC.Barcode(offsetX + 48, offsetY, pp.Barcode);
        TSC.WindowsFont(offsetX, offsetY + 48, pp.ORD_MID);
        TSC.WindowsFont(offsetX, offsetY + 80, pp.RPT_DATE, 24);
    }

    /// <summary>
    /// 設定列印參數
    /// </summary>
    private static PrintParam SetPrintParam(string OrdMid, string RptDate)
    {
        return new PrintParam(OrdMid, RptDate, OrdMid, OrdMid);
    }

    /// <summary>
    /// 精簡版列印參數模型
    /// </summary>
    private record PrintParam(string ORD_MID, string RPT_DATE, string Qrcode, string Barcode);
}
