using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMailApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

        SmtpClient sc = new SmtpClient();

        //送信完了イベント
        private void Sc_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            if(e.Cancelled) {
                MessageBox.Show("送信はキャンセルされました");
            } else {
                MessageBox.Show(e.Error?.Message ?? "送信完了");
            }
        }

        //メール送信処理
        private void btOk_Click(object sender, RoutedEventArgs e) {
            try {
                MailMessage msg = new MailMessage("ojsinfosys01@gmail.com",tbTo.Text);
                if(tbCc.Text != "") {
                    msg.CC.Add(tbCc.Text);
                }
                if(tbBcc.Text != "") {
                    msg.Bcc.Add(tbBcc.Text);
                }
                msg.Subject = tbTitle.Text; //件名
                msg.Body = tbBody.Text; //本文


                sc.Host = "smtp.gmail.com"; //SMTPサーバーの設定
                sc.Port = 587;
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("ojsinfosys01@gmail.com", "ojsInfosys2020");

                sc.SendMailAsync(msg);   //送信
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //送信キャンセル処理
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            sc.SendAsyncCancel();
        }

        //設定画面表示
        private void btConfig_Click(object sender, RoutedEventArgs e) {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.ShowDialog();
        }

        //メインウィンドウがロードされるタイミングで呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }
    }
}
