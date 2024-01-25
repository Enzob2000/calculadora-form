using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices;


namespace calculadora_form
{
    public partial class Form1 : Form
    {


        #region Dlls para poder hacer el movimiento del Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Rectangle sizeGripRectangle;
        bool inSizeDrag = false;
        const int GRIP_SIZE = 15;

        int w = 0;
        int h = 0;
        #endregion



        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(128, 128, 255);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse);// width of ellipse

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

        }


        public class RJButton : Button
        {
            //Fields
            private int borderSize = 0;
            private int borderRadius = 20;
            private Color borderColor = Color.PaleVioletRed;

            //Properties
            [Category("RJ Code Advance")]
            public int BorderSize
            {
                get { return borderSize; }
                set
                {
                    borderSize = value;
                    this.Invalidate();
                }
            }

            [Category("RJ Code Advance")]
            public int BorderRadius
            {
                get { return borderRadius; }
                set
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }

            [Category("RJ Code Advance")]
            public Color BorderColor
            {
                get { return borderColor; }
                set
                {
                    borderColor = value;
                    this.Invalidate();
                }
            }
            [Category("RJ Code Advance")]
            public Color BackgroundColor
            {
                get { return this.BackColor; }
                set { this.BackColor = value; }
            }

            [Category("RJ Code Advance")]
            public Color TextColor
            {
                get { return this.ForeColor; }
                set { this.ForeColor = value; }
            }

            //Constructor
            public RJButton()
            {
                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.Size = new Size(150, 40);
                this.BackColor = Color.MediumSlateBlue;
                this.ForeColor = Color.White;
                this.Resize += new EventHandler(Button_Resize);
            }

            private void Button_Resize(object sender, EventArgs e)
            {
                if (borderRadius > this.Height)
                    borderRadius = this.Height;
            }
            //Methods
            private GraphicsPath GetFigurePath(Rectangle rect, float radius)
            {
                GraphicsPath path = new GraphicsPath();
                float curveSize = radius * 2F;

                path.StartFigure();
                path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
                path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
                path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
                path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
                path.CloseFigure();
                return path;
            }

            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);

                Rectangle rectSurface = this.ClientRectangle;
                Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
                int smoothSize = 2;
                if (borderSize > 0)
                    smoothSize = borderSize;

                if (borderRadius > 2) //Rounded button
                {
                    using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                    using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                    using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        //Button surface
                        this.Region = new Region(pathSurface);
                        //Draw surface border for HD result
                        pevent.Graphics.DrawPath(penSurface, pathSurface);

                        //Button border                    
                        if (borderSize >= 1)
                            //Draw control border
                            pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }
                else //Normal button
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.None;
                    //Button surface
                    this.Region = new Region(rectSurface);
                    //Button border
                    if (borderSize >= 1)
                    {
                        using (Pen penBorder = new Pen(borderColor, borderSize))
                        {
                            penBorder.Alignment = PenAlignment.Inset;
                            pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                        }
                    }
                }
            }
            protected override void OnHandleCreated(EventArgs e)
            {
                base.OnHandleCreated(e);
                this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
            }

            private void Container_BackColorChanged(object sender, EventArgs e)
            {
                this.Invalidate();
            }
        }

  
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            w = this.Width;
            h = this.Height;
        }
    }
}