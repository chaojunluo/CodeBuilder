using System;
using System.Collections.Generic;
using System.Text;

namespace PMDReader
{
    public class PdmModels
    {
        public PdmModels()
        {
            Tables = new List<TableInfo>();
            Views = new List<ViewInfo>();
        }
        /// <summary>
        /// 表集合
        /// </summary>
        public IList<TableInfo> Tables { get; private set; }
        /// <summary>
        /// 视图集合
        /// </summary>
        public IList<ViewInfo> Views { get; private set; }

    }
}
