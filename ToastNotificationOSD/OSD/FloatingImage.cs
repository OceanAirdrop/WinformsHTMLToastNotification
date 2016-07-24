using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormUtils
{
    class FloatingImage : FloatingWindow
    {
        Bitmap m_bitmap = null; 

        private System.Windows.Forms.Timer _viewClock;

        public void SetImage(Bitmap image)
        {
            m_bitmap = image;
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

            e.Graphics.DrawImage(m_bitmap, 0, 0);
        }

        protected void viewTimer(object sender, System.EventArgs e)
        {
            this._viewClock.Stop();
            this._viewClock.Dispose();
            this.Close();
        }

    }
}
