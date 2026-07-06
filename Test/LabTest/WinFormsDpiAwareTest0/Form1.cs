using System.Diagnostics;
using System.Reflection;

namespace WinFormsDpiAwareTest0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void CreateHandle()
        {
            SetFormDpiAware(this);
            base.CreateHandle();
        }

        public static void SetFormDpiAware(Form form)
        {
            FieldInfo fieldInfo1 = typeof(Control).GetField("_window", BindingFlags.Instance | BindingFlags.NonPublic)!;
            FieldInfo fieldInfo2 = typeof(NativeWindow).GetField(ReflectionHelpers.PropertyBackingFieldName("DpiAwarenessContext"), BindingFlags.Instance | BindingFlags.NonPublic)!;
            Type type1 = fieldInfo2.FieldType;
            FieldInfo[] valueInfos = type1.GetFields(BindingFlags.Static | BindingFlags.NonPublic);
            fieldInfo2.SetValue(fieldInfo1.GetValue(form), valueInfos[3].GetValue(null));
        }
    }
}
