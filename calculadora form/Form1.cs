using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices;
using System.Data;


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
            panel1.Visible = true;
            panel2.Visible = false;

            this.FormBorderStyle = FormBorderStyle.None;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 60, 60));






        }



        private void menuStrip2_MouseDown(object sender, MouseEventArgs e)
        {
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            w = this.Width;
            h = this.Height;
        }

        public void tex1(string tex)
        {
            if (textBox1.Text.Length < 16)
            {
                textBox1.Text = textBox1.Text + tex;
            }

        }
        public void tex2(string tex)
        {
            if (textBox2.Text.Length < 35)
            {
                textBox2.Text = textBox2.Text + tex;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        private void rjButton18_Click(object sender, EventArgs e)
        {


            tex1("1");
            Size = new Size(900, 200);
        }

        private void rjButton19_Click(object sender, EventArgs e)
        {
            tex1("2");
        }

        private void rjButton8_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1);
            }


        }

        private void rjButton17_Click(object sender, EventArgs e)
        {
            tex1("3");
        }

        private void rjButton15_Click(object sender, EventArgs e)
        {
            tex1("4");
        }

        private void rjButton16_Click(object sender, EventArgs e)
        {
            tex1("5");
        }

        private void rjButton20_Click(object sender, EventArgs e)
        {
            tex1("6");
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            tex1("7");
        }

        private void rjButton13_Click(object sender, EventArgs e)
        {
            tex1("8");
        }

        private void rjButton14_Click(object sender, EventArgs e)
        {
            tex1("9");
        }

        private void rjButton22_Click(object sender, EventArgs e)
        {
            tex1(".");
        }

        private void rjButton25_Click(object sender, EventArgs e)
        {
            tex1("+");
        }

        private void rjButton21_Click(object sender, EventArgs e)
        {
            tex1("0");
        }

        private void rjButton24_Click(object sender, EventArgs e)
        {
            tex1("-");
        }

        private void rjButton23_Click(object sender, EventArgs e)
        {
            tex1("*");
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            tex1("/");
        }

        private void rjButton29_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            var result = table.Compute(textBox1.Text, null);
            textBox1.Text = result.ToString();
        }

        private void rjButton10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }



        private void rjButton65_Click(object sender, EventArgs e)
        {
            tex2("1");

        }

        private void rjButton69_Click(object sender, EventArgs e)
        {
            tex2("2");
        }

        private void rjButton72_Click(object sender, EventArgs e)
        {
            tex2("3");
        }

        private void rjButton66_Click(object sender, EventArgs e)
        {
            tex2("0");
        }

        private void rjButton73_Click(object sender, EventArgs e)
        {
            tex2(".");
        }

        private void rjButton77_Click(object sender, EventArgs e)
        {
            tex2("+");
        }

        private void rjButton76_Click(object sender, EventArgs e)
        {
            tex2("-");
        }

        private void rjButton64_Click(object sender, EventArgs e)
        {
            tex2("4");
        }

        private void rjButton68_Click(object sender, EventArgs e)
        {
            tex2("5");
        }

        private void rjButton71_Click(object sender, EventArgs e)
        {
            tex2("6");
        }

        private void rjButton75_Click(object sender, EventArgs e)
        {
            tex2("*");
        }

        private void rjButton63_Click(object sender, EventArgs e)
        {
            tex2("7");
        }

        private void rjButton67_Click(object sender, EventArgs e)
        {
            tex2("8");
        }

        private void rjButton70_Click(object sender, EventArgs e)
        {
            tex2("9");
        }

        private void rjButton74_Click(object sender, EventArgs e)
        {
            tex2("/");
        }

        private void rjButton58_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.TextLength - 1);
            }
        }

        private void rjButton60_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cientificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            this.FormBorderStyle = FormBorderStyle.None;
            Size = new Size(980, 590);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 60, 60));
            panel1.Visible = false;
            textBox2.Text = textBox1.Text;


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Size = new Size(510, 563);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 60, 60));
        }



        private void menuStrip3_MouseDown_1(object sender, MouseEventArgs e)
        {
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            w = this.Width;
            h = this.Height;
        }

        private void rjButton80_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            var result = table.Compute(textBox2.Text, null);
            textBox2.Text = result.ToString();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            this.FormBorderStyle = FormBorderStyle.None;
            Size = new Size(510, 563);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 60, 60));
            panel2.Visible = false;
            textBox1.Text = textBox2.Text;
        }
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



}
