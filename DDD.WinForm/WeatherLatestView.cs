using DDD.WinForm.Common;
using DDD.WinForm.Data;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DDD.WinForm
{
   // 3人のチーム開発をしていた場合、みんなが関数を呼んでくれるか
   // 100画面くらいある場合、温度の値に出くわすたびにこの関数と Const が本当に使用されるか？
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
