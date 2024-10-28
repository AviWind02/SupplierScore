using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SupplierScore
{
    public partial class SupplierScore : Form
    {
        private string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SupplierScore");
        private string filePathForSuppliers = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SupplierScore", "suppliers.txt");
        private string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SupplierScore", "SupplierScore.log");
        private string csvPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SupplierScore", "suppliers.csv");

        private ToolTip toolTipAmountOwed = new ToolTip();
        private bool isEditing = false;
        private string editingInvoiceId = "";

        public SupplierScore()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadSuppliers();
            dataGridView1.CellClick += dataGridView1_CellClick;

            toolTipAmountOwed.SetToolTip(NumericUpDownAmountOwed, "Amount owed (excluding VAT)");
        }

        private void SupplierScore_Load(object sender, EventArgs e)
        {
            ComboBoxBusinessSize.Items.AddRange(new string[] { "Small", "Medium", "Large" });

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

                MessageBox.Show("Looks like this may be the first time using this app. Created by the Indian. If you find any issues, *DONT* WhatsApp me for assistance!",
                                "Welcome to Supplier Score",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LogAction("Created folder for first-time use.");
            }

            if (File.Exists(filePathForSuppliers))
            {
                var supplierNames = File.ReadAllLines(filePathForSuppliers);
                ComboBoxSuppliers.Items.AddRange(supplierNames);
            }

            try
            {
                LoadDataFromCSV();

                // Start up sort after loading
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                dataGridView1.Sort(dataGridView1.Columns[5], System.ComponentModel.ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                LogAction($"Error loading CSV: {ex.Message}");
                MessageBox.Show($"Error loading CSV: {ex.Message}");
            }
        }

        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Invoice ID";
            dataGridView1.Columns[1].Name = "Supplier Name";
            dataGridView1.Columns[2].Name = "Amount Owed";
            dataGridView1.Columns[3].Name = "Business Size";
            dataGridView1.Columns[4].Name = "Due Date";
            dataGridView1.Columns[5].Name = "Score";
        }

        private void LoadSuppliers()
        {
            List<string> suppliers = new List<string>()
            {
                "Anglian Chem", "RM Cellar", "Laundry Liv-in", "Broadland Windows", "Chapel Doors", "OOTG", "Cooks", "Genie", "SSS", "Southeast"
            };

            ComboBoxSuppliers.Items.AddRange(suppliers.ToArray());

            if (File.Exists(filePathForSuppliers))
            {
                var fileSuppliers = File.ReadAllLines(filePathForSuppliers);
                foreach (var supplier in fileSuppliers)
                {
                    if (!suppliers.Contains(supplier))
                    {
                        ComboBoxSuppliers.Items.Add(supplier);
                    }
                }
            }
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            string supplierName = ComboBoxSuppliers.Text;
            decimal amountOwed = NumericUpDownAmountOwed.Value;
            string businessSize = ComboBoxBusinessSize.Text;
            DateTime dueDate = DateTimePickerDueDate.Value;
            string invoiceId = TextBoxInvoiceID.Text;
            string notes = RichTextBoxNotes.Text;

            if (string.IsNullOrEmpty(invoiceId) || string.IsNullOrEmpty(supplierName) || string.IsNullOrEmpty(businessSize) || string.IsNullOrEmpty(notes))
            {
                MessageBox.Show("Please fill out all fields, including Invoice ID and Notes.");
                return;
            }

            try
            {
                int score = CalculateScore(amountOwed, businessSize, dueDate);

                dataGridView1.Rows.Add(invoiceId, supplierName, amountOwed, businessSize, dueDate.ToShortDateString(), score);

                SaveSupplierName(supplierName);
                LogAction($"Calculated score for Invoice ID: {invoiceId}");

                SaveDataToCSV(invoiceId, supplierName, amountOwed, businessSize, dueDate, score, notes);
            }
            catch (Exception ex)
            {
                LogAction($"Error during calculation or saving: {ex.Message}");
                MessageBox.Show($"Error during calculation or saving: {ex.Message}");
            }
        }

        private int CalculateScore(decimal amountOwed, string businessSize, DateTime dueDate)
        {
            int score = 0;

            if (amountOwed > 200)
            {
                score += 10;
            }
            else if (amountOwed > 100)
            {
                score += 8;
            }
            else
            {
                score += 5;
            }

            switch (businessSize)
            {
                case "Large":
                    score += 9;
                    break;
                case "Medium":
                    score += 5;
                    break;
                case "Small":
                    score += 3;
                    break;
            }

            if (dueDate < DateTime.Now)
            {
                score += 20;
            }
            else if ((dueDate - DateTime.Now).Days <= 7)
            {
                score += 18;
            }
            else if ((dueDate - DateTime.Now).Days <= 14)
            {
                score += 12;
            }
            else
            {
                score += 5;
            }

            return score;
        }

        private void SaveSupplierName(string supplierName)
        {
            try
            {
                if (File.Exists(filePathForSuppliers))
                {
                    var existingNames = File.ReadAllLines(filePathForSuppliers);
                    if (existingNames.Contains(supplierName)) return;
                }

                File.AppendAllText(filePathForSuppliers, supplierName + Environment.NewLine);
                LogAction($"Saved supplier name: {supplierName}");
            }
            catch (Exception ex)
            {
                LogAction($"Error saving supplier name: {ex.Message}");
                MessageBox.Show($"Error saving supplier name: {ex.Message}");
            }
        }

        private void LogAction(string logMessage)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {logMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing log: {ex.Message}");
            }
        }

        private void SaveDataToCSV(string invoiceId, string supplierName, decimal amountOwed, string businessSize, DateTime dueDate, int score, string notes)
        {
            try
            {
                bool fileExists = File.Exists(csvPath);
                using (StreamWriter writer = new StreamWriter(csvPath, true))
                {
                    if (!fileExists)
                    {
                        writer.WriteLine("Invoice ID,Supplier Name,Amount Owed,Business Size,Due Date,Score,Notes");
                    }

                    // Save raw notes, no escaping or special handling of newlines or quotes
                    writer.WriteLine($"\"{invoiceId}\",\"{supplierName}\",\"{amountOwed}\",\"{businessSize}\",\"{dueDate.ToShortDateString()}\",\"{score}\",\"{notes}\"");
                }
                LogAction($"Saved data for Invoice ID: {invoiceId}");
            }
            catch (IOException ex) when (IsFileLocked(ex))
            {
                MessageBox.Show("CSV file is open in another program. Please close it and try again.");
                LogAction("CSV file is open, waiting for it to be closed.");
                WaitForFileToClose(csvPath);
            }
            catch (Exception ex)
            {
                LogAction($"Error saving to CSV: {ex.Message}");
                MessageBox.Show($"Error saving to CSV: {ex.Message}");
            }
        }


        private void LoadDataFromCSV()
        {
            if (!File.Exists(csvPath))
            {
                LogAction("No CSV file found at startup.");
                return;
            }
            try
            {
                using (TextFieldParser parser = new TextFieldParser(csvPath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    if (!parser.EndOfData)
                    {
                        parser.ReadFields(); // Skip header row
                    }

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        // Add data to the DataGridView, ensuring valid Invoice ID is present
                        if (fields.Length >= 6 && !string.IsNullOrWhiteSpace(fields[0]))
                        {
                            dataGridView1.Rows.Add(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5]);
                        }
                    }
                }
                LogAction("CSV data loaded successfully.");
            }
            catch (IOException ex) when (IsFileLocked(ex))
            {
                MessageBox.Show("CSV file is open in another program. Please close it and try again.");
                LogAction("CSV file is open, waiting for it to be closed.");
                WaitForFileToClose(csvPath);
                LoadDataFromCSV();  // Retry after file is closed
            }
            catch (Exception ex)
            {
                LogAction($"Error loading CSV: {ex.Message}");
                MessageBox.Show($"Error loading CSV: {ex.Message}");
            }
        }

        private bool IsFileLocked(IOException ioEx)
        {
            return ioEx.Message.Contains("being used by another process");
        }

        private void WaitForFileToClose(string filePath)
        {
            while (true)
            {
                try
                {
                    using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        fs.Close();
                    }
                    break;
                }
                catch (IOException)
                {
                    System.Threading.Thread.Sleep(1000);  // Wait for 1 second before retrying
                }
            }
        }

        private string LoadNotesFromCSV(string invoiceId)
        {
            if (!File.Exists(csvPath))
            {
                return "No notes found.";
            }

            string notes = "";

            try
            {
                using (StreamReader reader = new StreamReader(csvPath))
                {
                    string line;
                    bool found = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Invoice ID"))
                        {
                            continue; // Skip the header row
                        }

                        string[] fields = line.Split(new[] { ',' }, 7); // Ensure splitting handles up to the "Notes" field

                        if (fields[0] == invoiceId)
                        {
                            // Load notes exactly as they are, no special handling for quotes or newlines
                            string rawNotes = fields[fields.Length - 1];

                            if (string.IsNullOrWhiteSpace(rawNotes))
                            {
                                return "No notes found.";
                            }

                            notes = rawNotes;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        notes = "No notes found for this Invoice ID.";
                    }
                }
            }
            catch (Exception ex)
            {
                LogAction($"Error loading notes: {ex.Message}");
                MessageBox.Show($"Error loading notes: {ex.Message}");
            }

            return notes;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    string invoiceId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string supplierName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                    string notes = LoadNotesFromCSV(invoiceId);

                    RichTextBoxNotes.Text = $"View notes for ID | {supplierName}\n{notes}";
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];

                    TextBoxInvoiceID.Text = row.Cells[0].Value.ToString();
                    ComboBoxSuppliers.Text = row.Cells[1].Value.ToString();
                    NumericUpDownAmountOwed.Value = Convert.ToDecimal(row.Cells[2].Value);
                    ComboBoxBusinessSize.Text = row.Cells[3].Value.ToString();
                    DateTimePickerDueDate.Value = Convert.ToDateTime(row.Cells[4].Value);
                    RichTextBoxNotes.Text = LoadNotesFromCSV(row.Cells[0].Value.ToString());

                    isEditing = true;
                    editingInvoiceId = row.Cells[0].Value.ToString();
                    ButtonEdit.Text = "Done";
                    ButtonCalculate.Enabled = false;
                    MessageBox.Show("You are now editing the selected item. Modify the fields and click 'Done' to save changes.");
                }
                else
                {
                    MessageBox.Show("Please select a row to edit.");
                }
            }
            else
            {
                try
                {
                    SaveChangesToCSV(editingInvoiceId);

                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        DataGridViewRow row = dataGridView1.SelectedRows[0];
                        row.Cells[0].Value = TextBoxInvoiceID.Text;
                        row.Cells[1].Value = ComboBoxSuppliers.Text;
                        row.Cells[2].Value = NumericUpDownAmountOwed.Value.ToString();
                        row.Cells[3].Value = ComboBoxBusinessSize.Text;
                        row.Cells[4].Value = DateTimePickerDueDate.Value.ToShortDateString();
                        row.Cells[5].Value = CalculateScore(NumericUpDownAmountOwed.Value, ComboBoxBusinessSize.Text, DateTimePickerDueDate.Value).ToString();
                    }

                    ResetInputFields();
                    isEditing = false;
                    ButtonEdit.Text = "Edit";
                    ButtonCalculate.Enabled = true;

                    MessageBox.Show("Changes have been saved successfully.");
                }
                catch (Exception ex)
                {
                    LogAction($"Error saving changes: {ex.Message}");
                    MessageBox.Show($"Error saving changes: {ex.Message}");
                }
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string invoiceId = row.Cells[0].Value.ToString();

                try
                {
                    dataGridView1.Rows.Remove(row);
                    RemoveFromCSV(invoiceId);
                    ResetInputFields();
                    MessageBox.Show("The selected item has been removed.");
                }
                catch (Exception ex)
                {
                    LogAction($"Error removing item: {ex.Message}");
                    MessageBox.Show($"Error removing item: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to remove.");
            }
        }

        private void ResetInputFields()
        {
            TextBoxInvoiceID.Text = "";
            ComboBoxSuppliers.Text = "";
            NumericUpDownAmountOwed.Value = 0;
            ComboBoxBusinessSize.Text = "";
            DateTimePickerDueDate.Value = DateTime.Now;
            RichTextBoxNotes.Text = "";
        }

        private void RemoveFromCSV(string invoiceId)
        {
            try
            {
                if (File.Exists(csvPath))
                {
                    var lines = File.ReadAllLines(csvPath).Where(line => !line.StartsWith(invoiceId)).ToList();
                    File.WriteAllLines(csvPath, lines);
                    LogAction($"Removed Invoice ID: {invoiceId} from CSV.");
                }
            }
            catch (Exception ex)
            {
                LogAction($"Error removing from CSV: {ex.Message}");
                MessageBox.Show($"Error removing from CSV: {ex.Message}");
            }
        }

        private void SaveChangesToCSV(string originalInvoiceId)
        {
            try
            {
                if (File.Exists(csvPath))
                {
                    var lines = File.ReadAllLines(csvPath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].StartsWith(originalInvoiceId))
                        {
                            string updatedLine = $"{TextBoxInvoiceID.Text},{ComboBoxSuppliers.Text},{NumericUpDownAmountOwed.Value},{ComboBoxBusinessSize.Text},{DateTimePickerDueDate.Value.ToShortDateString()},{CalculateScore(NumericUpDownAmountOwed.Value, ComboBoxBusinessSize.Text, DateTimePickerDueDate.Value)},{RichTextBoxNotes.Text.Replace("\n", "\\n")}";
                            lines[i] = updatedLine;
                            break;
                        }
                    }
                    File.WriteAllLines(csvPath, lines);
                    LogAction($"Updated CSV for Invoice ID: {originalInvoiceId}");
                }
            }
            catch (Exception ex)
            {
                LogAction($"Error updating CSV: {ex.Message}");
                MessageBox.Show($"Error updating CSV: {ex.Message}");
            }
        }

        private void RichTextBoxNotes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
