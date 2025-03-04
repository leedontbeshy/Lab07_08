public class Cluster
{
    public List<Point> Points { get; set; }

    public Cluster()
    {
        Points = new List<Point>();
    }

    
    public override string ToString()
    {
        string result = "{";
        for (int i = 0; i < Points.Count; i++)
        {
            result += Points[i].ToString();
            if (i < Points.Count - 1)
            {
                result += ", ";
            }
        }
        result += "}";
        return result;
    }

    // khoang cach
    public double Distance(Cluster other)
    {
        double minDistance = double.MaxValue;
        foreach (Point p1 in this.Points)
        {
            foreach (Point p2 in other.Points)
            {
                double distance = p1.Distance(p2);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }
        }
        return minDistance;
    }

    // hop 2 cum
    public static Cluster operator +(Cluster c1, Cluster c2)
    {
        Cluster result = new Cluster();
        foreach (Point p in c1.Points)
        {
            result.Points.Add(p);
        }
        foreach (Point p in c2.Points)
        {
            result.Points.Add(p);
        }
        return result;
    }
}