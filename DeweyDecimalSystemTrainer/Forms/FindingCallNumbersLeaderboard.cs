﻿using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace DeweyDecimalSystemTrainer.Forms
{
    public partial class FindingCallNumbersLeaderboard : Form
    {
        //userdetails object
        Details userDetails = new Details();

        public FindingCallNumbersLeaderboard()
        {
            InitializeComponent();
            userDetails = userDetails.Instance();
        }

        private void FindingCallNumbersLeaderboard_Load(object sender, EventArgs e)
        {
            //calls methods on page load
            getLeaderboard();
            StyleDatagridview();
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            //sends user to Identifying Area form and passes username
            FindingCallNumbers next = new FindingCallNumbers();
            this.Hide();
            next.StartPosition = FormStartPosition.Manual;
            next.Location = new Point(this.Location.X, this.Location.Y);
            next.ShowDialog();
            this.Close();
        }

        //styles datagridview for leaderboard
        void StyleDatagridview()
        {

            IdentifyLeaderboardDataGridView.BorderStyle = BorderStyle.None;
            IdentifyLeaderboardDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            IdentifyLeaderboardDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            IdentifyLeaderboardDataGridView.DefaultCellStyle.SelectionBackColor = Color.MediumSlateBlue;//grid color
            IdentifyLeaderboardDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            IdentifyLeaderboardDataGridView.BackgroundColor = Color.FromArgb(30, 30, 30);
            IdentifyLeaderboardDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional
            IdentifyLeaderboardDataGridView.EnableHeadersVisualStyles = false;
            IdentifyLeaderboardDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            IdentifyLeaderboardDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            IdentifyLeaderboardDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            IdentifyLeaderboardDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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
            command.CommandText = "SELECT Username,FindingCallWins,FindingCallLoses FROM UserInfo ORDER BY FindingCallWins DESC LIMIT 10";

            dataReader = command.ExecuteReader();

            //adds selected values to datagridview
            while (dataReader.Read())
            {
                IdentifyLeaderboardDataGridView.Rows.Add(new object[] {
                dataReader.GetValue(0),
                dataReader.GetValue(1),
                dataReader.GetValue(2)
                });
            }

            con.Close();

        }

    }
}
