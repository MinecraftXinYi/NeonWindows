using System.Runtime.InteropServices;

namespace NeonWindows.ABI.UI.Composition;

/// <summary>
/// Describes a key/value pair that specifies a window composition attribute and its value.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct WindowCompositionAttribData
{
    /// <summary>
    /// A flag describing which value to get or set, specified as a value of the <see cref="WindowCompositionAttrib"/> enumeration.
    /// This parameter specifies which attribute to get or set, and the pvData member points to an object containing the attribute value.
    /// </summary>
    public WindowCompositionAttrib Attrib;

    /// <summary>
    /// When used with the GetWindowCompositionAttribute function, this member contains a pointer to a variable that will hold the value of the requested attribute when the function returns.
    /// When used with the SetWindowCompositionAttribute function, it points an object containing the attribute value to set.
    /// The type of the value set depends on the value of the Attrib member.
    /// For information about what type of value you should pass a pointer to in the pvData member, see <see cref="WindowCompositionAttrib"/>.
    /// </summary>
    public void* pvData;

    /// <summary>
    /// The size of the object pointed to by the pvData member, in bytes.
    /// </summary>
    public uint cbData;
}
