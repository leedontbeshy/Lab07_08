public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }


    public override string ToString()
    {
        return $"A({X}, {Y})";
    }

    // kc 2 diem
    public double Distance(Point other)
    {
        return Math.Sqrt(Math.Pow(this.X - other.X, 2) + Math.Pow(this.Y - other.Y, 2));
    }
}