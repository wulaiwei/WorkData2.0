#region 版权信息

// ------------------------------------------------------------------------------------ 
//     Copyright (C) 成都联宇创新科技有限公司 版权所有。 
//     描述：WorkData.Util
//     日期：2015-09-22 11:53
//     创建： MJZ
//     名字：ExcelExport.cs
// ------------------------------------------------------------------------------------

#endregion

#region 命名空间

using Aspose.Cells;
using System.Data;
using System.Text;
using System.Web;

#endregion

namespace WorkData.Util
{
    /// <summary>
    ///     说明：EXCEL导出类
    ///     创建：MJZ
    ///     日期：2014年9月22日 21:51:25
    /// </summary>
    public class ExcelExport
    {
        /// <summary>
        ///     将保存在服务器上的地址
        /// </summary>
        public string OutFileName { get; set; }

        /// <summary>
        ///     数据导出 说明：解决工作表中有超过65536条数据的情况
        /// </summary>
        /// <param name="dataTable">需要导出的DataTable</param>
        /// <param name="fileName">导出来的文件名字，工作表的名字和这个名字相同</param>
        public static void ExportExcel(DataTable dataTable, string fileName)
        {
            /*默认开启一个工作簿，并要求excel的格式为最低支持97和03的版本*/
            var wb = new Workbook(FileFormatType.Excel97To2003);
            wb.Worksheets.RemoveAt(0); //移除默认的一个工作表
            /*解决如果一个工作表中有超过65536条数据的情况*/
            var totalCount = dataTable.Rows.Count;
            const int sheetSize = 65536; //每个工作表显示多少条
            if (totalCount > sheetSize)
            {
                var s = totalCount / sheetSize; //取商
                var y = totalCount % sheetSize; //取余
                int sheetCount; //需要创建工作表的数量
                /*获取工作表的数量*/
                if (y > 0)
                {
                    sheetCount = s + 1;
                }
                else
                {
                    sheetCount = s;
                }
                /*遍历创建数据*/
                for (var i = 0; i < sheetCount; i++)
                {
                    wb.Worksheets.Add(fileName + " 第" + (i + 1) + "页"); //动态创建工作表
                    /*动态创建DataTable*/
                    var dataTableNew = dataTable.Clone();
                    /*如果是最后一页的话*/
                    if (i == sheetCount - 1)
                    {
                        for (var j = i * sheetSize; j < totalCount; j++)
                        {
                            dataTableNew.ImportRow(dataTable.Rows[j]);
                        }
                    }
                    else
                    {
                        /*做整数页的数据*/
                        for (var j = i * sheetSize; j <= (i + 1) * sheetSize - 1; j++)
                        {
                            dataTableNew.ImportRow(dataTable.Rows[j]);
                        }
                    }
                    /*将数据添加到集合中去*/
                    wb.Worksheets[i].Cells.ImportDataTable(dataTableNew, true, "A1");
                }
            }
            else
            {
                wb.Worksheets.Add(fileName); //动态创建工作表
                var sheet = wb.Worksheets[0];
                sheet.Cells.ImportDataTable(dataTable, true, "A1");
            }
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8) + ".xls");
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.BinaryWrite(wb.SaveToStream().ToArray());
            HttpContext.Current.Response.End();
        }
    }
}