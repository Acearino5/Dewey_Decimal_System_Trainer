using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace DeweyDecimalSystemTrainer.Forms
{
    public partial class ReplacingBooksLeaderboard : Form
    {


        //userdetails object
        Details userDetails = new Details();

        public ReplacingBooksLeaderboard()
        {
            InitializeComponent();
            userDetails = userDetails.Instance();
        }



        private void Leaderboard_Load(object sender, EventArgs e)
        {
            //calls methods
            getLeaderboard();
            StyleDatagridview();

        }

        private void backButton1_Click(object sender, EventArgs e)
        {

            //sends user to Identifying Area form and passes username
            ReplacingBooks next = new ReplacingBooks();
            this.Hide();
            next.StartPosition = FormStartPosition.Manual;
            next.Location = new Point(this.Location.X, this.Location.Y);
            next.ShowDialog();
            this.Close();
        }

        //styles datagridview for leaderboard
        void StyleDatagridview()
        {

            leaderboardDataGridView.BorderStyle = BorderStyle.None;
            leaderboardDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            leaderboardDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            leaderboardDataGridView.DefaultCellStyle.SelectionBackColor = Color.MediumSlateBlue;//grid color
            leaderboardDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            leaderboardDataGridView.BackgroundColor = Color.FromArgb(30, 30, 30);
            leaderboardDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional
            leaderboardDataGridView.EnableHeadersVisualStyles = false;
            leaderboardDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            leaderboardDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            leaderboardDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            leaderboardDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        public void getLeaderboard()
        {
            SQLiteConnection con = userDetails.getConnection();
            //opens connection to SQLite DB
            try
            {

                con.Open();
                Console.WriteLine("Opened");
            }
            catch (Exception)
            {
                Console.WriteLine("DB con error");
            }

            SQLiteDataReader dataReader;

            SQLiteCommand command = con.CreateCommand();

            //selects top 10 user information based on wins
            command.CommandText = "SELECT Username,ReplaceWins,ReplaceLoses FROM UserInfo ORDER BY ReplaceWins DESC LIMIT 10";

            dataReader = command.ExecuteReader();

            //adds selected values to datagridview
            while (dataReader.Read())
            {
                leaderboardDataGridView.Rows.Add(new object[] {
                dataReader.GetValue(0),
                dataReader.GetValue(1),
                dataReader.GetValue(2)
                });
            }

            con.Close();

        }


    }



}
//------------------------------End Of File---------------------------------------//