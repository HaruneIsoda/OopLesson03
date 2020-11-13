using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SendMailApp {
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window {
        public ConfigWindow() {
            InitializeComponent();
        }

        //初期値設定
        private void btDefault_Click(object sender, RoutedEventArgs e) {
            Config cf = (Config.GetInstance()).getDefaultStatus();
            tbSmtp.Text = cf.Smtp;
            tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            tbPort.Text = cf.Port.ToString();
            cbSsl.IsChecked = cf.Ssl;
            tbSender.Text = cf.MailAddress;
        }

        //適用ボタン
        private void btApply_Click(object sender, RoutedEventArgs e) {
            while(tbSmtp.Text == "" || tbUserName.Text == "" || tbPassWord.Password == "" || tbPort.Text == "") {
                MessageBox.Show("入力されていない項目があります", "エラー");
                return;
            }

            UpdateInfo();
        }

        //情報更新
        private void UpdateInfo() {
            (Config.GetInstance()).UpdateStatus(
                tbSmtp.Text,
                tbUserName.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false);
        }

        //ロード時に一度だけ呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Config cf = Config.GetInstance();
            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
            tbSender.Text = cf.MailAddress;
        }

        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e) {
            btApply_Click(sender, e);   //更新処理を呼び出す
            this.Close();
        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            Config cf = Config.GetInstance();

            if(
                !(cf.Smtp == tbSmtp.Text &&
                cf.Port.ToString().Equals(tbPort.Text) &&
                cf.MailAddress == tbUserName.Text &&
                cf.PassWord == tbPassWord.Password)) {
                MessageBoxResult result = MessageBox.Show("設定内容が保存されていません。保存しますか？",
                                                          "質問",
                                                          MessageBoxButton.YesNoCancel);

                if(result == MessageBoxResult.Yes) {
                    UpdateInfo();
                } else if(result == MessageBoxResult.No) {
                    //何もしない
                } else if(result == MessageBoxResult.Cancel) {
                    return;
                }
            }
            this.Close();
        }
    }
}