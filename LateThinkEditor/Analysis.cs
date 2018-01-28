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
    public class Analysis: Puzzle
    {
        /// <summary>
        /// デフォルトのコンストラクタ
        /// </summary>
        public Analysis() { }
        /// <summary>
        /// puzzleを引数にとるコンストラクタ
        /// </summary>
        /// <param name="puzzle"></param>
        public Analysis(Puzzle puzzle)
        {

        }
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
        /// 謎に対する答え
        /// </summary>
        public string Answer { get; set; } = "";
    }
}
