using System;
using System.Windows.Forms;

namespace AgonylCraftingEditor
{
    public partial class CraftFormulaEditForm : Form
    {
        private MainForm _parent;
        private int _craftFormulaIndex;

        public CraftFormulaEditForm(MainForm parent, int craftFormulaIndex = -1)
        {
            InitializeComponent();
            this._parent = parent;
            this._craftFormulaIndex = craftFormulaIndex;
        }

        private void CraftFormulaEditForm_Load(object sender, EventArgs e)
        {
            this.item1.DisplayMember = "Name";
            this.item1.ValueMember = "Id";
            this.item2.DisplayMember = "Name";
            this.item2.ValueMember = "Id";
            this.item3.DisplayMember = "Name";
            this.item3.ValueMember = "Id";
            this.item4.DisplayMember = "Name";
            this.item4.ValueMember = "Id";
            this.item5.DisplayMember = "Name";
            this.item5.ValueMember = "Id";
            this.item6.DisplayMember = "Name";
            this.item6.ValueMember = "Id";
            this.item7.DisplayMember = "Name";
            this.item7.ValueMember = "Id";
            this.item8.DisplayMember = "Name";
            this.item8.ValueMember = "Id";
            this.item9.DisplayMember = "Name";
            this.item9.ValueMember = "Id";
            this.item10.DisplayMember = "Name";
            this.item10.ValueMember = "Id";
            this.outcome.DisplayMember = "Name";
            this.outcome.ValueMember = "Id";
            var currentIndex = 0;
            foreach (var item in Utils.ItemList)
            {
                this.item1.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Item1 == item.Key)
                {
                    this.item1.SelectedIndex = currentIndex;
                }

                this.item2.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Item2 == item.Key)
                {
                    this.item2.SelectedIndex = currentIndex;
                }

                this.item3.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Item3 == item.Key)
                {
                    this.item3.SelectedIndex = currentIndex;
                }

                this.item4.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Item4 == item.Key)
                {
                    this.item4.SelectedIndex = currentIndex;
                }

                this.item5.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Item5 == item.Key)
                {
                    this.item5.SelectedIndex = currentIndex;
                }

                this.item6.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Item6 == item.Key)
                {
                    this.item6.SelectedIndex = currentIndex;
                }

                this.item7.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Item7 == item.Key)
                {
                    this.item7.SelectedIndex = currentIndex;
                }

                this.item8.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Item8 == item.Key)
                {
                    this.item8.SelectedIndex = currentIndex;
                }

                this.item9.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Item9 == item.Key)
                {
                    this.item9.SelectedIndex = currentIndex;
                }

                this.item10.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Item10 == item.Key)
                {
                    this.item10.SelectedIndex = currentIndex;
                }

                this.outcome.Items.Add(item.Value);
                if (this._craftFormulaIndex != -1 && this._parent.craftFormulaList[this._craftFormulaIndex].Outcome == item.Key)
                {
                    this.outcome.SelectedIndex = currentIndex;
                }

                currentIndex++;
            }

            if (this._craftFormulaIndex == -1)
            {
                this.successRate.Text = "0";
            }
            else
            {
                this.successRate.Text = this._parent.craftFormulaList[this._craftFormulaIndex].SuccessRate.ToString();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.item1.SelectedIndex == -1 || this.item2.SelectedIndex == -1
                || this.item3.SelectedIndex == -1 || this.item4.SelectedIndex == -1
                || this.item5.SelectedIndex == -1 || this.item6.SelectedIndex == -1
                || this.item7.SelectedIndex == -1 || this.item8.SelectedIndex == -1
                || this.item9.SelectedIndex == -1 || this.item10.SelectedIndex == -1
                || this.outcome.SelectedIndex == -1
                )
            {
                _ = MessageBox.Show("Please fill all fields. Choose (Empty) if item is not required", "Agonyl Crafting Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!ushort.TryParse(this.successRate.Text, out _))
            {
                _ = MessageBox.Show("Invalid success rate!", "Agonyl Crafting Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var rate = ushort.Parse(this.successRate.Text);
                if (rate == 0 || rate > 120)
                {
                    _ = MessageBox.Show("Incorrect success rate!", "Agonyl Crafting Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var It1 = (Item)this.item1.SelectedItem;
                    var ItName1 = Utils.GetItemName(It1.Id);
                    var It2 = (Item)this.item2.SelectedItem;
                    var ItName2 = Utils.GetItemName(It2.Id);
                    var It3 = (Item)this.item3.SelectedItem;
                    var ItName3 = Utils.GetItemName(It3.Id);
                    var It4 = (Item)this.item4.SelectedItem;
                    var ItName4 = Utils.GetItemName(It4.Id);
                    var It5 = (Item)this.item5.SelectedItem;
                    var ItName5 = Utils.GetItemName(It5.Id);
                    var It6 = (Item)this.item6.SelectedItem;
                    var ItName6 = Utils.GetItemName(It6.Id);
                    var It7 = (Item)this.item7.SelectedItem;
                    var ItName7 = Utils.GetItemName(It7.Id);
                    var It8 = (Item)this.item8.SelectedItem;
                    var ItName8 = Utils.GetItemName(It8.Id);
                    var It9 = (Item)this.item9.SelectedItem;
                    var ItName9 = Utils.GetItemName(It9.Id);
                    var It10 = (Item)this.item10.SelectedItem;
                    var ItName10 = Utils.GetItemName(It10.Id);
                    var outi = (Item)this.outcome.SelectedItem;
                    var outName = Utils.GetItemName(outi.Id);
                    if (this._craftFormulaIndex == -1)
                    {
                        this._parent.craftFormulaList.Add(new CraftFormula()
                        {
                            Item1 = It1.Id,
                            ItemName1 = ItName1,
                            Item2 = It2.Id,
                            ItemName2 = ItName2,
                            Item3 = It3.Id,
                            ItemName3 = ItName3,
                            Item4 = It4.Id,
                            ItemName4 = ItName4,
                            Item5 = It5.Id,
                            ItemName5 = ItName5,
                            Item6 = It6.Id,
                            ItemName6 = ItName6,
                            Item7 = It7.Id,
                            ItemName7 = ItName7,
                            Item8 = It8.Id,
                            ItemName8 = ItName8,
                            Item9 = It9.Id,
                            ItemName9 = ItName9,
                            Item10 = It10.Id,
                            ItemName10 = ItName10,
                            SuccessRate = ushort.Parse(this.successRate.Text),
                            Outcome = outi.Id,
                            OutcomeName = outName,
                        });
                    }
                    else
                    {
                        this._parent.craftFormulaList[this._craftFormulaIndex].Item1 = It1.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].ItemName1 = ItName1;
                        this._parent.craftFormulaList[this._craftFormulaIndex].Item2 = It2.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].ItemName2 = ItName2;
                        this._parent.craftFormulaList[this._craftFormulaIndex].Item3 = It3.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].ItemName3 = ItName3;
                        this._parent.craftFormulaList[this._craftFormulaIndex].Item4 = It4.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].ItemName4 = ItName4;
                        this._parent.craftFormulaList[this._craftFormulaIndex].Item5 = It5.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].ItemName5 = ItName5;
                        this._parent.craftFormulaList[this._craftFormulaIndex].Item6 = It6.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].ItemName6 = ItName6;
                        this._parent.craftFormulaList[this._craftFormulaIndex].Item7 = It7.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].ItemName7 = ItName7;
                        this._parent.craftFormulaList[this._craftFormulaIndex].Item8 = It8.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].ItemName8 = ItName8;
                        this._parent.craftFormulaList[this._craftFormulaIndex].Item9 = It9.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].ItemName9 = ItName9;
                        this._parent.craftFormulaList[this._craftFormulaIndex].Item10 = It10.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].ItemName10 = ItName10;
                        this._parent.craftFormulaList[this._craftFormulaIndex].SuccessRate = ushort.Parse(this.successRate.Text);
                        this._parent.craftFormulaList[this._craftFormulaIndex].Outcome = outi.Id;
                        this._parent.craftFormulaList[this._craftFormulaIndex].OutcomeName = outName;
                    }

                    this.Close();
                }
            }
        }
    }
}
