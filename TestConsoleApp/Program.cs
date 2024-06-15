using SGS.OAD.TscPrinter;

namespace TestConsoleApp;

internal class Program
{
    static void Main()
    {
        //Console.WriteLine("Hello, World!");
        //TSC.About();
        PrintLimsLabelFormat1();
    }

    private static void PrintLimsLabelFormat2()
    {
        bool IsDualPrint = true;
        PrintParam pp = SetPrintParam("AVO24600467", "(6/21)");

        TSC.OpenPort("TSC TTP-245");
        TSC.Setup(73, 15);
        TSC.ClearBuffer();

        SetContent_01(pp, 10, 10);
        if (IsDualPrint)
            SetContent_01(pp, 314, 10);

        TSC.PrintLabel();
        TSC.ClearBuffer();
        TSC.ClosePort();
    }

    private static void PrintLimsLabelFormat1()
    {
        bool IsDualPrint = true;
        PrintParam pp = SetPrintParam("AVO24600467", "(6/21)");

        try
        {
            TSC.Build("TSC TTP-245", 73, 15);

            SetContent_01(pp, 10, 10);
            if (IsDualPrint)
                SetContent_01(pp, 314, 10);

            TSC.Print();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            TSC.Dispose();
        }
    }

    private static void SetContent_01(PrintParam pp, int offsetX, int offsetY)
    {
        TSC.Qrcode(offsetX, offsetY, pp.Qrcode);
        TSC.Barcode(offsetX + 48, offsetY, pp.Barcode);
        TSC.WindowsFont(offsetX, offsetY + 48, pp.ORD_MID);
        TSC.WindowsFont(offsetX, offsetY + 80, pp.RPT_DATE, 24);
    }

    private static PrintParam SetPrintParam(string OrdMid, string RptDate)
    {
        return new PrintParam(OrdMid, RptDate, OrdMid, OrdMid);
    }

    private record PrintParam(string ORD_MID, string RPT_DATE, string Qrcode, string Barcode);
}
