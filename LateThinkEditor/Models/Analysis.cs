using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateThinkEditor
{
    /// <summary>
    /// 問題の分析
    /// </summary>
    public class Analysis
    {
        /// <summary>
        /// デフォルトのコンストラクタ
        /// </summary>
        public Analysis() { }
        public Analysis(string text)
        {
            Text = text;
        }
        /// <summary>
        /// 問題/解説の一部分
        /// </summary>
        public string Text { get; set; } = "";
        /// <summary>
        /// チャーム
        /// </summary>
        public string Charm { get; set; } = "";
        /// <summary>
        /// トリック
        /// </summary>
        public string Trick { get; set; } = "";
        /// <summary>
        /// ベール
        /// </summary>
        public string Veil { get; set; } = "";
        /// <summary>
        /// クルー
        /// </summary>
        public string Clue { get; set; } = "";

        /// <summary>
        /// 謎
        /// </summary>
        public string Mystery { get; set; } = "";
        /// <summary>
        /// HTMLとして出力
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string tooltip = "";
            if (Charm !="")
            {
                tooltip += string.Format("チャーム: {0}\n", Charm);
            }
            if (Trick != "")
            {
                tooltip += string.Format("トリック: {0}\n", Trick);
            }
            if (Veil != "")
            {
                tooltip += string.Format("ベール: {0}\n", Veil);
            }
            if (Clue != "")
            {
                tooltip += string.Format("クルー: {0}\n", Clue);
            }
            if (Mystery != "")
            {
                tooltip += string.Format("謎: {0}\n", Mystery);
            }
            return string.Format("<button style='text-align:left; border:0; background:transparent;' title='{0}'>{1}</button><br>\n", tooltip,Text);
        }
    }
}
