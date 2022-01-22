using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TickTacToe
{
    public partial class Info : Form
    {
               

        public Info()
        {
            InitializeComponent();
        }

        public Info(int x, int y)
        {
            InitializeComponent();
            CenterToParent();
            SetDesktopLocation(x, y);
        }

        public void give_text(string s)
        {
            textBox1.AppendText(s);
        }
    }
}
