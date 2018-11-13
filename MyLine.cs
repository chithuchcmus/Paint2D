﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    [Serializable]
    public class MyLine : MyShape
    {
        public MyLine(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr, _points)
        {
        }

        public override void updatePenAttr(PenAttr _penAttr)
        {
            penAttr = _penAttr;
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 2;
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                pen.DashStyle = penAttr.dashStyle;
                graphics.DrawLine(pen, points[0], points[1]);
                pictureBox.Invalidate();
            }
        }

        public override void drawTemporaryChange(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(COLOR_PEN_DEFAULT))
            {
                pen.DashStyle = DASH_STYLE_TEMP;
                graphics.DrawLine(pen, points[0], points[1]);
                pictureBox.Invalidate();
            }
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            // su dung graphics path
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddLine(points[0], points[1]);
                pen.DashStyle = penAttr.dashStyle;
                return path.IsOutlineVisible(p, pen);
            }
        }

        // khong co diem ben trong
        public override void drawInsidePoint(Bitmap _bitmap, Point p, PictureBox pictureBox)
        {
        }
    }
}