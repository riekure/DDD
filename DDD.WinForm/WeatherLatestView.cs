using DDD.WinForm.Common;
using DDD.WinForm.Data;
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

    // BAD コードの改善
    // 第一段階：画面ごとに重複したコードを書く
    // 第二段階：共通化を行う
    public partial class WeatherLatestView : Form
    {
        public WeatherLatestView()
        {
            InitializeComponent();
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = WeatherSQLite.Getlatest(Convert.ToInt32(AreaIdTextBox.Text));

                if (dt.Rows.Count > 0)
                {
                    DataDateLabel.Text = dt.Rows[0]["DataDate"].ToString();
                    ConditionLabel.Text = dt.Rows[0]["Condition"].ToString();
                    TemperatureLabel.Text =
                        CommonFunc.RoundString(Convert.ToSingle(dt.Rows[0]["Temperature"]), CommonConst.temperatureDecimalPoint)
                        + CommonConst.TemperatureUnitName;
                }
            } catch (Exception)
            {

            }
        }
    }
}
