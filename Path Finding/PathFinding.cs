using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Path_Finding
{
    public partial class PathFinding : Form
    {
        private const int Width = 24, Height = 18, Size = 25;
        private static int WIDTH, HEIGHT;

        private static Bitmap bmpBG, bmp;
        private static Graphics g, G, G2;
        private static Brush br = new SolidBrush(Color.FromArgb(64, 64, 64));
        private static Pen p = new Pen(br, 1);
        private static Rectangle rect = new Rectangle() { Width = Size - 1, Height = Size - 1 };
        private static int[,] Map = new int[Height + 2, Width + 2];
        private static List<Pnt> ListPnt = new List<Pnt>();
        private static int tmpX, tmpY, tmpInt;
        private static int Draw = 1, Type = 0, Algorithm = 0, cnt;
        private static Pnt pFinding = new Pnt();
        private static bool hasStart, hasDest, tmpBool, isFinding;
        private static Pnt pStart = new Pnt(), pDest = new Pnt();
        private static Action[] Action_Algorithm = new Action[5];
        private static Pnt[] Drts = new Pnt[] { new Pnt() { x = 0, y = -1 }, new Pnt() { x = 1, y = 0 }, new Pnt() { x = 0, y = 1 }, new Pnt() { x = -1, y = 0 } };
        private static bool[,] Mark = new bool[Height + 2, Width + 2];
        private static int[,] Mark2 = new int[Height + 2, Width + 2];
        private static List<Pnt> ListPath = new List<Pnt>(), ListAnim = new List<Pnt>(), ListPath2 = new List<Pnt>();
        private static Pnt tmpP, tmpP2;
        private static Queue<Pnt> qList = new Queue<Pnt>();
        private static Pnt[,] MapAlgorithm = new Pnt[Height + 2, Width + 2];
        private static List<PPnt> ListPPnt = new List<PPnt>();
        private static PPnt tmpPP, tmpPP2;

        public PathFinding()
        {
            InitializeComponent();
            importDialog.Filter = "Map files (*.Dat)|*.dat";
            exportDialog.Filter = "Map files (*.Dat)|*.dat";
            rDrawWall.Checked = true;
            rDFS.Checked = true;
            rOnlyResult.Checked = true;
            for (int i = 0; i < Height + 2; i++)
            {
                for (int j = 0; j < Width + 2; j++) MapAlgorithm[i, j] = new Pnt();
            }
            for (int i = 0; i < Width + 2; i++)
            {
                Map[0, i] = 1;
                Map[Height + 1, i] = 1;
            }
            for (int i = 1; i < Height + 1; i++)
            {
                Map[i, 0] = 1;
                Map[i, Width + 1] = 1;
            }
            Action_Algorithm[0] = Algorithm_DFS;
            Action_Algorithm[1] = Algorithm_BFS;
            Action_Algorithm[2] = Algorithm_AStar;
            WIDTH = Width * Size;
            HEIGHT = Height * Size;
            bmpBG = new Bitmap(WIDTH + 1, HEIGHT + 1);
            G = Graphics.FromImage(bmpBG);
            for (int i = 0; i < Height + 1; i++) G.DrawLine(p, 0, i * Size, WIDTH, i * Size);
            for (int i = 0; i < Width + 1; i++) G.DrawLine(p, i * Size, 0, i * Size, HEIGHT);
            Table.Image = bmpBG;
        }

        private void Table_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            if (Type != 0) foreach (Pnt p in ListPath2)
                {
                    rect.X = Size * (p.x - 1) + 1;
                    rect.Y = Size * (p.y - 1) + 1;
                    g.FillRectangle(Brushes.Cyan, rect);
                }
            if (isFinding)
            {
                rect.X = Size * (pFinding.x - 1) + 1;
                rect.Y = Size * (pFinding.y - 1) + 1;
                g.FillRectangle(Brushes.Blue, rect);
            }
            else
            {
                foreach (Pnt p in ListPath)
                {
                    rect.X = Size * (p.x - 1) + 1;
                    rect.Y = Size * (p.y - 1) + 1;
                    g.FillRectangle(Brushes.Gold, rect);
                }
            }
            foreach (Pnt p in ListPnt)
            {
                rect.X = Size * (p.x - 1) + 1;
                rect.Y = Size * (p.y - 1) + 1;
                g.FillRectangle(Brushes.Black, rect);
            }
            if (hasStart)
            {
                rect.X = Size * (pStart.x - 1) + 1;
                rect.Y = Size * (pStart.y - 1) + 1;
                g.FillRectangle(Brushes.Red, rect);
            }
            if (hasDest)
            {
                rect.X = Size * (pDest.x - 1) + 1;
                rect.Y = Size * (pDest.y - 1) + 1;
                g.FillRectangle(Brushes.Green, rect);
            }
        }

        private void Clear()
        {
            if (Map[tmpY, tmpX] == 0) { }
            else if (Map[tmpY, tmpX] == 1) ListPnt.RemoveAt(IndexOf(tmpX, tmpY));
            else if (Map[tmpY, tmpX] == 2) hasStart = false;
            else if (Map[tmpY, tmpX] == 3) hasDest = false;
            Map[tmpY, tmpX] = 0;
        }

        private void DrawWall()
        {
            if (Map[tmpY, tmpX] == 0)
            {
                ListPnt.Add(new Pnt() { x = tmpX, y = tmpY });
                Map[tmpY, tmpX] = 1;
            }
            else if (Map[tmpY, tmpX] == 2)
            {
                hasStart = false;
                ListPnt.Add(new Pnt() { x = tmpX, y = tmpY });
                Map[tmpY, tmpX] = 1;
            }
            else if (Map[tmpY, tmpX] == 3)
            {
                hasDest = false;
                ListPnt.Add(new Pnt() { x = tmpX, y = tmpY });
                Map[tmpY, tmpX] = 1;
            }

        }

        private void DrawStart()
        {
            if (hasStart) Map[pStart.y, pStart.x] = 0;
            if (Map[tmpY, tmpX] == 0) { }
            else if (Map[tmpY, tmpX] == 1)
            {
                ListPnt.RemoveAt(IndexOf(tmpX, tmpY));
            }
            else if (Map[tmpY, tmpX] == 3)
            {
                hasDest = false;
            }
            pStart.x = tmpX;
            pStart.y = tmpY;
            hasStart = true;
            Map[tmpY, tmpX] = 2;
        }

        private void DrawDest()
        {
            if (hasDest) Map[pDest.y, pDest.x] = 0;
            if (Map[tmpY, tmpX] == 0) { }
            else if (Map[tmpY, tmpX] == 1)
            {
                ListPnt.RemoveAt(IndexOf(tmpX, tmpY));
            }
            else if (Map[tmpY, tmpX] == 2)
            {
                hasStart = false;
            }
            pDest.x = tmpX;
            pDest.y = tmpY;
            hasDest = true;
            Map[tmpY, tmpX] = 3;
        }

        private void Table_MouseClick(object sender, MouseEventArgs e)
        {
            tmpX = e.X / Size + 1;
            tmpY = e.Y / Size + 1;
            switch (Draw)
            {
                case 0: Clear(); break;
                case 1: DrawWall(); break;
                case 2: DrawStart(); break;
                case 3: DrawDest(); break;
            }
            Table.Invalidate();
        }

        private void Table_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tmpX = e.X / Size + 1;
                tmpY = e.Y / Size + 1;
                if (Draw == 0) Clear();
                else if (Draw == 1) DrawWall();
                Table.Invalidate();
            }
        }

        private static int IndexOf(int x, int y)
        {
            for (int i = 0; i < ListPnt.Count; i++)
            {
                if (ListPnt[i].x == x & ListPnt[i].y == y) return i;
            }
            return -1;
        }

        private void rClear_CheckedChanged(object sender, EventArgs e) { Draw = 0; }
        private void rDrawWall_CheckedChanged(object sender, EventArgs e) { Draw = 1; }
        private void rDrawStart_CheckedChanged(object sender, EventArgs e) { Draw = 2; }
        private void rDrawDest_CheckedChanged(object sender, EventArgs e) { Draw = 3; }
        private void rDFS_CheckedChanged(object sender, EventArgs e) { Algorithm = 0; }
        private void rBFS_CheckedChanged(object sender, EventArgs e) { Algorithm = 1; }
        private void rAStar_CheckedChanged(object sender, EventArgs e) { Algorithm = 2; }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (hasStart && hasDest)
            {
                ListPath.Clear();
                ListPath2.Clear();
                ListAnim.Clear();
                Action_Algorithm[Algorithm]();
                lbStepsNum.Text = ListAnim.Count.ToString();
                switch (Type)
                {
                    case 0:
                    case 1: for (int i = 0; i < ListAnim.Count; i++) ListPath2.Add(ListAnim[i]);
                        Table.Invalidate(); break;
                    case 2: 
                        Table.MouseClick -= Table_MouseClick;
                        Table.MouseMove -= Table_MouseMove;
                        isFinding = true; cnt = 0; tAnimation.Enabled = true;
                        groupBoxAlgorithm.Enabled = groupBoxDraw.Enabled = groupBoxType.Enabled = false;
                        btnClear.Enabled = btnFind.Enabled= false; break;
                }
            }
            else MessageBox.Show("Need Start And Dest!", "Error!");
        }

        private void Algorithm_DFS()
        {
            for (int i = 1; i < Height + 1; i++)
            {
                for (int j = 1; j < Width + 1; j++)
                {
                    Mark[i, j] = false;
                }
            }
            MapAlgorithm[pStart.y, pStart.x].x = MapAlgorithm[pStart.y, pStart.x].y = -1;
            if (!DFS(pStart.x, pStart.y)) MessageBox.Show("Can't Find Path!", "Error!");
        }

        private bool DFS(int x, int y)
        {
            Mark[y, x] = true;
            ListAnim.Add(new Pnt() { x = x, y = y });
            for (int i = 0; i < 4; i++)
            {
                tmpY = y + Drts[i].y;
                tmpX = x + Drts[i].x;
                if (Map[tmpY, tmpX] != 1 && !Mark[tmpY, tmpX])
                {
                    MapAlgorithm[tmpY, tmpX].x = x;
                    MapAlgorithm[tmpY, tmpX].y = y;
                    if (Map[tmpY, tmpX] == 3)
                    {
                        while (MapAlgorithm[tmpY, tmpX].x != -1)
                        {
                            tmpP = new Pnt() { x = tmpX, y = tmpY };
                            ListPath.Add(tmpP);
                            tmpInt = tmpX;
                            tmpX = MapAlgorithm[tmpY, tmpInt].x;
                            tmpY = MapAlgorithm[tmpY, tmpInt].y;
                        }
                        return true;
                    }
                    else
                    {
                        tmpBool = DFS(tmpX, tmpY);
                        if (tmpBool) return true;
                    }
                }
            }
            return false;
        }

        private void Algorithm_BFS()
        {
            for (int i = 1; i < Height + 1; i++)
            {
                for (int j = 1; j < Width + 1; j++) Mark[i, j] = false;
            }
            if (!BFS(pStart.x, pStart.y))
                MessageBox.Show("Can't Find Path!", "Error!");
        }

        private bool BFS(int x, int y)
        {
            Mark[y, x] = true;
            MapAlgorithm[y, x].x = MapAlgorithm[y, x].y = -1;
            tmpP = new Pnt() { x = x, y = y };
            qList.Enqueue(tmpP);
            while (qList.Count != 0)
            {
                tmpP = qList.Dequeue();
                ListAnim.Add(tmpP);
                for (int i = 0; i < 4; i++)
                {
                    tmpY = tmpP.y + Drts[i].y;
                    tmpX = tmpP.x + Drts[i].x;
                    if (Map[tmpY, tmpX] != 1 && !Mark[tmpY, tmpX])
                    {
                        MapAlgorithm[tmpY, tmpX].x = tmpP.x;
                        MapAlgorithm[tmpY, tmpX].y = tmpP.y;
                        if (Map[tmpY, tmpX] == 3)
                        {
                            while (MapAlgorithm[tmpY, tmpX].x != -1)
                            {
                                tmpP = new Pnt() { x = tmpX, y = tmpY };
                                ListPath.Add(tmpP);
                                tmpInt = tmpX;
                                tmpX = MapAlgorithm[tmpY, tmpInt].x;
                                tmpY = MapAlgorithm[tmpY, tmpInt].y;
                            }
                            qList.Clear();
                            return true;
                        }
                        tmpP2 = new Pnt() { x = tmpX, y = tmpY };
                        Mark[tmpY, tmpX] = true;
                        qList.Enqueue(tmpP2);
                    }
                }
            }
            return false;
        }


        private static int Abs(int x) { return x < 0 ? -x : x; }
        private static int Priority(Pnt p)
        {
            return Abs(p.x - pDest.x) + Abs(p.y - pDest.y);
        }

        

        private void Algorithm_AStar()
        {
            for (int i = 1; i < Height + 1; i++)
            {
                for (int j = 1; j < Width + 1; j++)
                    Mark[i, j] = false;
            }
            if (!AStar())
                MessageBox.Show("Can't Find Path!", "Error!");
        }

        private int GetMinListPPnt()
        {
            int cmin = 0;
            for (int i = 1; i < ListPPnt.Count; i++)
                if (ListPPnt[i].p < ListPPnt[cmin].p)
                    cmin = i;
            return cmin;
        }

        private bool AStar()
        {
            tmpPP = new PPnt() { x = pStart.x, y = pStart.y, p = 0, q = 0 };
            // --> Xem qua Class PPnt
            Mark[tmpPP.y, tmpPP.x] = true;
            MapAlgorithm[tmpPP.y, tmpPP.x].x = MapAlgorithm[tmpPP.y, tmpPP.x].y = -1;
            ListPPnt.Add(tmpPP);
            while (ListPPnt.Count != 0)
            {
                tmpInt = GetMinListPPnt();
                tmpPP = ListPPnt[tmpInt];
                ListAnim.Add(new Pnt() { x = tmpPP.x, y = tmpPP.y });
                ListPPnt.RemoveAt(tmpInt);
                for (int i = 0; i < 4; i++)
                {
                    tmpY = tmpPP.y + Drts[i].y;
                    tmpX = tmpPP.x + Drts[i].x;
                    if (Map[tmpY, tmpX] != 1 && !Mark[tmpY, tmpX])
                    {
                        Mark[tmpY, tmpX] = true;
                        MapAlgorithm[tmpY, tmpX].x = tmpPP.x;
                        MapAlgorithm[tmpY, tmpX].y = tmpPP.y;
                        tmpPP2 = new PPnt() { x = tmpX, y = tmpY, p = Abs(tmpX - pDest.x) + Abs(tmpY - pDest.y) + tmpPP.q, q = tmpPP.q + 1 };
                        ListPPnt.Add(tmpPP2);
                        if (Map[tmpY, tmpX] == 3)
                        {
                            while (MapAlgorithm[tmpY, tmpX].x != -1)
                            {
                                tmpP = new Pnt() { x = tmpX, y = tmpY };
                                ListPath.Add(tmpP);
                                tmpInt = tmpX;
                                tmpX = MapAlgorithm[tmpY, tmpInt].x;
                                tmpY = MapAlgorithm[tmpY, tmpInt].y;
                            }
                            ListPPnt.Clear();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < Height + 1; i++)
            {
                for (int j = 1; j < Width + 1; j++) Map[i, j] = 0;
            }
            hasStart = hasDest = false;
            ListPath.Clear();
            ListPath2.Clear();
            ListPnt.Clear();
            ListAnim.Clear();
            Table.Invalidate();
        }

        private void tAnimation_Tick(object sender, EventArgs e)
        {
            if (cnt < ListAnim.Count)
            {
                ListPath2.Add(ListAnim[cnt]);
                pFinding.x = ListAnim[cnt].x;
                pFinding.y = ListAnim[cnt].y;
                cnt++;
            }
            else
            {
                Stop();
            }
            Table.Invalidate();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            tAnimation.Interval = 130 - trackBar.Value * 20;
        }

        private void rOnlyResult_CheckedChanged(object sender, EventArgs e) { Type = 0; Table.Invalidate(); }
        private void rIncludeSteps_CheckedChanged(object sender, EventArgs e) { Type = 1; }
        private void rAnimation_CheckedChanged(object sender, EventArgs e) { Type = 2; }

        private void Stop()
        {
            Table.MouseClick += Table_MouseClick;
            Table.MouseMove += Table_MouseMove;
            groupBoxAlgorithm.Enabled = groupBoxDraw.Enabled = groupBoxType.Enabled = true;
            btnClear.Enabled = btnFind.Enabled  = true;
            isFinding = false;
            tAnimation.Enabled = false;
            Table.Invalidate();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isFinding)
            {
                for (int i = cnt; i < ListAnim.Count; i++)
                {
                    ListPath2.Add(ListAnim[i]);
                }
                Stop();
            }
        }

       

    }
}
