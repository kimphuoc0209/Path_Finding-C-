namespace Path_Finding
{
    partial class PathFinding
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Table = new System.Windows.Forms.PictureBox();
            this.groupBoxDraw = new System.Windows.Forms.GroupBox();
            this.rClear = new System.Windows.Forms.RadioButton();
            this.rDrawDest = new System.Windows.Forms.RadioButton();
            this.rDrawStart = new System.Windows.Forms.RadioButton();
            this.rDrawWall = new System.Windows.Forms.RadioButton();
            this.groupBoxAlgorithm = new System.Windows.Forms.GroupBox();
            this.rAStar = new System.Windows.Forms.RadioButton();
            this.rBFS = new System.Windows.Forms.RadioButton();
            this.rDFS = new System.Windows.Forms.RadioButton();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tAnimation = new System.Windows.Forms.Timer(this.components);
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.rAnimation = new System.Windows.Forms.RadioButton();
            this.rIncludeSteps = new System.Windows.Forms.RadioButton();
            this.rOnlyResult = new System.Windows.Forms.RadioButton();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.exportDialog = new System.Windows.Forms.SaveFileDialog();
            this.importDialog = new System.Windows.Forms.OpenFileDialog();
            this.lbSteps = new System.Windows.Forms.Label();
            this.lbStepsNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.groupBoxDraw.SuspendLayout();
            this.groupBoxAlgorithm.SuspendLayout();
            this.groupBoxType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.BackColor = System.Drawing.Color.White;
            this.Table.Location = new System.Drawing.Point(27, 30);
            this.Table.Margin = new System.Windows.Forms.Padding(4);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(801, 555);
            this.Table.TabIndex = 0;
            this.Table.TabStop = false;
            this.Table.Paint += new System.Windows.Forms.PaintEventHandler(this.Table_Paint);
            this.Table.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Table_MouseClick);
            this.Table.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Table_MouseMove);
            // 
            // groupBoxDraw
            // 
            this.groupBoxDraw.Controls.Add(this.rClear);
            this.groupBoxDraw.Controls.Add(this.rDrawDest);
            this.groupBoxDraw.Controls.Add(this.rDrawStart);
            this.groupBoxDraw.Controls.Add(this.rDrawWall);
            this.groupBoxDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDraw.Location = new System.Drawing.Point(843, 22);
            this.groupBoxDraw.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxDraw.Name = "groupBoxDraw";
            this.groupBoxDraw.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxDraw.Size = new System.Drawing.Size(176, 158);
            this.groupBoxDraw.TabIndex = 1;
            this.groupBoxDraw.TabStop = false;
            this.groupBoxDraw.Text = "Draw";
            // 
            // rClear
            // 
            this.rClear.AutoSize = true;
            this.rClear.Location = new System.Drawing.Point(21, 121);
            this.rClear.Margin = new System.Windows.Forms.Padding(4);
            this.rClear.Name = "rClear";
            this.rClear.Size = new System.Drawing.Size(70, 24);
            this.rClear.TabIndex = 3;
            this.rClear.Text = "Clear";
            this.rClear.UseVisualStyleBackColor = true;
            this.rClear.CheckedChanged += new System.EventHandler(this.rClear_CheckedChanged);
            // 
            // rDrawDest
            // 
            this.rDrawDest.AutoSize = true;
            this.rDrawDest.Location = new System.Drawing.Point(21, 89);
            this.rDrawDest.Margin = new System.Windows.Forms.Padding(4);
            this.rDrawDest.Name = "rDrawDest";
            this.rDrawDest.Size = new System.Drawing.Size(111, 24);
            this.rDrawDest.TabIndex = 2;
            this.rDrawDest.Text = "Draw Dest";
            this.rDrawDest.UseVisualStyleBackColor = true;
            this.rDrawDest.CheckedChanged += new System.EventHandler(this.rDrawDest_CheckedChanged);
            // 
            // rDrawStart
            // 
            this.rDrawStart.AutoSize = true;
            this.rDrawStart.Location = new System.Drawing.Point(21, 57);
            this.rDrawStart.Margin = new System.Windows.Forms.Padding(4);
            this.rDrawStart.Name = "rDrawStart";
            this.rDrawStart.Size = new System.Drawing.Size(111, 24);
            this.rDrawStart.TabIndex = 1;
            this.rDrawStart.Text = "Draw Start";
            this.rDrawStart.UseVisualStyleBackColor = true;
            this.rDrawStart.CheckedChanged += new System.EventHandler(this.rDrawStart_CheckedChanged);
            // 
            // rDrawWall
            // 
            this.rDrawWall.AutoSize = true;
            this.rDrawWall.Location = new System.Drawing.Point(21, 25);
            this.rDrawWall.Margin = new System.Windows.Forms.Padding(4);
            this.rDrawWall.Name = "rDrawWall";
            this.rDrawWall.Size = new System.Drawing.Size(108, 24);
            this.rDrawWall.TabIndex = 0;
            this.rDrawWall.Text = "Draw Wall";
            this.rDrawWall.UseVisualStyleBackColor = true;
            this.rDrawWall.CheckedChanged += new System.EventHandler(this.rDrawWall_CheckedChanged);
            // 
            // groupBoxAlgorithm
            // 
            this.groupBoxAlgorithm.Controls.Add(this.rAStar);
            this.groupBoxAlgorithm.Controls.Add(this.rBFS);
            this.groupBoxAlgorithm.Controls.Add(this.rDFS);
            this.groupBoxAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAlgorithm.Location = new System.Drawing.Point(843, 185);
            this.groupBoxAlgorithm.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxAlgorithm.Name = "groupBoxAlgorithm";
            this.groupBoxAlgorithm.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAlgorithm.Size = new System.Drawing.Size(176, 199);
            this.groupBoxAlgorithm.TabIndex = 2;
            this.groupBoxAlgorithm.TabStop = false;
            this.groupBoxAlgorithm.Text = "Algorithm";
            // 
            // rAStar
            // 
            this.rAStar.AutoSize = true;
            this.rAStar.Location = new System.Drawing.Point(21, 94);
            this.rAStar.Margin = new System.Windows.Forms.Padding(4);
            this.rAStar.Name = "rAStar";
            this.rAStar.Size = new System.Drawing.Size(52, 24);
            this.rAStar.TabIndex = 4;
            this.rAStar.Text = "A *";
            this.rAStar.UseVisualStyleBackColor = true;
            this.rAStar.CheckedChanged += new System.EventHandler(this.rAStar_CheckedChanged);
            // 
            // rBFS
            // 
            this.rBFS.AutoSize = true;
            this.rBFS.Location = new System.Drawing.Point(21, 62);
            this.rBFS.Margin = new System.Windows.Forms.Padding(4);
            this.rBFS.Name = "rBFS";
            this.rBFS.Size = new System.Drawing.Size(63, 24);
            this.rBFS.TabIndex = 1;
            this.rBFS.Text = "BFS";
            this.rBFS.UseVisualStyleBackColor = true;
            this.rBFS.CheckedChanged += new System.EventHandler(this.rBFS_CheckedChanged);
            // 
            // rDFS
            // 
            this.rDFS.AutoSize = true;
            this.rDFS.Location = new System.Drawing.Point(21, 30);
            this.rDFS.Margin = new System.Windows.Forms.Padding(4);
            this.rDFS.Name = "rDFS";
            this.rDFS.Size = new System.Drawing.Size(64, 24);
            this.rDFS.TabIndex = 0;
            this.rDFS.Text = "DFS";
            this.rDFS.UseVisualStyleBackColor = true;
            this.rDFS.CheckedChanged += new System.EventHandler(this.rDFS_CheckedChanged);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(1041, 50);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(83, 47);
            this.btnFind.TabIndex = 3;
            this.btnFind.TabStop = false;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(1041, 113);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 47);
            this.btnClear.TabIndex = 4;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tAnimation
            // 
            this.tAnimation.Interval = 110;
            this.tAnimation.Tick += new System.EventHandler(this.tAnimation_Tick);
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.rAnimation);
            this.groupBoxType.Controls.Add(this.rIncludeSteps);
            this.groupBoxType.Controls.Add(this.rOnlyResult);
            this.groupBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxType.Location = new System.Drawing.Point(843, 391);
            this.groupBoxType.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxType.Size = new System.Drawing.Size(176, 132);
            this.groupBoxType.TabIndex = 5;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Type";
            // 
            // rAnimation
            // 
            this.rAnimation.AutoSize = true;
            this.rAnimation.Location = new System.Drawing.Point(21, 94);
            this.rAnimation.Margin = new System.Windows.Forms.Padding(4);
            this.rAnimation.Name = "rAnimation";
            this.rAnimation.Size = new System.Drawing.Size(104, 24);
            this.rAnimation.TabIndex = 2;
            this.rAnimation.Text = "Animation";
            this.rAnimation.UseVisualStyleBackColor = true;
            this.rAnimation.CheckedChanged += new System.EventHandler(this.rAnimation_CheckedChanged);
            // 
            // rIncludeSteps
            // 
            this.rIncludeSteps.AutoSize = true;
            this.rIncludeSteps.Location = new System.Drawing.Point(21, 62);
            this.rIncludeSteps.Margin = new System.Windows.Forms.Padding(4);
            this.rIncludeSteps.Name = "rIncludeSteps";
            this.rIncludeSteps.Size = new System.Drawing.Size(131, 24);
            this.rIncludeSteps.TabIndex = 1;
            this.rIncludeSteps.Text = "Include Steps";
            this.rIncludeSteps.UseVisualStyleBackColor = true;
            this.rIncludeSteps.CheckedChanged += new System.EventHandler(this.rIncludeSteps_CheckedChanged);
            // 
            // rOnlyResult
            // 
            this.rOnlyResult.AutoSize = true;
            this.rOnlyResult.Location = new System.Drawing.Point(21, 30);
            this.rOnlyResult.Margin = new System.Windows.Forms.Padding(4);
            this.rOnlyResult.Name = "rOnlyResult";
            this.rOnlyResult.Size = new System.Drawing.Size(117, 24);
            this.rOnlyResult.TabIndex = 0;
            this.rOnlyResult.Text = "Only Result";
            this.rOnlyResult.UseVisualStyleBackColor = true;
            this.rOnlyResult.CheckedChanged += new System.EventHandler(this.rOnlyResult_CheckedChanged);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(843, 535);
            this.trackBar.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar.Maximum = 4;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(172, 56);
            this.trackBar.TabIndex = 0;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(1041, 185);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(83, 47);
            this.btnStop.TabIndex = 6;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // exportDialog
            // 
            this.exportDialog.FileName = "Map.Dat";
            // 
            // importDialog
            // 
            this.importDialog.FileName = "Map.Dat";
            // 
            // lbSteps
            // 
            this.lbSteps.AutoSize = true;
            this.lbSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSteps.Location = new System.Drawing.Point(1051, 428);
            this.lbSteps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSteps.Name = "lbSteps";
            this.lbSteps.Size = new System.Drawing.Size(57, 20);
            this.lbSteps.TabIndex = 10;
            this.lbSteps.Text = "Steps:";
            // 
            // lbStepsNum
            // 
            this.lbStepsNum.BackColor = System.Drawing.SystemColors.Window;
            this.lbStepsNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStepsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStepsNum.Location = new System.Drawing.Point(1048, 459);
            this.lbStepsNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStepsNum.Name = "lbStepsNum";
            this.lbStepsNum.Size = new System.Drawing.Size(62, 30);
            this.lbStepsNum.TabIndex = 11;
            this.lbStepsNum.Text = "0";
            this.lbStepsNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PathFinding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1141, 614);
            this.Controls.Add(this.lbStepsNum);
            this.Controls.Add(this.lbSteps);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.groupBoxAlgorithm);
            this.Controls.Add(this.groupBoxDraw);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.trackBar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PathFinding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Path Finding";
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.groupBoxDraw.ResumeLayout(false);
            this.groupBoxDraw.PerformLayout();
            this.groupBoxAlgorithm.ResumeLayout(false);
            this.groupBoxAlgorithm.PerformLayout();
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Table;
        private System.Windows.Forms.GroupBox groupBoxDraw;
        private System.Windows.Forms.RadioButton rDrawDest;
        private System.Windows.Forms.RadioButton rDrawStart;
        private System.Windows.Forms.RadioButton rDrawWall;
        private System.Windows.Forms.GroupBox groupBoxAlgorithm;
        private System.Windows.Forms.RadioButton rBFS;
        private System.Windows.Forms.RadioButton rDFS;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rClear;
        private System.Windows.Forms.Timer tAnimation;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.RadioButton rAnimation;
        private System.Windows.Forms.RadioButton rIncludeSteps;
        private System.Windows.Forms.RadioButton rOnlyResult;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.RadioButton rAStar;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.SaveFileDialog exportDialog;
        private System.Windows.Forms.OpenFileDialog importDialog;
        private System.Windows.Forms.Label lbSteps;
        private System.Windows.Forms.Label lbStepsNum;
    }
}

