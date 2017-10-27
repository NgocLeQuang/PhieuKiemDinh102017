using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhieuKiemDinh.MyClass;

namespace PhieuKiemDinh.MyUserControl
{
    public delegate void AllTextChange(object sender, EventArgs e);
    public partial class uc_DeSo : UserControl
    {
        public event AllTextChange Changed;
        private bool is_focus;

        public uc_DeSo()
        {
            InitializeComponent();
        }

        public void curency(TextEdit luong)
        {
            try
            {
                string t;
                string txt, txt1;
                txt1 = luong.Text.Replace(",", "");
                txt = "";
                int n = txt1.Length;
                int dem = 0;

                if (luong.Text.Length > 0)
                {
                    if (luong.Text.Substring(0, 1) == "-")
                    {
                        if (luong.Text.Length > 1)
                        {
                            if (luong.SelectionLength != luong.Text.Length)
                            {
                                if (luong.Text != "?")
                                {
                                    for (int i = n - 1; i >= 0; i--)
                                    {
                                        if (dem == 2 && i != 0)
                                        {
                                            txt = "," + txt1.Substring(i, 1) + txt;
                                            dem = 0;
                                        }
                                        else
                                        {
                                            txt = txt1.Substring(i, 1) + txt;
                                            dem += 1;
                                        }
                                    }
                                    luong.Text = txt;
                                    luong.Select(luong.Text.Length, 0);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (luong.SelectionLength != luong.Text.Length)
                        {
                            if (luong.Text != "?")
                            {
                                for (int i = n - 1; i >= 0; i--)
                                {
                                    if (dem == 2 && i != 0)
                                    {
                                        txt = "," + txt1.Substring(i, 1) + txt;
                                        dem = 0;
                                    }
                                    else
                                    {
                                        txt = txt1.Substring(i, 1) + txt;
                                        dem += 1;
                                    }
                                }
                                luong.Text = txt;
                                luong.Select(luong.Text.Length, 0);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void ResetData()
        {
            txt_TruongSo01.Text = "";
            txt_TruongSo03.Text = "";
            txt_TruongSo04.Text = "";
            txt_TruongSo05.Text = "";
            txt_TruongSo06.Text = "";
            txt_TruongSo07.Text = "";
            txt_TruongSo08_1.Text = "";
            txt_TruongSo08_2.Text = "";
            txt_TruongSo09.Text = "";
            txt_TruongSo10.Text = "";
            txt_TruongSo11.Text = "";
            txt_TruongSo12.Text = "";
            txt_TruongSo13.Text = "";
            txt_TruongSo14.Text = "";
           // txt_FlagError.Text = "";

            txt_TruongSo01.BackColor = Color.White;
            txt_TruongSo03.BackColor = Color.White;
            txt_TruongSo04.BackColor = Color.White;
            txt_TruongSo05.BackColor = Color.White;
            txt_TruongSo06.BackColor = Color.White;
            txt_TruongSo07.BackColor = Color.White;
            txt_TruongSo08_1.BackColor = Color.White;
            txt_TruongSo08_2.BackColor = Color.White;
            txt_TruongSo09.BackColor = Color.White;
            txt_TruongSo10.BackColor = Color.White;
            txt_TruongSo11.BackColor = Color.White;
            txt_TruongSo12.BackColor = Color.White;
            txt_TruongSo13.BackColor = Color.White;
            txt_TruongSo14.BackColor = Color.White;
            //txt_FlagError.BackColor = Color.White;
        }

        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_TruongSo03.Text) &&
                string.IsNullOrEmpty(txt_TruongSo04.Text) &&
                string.IsNullOrEmpty(txt_TruongSo05.Text) &&
                string.IsNullOrEmpty(txt_TruongSo06.Text) &&
                string.IsNullOrEmpty(txt_TruongSo07.Text) &&
                string.IsNullOrEmpty(txt_TruongSo08_1.Text) &&
                string.IsNullOrEmpty(txt_TruongSo08_2.Text) &&
                string.IsNullOrEmpty(txt_TruongSo09.Text) &&
                string.IsNullOrEmpty(txt_TruongSo10.Text) &&
                string.IsNullOrEmpty(txt_TruongSo11.Text) &&
                string.IsNullOrEmpty(txt_TruongSo12.Text) &&
                string.IsNullOrEmpty(txt_TruongSo13.Text) &&
                string.IsNullOrEmpty(txt_TruongSo14.Text) //&&
               // string.IsNullOrEmpty(txt_FlagError.Text)
               )
                return true;
            return false;
        }

        public void SetValue(DESO deso)
        {
            txt_TruongSo01.Text = deso.TruongSo01;
            txt_TruongSo03.Text = deso.TruongSo03;
            txt_TruongSo04.Text = deso.TruongSo04;
            txt_TruongSo05.Text = deso.TruongSo05;
            txt_TruongSo06.Text = deso.TruongSo06;
            txt_TruongSo07.Text = deso.TruongSo07;
            txt_TruongSo08_1.Text = deso.TruongSo08_1;
            txt_TruongSo08_1.Text = deso.TruongSo08_2;
            txt_TruongSo09.Text = deso.TruongSo09;
            txt_TruongSo10.Text = deso.TruongSo10;
            txt_TruongSo11.Text = deso.TruongSo11;
            txt_TruongSo12.Text = deso.TruongSo12;
            txt_TruongSo13.Text = deso.TruongSo13;
            txt_TruongSo14.Text = deso.TruongSo14;
           // txt_FlagError.Text = deso.FlagError;
        }
        
        private void DoiMau(int soByteBe, int soBytelon, TextEdit textBox)
        {
            if(!string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Text != "?")
                {
                    if (textBox.Text.Length >= soByteBe && textBox.Text.Length <= soBytelon)
                    {
                        textBox.BackColor = Color.White;
                        textBox.ForeColor = Color.Black;
                    }
                    else
                    {
                        textBox.BackColor = Color.Red;
                        textBox.ForeColor = Color.White;
                    }
                }
                else
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.Black;
                }
            }
            else
            {
                textBox.BackColor = Color.White;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txt_TruongSo01_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }

        private void txt_Note_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }
        
        private void txt_TruongSo03_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_TruongSo03.Text))
            {
                if (txt_TruongSo03.Text!="?")
                {
                    if (int.Parse(txt_TruongSo03.Text) > 3 || int.Parse(txt_TruongSo03.Text) < 1|| txt_TruongSo03.Text.Length>1)
                    {
                        txt_TruongSo03.BackColor = Color.Red;
                        txt_TruongSo03.ForeColor= Color.White;
                    }
                    else
                    {
                        txt_TruongSo03.BackColor = Color.White;
                        txt_TruongSo03.ForeColor = Color.Black;
                    }
                }
                else
                {
                    txt_TruongSo03.BackColor = Color.White;
                    txt_TruongSo03.ForeColor = Color.Black;
                }
            }
            else
            {
                txt_TruongSo03.BackColor = Color.White;
                txt_TruongSo03.ForeColor = Color.Black;
            }
            Changed?.Invoke(sender, e);
        }
      
        private void txt_TruongSo04_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_TruongSo04.Text.Length > 8)
            {
                txt_TruongSo04.BackColor = Color.Red;
                txt_TruongSo04.ForeColor = Color.White;
            }
            else
            {
                txt_TruongSo04.BackColor = Color.White;
                txt_TruongSo04.ForeColor = Color.Black;
            }
            Changed?.Invoke(sender, e);
        }

        private void txt_TruongSo05_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }

        private void txt_TruongSo06_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }

        private void txt_TruongSo07_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }

        private void txt_TruongSo08_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }

        private void txt_TruongSo09_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_TruongSo09.Text.Length > 20)
            {
                txt_TruongSo09.BackColor = Color.Red;
                txt_TruongSo09.ForeColor = Color.White;
            }
            else
            {
                txt_TruongSo09.BackColor = Color.White;
                txt_TruongSo09.ForeColor = Color.Black;
            }
            Changed?.Invoke(sender, e);
        }

        private void txt_TruongSo10_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_TruongSo10.Text) && txt_TruongSo10.Text != "?")
            {

                // trường hợp ngoài/*int.Parse(txt_TruongSo10.Text) > 311231 || int.Parse(txt_TruongSo10.Text) < 291001||
                if (txt_TruongSo10.Text.Length != 6)
                {
                    txt_TruongSo10.BackColor = Color.Red;
                    txt_TruongSo10.ForeColor = Color.White;
                }
                else
                {
                    txt_TruongSo10.BackColor = Color.White;
                    txt_TruongSo10.ForeColor = Color.Black;
                }
                /*   else
                    {
                        try
                        {
                            if (int.Parse(txt_TruongSo10.Text.Substring(2,2)+"")>12|| int.Parse(txt_TruongSo10.Text.Substring(4, 2) + "") > 31)
                            {
                                txt_TruongSo10.BackColor = Color.Red;
                                txt_TruongSo10.ForeColor = Color.White;
                            }
                            else
                            {
                                txt_TruongSo10.BackColor = Color.White;
                                txt_TruongSo10.ForeColor = Color.Black;
                            }
                        }
                        catch { }
                    }*/

            }
            else
            {
                txt_TruongSo10.BackColor = Color.White;
                txt_TruongSo10.ForeColor = Color.Black;
            }
           
            Changed?.Invoke(sender, e);
        }

        private void txt_TruongSo10_Leave(object sender, EventArgs e)
        {
             //// if (txt_TruongSo10.Text.Length < 6 & !string.IsNullOrEmpty(txt_TruongSo10.Text))
             //  //   txt_TruongSo10.Text = "?";
             // //Gọi change
             // if (!string.IsNullOrEmpty(txt_TruongSo10.Text))
             // {
             //     if (txt_TruongSo10.Text != "?")
             //     {
             //         // trường hợp ngoài
             //         if (/*int.Parse(txt_TruongSo10.Text) > 311231 || int.Parse(txt_TruongSo10.Text) < 291001 ||*/ txt_TruongSo10.Text.Length != 6)
             //         {
             //             txt_TruongSo10.BackColor = Color.Red;
             //             txt_TruongSo10.ForeColor = Color.White;
             //       }
             //       else
             //       {
             //           txt_TruongSo10.BackColor = Color.White;
             //           txt_TruongSo10.ForeColor = Color.Black;
             //       }
             //       /*  else
             //         {
             //             try
             //             {
             //                 if (int.Parse(txt_TruongSo10.Text.Substring(2, 2) + "") > 12 || int.Parse(txt_TruongSo10.Text.Substring(4, 2) + "") > 31)
             //                 {
             //                     txt_TruongSo10.BackColor = Color.Red;
             //                     txt_TruongSo10.ForeColor = Color.White;
             //                 }
             //                 else
             //                 {
             //                     txt_TruongSo10.BackColor = Color.White;
             //                     txt_TruongSo10.ForeColor = Color.Black;
             //                 }
             //             }
             //             catch { }
             //         }*/
             //   }
             //     else
             //     {
             //         txt_TruongSo10.BackColor = Color.White;
             //         txt_TruongSo10.ForeColor = Color.Black;
             //     }
             // }
             // else
             // {
             //     txt_TruongSo10.BackColor = Color.White;
             //     txt_TruongSo10.ForeColor = Color.Black;
             // }
           
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong10 = txt_TruongSo10.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo11_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_TruongSo11.Text) && txt_TruongSo11.Text != "?")
            {
                if (int.Parse(txt_TruongSo11.Text) > 291231 || int.Parse(txt_TruongSo11.Text) < 291001 || txt_TruongSo10.Text.Length != 6)
                {
                    txt_TruongSo11.BackColor = Color.Red;
                    txt_TruongSo11.ForeColor = Color.White;
                }
                else
                {
                    try
                    {
                        if (int.Parse(txt_TruongSo11.Text.Substring(2, 2) + "") > 12 || int.Parse(txt_TruongSo11.Text.Substring(4, 2) + "") > 31)
                        {
                            txt_TruongSo11.BackColor = Color.Red;
                            txt_TruongSo11.ForeColor = Color.White;
                        }
                        else
                        {
                            txt_TruongSo11.BackColor = Color.White;
                            txt_TruongSo11.ForeColor = Color.Black;
                        }
                    }
                    catch { }
                }
            }
            else
            {
                txt_TruongSo11.BackColor = Color.White;
                txt_TruongSo11.ForeColor = Color.Black;
            }
            Changed?.Invoke(sender, e);
        }

        private void txt_TruongSo11_Leave(object sender, EventArgs e)
        {
            /*
            //Gọi change 10
            if (!string.IsNullOrEmpty(txt_TruongSo10.Text))
            {
                if (txt_TruongSo10.Text != "?")
                {
                    // trường hợp ngoài
                    if (int.Parse(txt_TruongSo10.Text) > 311231 || int.Parse(txt_TruongSo10.Text) < 291001 || txt_TruongSo10.Text.Length != 6)
                    {
                        txt_TruongSo10.BackColor = Color.Red;
                        txt_TruongSo10.ForeColor = Color.White;
                    }
                    else
                    {
                        try
                        {
                            if (int.Parse(txt_TruongSo10.Text.Substring(2, 2) + "") > 12 || int.Parse(txt_TruongSo10.Text.Substring(4, 2) + "") > 31)
                            {
                                txt_TruongSo10.BackColor = Color.Red;
                                txt_TruongSo10.ForeColor = Color.White;
                            }
                            else
                            {
                                txt_TruongSo10.BackColor = Color.White;
                                txt_TruongSo10.ForeColor = Color.Black;
                            }
                        }
                        catch { }
                    }
                }
                else
                {
                    txt_TruongSo10.BackColor = Color.White;
                    txt_TruongSo10.ForeColor = Color.Black;
                }
            }
            else
            {
                txt_TruongSo10.BackColor = Color.White;
                txt_TruongSo10.ForeColor = Color.Black;
            }

            // So sánh
            if (string.IsNullOrEmpty(txt_TruongSo11.Text) & string.IsNullOrEmpty(txt_TruongSo10.Text))
            {
                txt_TruongSo10.BackColor = Color.White;
                txt_TruongSo10.ForeColor = Color.Black;
            }
            else if (string.IsNullOrEmpty(txt_TruongSo10.Text) & !string.IsNullOrEmpty(txt_TruongSo11.Text))
            {
                txt_TruongSo10.BackColor = Color.Red;
                txt_TruongSo10.ForeColor = Color.White;
            }
            else if(txt_TruongSo11.Text.Length==6)
            {
                try
                {
                    if (int.Parse(txt_TruongSo10.Text.Substring(0, 2) + "") < int.Parse(txt_TruongSo11.Text.Substring(0, 2) + "") & int.Parse(txt_TruongSo11.Text.Substring(0, 2) + "") <= 29)
                    {
                        txt_TruongSo10.BackColor = Color.Red;
                        txt_TruongSo10.ForeColor = Color.White;
                    }
                    else if (int.Parse(txt_TruongSo10.Text.Substring(0, 2) + "") == int.Parse(txt_TruongSo11.Text.Substring(0, 2) + "") & int.Parse(txt_TruongSo10.Text.Substring(0, 2) + "") <= 31 & int.Parse(txt_TruongSo11.Text.Substring(0, 2) + "") <= 29)
                    {
                        if (int.Parse(txt_TruongSo10.Text.Substring(2, 2) + "") < int.Parse(txt_TruongSo11.Text.Substring(2, 2) + "") & int.Parse(txt_TruongSo10.Text.Substring(2, 2) + "") <= 12 & int.Parse(txt_TruongSo11.Text.Substring(2, 2) + "")<=12)
                        {
                            txt_TruongSo10.BackColor = Color.Red;
                            txt_TruongSo10.ForeColor = Color.White;
                        }
                        else if (int.Parse(txt_TruongSo10.Text.Substring(2, 2) + "") == int.Parse(txt_TruongSo11.Text.Substring(2, 2) + ""))
                        {
                            if (int.Parse(txt_TruongSo10.Text.Substring(4, 2) + "") < int.Parse(txt_TruongSo11.Text.Substring(4, 2) + "") & int.Parse(txt_TruongSo10.Text.Substring(4, 2) + "") <= 31 & int.Parse(txt_TruongSo11.Text.Substring(4, 2) + "")<=31)
                            {
                                txt_TruongSo10.BackColor = Color.Red;
                                txt_TruongSo10.ForeColor = Color.White;
                            }
                            else
                            {
                                txt_TruongSo10.BackColor = Color.White;
                                txt_TruongSo10.ForeColor = Color.Black;
                            }
                        }
                    }
                }
                catch { }
            }*/
            ////Gọi change 11
            //if (!string.IsNullOrEmpty(txt_TruongSo11.Text))
            //{
            //    if (txt_TruongSo11.Text != "?")
            //    {
            //        if (int.Parse(txt_TruongSo11.Text) > 291231 || int.Parse(txt_TruongSo11.Text) < 291001)
            //        {
            //            txt_TruongSo11.BackColor = Color.Red;
            //            txt_TruongSo11.ForeColor = Color.White;
            //        }
            //        else
            //        {
            //            try
            //            {
            //                if (int.Parse(txt_TruongSo11.Text.Substring(2, 2) + "") > 12 || int.Parse(txt_TruongSo11.Text.Substring(4, 2) + "") > 31)
            //                {
            //                    txt_TruongSo11.BackColor = Color.Red;
            //                    txt_TruongSo11.ForeColor = Color.White;
            //                }
            //                else
            //                {
            //                    txt_TruongSo11.BackColor = Color.White;
            //                    txt_TruongSo11.ForeColor = Color.Black;
            //                }
            //            }
            //            catch { }
            //        }
            //    }
            //    else
            //    {
            //        txt_TruongSo11.BackColor = Color.White;
            //        txt_TruongSo11.ForeColor = Color.Black;
            //    }
            //}
            //else
            //{
            //    txt_TruongSo11.BackColor = Color.White;
            //    txt_TruongSo11.ForeColor = Color.Black;
            //}

            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong11 = txt_TruongSo11.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo12_EditValueChanged(object sender, EventArgs e)
        {
            /* if (!string.IsNullOrEmpty(txt_TruongSo12.Text))
             {
                 if (txt_TruongSo12.Text != "?")
                 {
                     if (int.Parse(txt_TruongSo12.Text) > 27 || int.Parse(txt_TruongSo12.Text) < 0)
                     {
                         txt_TruongSo12.BackColor = Color.Red;
                         txt_TruongSo12.ForeColor = Color.White;
                     }
                     else
                     {
                         txt_TruongSo12.BackColor = Color.White;
                         txt_TruongSo12.ForeColor = Color.Black;
                     }
                 }
                 else
                 {
                     txt_TruongSo12.BackColor = Color.White;
                     txt_TruongSo12.ForeColor = Color.Black;
                 }

             }
             else
             {
                 txt_TruongSo12.BackColor = Color.White;
                 txt_TruongSo12.ForeColor = Color.Black;
             }*/
            if (txt_TruongSo12.Text.Length > 2)
            {
                txt_TruongSo12.BackColor = Color.Red;
                txt_TruongSo12.ForeColor = Color.White;
            }
            else
            {
                txt_TruongSo12.BackColor = Color.White;
                txt_TruongSo12.ForeColor = Color.Black;
            }
            Changed?.Invoke(sender, e);
        }

        private void txt_TruongSo13_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_TruongSo13.Text.Length > 8)
            {
                txt_TruongSo13.BackColor = Color.Red;
                txt_TruongSo13.ForeColor = Color.White;
            }
            else
            {
                txt_TruongSo13.BackColor = Color.White;
                txt_TruongSo13.ForeColor = Color.Black;
            }
            Changed?.Invoke(sender, e);
        }

        private void txt_TruongSo14_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_TruongSo14.Text.Length > 3)
            {
                txt_TruongSo14.BackColor = Color.Red;
                txt_TruongSo14.ForeColor = Color.White;
            }
            else
            {
                txt_TruongSo14.BackColor = Color.White;
                txt_TruongSo14.ForeColor = Color.Black;
            }
            Changed?.Invoke(sender, e);
        }

        private void uc_DeSo_Load(object sender, EventArgs e)
        {
            txt_TruongSo03.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo04.GotFocus += Txt_TruongSo04_GotFocus; 
            txt_TruongSo05.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo06.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo07.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo08_1.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo08_2.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo09.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo10.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo11.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo12.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo13.GotFocus += Txt_TruongSo03_GotFocus;
            txt_TruongSo14.GotFocus += Txt_TruongSo03_GotFocus;
           // txt_FlagError.GotFocus += Txt_TruongSo03_GotFocus;

        }

        private void Txt_TruongSo03_GotFocus(object sender, EventArgs e)
        {
            ((TextEdit)sender).SelectAll();
        }

        private void Txt_TruongSo04_GotFocus(object sender, EventArgs e)
        {
            is_focus = true;
            ((TextEdit)sender).SelectAll();
            
        }

        private void txt_TruongSo04_Leave(object sender, EventArgs e)
        {
            is_focus = false;
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong4 = txt_TruongSo04.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo04_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                curency((TextEdit)sender);
            }
            catch
            {
                // ignored
            }
        }

        private void txt_TruongSo03_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong3 = txt_TruongSo03.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo05_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong5 = txt_TruongSo05.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo06_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong6 = txt_TruongSo06.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo07_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong7 = txt_TruongSo07.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo08_1_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong8_1 = txt_TruongSo08_1.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo08_2_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong8_2 = txt_TruongSo08_2.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo09_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong9 = txt_TruongSo09.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo12_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong12 = txt_TruongSo12.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo13_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong13 = txt_TruongSo13.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_TruongSo14_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.Truong14 = txt_TruongSo14.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_FlagError_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Properties.Settings.Default.FlagError = txt_FlagError.Text;
            Properties.Settings.Default.Save();
        }
    }
}
