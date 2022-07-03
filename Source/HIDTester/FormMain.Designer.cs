using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIDTester
{
    public partial class FormMain
    {
		private Dictionary<string, Form> menuDic = new Dictionary<string, Form>();

		private IContainer components;

		private Label stateLabel;

		private ToolStripMenuItem fdToolStripMenuItem;

		private Button Download;

		private Button KEY1;

		private Button KEY2;

		private Button KEY3;

		private Button KEY4;

		private Button K1_Left;

		private Button K1_Centre;

		private Button K1_Right;

		private TextBox SetText;

		private Button Key_Clear;

		private Button KEY8;

		private Button KEY7;

		private Button KEY6;

		private Button KEY5;

		private Button KEY12;

		private Button KEY11;

		private Button KEY10;

		private Button KEY9;

		private Button KEY16;

		private Button KEY15;

		private Button KEY14;

		private Button KEY13;

		private Button K2_Right;

		private Button K2_Centre;

		private Button K2_Left;

		private SplitContainer splitContainer1;

		private FlowLayoutPanel flowLayoutPanel1;

		private TextBox SetFunText;

		private Button K3_Left;

		private Button K3_Centre;

		private Button K3_Right;

		private FlowLayoutPanel flowLayoutPanel_LayerFun;

		private PictureBox pictureBox1;

		private Label label_Dowload_Dsp;


		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(HIDTester.FormMain));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.stateLabel = new System.Windows.Forms.Label();
			this.fdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Download = new System.Windows.Forms.Button();
			this.KEY1 = new System.Windows.Forms.Button();
			this.KEY2 = new System.Windows.Forms.Button();
			this.KEY3 = new System.Windows.Forms.Button();
			this.KEY4 = new System.Windows.Forms.Button();
			this.K1_Left = new System.Windows.Forms.Button();
			this.K1_Centre = new System.Windows.Forms.Button();
			this.K1_Right = new System.Windows.Forms.Button();
			this.SetText = new System.Windows.Forms.TextBox();
			this.Key_Clear = new System.Windows.Forms.Button();
			this.KEY8 = new System.Windows.Forms.Button();
			this.KEY7 = new System.Windows.Forms.Button();
			this.KEY6 = new System.Windows.Forms.Button();
			this.KEY5 = new System.Windows.Forms.Button();
			this.KEY12 = new System.Windows.Forms.Button();
			this.KEY11 = new System.Windows.Forms.Button();
			this.KEY10 = new System.Windows.Forms.Button();
			this.KEY9 = new System.Windows.Forms.Button();
			this.KEY16 = new System.Windows.Forms.Button();
			this.KEY15 = new System.Windows.Forms.Button();
			this.KEY14 = new System.Windows.Forms.Button();
			this.KEY13 = new System.Windows.Forms.Button();
			this.K2_Right = new System.Windows.Forms.Button();
			this.K2_Centre = new System.Windows.Forms.Button();
			this.K2_Left = new System.Windows.Forms.Button();
			this.SetFunText = new System.Windows.Forms.TextBox();
			this.K3_Left = new System.Windows.Forms.Button();
			this.K3_Centre = new System.Windows.Forms.Button();
			this.K3_Right = new System.Windows.Forms.Button();
			this.flowLayoutPanel_LayerFun = new System.Windows.Forms.FlowLayoutPanel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label_Dowload_Dsp = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.splitContainer1, "splitContainer1");
			this.splitContainer1.Name = "splitContainer1";
			componentResourceManager.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			componentResourceManager.ApplyResources(this.stateLabel, "stateLabel");
			this.stateLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.stateLabel.Name = "stateLabel";
			this.fdToolStripMenuItem.Name = "fdToolStripMenuItem";
			componentResourceManager.ApplyResources(this.fdToolStripMenuItem, "fdToolStripMenuItem");
			componentResourceManager.ApplyResources(this.Download, "Download");
			this.Download.Name = "Download";
			this.Download.UseVisualStyleBackColor = true;
			this.Download.Click += new System.EventHandler(Download_Click);
			componentResourceManager.ApplyResources(this.KEY1, "KEY1");
			this.KEY1.Name = "KEY1";
			this.KEY1.UseVisualStyleBackColor = true;
			this.KEY1.Click += new System.EventHandler(KEY1_Click);
			componentResourceManager.ApplyResources(this.KEY2, "KEY2");
			this.KEY2.Name = "KEY2";
			this.KEY2.UseVisualStyleBackColor = true;
			this.KEY2.Click += new System.EventHandler(KEY2_Click);
			componentResourceManager.ApplyResources(this.KEY3, "KEY3");
			this.KEY3.Name = "KEY3";
			this.KEY3.UseVisualStyleBackColor = true;
			this.KEY3.Click += new System.EventHandler(KEY3_Click);
			componentResourceManager.ApplyResources(this.KEY4, "KEY4");
			this.KEY4.Name = "KEY4";
			this.KEY4.UseVisualStyleBackColor = true;
			this.KEY4.Click += new System.EventHandler(KEY4_Click);
			componentResourceManager.ApplyResources(this.K1_Left, "K1_Left");
			this.K1_Left.Name = "K1_Left";
			this.K1_Left.UseVisualStyleBackColor = true;
			this.K1_Left.Click += new System.EventHandler(K1_Left_Click);
			componentResourceManager.ApplyResources(this.K1_Centre, "K1_Centre");
			this.K1_Centre.Name = "K1_Centre";
			this.K1_Centre.UseVisualStyleBackColor = true;
			this.K1_Centre.Click += new System.EventHandler(K1_Centre_Click);
			componentResourceManager.ApplyResources(this.K1_Right, "K1_Right");
			this.K1_Right.Name = "K1_Right";
			this.K1_Right.UseVisualStyleBackColor = true;
			this.K1_Right.Click += new System.EventHandler(K1_Right_Click);
			componentResourceManager.ApplyResources(this.SetText, "SetText");
			this.SetText.Name = "SetText";
			componentResourceManager.ApplyResources(this.Key_Clear, "Key_Clear");
			this.Key_Clear.Name = "Key_Clear";
			this.Key_Clear.UseVisualStyleBackColor = true;
			this.Key_Clear.Click += new System.EventHandler(Key_Clear_Click);
			componentResourceManager.ApplyResources(this.KEY8, "KEY8");
			this.KEY8.Name = "KEY8";
			this.KEY8.UseVisualStyleBackColor = true;
			this.KEY8.Click += new System.EventHandler(KEY8_Click);
			componentResourceManager.ApplyResources(this.KEY7, "KEY7");
			this.KEY7.Name = "KEY7";
			this.KEY7.UseVisualStyleBackColor = true;
			this.KEY7.Click += new System.EventHandler(KEY7_Click);
			componentResourceManager.ApplyResources(this.KEY6, "KEY6");
			this.KEY6.Name = "KEY6";
			this.KEY6.UseVisualStyleBackColor = true;
			this.KEY6.Click += new System.EventHandler(KEY6_Click);
			componentResourceManager.ApplyResources(this.KEY5, "KEY5");
			this.KEY5.Name = "KEY5";
			this.KEY5.UseVisualStyleBackColor = true;
			this.KEY5.Click += new System.EventHandler(KEY5_Click);
			componentResourceManager.ApplyResources(this.KEY12, "KEY12");
			this.KEY12.Name = "KEY12";
			this.KEY12.UseVisualStyleBackColor = true;
			this.KEY12.Click += new System.EventHandler(KEY12_Click);
			componentResourceManager.ApplyResources(this.KEY11, "KEY11");
			this.KEY11.Name = "KEY11";
			this.KEY11.UseVisualStyleBackColor = true;
			this.KEY11.Click += new System.EventHandler(KEY11_Click);
			componentResourceManager.ApplyResources(this.KEY10, "KEY10");
			this.KEY10.Name = "KEY10";
			this.KEY10.UseVisualStyleBackColor = true;
			this.KEY10.Click += new System.EventHandler(KEY10_Click);
			componentResourceManager.ApplyResources(this.KEY9, "KEY9");
			this.KEY9.Name = "KEY9";
			this.KEY9.UseVisualStyleBackColor = true;
			this.KEY9.Click += new System.EventHandler(KEY9_Click);
			componentResourceManager.ApplyResources(this.KEY16, "KEY16");
			this.KEY16.Name = "KEY16";
			this.KEY16.UseVisualStyleBackColor = true;
			componentResourceManager.ApplyResources(this.KEY15, "KEY15");
			this.KEY15.Name = "KEY15";
			this.KEY15.UseVisualStyleBackColor = true;
			componentResourceManager.ApplyResources(this.KEY14, "KEY14");
			this.KEY14.Name = "KEY14";
			this.KEY14.UseVisualStyleBackColor = true;
			componentResourceManager.ApplyResources(this.KEY13, "KEY13");
			this.KEY13.Name = "KEY13";
			this.KEY13.UseVisualStyleBackColor = true;
			componentResourceManager.ApplyResources(this.K2_Right, "K2_Right");
			this.K2_Right.Name = "K2_Right";
			this.K2_Right.UseVisualStyleBackColor = true;
			this.K2_Right.Click += new System.EventHandler(K2_Right_Click);
			componentResourceManager.ApplyResources(this.K2_Centre, "K2_Centre");
			this.K2_Centre.Name = "K2_Centre";
			this.K2_Centre.UseVisualStyleBackColor = true;
			this.K2_Centre.Click += new System.EventHandler(K2_Centre_Click);
			componentResourceManager.ApplyResources(this.K2_Left, "K2_Left");
			this.K2_Left.Name = "K2_Left";
			this.K2_Left.UseVisualStyleBackColor = true;
			this.K2_Left.Click += new System.EventHandler(K2_Left_Click);
			componentResourceManager.ApplyResources(this.SetFunText, "SetFunText");
			this.SetFunText.Name = "SetFunText";
			componentResourceManager.ApplyResources(this.K3_Left, "K3_Left");
			this.K3_Left.Name = "K3_Left";
			this.K3_Left.UseVisualStyleBackColor = true;
			componentResourceManager.ApplyResources(this.K3_Centre, "K3_Centre");
			this.K3_Centre.Name = "K3_Centre";
			this.K3_Centre.UseVisualStyleBackColor = true;
			componentResourceManager.ApplyResources(this.K3_Right, "K3_Right");
			this.K3_Right.Name = "K3_Right";
			this.K3_Right.UseVisualStyleBackColor = true;
			componentResourceManager.ApplyResources(this.flowLayoutPanel_LayerFun, "flowLayoutPanel_LayerFun");
			this.flowLayoutPanel_LayerFun.Name = "flowLayoutPanel_LayerFun";
			this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			componentResourceManager.ApplyResources(this.pictureBox1, "pictureBox1");
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.TabStop = false;
			componentResourceManager.ApplyResources(this.label_Dowload_Dsp, "label_Dowload_Dsp");
			this.label_Dowload_Dsp.Name = "label_Dowload_Dsp";
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.flowLayoutPanel1);
			base.Controls.Add(this.label_Dowload_Dsp);
			base.Controls.Add(this.flowLayoutPanel_LayerFun);
			base.Controls.Add(this.SetFunText);
			base.Controls.Add(this.K3_Right);
			base.Controls.Add(this.K3_Centre);
			base.Controls.Add(this.K3_Left);
			base.Controls.Add(this.K2_Right);
			base.Controls.Add(this.K2_Centre);
			base.Controls.Add(this.K2_Left);
			base.Controls.Add(this.KEY16);
			base.Controls.Add(this.KEY15);
			base.Controls.Add(this.KEY14);
			base.Controls.Add(this.KEY13);
			base.Controls.Add(this.KEY12);
			base.Controls.Add(this.KEY11);
			base.Controls.Add(this.KEY10);
			base.Controls.Add(this.KEY9);
			base.Controls.Add(this.KEY8);
			base.Controls.Add(this.KEY7);
			base.Controls.Add(this.KEY6);
			base.Controls.Add(this.KEY5);
			base.Controls.Add(this.Key_Clear);
			base.Controls.Add(this.SetText);
			base.Controls.Add(this.K1_Right);
			base.Controls.Add(this.K1_Centre);
			base.Controls.Add(this.K1_Left);
			base.Controls.Add(this.KEY4);
			base.Controls.Add(this.KEY3);
			base.Controls.Add(this.KEY2);
			base.Controls.Add(this.KEY1);
			base.Controls.Add(this.Download);
			base.Controls.Add(this.stateLabel);
			base.Controls.Add(this.splitContainer1);
			base.Controls.Add(this.pictureBox1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Name = "FormMain";
			base.Load += new System.EventHandler(FormMain_Load);
			((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
