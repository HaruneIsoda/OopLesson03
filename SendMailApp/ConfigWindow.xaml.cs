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

        private void btDefault_Click(object sender, RoutedEventArgs e) {
            Config cf = (Config.GetInstance()).getDefaultStatus();
            infoOutput(cf);            
        }

        //適用ボタン
        private void btApply_Click(object sender, RoutedEventArgs e) {

            (Config.GetInstance()).UpdateStatus(
                tbSmtp.Text,
                tbUserName.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked);

            //Config cf = Config.GetInstance();
            //infoInput(cf);
            //cf.UpdateStatus(cf);
        }

        //ロードウィンドウ
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Config cf = Config.GetInstance();
            infoOutput(cf);
        }

        //情報表示
        private void infoOutput(Config cf) {
            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
        }

        //情報を上書き
        private void infoInput(Config cf) {
            cf.Smtp = tbSmtp.Text;
            cf.MailAddress = tbUserName.Text;
            cf.PassWord = tbPassWord.Password;
            cf.Port = int.Parse(tbPort.Text);
            cf.Ssl = cbSsl.IsEnabled;
        }

    }
}
