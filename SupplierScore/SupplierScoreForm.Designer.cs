namespace SupplierScore
{
    partial class SupplierScore
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
            GroupBoxInput = new GroupBox();
            ButtonRemove = new Button();
            ButtonEdit = new Button();
            LabelInvoiceID = new Label();
            TextBoxInvoiceID = new TextBox();
            ButtonCalculate = new Button();
            DateTimePickerDueDate = new DateTimePicker();
            LabelDueDate = new Label();
            ComboBoxBusinessSize = new ComboBox();
            LabelBusinessSize = new Label();
            NumericUpDownAmountOwed = new NumericUpDown();
            LabelAmountOwed = new Label();
            ComboBoxSuppliers = new ComboBox();
            LabelSuppliers = new Label();
            dataGridView1 = new DataGridView();
            GroupBoxOutputSupplier = new GroupBox();
            GroupBoxNotes = new GroupBox();
            RichTextBoxNotes = new RichTextBox();
            Tag = new Label();
            GroupBoxInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownAmountOwed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            GroupBoxOutputSupplier.SuspendLayout();
            GroupBoxNotes.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBoxInput
            // 
            GroupBoxInput.Controls.Add(ButtonRemove);
            GroupBoxInput.Controls.Add(ButtonEdit);
            GroupBoxInput.Controls.Add(LabelInvoiceID);
            GroupBoxInput.Controls.Add(TextBoxInvoiceID);
            GroupBoxInput.Controls.Add(ButtonCalculate);
            GroupBoxInput.Controls.Add(DateTimePickerDueDate);
            GroupBoxInput.Controls.Add(LabelDueDate);
            GroupBoxInput.Controls.Add(ComboBoxBusinessSize);
            GroupBoxInput.Controls.Add(LabelBusinessSize);
            GroupBoxInput.Controls.Add(NumericUpDownAmountOwed);
            GroupBoxInput.Controls.Add(LabelAmountOwed);
            GroupBoxInput.Controls.Add(ComboBoxSuppliers);
            GroupBoxInput.Controls.Add(LabelSuppliers);
            GroupBoxInput.Location = new Point(12, 12);
            GroupBoxInput.Name = "GroupBoxInput";
            GroupBoxInput.Size = new Size(304, 205);
            GroupBoxInput.TabIndex = 0;
            GroupBoxInput.TabStop = false;
            GroupBoxInput.Text = "Input";
            // 
            // ButtonRemove
            // 
            ButtonRemove.Location = new Point(204, 164);
            ButtonRemove.Name = "ButtonRemove";
            ButtonRemove.Size = new Size(93, 35);
            ButtonRemove.TabIndex = 13;
            ButtonRemove.Text = "Remove";
            ButtonRemove.UseVisualStyleBackColor = true;
            ButtonRemove.Click += ButtonRemove_Click;
            // 
            // ButtonEdit
            // 
            ButtonEdit.Location = new Point(105, 164);
            ButtonEdit.Name = "ButtonEdit";
            ButtonEdit.Size = new Size(93, 35);
            ButtonEdit.TabIndex = 12;
            ButtonEdit.Text = "Edit";
            ButtonEdit.UseVisualStyleBackColor = true;
            ButtonEdit.Click += ButtonEdit_Click;
            // 
            // LabelInvoiceID
            // 
            LabelInvoiceID.AutoSize = true;
            LabelInvoiceID.Location = new Point(6, 143);
            LabelInvoiceID.Name = "LabelInvoiceID";
            LabelInvoiceID.Size = new Size(62, 15);
            LabelInvoiceID.TabIndex = 10;
            LabelInvoiceID.Text = "Invoice ID:";
            // 
            // TextBoxInvoiceID
            // 
            TextBoxInvoiceID.Location = new Point(113, 135);
            TextBoxInvoiceID.Name = "TextBoxInvoiceID";
            TextBoxInvoiceID.Size = new Size(153, 23);
            TextBoxInvoiceID.TabIndex = 9;
            // 
            // ButtonCalculate
            // 
            ButtonCalculate.Location = new Point(6, 164);
            ButtonCalculate.Name = "ButtonCalculate";
            ButtonCalculate.Size = new Size(93, 35);
            ButtonCalculate.TabIndex = 8;
            ButtonCalculate.Text = "Calculate ";
            ButtonCalculate.UseVisualStyleBackColor = true;
            ButtonCalculate.Click += ButtonCalculate_Click;
            // 
            // DateTimePickerDueDate
            // 
            DateTimePickerDueDate.Format = DateTimePickerFormat.Short;
            DateTimePickerDueDate.Location = new Point(113, 106);
            DateTimePickerDueDate.Name = "DateTimePickerDueDate";
            DateTimePickerDueDate.Size = new Size(153, 23);
            DateTimePickerDueDate.TabIndex = 7;
            DateTimePickerDueDate.Value = new DateTime(2024, 10, 27, 0, 0, 0, 0);
            // 
            // LabelDueDate
            // 
            LabelDueDate.AutoSize = true;
            LabelDueDate.Location = new Point(6, 114);
            LabelDueDate.Name = "LabelDueDate";
            LabelDueDate.Size = new Size(58, 15);
            LabelDueDate.TabIndex = 6;
            LabelDueDate.Text = "Due Date:";
            // 
            // ComboBoxBusinessSize
            // 
            ComboBoxBusinessSize.FormattingEnabled = true;
            ComboBoxBusinessSize.Location = new Point(113, 77);
            ComboBoxBusinessSize.Name = "ComboBoxBusinessSize";
            ComboBoxBusinessSize.Size = new Size(153, 23);
            ComboBoxBusinessSize.TabIndex = 5;
            // 
            // LabelBusinessSize
            // 
            LabelBusinessSize.AutoSize = true;
            LabelBusinessSize.Location = new Point(6, 85);
            LabelBusinessSize.Name = "LabelBusinessSize";
            LabelBusinessSize.Size = new Size(78, 15);
            LabelBusinessSize.TabIndex = 4;
            LabelBusinessSize.Text = "Business Size:";
            // 
            // NumericUpDownAmountOwed
            // 
            NumericUpDownAmountOwed.DecimalPlaces = 2;
            NumericUpDownAmountOwed.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            NumericUpDownAmountOwed.Location = new Point(113, 48);
            NumericUpDownAmountOwed.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NumericUpDownAmountOwed.Name = "NumericUpDownAmountOwed";
            NumericUpDownAmountOwed.Size = new Size(153, 23);
            NumericUpDownAmountOwed.TabIndex = 1;
            NumericUpDownAmountOwed.ThousandsSeparator = true;
            NumericUpDownAmountOwed.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // LabelAmountOwed
            // 
            LabelAmountOwed.AutoSize = true;
            LabelAmountOwed.Location = new Point(6, 56);
            LabelAmountOwed.Name = "LabelAmountOwed";
            LabelAmountOwed.Size = new Size(88, 15);
            LabelAmountOwed.TabIndex = 3;
            LabelAmountOwed.Text = "Amount Owed:";
            // 
            // ComboBoxSuppliers
            // 
            ComboBoxSuppliers.FormattingEnabled = true;
            ComboBoxSuppliers.Location = new Point(113, 19);
            ComboBoxSuppliers.Name = "ComboBoxSuppliers";
            ComboBoxSuppliers.Size = new Size(153, 23);
            ComboBoxSuppliers.TabIndex = 2;
            // 
            // LabelSuppliers
            // 
            LabelSuppliers.AutoSize = true;
            LabelSuppliers.Location = new Point(6, 27);
            LabelSuppliers.Name = "LabelSuppliers";
            LabelSuppliers.Size = new Size(58, 15);
            LabelSuppliers.TabIndex = 0;
            LabelSuppliers.Text = "Suppliers:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(664, 271);
            dataGridView1.TabIndex = 1;
            // 
            // GroupBoxOutputSupplier
            // 
            GroupBoxOutputSupplier.Controls.Add(dataGridView1);
            GroupBoxOutputSupplier.Location = new Point(12, 223);
            GroupBoxOutputSupplier.Name = "GroupBoxOutputSupplier";
            GroupBoxOutputSupplier.Size = new Size(676, 299);
            GroupBoxOutputSupplier.TabIndex = 2;
            GroupBoxOutputSupplier.TabStop = false;
            GroupBoxOutputSupplier.Text = "Supplier List";
            // 
            // GroupBoxNotes
            // 
            GroupBoxNotes.Controls.Add(RichTextBoxNotes);
            GroupBoxNotes.Location = new Point(322, 12);
            GroupBoxNotes.Name = "GroupBoxNotes";
            GroupBoxNotes.Size = new Size(366, 205);
            GroupBoxNotes.TabIndex = 3;
            GroupBoxNotes.TabStop = false;
            GroupBoxNotes.Text = "Notes";
            // 
            // RichTextBoxNotes
            // 
            RichTextBoxNotes.Location = new Point(6, 19);
            RichTextBoxNotes.Name = "RichTextBoxNotes";
            RichTextBoxNotes.Size = new Size(334, 180);
            RichTextBoxNotes.TabIndex = 0;
            RichTextBoxNotes.Text = "";
            RichTextBoxNotes.TextChanged += RichTextBoxNotes_TextChanged;
            // 
            // Tag
            // 
            Tag.AutoSize = true;
            Tag.Location = new Point(-2, 520);
            Tag.Name = "Tag";
            Tag.Size = new Size(127, 15);
            Tag.TabIndex = 4;
            Tag.Text = "Created By Avi | V 1.0.0";
            // 
            // SupplierScore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 534);
            Controls.Add(Tag);
            Controls.Add(GroupBoxNotes);
            Controls.Add(GroupBoxOutputSupplier);
            Controls.Add(GroupBoxInput);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SupplierScore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Supplier Score";
            Load += SupplierScore_Load;
            GroupBoxInput.ResumeLayout(false);
            GroupBoxInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownAmountOwed).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            GroupBoxOutputSupplier.ResumeLayout(false);
            GroupBoxNotes.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GroupBoxInput;
        private Label LabelSuppliers;
        private NumericUpDown NumericUpDownAmountOwed;
        private Label LabelAmountOwed;
        private ComboBox ComboBoxSuppliers;
        private Label LabelBusinessSize;
        private ComboBox ComboBoxBusinessSize;
        private DateTimePicker DateTimePickerDueDate;
        private Label LabelDueDate;
        private Button ButtonCalculate;
        private DataGridView dataGridView1;
        private GroupBox GroupBoxOutputSupplier;
        private GroupBox GroupBoxNotes;
        private Label LabelInvoiceID;
        private TextBox TextBoxInvoiceID;
        private RichTextBox RichTextBoxNotes;
        private Button ButtonRemove;
        private Button ButtonEdit;
        private Label Tag;
    }
}
