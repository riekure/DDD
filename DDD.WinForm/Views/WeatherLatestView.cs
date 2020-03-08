using DDD.Domain.Entites;
using DDD.WinForm.ViewModels;
using DDD.WinForm.Views;
using System;
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
        private WeatherLatestViewModel _viewModel = new WeatherLatestViewModel();
        public WeatherLatestView()
        {
            InitializeComponent();

            this.AreaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AreaComboBox.DataBindings.Add("SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            this.AreaComboBox.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Areas));
            this.AreaComboBox.ValueMember = nameof(AreaEntity.AreaId);
            this.AreaComboBox.DisplayMember = nameof(AreaEntity.AreaName);
            
            this.DataDateLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.DataDateText));
            this.ConditionLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.ConditionText));
            this.TemperatureLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.TemperatureText));
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            try
            {
                _viewModel.Search();
            }
            catch(Exception _)
            {
                ;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var f = new WeatherListView())
            {
                f.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var f = new WeatherSaveView())
            {
                f.ShowDialog();
            }
        }
    }
}
