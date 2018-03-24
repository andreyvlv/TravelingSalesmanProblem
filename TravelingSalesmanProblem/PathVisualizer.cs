using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TravelingSalesmanProblem
{
    public class PathVisualizer
    {
        Pen pen;
        SolidBrush textColor;
        Pen background;
        FontFamily fontFamily;
        FontFamily upperTextFont;
        List<Point> points;
        List<Point> bestPointOrder;

        public PathVisualizer()
        {
            pen = new Pen(Color.FromArgb(0x41, 0x8d, 0xcb), 2); // #87BBD0 #418DCB
            textColor = new SolidBrush(Color.FromArgb(0xc0, 0xda, 0xff)); //#C6E6F5 #C0DAFF
            background = new Pen(Color.FromArgb(0x1e, 0x39, 0x64), 5);
            fontFamily = new FontFamily("Arial");
            upperTextFont = new FontFamily("Segoe UI");
            points = PointKeeper.GetRandomPoints();
            bestPointOrder = new List<Point>();
        }

        public void VisualizePath(Graphics graphics, Size size)
        {           
            var sw = new Stopwatch();
            sw.Start();
            var permutationsOfPoints = PathFinder.GetPermutation(points);
            bestPointOrder = PathFinder.GetBestPointOrder(permutationsOfPoints);           
            var bestOrderIndexes = PathFinder.GetBestOrderByIndex(bestPointOrder, points);
            sw.Stop();
            var averagePathLength = PathFinder.GetAveragePathLength(permutationsOfPoints);
            DrawBestPath(graphics, size, bestPointOrder);
            DrawPoints(graphics, size);
            DrawInfo(graphics, sw.Elapsed.TotalMilliseconds, bestOrderIndexes, averagePathLength);          
        }

        void DrawBestPath(Graphics graphics, Size size, List<Point> pointArr)
        {
            var verticalShift = size.Height / 2;
            var horizontalShift = size.Width / 2;

            for (int i = 1; i < pointArr.Count; i++)
            {
                graphics.DrawLine(pen,
                    new Point(pointArr[i - 1].X + horizontalShift - 15, pointArr[i - 1].Y + verticalShift + 5),
                    new Point(pointArr[i].X + horizontalShift - 15, pointArr[i].Y + verticalShift + 5));
            }
        }

        public void DrawPoints(Graphics graphics, Size size)
        {            
            var verticalShift = size.Height / 2;
            var horizontalShift = size.Width / 2;
            
            for (int i = 0; i < points.Count; i++)
            {    
                // отрисовка точек массива
                graphics.DrawEllipse(pen, 
                    new Rectangle(new Point(points[i].X + horizontalShift - 20, points[i].Y + verticalShift), 
                    new Size(10, 10)));

                // зарисовать внутренность кружка
                graphics.DrawEllipse(background,
                    new Rectangle(new Point(points[i].X + horizontalShift - 17, points[i].Y + verticalShift + 3),
                    new Size(4, 4)));

                // отрисовка информации о точке
                graphics.DrawString($"Point: {i}\nX: {points[i].X} \nY: {points[i].Y * -1}",
                       new Font(upperTextFont, 8),
                        textColor,
                        new Point(points[i].X + horizontalShift, points[i].Y + verticalShift));
            }
        }             
         
        void DrawInfo(Graphics graphics, double time, List<int> order, double average)
        {
            
            // для смещения надписей вправо
            int x = 80;
            // вывести надпись Best Way:
            graphics.DrawString($"Best Way: ",
                    new Font(upperTextFont, 10, FontStyle.Bold),
                    textColor,
                    new Point(10, 10));

            // вывести порядок следования точек
            foreach (var item in order)
            {
                graphics.DrawString($"->  {item}",
                    new Font(upperTextFont, 10, FontStyle.Bold),
                    textColor,
                    new Point(x, 10));
                x += 35;
            }
                      
            DrawText(graphics, "Best Path Length:", bestPointOrder.GetPathLength(), 35);           
            DrawText(graphics, "Average Path Length:", average, 60);
            DrawText(graphics, "Time Elapsed:", time, 85);
        }

        void DrawText(Graphics graphics, string header, double info, int yStartPoint)
        {
            graphics.DrawString($"{header} {info:f2}",
                    new Font(upperTextFont, 10, FontStyle.Bold),
                    textColor,
                    new Point(10, yStartPoint));
        }
    }
}
