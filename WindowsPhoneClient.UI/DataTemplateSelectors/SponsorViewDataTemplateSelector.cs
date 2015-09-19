using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsPhoneClient.UI.Models;

namespace WindowsPhoneClient.UI.DataTemplateSelectors
{
    public class SponsorViewDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultLogoDataTemplateSelector { get; set; }
        public DataTemplate SponsorWithLogoDataTemplateSelector { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var dataBoundItem = item as PartnerModel;
            if (dataBoundItem.LogoRelativePath.ToLower().Contains("default"))
            {
                return DefaultLogoDataTemplateSelector;
            }
            else
            {
                return SponsorWithLogoDataTemplateSelector;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
