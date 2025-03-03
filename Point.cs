using System;
//1/ Xây dựng lớp Point.
public class Point
{
    // Thuộc tính x và y đại diện cho tọa độ của điểm trong hệ tọa độ Descartes 2 chiều
    public double x { get; set; }
    public double y { get; set; }

    // Hàm khởi tạo để tạo một điểm với tọa độ x và y
    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    // Phương thức ToString trả về chuỗi biểu diễn của điểm dưới dạng A(x, y)
    public override string ToString()
    {
        return $"A({x}, {y})";
    }

    // Phương thức Distance tính khoảng cách Euclidean giữa điểm hiện tại và điểm khác
    public double Distance(Point other)
    {
        return Math.Sqrt(Math.Pow(this.x - other.x, 2) + Math.Pow(this.y - other.y, 2));
    }
}
