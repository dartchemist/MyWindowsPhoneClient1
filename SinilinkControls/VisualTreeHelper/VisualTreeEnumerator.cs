using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace SinilinkControls.VisualTreeHelper
{
    public static class VisualTreeEnumerator
    {
        public static TPanel FindLayoutContainer<TPanel>(DependencyObject parent) where TPanel : Panel
        {
            if (parent == null)
            {
                return null;
            }

            TPanel foundLayoutContainer =  null;
            var pageChildrenCount = System.Windows.Media.VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < pageChildrenCount; ++i)
            {
                var child = System.Windows.Media.VisualTreeHelper.GetChild(parent, i);
                var childType = child as TPanel;
                if (childType == null)
                {
                    foundLayoutContainer = FindLayoutContainer<TPanel>(child);
                    if (foundLayoutContainer != null)
                        break;
                }
                else
                {
                    foundLayoutContainer = (TPanel) child;
                    break;
                }
            }
            return foundLayoutContainer;
        }
    }
}