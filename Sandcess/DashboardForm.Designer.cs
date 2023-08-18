namespace Sandcess
{
    partial class DashboardForm
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
            diagramControlPathRelationship = new Northwoods.Go.WinForms.DiagramControl();
            panelPathRelationship = new Panel();
            panelPathRelationship.SuspendLayout();
            SuspendLayout();
            // 
            // diagramControlPathRelationship
            // 
            diagramControlPathRelationship.AllowDrop = true;
            diagramControlPathRelationship.BackColor = Color.White;
            diagramControlPathRelationship.Dock = DockStyle.Fill;
            diagramControlPathRelationship.Location = new Point(0, 0);
            diagramControlPathRelationship.Name = "diagramControlPathRelationship";
            diagramControlPathRelationship.Size = new Size(800, 450);
            diagramControlPathRelationship.TabIndex = 0;
            diagramControlPathRelationship.Text = "diagramControl1";
            // 
            // panelPathRelationship
            // 
            panelPathRelationship.Controls.Add(diagramControlPathRelationship);
            panelPathRelationship.Dock = DockStyle.Fill;
            panelPathRelationship.Location = new Point(0, 0);
            panelPathRelationship.Name = "panelPathRelationship";
            panelPathRelationship.Size = new Size(800, 450);
            panelPathRelationship.TabIndex = 1;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelPathRelationship);
            Name = "DashboardForm";
            Text = "DashboardForm";
            panelPathRelationship.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Northwoods.Go.WinForms.DiagramControl diagramControlPathRelationship;
        private Panel panelPathRelationship;
    }
}