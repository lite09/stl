namespace stl
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aфаилToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаСвойствToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aфаилToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aфаилToolStripMenuItem
            // 
            this.aфаилToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицаСвойствToolStripMenuItem});
            this.aфаилToolStripMenuItem.Name = "aфаилToolStripMenuItem";
            this.aфаилToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aфаилToolStripMenuItem.Text = "фаил";
            // 
            // таблицаСвойствToolStripMenuItem
            // 
            this.таблицаСвойствToolStripMenuItem.Name = "таблицаСвойствToolStripMenuItem";
            this.таблицаСвойствToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.таблицаСвойствToolStripMenuItem.Text = "таблица свойств";
            this.таблицаСвойствToolStripMenuItem.Click += new System.EventHandler(this.таблицаСвойствToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Таблица свойств";
            this.openFileDialog.Filter = "Таблица|*.csv|Все фаилы(*.*)|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aфаилToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаСвойствToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

