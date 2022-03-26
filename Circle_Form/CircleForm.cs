namespace Circle_Form
{
    public partial class CircleForm : Form
    {
        static int XMAX = 700;
        static int YMAX = 700;
        static int XORG = XMAX / 2;
        static int YORG = YMAX / 2;
        static int RADIUS = XMAX / 2 - 50;
        static int NDOTS = 2400;
    
        static void drawCircle(Graphics g, int x, int y)
        {
            Pen pen = new Pen(Color.Black);
            g.DrawEllipse(pen, x, y, 1, 1); 
        }
           
        static void drawDot(Graphics g, int x, int y)
        {
            Pen pen = new Pen(Color.Red);
            g.DrawLine(pen, XORG, YORG, x, y);
        }
        
        static void drawCircleTime(Graphics g, int x, int y, int num)
        {
            Font font = new Font("Arial", 20);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString(System.Convert.ToString(num), font, brush, x, y);
        }
        static void drawTime(Graphics g)
        {
            int x, y;
            int hour = DateTime.Now.Hour - 1;
            int min = DateTime.Now.Minute - 5;
            double hour_step = Math.PI / 6;
            double min_step = Math.PI / 30;
            Pen pen = new Pen(Color.Black);

            x = (int)((RADIUS - 150) * Math.Cos((hour_step * hour) - Math.PI / 3) + XORG - 10);
            y = (int)((RADIUS - 150) * Math.Sin((hour_step * hour) - Math.PI / 3) + YORG - 10);

            g.DrawLine(pen, XORG, YORG, x, y);

            x = (int)((RADIUS - 70) * Math.Cos((min_step * min) - Math.PI / 3) + XORG - 10);
            y = (int)((RADIUS - 70) * Math.Sin((min_step * min) - Math.PI / 3) + YORG - 10);
            g.DrawLine(pen, XORG, YORG, x, y);
        }
        static void drawCircle(Graphics g)
        {
            int i, circle_x, circle_y, dot_x, dot_y, time_x, time_y;
            double step = 2 * Math.PI / NDOTS;
            double time_step = Math.PI / 6;
            double theta = 0.0;

            for (i = 0; i < NDOTS; i++)
            {
                circle_x = (int)(RADIUS * Math.Cos(theta - Math.PI / 2) + XORG);
                circle_y = (int)(RADIUS * Math.Sin(theta - Math.PI / 2) + YORG);
                dot_x = (int)(10 * Math.Cos(theta - Math.PI / 2) + XORG);
                dot_y = (int)(10 * Math.Sin(theta - Math.PI / 2) + YORG);

                drawCircle(g, circle_x, circle_y);
                drawDot(g, dot_x, dot_y);
             
                theta += step;
            }
            
            for(i = 0; i < 12; i++)
            {
                time_x = (int)((RADIUS - 20) * Math.Cos(theta - Math.PI / 3) + XORG - 10);
                time_y = (int)((RADIUS - 20) * Math.Sin(theta - Math.PI / 3) + YORG - 10);

                drawCircleTime(g, time_x, time_y, i+1);

                theta += time_step;
            }
        }

        public CircleForm()
        {
            InitializeComponent();
        }

        private void CircleForm_Paint(object sender, PaintEventArgs e)
        {
            drawCircle(e.Graphics);
            drawTime(e.Graphics);
        }

        private void CircleForm_Load(object sender, EventArgs e)
        {

        }
    }
}