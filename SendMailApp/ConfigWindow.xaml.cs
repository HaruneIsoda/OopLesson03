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
            this.Close();
        }

    }
}
