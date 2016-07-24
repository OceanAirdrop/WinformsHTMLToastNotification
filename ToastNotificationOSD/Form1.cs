using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormUtils;

namespace ToastNotificationOSD
{
    public partial class Form1 : Form
    {
        bool m_bIsMainFormActive = false;

        FloatingImage m_MessageBoxImage = new FloatingImage();

        FloatingHTML m_htmlToast = new FloatingHTML();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = GenerateHTMLToastWithBoarder();
        }

        public void HideUserNotifications()
        {
            m_MessageBoxImage.Close();
            m_htmlToast.Close();
        }


        void DisplayPopupDialogImage(Bitmap img, int imgHeight, int imgWidth, int nSecTimeout)
        {
            if (this.WindowState == FormWindowState.Minimized || m_bIsMainFormActive == false)
                return;

            FloatingImage m_floatingImageDlg = new FloatingImage();

            Rectangle rect = this.Bounds;

            Point px = new Point(rect.Right, rect.Top);

            Point screenLocation = PointToScreen(px);
            m_floatingImageDlg.SetImage(img);
            m_floatingImageDlg.SetImgSize(imgHeight, imgWidth);
           

            m_floatingImageDlg.SetImgLocation(screenLocation.X - (imgWidth + (imgWidth / 2)), screenLocation.Y);

            m_floatingImageDlg.Show(nSecTimeout);
        }


        public void DisplayMessageBoxImage(Bitmap imageToDisplay)
        {
            m_MessageBoxImage.Close();

            if (this.WindowState == FormWindowState.Minimized || m_bIsMainFormActive == false)
                return;

            int imageTimeout =  Convert.ToInt32(textBoxTimeOut.Text); ; // 5 secs
            int imgHeight = 600;
            int imgWidth = 300;

            Rectangle rect = this.Bounds;
            Point px = new Point(rect.Right, rect.Top);
            Point screenLocation = PointToScreen(px);

            m_MessageBoxImage.SetImage(imageToDisplay);
            m_MessageBoxImage.SetImgSize(imgHeight, imgWidth);

            int pixelOffset = 400;
            m_MessageBoxImage.SetImgLocation(screenLocation.X - (imgWidth + pixelOffset), screenLocation.Y);

            m_MessageBoxImage.Show(imageTimeout);
        }

        void DisplayPopupDialogImageTest(ToolStripButton button)
        {
            if (this.WindowState == FormWindowState.Minimized || m_bIsMainFormActive == false)
                return;

            FloatingImage m_floatingImageDlg = new FloatingImage();

            int imgHeight = 600;
            int imgWidth = 300;

            Rectangle rect = button.Bounds;

            Point px = new Point(rect.Left, rect.Bottom);

            Point screenLocation = PointToScreen(px); //Point.Empty);
            //m_floatingImageDlg.SetImage(global::ECPApp.Properties.Resources.diag_arrow_up_right128);
            //m_floatingImageDlg.SetImage(global::ECPApp.Properties.Resources.text_popup_dialog);
            m_floatingImageDlg.SetImgSize(imgHeight, imgWidth);
            //m_floatingImageDlg.SetImgLocation(screenLocation.X - (imgWidth / 2), screenLocation.Y - imgHeight);
            //m_floatingImageDlg.SetImgLocation(screenLocation.X - imgWidth, screenLocation.Y - (imgWidth / 2));

            m_floatingImageDlg.SetImgLocation(screenLocation.X + imgWidth, screenLocation.Y);


            int imageTimeout = 5000; // 4 secs
            m_floatingImageDlg.Show(imageTimeout);
        }

   

        private void Form1_Activated(object sender, EventArgs e)
        {
            m_bIsMainFormActive = true;
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            HideUserNotifications();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            HideUserNotifications();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var image = Properties.Resources.cake;

            DisplayMessageBoxImage(image);
        }

        private string GenerateHTML1()
        {
            string str = @"

                boom!!<br/>
                <br/><br/><br/>
                <img src='data:image/gif;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAABGdBTUEAALGPC/xhBQAACgpJREFUaEPtWGlsVNcVZkkaigSCQAJJaBNIpFYNwXhf8ILxhnd7vI2XsT2bZzxjj+3ZZ + zxgg3eGLxgzE5C2BKa / Gh / VPnTqqmq / qlUVSoRv6ruTdW0WdoATQjn9DvPz24cQK1gQonkT7rye89v7j3n3O9859y3bAlLWMISIoJPL61bQZdXr1Fvv5q4dnGtXr38auLjcxv6bp7ZlKfePtxo63Stb + 90bQp5rI + oj5a9f2Sbgc48d5Wmnn5SffRwodPlW9He5a6E8b / AX1LHP3s91qF3DkQv / yj8gommthGHn / slH3ymkMKbt / LhJ1 / gl9el0utfz + bLq1epUz04uP3dK3zB3g3eQOhxh9MbgsH / 6HS5L / l8zpweny2lz2dpPdajNf56ZPvKT8a3nqXeDcT + NcxDmz + jmec / 4LPP / o4vrAvR + XXr1SkfHLo8 / jUOp + d8h8v7Z6c38EdE / qajyz0aCPpWqK8s4P3Jb9fR6JYb1PkokWEZUWAN0cTWP9CRLcnqK18OKqprV1bW1D2NvzvwN0pb3xilN1u / aXd0rUK0T8ABHhoeZ + wCjYYnOdQ / 9Fe3x7Vd / fmytyeSN914dctxPrXtJqjDFFxL7HyMuX8j08FnctXXIosqbcMand6U29rWccbm6Lpqa +/ 6m8XuuN5ia79hsbVfb23vfB / R / i2MvzEze5KDoX1w4iD94K0f8uyJU9zhdE7LPD8 / vv35D89tMNIrT2j56DMpfGhLEY1teY1Hv3GTJ7deo9EnVioLRgpV2voVepPF3NbhvGKxOW6VV9bQ7j05lJiUStGx8bQzJp6iMRKTU8lksdPI + ARdfuP7FJ48Qh1OL5nxrFFvpvZO53l1yttAE5tX0tGt++n0tg / UR5FBQ5PhRUT7p0aLjXLyCjhqZyy9tCOaZWx / aeei69z8Inb7e / jia2 / ShUtvSvS5Wd9CybvSucnQwm0Oh0Wd9o7gY0 + t4osb36aTT6xVH90fdM3GfHuH8y / gOEfHJCjGftHo + esdUTGE3eGZ2VMs0T95 + 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' alt='Base64 encoded image'/>
            ";

            return str;
        }

        private string GenerateHTML2()
        {
            return "<b>hello</b> there. Visit <a href=\"https://github.com/OceanAirdrop\">github.com/OceanAirdrop</a>  for code. Heres a <span style=\"color: red\">random</span> apple ";

        }

        private string GenerateHTML3()
        {
            string str = @"

<html>
    <head>
        <title>Intro</title>
        <link rel='Stylesheet' href='StyleSheet' />
    </head>

    <body style='background-color: #eee; background-gradient: #707; background-gradient-angle: 60; margin: 0; border-style: solid;'>
        <h1 align='center' style='color: white'>
            HTML Renderer Project - WinForms
            <br />
            <span style='font-size: x-small;'>Release 1.5.0.6</span>
        </h1>
        <blockquote class='whitehole'>
            <p style='margin-top: 0px'>
                <table border='0' width='100%'>
                    <tr style='vertical-align: top;'>
                        <td width='32' style='padding: 2px 5px 0 0'>
                            <img src='HtmlIcon' />
                        </td>
                        <td>
                            Everything you see on this panel (see samples on the left) is <b>custom-painted</b>
                            by the <b>HTML Renderer</b>, including tables, images, links and videos.<br />
                            This project allows you to have the rich format power of HTML on your desktop applications
                            without <b>WebBrowser</b> control or <b>MSHTML</b>.<br />
                            The library is <b>100% managed code</b> without any external dependencies, the only 
                            requirement is <b>.NET 2.0 or higher</b>, including support for Client Profile.
                        </td>
                    </tr>
                </table>
            </p>
        </blockquote>
    </body>
</html>

";

            return str;
        }


        private string GenerateHTML4()
        {
            // html taken from here: http://www.w3schools.com/html/html_css.asp
            string str = @"<div style='background-color:#ffffcc;padding:0.01em 16px;border-left:6px solid #ffeb3b;margin:20px 0;'>

                <p><strong>Tip:</strong> You can learn much more about CSS in our <a href='/css/default.asp'>CSS Tutorial</a>.
            </div>";

            return str;
        }

        private string GenerateHTML5()
        {
            // html taken from here: http://www.w3schools.com/html/html_css.asp
            string str = @"
                        <html>
                        <head>
                        <style>
                            .w3-note {
	                            background-color:#ffffcc;
	                            padding:0.01em 16px;
	                            border-left:6px solid #ffeb3b;
	                            margin:20px 0;
                            }
                        </style>
                        </head>
                            <body>
                                <div class='w3-note'>
                                    <p><strong>Tip:</strong> You can learn much more about CSS in our <a href='/css/default.asp'>CSS Tutorial</a>.
                                </div>
                            </body>
                        </html>";

            return str;
        }

        private string GenerateHTML6()
        {
            // html taken from here: http://www.w3schools.com/html/html_css.asp
            string str = @"
                        <html>
                        <head>
                        <style>
                            .w3-note {
	                            background-color:#ffffcc;
	                            border-left:6px solid #ffeb3b;
	                            margin:0;
                            }
                        </style>
                        </head>
                            <body>
                                <div class='w3-note'>
                                    <p><strong>Tip:</strong> You can learn much more about CSS in our <a href='/css/default.asp'>CSS Tutorial</a>.
                                </div>
                            </body>
                        </html>";

            return str;
        }

        private string GenerateHTMLToastNoBoarder()
        {
            string str = @"

                <html>
                <head>
                <style>
                    .w3-note {
	                    background-color:#ffffcc;
	                    border-left:6px solid #ffeb3b;
	                    margin:0;
                    }
                </style>
                </head>
                <body style='margin: 0;'>
                    <div class='w3-note'>
                        <p><strong>Tip:</strong> You can learn much more about CSS in our <a href='/css/default.asp'>CSS Tutorial</a>.
                    </div>
                </body>
                </html>";

            return str;
        }

        private string GenerateHTMLToastWithBoarder()
        {
            string str = @"
<html>
<head>
<style>
    .w3-note {
	    background-color:#ffffcc;
	    border-left:8px solid #ffeb3b;
	    margin:0;
    }
</style>
</head>
<body style='margin: 0; border-style: solid;'>
    <div class='w3-note'>
        <p><strong>Tip: </strong> You can learn much more about CSS in our <a href='/css/default.asp'>CSS Tutorial</a>.
    </div>
</body>
</html>";

            return str;
        }

        private string GenerateHTMLToastWithBoarder2(string title, string text, string type = "w3-note")
        {
            string str = @"
                    <html>
                    <head>
                    <style>
	                    .w3-note {
		                    background-color:#ffffcc;
		                    border-left:8px solid #ffeb3b;
		                    margin:0;
	                    }

                        .w3-warning {
	                        background-color:#ffdddd;
	                        border-left:6px solid #f44336;
	                        margin:0;
                        }
                    </style>
                    </head>
                    <body style='margin: 0; border-style: solid;'>
	                    <div class='{000}'>
		                    <p><strong>{111}: </strong>{222}
	                    </div>
                    </body>
                    </html>";

            str = str.Replace("{000}", type);
            str = str.Replace("{111}", title);
            str = str.Replace("{222}", text);
            return str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_htmlToast.Close();

            string html = richTextBox1.Text; // GenerateHTMLToastNoBoarder();

            int imgHeight = m_htmlToast.GetHTMLHeight(html);
            int imgWidth = 1000;

            m_htmlToast.SetImgSize(imgWidth, imgHeight);
            m_htmlToast.SetHTML(html);

            
          
            Rectangle rect = button2.Bounds;
            Point px = new Point(rect.Left, rect.Bottom);
            Point screenLocation = PointToScreen(px);

            //m_htmlToast.SetImgLocation(screenLocation.X, screenLocation.Y);

            m_htmlToast.SetImgLocation(Convert.ToInt32(textBoxX.Text), Convert.ToInt32(textBoxY.Text));




            int imageTimeout = Convert.ToInt32(textBoxTimeOut.Text);
            m_htmlToast.Show(imageTimeout);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_htmlToast.Close();

            int imgHeight =   m_htmlToast.GetHTMLHeight(GenerateHTML3()) + 2;
            int imgWidth = 1000;

            m_htmlToast.SetImgSize(imgWidth, imgHeight);
            m_htmlToast.SetHTML(GenerateHTML3());



            Rectangle rect = button2.Bounds;
            Point px = new Point(rect.Left, rect.Bottom);
            Point screenLocation = PointToScreen(px);

            m_htmlToast.SetImgLocation(screenLocation.X, screenLocation.Y);


            int imageTimeout = Convert.ToInt32(textBoxTimeOut.Text);
            m_htmlToast.Show(imageTimeout);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int offset = 15;

            string html = GenerateHTMLToastWithBoarder();

            int imgHeight = m_htmlToast.GetHTMLHeight(html)+2;
            int imgWidth = this.Width - 25;

            m_htmlToast.SetImgSize(imgWidth, imgHeight);
            m_htmlToast.SetHTML(html);



            Rectangle rect = this.Bounds;
            Point px = new Point(rect.Left, rect.Bottom);
            Point screenLocation = PointToScreen(px);

            m_htmlToast.SetImgLocation(screenLocation.X, screenLocation.Y);

            m_htmlToast.SetImgLocation(px.X + offset, px.Y - imgHeight - offset);


            int imageTimeout = Convert.ToInt32(textBoxTimeOut.Text);
            m_htmlToast.Show(imageTimeout);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            m_htmlToast.Close();
            int offset = 15;

            string html = GenerateHTMLToastWithBoarder2(" Warning", "You have gone over capacity");

            int imgHeight = m_htmlToast.GetHTMLHeight(html) + 2;
            int imgWidth = this.Width - 25;

            m_htmlToast.SetImgSize(imgWidth, imgHeight);
            m_htmlToast.SetHTML(html);



            Rectangle rect = this.Bounds;
            Point px = new Point(rect.Left, rect.Bottom);
            Point screenLocation = PointToScreen(px);

            m_htmlToast.SetImgLocation(screenLocation.X, screenLocation.Y);

            m_htmlToast.SetImgLocation(px.X + offset, px.Y - imgHeight - offset);


            int imageTimeout = 5000;
            m_htmlToast.Show(imageTimeout);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            m_htmlToast.Close();

            int offset = 15;

            string html = GenerateHTMLToastWithBoarder2("Error", "The Location is in the wrong format", "w3-warning");

            int imgHeight = m_htmlToast.GetHTMLHeight(html) + 2;
            int imgWidth = this.Width - 25;

            m_htmlToast.SetImgSize(imgWidth, imgHeight);
            m_htmlToast.SetHTML(html);



            Rectangle rect = this.Bounds;
            Point px = new Point(rect.Left, rect.Bottom);
            Point screenLocation = PointToScreen(px);

            m_htmlToast.SetImgLocation(screenLocation.X, screenLocation.Y);

            m_htmlToast.SetImgLocation(px.X + offset, px.Y - imgHeight - offset);


            int imageTimeout = 5000;
            m_htmlToast.Show(imageTimeout);
        }

        private void buttonCustomHTML_Click(object sender, EventArgs e)
        {
            m_htmlToast.Close();
            int offset = 15;

            string html = richTextBox1.Text;

            int imgHeight = m_htmlToast.GetHTMLHeight(html) + 2;
            int imgWidth = this.Width - 25;

            m_htmlToast.SetImgSize(imgWidth, imgHeight);
            m_htmlToast.SetHTML(html);



            Rectangle rect = this.Bounds;
            Point px = new Point(rect.Left, rect.Bottom);
            Point screenLocation = PointToScreen(px);

            m_htmlToast.SetImgLocation(screenLocation.X, screenLocation.Y);

            m_htmlToast.SetImgLocation(px.X + offset, px.Y - imgHeight - offset);


            int imageTimeout = Convert.ToInt32(textBoxTimeOut.Text);
            m_htmlToast.Show(imageTimeout);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var image = Properties.Resources.diag_arrow_up_right256;

            DisplayMessageBoxImage(image);
        }
    }
}
