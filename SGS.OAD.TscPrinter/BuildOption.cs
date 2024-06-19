namespace SGS.OAD.TscPrinter;

/// <summary>
/// TSC 標籤印表機的建置選項，預設值為 LIMS 設定
/// </summary>
/// <param name="speed">印表機的速度。單位為英寸/秒（ips），範圍 1~12</param>
/// <param name="density">列印濃度，範圍 0~15</param>
/// <param name="sensor">感應器模式，0連續，1間隔，2黑標</param>
/// <param name="vertical">垂直間距</param>
/// <param name="offset">水平偏移量</param>
public record BuildOption(int speed = 2, int density = 4, int sensor = 0, int vertical = 3, int offset = 0);
