namespace 专题2_递归下降语法分析器___WinForm
{
    partial class ExpressionParser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpressionParser));
            button1 = new Button();
            button2 = new Button();
            DetailedOutput = new TextBox();
            label1 = new Label();
            BasicOutput = new TextBox();
            InputBox = new TextBox();
            Previous = new Button();
            Next = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            FormattedInput = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Noto Sans", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(309, 744);
            button1.Name = "button1";
            button1.Size = new Size(184, 49);
            button1.TabIndex = 1;
            button1.Text = "Analysis";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AnalysisClick;
            // 
            // button2
            // 
            button2.Font = new Font("Noto Sans", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(592, 744);
            button2.Name = "button2";
            button2.Size = new Size(184, 49);
            button2.TabIndex = 1;
            button2.Text = "Reset";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ResetClick;
            // 
            // DetailedOutput
            // 
            DetailedOutput.BackColor = Color.White;
            DetailedOutput.Font = new Font("SF Mono", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            DetailedOutput.ForeColor = Color.Teal;
            DetailedOutput.Location = new Point(12, 34);
            DetailedOutput.Multiline = true;
            DetailedOutput.Name = "DetailedOutput";
            DetailedOutput.PlaceholderText = "Detailed information about the analyzing stack.";
            DetailedOutput.ReadOnly = true;
            DetailedOutput.ScrollBars = ScrollBars.Horizontal;
            DetailedOutput.Size = new Size(1040, 107);
            DetailedOutput.TabIndex = 1;
            DetailedOutput.WordWrap = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(949, 81);
            label1.TabIndex = 5;
            label1.Text = resources.GetString("label1.Text");
            // 
            // BasicOutput
            // 
            BasicOutput.BackColor = Color.White;
            BasicOutput.Font = new Font("SF Mono", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            BasicOutput.ForeColor = Color.FromArgb(192, 0, 192);
            BasicOutput.Location = new Point(12, 34);
            BasicOutput.Multiline = true;
            BasicOutput.Name = "BasicOutput";
            BasicOutput.PlaceholderText = "Showing whether the inputted expression can be parsed successfully." + Environment.NewLine + "The numerical result will also be displayed here.";
            BasicOutput.ReadOnly = true;
            BasicOutput.Size = new Size(1040, 84);
            BasicOutput.TabIndex = 3;
            // 
            // InputBox
            // 
            InputBox.Font = new Font("SF Mono", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            InputBox.Location = new Point(24, 139);
            InputBox.Multiline = true;
            InputBox.Name = "InputBox";
            InputBox.PlaceholderText = "Please enter a mathematical expresion (e.g. 4 + 4 * 4)...";
            InputBox.ScrollBars = ScrollBars.Vertical;
            InputBox.Size = new Size(1040, 84);
            InputBox.TabIndex = 4;
            // 
            // Previous
            // 
            Previous.Font = new Font("Noto Sans", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Previous.Location = new Point(297, 156);
            Previous.Name = "Previous";
            Previous.Size = new Size(184, 50);
            Previous.TabIndex = 1;
            Previous.Text = "<<Prev";
            Previous.UseVisualStyleBackColor = true;
            Previous.Click += PreviousClick;
            // 
            // Next
            // 
            Next.Font = new Font("Noto Sans", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Next.Location = new Point(580, 156);
            Next.Name = "Next";
            Next.Size = new Size(184, 50);
            Next.TabIndex = 1;
            Next.Text = "Next>>";
            Next.UseVisualStyleBackColor = true;
            Next.Click += NextClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DetailedOutput);
            groupBox1.Controls.Add(Previous);
            groupBox1.Controls.Add(Next);
            groupBox1.Font = new Font("Noto Sans", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 515);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1064, 223);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detailed progress in parsing the input:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BasicOutput);
            groupBox2.Font = new Font("Noto Sans", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(12, 379);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1064, 130);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Summarized result:";
            // 
            // groupBox3
            // 
            groupBox3.Font = new Font("Noto Sans", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(12, 107);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1064, 130);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Input";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(FormattedInput);
            groupBox4.Font = new Font("Noto Sans", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox4.Location = new Point(12, 243);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1064, 130);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Formatted input:";
            // 
            // FormattedInput
            // 
            FormattedInput.BackColor = Color.White;
            FormattedInput.Font = new Font("SF Mono", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            FormattedInput.ForeColor = SystemColors.MenuHighlight;
            FormattedInput.Location = new Point(12, 34);
            FormattedInput.Multiline = true;
            FormattedInput.Name = "FormattedInput";
            FormattedInput.PlaceholderText = "The format of the expression will be displayed here. " + Environment.NewLine + "For instance, 4+4*4 will be formatted to i+i*i";
            FormattedInput.ReadOnly = true;
            FormattedInput.ScrollBars = ScrollBars.Vertical;
            FormattedInput.Size = new Size(1040, 84);
            FormattedInput.TabIndex = 0;
            // 
            // ExpressionParser
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1088, 804);
            Controls.Add(label1);
            Controls.Add(InputBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            KeyPreview = true;
            MaximumSize = new Size(1110, 860);
            MinimumSize = new Size(1110, 860);
            Name = "ExpressionParser";
            Text = "Task 2 - Expression Parser (Author: 0x00ac3375)";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private TextBox DetailedOutput;
        private Label label1;
        private TextBox BasicOutput;
        private TextBox InputBox;
        private Button Previous;
        private Button Next;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private TextBox FormattedInput;
    }
}