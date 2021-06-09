using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Security;
using ExtensionMethods;
using System.Text.RegularExpressions;

namespace StickerApp
{

    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapSource userImage;
        System.Windows.Media.Brush emotePressed;
        string filepath;
        List<BitmapSource> changeHistory = new List<BitmapSource>();
        int changeNumber = 1;
        bool justUndid = false;
        public MainWindow()
        {
            InitializeComponent();
            userImage = new BitmapImage(new Uri(ImagePanel1.Source.ToString()));
            changeHistory.Add(userImage);
        }

        private void ButtonOpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            string path = @"C:\Programowanie\Studia\C#\S4 - Programowanie\Stickers";
            if (Directory.Exists(path))
            {
                openFileDialog.InitialDirectory = path;
            }
            else
            {
                openFileDialog.InitialDirectory = @"C:\";
            }

            if (openFileDialog.ShowDialog() == true)
            {
                userImage = new BitmapImage(new Uri(openFileDialog.FileName));
                ImagePanel1.Source = userImage;
                filepath = string.Empty;
                changeNumber = 1;
                clearList(changeHistory);
                changeHistory[0] = userImage;
            }
        }

        private void ButtonSaveAs(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Image";
            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";

            string path = @"C:\Programowanie\Studia\C#\S4 - Programowanie\Stickers";
            if (Directory.Exists(path))
            {
                saveFileDialog.InitialDirectory = path;
            }
            else
            {
                saveFileDialog.InitialDirectory = @"C:\";
            }

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    filepath = saveFileDialog.FileName;
                    var encoder = new PngBitmapEncoder(); // Or PngBitmapEncoder, or whichever encoder you want
                    encoder.Frames.Add(BitmapFrame.Create(userImage));
                    encoder.Save(saveFileDialog.OpenFile());
                    GrantAccess(filepath);
                }
                catch (System.IO.IOException)
                {
                    GrantAccess(filepath);
                    MessageBox.Show("File is currently being used!", "Error!");
                }
            }
        }

        private void ButtonQuickSave(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(filepath))
            {

                try
                {
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(userImage));
                    encoder.Save(new FileStream(filepath, FileMode.Create));
                    GrantAccess(filepath);
                }
                catch (System.IO.IOException)
                {
                    GrantAccess(filepath);
                    MessageBox.Show("File is currently being used!", "Error!");
                }
            }
            else ButtonSaveAs(sender, e);

        }

        private bool GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(
                new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                FileSystemRights.FullControl,
                InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                PropagationFlags.NoPropagateInherit,
                AccessControlType.Allow));

            dInfo.SetAccessControl(dSecurity);
            return true;
        }

        private void StickerClick(object sender, RoutedEventArgs e)
        {
            emotePressed = (e.Source as Button).Background;

            SetRotation();
            if (SizeValue.Text != String.Empty)
            {
                customPointer.Height = 60 * (Convert.ToDouble(SizeValue.Text) / 100);
                customPointer.Width = 60 * (Convert.ToDouble(SizeValue.Text) / 100);
            }

            customPointer.Fill = emotePressed;
        }
        double pX;
        double pY;

        void OnMouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (emotePressed != null)
            {
                customPointer.Opacity = 0.7;
                // Get the x and y coordinates of the mouse pointer
                System.Windows.Point p = e.GetPosition(RootCanvas);
                // customPointer.Source = emotePressed;
                pX = p.X;
                pY = p.Y;
                // Set the coordinates of customPointer to the mouse pointer coordinates
                Canvas.SetTop(customPointer, pY-customPointer.Height/2);
                Canvas.SetLeft(customPointer, pX-customPointer.Width/2);
                
                Cursor = Cursors.None;
            }
        }

        void OnMouseLeaveHandler(object sender, MouseEventArgs e)
        {
            customPointer.Opacity = 0;
            Cursor = Cursors.Arrow;
        }

        private void RootCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(emotePressed != null && pX>0 && pY>0 && pX<userImage.Width && pY<userImage.Height)
            {
                if(justUndid)
                {
                    clearList(changeHistory);
                    justUndid = false;
                }

                RotateTransform aRotateTransform = new RotateTransform();
                aRotateTransform.CenterX = 0.5;
                aRotateTransform.CenterY = 0.5;
                aRotateTransform.Angle = Convert.ToInt16(RotationValue.Text);
                emotePressed.RelativeTransform = aRotateTransform;

                //ImageBrush bg = new ImageBrush();
                //bg.ImageSource = userImage;
                //bg.Stretch = Stretch.None;
                //bg.AlignmentX = AlignmentX.Left;
                //bg.AlignmentY = AlignmentY.Top;
                //myWindow.Background = bg;

                BitmapSource beforeSavingAlpha = BitmapSourceFromBrush(emotePressed, Convert.ToInt32(customPointer.Height));
                //BitmapSource alpha = GetAlphaAsGrayBitmap(beforeSavingAlpha);
                WriteableBitmap mybrush = new WriteableBitmap((BitmapSource)(new FormatConvertedBitmap(beforeSavingAlpha, PixelFormats.Bgr32, null, 0)));


                WriteableBitmap mybrushCropped = CropToFit(mybrush);
                mybrushCropped = new WriteableBitmap((BitmapSource)(new FormatConvertedBitmap(/*MergeAlphaAndRGB(mybrushCropped, alpha)*/ mybrushCropped, PixelFormats.Bgr32, null, 0)));
                //ImagePanel1.Source = mybrushCropped;
                userImage = new WriteableBitmap((BitmapSource)(new FormatConvertedBitmap(userImage, PixelFormats.Bgr32, null, 0)));     //change to Bgra32 for alpha (writes transparency instead of black bg)
                userImage = OverlayBitmaps(userImage, mybrushCropped);
                ImagePanel1.Source = userImage;
                aRotateTransform.Angle = 0;
                emotePressed.RelativeTransform = aRotateTransform;
                changeHistory.Add(userImage);
                changeNumber++;

            }
        }

        WriteableBitmap CropToFit(WriteableBitmap mybrush)
        {   
            if(mybrush.Height/2 > pY)   //top
            {
                double tophdiff = (mybrush.Height / 2 - pY);

                mybrush = new WriteableBitmap(new CroppedBitmap(mybrush, new Int32Rect(0, Convert.ToInt32(mybrush.Height / 2 - pY), Convert.ToInt32(mybrush.Width),Convert.ToInt32(mybrush.Height-tophdiff))));
            }

            if (mybrush.Width / 2 > pX) //left
            {
                double leftwdiff = (mybrush.Width / 2 - pX);

                mybrush = new WriteableBitmap(new CroppedBitmap(mybrush, new Int32Rect(Convert.ToInt32(mybrush.Width / 2 - pX), 0, Convert.ToInt32(mybrush.Width - leftwdiff), Convert.ToInt32(mybrush.Height))));
            }

            if (mybrush.Height / 2 + pY > userImage.Height)    //bottom
            {
                double bothdiff = (mybrush.Height / 2 + pY - userImage.Height);

                mybrush = new WriteableBitmap(new CroppedBitmap(mybrush, new Int32Rect(0, 0, Convert.ToInt32(mybrush.Width), Convert.ToInt32(mybrush.Height - bothdiff))));
            }

            if (mybrush.Width / 2 + pX > userImage.Width)     //right
            {
                double rightwdiff = (mybrush.Width / 2 + pX - userImage.Width);

                mybrush = new WriteableBitmap(new CroppedBitmap(mybrush, new Int32Rect(0, 0, Convert.ToInt32(mybrush.Width - rightwdiff), Convert.ToInt32(mybrush.Height))));
            }

            return mybrush;
        }


        private void RotationValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (emotePressed != null)
            {
                SetRotation();
            }
        }

        private void SizeValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (customPointer != null && SizeValue.Text != String.Empty && RotationValue.Text != String.Empty)
            {
                customPointer.Height = 60 * (Convert.ToDouble(SizeValue.Text) / 100);
                customPointer.Width = 60 * (Convert.ToDouble(SizeValue.Text) / 100);
                customPointer.Fill = emotePressed;

                SetRotation();
            }
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static readonly Regex _regex = new Regex("[^0-9]+"); 
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void SetRotation()
        {
            if (RotationValue.Text != String.Empty)
            {
                RotateTransform aRotateTransform = new RotateTransform();
                aRotateTransform.CenterX = customPointer.Height / 2;
                aRotateTransform.CenterY = customPointer.Width / 2;
                aRotateTransform.Angle = Convert.ToInt16(RotationValue.Text);
                //RootCanvas.RenderTransform = aRotateTransform;
                customPointer.RenderTransform = aRotateTransform;

            }
        }


        public BitmapSource OverlayBitmaps(BitmapSource b1, BitmapSource b2)
        {
            if (b1.Format != b2.Format)
            {
                throw new ArgumentException("All input bitmaps must have the same pixel format");
            }

            var width = b1.PixelWidth;
            var height = b1.PixelHeight;
            var wb = new WriteableBitmap(width, height, 96, 96, b1.Format, null);
            var stride1 = (b1.PixelWidth * b1.Format.BitsPerPixel + 7) / 8;
            var stride2 = (b2.PixelWidth * b2.Format.BitsPerPixel + 7) / 8;
            var size = b1.PixelHeight * stride1;

            var buffer = new byte[size];
            b1.CopyPixels(buffer, stride1, 0);
            wb.WritePixels(
                new Int32Rect(0, 0, b1.PixelWidth, b1.PixelHeight),
                buffer, stride1, 0);
            b2.CopyPixels(buffer, stride2, 0);
            try
            {
                wb.WritePixels(
                    new Int32Rect(Convert.ToInt32(pX) - b2.PixelWidth / 2 + (pX > b2.Width / 2 ? 0 : Convert.ToInt32(b2.Width / 2 - pX)) -
                    (b2.Width / 2 + pX < userImage.Width ? 0 : Convert.ToInt32(b2.Width / 2 + pX - userImage.Width)),
                    Convert.ToInt32(pY) - b2.PixelHeight / 2 + (pY > b2.Height / 2 ? 0 : Convert.ToInt32(b2.Height / 2 - pY)) -
                    (b2.Height / 2 + pY < userImage.Height ? 0 : Convert.ToInt32(b2.Height / 2 + pY - userImage.Height)),
                    b2.PixelWidth, b2.PixelHeight),
                    buffer, stride2, 0);
            }
            catch
            {
               
            }

            return wb;
        }

        public static BitmapSource BitmapSourceFromBrush(Brush drawingBrush, int size = 32, int dpi = 96)
        {
            // RenderTargetBitmap = builds a bitmap rendering of a visual
            var pixelFormat = PixelFormats.Pbgra32;
            RenderTargetBitmap rtb = new RenderTargetBitmap(size, size, dpi, dpi, pixelFormat);

            // Drawing visual allows us to compose graphic drawing parts into a visual to render
            var drawingVisual = new DrawingVisual();
            using (DrawingContext context = drawingVisual.RenderOpen())
            {
                // Declaring drawing a rectangle using the input brush to fill up the visual
                context.DrawRectangle(drawingBrush, null, new Rect(0, 0, size, size));
            }

            // Actually rendering the bitmap
            rtb.Render(drawingVisual);
            return rtb;
        }


        //SavingAlpha
        private static BitmapSource GetAlphaAsGrayBitmap(BitmapSource rgba)
        {
            WriteableBitmap bmp = new WriteableBitmap(rgba);
            WriteableBitmap alpha = new WriteableBitmap(rgba.PixelWidth, rgba.PixelHeight, 96, 96, PixelFormats.Gray8, null);

            unsafe
            {
                byte* alphaPtr = (byte*)alpha.BackBuffer.ToPointer();
                byte* mainPtr = (byte*)bmp.BackBuffer.ToPointer();
                for (int i = 0; i < bmp.PixelWidth * bmp.PixelHeight; i++)
                    alphaPtr[i] = mainPtr[i * 4 + 3];
            }

            return alpha;
        }

        private static BitmapSource MergeAlphaAndRGB(BitmapSource rgb, BitmapSource alpha)
        {
            // Put alpha back in
            WriteableBitmap dstW = new WriteableBitmap(new FormatConvertedBitmap(rgb, PixelFormats.Bgra32, null, 0));
            WriteableBitmap alphaW = new WriteableBitmap(alpha);
            unsafe
            {
                byte* resizedPtr = (byte*)dstW.BackBuffer.ToPointer();
                byte* alphaPtr = (byte*)alphaW.BackBuffer.ToPointer();
                for (int i = 0; i < dstW.PixelWidth * dstW.PixelHeight; i++)
                    resizedPtr[i * 4 + 3] = alphaPtr[i];
            }

            return dstW;
        }

        private static BitmapSource GetScaledBitmap(BitmapSource src, ScaleTransform scale)
        {
            if (src.Format == PixelFormats.Bgra32) // special case when image has an alpha channel
            {
                // Put alpha in a gray bitmap and scale it
                BitmapSource alpha = GetAlphaAsGrayBitmap(src);
                TransformedBitmap scaledAlpha = new TransformedBitmap(alpha, scale);

                // Scale RGB without taking in account alpha
                TransformedBitmap scaledSrc = new TransformedBitmap(new FormatConvertedBitmap(src, PixelFormats.Bgr32, null, 0), scale);

                // Merge them back
                return MergeAlphaAndRGB(scaledSrc, scaledAlpha);
            }
            else
            {
                return new TransformedBitmap(src, scale);
            }
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (changeNumber > 1)
            {
                justUndid = true;
                changeNumber--;
                userImage = changeHistory[changeNumber - 1];
                ImagePanel1.Source = userImage;

            }
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            if (changeHistory.Count>1 && changeNumber < changeHistory.Count)
            {
                changeNumber++;
                userImage = changeHistory[changeNumber - 1];
                ImagePanel1.Source = userImage;
            }
        }

        private void clearList(List<BitmapSource> list)
        {
            int end = list.Count;
            for (int i = changeNumber; i < end; i++)
            {
                list.RemoveAt(list.Count - 1);
            }
            justUndid = false;
        }

        private void ZoomOn_Click(object sender, RoutedEventArgs e)
        {
            
            border.Initialize(border);
            RootCanvas.IsHitTestVisible = false;
        }

        private void ZoomOff_Click(object sender, RoutedEventArgs e)
        {
            border.Reset();
            RootCanvas.IsHitTestVisible = true;
        }
    }

}
