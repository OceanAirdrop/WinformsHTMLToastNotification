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
            m_MessageBoxImage.SetImgLocation(px.X - pixelOffset, px.Y + 50);

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

        private string SaveIconBase64()
        {
            // https://www.iconfinder.com/icons/22623/disk_floppy_save_icon#size=64
            return "data:image/png;base64,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";
        }

        private string PencilIconBase64()
        {
            // https://www.iconfinder.com/icons/22604/edit_pencil_write_icon#size=64
            return "data:image/png;base64,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";
        }


        private string GenerateHTMLBase64ImageTest()
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
                        <p><strong>Tip:</strong> This is using a base 64 image: <img style='padding-left: 500px;' alt='Embedded Image' src='{000}' align='right'/>
                    </div>
                </body>
                </html>";

            str = str.Replace("{000}", SaveIconBase64());
           

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
        <p><strong>Tip: </strong> Don't Eat Yellow Snow!.
    </div>
</body>
</html>";

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

            int imgHeight =   m_htmlToast.GetHTMLHeight(GenerateHTML3()) + 65;
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

        private string GenerateHTMLToast(string title, string text, string type = "w3-warning")
        {
            string str = @"
                    <html>
                    <head>
                    <style>
	                    .w3-warning {
		                    background-color:#ffffcc;
		                    border-left:8px solid #ffeb3b;
		                    margin:0;
	                    }

                        .w3-error  {
	                        background-color:#ffdddd;
	                        border-left:6px solid #f44336;
	                        margin:0;
                        }

                        .w3-success {
	                        background-color:#dff0d8;
	                        border-left:6px solid #4bae4f;
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


        public void DisplayToastNotification(ToastNotificationType type, string title, string text, int timeOut = 4000)
        {
            m_htmlToast.Close();

            int offset = 15;

            string cssClass = "w3-success";
            switch (type)
            {
                case ToastNotificationType.Success:
                    cssClass = "w3-success";
                    break;
                case ToastNotificationType.Warning:
                    cssClass = "w3-warning";
                    break;
                case ToastNotificationType.Error:
                    cssClass = "w3-error ";
                    break;
            }

            string html = GenerateHTMLToast(title, text, cssClass);

            int imgHeight = m_htmlToast.GetHTMLHeight(html) + 5;
            int imgWidth = this.Width - 25;

            m_htmlToast.SetImgSize(imgWidth, imgHeight);
            m_htmlToast.SetHTML(html);



            Rectangle rect = this.Bounds;
            Point px = new Point(rect.Left, rect.Bottom);
            Point screenLocation = PointToScreen(px);

            m_htmlToast.SetImgLocation(px.X + offset, px.Y - imgHeight - offset);

            m_htmlToast.Show(timeOut);
        }

        private void buttonDebugTestSuccessToast_Click(object sender, EventArgs e)
        {
            DisplayToastNotification(ToastNotificationType.Success, "Success", "Something worked as expected");
        }

        private void buttonDebugTestWarningToast_Click(object sender, EventArgs e)
        {
            DisplayToastNotification(ToastNotificationType.Warning, "Warning", "Hmmm... You have just gone over budget!");
        }

        private void buttonDebugTestErrorToast_Click(object sender, EventArgs e)
        {
            DisplayToastNotification(ToastNotificationType.Error, "Error", "Something went bad.  Didnt expect that!");
        }

        private void buttonBase64Image_Click(object sender, EventArgs e)
        {
            var html = GenerateHTMLBase64ImageTest();

            m_htmlToast.Close();
            int offset = 15;

            int imgHeight = m_htmlToast.GetHTMLHeight(html) + 2;
            int imgWidth = this.Width - 25;

            m_htmlToast.SetImgSize(imgWidth, imgHeight);
            m_htmlToast.SetHTML(html);


            Rectangle rect = this.Bounds;
            Point px = new Point(rect.Left, rect.Bottom);

            m_htmlToast.SetImgLocation(px.X + offset, px.Y - imgHeight - offset);


            int imageTimeout = Convert.ToInt32(textBoxTimeOut.Text);
            m_htmlToast.Show(imageTimeout);
        }
    }
}
