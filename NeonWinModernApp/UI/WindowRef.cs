using System;
using System.Diagnostics;

namespace NeonWindows.UI;

[DebuggerDisplay("{Value}")]
public unsafe readonly struct WindowRef : IEquatable<WindowRef>
{
    public readonly void* Value;

    public WindowRef(void* value) => this.Value = value;

    public WindowRef(IntPtr value) : this((void*)value)
    {
    }

    public static WindowRef Null => default;

    public bool IsNull => Value == default;

    public static implicit operator void*(WindowRef value) => value.Value;

    public static explicit operator WindowRef(void* value) => new(value);

    public static bool operator ==(WindowRef left, WindowRef right) => left.Value == right.Value;

    public static bool operator !=(WindowRef left, WindowRef right) => !(left == right);

    public bool Equals(WindowRef other) => this.Value == other.Value;

    public override bool Equals(object obj) => obj is WindowRef other && this.Equals(other);

    public override int GetHashCode() => unchecked((int)this.Value);

    public override string ToString() => $"0x{(nuint)this.Value:x}";

    public static implicit operator IntPtr(WindowRef value) => new(value.Value);

    public static explicit operator WindowRef(IntPtr value) => new(value.ToPointer());

    public static explicit operator WindowRef(UIntPtr value) => new(value.ToPointer());
}
