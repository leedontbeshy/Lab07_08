using System;
//1/ Xây dựng lớp Point.
public class Point
{
    // 
    public double x { get; set; }
    public double y { get; set; }

    // 
    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    // 
    public override string ToString()
    {
        return $"A({x}, {y})";
    }

    
    public double Distance(Point other)
    {
        return Math.Sqrt(Math.Pow(this.x - other.x, 2) + Math.Pow(this.y - other.y, 2));
    }
}
