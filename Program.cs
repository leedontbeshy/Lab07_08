/* Lab 07 - 08 (Lab 07 từ câu 01-05, Lab 08 từ câu 06-07).
    Một lớp Point trong hệ toạ độ Descartes 2 chiều gồm các
    thuộc tính: x, y. Một lớp Cluster chứa một list các Point.
    1/ Xây dựng lớp Point.
    2/ Bổ sung vào Point: ToString dạng A(x, y), distance
     - tính khoảng cách giữa 2 điểm theo Euclidean.
    3/ Bổ sung vào lớp Cluster: ToString dạng {A(x, y), B(x, y), C(x, y)}
    4/ Bổ sung phương thức distance cho Cluster để tính
    khoảng cách giữa các cụm theo single linkage (theo
    khoảng cách nhỏ nhất giữa các cặp điểm của 2 cụm).
    5/ Bổ sung operator + để hợp 2 Cluster.
    6/ Cài đặt thuật toán hierarchical clustering để phân
     cụm (với single linkage).
        - public List<Cluster> HierarchicalClustering()
    7/ Triển khai kết quả trong hàm main.
*/

using System;
using System.Collections.Generic;

public class HierarchicalClustering
{
    public List<Cluster> Clusters { get; set; }

    public HierarchicalClustering(List<Point> points)
    {
        Clusters = new List<Cluster>();
        foreach (Point p in points)
        {
            Cluster cluster = new Cluster();
            cluster.Points.Add(p);
            Clusters.Add(cluster);
        }
    }

    // hierarchical clustering single linkage
    public List<Cluster> Run()
    {
        while (Clusters.Count > 1)
        {
            // tim cap cum co kc min
            int cluster1Index = 0;
            int cluster2Index = 1;
            double minDistance = Clusters[0].Distance(Clusters[1]);

            for (int i = 0; i < Clusters.Count; i++)
            {
                for (int j = i + 1; j < Clusters.Count; j++)
                {
                    double distance = Clusters[i].Distance(Clusters[j]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        cluster1Index = i;
                        cluster2Index = j;
                    }
                }
            }

            // hop
            Cluster newCluster = Clusters[cluster1Index] + Clusters[cluster2Index];
            Clusters.RemoveAt(cluster2Index);
            Clusters.RemoveAt(cluster1Index);
            Clusters.Add(newCluster);
        }

        return Clusters;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        
        List<Point> points = new List<Point>
        {
            new Point(1, 2),
            new Point(2, 3),
            new Point(3, 4),
            new Point(10, 11),
            new Point(11, 12)
        };

        
        HierarchicalClustering hc = new HierarchicalClustering(points);

        Console.WriteLine("Các cụm ban đầu:");
        foreach (Cluster cluster in hc.Clusters)
        {
            Console.WriteLine(cluster.ToString());
        }

        
        Console.WriteLine("\nKhoảng cách giữa các cụm ban đầu:");
        for (int i = 0; i < hc.Clusters.Count; i++)
        {
            for (int j = i + 1; j < hc.Clusters.Count; j++)
            {
                Console.WriteLine($"Khoảng cách giữa cụm {i + 1} và cụm {j + 1}: {hc.Clusters[i].Distance(hc.Clusters[j])}");
            }
        }

        
        List<Cluster> result = hc.Run();

        
        Console.WriteLine("\nKết quả sau khi phân cụm:");
        foreach (Cluster cluster in result)
        {
            Console.WriteLine(cluster.ToString());
        }
    }
}