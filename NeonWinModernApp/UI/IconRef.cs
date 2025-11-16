using System;
using System.Diagnostics;

namespace NeonWindows.UI;

[DebuggerDisplay("{Value}")]
public unsafe readonly struct IconRef : IEquatable<IconRef>
{
    public readonly void* Value;

    public IconRef(void* value) => this.Value = value;

    public IconRef(IntPtr value) : this((void*)value)
    {
    }

    public static IconRef Null => default;

    public bool IsNull => Value == default;

    public static implicit operator void*(IconRef value) => value.Value;

    public static explicit operator IconRef(void* value) => new(value);

    public static bool operator ==(IconRef left, IconRef right) => left.Value == right.Value;

    public static bool operator !=(IconRef left, IconRef right) => !(left == right);

    public bool Equals(IconRef other) => this.Value == other.Value;

    public override bool Equals(object obj) => obj is IconRef other && this.Equals(other);

    public override int GetHashCode() => unchecked((int)this.Value);

    public override string ToString() => $"0x{(nuint)this.Value:x}";

    public static implicit operator IntPtr(IconRef value) => new(value.Value);

    public static explicit operator IconRef(IntPtr value) => new(value.ToPointer());

    public static explicit operator IconRef(UIntPtr value) => new(value.ToPointer());
}
