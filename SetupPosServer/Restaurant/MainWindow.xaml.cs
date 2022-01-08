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
namespace SetupPosServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load
            try
            {


            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
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
                sdate =  date.Value.ToLongTimeString(); 
               
                /// date.Value.Millisecond.ToString();
                //    newdate= DateTime.ParseExact("23/01/2013 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            }
            newdate= Convert.ToDateTime(sdate);
          //  newdate = DateTime.Parse(sdate);
            return sdate;
        }
        private async void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            //string s = "";

            //s = DateTodbdate(DateTime.Now).ToString();
            ////   tb_serverUri.Text =s + DateTodbdate(DateTime.Now).Value.Millisecond.ToString();
            //tb_serverUri.Text = s;


            ////s = DateTodbstring(DateTime.Now);
            ////tb_serverUri.Text = s;
            ////MessageBox.Show(s);



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
                    chk = await ac.StatSendserverkey(tb_activationkey.Text,"all");

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
                //if ((sender as ComboBox).Name == "cb_paymentProcessType")
                //    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");
                //else if ((sender as ComboBox).Name == "cb_card")
                //    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorCard, tt_errorCard, "trEmptyCardTooltip");
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

    }
}
