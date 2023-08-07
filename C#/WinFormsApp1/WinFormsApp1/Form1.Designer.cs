namespace WinFormsApp1
{
    partial class Form1
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
            inputText = new TextBox();
            submit = new Button();
            display = new Label();
            SuspendLayout();
            // 
            // inputText
            // 
            inputText.Location = new Point(185, 62);
            inputText.Name = "inputText";
            inputText.Size = new Size(100, 26);
            inputText.TabIndex = 0;
            inputText.TextChanged += textBox1_TextChanged;
            // 
            // submit
            // 
            submit.Location = new Point(291, 65);
            submit.Name = "submit";
            submit.Size = new Size(75, 23);
            submit.TabIndex = 1;
            submit.Text = "Ok";
            submit.UseVisualStyleBackColor = true;
            submit.Click += button1_Click;
            // 
            // display
            // 
            display.AutoSize = true;
            display.Location = new Point(185, 116);
            display.Name = "display";
            display.Size = new Size(45, 19);
            display.TabIndex = 2;
            display.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 245);
            Controls.Add(display);
            Controls.Add(submit);
            Controls.Add(inputText);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputText;
        private Button submit;
        private Label display;
    }
}