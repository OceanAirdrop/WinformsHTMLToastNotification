using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormUtils
{
    public class FloatingOSDWindow : FloatingWindow
    {
        #region Variables
        private SolidBrush _brush;
        private System.Drawing.StringFormat _stringFormat;
        private Rectangle _rScreen;
        private System.Windows.Forms.Timer _viewClock;
        private Font _textFont;
        private string _text;
        private AnimateMode _mode;
        private uint _time;
        private GraphicsPath _gp;
        #endregion

        #region Public Methods
        /// <summary>
        /// Show given text on OSD-window
        /// </summary>
        /// <param name="pt">Top-left corner of text in screen coordinates</param>
        /// <param name="alpha">Transparency of text</param>
        /// <param name="textColor">Color of text</param>
        /// <param name="textFont">Font of text</param>
        /// <param name="showTimeMSec">How long text will be remain on screen, in millisecond</param>
        /// <param name="mode">Effect to be applied. Work only if <c>time</c> greater than 0</param>
        /// <param name="time">Time, in milliseconds, for effect playing. If this equal to 0 <c>mode</c> ignored and text showed at once</param>
        /// <param name="text">Text to display</param>
        public void Show(Point pt, byte alpha, Color textColor, Font textFont, int showTimeMSec,  AnimateMode mode, uint time, string text)
        {
            if(this._viewClock!=null)
            {
                _viewClock.Stop();
                _viewClock.Dispose();
            }
            this._brush = new SolidBrush(textColor);
            this._textFont = textFont;
            this._text = text;
            this._mode = mode;
            this._time = time;
            SizeF textArea;
            this._rScreen = Screen.PrimaryScreen.Bounds;
            if(this._stringFormat == null)
            {
                this._stringFormat = new StringFormat();
                this._stringFormat.Alignment = StringAlignment.Near;
                this._stringFormat.LineAlignment = StringAlignment.Near;
                this._stringFormat.Trimming = StringTrimming.EllipsisWord;
            }
            using(Bitmap bm = new Bitmap(base.Width, base.Height))
                using(Graphics fx = Graphics.FromImage(bm))
                    textArea = fx.MeasureString(text, textFont, this._rScreen.Width, this._stringFormat);
            base.Location = pt;
            base.Alpha = alpha;
            base.Size = new Size((int)Math.Ceiling(textArea.Width), (int)Math.Ceiling(textArea.Height));
            if(time > 0)
                base.ShowAnimate(mode, time);
            else
                base.Show();
            _viewClock = new System.Windows.Forms.Timer();
            _viewClock.Tick += new System.EventHandler(viewTimer);
            _viewClock.Interval = showTimeMSec;
            _viewClock.Start();
        }
        #endregion

        #region Overrided Drawing & Path Creation
        protected override void PerformPaint(PaintEventArgs e)
        {
            if(base.Handle == IntPtr.Zero)
                return;
            Graphics g = e.Graphics;
            if(this._gp != null)
                this._gp.Dispose();
            this._gp = new GraphicsPath();
            this._gp.AddString(this._text, this._textFont.FontFamily, (int)this._textFont.Style, g.DpiY * this._textFont.SizeInPoints / 72, base.Bound, this._stringFormat);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(this._brush, this._gp);
        }
        #endregion 

        #region Timers
        protected void viewTimer(object sender, System.EventArgs e)
        {
            this._viewClock.Stop();
            this._viewClock.Dispose();
            if(this._time > 0)
                this.HideAnimate(this._mode, this._time);
            this.Close();
        }
        #endregion
    }
}
