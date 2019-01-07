using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QEdit
{
    public partial class EditorWindow : Form
    {
        private int fontSize = 14;

        public EditorWindow()
        {
            InitializeComponent();
            setFontSize(fontSize);
        }

        public void setFontSize(int size)
        {
            Font f = new Font("Consolas", (float)size);
            input.Font = f;
            output.Font = f;
        }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void update() {
            string o = Program.process(input.Text);
            output.Text = o;
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.OemMinus)
            {
                fontSize -= 2;
                if (fontSize < 8) fontSize = 8;
                setFontSize(fontSize);
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.Oemplus)
            {
                fontSize += 2;
                if (fontSize > 48) fontSize = 48;
                setFontSize(fontSize);
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.D1) {
                Program.defaultFirstCase = Program.low;
                Program.defaultCase = Program.low;
                Program.defaultGlue = Program.concat;
                update();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.D2) {
                Program.defaultFirstCase = Program.low;
                Program.defaultCase = Program.low;
                Program.defaultGlue = Program.snake;
                update();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.D3) {
                Program.defaultFirstCase = Program.low;
                Program.defaultCase = Program.title;
                Program.defaultGlue = Program.concat;
                update();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.D4) {
                Program.defaultFirstCase = Program.title;
                Program.defaultCase = Program.title;
                Program.defaultGlue = Program.concat;
                update();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.D5) {
                Program.defaultFirstCase = Program.high;
                Program.defaultCase = Program.high;
                Program.defaultGlue = Program.snake;
                update();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.D6) {
                Program.defaultFirstCase = Program.high;
                Program.defaultCase = Program.high;
                Program.defaultGlue = Program.concat;
                update();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.D7) {
                Program.defaultFirstCase = Program.low;
                Program.defaultCase = Program.low;
                Program.defaultGlue = Program.hyphen;
                update();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.D0) {
                Program.subs = Program.loadSubstitutions();
                update();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.S) {
                string o = Program.process(input.Text, true);
                Clipboard.Clear();
                Clipboard.SetText(o);

                input.Text = "";
                update();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.D8) {
                Program.debugWords = !Program.debugWords;
            }

            if (e.Control && e.KeyCode == Keys.D9) {
                openFileDialog1.ShowDialog();
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {
            Program.substitutionsFile = openFileDialog1.FileName;
            Program.subs = Program.loadSubstitutions();
            update();
        }
    }
}
