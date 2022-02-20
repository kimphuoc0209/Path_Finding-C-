using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Path_Finding
{
    class Pnt
    {
        public int x, y;
    }


    class PPnt
    {
        public int x, y, p, q;
        // Sử dụng trong A *
        // q là quãng đường đã đi từ đỉnh xuất phát đến đỉnh đang xét (trong code nó bằng q đỉnh cha + 1)
        // p = q + độ dài ước lượng từ đỉnh xét đến đích (tổng độ dài ước lượng), p ngắn nhất được xét trước
        // Cái độ dài ước lượng đến đích đó trong A* được gọi là chỉ số Heuristic
    }
}
