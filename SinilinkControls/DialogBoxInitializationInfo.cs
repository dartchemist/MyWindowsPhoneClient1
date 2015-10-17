using System;

namespace SinilinkControls
{
    public class DialogBoxInitializationInfo
    {
        public string Title { get; set; }
        public object Content { get; set; }
        public Uri Icon { get; set; }
        public DialogBoxButtons Buttons { get; set; }
        public object OkButtonContent { get; set; }
        public object CancelButtonContent { get; set; }
    }
}