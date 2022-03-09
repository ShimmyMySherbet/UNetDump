
namespace UNetBrowser
{
    partial class NetBrowser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.pnheader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbServer = new System.Windows.Forms.CheckBox();
            this.cbClient = new System.Windows.Forms.CheckBox();
            this.cbCaseSensitive = new System.Windows.Forms.CheckBox();
            this.cbSearchParam = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowItems = new System.Windows.Forms.FlowLayoutPanel();
            this.pnheader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnheader
            // 
            this.pnheader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnheader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnheader.Controls.Add(this.panel1);
            this.pnheader.Controls.Add(this.cbCaseSensitive);
            this.pnheader.Controls.Add(this.cbSearchParam);
            this.pnheader.Controls.Add(this.btnExport);
            this.pnheader.Controls.Add(this.txtSearch);
            this.pnheader.Controls.Add(this.label1);
            this.pnheader.Location = new System.Drawing.Point(0, 0);
            this.pnheader.Margin = new System.Windows.Forms.Padding(4);
            this.pnheader.Name = "pnheader";
            this.pnheader.Size = new System.Drawing.Size(919, 35);
            this.pnheader.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbServer);
            this.panel1.Controls.Add(this.cbClient);
            this.panel1.Location = new System.Drawing.Point(442, -9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 51);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sent By:";
            // 
            // cbServer
            // 
            this.cbServer.AutoSize = true;
            this.cbServer.Checked = true;
            this.cbServer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbServer.Location = new System.Drawing.Point(78, 12);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(74, 25);
            this.cbServer.TabIndex = 2;
            this.cbServer.Text = "Server";
            this.cbServer.UseVisualStyleBackColor = true;
            this.cbServer.CheckedChanged += new System.EventHandler(this.cbServer_CheckedChanged);
            // 
            // cbClient
            // 
            this.cbClient.AutoSize = true;
            this.cbClient.Checked = true;
            this.cbClient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClient.Location = new System.Drawing.Point(158, 13);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(69, 25);
            this.cbClient.TabIndex = 4;
            this.cbClient.Text = "Client";
            this.cbClient.UseVisualStyleBackColor = true;
            // 
            // cbCaseSensitive
            // 
            this.cbCaseSensitive.AutoSize = true;
            this.cbCaseSensitive.Location = new System.Drawing.Point(678, 5);
            this.cbCaseSensitive.Name = "cbCaseSensitive";
            this.cbCaseSensitive.Size = new System.Drawing.Size(128, 25);
            this.cbCaseSensitive.TabIndex = 7;
            this.cbCaseSensitive.Text = "Case Sensitive";
            this.cbCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // cbSearchParam
            // 
            this.cbSearchParam.AutoSize = true;
            this.cbSearchParam.Checked = true;
            this.cbSearchParam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSearchParam.Location = new System.Drawing.Point(287, 5);
            this.cbSearchParam.Name = "cbSearchParam";
            this.cbSearchParam.Size = new System.Drawing.Size(159, 25);
            this.cbSearchParam.TabIndex = 6;
            this.cbSearchParam.Text = "Search Parameters";
            this.cbSearchParam.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExport.Location = new System.Drawing.Point(826, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.OnExportRequested);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.txtSearch.Location = new System.Drawing.Point(68, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(213, 28);
            this.txtSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search:";
            // 
            // flowItems
            // 
            this.flowItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowItems.AutoScroll = true;
            this.flowItems.Location = new System.Drawing.Point(1, 38);
            this.flowItems.Name = "flowItems";
            this.flowItems.Size = new System.Drawing.Size(913, 553);
            this.flowItems.TabIndex = 6;
            // 
            // NetBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(915, 593);
            this.Controls.Add(this.flowItems);
            this.Controls.Add(this.pnheader);
            this.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(134)))), ((int)(((byte)(248)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NetBrowser";
            this.Text = "Unturned Net Method Browser";
            this.Load += new System.EventHandler(this.OnWindowLoad);
            this.pnheader.ResumeLayout(false);
            this.pnheader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnheader;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox cbClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbServer;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowItems;
        private System.Windows.Forms.CheckBox cbSearchParam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbCaseSensitive;
    }
}

