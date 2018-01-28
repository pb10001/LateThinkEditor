using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LateThinkEditor
{
    /// <summary>
    /// 問題
    /// </summary>
    public class Puzzle
    {
        /// <summary>
        /// デフォルトのコンストラクタ
        /// </summary>
        public Puzzle()
        {
        }
        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public Puzzle(Puzzle source)
        {
            Id = source.Id;
            Title = source.Title;
            Content = source.Content;
            Solution = source.Solution;
            ContentAnalysis.AddRange(source.ContentAnalysis);
            SolutionAnalysis.AddRange(source.SolutionAnalysis);
        }
        /// <summary>
        /// JSONから生成するstatic factory method
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Puzzle FromJSONString(string json)
        {
            return JsonConvert.DeserializeObject<Puzzle>(json);
        }
        string id;
        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; } = "";
        /// <summary>
        /// 問題文
        /// </summary>
        public string Content { get; set; } = "";
        /// <summary>
        /// 問題文の分析
        /// </summary>
        public List<Analysis> ContentAnalysis { get; set; } = new List<Analysis>();
        /// <summary>
        /// 解説
        /// </summary>
        public string Solution { get; set; } = "";
        /// <summary>
        /// 解説の分析
        /// </summary>
        public List<Analysis> SolutionAnalysis { get; set; } = new List<Analysis>();
        /// <summary>
        /// JSON文字列化
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (id==null)
            {
                SetId();
            }
            return JsonConvert.SerializeObject(this).ToString();
        }
        /// <summary>
        /// idとしてハッシュ値を割り当て
        /// </summary>
        private void SetId()
        {
            id = GetHashCode().ToString();
        }
    }
}
