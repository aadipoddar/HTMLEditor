using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//for reading and writing files
using System.IO;

namespace LiveHTMLEditor
{
    public partial class Form1 : Form
    {
        //we will store a current open file  as  a variable
        public string currentFile = null;

        public Form1()
        {
            InitializeComponent();

            //We added Fast Colored Textbox component to project for code highlighting in code box
            //now adding the code editor fieldto form 

            //we added a split container and placed a code editor with web browser in it
            //now user will be allowed to split these panels(code editor and browser)
            //panels can be resized 

            //we just need to change the language property to HTML to highlight it

            //we added a text changed eventfor code editor and update a web browser content

            ///we added options, like : save,open , new , cut , copy , paste , etc..
            //we aaded them to menustrip
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            //we set a content of web browser to code editor field text
            webBrowser1.DocumentText = fastColoredTextBox1.Text;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete the current code?", "New", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //delete all code 
                fastColoredTextBox1.Clear();

                //set current file to nothing
                currentFile = null;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show message to be sure that user wants to delete the code
            if (MessageBox.Show("Do you really want to delete the current code?", "Open", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Open menu with file choosing 
                OpenFileDialog op = new OpenFileDialog();
                //filter
                op.Filter = "HTML File|*.html|Any File|*.*";

                if (op.ShowDialog() == DialogResult.OK)
                {
                    //read choosed file
                    StreamReader sr = new StreamReader(op.FileName);

                    //set current file from choosed
                    currentFile = op.FileName;

                    //readed text set to code editor
                    fastColoredTextBox1.Text = sr.ReadToEnd();
                    //stop reading file
                    sr.Close();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currentFile != null)
            {
                //Write text to file 
                StreamWriter sw = new StreamWriter(currentFile);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save menu
            SaveFileDialog op = new SaveFileDialog();
            //filter
            op.Filter = "HTML File|*.html|Any File|*.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                //write choosed file
                StreamWriter sr = new StreamWriter(op.FileName);

                //set current file from choosed
                currentFile = op.FileName;

                //write code to file
                sr.Write(fastColoredTextBox1.Text);
                //stop reading file
                sr.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete the current code and exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowFindDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }
    }
}
