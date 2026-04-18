using Windows.UI;

namespace NeonWindows.UI.Modern;

/// <summary>
/// 提供用于处理 Color 值的静态帮助方法。
/// </summary>
public static class ColorHelper2
{
    /// <summary>
    /// 检测颜色是否可以归类为浅色。
    /// </summary>
    /// <param name="color">要检测的颜色。</param>
    /// <returns>是否可以归类为浅色。</returns>
    public static bool IsColorLight(this Color color)
        => ((5 * color.G) + (2 * color.R) + color.B) > (8 * 128);
}
