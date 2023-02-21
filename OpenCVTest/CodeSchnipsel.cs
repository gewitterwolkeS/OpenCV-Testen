//Button b = new Button();
//b.Content = "hallo";
//b.Click += B_Click;
//this.Content = b;
//this.MouseDown += StartFenster_MouseDown;
//DockPanel dockPanel;
//StackPanel stackPanel;
//Image image;
//Label label1;
//Button button1;
//private void StartFenster_MouseDown(object sender, MouseButtonEventArgs e)
//{
//    System.Windows.Point pos = e.GetPosition(image);
//    throw new NotImplementedException();
//}

//private void B_Click(object sender, RoutedEventArgs e)
//{

//    this.Title = "sdfsdf";
//    Point x;
//    OpenCvSharp.Point p;

//    //image.Source = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(m);
//    //if (image.Source != null)
//    //{
//    //    Point pos = e.GetPosition(image);
//    //    var x = Math.Floor(pos.X * image.Source.Width / image.ActualWidth);
//    //    var y = Math.Floor(pos.Y * image.Source.Height / image.ActualHeight);

//    //    sizeStart = new OpenCvSharp.Point(x, y);
//    //    size = true;
//    //}
//    //OpenFileDialog bofd = new OpenFileDialog();
//    //bofd.Title = "BlackSource";
//    //if (bofd.ShowDialog() == true)
//    //{
//    //    filenameWhite = wofd.FileName;
//    //    filenameBlack = bofd.FileName;
//    //    loadImage();
//    //}
//    //whiteSource = Cv2.ImRead(filenameWhite);
//    //blackSource = Cv2.ImRead(filenameBlack);
//}
//public class PuzzleTeil
//{
//    public Mat maske;
//    public Mat bild;   
//    public PuzzleTeil(Mat bild, Mat maske)
//    {

//    }  
//    public OpenCvSharp.Point[] getContour()
//    {
//        if (contour == null)
//        {
//            OpenCvSharp.Point[][] contours;
//            HierarchyIndex[] hierarchyIndices;
//            Cv2.FindContours(mask, out contours, out hierarchyIndices, RetrievalModes.CComp, ContourApproximationModes.ApproxNone);
//            contour = contours[0];
//        }
//        return contour;
//        //return contours[0];
//    }  


//    public static PuzzleTeil load(Stream fs)
//    {
//        Mat mask = Serializer.getMat(fs);
//        var boundingRect = Serializer.getRect(fs);
//        PuzzleTeil ret = new PuzzleTeil(scan, mask, boundingRect);
//        for (int i = 0; i < 4; i++)
//        {
//            ret.Ecken[i] = Serializer.getInt32(fs);// .dd((Int32)Ecken[i], fs);
//        }
//        return ret;
//    }
//    public void writeToStream(Stream fs)
//    {
//        Serializer.Add(mask, fs);
//        Serializer.Add(boundingRect, fs);
//        for (int i = 0; i < 4; i++)
//        {
//            Serializer.Add((Int32)Ecken[i], fs);
//        }
//    }
//}

//using OpenCvSharp;
//using System;

//void loadImage()
//{
//    whiteSource = Cv2.ImRead(filenameWhite);
//    blackSource = Cv2.ImRead(filenameBlack);
//    difSourceGray = new Mat();
//    Mat difSource = whiteSource - blackSource;
//    Cv2.CvtColor(difSource, difSourceGray, ColorConversionCodes.BGR2GRAY);
//    Calc();
//}

//private void ValueChanged(object? sender, EventArgs e)
//{
//    Calc();
//}
//public PuzzleScan psc = new PuzzleScan();
//public void Calc()
//{
//    result.Content = "Nix";
//    Mat thresholdImage = new Mat();
//    Cv2.Threshold(difSourceGray, thresholdImage, threshold.val, 255, ThresholdTypes.BinaryInv);


//    Mat strukturElement = new Mat();
//    Cv2.Erode(thresholdImage, thresholdImage, strukturElement, null, erode.val);

//    ConnectedComponents cc = Cv2.ConnectedComponentsEx(thresholdImage, PixelConnectivity.Connectivity8);

//    psc = new PuzzleScan();
//    psc.image = new Mat();
//    whiteSource.CopyTo(psc.image);
//    Mat realWhite = new Mat(whiteSource.Size(), MatType.CV_8UC1, Scalar.White);
//    foreach (ConnectedComponents.Blob b in cc.Blobs)
//    {
//        if (b.Area > minSize.val && b.Area < maxSize.val)
//        {
//            OpenCvSharp.Rect boundingRect = new OpenCvSharp.Rect(b.Rect.Left - sizePlus.val, b.Rect.Top - sizePlus.val, b.Width + 2 * sizePlus.val, b.Height + 2 * sizePlus.val);
//            if (boundingRect.X < 0)
//            {
//                boundingRect.Width += boundingRect.X;
//                boundingRect.X = 0;
//            }
//            if (boundingRect.Y < 0)
//            {
//                boundingRect.Height += boundingRect.Y;
//                boundingRect.Y = 0;
//            }
//            if (boundingRect.Right > whiteSource.Width) boundingRect.Width = whiteSource.Width - boundingRect.Left;
//            if (boundingRect.Bottom > whiteSource.Height) boundingRect.Height = whiteSource.Height - boundingRect.Top;
//            Mat mask = new Mat();
//            cc.FilterByBlob(realWhite, mask, b);
//            mask[boundingRect].CopyTo(mask);

//            Cv2.Dilate(mask, mask, strukturElement, null, diletate.val);

//            PuzzleTeil neuesTeil = new PuzzleTeil(psc, mask, boundingRect);
//            //neuesTeil.scan = psc;
//            //neuesTeil.mask = mask;
//            //neuesTeil.targetRect = boundingRect;
//            psc.teile.Add(neuesTeil);
//        }
//    }
//    result.Content = psc.ToString();
//    draw();
//}