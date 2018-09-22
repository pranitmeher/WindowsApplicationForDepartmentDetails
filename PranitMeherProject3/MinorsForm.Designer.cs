namespace PranitMeherProject3
{
    partial class MinorsForm
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
            this.pnl_minors = new System.Windows.Forms.Panel();
            this.lbl_minor_course_desc = new System.Windows.Forms.Label();
            this.lbl_minor_course_title = new System.Windows.Forms.Label();
            this.cb_minors_courses = new System.Windows.Forms.ComboBox();
            this.lbl_note = new System.Windows.Forms.Label();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.pnl_minors.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_minors
            // 
            this.pnl_minors.Controls.Add(this.lbl_minor_course_desc);
            this.pnl_minors.Controls.Add(this.lbl_minor_course_title);
            this.pnl_minors.Controls.Add(this.cb_minors_courses);
            this.pnl_minors.Controls.Add(this.lbl_note);
            this.pnl_minors.Controls.Add(this.lbl_desc);
            this.pnl_minors.Controls.Add(this.lbl_title);
            this.pnl_minors.Location = new System.Drawing.Point(8, 8);
            this.pnl_minors.Name = "pnl_minors";
            this.pnl_minors.Size = new System.Drawing.Size(1280, 1320);
            this.pnl_minors.TabIndex = 0;
            // 
            // lbl_minor_course_desc
            // 
            this.lbl_minor_course_desc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_minor_course_desc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_minor_course_desc.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_minor_course_desc.ForeColor = System.Drawing.Color.White;
            this.lbl_minor_course_desc.Location = new System.Drawing.Point(24, 784);
            this.lbl_minor_course_desc.Name = "lbl_minor_course_desc";
            this.lbl_minor_course_desc.Size = new System.Drawing.Size(1216, 240);
            this.lbl_minor_course_desc.TabIndex = 9;
            this.lbl_minor_course_desc.Text = "label1";
            this.lbl_minor_course_desc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_minor_course_desc.Visible = false;
            // 
            // lbl_minor_course_title
            // 
            this.lbl_minor_course_title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_minor_course_title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_minor_course_title.Font = new System.Drawing.Font("Calibri", 13.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_minor_course_title.ForeColor = System.Drawing.Color.Orange;
            this.lbl_minor_course_title.Location = new System.Drawing.Point(40, 640);
            this.lbl_minor_course_title.Name = "lbl_minor_course_title";
            this.lbl_minor_course_title.Size = new System.Drawing.Size(1216, 112);
            this.lbl_minor_course_title.TabIndex = 8;
            this.lbl_minor_course_title.Text = "label52";
            this.lbl_minor_course_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_minor_course_title.Visible = false;
            // 
            // cb_minors_courses
            // 
            this.cb_minors_courses.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cb_minors_courses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_minors_courses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_minors_courses.Font = new System.Drawing.Font("Calibri Light", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_minors_courses.ForeColor = System.Drawing.Color.Orange;
            this.cb_minors_courses.FormattingEnabled = true;
            this.cb_minors_courses.Location = new System.Drawing.Point(472, 552);
            this.cb_minors_courses.Name = "cb_minors_courses";
            this.cb_minors_courses.Size = new System.Drawing.Size(360, 41);
            this.cb_minors_courses.TabIndex = 7;
            this.cb_minors_courses.SelectedIndexChanged += new System.EventHandler(this.cb_minors_courses_SelectedIndexChanged);
            // 
            // lbl_note
            // 
            this.lbl_note.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_note.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_note.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_note.ForeColor = System.Drawing.Color.Red;
            this.lbl_note.Location = new System.Drawing.Point(32, 1040);
            this.lbl_note.Name = "lbl_note";
            this.lbl_note.Size = new System.Drawing.Size(1216, 168);
            this.lbl_note.TabIndex = 6;
            this.lbl_note.Text = "label2";
            this.lbl_note.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_desc
            // 
            this.lbl_desc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_desc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_desc.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_desc.ForeColor = System.Drawing.Color.White;
            this.lbl_desc.Location = new System.Drawing.Point(32, 192);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(1216, 328);
            this.lbl_desc.TabIndex = 5;
            this.lbl_desc.Text = "label1";
            this.lbl_desc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_title.Font = new System.Drawing.Font("Calibri", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.Orange;
            this.lbl_title.Location = new System.Drawing.Point(24, 24);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(1216, 112);
            this.lbl_title.TabIndex = 4;
            this.lbl_title.Text = "label52";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MinorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1410, 1394);
            this.Controls.Add(this.pnl_minors);
            this.Name = "MinorsForm";
            this.Text = "MinorsForm";
            this.Load += new System.EventHandler(this.MinorsForm_Load);
            this.pnl_minors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_minors;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.Label lbl_note;
        private System.Windows.Forms.ComboBox cb_minors_courses;
        private System.Windows.Forms.Label lbl_minor_course_desc;
        private System.Windows.Forms.Label lbl_minor_course_title;
    }
}