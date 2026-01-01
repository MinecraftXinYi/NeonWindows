using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Modern.Core;

public unsafe static class CoreUITextInputNativeApi
{
    /// <summary>
    /// 为指定的 ITextInputConsumer 对象创建 ITextInputProducer 对象。
    /// </summary>
    /// <param name="pTextInputConsumer">TextInputConsumer 对象的指针。</param>
    /// <param name="pTextInputProducer">TextInputProducer 对象的指针。</param>
    /// <returns>**HRESULT**</returns>
    public static int PrivateCreateTextInputProducer(nint pTextInputConsumer, out nint pTextInputProducer)
    {
        fixed (nint* ppTextInputProducer = &pTextInputProducer)
            return PrivateCreateTextInputProducer(pTextInputConsumer, ppTextInputProducer);
    }

    /// <summary>
    /// 为指定的 ITextInputConsumer 对象创建 ITextInputProducer 对象。
    /// </summary>
    /// <param name="pTextInputConsumer">TextInputConsumer 对象的指针。</param>
    /// <param name="ppTextInputProducer">用于接收 TextInputProducer 对象的指针。</param>
    /// <returns>**HRESULT**</returns>
    [DllImport(WinRTDllName.WindowsUICoreTextInput, EntryPoint = "#1500")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern int PrivateCreateTextInputProducer(nint pTextInputConsumer, nint* ppTextInputProducer);
}
