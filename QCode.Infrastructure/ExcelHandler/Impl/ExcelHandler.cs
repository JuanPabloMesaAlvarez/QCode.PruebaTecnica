using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCode.Infrastructure.ExcelHandler
{
    public class ExcelHandler : IExcelHandler
    {
        public DataTable ReadFileData(string path)
        {
            DataSet result;
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    result = reader.AsDataSet();
                }
            }
            return result.Tables[0];
        }
    }
}
