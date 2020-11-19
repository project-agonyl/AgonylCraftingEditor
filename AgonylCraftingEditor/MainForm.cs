using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace AgonylCraftingEditor
{
    public partial class MainForm : Form
    {
        public BindingList<CraftFormula> craftFormulaList;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Utils.GetMyDirectory() + Path.DirectorySeparatorChar + "IT0.txt"))
            {
                _ = MessageBox.Show("Please place IT0.txt in same folder as this application", "Agonyl Crafting Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (!File.Exists(Utils.GetMyDirectory() + Path.DirectorySeparatorChar + "IT1.txt"))
            {
                _ = MessageBox.Show("Please place IT1.txt in same folder as this application", "Agonyl Crafting Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (!File.Exists(Utils.GetMyDirectory() + Path.DirectorySeparatorChar + "IT2.txt"))
            {
                _ = MessageBox.Show("Please place IT2.txt in same folder as this application", "Agonyl Crafting Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (!File.Exists(Utils.GetMyDirectory() + Path.DirectorySeparatorChar + "IT3.txt"))
            {
                _ = MessageBox.Show("Please place IT3.txt in same folder as this application", "Agonyl Crafting Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            Utils.LoadItemData();
            this.craftFormulaList = new BindingList<CraftFormula>();
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.DataSource = this.craftFormulaList;
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "OutcomeName",
                Name = "Outcome",
                Width = 100,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SuccessRate",
                Name = "Success",
                Width = 50,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName1",
                Name = "Item 1",
                Width = 75,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName2",
                Name = "Item 2",
                Width = 75,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName3",
                Name = "Item 3",
                Width = 75,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName4",
                Name = "Item 4",
                Width = 100,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName5",
                Name = "Item 5",
                Width = 100,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName6",
                Name = "Item 6",
                Width = 100,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName7",
                Name = "Item 7",
                Width = 100,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName8",
                Name = "Item 8",
                Width = 100,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName9",
                Name = "Item 9",
                Width = 100,
            });
            this.dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ItemName10",
                Name = "Item 10",
                Width = 100,
            });
        }

        private void dataGridView_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the Data format of the file(s) can be accepted
            // (we only accept file drops from Windows Explorer, etc.)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // modify the drag drop effects to Move
                e.Effect = DragDropEffects.All;
            }
            else
            {
                // no need for any drag drop effect
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridView_DragDrop(object sender, DragEventArgs e)
        {
            // still check if the associated data from the file(s) can be used for this purpose
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Fetch the file(s) names with full path here to be processed
                var fileList = (string[])e.Data.GetData(DataFormats.FileDrop);
                this.LoadData(fileList[0]);
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = this.dataGridView.Rows[e.RowIndex].Index;
            var form = new CraftFormulaEditForm(this, dataIndexNo);
            form.ShowDialog();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var form = new CraftFormulaEditForm(this);
            form.ShowDialog();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.LoadData(openFileDialog.FileName);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.craftFormulaList.Count == 0)
            {
                _ = MessageBox.Show("Combination list is empty", "Agonyl Crafting Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                var dataBuilder = new BinaryDataBuilder();
                foreach (var item in this.craftFormulaList)
                {
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Item1));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Item2));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Item3));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Item4));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Item5));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Item6));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Item7));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Item8));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Item9));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Item10));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.SuccessRate));
                    dataBuilder.PutBytes(BitConverter.GetBytes(item.Outcome));
                    dataBuilder.PutBytes(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                }

                File.WriteAllBytes(saveFileDialog.FileName, dataBuilder.GetBuffer());
                _ = MessageBox.Show("Saved the file " + Path.GetFileName(saveFileDialog.FileName), "Agonyl Crafting Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadData(string file)
        {
            // Load data into grid
            var dataFile = File.ReadAllBytes(file);
            this.craftFormulaList.Clear();
            for (var i = 0; i < dataFile.Length; i += 32)
            {
                this.craftFormulaList.Add(new CraftFormula()
                {
                    Item1 = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i)),
                    ItemName1 = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i))),
                    Item2 = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 2)),
                    ItemName2 = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 2))),
                    Item3 = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 4)),
                    ItemName3 = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 4))),
                    Item4 = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 6)),
                    ItemName4 = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 6))),
                    Item5 = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 8)),
                    ItemName5 = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 8))),
                    Item6 = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 10)),
                    ItemName6 = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 10))),
                    Item7 = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 12)),
                    ItemName7 = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 12))),
                    Item8 = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 14)),
                    ItemName8 = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 14))),
                    Item9 = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 16)),
                    ItemName9 = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 16))),
                    Item10 = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 18)),
                    ItemName10 = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 18))),
                    SuccessRate = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 20)),
                    Outcome = Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 22)),
                    OutcomeName = Utils.GetItemName(Utils.BytesToUInt16(Utils.SkipAndTakeLinqShim(ref dataFile, 2, i + 22))),
                });
            }

            _ = MessageBox.Show("Loaded " + this.craftFormulaList.Count + " crafting combinations", "Agonyl Craft Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
