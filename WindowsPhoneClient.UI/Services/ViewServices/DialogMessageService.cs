using System.Threading.Tasks;
using System.Windows.Controls;
using WindowsPhoneClient.UI.Resources;
using SinilinkControls;

namespace WindowsPhoneClient.UI.Services.ViewServices
{
    public class DialogMessageService : IMessageService
    {
        public bool ShowMessage(string message, string caption, bool confirmation)
        {
            var dialogInitializationInfo = new DialogBoxInitializationInfo
            {
                Buttons = confirmation ? DialogBoxButtons.Ok : DialogBoxButtons.OkCancel,
                Content = message,
                Title = caption,
                OkButtonContent = AppResources.SinilinkDialogOkButtonText,
                CancelButtonContent = AppResources.SinilinkDialogCancelButtonText
            };
            var dialogBox = new DialogBox();
            dialogBox.Width = (double)App.Current.Resources["ScreenWidth"];
            dialogBox.Height = (double)App.Current.Resources["ScreenHeight"];
            if (dialogBox.RowSpanSize.HasValue)
            {
                Grid.SetRowSpan(dialogBox, dialogBox.RowSpanSize.Value);
            }
            dialogBox.Show(dialogInitializationInfo).ContinueWith(t => true, TaskContinuationOptions.OnlyOnRanToCompletion);
            return false;

        }
    }
}