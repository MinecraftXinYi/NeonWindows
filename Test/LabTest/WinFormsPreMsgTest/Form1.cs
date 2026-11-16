namespace WinFormsPreMsgTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            Console.WriteLine("Form" + " " + msg.ToString());
            return base.PreProcessMessage(ref msg);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            Console.WriteLine("Form" + " " + "VisibleChanged");
            base.OnVisibleChanged(e);
        }
    }
}
