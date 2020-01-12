using System;
using System.Collections.Generic;
using System.Text;

namespace CodeModel
{
    public class NormalModel
    {
        public string SearchColumnsStr { get; set; }

        public string Title { get; set; }

        public string NameSpace { get; set; }

        public string TableName { get; set; }

        /// <summary>
        /// 列列表
        /// </summary>

        public List<ColumnInfo> ColumnList { get; set; }


    }
}
