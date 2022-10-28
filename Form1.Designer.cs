namespace NovelAIWindowsTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Text2Img = new System.Windows.Forms.Button();
            this.btn_Text2Imgs = new System.Windows.Forms.Button();
            this.btn_Config = new System.Windows.Forms.Button();
            this.btn_images = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.text_Tag = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Text2Img
            // 
            this.btn_Text2Img.Location = new System.Drawing.Point(285, 88);
            this.btn_Text2Img.Name = "btn_Text2Img";
            this.btn_Text2Img.Size = new System.Drawing.Size(107, 50);
            this.btn_Text2Img.TabIndex = 0;
            this.btn_Text2Img.Text = "文生图";
            this.btn_Text2Img.UseVisualStyleBackColor = true;
            this.btn_Text2Img.Click += new System.EventHandler(this.btn_Text2Img_Click);
            // 
            // btn_Text2Imgs
            // 
            this.btn_Text2Imgs.Location = new System.Drawing.Point(285, 162);
            this.btn_Text2Imgs.Name = "btn_Text2Imgs";
            this.btn_Text2Imgs.Size = new System.Drawing.Size(107, 50);
            this.btn_Text2Imgs.TabIndex = 1;
            this.btn_Text2Imgs.Text = "批量文生图";
            this.btn_Text2Imgs.UseVisualStyleBackColor = true;
            this.btn_Text2Imgs.Click += new System.EventHandler(this.btn_Text2Imgs_Click);
            // 
            // btn_Config
            // 
            this.btn_Config.Location = new System.Drawing.Point(285, 232);
            this.btn_Config.Name = "btn_Config";
            this.btn_Config.Size = new System.Drawing.Size(107, 23);
            this.btn_Config.TabIndex = 2;
            this.btn_Config.Text = "打开配置文件";
            this.btn_Config.UseVisualStyleBackColor = true;
            this.btn_Config.Click += new System.EventHandler(this.btn_Config_Click);
            // 
            // btn_images
            // 
            this.btn_images.Location = new System.Drawing.Point(285, 261);
            this.btn_images.Name = "btn_images";
            this.btn_images.Size = new System.Drawing.Size(107, 23);
            this.btn_images.TabIndex = 3;
            this.btn_images.Text = "打开文生图文件夹";
            this.btn_images.UseVisualStyleBackColor = true;
            this.btn_images.Click += new System.EventHandler(this.btn_images_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(33, 86);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(164, 221);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // text_Tag
            // 
            this.text_Tag.Location = new System.Drawing.Point(33, 34);
            this.text_Tag.Multiline = true;
            this.text_Tag.Name = "text_Tag";
            this.text_Tag.Size = new System.Drawing.Size(359, 35);
            this.text_Tag.TabIndex = 5;
            this.text_Tag.TextChanged += new System.EventHandler(this.text_Tag_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 319);
            this.Controls.Add(this.text_Tag);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btn_images);
            this.Controls.Add(this.btn_Config);
            this.Controls.Add(this.btn_Text2Imgs);
            this.Controls.Add(this.btn_Text2Img);
            this.Name = "Form1";
            this.Text = "Ai画图桌面程序";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Text2Img;
        private System.Windows.Forms.Button btn_Text2Imgs;
        private System.Windows.Forms.Button btn_Config;
        private System.Windows.Forms.Button btn_images;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox text_Tag;
    }
}

