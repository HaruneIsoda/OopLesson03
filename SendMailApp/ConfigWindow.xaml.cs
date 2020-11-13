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
    /// 
    public partial class ConfigWindow : Window {

        bool IsTextChanged = false;

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
            if(nullTextBoxCheck() == false) {
                return;
            }
            UpdateInfo();
        }

        private bool nullTextBoxCheck() {
            if(tbSmtp.Text == "" || tbUserName.Text == "" ||
                tbPassWord.Password == "" || tbPort.Text == "") {
                MessageBox.Show("入力されていない項目があります", "エラー");
                return false;
            }
            return true;
        }

        //情報更新
        private void UpdateInfo() {
            (Config.GetInstance()).UpdateStatus(
                tbSmtp.Text,
                tbUserName.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false);

            IsTextChanged = false;  //変更のフラグを取り消す
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

            IsTextChanged = false;
        }

        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e) {
            if(nullTextBoxCheck() == false) {
                return; //エラーが出たらウィンドウを閉じさせない
            }
            UpdateInfo();
            this.Close();
        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            if(IsTextChanged) {
                MessageBoxResult result = MessageBox.Show("設定内容が保存されていません。保存しますか？",
                                                          "質問",
                                                          MessageBoxButton.YesNoCancel);

                if(result == MessageBoxResult.Yes) {
                    if(nullTextBoxCheck() == false) {
                        return;
                    }
                    UpdateInfo();
                } else if(result == MessageBoxResult.No) {
                    //何もしない
                } else if(result == MessageBoxResult.Cancel) {
                    return;
                }
            }
            this.Close();
            IsTextChanged = false;
        }

        private void TextChangedCheck(object sender, TextChangedEventArgs e) {
            IsTextChanged = true;
        }

        private void PasswordChangedCheck(object sender, RoutedEventArgs e) {
            IsTextChanged = true;
        }
    }
}