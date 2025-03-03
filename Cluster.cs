using System;
using System.Collections.Generic;

public class Cluster
{
    
    public List<Point> Points { get; set; }

    
    public Cluster()
    {
        Points = new List<Point>();
    }

    // Phương thức ToString trả về chuỗi biểu diễn của cụm dưới dạng {A(x, y), B(x, y), C(x, y)}
    public override string ToString()
    {
        return "{" + string.Join(", ", Points) + "}";
    }

    // phuong thuc distance tinh khoang cach giua cac cum theo single linkage 
    public double Distance(Cluster other)
    {
        double minDistance = double.MaxValue;
        for (int i = 0; i < Points.Count; i++)
        {
            for (int j = 0; j < other.Points.Count; j++)
            {
                double distance = Points[i].Distance(other.Points[j]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }
        }
        return minDistance;
    }

    // 5/ Bổ sung operator + để hợp 2 Cluster.
    public static Cluster operator +(Cluster a, Cluster b)
    {
        if (a == null) return b ?? new Cluster();
        if (b == null) return a;

        Cluster result = new Cluster();
        result.Points.AddRange(a.Points);
        result.Points.AddRange(b.Points);
        return result;
    }
}
