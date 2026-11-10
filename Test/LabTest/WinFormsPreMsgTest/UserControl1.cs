using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsPreMsgTest
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            Console.WriteLine("Control" + msg.ToString());
            return base.PreProcessMessage(ref msg);
        }
    }
}
