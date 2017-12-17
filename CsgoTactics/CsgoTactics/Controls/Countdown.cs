using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CsgoTactics.Controls
{
    // A Control to count down time in the design of a clock
    class Countdown : Grid
    {


        public Point Center
        {
            get { return (Point)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Center.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CenterProperty =
            DependencyProperty.Register("Center", typeof(Point), typeof(Countdown), new PropertyMetadata(0d, OnCenterChanged));

        private static void OnCenterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (Countdown)d;
            Point oldCenter = (Point)e.OldValue;
            Point newCenter = target.Center;
            target.OnCenterChanged(oldCenter, newCenter);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes
        /// to the Center property.
        /// </summary>
        /// <param name="oldCenter">The old Center value</param>
        /// <param name="newCenter">The new Center value</param>
        private void OnCenterChanged(Point oldCenter, Point newCenter)
        {
            // to-do
        }
        
        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(Countdown), new PropertyMetadata(0d, OnAngleChanged));

        private static void OnAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (Countdown)d;
            double oldAngle = (double)e.OldValue;
            double newAngle = target.Angle;
            target.OnAngleChanged(oldAngle, newAngle);
        }

        private void OnAngleChanged(double oldAngle, double newAngle)
        {
            // to-do
        }



        public double Ticks
        {
            get { return (double)GetValue(TicksProperty); }
            set { SetValue(TicksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Ticks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TicksProperty =
            DependencyProperty.Register("Ticks", typeof(double), typeof(Countdown), new PropertyMetadata(45d, OnTicksChanged));

        private static void OnTicksChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (Countdown)d;
            double oldTicks = (double)e.OldValue;
            double newTicks = target.Angle;
            target.OnTicksChanged(oldTicks, newTicks);
        }

        private void OnTicksChanged(double oldTicks, double newTicks)
        {
            // to-do
        }

        void updateCounddown()
        {
            //double startAngle = 60;
            //double endAngle = 300;

            var linePathGeometry = new PathGeometry();
            var linePathFigure = new PathFigure();
            var linePath = new Path();

            linePathGeometry.Figures.Add(linePathFigure);
            linePath.Data = linePathGeometry;
            this.Children.Add(linePath);

        }

    }
}
