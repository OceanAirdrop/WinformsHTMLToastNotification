using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace WinFormUtils
{
    class FloatingHTML : FloatingWindow
    {
        Bitmap m_bitmap = null;
        Image m_image = null;

        private System.Windows.Forms.Timer _viewClock;

        public void SetImage(Bitmap image)
        {
            m_bitmap = image;
        }

        public void SetHTML(string htmlText, bool autoSize = false)
        {
            //m_image = HtmlRender.RenderToImage(htmlText); //,, maxWidth: cellSize.Width);
            var tmpImage = HtmlRender.RenderToImage(htmlText );

           // m_image = HtmlRender.RenderToImage(htmlText, maxWidth: 1000);

            if (autoSize == true )
            {
                m_image = HtmlRender.RenderToImage(htmlText, tmpImage.Height, tmpImage.Width);
            }
            else
                m_image = HtmlRender.RenderToImage(htmlText, _size);
        }

        public int GetHTMLHeight(string htmlText)
        {
            var image = HtmlRender.RenderToImage(htmlText);

            return image.Height;
        }


        public void CloseImage()
        {
            if (this._viewClock != null)
            {
                this._viewClock.Stop();
                this._viewClock.Dispose();
                this.Close();
            }
        }

        private Image GenerateHTMLImage()
        {
            string htmlText = "<b>hello</b> there. Visit <a href=\"https://github.com/OceanAirdrop\">github.com/OceanAirdrop</a>  for code. Heres a <span style=\"color: red\">random</span> apple ";
            Image img = HtmlRender.RenderToImage(htmlText); //,, maxWidth: cellSize.Width);

            return img;

            // Step 4: Keep a record of the full image size to send back to caller.
          //  fullImageSize.Height = htmlImage.Height;
         //   fullImageSize.Width = htmlImage.Width;

            // Step 5: Render the HTML imaage a second time with the cell size width / height
            //img = HtmlRender.RenderToImage(htmlText, new Size(cellSize.Width, cellSize.Height));
        }

        public void Show(int showTimeMSec)
        {
            if (this._viewClock != null)
            {
                _viewClock.Stop();
                _viewClock.Dispose();
            }

            base.Show();

            _viewClock = new System.Windows.Forms.Timer();
            _viewClock.Tick += new System.EventHandler(viewTimer);
            _viewClock.Interval = showTimeMSec;
            _viewClock.Start();
        }

        protected override void PerformPaint(PaintEventArgs e)
        {
            if (base.Handle == IntPtr.Zero)
                return;

            // This function will grab a graphics object from the image and then draw another image on-top
            //Graphics g = Graphics.FromImage(img);

            //// elipsis
            //g.DrawImage(Resources.elipsis, new Point(img.Width - Resources.elipsis.Width, img.Height - Resources.elipsis.Height));

            e.Graphics.DrawImage(m_image, 0, 0);
        }

        protected void viewTimer(object sender, System.EventArgs e)
        {
            this._viewClock.Stop();
            this._viewClock.Dispose();
            this.Close();
        }

    }
}
