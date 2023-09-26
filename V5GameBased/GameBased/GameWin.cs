using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace GameBased
{
    public partial class GameWin : Form
    {
        DataBase1 db1 = new DataBase1();
        Thread th;
        public GameWin()
        {
            InitializeComponent();
        }

        private void GameWin_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = StaticData.explanationgamewin;
        }

        private void btnnewgame_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `skills` SET `Status`=0 WHERE 1", db1.GetConnection());
            MySqlCommand command1 = new MySqlCommand("UPDATE `player` SET `Endurance`=100,`Level`=1,`Experiense`=0,`SkillPoint`=2,`Points_pursuit`=0,`Money`=16000,`CostExpLevelUP`=1000,LoseAttack=0,gamewin=0", db1.GetConnection());
            db1.OpenConnection();
            command.ExecuteNonQuery();
            command1.ExecuteNonQuery();
            db1.CloseConnection();

            this.Close();
            th = new Thread(openForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void openForm1()
        {
            Application.Run(new Form1());
        }

        private void btncontinuegame_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `player` SET gamewin=1 ", db1.GetConnection());
            db1.OpenConnection();
            command.ExecuteNonQuery();
            db1.CloseConnection();
            this.Close();
            th = new Thread(openForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
