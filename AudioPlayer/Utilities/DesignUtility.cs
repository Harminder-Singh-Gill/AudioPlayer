using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AudioPlayer
{
    class DesignUtility
    {
        public static readonly string InvalidYouTubeUrlMessage = "Not a valid YouTube URL";
        public static readonly string NoInternetMessage = "No Internet.";
        public static readonly string NoYouTubeResultsMessage = "No YouTube songs were found.";
        public static readonly string FileNotFoundMessage = "The file was not found.";
        public static readonly string UrlNotSupportedMessage = "This url is not supported.";
        public static string FileNotSupportedMessage = "The file is not supported.";
        public static string ApologyMessage = "We apologise, It seems there is a problem with playing audio from YouTube at the moment. " +
            "We are looking into it and will resolve this issue at the earliest.";

        public const string PlayNextMessage = "Do you want to play the next audio in the playlist";
        public const string PlayPreviousMessage = "Do you want to play the previous audio in the playlist";
        public const string ErrorCaption = "Error Playing Audio";

        public static readonly Color ColorOffWhite = Color.FromArgb(227, 232, 232);

        public static string GetTimeSpanString(TimeSpan timeSpan)
        {
            int h = timeSpan.Hours;
            int m = timeSpan.Minutes;
            int s = timeSpan.Seconds;
            string zeroS = s < 10 ? "0" : "";
            string zeroM = m < 10 ? "0" : "";
            return (h + ":").TrimStart('0', ':') + zeroM + m + ":" + zeroS + s;
        }
        public static GraphicsPath GetFillet(Rectangle r, int d)
        {

            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(r.X, r.Y, d, d, 180, 90);

            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);

            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);

            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);

            return gp;

        }
        public static GraphicsPath MakeRoundedRect(RectangleF rect, float xradius,
            float yradius, bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            // Make a GraphicsPath to draw the rectangle.
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Upper left corner.
            if (round_ul)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Top side.
            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Right side.
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Bottom side.
            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Left side.
            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();

            return path;
        }
    }
}
