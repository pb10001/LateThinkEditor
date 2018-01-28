using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LateThinkEditor
{
    /// <summary>
    /// 問題を編集するフォーム
    /// </summary>
    public partial class PuzzleEditor : Form
    {
        /// <summary>
        /// 問題を引数にとるコンストラクタ
        /// </summary>
        /// <param name="p"></param>
        public PuzzleEditor(Puzzle p)
        {
            InitializeComponent();
            prevPuzzle = p;
            NewPuzzle = new Puzzle(p);
            Text = NewPuzzle.Title;
            richTextBox1.Text = NewPuzzle.Content;
            richTextBox2.Text = NewPuzzle.Solution;
            textBox1.DataBindings.Add("Text", NewPuzzle, "Title");
            richTextBox1.DataBindings.Add("Text", NewPuzzle, "Content");
            richTextBox2.DataBindings.Add("Text", NewPuzzle, "Solution");
            Font = new Font(Properties.Settings.Default.FontStyle, Properties.Settings.Default.FontSize);
        }
        Puzzle prevPuzzle;
        /// <summary>
        /// 編集後の問題
        /// </summary>
        public Puzzle NewPuzzle { get; private set; }
        private void PuzzleEditor_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
