using System;
using System.Drawing;
using System.Windows.Forms;

namespace DungeonMaster
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            Label label1;
            Label label2;
            button1 = new Button();
            textBox1 = new TextBox();
            dungeon = new RadioButton();
            city = new RadioButton();
            bar = new RadioButton();
            panel1 = new Panel();
            job = new Label();
            name = new Label();
            status = new Button();
            next = new Button();
            back = new Button();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ButtonFace;
            label1.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(19, 12);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 2, 0, 2);
            label1.Size = new Size(51, 23);
            label1.TabIndex = 0;
            label1.Text = "名前";
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ButtonFace;
            label2.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(224, 12);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 2, 0, 2);
            label2.Size = new Size(65, 23);
            label2.TabIndex = 0;
            label2.Text = "ジョブ";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(589, 349);
            button1.Name = "button1";
            button1.Size = new Size(120, 34);
            button1.TabIndex = 0;
            button1.Text = "決定";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(31, 98);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(365, 325);
            textBox1.TabIndex = 1;
            // 
            // dungeon
            // 
            dungeon.AutoSize = true;
            dungeon.Location = new Point(589, 259);
            dungeon.Name = "dungeon";
            dungeon.Size = new Size(99, 19);
            dungeon.TabIndex = 3;
            dungeon.TabStop = true;
            dungeon.Text = "ダンジョンに潜る";
            dungeon.UseVisualStyleBackColor = true;
            // 
            // city
            // 
            city.AutoSize = true;
            city.Location = new Point(589, 284);
            city.Name = "city";
            city.Size = new Size(109, 19);
            city.TabIndex = 3;
            city.TabStop = true;
            city.Text = "街で買い物をする";
            city.UseVisualStyleBackColor = true;
            // 
            // bar
            // 
            bar.AutoSize = true;
            bar.Location = new Point(589, 309);
            bar.Name = "bar";
            bar.Size = new Size(107, 19);
            bar.TabIndex = 3;
            bar.TabStop = true;
            bar.Text = "酒場で情報収集";
            bar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(job);
            panel1.Controls.Add(name);
            panel1.Controls.Add(status);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(31, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(725, 54);
            panel1.TabIndex = 4;
            // 
            // job
            // 
            job.BackColor = SystemColors.Control;
            job.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            job.Location = new Point(295, 12);
            job.Name = "job";
            job.Size = new Size(142, 23);
            job.TabIndex = 2;
            // 
            // name
            // 
            name.BackColor = SystemColors.Control;
            name.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            name.Location = new Point(76, 12);
            name.Name = "name";
            name.Size = new Size(142, 23);
            name.TabIndex = 2;
            // 
            // status
            // 
            status.Location = new Point(461, 10);
            status.Name = "status";
            status.Size = new Size(137, 25);
            status.TabIndex = 1;
            status.Text = "ステータス表示";
            status.UseVisualStyleBackColor = true;
            status.Click += status_Click;
            // 
            // next
            // 
            next.Location = new Point(422, 338);
            next.Name = "next";
            next.Size = new Size(78, 31);
            next.TabIndex = 5;
            next.Text = "進む";
            next.UseVisualStyleBackColor = true;
            next.Click += next_Click_1;
            // 
            // back
            // 
            back.Location = new Point(422, 375);
            back.Name = "back";
            back.Size = new Size(78, 31);
            back.TabIndex = 5;
            back.Text = "撤退";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(back);
            Controls.Add(next);
            Controls.Add(panel1);
            Controls.Add(bar);
            Controls.Add(city);
            Controls.Add(dungeon);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button button1;
        public TextBox textBox1;
        public RadioButton dungeon;
        public RadioButton city;
        public RadioButton bar;
        public Panel panel1;
        public Label label1;
        public Button next;
        public Button back;
        public Button status;
        public Label name;
        public Label job;
    }
}
