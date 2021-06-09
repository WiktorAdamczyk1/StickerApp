using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace StickerApp
{
    public partial class ButtonStyleSticker : ResourceDictionary
    {
        private void StickerEnterHandler(object sender, RoutedEventArgs e)
        {
            var srcButton = e.Source as Button;
            srcButton.BorderThickness = new Thickness(1);
            srcButton.BorderBrush = new SolidColorBrush(Colors.Black);
        }
        private void StickerLeaveHandler(object sender, RoutedEventArgs e)
        {
            var srcButton = e.Source as Button;
            srcButton.BorderThickness = new Thickness(0);
            srcButton.BorderBrush = new SolidColorBrush(Colors.Black);
        }
    }
}
