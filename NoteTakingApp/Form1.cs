using System.Data;

namespace NoteTakingApp
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public NoteTaker()
        {
            InitializeComponent();
        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previousNotes.DataSource = notes;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();    
            }
            catch(Exception ex)
            {
                Console.WriteLine("Not a valid entry");
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            titleTxtBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteTxtBx.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void newNoteBtn_Click(object sender, EventArgs e)
        {
            titleTxtBox.Text = "";
            noteTxtBx.Text = "";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = titleTxtBox.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = noteTxtBx.Text;
            }
            else
            {
                notes.Rows.Add(titleTxtBox.Text, noteTxtBx.Text);
            }
            titleTxtBox.Text = "";
            noteTxtBx.Text = "";
            editing = false;
        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleTxtBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            titleTxtBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}