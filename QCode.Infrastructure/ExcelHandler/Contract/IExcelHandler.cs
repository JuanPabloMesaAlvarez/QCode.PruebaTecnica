﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCode.Infrastructure.ExcelHandler
{
    public interface IExcelHandler
    {
        DataTable ReadFileData(string path);
    }
}
