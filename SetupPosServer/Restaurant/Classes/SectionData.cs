using MaterialDesignThemes.Wpf;
using netoaster;
using Restaurant;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace SetupPosServer.Classes
{
    class SectionData
    {
        public static bool iscodeExist = false;

        public static BrushConverter bc = new BrushConverter();

        public static ImageBrush brush = new ImageBrush();
         

        public static bool IsValid(string txt)
        {//for email
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                   RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool isValidEmail = regex.IsMatch(txt);

            if (!isValidEmail) return false;

            else return true;

        }

        public static void SetError(Control c, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = tr;
            c.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }
        public static bool validateEmptyTextBlock(TextBlock txt, Path p_error, ToolTip tt_error, string tr)
        {
            bool isValid = true;
            if (txt.Text.Equals(""))
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content =tr;
                txt.Background = (Brush)bc.ConvertFrom("#15FF0000");
                isValid = false;
            }
            else
            {
                txt.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;
            }
            return isValid;
        }
        public static bool validateEmptyTextBox(TextBox tb, Path p_error, ToolTip tt_error, string tr)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = tr;
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
        public static bool validateEmptyComboBox(ComboBox cb, Path p_error, ToolTip tt_error, string tr)
        {
            bool isValid = true;

            if (cb.SelectedIndex == -1)
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = tr;
                cb.Background = (Brush)bc.ConvertFrom("#15FF0000");
                isValid = false;
            }
            else
            {
                cb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;

            }
            return isValid;
        }
        
        public static bool validateEmptyPassword(PasswordBox pb, Path p_error, ToolTip tt_error, string tr)
        {
            bool isValid = true;

            if (pb.Password.Equals(""))
            {
                SectionData.showPasswordValidate(pb, p_error, tt_error, "trEmptyPasswordToolTip");
                p_error.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                SectionData.clearPasswordValidate(pb, p_error);
                p_error.Visibility = Visibility.Collapsed;
            }
            return isValid;
        }
      
            public static bool ValidatorExtensions(string txt)
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                       RegexOptions.CultureInvariant | RegexOptions.Singleline);
                bool isValidEmail = regex.IsMatch(txt);

                if (!isValidEmail) return false;

                else return true;

            }
        public static bool validateEmail(TextBox tb, Path p_error, ToolTip tt_error)
        {
            bool isValid = true;
            if (!tb.Text.Equals(""))
            {
                if (!ValidatorExtensions(tb.Text))
                {
                    p_error.Visibility = Visibility.Visible;
                    tt_error.Content = "Email address is not valid";
                    tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
                    isValid = false;
                }
                else
                {
                    p_error.Visibility = Visibility.Collapsed;
                    tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                    isValid = true;
                }
            }
            return isValid;
        }
        public static bool validateEmptyDatePicker(DatePicker dp, Path p_error, ToolTip tt_error, string tr)
        {
            bool isValid = true;
            TextBox tb = (TextBox)dp.Template.FindName("PART_TextBox", dp);
            if (tb.Text.Trim().Equals(""))
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = tr;
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
        public static void validateSmalThanDateNowDatePicker(DatePicker dp, Path p_error, ToolTip tt_error, string tr)
        {
            TextBox tb = (TextBox)dp.Template.FindName("PART_TextBox", dp);
            if (dp.SelectedDate < DateTime.Now)
            {
                p_error.Visibility = Visibility.Visible;
                tt_error.Content = tr;
                tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
            }
            else
            {
                tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                p_error.Visibility = Visibility.Collapsed;
            }
        }
        public static void clearValidate(TextBox tb, Path p_error)
        {
            tb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            p_error.Visibility = Visibility.Collapsed;
        }
        public static void clearPasswordValidate(PasswordBox pb, Path p_error)
        {
            pb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            p_error.Visibility = Visibility.Collapsed;
        }
        public static void clearTextBlockValidate(TextBlock txt, Path p_error)
        {
            txt.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            p_error.Visibility = Visibility.Collapsed;
        }
        public static void clearComboBoxValidate(ComboBox cb, Path p_error)
        {
            cb.Background = (Brush)bc.ConvertFrom("#f8f8f8");
            p_error.Visibility = Visibility.Collapsed;
        }
        public static void showTextBoxValidate(TextBox tb, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = tr;
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }
        public static void showPasswordValidate(PasswordBox tb, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = tr;
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }
        
           
        public static void showComboBoxValidate(ComboBox cb, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = tr;
            cb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }

        public static void showDatePickerValidate(DatePicker dp, Path p_error, ToolTip tt_error, string tr)
        {
            TextBox tb = (TextBox)dp.Template.FindName("PART_TextBox", dp);

            p_error.Visibility = Visibility.Visible;
            tt_error.Content = tr;
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }

        public static void showTimePickerValidate(TimePicker tp, Path p_error, ToolTip tt_error, string tr)
        {
            TextBox tb = (TextBox)tp.Template.FindName("PART_TextBox", tp);

            p_error.Visibility = Visibility.Visible;
            tt_error.Content = tr;
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }





        public static void validateDuplicateCode(TextBox tb, Path p_error, ToolTip tt_error, string tr)
        {
            p_error.Visibility = Visibility.Visible;
            tt_error.Content = tr;
            tb.Background = (Brush)bc.ConvertFrom("#15FF0000");
        }

        public static void getMobile(string _mobile, ComboBox _area, TextBox _tb)
        {//mobile
            if ((_mobile != null))
            {
                string area = _mobile;
                string[] pharr = area.Split('-');
                int j = 0;
                string phone = "";

                foreach (string strpart in pharr)
                {
                    if (j == 0)
                    {
                        area = strpart;
                    }
                    else
                    {
                        phone = phone + strpart;
                    }
                    j++;
                }

                _area.Text = area;

                _tb.Text = phone.ToString();
            }
            else
            {
                _area.SelectedIndex = -1;
                _tb.Clear();
            }
        }

        public static void getPhone(string _phone, ComboBox _area, ComboBox _areaLocal, TextBox _tb)
        {//phone
            if ((_phone != null))
            {
                string area = _phone;
                string[] pharr = area.Split('-');
                int j = 0;
                string phone = "";
                string areaLocal = "";
                foreach (string strpart in pharr)
                {
                    if (j == 0)
                        area = strpart;
                    else if (j == 1)
                        areaLocal = strpart;
                    else
                        phone = phone + strpart;
                    j++;
                }

                _area.Text = area;
                _areaLocal.Text = areaLocal;
                _tb.Text = phone.ToString();
            }
            else
            {
                _area.SelectedIndex = -1;
                _areaLocal.SelectedIndex = -1;
                _tb.Clear();
            }
        }
         
        public static decimal calcPercentage(decimal value, decimal percentage)
        {
            decimal percentageVal = (value * percentage) / 100;

            return percentageVal;
        }
        public static void defaultDatePickerStyle(DatePicker dp)
        {
            dp.Loaded += delegate
            {

                var textBox1 = (TextBox)dp.Template.FindName("PART_TextBox", dp);
                if (textBox1 != null)
                {
                    textBox1.Background = dp.Background;
                    textBox1.BorderThickness = dp.BorderThickness;
                }
            };
        }


        static public void searchInComboBox(ComboBox cbm)
        {
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(cbm.Items);
            itemsViewOriginal.Filter = ((o) =>
            {
                if (String.IsNullOrEmpty(cbm.Text)) return true;
                else
                {
                    if (((string)o).Contains(cbm.Text)) return true;
                    else return false;
                }
            });
            itemsViewOriginal.Refresh();
        }
 
        /// <summary>
        /// لمنع  الصفر بالبداية
        /// </summary>
        /// <param name="txb"></param>
        static public void InputJustNumber(ref TextBox txb)
        {
            if (txb.Text.Count() == 2 && txb.Text == "00")
            {
                string myString = txb.Text;
                myString = Regex.Replace(myString, "00", "0");
                txb.Text = myString;
                txb.Select(txb.Text.Length, 0);
                txb.Focus();
            }
        }

        static async public void ExceptionMessage(Exception ex, object window)
        {
            try
            {

                //Message
                if (ex.HResult == -2146233088)
                    Toaster.ShowError(window as Window, message: "trNoConnection", animation: ToasterAnimation.FadeIn);
                else
                    Toaster.ShowError(window as Window, message: ex.HResult + " || " + ex.Message, animation: ToasterAnimation.FadeIn);

                //ErrorClass errorClass = new ErrorClass();
                //errorClass.num = ex.HResult.ToString();
                //errorClass.msg = ex.Message;
                //errorClass.stackTrace = ex.StackTrace;
                //errorClass.targetSite = ex.TargetSite.ToString();
                //errorClass.posId = MainWindow.posID;
                //errorClass.branchId = MainWindow.branchID;
                //errorClass.createUserId = MainWindow.userLogin.userId;
                //await errorClass.save(errorClass);

            }
            catch
            {

            }
        }
        static public void StartAwait(Grid grid)
        {
            grid.IsEnabled = false;
            grid.Opacity = 0.6;
            MahApps.Metro.Controls.ProgressRing progressRing = new MahApps.Metro.Controls.ProgressRing();
            progressRing.Name = "prg_awaitRing";
            progressRing.Foreground = App.Current.Resources["MainColorBlue"] as Brush;
            progressRing.IsActive = true;
            Grid.SetRowSpan(progressRing, 10);
            Grid.SetColumnSpan(progressRing, 10);
            grid.Children.Add(progressRing);
        }
        static public void EndAwait(Grid grid)
        {
            MahApps.Metro.Controls.ProgressRing progressRing = FindControls.FindVisualChildren<MahApps.Metro.Controls.ProgressRing>(grid)
                .Where(x => x.Name == "prg_awaitRing").FirstOrDefault();
            grid.Children.Remove(progressRing);

            var progressRingList = FindControls.FindVisualChildren<MahApps.Metro.Controls.ProgressRing>(grid)
                 .Where(x => x.Name == "prg_awaitRing");
            if (progressRingList.Count() == 0)
            {
                    grid.IsEnabled = true;
                    grid.Opacity = 1;
            }
        }

       
        

        public static bool chkPasswordLength(string password)
        {
            bool b = false;
            if (password.Length < 6)
                b = true;
            return b;
        }


    }
}
