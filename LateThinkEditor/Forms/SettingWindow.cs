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
    /// 設定のためのフォーム
    /// </summary>
    public partial class SettingWindow : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SettingWindow()
        {
            InitializeComponent();
            fontDialog1.Font = new Font(Properties.Settings.Default.FontStyle, Properties.Settings.Default.FontSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.FontSize = fontDialog1.Font.Size;
                Properties.Settings.Default.FontStyle = fontDialog1.Font.Name;
                Properties.Settings.Default.Save();
            }
        }

        private void SettingWindow_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
