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

    // 潜在的な BAD ポイント
    // 知識の所在：どこに知識がある？という問題
    // ロジックには2種類ある：使う側（クライアントコード）、使われる側
    // 使う側に知識があるとドメインロジックが散らばる
    // ・温度は小数点以下2桁で丸めて単位は℃
    // ・CommonFunc と CommonConst に移動したのでクライアントコードに知識がないように見える

    // クライアントコードが値とロジックを結びつける必要がある

    // 温度の値を扱うときに CommonFunc と CommonConst を使って処理をしないといけない
    // ・永遠に全員gな覚えて置かなければいけない
    // ・関数と存在を知らないメンバーが同じようなコードを書き出す
    // ・画面コードに直接単位「℃」を書き込む人も現れる

    // 解決策
    // 値とロジックを一体化させて、使う側にインテリセンスの中から選ぶだけの状態にする
    // ・ValueObject
    // ・Entity

    // テストしやすいコード
    // どこにも依存していない関数 = テストのしやすさ
    // 関数内で他の関数を呼んでいたとしても、その関数がそこで完結していればOK

    // テストしづらいコード
    // アプリケーションの外部にアクセスしているコード（データベース、ファイル）
    // 実際にファイルが存在しないとテストができない
    // 外部機器がないとテストできない
    // 解決策：インタフェースの利用、Moq などのツールを利用

    // アーキテクチャー
    // WinForm(WPF)：View（画面）、ViewModel（画面と1対1のロジック部分）
    // Infrastructure：アプリケーションの外側との接触部分
    // Domain：ビジネスロジック、ValueObject, Entity, Helper, Exception, 静的ロジック、インタフェース
    // テストプロジェクト
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
                        + " "
                        + CommonConst.TemperatureUnitName;
                }
            } catch (Exception)
            {

            }
        }
    }
}
