using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace Lab_Canvas
{
    public partial class MainWindow : Window
    {
        int count = 0;
        int height = 250;
        int width = 350;
        int top = 100;
        private Brush circleColor = Brushes.White;
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private Rectangle CreateSquare()
        {
            Rectangle rect = new Rectangle();
            rect.Height = 100;
            rect.Width = 100;
            rect.Fill = Brushes.Blue;

            return rect;
        }

        #region DrawCircle
        private void DrawCircle(int height, int width, int left, int top)
        {
            // create circle
            Ellipse circle = new Ellipse();
            circle.Height = height;
            circle.Width = width;
            circle.Fill = circleColor;
            circleColor = AlternateColor(circleColor);

            // set position 
            Canvas.SetLeft(circle, left);
            Canvas.SetTop(circle, top);

            // add circle to canvas
            BackgroundCanvas.Children.Add(circle);
        }
        #endregion

        private Brush AlternateColor(Brush color)
        {
            if(color == Brushes.White)
            {
                return Brushes.Black;
            }
            else
            {
                return Brushes.White;
            }
        }

        private void FallingSquareButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Interval = new System.TimeSpan(0,0,0,0,500);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        void timer_Tick(object sender, System.EventArgs e)
        {
            DrawCircle(height, width, 50, top);
            System.Media.SystemSounds.Beep.Play();
            height -= 50;
            width -= 50;
            top += 25;
            count++;
            if(count == 5)
            {
                timer.Stop();
            }
        }
    }
}
