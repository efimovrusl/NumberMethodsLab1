using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphLab1
{
    public partial class Graph : Form
    {
        Pen blackPen = new Pen(Color.Black);
        Pen grayPen = new Pen(Color.Gray);
        Graphics g = null;
        static float x_max, y_max;
        static PointF[] corners = new PointF[4];  // LEFT_UP RIGTH_UP RIGTH_DOWN LEFT_DOWN
        GraphSurface graphSurf1, graphSurf2;
        Table table1, table2;

        /* PRIMARY POINTS TO THIS ARRAY */
        /* VARIANT #2 */
        PointF[] PRIMARY_POINTS_TASK1 = new PointF[]
        {
            new PointF(0.35f, 2.73951f),
            new PointF(0.41f, 2.30080f),
            new PointF(0.47f, 1.96864f),
            new PointF(0.51f, 1.78776f),
            new PointF(0.56f, 1.59502f),
            new PointF(0.64f, 1.34310f),
        };
        float[] xToInterpolate_TASK1 = new float[]
        {
            0.526f,
            0.482f,
            0.436f,
            0.453f,
            0.552f,
            0.640f,
        };
        float[] yToFind_TASK1 = null;
        PointF[] PRIMARY_POINTS_TASK2 = new PointF[10];
        float[] xToInterpolate_TASK2 = new float[]
        {
            1.011f,
            1.174f,
            1.284f,
            1.331f,
            1.480f,
            1.521f,
            1.669f,
            1.747f,
            1.848f,
        };
        float[] yToFind_TASK2 = null;

        public Graph()
        {
            InitializeComponent();
            blackPen.Width = 2;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void drawLine(Pen pen, float x1, float y1, float x2, float y2)
        {
            PointF[] points =
            {
                new PointF(x1, y1),
                new PointF(x2, y2)
            };
            g.DrawLines(pen, points);
        }
        private void connectPoints(Pen pen, PointF[] points, bool connectLastToFirst = false)
        {
            PointF bufPoint1, bufPoint2;
            for (int i = 0; i < points.Length - (connectLastToFirst ? 0 : 1); i++)
            {
                bufPoint1 = points[i];
                bufPoint2 = points[(i + 1) % points.Length];
                drawLine(pen, bufPoint1.X, bufPoint1.Y, bufPoint2.X, bufPoint2.Y);
            }
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            g = graph_canvas.CreateGraphics();
            x_max = graph_canvas.Width;
            y_max = graph_canvas.Height;

            graphSurf1 = new GraphSurface(
                g, blackPen, new Pen(Color.Black, 5), grayPen, new PointF(x_max, y_max));
            graphSurf2 = new GraphSurface(
                g, blackPen, new Pen(Color.Black, 5), grayPen, new PointF(x_max, y_max));
        }

        private void doTask()
        {
            graph_canvas.Refresh();
            tablePanel1.Refresh();
            tablePanel2.Refresh();

            x_max = graph_canvas.Width;
            y_max = graph_canvas.Height;

            corners[0] = new PointF(3, 3);
            corners[1] = new PointF(x_max - 3, 3);
            corners[2] = new PointF(x_max - 3, y_max - 3);
            corners[3] = new PointF(3, y_max - 3);

            connectPoints(new Pen(Color.DarkCyan, 2), corners, true);
        }

        private void button1_Click(object sender, EventArgs e)
        { /* ЗАДАНИЕ №1 */

            table1 = new Table(tablePanel1.CreateGraphics(), 2, PRIMARY_POINTS_TASK1.Length + 1,
                tablePanel1.Height, tablePanel1.Width);
            table1.values[0, 0] = "x";
            table1.values[1, 0] = "f(x)";
            for (int i = 0; i < PRIMARY_POINTS_TASK1.Length; i++)
            {
                table1.values[0, i + 1] = String.Format("{0:0.00}", PRIMARY_POINTS_TASK1[i].X);
                table1.values[1, i + 1] = String.Format("{0:0.00}", PRIMARY_POINTS_TASK1[i].Y);
            }

            table2 = new Table(tablePanel2.CreateGraphics(), 2, PRIMARY_POINTS_TASK1.Length + 1,
                tablePanel2.Height, tablePanel1.Width + 1);

            PointF bufferP;
            for (int i = 0; i < PRIMARY_POINTS_TASK1.Length; i++)
                graphSurf1.addPoint(PRIMARY_POINTS_TASK1[i]);

            table1.drawTable();

            doTask();

            g.DrawCurve(blackPen, graphSurf1.GetPointsToConnect());

            table1.drawTable();

            yToFind_TASK1 = new float[xToInterpolate_TASK1.Length];
            for (int i = 0; i < xToInterpolate_TASK1.Length; i++)
                yToFind_TASK1[i] = Lagrange.Interpolate(xToInterpolate_TASK1[i], PRIMARY_POINTS_TASK1);
            PointF[] foundPoints = new PointF[xToInterpolate_TASK1.Length];
            for (int i = 0; i < foundPoints.Length; i++)
                foundPoints[i] = new PointF(xToInterpolate_TASK1[i], yToFind_TASK1[i]);

            table2.values[0, 0] = "x";
            table2.values[1, 0] = "f(x)";
            for (int i = 0; i < foundPoints.Length; i++)
            {
                table2.values[0, i + 1] = String.Format("{0:0.00}", foundPoints[i].X);
                table2.values[1, i + 1] = String.Format("{0:0.00}", foundPoints[i].Y);
            }
            table2.drawTable();
            graphSurf1.drawPoints(foundPoints, true);
        }

        private void button2_Click(object sender, EventArgs e)
        { /* ЗАДАНИЕ №2 */
            for (int i = 0; i < PRIMARY_POINTS_TASK2.Length; i++)
            {
                PRIMARY_POINTS_TASK2[i].X = 1.0f + 0.1f * i;
                PRIMARY_POINTS_TASK2[i].Y = (float)Math.Exp(PRIMARY_POINTS_TASK2[i].X);
            }
            table1 = new Table(tablePanel1.CreateGraphics(), 2, PRIMARY_POINTS_TASK2.Length + 1, 
                tablePanel1.Height, tablePanel1.Width);
            table1.values[0, 0] = "x";
            table1.values[1, 0] = "f(x)";

            for (int i = 0; i < PRIMARY_POINTS_TASK2.Length; i++)
            {
                table1.values[0, i + 1] = String.Format("{0:0.00}", PRIMARY_POINTS_TASK2[i].X);
                table1.values[1, i + 1] = String.Format("{0:0.00}", PRIMARY_POINTS_TASK2[i].Y);
            }

            table2 = new Table(tablePanel2.CreateGraphics(), 2, xToInterpolate_TASK2.Length + 1,
                tablePanel2.Height, tablePanel2.Width + 1);

            PointF bufferP;
            for (int i = 0; i < PRIMARY_POINTS_TASK2.Length; i++)
                graphSurf2.addPoint(PRIMARY_POINTS_TASK2[i]);

            doTask();

            table1.drawTable();

            g.DrawCurve(blackPen, graphSurf2.GetPointsToConnect());


            yToFind_TASK2 = new float[xToInterpolate_TASK2.Length];
            for (int i = 0; i < xToInterpolate_TASK2.Length; i++)
                yToFind_TASK2[i] = Lagrange.Interpolate(xToInterpolate_TASK2[i], PRIMARY_POINTS_TASK2);
            PointF[] foundPoints = new PointF[xToInterpolate_TASK2.Length];
            for (int i = 0; i < foundPoints.Length; i++)
                foundPoints[i] = new PointF(xToInterpolate_TASK2[i], yToFind_TASK2[i]);

            for (int i = 0; i < foundPoints.Length; i++)
                Console.WriteLine(foundPoints[i].ToString());

            table2.values[0, 0] = "x";
            table2.values[1, 0] = "f(x)";
            for (int i = 0; i < foundPoints.Length; i++)
            {
                table2.values[0, i + 1] = String.Format("{0:0.00}", foundPoints[i].X);
                table2.values[1, i + 1] = String.Format("{0:0.00}", foundPoints[i].Y);
            }
            table2.drawTable();
            graphSurf2.drawPoints(foundPoints, true);
        }
    }

    class GraphSurface
    {
        float xMax, xMin, yMax, yMin;
        float width, height;
        float xCenter, yCenter;
        Graphics g;
        Pen linePen, pointPen, borderPen;
        PointF canvasSize;
        List<PointF> allPoints = new List<PointF>();
        Font fontArial = new Font("Arial", 8);
        SolidBrush brushBlack = new SolidBrush(Color.Black);
        public GraphSurface(Graphics g, Pen linePen, Pen pointPen, 
            Pen borderPen, PointF canvasSize)
        {
            this.g = g;
            this.linePen = linePen;
            this.pointPen = pointPen;
            this.borderPen = borderPen;
            this.canvasSize = canvasSize;
        }
        private void update()
        {
            xMax = 0; xMin = 0; yMax = 0; yMin = 0;
            foreach (PointF point in allPoints)
            {
                if (point.X > xMax) xMax = point.X;
                if (point.X < xMin) xMin = point.X;
                if (point.Y > yMax) yMax = point.Y;
                if (point.Y < yMin) yMin = point.Y;
            }
            xMax++; xMin--; yMax++; yMin--;
            if (xMax < 1) xMax = 1;
            if (xMin > -1) xMin = -1;
            if (yMax < 1) yMax = 1;
            if (yMin > -1) yMin = -1;
            allPoints = allPoints.OrderBy(o => o.X).ToList();
            width = xMax - xMin;
            height = yMax - yMin;
            xCenter = (xMax + xMin) / 2;
            yCenter = (yMax + yMin) / 2;
            drawAxes();
        }
        public void addPoint(PointF anotherPoint)
        {
            foreach (PointF point in allPoints)
                if (point.Equals(anotherPoint))
                    return;
            allPoints.Add(anotherPoint);
        }
        public PointF[] GetPointsToConnect()
        {
            update();
            return transformPointsToCanvas(allPoints.ToArray());
        }
        public PointF[] transformPointsToCanvas(PointF[] points)
        {
            update();
            PointF[] transformedPoints = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
                transformedPoints[i] = transformPointToCanvas(points[i]);
            return transformedPoints;
        }
        public PointF transformPointToCanvas(PointF point)
        {
            return new PointF(
                    ((point.X - xCenter) / width + 0.5f) * canvasSize.X,
                    (1 - ((point.Y - yCenter) / height + 0.5f)) * canvasSize.Y);
        }
        private void connectPointsOnCanvas(Pen pen, PointF[] points, bool connectLastToFirst = false)
        {
            PointF bufPoint1, bufPoint2;
            for (int i = 0; i < points.Length - (connectLastToFirst ? 0 : 1); i++)
            {
                bufPoint1 = transformPointToCanvas(points[i]);
                bufPoint2 = transformPointToCanvas(points[(i + 1) % points.Length]);
                g.DrawLine(pen, bufPoint1.X, bufPoint1.Y, bufPoint2.X, bufPoint2.Y);
            }
        }
        private void drawNumbers(List<PointF[]> oXDashes, List<PointF[]> oYDashes)
        {
            PointF temp;
            for (int i = 0; i < oXDashes.Count; i++)
            {
                temp = oXDashes[i][0];
                if (temp.X != 0)
                    g.DrawString(temp.X.ToString(), fontArial, brushBlack,
                        transformPointToCanvas(temp).X - 4, 
                        transformPointToCanvas(temp).Y + 3);
            }
            for (int i = 0; i < oYDashes.Count; i++)
            {
                temp = oYDashes[i][0];
                if (temp.Y != 0)
                    g.DrawString(temp.Y.ToString(), fontArial, brushBlack,
                        transformPointToCanvas(temp).X - 15, 
                        transformPointToCanvas(temp).Y - 6);
            }
        }
        private void circlePoints(PointF[] points, Pen tempPen = null)
        {
            for (int i = 0; i < points.Length; i++) 
            {
                g.DrawLine(tempPen == null ? pointPen : tempPen, 
                    transformPointToCanvas(points[i]).X - 2, 
                    transformPointToCanvas(points[i]).Y,
                    transformPointToCanvas(points[i]).X + 2, 
                    transformPointToCanvas(points[i]).Y + 2);
                g.DrawEllipse(tempPen == null ? pointPen : tempPen, new RectangleF(
                    transformPointToCanvas(points[i]).X, 
                    transformPointToCanvas(points[i]).Y, 0.8f, 0.8f));
            }
        }
        public void drawPoints(PointF[] points, bool drawRed = false)
        {
            circlePoints(points, new Pen(drawRed ? Color.Red : pointPen.Color, 5));
        }
        public void drawAxes()
        {
            PointF[] oXLine = new PointF[]
            {
                new PointF(xMin + 0.05f, 0),
                new PointF(xMax - 0.05f, 0),
            };
            PointF[] oYLine = new PointF[]
            {
                new PointF(0, yMin + 0.05f),
                new PointF(0, yMax - 0.05f),
            };
            List<PointF[]> oXDashes = new List<PointF[]>();
            List<PointF[]> oYDashes = new List<PointF[]>();
            for (int i = (int)Math.Ceiling(xMin) + 1; i <= (int)Math.Floor(xMax); i++)
                oXDashes.Add(new PointF[2] { 
                    new PointF(i, -0.008f * (yMax - yMin)),
                    new PointF(i, 0.008f * (yMax - yMin))});
            for (int i = (int)Math.Ceiling(yMin) + 1; i <= (int)Math.Floor(yMax); i++)
                oYDashes.Add(new PointF[2] { 
                    new PointF(-0.01f * (xMax - xMin), i),
                    new PointF(0.01f * (xMax - xMin), i) });
            foreach (PointF[] dash in oXDashes)
                connectPointsOnCanvas(borderPen, dash);
            foreach (PointF[] dash in oYDashes)
                connectPointsOnCanvas(borderPen, dash);
            drawNumbers(oXDashes, oYDashes);
            connectPointsOnCanvas(borderPen, oXLine);
            connectPointsOnCanvas(borderPen, oYLine);
            circlePoints(allPoints.ToArray());
        }
    }

    class Table
    {
        Graphics g;
        Font fontArial = new Font("Arial", 7);
        SolidBrush brushBlack = new SolidBrush(Color.Black);
        Pen grayPen = new Pen(Color.DarkGray);
        Pen blackPen = new Pen(Color.Black);
        int rows, columns, height, width;
        public String[,] values;
        public Table(Graphics g, int rows, int columns, int height, int width)
        {
            this.g = g;
            this.rows = rows;
            this.columns = columns;
            this.height = height;
            this.width = width;
            values = new String[rows, columns];
        }
        public void drawTable()
        {
            drawBorders();
            fillText();
        }
        private void fillText()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    g.DrawString(values[i, j], fontArial, brushBlack,
                        (float)width / columns * j, (float)height / rows * i + 7);
                }
            }
        }
        private void drawBorders()
        {
            for (int i = 1; i < rows; i++)
            {
                g.DrawLine(grayPen, 
                    new PointF(0, (float)height / rows * i), 
                    new PointF(width, (float)height / rows * i));
            }
            for (int i = 1; i < columns; i++)
            {
                g.DrawLine(grayPen,
                    new PointF((float)width / columns * i, 0),
                    new PointF((float)width / columns * i, height));
            }
        }

    }
    static class Lagrange
    {
        public static float Interpolate(float x, PointF[] points)
        {
            float result = 0;
            for (int i = 0; i < points.Length; i++)
            {
                float element = 1;
                for (int k = 0; k < points.Length; k++)
                {
                    if (k != i)
                    {
                        element *= (x - points[k].X) / (points[i].X - points[k].X);
                    }
                }
                result += points[i].Y * element;
            }
            return result;
        }
    }

}


