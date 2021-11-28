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
        private async void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            string t = Global.APIUri;//temp delete
            int chk = 0;
            try
            {
                if (tb_activationkey.Text != "".Trim() && tb_activationkey.Text != "".Trim())
                {
                    AvtivateServer ac = new AvtivateServer();
                    Global.APIUri = tb_serverUri.Text + @"/api/";
                    chk = await ac.checkconn();
                    //string res=  await ac.checkincconn();


                    //
                    chk = await ac.Sendserverkey(tb_activationkey.Text);
                    if (chk == -1)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: "The Activation site Not found", animation: ToasterAnimation.FadeIn);
                    }
                    else if (chk == 0)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: "The Activation not complete", animation: ToasterAnimation.FadeIn);
                    }
                    else if (chk == -2)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), message: "The key is used before", animation: ToasterAnimation.FadeIn);
                    }
                    else if (chk == -3)
                    {
                        Toaster.ShowWarning(Window.GetWindow(this), "The key is Not exist", animation: ToasterAnimation.FadeIn);
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
