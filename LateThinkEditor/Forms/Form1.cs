using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LateThinkEditor
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class Form1 : Form
    {
        const string FILTER = "JSONファイル(*.json)|*.json";
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = puzzles;
            saveFileDialog1.Filter = FILTER;
            openFileDialog1.Filter = FILTER;
            ResetFont();
        }
        BindingList<Puzzle> puzzles = new BindingList<Puzzle>();
        string filePath = "";
        private void button1_Click(object sender, EventArgs e)
        {
            var item = (Puzzle)listBox1.SelectedItem;
            if(item != null)
            {
                var editor = new PuzzleEditor(item);
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    puzzles.Remove(item);
                    puzzles.Insert(0, editor.NewPuzzle);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("タイトルは必須です。");
                return;
            }
            else if (puzzles.Any(x=>x.Title == textBox1.Text))
            {
                MessageBox.Show("同じタイトルの問題が既に存在します。");
                return;
            }
            var puzzle = new Puzzle()
            {
                Title = textBox1.Text
            };
            puzzles.Add(puzzle);
        }

        private void 名前を付けて保存AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile(saveFileDialog1.FileName);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath != "")
            {
                var res = MessageBox.Show("現在のデータを保存しますか？", "未保存データ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        SaveFile(saveFileDialog1.FileName);
                    }
                }
                else if (res == DialogResult.No)
                {
                    OpenFile();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                OpenFile();
            }
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void オプションOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SettingWindow();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
            }
            ResetFont();
        }
        private new void ResetFont()
        {
            Font = new Font(Properties.Settings.Default.FontStyle, Properties.Settings.Default.FontSize);
        }
        private void OpenFile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                puzzles.Clear();
                var data = System.IO.File.ReadAllText(openFileDialog1.FileName);
                foreach (var item in JsonConvert.DeserializeObject<List<string>>(data))
                {
                    puzzles.Add(Puzzle.FromJSONString(item));
                }
                filePath = openFileDialog1.FileName;
            }
        }
        private void SaveFile(string path)
        {
            System.IO.File.WriteAllText(path,JsonConvert.SerializeObject(puzzles.Select(x => x.ToString())).ToString());
        }

        private void 上書き保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 新規作成NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath != "")
            {
                var res = MessageBox.Show("現在のデータを保存しますか？", "未保存データ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        SaveFile(saveFileDialog1.FileName);
                    }
                }
            }
            filePath = "";
            puzzles.Clear();
        }


        private void 上書き保存SToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (filePath =="")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveFile(saveFileDialog1.FileName);
                }
            }
            else
            {
                SaveFile(filePath);
            }
        }
    }
}
