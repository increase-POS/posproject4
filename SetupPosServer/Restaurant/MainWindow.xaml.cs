using netoaster;
using SetupPosServer.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace SetupPosServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load
            try
            {

                fillServerState(cb_serverStatus);
                cb_serverStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        static public void fillServerState(ComboBox combo)
        {
            var typelist = new[] {
                new { Text = "Online"    , Value = "True" },
                new { Text = "Offline"   , Value = "False" }
                 };
            combo.DisplayMemberPath = "Text";
            combo.SelectedValuePath = "Value";
            combo.ItemsSource = typelist;

        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);

                if (e.Key == Key.Return)
                {
                    Btn_next_Click(btn_next, null);
                }
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                //SectionData.ExceptionMessage(ex, this);
            }
        }

        //public static DateTime? DateTodbdate(DateTime? date)
        //{
        //    string sdate = "";
        //    DateTime? newdate = null;
        //   // newdate = DateTime.Parse(sdate);
        //    if (date != null)
        //    {

        //    //"yyyy'-'MM'-'dd'T'HH':'mm':'ss"
        //  //  HH: mm: ss", CultureInfo.InvariantCulture
        //        sdate = date.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        //       /// date.Value.Millisecond.ToString();
        //  //    newdate= DateTime.ParseExact("23/01/2013 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        //    }
        //  //  newdate= DateTime.Parse(sdate);
        //    newdate = Convert.ToDateTime(sdate);
        //    return newdate;
        //}
        public static string DateTodbstring(DateTime? date)
        {
            string sdate = "";
            DateTime? newdate = null;
            // newdate = DateTime.Parse(sdate);
            if (date != null)
            {

                //"yyyy'-'MM'-'dd'T'HH':'mm':'ss"
                //  HH: mm: ss", CultureInfo.InvariantCulture
                // sdate = date.Value.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss.ffffff");
                sdate = date.Value.ToLongTimeString();

                /// date.Value.Millisecond.ToString();
                //    newdate= DateTime.ParseExact("23/01/2013 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            }
            newdate = Convert.ToDateTime(sdate);
            //  newdate = DateTime.Parse(sdate);
            return sdate;
        }
        private async void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            string t = Global.APIUri;//temp delete
            int chk = 0;
            try
            {
                if (tb_activationkey.Text.Trim() != "".Trim() && tb_serverUri.Text.Trim() != "".Trim())
                {
                    AvtivateServer ac = new AvtivateServer();
                    Global.APIUri = tb_serverUri.Text + @"/api/";
                    chk = await ac.checkconn();
                    //string res=  await ac.checkincconn();

                    //   MessageBox.Show(chk.ToString());
                    //
                    chk = await ac.StatSendserverkey(tb_activationkey.Text, "all");

                    //   MessageBox.Show(chk.ToString());

                    if (chk <= 0)
                    {
                        string message = "inc(" + chk + ")";

                        string messagecode = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(message));
                        //  tb_activationkey.Text = messagecode;


                        string msg = "The Activation not complete (Error code:" + messagecode + ")";


                        Toaster.ShowWarning(Window.GetWindow(this), message: msg, animation: ToasterAnimation.FadeIn);
                    }

                    else
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: "The Activation done successfuly", animation: ToasterAnimation.FadeIn);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.APIUri = t;//temp delete
                Toaster.ShowWarning(Window.GetWindow(this), message: "The server Not Found", animation: ToasterAnimation.FadeIn);
            }
        }

        //private async void next_Click(object sender, RoutedEventArgs e)
        //{

        //    int chk = 0;
        //    string activationkey = "";//getget from info 
        //    try
        //    {
        //        if (activationkey.Trim() != "".Trim())
        //        {
        //            AvtivateServer ac = new AvtivateServer();

        //            chk = await ac.checkconn();

        //            chk = await ac.Sendserverkey(tb_activationkey.Text);



        //            if (chk <= 0)
        //            {
        //                string message = "inc(" + chk + ")";

        //                string messagecode = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(message));
        //                tb_activationkey.Text = messagecode;


        //                string msg = "The Activation not complete (Error code:" + messagecode + ")";


        //                Toaster.ShowWarning(Window.GetWindow(this), message: msg, animation: ToasterAnimation.FadeIn);
        //            }

        //            else
        //            {
        //                Toaster.ShowSuccess(Window.GetWindow(this), message: "The Activation done successfuly", animation: ToasterAnimation.FadeIn);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Toaster.ShowWarning(Window.GetWindow(this), message: "The server Not Found", animation: ToasterAnimation.FadeIn);
        //    }
        //}
        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
                TextBox textBox = sender as TextBox;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_serverUri")
                    validateEmptyTextBox(tb_serverUri, p_errorServerUri, tt_errorServerUri, "trEmptyError");
                else if ((sender as TextBox).Name == "tb_activationkey")
                    validateEmptyTextBox(tb_activationkey, p_errorActivationkey, tt_errorActivationkey, "trEmptyError");
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_serverStatus")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorServerStatus, tt_errorServerStatus, "trEmptyError");
            }
        }
        public static BrushConverter bc = new BrushConverter();
        public static bool validateEmptyTextBox(TextBox tb, Path p_error, ToolTip tt_error, string tr)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                p_error.Visibility = Visibility.Visible;
                //tt_error.Content = wd_setupFirstPos.resourcemanager.GetString(tr);
                tt_error.Content = "This field cann't be empty";
                tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
                isValid = false;
            }
            else
            {
                tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;
            }
            return isValid;
        }
        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Cb_serverStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cb_serverStatus.SelectedIndex == 0)
                {
                    txt_activationkeyTitle.Visibility = Visibility.Visible;
                    tb_activationkey.Visibility = Visibility.Visible;
                    btn_upload.Visibility = Visibility.Collapsed;
                    btn_next.IsEnabled = true;

                }
                else
                {
                    SectionData.clearValidate(tb_activationkey, p_errorActivationkey);
                    txt_activationkeyTitle.Visibility = Visibility.Collapsed;
                    tb_activationkey.Visibility = Visibility.Collapsed;
                    btn_upload.Visibility = Visibility.Visible;
                    btn_next.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }


        }

        private async void Btn_upload_Click(object sender, RoutedEventArgs e)
        {//upload
            try
            {
                validateEmptyTextBox(tb_serverUri, p_errorServerUri, tt_errorServerUri, "trEmptyError");
                if (!tb_serverUri.Text.Equals(""))
                {
                    // start activate
                    string t = Global.APIUri;//temp delete
                    int chk = 0;
                    string message = "";
                    try
                    {
                        if (tb_serverUri.Text.Trim() != "".Trim())
                        {
                            bool isServerActivated = true;
                            AvtivateServer ac = new AvtivateServer();
                            Global.APIUri = tb_serverUri.Text + @"/api/";

                            string filepath = "";
                            openFileDialog.Filter = "INC|*.ac; ";
                            SendDetail customerdata = new SendDetail();
                            SendDetail dc = new SendDetail();
                            if (openFileDialog.ShowDialog() == true)
                            {
                                filepath = openFileDialog.FileName;

                                //   bool resr = ReportCls.decodefile(filepath, @"D:\stringlist.txt");//comment

                                string objectstr = "";

                                objectstr = ReportCls.decodetoString(filepath);

                                dc = JsonConvert.DeserializeObject<SendDetail>(objectstr, new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                                packagesSend pss = new packagesSend();

                                pss = dc.packageSend;
                                isServerActivated = dc.packageSend.isServerActivated;
                                pss.activeApp = "all";//no comment

                                dc.packageSend = pss;

                                // string activeState = "";
                                customerdata = await ac.OfflineActivate(dc, "up");

                            }
                            // upload

                            if (customerdata.packageSend.result > 0)
                            {
                                if (isServerActivated == false || (isServerActivated == true && dc.packageSend.activeState == "up"))
                                {
                                    // if first activate OR upgrade  show save dialoge to save customer data in file 
                                    saveFileDialog.Filter = "File|*.ac;";
                                    if (saveFileDialog.ShowDialog() == true)
                                    {
                                        string DestPath = saveFileDialog.FileName;

                                        string myContent = JsonConvert.SerializeObject(customerdata);

                                        bool res = false;

                                        res = ReportCls.encodestring(myContent, DestPath);

                                        if (res)
                                        {
                                            //     //done
                                            //   MessageBox.Show("Success");
                                            Toaster.ShowSuccess(Window.GetWindow(this), message: "Success", animation: ToasterAnimation.FadeIn);
                                        }
                                        else
                                        {
                                            Toaster.ShowWarning(Window.GetWindow(this), message: "Error", animation: ToasterAnimation.FadeIn);
                                            //   MessageBox.Show("Error");
                                        }

                                    }
                                }
                                else
                                {
                                    // if extend show extend result
                                    //renew no save

                                    Toaster.ShowSuccess(Window.GetWindow(this), message: "Success Extend", animation: ToasterAnimation.FadeIn);

                                }

                            }
                            else
                            {
                              //MessageBox.Show(customerdata.packageSend.result.ToString());
                                Toaster.ShowWarning(Window.GetWindow(this), message: "Error-" + customerdata.packageSend.result.ToString(), animation: ToasterAnimation.FadeIn);

                            }
                            //end uploaa 
                        }
                    }
                    catch (Exception ex)
                    {
                        Global.APIUri = t;//temp delete
                        Toaster.ShowWarning(Window.GetWindow(this), message: "The server Not Found", animation: ToasterAnimation.FadeIn);
                    }


                    //end activate

                    await Task.Delay(2000);
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                Toaster.ShowWarning(Window.GetWindow(this), message: "The server Not Found", animation: ToasterAnimation.FadeIn);
            }
        }
    }
}
