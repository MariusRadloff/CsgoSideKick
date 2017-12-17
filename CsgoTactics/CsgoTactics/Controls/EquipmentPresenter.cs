using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CsgoTactics.Controls
{
    // Control for displaying the equipment of the player
    public class EquipmentPresenter : Grid
    {
        StackPanel rootPanel = new StackPanel();
        TextBlock TextBlockTotalValue = new TextBlock();
        TextBlock TextBlockCurrentValue = new TextBlock();
        TextBlock TextBlockEquipmentType = new TextBlock();
        TextBlock TextBlockEquipmentName = new TextBlock();
        BitmapImage BitmapImageEquipmentPicture = new BitmapImage();
        Image ImageEquipmentPicture = new Image();

        public EquipmentPresenter()
        {
            rootPanel.Orientation = Orientation.Vertical;
            rootPanel.Children.Add(TextBlockEquipmentType);
            rootPanel.Children.Add(ImageEquipmentPicture);
            rootPanel.Children.Add(TextBlockEquipmentName);
            rootPanel.Children.Add(TextBlockCurrentValue);
            //BitmapIconEquipmentPicture.Height = 50;
            //BitmapIconEquipmentPicture.Width = 100;
            TextBlockEquipmentType.FontSize = 20;
            TextBlockEquipmentName.FontSize = 24;
            TextBlockCurrentValue.FontSize = TextBlockTotalValue.FontSize = 30;


            this.Children.Add(rootPanel);
        }

        #region EquipmentPresenterType
        public EquipmentPresenterType PresenterType
        {
            get { return (EquipmentPresenterType)GetValue(PresenterTypeProperty); }
            set { SetValue(PresenterTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PresenterType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PresenterTypeProperty =
            DependencyProperty.Register("PresenterType", typeof(EquipmentPresenterType), typeof(EquipmentPresenter), new PropertyMetadata(EquipmentPresenterType.Weapon, OnPresenterTypeChanged));

        private static void OnPresenterTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (EquipmentPresenter)d;
            var oldValue = (EquipmentPresenterType)e.OldValue;
            var newValue = (EquipmentPresenterType)e.NewValue;
            target.OnPresenterTypeChanged(newValue, oldValue);
        }

        private void OnPresenterTypeChanged(EquipmentPresenterType newValue, EquipmentPresenterType oldValue)
        {
            ChangePresenterType(newValue);
        }

        private void ChangePresenterType(EquipmentPresenterType type)
        {
            switch (type)
            {
                case EquipmentPresenterType.Weapon:
                    this.Background = Application.Current.Resources["EquipmentPresenterWeaponBackground"] as SolidColorBrush;
                    TextBlockEquipmentType.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockEquipmentType.FontSize = 20;
                    TextBlockEquipmentType.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    TextBlockEquipmentName.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockEquipmentName.FontSize = 20;
                    TextBlockEquipmentName.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    TextBlockCurrentValue.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockCurrentValue.FontSize = 20;
                    TextBlockCurrentValue.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    ImageEquipmentPicture.Width = 200;
                    ImageEquipmentPicture.Height = 200;
                    break;
                case EquipmentPresenterType.Grenade:
                    this.Background = Application.Current.Resources["EquipmentPresenterGrenadeBackground"] as SolidColorBrush;
                    TextBlockEquipmentType.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockEquipmentType.FontSize = 20;
                    TextBlockEquipmentType.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush; ;
                    TextBlockEquipmentName.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockEquipmentName.FontSize = 20;
                    TextBlockEquipmentName.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    TextBlockCurrentValue.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockCurrentValue.FontSize = 20;
                    TextBlockCurrentValue.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    ImageEquipmentPicture.Width = 200;
                    ImageEquipmentPicture.Height = 200;
                    break;
                case EquipmentPresenterType.Equipment:
                    this.Background = Application.Current.Resources["EquipmentPresenterEquipmentBackground"] as SolidColorBrush;
                    TextBlockEquipmentType.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockEquipmentType.FontSize = 20;
                    TextBlockEquipmentType.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush; ;
                    TextBlockEquipmentName.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockEquipmentName.FontSize = 20;
                    TextBlockEquipmentName.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    TextBlockCurrentValue.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockCurrentValue.FontSize = 20;
                    TextBlockCurrentValue.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    ImageEquipmentPicture.Width = 200;
                    ImageEquipmentPicture.Height = 200;
                    break;
                case EquipmentPresenterType.Armor:
                    this.Background = Application.Current.Resources["EquipmentPresenterArmorBackground"] as SolidColorBrush;
                    TextBlockEquipmentType.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockEquipmentType.FontSize = 20;
                    TextBlockEquipmentType.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush; ;
                    TextBlockEquipmentName.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockEquipmentName.FontSize = 20;
                    TextBlockEquipmentName.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    TextBlockCurrentValue.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockCurrentValue.FontSize = 20;
                    TextBlockCurrentValue.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    ImageEquipmentPicture.Width = 200;
                    ImageEquipmentPicture.Height = 200;
                    break;
                case EquipmentPresenterType.Bomb:
                    this.Background = Application.Current.Resources["EquipmentPresenterBombBackground"] as SolidColorBrush;
                    TextBlockEquipmentType.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockEquipmentType.FontSize = 20;
                    TextBlockEquipmentType.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush; ;
                    TextBlockEquipmentName.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockEquipmentName.FontSize = 20;
                    TextBlockEquipmentName.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    TextBlockCurrentValue.FontStyle = Windows.UI.Text.FontStyle.Normal;
                    TextBlockCurrentValue.FontSize = 20;
                    TextBlockCurrentValue.Foreground = Application.Current.Resources["EquipmentPresenterForegroung"] as SolidColorBrush;
                    ImageEquipmentPicture.Width = 200;
                    ImageEquipmentPicture.Height = 200;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region EquipmentType
        public string EquipmentType
        {
            get { return (string)GetValue(EquipmentTypeProperty); }
            set { SetValue(EquipmentTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EquipmentType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EquipmentTypeProperty =
            DependencyProperty.Register("EquipmentType", typeof(string), typeof(EquipmentPresenter), new PropertyMetadata("Na", OnEquipmentTypeChanged));

        private static void OnEquipmentTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (EquipmentPresenter)d;
            var oldValue = e.OldValue;
            var newValue = e.NewValue;
            target.OnEquipmentTypeChanged(newValue, oldValue);
        }

        private void OnEquipmentTypeChanged(object newValue, object oldValue)
        {
            TextBlockEquipmentType.Text = EquipmentType;
            //UpdateGrid();
        }
        #endregion

        #region EquipmentName
        public string EquipmentName
        {
            get { return (string)GetValue(EquipmentNameProperty); }
            set { SetValue(EquipmentNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EquipmentName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EquipmentNameProperty =
            DependencyProperty.Register("EquipmentName", typeof(string), typeof(EquipmentPresenter), new PropertyMetadata("Na", OnEquipmentNameChanged));

        private static void OnEquipmentNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (EquipmentPresenter)d;
            var oldValue = e.OldValue;
            var newValue = e.NewValue;
            target.OnEquipmentNameChanged(newValue, oldValue);
        }

        private void OnEquipmentNameChanged(object newValue, object oldValue)
        {
            TextBlockEquipmentName.Text = EquipmentName;
            //UpdateGrid();
        }
        #endregion

        #region EquipmentTotalValue
        public int EquipmentTotalValue
        {
            get { return (int)GetValue(EquipmentTotalValueProperty); }
            set { SetValue(EquipmentTotalValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EquipmentValueTotal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EquipmentTotalValueProperty =
            DependencyProperty.Register("EquipmentTotalValue", typeof(int), typeof(EquipmentPresenter), new PropertyMetadata(0, OnEquipmentTotalValueChanged));

        private static void OnEquipmentTotalValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (EquipmentPresenter)d;
            var oldValue = e.OldValue;
            var newValue = e.NewValue;
            target.OnEquipmentTotalValueChanged(newValue, oldValue);
        }

        private void OnEquipmentTotalValueChanged(object newValue, object oldValue)
        {
            TextBlockCurrentValue.Text = EquipmentCurrentValue + " / " + EquipmentTotalValue;
            //UpdateGrid();
        }
        #endregion

        #region EquipmentCurrentValue
        public int EquipmentCurrentValue
        {
            get { return (int)GetValue(EquipmentCurrentValueProperty); }
            set { SetValue(EquipmentCurrentValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EquipmentValueCurrent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EquipmentCurrentValueProperty =
            DependencyProperty.Register("EquipmentCurrentValue", typeof(int), typeof(EquipmentPresenter), new PropertyMetadata(0, OnEquipmentCurrentValueChanged));

        private static void OnEquipmentCurrentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (EquipmentPresenter)d;
            var oldValue = e.OldValue;
            var newValue = e.NewValue;
            target.OnEquipmentCurrentValueChanged(newValue, oldValue);
        }

        private void OnEquipmentCurrentValueChanged(object newValue, object oldValue)
        {
            TextBlockCurrentValue.Text = EquipmentCurrentValue + " / " + EquipmentTotalValue;
            //UpdateGrid();
        }
        #endregion

        #region EquipmentPictureUri
        public string EquipmentPictureUri
        {
            get { return (string)GetValue(EquipmentPictureUriProperty); }
            set { SetValue(EquipmentPictureUriProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EquipmentPictureUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EquipmentPictureUriProperty =
            DependencyProperty.Register("EquipmentPictureUri", typeof(string), typeof(EquipmentPresenter), new PropertyMetadata("", OnEquipmentPictureUriChanged));

        private static void OnEquipmentPictureUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (EquipmentPresenter)d;
            var oldValue = e.OldValue;
            var newValue = e.OldValue;
            target.OnEquipmentPictureUriChanged(newValue, oldValue);
        }

        private void OnEquipmentPictureUriChanged(object newValue, object oldValue)
        {
            BitmapImageEquipmentPicture.UriSource = new Uri(EquipmentPictureUri);
            ImageEquipmentPicture.Source = BitmapImageEquipmentPicture;
            //UpdateGrid();
        }
        #endregion

        public enum EquipmentPresenterType
        {
            Weapon,
            Grenade,
            Equipment,
            Armor,
            Bomb
        }

        private void UpdateGrid()
        {
            TextBlockEquipmentType.Text = EquipmentType;
            TextBlockEquipmentName.Text = EquipmentName;
            TextBlockCurrentValue.Text = EquipmentCurrentValue + " / " + EquipmentTotalValue;
            BitmapImageEquipmentPicture.UriSource = new Uri(EquipmentPictureUri);
            ImageEquipmentPicture.Source = BitmapImageEquipmentPicture;
        }
    }
}
