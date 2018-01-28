using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            richTextBox1.TextChanged += RichTextBox_TextChanged;
            richTextBox2.TextChanged += RichTextBox_TextChanged;
            textBox1.DataBindings.Add("Text", NewPuzzle, "Title");
            richTextBox1.DataBindings.Add("Text", NewPuzzle, "Content");
            richTextBox2.DataBindings.Add("Text", NewPuzzle, "Solution");
            Font = new Font(Properties.Settings.Default.FontStyle, Properties.Settings.Default.FontSize);
            richTextBox1.Text = NewPuzzle.Content;
            richTextBox2.Text = NewPuzzle.Solution;
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

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            var box = (RichTextBox)sender;
            var array = box.Text.Split('\n');
            Stack<Analysis> stack = new Stack<Analysis>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "")
                    continue;
                if(array[i][0] != '#')
                {
                    var analysis = new Analysis(array[i]);
                    stack.Push(analysis);
                }
                else
                {
                    if (stack.Count == 0)
                        continue;
                    var a = stack.Pop();
                    var cmt = array[i].Replace("#","").Split(' ');
                    if (cmt.Length <= 1)
                    {
                        stack.Push(a);
                        continue;
                    }
                    switch (cmt[0])
                    {
                        case "ch":
                            a.Charm = cmt[1];
                            break;
                        case "tr":
                            a.Trick = cmt[1];
                            break;
                        case "ve":
                            a.Veil = cmt[1];
                            break;
                        case "cl":
                            a.Clue = cmt[1];
                            break;
                        case "my":
                            a.Mystery = cmt[1];
                            break;
                        default:
                            break;
                    }
                    stack.Push(a);
                }
            }
            var list = stack.ToList();
            list.Reverse();
            if (box.Name == "richTextBox1")
            {
                NewPuzzle.ContentAnalysis.Clear();
                NewPuzzle.ContentAnalysis.AddRange(list);
                webBrowser1.DocumentText = "<style>a{cursor:pointer;}a:hover{color:red;}</style>" + string.Join("", NewPuzzle.ContentAnalysis);
            }
            else
            {
                NewPuzzle.SolutionAnalysis.Clear();
                NewPuzzle.SolutionAnalysis.AddRange(list);
                webBrowser2.DocumentText = "<style>a{cursor:pointer;}a:hover{color:red;}</style>" + string.Join("", NewPuzzle.SolutionAnalysis);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Join("\n", NewPuzzle.ContentAnalysis.Select(x=>x.Text)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(string.Join("\n", NewPuzzle.SolutionAnalysis.Select(x => x.Text)));
        }
    }
}
