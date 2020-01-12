using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace PMDReader
{
    public class PdmReader
    {
        private const string a = "attribute", c = "collection", o = "object";

        private const string cClasses = "c:Classes";
        private const string oClass = "o:Class";

        private const string cAttributes = "c:Attributes";
        private const string oAttribute = "o:Attribute";

        private const string cTables = "c:Tables";
        private const string oTable = "o:Table";

        private const string cColumns = "c:Columns";
        private const string oColumn = "o:Column";

        private const string cPrimaryKey = "c:PrimaryKey";

        private const string cViews = "c:Views";
        private const string oView = "o:View";


        /// <summary>
        /// 读取指定Pdm文件的实体集合
        /// </summary>
        /// <param name="PdmFile">Pdm文件名(全路径名)</param>
        /// <returns>实体集合</returns>
        public PdmModels ReadFromFile(string PdmFile)
        {
            XmlDocument xmlDoc;
            //加载文件.
            xmlDoc = new XmlDocument();
            xmlDoc.Load(PdmFile);
            //必须增加xml命名空间管理，否则读取会报错.
            XmlNamespaceManager xmlnsManager;
            xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);
            xmlnsManager.AddNamespace("a", "attribute");
            xmlnsManager.AddNamespace("c", "collection");
            xmlnsManager.AddNamespace("o", "object");
            PdmModels theModels = new PdmModels();

            //读取所有表节点
            XmlNodeList xnTablesList = xmlDoc.SelectNodes("//" + cTables, xmlnsManager);
            foreach (XmlNode xmlTables in xnTablesList)
            {
                foreach (XmlNode xnTable in xmlTables.ChildNodes)
                {
                    //排除快捷对象.
                    if (xnTable.Name != "o:Shortcut")
                    {
                        theModels.Tables.Add(GetTable(xnTable));
                    }
                }
            }
            //读取所有视图节点.
            XmlNodeList xnViewsList = xmlDoc.SelectNodes("//" + cViews, xmlnsManager);
            foreach (XmlNode xmlViews in xnViewsList)
            {
                foreach (XmlNode xnView in xmlViews.ChildNodes)
                {
                    theModels.Views.Add(GetView(xnView));

                }
            }
            return theModels;

        }

        //初始化"o:View"的节点
        private ViewInfo GetView(XmlNode xnView)
        {
            ViewInfo theView = new ViewInfo();
            XmlElement xe = (XmlElement)xnView;
            theView.ViewId = xe.GetAttribute("Id");
            XmlNodeList xnTProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnTProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID":
                        theView.ObjectId = xnP.InnerText;
                        break;
                    case "a:Name":
                        theView.Name = xnP.InnerText;
                        break;
                    case "a:Code":
                        theView.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate":
                        theView.CreationDate = String2DateTime(xnP.InnerText);
                        break;
                    case "a:Creator":
                        theView.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate":
                        theView.ModificationDate = String2DateTime(xnP.InnerText);
                        break;
                    case "a:Modifier":
                        theView.Modifier = xnP.InnerText;
                        break;
                    case "a:Comment":
                        theView.Comment = xnP.InnerText;
                        break;
                    case "a:Description":
                        theView.Description = xnP.InnerText;
                        break;
                    case "a:View.SQLQuery":
                        theView.ViewSQLQuery = xnP.InnerText;
                        break;
                    case "a:TaggedSQLQuery":
                        theView.TaggedSQLQuery = xnP.InnerText;
                        break;
                    case "c:Columns":
                        InitColumns(xnP, theView);
                        break;
                }
            }
            return theView;
        }

        //初始化"o:Table"的节点
        private TableInfo GetTable(XmlNode xnTable)
        {
            TableInfo mTable = new TableInfo();
            XmlElement xe = (XmlElement)xnTable;
            mTable.TableId = xe.GetAttribute("Id");
            XmlNodeList xnTProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnTProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID":
                        mTable.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name":
                        mTable.Name = xnP.InnerText;
                        break;
                    case "a:Code":
                        mTable.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate":
                        mTable.CreationDate = String2DateTime(xnP.InnerText);
                        break;
                    case "a:Creator":
                        mTable.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate":
                        mTable.ModificationDate = String2DateTime(xnP.InnerText);
                        break;
                    case "a:Modifier":
                        mTable.Modifier = xnP.InnerText;
                        break;
                    case "a:Comment":
                        mTable.Comment = xnP.InnerText;
                        break;
                    case "a:PhysicalOptions":
                        mTable.PhysicalOptions = xnP.InnerText;
                        break;
                    case "c:Columns":
                        InitColumns(xnP, mTable);
                        break;
                    case "c:Keys":
                        InitKeys(xnP, mTable);
                        break;
                    case "c:PrimaryKey":
                        InitPrimaryKey(xnP, mTable);
                        break;
                    case "a:Description":
                        mTable.Description = xnP.InnerText;
                        break;
                }
            }
            return mTable;
        }

        //PDM文件中的日期格式采用的是当前日期与1970年1月1日8点之差的秒树来保存.
        private DateTime _BaseDateTime = new DateTime(1970, 1, 1, 8, 0, 0);
        private DateTime String2DateTime(string DateString)
        {
            Int64 theTicker = Int64.Parse(DateString);
            return _BaseDateTime.AddSeconds(theTicker);
        }

        //初始化"c:Columns"的节点
        private void InitColumns(XmlNode xnColumns, TableInfo pTable)
        {
            foreach (XmlNode xnColumn in xnColumns)
            {
                pTable.AddColumn(GetColumn(xnColumn, pTable));
            }
        }
        //初始化"c:Columns"的节点
        private void InitColumns(XmlNode xnColumns, ViewInfo pView)
        {
            foreach (XmlNode xnColumn in xnColumns)
            {
                pView.Columns.Add(GetColumn(xnColumn, pView));
            }
        }
        //初始化c:Keys"的节点
        private void InitKeys(XmlNode xnKeys, TableInfo pTable)
        {
            foreach (XmlNode xnKey in xnKeys)
            {
                pTable.AddKey(GetKey(xnKey, pTable));
            }
        }
        //初始化c:PrimaryKey"的节点
        private void InitPrimaryKey(XmlNode xnPrimaryKey, TableInfo pTable)
        {
            pTable.PrimaryKeyRefCode = GetPrimaryKey(xnPrimaryKey);
        }
        private static Boolean ConvertToBooleanPG(Object obj)
        {
            if (obj != null)
            {
                string mStr = obj.ToString();
                mStr = mStr.ToLower();
                if ((mStr.Equals("y") || mStr.Equals("1")) || mStr.Equals("true"))
                {
                    return true;
                }
            }
            return false;
        }

        private ColumnInfo GetColumn(XmlNode xnColumn, TableInfo OwnerTable)
        {
            ColumnInfo mColumn = new ColumnInfo(OwnerTable);
            XmlElement xe = (XmlElement)xnColumn;
            mColumn.ColumnId = xe.GetAttribute("Id");
            XmlNodeList xnCProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnCProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID":
                        mColumn.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name":
                        mColumn.Name = xnP.InnerText;
                        break;
                    case "a:Code":
                     
                        mColumn.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate":
                        mColumn.CreationDate = String2DateTime(xnP.InnerText);
                        break;
                    case "a:Creator":
                        mColumn.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate":
                        mColumn.ModificationDate = String2DateTime(xnP.InnerText);
                        break;
                    case "a:Modifier":
                        mColumn.Modifier = xnP.InnerText;
                        break;
                    case "a:Comment":
                        mColumn.Comment = xnP.InnerText;
                        break;
                    case "a:DataType":
                        mColumn.DataType = xnP.InnerText;
                        Regex reg = new Regex(@"[(]\S+[)]");//去掉nvarchar(50) 这种数据类型的()
                        mColumn.DataType = reg.Replace(mColumn.DataType, "");
                        break;
                    case "a:Length":
                        mColumn.Length = xnP.InnerText;
                        break;
                    case "a:Identity":
                        mColumn.Identity = ConvertToBooleanPG(xnP.InnerText);
                        break;
                    case "a:Mandatory":
                        mColumn.Mandatory = ConvertToBooleanPG(xnP.InnerText);
                        break;
                    case "a:PhysicalOptions":
                        mColumn.PhysicalOptions = xnP.InnerText;
                        break;
                    case "a:ExtendedAttributesText":
                        mColumn.ExtendedAttributesText = xnP.InnerText;
                        break;
                    case "a:Precision":
                        mColumn.Precision = xnP.InnerText;
                        break;
                }
            }
            return mColumn;
        }
        private ViewColumnInfo GetColumn(XmlNode xnColumn, ViewInfo OwnerView)
        {
            ViewColumnInfo mColumn = new ViewColumnInfo(OwnerView);
            XmlElement xe = (XmlElement)xnColumn;
            mColumn.ViewColumnId = xe.GetAttribute("Id");
            XmlNodeList xnCProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnCProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID":
                        mColumn.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name":
                        mColumn.Name = xnP.InnerText;
                        break;
                    case "a:Code":
                        mColumn.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate":
                        mColumn.CreationDate = String2DateTime(xnP.InnerText);
                        break;
                    case "a:Creator":
                        mColumn.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate":
                        mColumn.ModificationDate = String2DateTime(xnP.InnerText);
                        break;
                    case "a:Modifier":
                        mColumn.Modifier = xnP.InnerText;
                        break;
                    case "a:Comment":
                        mColumn.Comment = xnP.InnerText;
                        break;
                    case "a:DataType":
                        mColumn.DataType = xnP.InnerText;
                        break;
                    case "a:Length":
                        mColumn.Length = xnP.InnerText;
                        break;
                    case "a:Precision":
                        mColumn.Description = xnP.InnerText;
                        break;
                }
            }
            return mColumn;
        }
        private string GetPrimaryKey(XmlNode xnKey)
        {
            XmlElement xe = (XmlElement)xnKey;
            if (xe.ChildNodes.Count > 0)
            {
                XmlElement theKP = (XmlElement)xe.ChildNodes[0];
                return theKP.GetAttribute("Ref");
            }
            return "";
        }
        private void InitKeyColumns(XmlNode xnKeyColumns, PdmKey Key)
        {
            XmlElement xe = (XmlElement)xnKeyColumns;
            XmlNodeList xnKProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnKProperty)
            {
                string theRef = ((XmlElement)xnP).GetAttribute("Ref");
                Key.AddColumnObjCode(theRef);
            }
        }
        private PdmKey GetKey(XmlNode xnKey, TableInfo OwnerTable)
        {
            PdmKey mKey = new PdmKey(OwnerTable);
            XmlElement xe = (XmlElement)xnKey;
            mKey.KeyId = xe.GetAttribute("Id");
            XmlNodeList xnKProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnKProperty)
            {
                switch (xnP.Name)
                {
                    case "a:ObjectID":
                        mKey.ObjectID = xnP.InnerText;
                        break;
                    case "a:Name":
                        mKey.Name = xnP.InnerText;
                        break;
                    case "a:Code":
                        mKey.Code = xnP.InnerText;
                        break;
                    case "a:CreationDate":
                        mKey.CreationDate = String2DateTime(xnP.InnerText);
                        break;
                    case "a:Creator":
                        mKey.Creator = xnP.InnerText;
                        break;
                    case "a:ModificationDate":
                        mKey.ModificationDate = String2DateTime(xnP.InnerText);
                        break;
                    case "a:Modifier":
                        mKey.Modifier = xnP.InnerText;
                        break;
                    case "c:Key.Columns":
                        InitKeyColumns(xnP, mKey);
                        break;
                }
            }
            return mKey;
        }
    }
}
