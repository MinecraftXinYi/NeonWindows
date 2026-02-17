using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern.Core;

public static class CoreUITextInputApi
{
    /// <summary>
    /// 为指定的 ITextInputConsumer 对象创建 ITextInputProducer 对象。
    /// </summary>
    /// <param name="pTextInputConsumer">TextInputConsumer 对象的指针。</param>
    /// <param name="pTextInputProducer">TextInputProducer 对象的指针。</param>
    /// <returns>**HRESULT**</returns>
    [DllImport(WinRTDllName.WindowsUICoreTextInput, EntryPoint = "#1500", ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int PrivateCreateTextInputProducer(nint pTextInputConsumer, out nint pTextInputProducer);
}
