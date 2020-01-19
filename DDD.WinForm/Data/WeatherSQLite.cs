﻿using DDD.WinForm.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.Data
{
    public static class WeatherSQLite
    {
        public static DataTable Getlatest(int areaId)
        {
            var sql = @"
select DataDate,
       Condition,
       Temperature
from Weather
where AreaId = @AreaId
order by DataDate desc
LIMIT 1";

            var dt = new DataTable();
            using (var connection = new SQLiteConnection(CommonConst.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@AreaId", areaId);
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
