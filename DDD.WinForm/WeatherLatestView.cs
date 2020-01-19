using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DDD.WinForm
{
    // BAD コードの悪いところ
    // 1. SQL が重複する
    // 2. SQL の接続先、タイムアウト時間をアプリケーション全体で変更する場合に追従できない（全コードをチェックして書き換えが必要）
    // 3. データ取得後の値の加工、小数点以下2桁で丸める単位の表示
    // 4. weather テーブルの一覧表示画面を作成する場合は、そこにも同じ加工処理を各必要がある

    public partial class WeatherLatestView : Form
    {
        private readonly string ConnectionString = @"Data Source=C:\Users\ryo\Documents\DDD\DDD.db;Version=3;";
        public WeatherLatestView()
        {
            InitializeComponent();
        }

        private void LatestButton_Click(object sender, EventArgs e)
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
            using(var connection = new SQLiteConnection(ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@AreaId", this.AreaIdTextBox.Text);
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }

            if (dt.Rows.Count > 0)
            {
                DataDateLabel.Text = dt.Rows[0]["DataDate"].ToString();
                ConditionLabel.Text = dt.Rows[0]["Condition"].ToString();
                TemperatureLabel.Text = RoundString(Convert.ToSingle(dt.Rows[0]["Temperature"]), 2) + "℃";
            }
        }

        private string RoundString(float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString("F" + decimalPoint);
        }
    }
}
