using System.Data;

namespace carPro
{
    public partial class UpdateUser : Form
    {
        public UpdateUser()
        {
            InitializeComponent();
        }
        public string phoneNumber;
        private readonly MangerDb mangerD = new();
        private string stat;
        /// <summary>
        /// Handles the 'Click' event of the 'UpdateU' button, updating user information in the database.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void UpdateU_Click(object sender, EventArgs e)
        {
            CustomerClassDb db = new();
            if (db.UpdateUser(userName.Text.ToString(), EncPass.EncryptString(pass.Text), name.Text.ToString(), stat, phoneNumber, mail.Text) == true)
                phoneNumber = userName.Text;
        }
        /// <summary>
        /// Handles the 'Load' event of the 'UpdateUser' form, populating the form with user information from the database.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void UpdateUser_Load(object sender, EventArgs e)
        {

            DataTable row = mangerD.ReturnAllTable("SELECT * FROM `usertable` WHERE `phoneNumber`=" + phoneNumber);
            if (row == null)
            {
                this.Close();
                return;
            }
            name.Text = row.Rows[0].Table.Rows[0].Table.Rows[0][2].ToString();
            userName.Text = row.Rows[0].Table.Rows[0].Table.Rows[0][0].ToString();
            pass.Text = EncPass.DecryptString(row.Rows[0].Table.Rows[0].Table.Rows[0][1].ToString());
            stat = row.Rows[0].Table.Rows[0].Table.Rows[0][3].ToString();
            mail.Text = row.Rows[0].Table.Rows[0].Table.Rows[0][7].ToString();
        }
    }
}
