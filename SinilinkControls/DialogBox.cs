using System;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using SinilinkControls.VisualTreeHelper;

namespace SinilinkControls
{
    public class DialogBox : ContentControl
    {
        private readonly TaskCompletionSource<DialogBoxResult> _dialogBoxCompletionSource =
            new TaskCompletionSource<DialogBoxResult>();

        private Panel _parentPageLayoutPanel;
        
        #region Dependency Properties
        
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(DialogBox), new PropertyMetadata(string.Empty));

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleIconProperty =
            DependencyProperty.Register("TitleIcon", typeof(ImageSource), typeof(DialogBox), new PropertyMetadata(null));

        public ImageSource TitleIcon
        {
            get { return (ImageSource) GetValue(TitleIconProperty); }
            set { SetValue(TitleIconProperty, value); }
        }

        public static readonly DependencyProperty OkButtonContentProperty =
            DependencyProperty.Register("OkButtonContent", typeof(object), typeof(DialogBox), new PropertyMetadata(null));

        public object OkButtonContent
        {
            get { return GetValue(OkButtonContentProperty); }
            set { SetValue(OkButtonContentProperty, value); }
        }

        public static readonly DependencyProperty CancelButtonContentProperty =
            DependencyProperty.Register("CancelButtonContent", typeof(object), typeof(DialogBox), new PropertyMetadata(null));

        public object CancelButtonContent
        {
            get { return GetValue(CancelButtonContentProperty); }
            set { SetValue(CancelButtonContentProperty, value); }
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(DialogBox), new PropertyMetadata(false));

        public bool IsOpen
        {
            get { return (bool) GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        #endregion

        public DialogBoxButtons Buttons { get; set; }
        public int? RowSpanSize { get; set; }

        public DialogBox()
        {
            DefaultStyleKey = typeof (DialogBox);
            FindRootLayoutPanel();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
           
            var okButton = GetTemplateChild("OkButton") as Button;
            var cancelButton = GetTemplateChild("CancelButton") as Button;

            okButton.Click += (sender, args) =>
            {
                _dialogBoxCompletionSource.SetResult(DialogBoxResult.Ok);
                CloseDialog();
            };

            cancelButton.Click += (sender, args) =>
            {
                _dialogBoxCompletionSource.SetResult(DialogBoxResult.Cancel);
                CloseDialog();
            };
        }

        public async Task<DialogBoxResult> Show(DialogBoxInitializationInfo initializationInfo)
        {
            InitializeDialogBox(initializationInfo);
            _parentPageLayoutPanel.Children.Add(this);
            IsOpen = true;
            return await _dialogBoxCompletionSource.Task;
        }
        #region Private Methods
        
        private void FindRootLayoutPanel()
        {
            var currentPhonePage =
               ((PhoneApplicationFrame)Application.Current.RootVisual).Content as PhoneApplicationPage;
            _parentPageLayoutPanel = VisualTreeEnumerator.FindLayoutContainer<Grid>(currentPhonePage);
            var grid = _parentPageLayoutPanel as Grid;
            if (grid != null)
            {
                RowSpanSize = grid.RowDefinitions.Count;

            }
        }
        
        private void CloseDialog()
        {
            IsOpen = false;
            _parentPageLayoutPanel.Children.Remove(this);
        }

        private void InitializeDialogBox(DialogBoxInitializationInfo initializationInfo)
        {
            Title = initializationInfo.Title;
            Content = initializationInfo.Content;
            Buttons = initializationInfo.Buttons;
            OkButtonContent = initializationInfo.OkButtonContent;
            CancelButtonContent = initializationInfo.CancelButtonContent;
        }
        
        #endregion
    }
}
