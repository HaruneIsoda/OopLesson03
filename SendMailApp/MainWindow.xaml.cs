using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.Remoting.Messaging;
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
                MessageBox.Show("送信はキャンセルされました", "確認");
            } else {
                MessageBox.Show(e.Error?.Message ?? "送信完了", "確認");
            }
        }

        //メール送信処理
        private void btOk_Click(object sender, RoutedEventArgs e) {
            try {
                Config cf = Config.GetInstance();
                MailMessage msg = new MailMessage(cf.MailAddress, tbTo.Text);
                if(tbCc.Text != "") {
                    msg.CC.Add(tbCc.Text);
                }
                if(tbBcc.Text != "") {
                    msg.Bcc.Add(tbBcc.Text);
                }

                if(tbTitle.Text == "" || tbBody.Text == "") {
                    if(questionMessage()) { //trueだったら格納
                        msg.Subject = tbTitle.Text; //件名
                        msg.Body = tbBody.Text; //本文
                    } else {
                        return;
                    }


                    //添付ファイル
                    foreach(var file in fileListBox.Items) {
                        msg.Attachments.Add(new Attachment(file.ToString(), MediaTypeNames.Application.Octet));
                    }

                    sc.Host = cf.Smtp; //SMTPサーバーの設定
                    sc.Port = cf.Port;
                    sc.EnableSsl = cf.Ssl;
                    sc.Credentials = new NetworkCredential(cf.MailAddress, cf.PassWord);

                    sc.SendMailAsync(msg);   //送信
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        //件名と本文の入力確認
        private bool questionMessage() {
            string name = "";
            if(tbTitle.Text == "" && tbBody.Text == "") {
                name = "件名と本文";
            } else if(tbTitle.Text == "") {
                name = "件名";
            } else if(tbBody.Text == "") {
                name = "本文";
            }

            MessageBoxResult result = MessageBox.Show($"{name}が入力されていません。送信しますか？",
                                                      "質問", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes) {
                return true;
            } else if(result == MessageBoxResult.No) {
                return false;
            }

            return true;
        }

        //送信キャンセル処理
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            sc.SendAsyncCancel();
        }

        //設定ボタン
        private void btConfig_Click(object sender, RoutedEventArgs e) {
            ConfigWindowShow();
        }

        //設定画面表示
        private static void ConfigWindowShow() {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.ShowDialog();
        }

        //メインウィンドウがロードされるタイミングで呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            try {
                (Config.GetInstance()).DeSerialise();
            } catch(FileNotFoundException) {
                ConfigWindowShow();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //メインウィンドウが閉じるタイミングで呼び出される
        private void Window_Closed(object sender, EventArgs e) {
            try {
                (Config.GetInstance()).Serialise();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //ファイル追加ボタン
        private void imageAddButton_Click(object sender, RoutedEventArgs e) {
            var ofd = new OpenFileDialog();
            ofd.FileName = "ファイルを選択してください";
            //ofd.DefaultExt = ".jpg";
            ofd.Filter = "すべてのファイル|*.*";

            try {
                bool? result = ofd.ShowDialog();

                if(result == true) {
                    fileListBox.Items.Add(ofd.FileName);
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //ファイル削除ボタン
        private void imageDeleteButton_Click(object sender, RoutedEventArgs e) {
            var sel = fileListBox.SelectedIndex;
            if(sel == -1) {
                return; //選択されていなかったらreturn
            } else {
                fileListBox.Items.RemoveAt(sel);
            }
        }
    }
}
