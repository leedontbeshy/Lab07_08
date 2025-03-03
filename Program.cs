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

public class Program
{
    // 6/ Cài đặt thuật toán hierarchical clustering để phâncụm (với single linkage).- public List<Cluster> HierarchicalClustering()
    public static List<Cluster> HierarchicalClustering(List<Cluster> clusters)
    {
        if (clusters == null || clusters.Count == 0) return new List<Cluster>();

        while (clusters.Count > 1)
        {

            double minDistance = double.MaxValue;
            int clusterA = 0;
            int clusterB = 1;

            // tim 2 cum co khoang cach nho nhat
            for (int i = 0; i < clusters.Count; i++)
            {
                for (int j = i + 1; j < clusters.Count; j++)
                {
                    double distance = clusters[i].Distance(clusters[j]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        clusterA = i;
                        clusterB = j;
                    }
                }
            }

            // hop nhat
            Cluster mergedCluster = clusters[clusterA] + clusters[clusterB];
            clusters.RemoveAt(clusterB);
            clusters.RemoveAt(clusterA);
            clusters.Add(mergedCluster);
        }

        return clusters;
    }

    // Hàm Main để triển khai kết quả
    public static void Main(string[] args)
    {
        Point p1 = new Point(1, 2);
        Point p2 = new Point(3, 4);
        Point p3 = new Point(5, 6);
        Point p4 = new Point(7, 8);

        Cluster c1 = new Cluster();
        c1.Points.Add(p1);
        c1.Points.Add(p2);

        Cluster c2 = new Cluster();
        c2.Points.Add(p3);
        c2.Points.Add(p4);

        List<Cluster> clusters = new List<Cluster>();
        clusters.Add(c1);
        clusters.Add(c2);

        
        List<Cluster> result = HierarchicalClustering(clusters);

        
        foreach (Cluster cluster in result)
        {
            Console.WriteLine(cluster.ToString());
        }
    }
}

