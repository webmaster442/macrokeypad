using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HIDTester;

public class LayerFun : UserControl
{
	private IContainer components;

	private RadioButton KEY_Layer1;

	private RadioButton KEY_Layer2;

	private RadioButton KEY_Layer3;

	private RadioButton KEY_FunLayer1;

	private RadioButton KEY_FunLayer2;

	private RadioButton KEY_FunLayer3;

	public LayerFun()
	{
		InitializeComponent();
	}

	private void KEY_FunLayer1_CheckedChanged(object sender, EventArgs e)
	{
		if (KEY_FunLayer1.Checked)
		{
			FormMain.KeyParam.KEY_Cur_Layer = 1;
			FormMain.KeyParam.PageBet_Inte_Cmd = 1;
		}
	}

	private void KEY_FunLayer2_CheckedChanged(object sender, EventArgs e)
	{
		if (KEY_FunLayer2.Checked)
		{
			FormMain.KeyParam.KEY_Cur_Layer = 2;
			FormMain.KeyParam.PageBet_Inte_Cmd = 1;
		}
	}

	private void KEY_FunLayer3_CheckedChanged(object sender, EventArgs e)
	{
		if (KEY_FunLayer3.Checked)
		{
			FormMain.KeyParam.KEY_Cur_Layer = 3;
			FormMain.KeyParam.PageBet_Inte_Cmd = 1;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(HIDTester.LayerFun));
		this.KEY_Layer1 = new System.Windows.Forms.RadioButton();
		this.KEY_Layer2 = new System.Windows.Forms.RadioButton();
		this.KEY_Layer3 = new System.Windows.Forms.RadioButton();
		this.KEY_FunLayer1 = new System.Windows.Forms.RadioButton();
		this.KEY_FunLayer2 = new System.Windows.Forms.RadioButton();
		this.KEY_FunLayer3 = new System.Windows.Forms.RadioButton();
		base.SuspendLayout();
		componentResourceManager.ApplyResources(this.KEY_Layer1, "KEY_Layer1");
		this.KEY_Layer1.Name = "KEY_Layer1";
		componentResourceManager.ApplyResources(this.KEY_Layer2, "KEY_Layer2");
		this.KEY_Layer2.Name = "KEY_Layer2";
		componentResourceManager.ApplyResources(this.KEY_Layer3, "KEY_Layer3");
		this.KEY_Layer3.Name = "KEY_Layer3";
		componentResourceManager.ApplyResources(this.KEY_FunLayer1, "KEY_FunLayer1");
		this.KEY_FunLayer1.Checked = true;
		this.KEY_FunLayer1.Name = "KEY_FunLayer1";
		this.KEY_FunLayer1.TabStop = true;
		this.KEY_FunLayer1.UseVisualStyleBackColor = true;
		this.KEY_FunLayer1.CheckedChanged += new System.EventHandler(KEY_FunLayer1_CheckedChanged);
		componentResourceManager.ApplyResources(this.KEY_FunLayer2, "KEY_FunLayer2");
		this.KEY_FunLayer2.Name = "KEY_FunLayer2";
		this.KEY_FunLayer2.TabStop = true;
		this.KEY_FunLayer2.UseVisualStyleBackColor = true;
		this.KEY_FunLayer2.CheckedChanged += new System.EventHandler(KEY_FunLayer2_CheckedChanged);
		componentResourceManager.ApplyResources(this.KEY_FunLayer3, "KEY_FunLayer3");
		this.KEY_FunLayer3.Name = "KEY_FunLayer3";
		this.KEY_FunLayer3.TabStop = true;
		this.KEY_FunLayer3.UseVisualStyleBackColor = true;
		this.KEY_FunLayer3.CheckedChanged += new System.EventHandler(KEY_FunLayer3_CheckedChanged);
		componentResourceManager.ApplyResources(this, "$this");
		base.Controls.Add(this.KEY_FunLayer3);
		base.Controls.Add(this.KEY_FunLayer2);
		base.Controls.Add(this.KEY_FunLayer1);
		this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
		base.Name = "LayerFun";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
