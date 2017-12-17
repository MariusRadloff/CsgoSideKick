using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CsgoTactics.Controls
{
    /// <summary>
    /// </summary>
    public class GaugeChartGrid : Grid
    {
        //TextBlock
        TextBlock textBlock = new TextBlock();

        //Backgroundring
        EllipseGeometry BackgroundringOuterEllipseGeometry = new EllipseGeometry();
        EllipseGeometry BackgroundringInnerEllipseGeometry = new EllipseGeometry();
        Path BackgroundringEllipsePath = new Path();
        GeometryGroup BackgroundringEllipseGroup = new GeometryGroup();

        //Slice1
        ArcSegment innerArcSegment1 = new ArcSegment();
        ArcSegment outerArcSegment1 = new ArcSegment();
        LineSegment lineSegment1 = new LineSegment();

        PathGeometry pathGeometry1 = new PathGeometry();
        PathFigure pathFigure1 = new PathFigure();
        Path ringSlicePath1 = new Path();

        //Slice2
        ArcSegment innerArcSegment2 = new ArcSegment();
        ArcSegment outerArcSegment2 = new ArcSegment();
        LineSegment lineSegment2 = new LineSegment();

        PathGeometry pathGeometry2 = new PathGeometry();
        PathFigure pathFigure2 = new PathFigure();
        Path ringSlicePath2 = new Path();

        //Slice3
        ArcSegment innerArcSegment3 = new ArcSegment();
        ArcSegment outerArcSegment3 = new ArcSegment();
        LineSegment lineSegment3 = new LineSegment();

        PathGeometry pathGeometry3 = new PathGeometry();
        PathFigure pathFigure3 = new PathFigure();
        Path ringSlicePath3 = new Path();


        private bool _isUpdating;

        #region Text

        public bool isTextEnabled
        {
            get { return (bool)GetValue(isTextEnabledProperty); }
            set { SetValue(isTextEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isTextEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isTextEnabledProperty =
            DependencyProperty.Register("isTextEnabled", typeof(bool), typeof(GaugeChartGrid), new PropertyMetadata(false, OnIsTextEnabledChanged));

        private static void OnIsTextEnabledChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)sender;
            var oldIsTextEnabled = (bool)e.OldValue;
            var newIsTextEnabled = (bool)e.NewValue;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsBackgroundRing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(GaugeChartGrid), new PropertyMetadata(null, OnTextChanged));

        private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)sender;
            var oldText = (string)e.OldValue;
            var newText = (string)e.NewValue;
            target.OnTextChanged(oldText, newText);
        }

        private void OnTextChanged(string oldText, string newText)
        {
            if (isTextEnabled)
            {
                UpdatePath();
            }
        }
        #endregion

        #region BackgroundRing
        public bool IsBackgroundRing
        {
            get { return (bool)GetValue(IsBackgroundRingProperty); }
            set { SetValue(IsBackgroundRingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsBackgroundRing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBackgroundRingProperty =
            DependencyProperty.Register("IsBackgroundRing", typeof(bool), typeof(GaugeChartGrid), new PropertyMetadata(true, OnIsBackgroundRingChanged));

        private static void OnIsBackgroundRingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)sender;
            var oldIsBackgroundRing = (bool)e.OldValue;
            var newIsBackgroundRing = (bool)e.NewValue;
            target.OnIsBackgroundRingChanged(oldIsBackgroundRing, newIsBackgroundRing);
        }

        private void OnIsBackgroundRingChanged(bool oldIsBackgroundRing, bool newIsBackgroundRing)
        {
            UpdatePath();
        }
        #endregion

        #region StartAngle
        /// <summary>
        /// The start angle property.
        /// </summary>
        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register(
                "StartAngle",
                typeof(double),
                typeof(GaugeChartGrid),
                new PropertyMetadata(
                    0d,
                    OnStartAngleChanged));

        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>
        /// The start angle.
        /// </value>
        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        private static void OnStartAngleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)sender;
            var oldStartAngle = (double)e.OldValue;
            var newStartAngle = (double)e.NewValue;
            target.OnStartAngleChanged(oldStartAngle, newStartAngle);
        }

        private void OnStartAngleChanged(double oldStartAngle, double newStartAngle)
        {
            UpdatePath();
        }
        #endregion

        #region Angle1
        /// <summary>
        /// The end angle property.
        /// </summary>
        public static readonly DependencyProperty Angle1Property =
            DependencyProperty.Register(
                "Angle1",
                typeof(double),
                typeof(GaugeChartGrid),
                new PropertyMetadata(
                    0d,
                    OnAngle1Changed));

        /// <summary>
        /// Gets or sets the end angle.
        /// </summary>
        /// <value>
        /// The end angle.
        /// </value>
        public double Angle1
        {
            get { return (double)GetValue(Angle1Property); }
            set { SetValue(Angle1Property, value); }
        }

        private static void OnAngle1Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)sender;
            var oldAngle1 = (double)e.OldValue;
            var newAngle1 = (double)e.NewValue;
            target.OnAngle1Changed(oldAngle1, newAngle1);
        }

        private void OnAngle1Changed(double oldAngle1, double newAngle1)
        {
            UpdatePath();
        }
        #endregion

        #region Angle2
        /// <summary>
        /// The end angle property.
        /// </summary>
        public static readonly DependencyProperty Angle2Property =
            DependencyProperty.Register(
                "Angle2",
                typeof(double),
                typeof(GaugeChartGrid),
                new PropertyMetadata(
                    0d,
                    OnAngle2Changed));

        /// <summary>
        /// Gets or sets the end angle.
        /// </summary>
        /// <value>
        /// The end angle.
        /// </value>
        public double Angle2
        {
            get { return (double)GetValue(Angle2Property); }
            set { SetValue(Angle2Property, value); }
        }

        private static void OnAngle2Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)sender;
            var oldAngle2 = (double)e.OldValue;
            var newAngle2 = (double)e.NewValue;
            target.OnAngle2Changed(oldAngle2, newAngle2);
        }

        private void OnAngle2Changed(double oldAngle2, double newAngle2)
        {
            UpdatePath();
        }
        #endregion

        #region Angle3
        /// <summary>
        /// The end angle property.
        /// </summary>
        public static readonly DependencyProperty Angle3Property =
            DependencyProperty.Register(
                "Angle3",
                typeof(double),
                typeof(GaugeChartGrid),
                new PropertyMetadata(
                    0d,
                    OnAngle3Changed));

        /// <summary>
        /// Gets or sets the end angle.
        /// </summary>
        /// <value>
        /// The end angle.
        /// </value>
        public double Angle3
        {
            get { return (double)GetValue(Angle3Property); }
            set { SetValue(Angle3Property, value); }
        }

        private static void OnAngle3Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)sender;
            var oldAngle3 = (double)e.OldValue;
            var newAngle3 = (double)e.NewValue;
            target.OnAngle3Changed(oldAngle3, newAngle3);
        }

        private void OnAngle3Changed(double oldAngle3, double newAngle3)
        {
            UpdatePath();
        }
        #endregion

        #region OuterRadius
        /// <summary>
        /// The radius property
        /// </summary>
        public static readonly DependencyProperty OuterRadiusProperty =
            DependencyProperty.Register(
                "OuterRadius",
                typeof(double),
                typeof(GaugeChartGrid),
                new PropertyMetadata(
                    0d,
                    OnOuterRadiusChanged));

        /// <summary>
        /// Gets or sets the outer radius.
        /// </summary>
        /// <value>
        /// The outer radius.
        /// </value>
        public double OuterRadius
        {
            get { return (double)GetValue(OuterRadiusProperty); }
            set { SetValue(OuterRadiusProperty, value); }
        }

        private static void OnOuterRadiusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)sender;
            var oldOuterRadius = (double)e.OldValue;
            var newOuterRadius = (double)e.NewValue;
            target.OnOuterRadiusChanged(oldOuterRadius, newOuterRadius);
        }

        private void OnOuterRadiusChanged(double oldOuterRadius, double newOuterRadius)
        {
            this.Width = 2 * OuterRadius + this.Padding.Left + this.Padding.Right;
            this.Height = 2 * OuterRadius + this.Padding.Top + this.Padding.Bottom;
            UpdatePath();
        }
        #endregion

        #region InnerRadius
        /// <summary>
        /// The inner radius property
        /// </summary>
        public static readonly DependencyProperty InnerRadiusProperty =
            DependencyProperty.Register(
                "InnerRadius",
                typeof(double),
                typeof(GaugeChartGrid),
                new PropertyMetadata(
                    0d,
                    OnInnerRadiusChanged));

        /// <summary>
        /// Gets or sets the inner radius.
        /// </summary>
        /// <value>
        /// The inner radius.
        /// </value>
        public double InnerRadius
        {
            get { return (double)GetValue(InnerRadiusProperty); }
            set { SetValue(InnerRadiusProperty, value); }
        }

        private static void OnInnerRadiusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)sender;
            var oldInnerRadius = (double)e.OldValue;
            var newInnerRadius = (double)e.NewValue;
            target.OnInnerRadiusChanged(oldInnerRadius, newInnerRadius);
        }

        private void OnInnerRadiusChanged(double oldInnerRadius, double newInnerRadius)
        {
            if (newInnerRadius < 0)
            {
                throw new ArgumentException("InnerRadius can't be a negative value.", "InnerRadius");
            }

            UpdatePath();
        }
        #endregion

        #region Center
        /// <summary>
        /// Center Dependency Property
        /// </summary>
        public static readonly DependencyProperty CenterProperty =
            DependencyProperty.Register(
                "Center",
                typeof(Point?),
                typeof(GaugeChartGrid),
                new PropertyMetadata(null, OnCenterChanged));

        /// <summary>
        /// Gets or sets the Center property. This dependency property 
        /// indicates the center point.
        /// Center point is calculated based on Radius and StrokeThickness if not specified.    
        /// </summary>
        public Point? Center
        {
            get { return (Point?)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        /// <summary>
        /// Handles changes to the Center property.
        /// </summary>
        /// <param name="d">
        /// The <see cref="DependencyObject"/> on which
        /// the property has changed value.
        /// </param>
        /// <param name="e">
        /// Event data that is issued by any event that
        /// tracks changes to the effective value of this property.
        /// </param>
        private static void OnCenterChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)d;
            Point? oldCenter = (Point?)e.OldValue;
            Point? newCenter = target.Center;
            target.OnCenterChanged(oldCenter, newCenter);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes
        /// to the Center property.
        /// </summary>
        /// <param name="oldCenter">The old Center value</param>
        /// <param name="newCenter">The new Center value</param>
        private void OnCenterChanged(
            Point? oldCenter, Point? newCenter)
        {
            UpdatePath();
        }
        #endregion

        #region Colors

        /// <summary>
        /// Backgroundring Color Dependency Property
        /// </summary>
        public static readonly DependencyProperty BackgroundRingColorProperty =
            DependencyProperty.Register(
                "BackgroundRingColor",
                typeof(SolidColorBrush),
                typeof(GaugeChartGrid),
                new PropertyMetadata(null, OnBackgroundRingColorChanged));

        /// <summary>
        /// Gets or sets the BackgroundRingColor property. This dependency property 
        /// indicates the Color of the ring.   
        /// </summary>
        public SolidColorBrush BackgroundRingColor
        {
            get { return (SolidColorBrush)GetValue(BackgroundRingColorProperty); }
            set { SetValue(BackgroundRingColorProperty, value); }
        }

        /// <summary>
        /// Handles changes to the BackgroundRingColor property.
        /// </summary>
        /// <param name="d">
        /// The <see cref="DependencyObject"/> on which
        /// the property has changed value.
        /// </param>
        /// <param name="e">
        /// Event data that is issued by any event that
        /// tracks changes to the effective value of this property.
        /// </param>
        private static void OnBackgroundRingColorChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)d;
            SolidColorBrush oldBackgroundRingColor = (SolidColorBrush)e.OldValue;
            SolidColorBrush newBackgroundRingColor = target.BackgroundRingColor;
            target.OnBackgroundRingColorChanged(oldBackgroundRingColor, newBackgroundRingColor);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes
        /// to the BackgroundRingColor property.
        /// </summary>
        /// <param name="oldBackgroundRingColor">The old Center value</param>
        /// <param name="newBackgroundRingColor">The new Center value</param>
        private void OnBackgroundRingColorChanged(
            SolidColorBrush oldBackgroundRingColor, SolidColorBrush newBackgroundRingColor)
        {
            UpdatePath();
        }

        /// <summary>
        /// Ring Slice Color 1 Dependency Property for the first Ring Slice
        /// </summary>
        public static readonly DependencyProperty RingSliceColor1Property =
            DependencyProperty.Register(
                "RingSliceColor1",
                typeof(SolidColorBrush),
                typeof(GaugeChartGrid),
                new PropertyMetadata(null, OnRingSliceColor1Changed));

        /// <summary>
        /// Gets or sets the Ring Slice Color 1 property. This dependency property 
        /// indicates the Color of the first Ring Slice.   
        /// </summary>
        public SolidColorBrush RingSliceColor1
        {
            get { return (SolidColorBrush)GetValue(RingSliceColor1Property); }
            set { SetValue(RingSliceColor1Property, value); }
        }

        /// <summary>
        /// Handles changes to the RingSliceColor1 property.
        /// </summary>
        /// <param name="d">
        /// The <see cref="DependencyObject"/> on which
        /// the property has changed value.
        /// </param>
        /// <param name="e">
        /// Event data that is issued by any event that
        /// tracks changes to the effective value of this property.
        /// </param>
        private static void OnRingSliceColor1Changed(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)d;
            SolidColorBrush oldRingSliceColor1 = (SolidColorBrush)e.OldValue;
            SolidColorBrush newRingSliceColor1 = target.RingSliceColor1;
            target.OnRingSliceColor1Changed(oldRingSliceColor1, newRingSliceColor1);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes
        /// to the RingSliceColor1 property.
        /// </summary>
        /// <param name="oldRingSliceColor1">The old Center value</param>
        /// <param name="newRingSliceColor1">The new Center value</param>
        private void OnRingSliceColor1Changed(
            SolidColorBrush oldRingSliceColor1, SolidColorBrush newRingSliceColor1)
        {
            UpdatePath();
        }

        /// <summary>
        /// Ring Slice Color 2 Dependency Property for the second Ring Slice
        /// </summary>
        public static readonly DependencyProperty RingSliceColor2Property =
            DependencyProperty.Register(
                "RingSliceColor2",
                typeof(SolidColorBrush),
                typeof(GaugeChartGrid),
                new PropertyMetadata(null, OnRingSliceColor2Changed));

        /// <summary>
        /// Gets or sets the Ring Slice Color 2 property. This dependency property 
        /// indicates the Color of the second Ring Slice.   
        /// </summary>
        public SolidColorBrush RingSliceColor2
        {
            get { return (SolidColorBrush)GetValue(RingSliceColor2Property); }
            set { SetValue(RingSliceColor2Property, value); }
        }

        /// <summary>
        /// Handles changes to the RingSliceColor2 property.
        /// </summary>
        /// <param name="d">
        /// The <see cref="DependencyObject"/> on which
        /// the property has changed value.
        /// </param>
        /// <param name="e">
        /// Event data that is issued by any event that
        /// tracks changes to the effective value of this property.
        /// </param>
        private static void OnRingSliceColor2Changed(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)d;
            SolidColorBrush oldRingSliceColor2 = (SolidColorBrush)e.OldValue;
            SolidColorBrush newRingSliceColor2 = target.RingSliceColor2;
            target.OnRingSliceColor2Changed(oldRingSliceColor2, newRingSliceColor2);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes
        /// to the RingSliceColor1 property.
        /// </summary>
        /// <param name="oldRingSliceColor2">The old Center value</param>
        /// <param name="newRingSliceColor2">The new Center value</param>
        private void OnRingSliceColor2Changed(
            SolidColorBrush oldRingSliceColor2, SolidColorBrush newRingSliceColor2)
        {
            UpdatePath();
        }

        /// <summary>
        /// Ring Slice Color 3 Dependency Property for the second Ring Slice
        /// </summary>
        public static readonly DependencyProperty RingSliceColor3Property =
            DependencyProperty.Register(
                "RingSliceColor3",
                typeof(SolidColorBrush),
                typeof(GaugeChartGrid),
                new PropertyMetadata(null, OnRingSliceColor3Changed));

        /// <summary>
        /// Gets or sets the Ring Slice Color 3 property. This dependency property 
        /// indicates the Color of the second Ring Slice.   
        /// </summary>
        public SolidColorBrush RingSliceColor3
        {
            get { return (SolidColorBrush)GetValue(RingSliceColor3Property); }
            set { SetValue(RingSliceColor3Property, value); }
        }

        /// <summary>
        /// Handles changes to the RingSliceColor3 property.
        /// </summary>
        /// <param name="d">
        /// The <see cref="DependencyObject"/> on which
        /// the property has changed value.
        /// </param>
        /// <param name="e">
        /// Event data that is issued by any event that
        /// tracks changes to the effective value of this property.
        /// </param>
        private static void OnRingSliceColor3Changed(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (GaugeChartGrid)d;
            SolidColorBrush oldRingSliceColor3 = (SolidColorBrush)e.OldValue;
            SolidColorBrush newRingSliceColor3 = target.RingSliceColor2;
            target.OnRingSliceColor3Changed(oldRingSliceColor3, newRingSliceColor3);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes
        /// to the RingSliceColor1 property.
        /// </summary>
        /// <param name="oldRingSliceColor3">The old Center value</param>
        /// <param name="newRingSliceColor3">The new Center value</param>
        private void OnRingSliceColor3Changed(
            SolidColorBrush oldRingSliceColor3, SolidColorBrush newRingSliceColor3)
        {
            UpdatePath();
        }

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="RingSlice" /> class.
        /// </summary>
        public GaugeChartGrid()
        {
            this.SizeChanged += OnSizeChanged;

            //Backgroundring
            BackgroundringEllipseGroup.Children.Add(BackgroundringOuterEllipseGeometry);
            BackgroundringEllipseGroup.Children.Add(BackgroundringInnerEllipseGeometry);
            BackgroundringEllipsePath.Data = BackgroundringEllipseGroup;
            this.Children.Add(BackgroundringEllipsePath);

            //TextBlock
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            this.Children.Add(textBlock);
            //if (Text != null && isTextEnabled != false)
            //{
            //    textBlock.Text = Text + "%";
            //}

            //Slice1
            pathFigure1.Segments.Add(innerArcSegment1);
            pathFigure1.Segments.Add(lineSegment1);
            pathFigure1.Segments.Add(outerArcSegment1);

            pathGeometry1.Figures.Add(pathFigure1);
            ringSlicePath1.Data = pathGeometry1;
            ringSlicePath1.Stroke = Application.Current.Resources["Stroke1"] as SolidColorBrush;
            ringSlicePath1.StrokeThickness = 1;

            //Slice2
            pathFigure2.Segments.Add(innerArcSegment2);
            pathFigure2.Segments.Add(lineSegment2);
            pathFigure2.Segments.Add(outerArcSegment2);

            pathGeometry2.Figures.Add(pathFigure2);
            ringSlicePath2.Data = pathGeometry2;
            ringSlicePath2.Stroke = Application.Current.Resources["Stroke1"] as SolidColorBrush;
            ringSlicePath2.StrokeThickness = 1;

            //Slice3
            pathFigure3.Segments.Add(innerArcSegment3);
            pathFigure3.Segments.Add(lineSegment3);
            pathFigure3.Segments.Add(outerArcSegment3);

            pathGeometry3.Figures.Add(pathFigure3);
            ringSlicePath3.Data = pathGeometry3;
            ringSlicePath3.Stroke = Application.Current.Resources["Stroke1"] as SolidColorBrush;
            ringSlicePath3.StrokeThickness = 1;

            this.InvalidateArrange();
            this.Children.Add(ringSlicePath1);
            this.Children.Add(ringSlicePath2);
            this.Children.Add(ringSlicePath3);

            //Add Rings
            //this.InvalidateArrange();
            //this.Children.Add(ringSlicePath1);
            //if (Angle2 != 0)
            //{
            //    this.Children.Add(ringSlicePath2);
            //}
            //if (Angle3 != 0)
            //{
            //    this.Children.Add(ringSlicePath3);
            //}

            //new PropertyChangeEventSource<double>(
            //    this, "StrokeThickness", BindingMode.OneWay).ValueChanged +=
            //    OnStrokeThicknessChanged;
        }

        private void OnStrokeThicknessChanged(object sender, double e)
        {
            UpdatePath();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            UpdatePath();
        }


        #region UpdatePath
        /// <summary>
        /// Suspends path updates until EndUpdate is called;
        /// </summary>
        public void BeginUpdate()
        {
            _isUpdating = true;
        }

        /// <summary>
        /// Resumes immediate path updates every time a component property value changes. Updates the path.
        /// </summary>
        public void EndUpdate()
        {
            _isUpdating = false;
            UpdatePath();
        }

        private void UpdatePath()
        {
            if (_isUpdating || ActualWidth == 0 || InnerRadius <= 0 || OuterRadius < InnerRadius)
                return;

            var center = this.Center ?? new Point(Width / 2, Width / 2);

            #region Slice1

            pathFigure1.IsClosed = true;

            // Starting Point
            pathFigure1.StartPoint = new Point(
                    center.X + Math.Sin(StartAngle * Math.PI / 180) * InnerRadius,
                    center.Y - Math.Cos(StartAngle * Math.PI / 180) * InnerRadius);
                        
            innerArcSegment1.IsLargeArc = (Angle1 - StartAngle) >= 180.0;
            innerArcSegment1.Point = new Point(
                    center.X + Math.Sin(Angle1 * Math.PI / 180) * InnerRadius,
                    center.Y - Math.Cos(Angle1 * Math.PI / 180) * InnerRadius);

            innerArcSegment1.Size = new Size(InnerRadius, InnerRadius);
            innerArcSegment1.SweepDirection = SweepDirection.Clockwise;
                        
            lineSegment1.Point = new Point(
                        center.X + Math.Sin(Angle1 * Math.PI / 180) * OuterRadius,
                        center.Y - Math.Cos(Angle1 * Math.PI / 180) * OuterRadius);

            outerArcSegment1.IsLargeArc = (Angle1 - StartAngle) >= 180.0;
            outerArcSegment1.Point =
                new Point(
                        center.X + Math.Sin(StartAngle * Math.PI / 180) * OuterRadius,
                        center.Y - Math.Cos(StartAngle * Math.PI / 180) * OuterRadius);
            outerArcSegment1.Size = new Size(OuterRadius, OuterRadius);
            outerArcSegment1.SweepDirection = SweepDirection.Counterclockwise;

            ringSlicePath1.Fill = RingSliceColor1;
 
            #endregion 

            #region Slice2

            if (Angle2 != 0)
            {
                pathFigure2.IsClosed = true;

                var StartAngle2 = StartAngle + Angle1;

                // Starting Point
                pathFigure2.StartPoint = new Point(
                    center.X + Math.Sin(StartAngle2 * Math.PI / 180) * InnerRadius,
                    center.Y - Math.Cos(StartAngle2 * Math.PI / 180) * InnerRadius);
                                
                innerArcSegment2.IsLargeArc = Angle2 >= 180.0;
                innerArcSegment2.Point = new Point(
                    center.X + Math.Sin((StartAngle2 + Angle2) * Math.PI / 180) * InnerRadius,
                    center.Y - Math.Cos((StartAngle2 + Angle2) * Math.PI / 180) * InnerRadius);
                innerArcSegment2.Size = new Size(InnerRadius, InnerRadius);
                innerArcSegment2.SweepDirection = SweepDirection.Clockwise;
                                
                lineSegment2.Point = new Point(
                    center.X + Math.Sin((StartAngle2 + Angle2) * Math.PI / 180) * OuterRadius,
                    center.Y - Math.Cos((StartAngle2 + Angle2) * Math.PI / 180) * OuterRadius);
                                
                outerArcSegment2.IsLargeArc = (Angle2) >= 180.0;
                outerArcSegment2.Point = new Point(
                    center.X + Math.Sin(StartAngle2 * Math.PI / 180) * OuterRadius,
                    center.Y - Math.Cos(StartAngle2 * Math.PI / 180) * OuterRadius);
                outerArcSegment2.Size = new Size(OuterRadius, OuterRadius);
                outerArcSegment2.SweepDirection = SweepDirection.Counterclockwise;

                ringSlicePath2.Fill = RingSliceColor2;
            }

            #endregion

            #region Slice3

            if (Angle3 != 0)
            {
                pathFigure3.IsClosed = true;

                var StartAngle3 = StartAngle + Angle1 + Angle2;

                // Starting Point
                pathFigure3.StartPoint = new Point(
                    center.X + Math.Sin(StartAngle3 * Math.PI / 180) * InnerRadius,
                    center.Y - Math.Cos(StartAngle3 * Math.PI / 180) * InnerRadius);
                
                innerArcSegment3.IsLargeArc = (Angle3) >= 180.0;
                innerArcSegment3.Point = new Point(
                    center.X + Math.Sin((StartAngle3 + Angle3) * Math.PI / 180) * InnerRadius,
                    center.Y - Math.Cos((StartAngle3 + Angle3) * Math.PI / 180) * InnerRadius);
                innerArcSegment3.Size = new Size(InnerRadius, InnerRadius);
                innerArcSegment3.SweepDirection = SweepDirection.Clockwise;

                lineSegment3.Point = new Point(
                    center.X + Math.Sin((StartAngle3 + Angle3) * Math.PI / 180) * OuterRadius,
                    center.Y - Math.Cos((StartAngle3 + Angle3) * Math.PI / 180) * OuterRadius);
                                
                outerArcSegment3.IsLargeArc = (Angle3) >= 180.0;
                outerArcSegment3.Point = new Point(
                    center.X + Math.Sin(StartAngle3 * Math.PI / 180) * OuterRadius,
                    center.Y - Math.Cos(StartAngle3 * Math.PI / 180) * OuterRadius);
                outerArcSegment3.Size = new Size(OuterRadius, OuterRadius);
                outerArcSegment3.SweepDirection = SweepDirection.Counterclockwise;

                ringSlicePath3.Fill = RingSliceColor3;
            }

            #endregion

            // Creates the Bachground Ring
            if (IsBackgroundRing)
            {
                BackgroundringEllipsePath.Fill = BackgroundRingColor;
                BackgroundringEllipsePath.Stroke = Application.Current.Resources["Stroke1"] as SolidColorBrush;
                BackgroundringEllipsePath.StrokeThickness = 1;

                BackgroundringInnerEllipseGeometry.Center = center;
                BackgroundringInnerEllipseGeometry.RadiusX = InnerRadius;
                BackgroundringInnerEllipseGeometry.RadiusY = InnerRadius;

                BackgroundringOuterEllipseGeometry.Center = center;
                BackgroundringOuterEllipseGeometry.RadiusX = OuterRadius;
                BackgroundringOuterEllipseGeometry.RadiusY = OuterRadius;
            }

            if (Text != null && isTextEnabled != false)
            {
                if (Text.Length > 4)
                {
                    textBlock.Text = Text.Substring(0, 4) + "%";
                }
                else
                {
                    textBlock.Text = Text + "%";
                }
            }
        }
        #endregion
    }
}
