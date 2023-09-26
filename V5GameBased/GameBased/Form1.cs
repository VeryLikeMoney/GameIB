using MySql.Data.MySqlClient;
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
using System.Data.SqlClient;



namespace GameBased
{
    
    public partial class Form1 : Form
    {
        DataBase1 db1 = new DataBase1();
        DataTable table = new DataTable();
        Button[] selectbtn;
        Button[] skillsbtn = new Button[5];
        Button[] skillsmain = new Button[20];
        ToolTip t = new ToolTip(); //для всплывающих описаний
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        String ts =""; //переменная для хранения и получения id скила
        Thread th;
        int selecctckillsbtn = 0;
        bool skillwin=false;//победа по прокачке

        public Form1()
        {
            InitializeComponent();     
        }
        //Кнопка для начала атаки
        private void button_attack_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        StaticData.highprobab = 510;
                        StaticData.lowlevel = 1;
                        StaticData.averagelevel = 2;
                        StaticData.averageprobab = 400;
                        StaticData.highlevel = 3;
                        StaticData.NameLevel = "легкой";
                        break;
                    case 1:
                        StaticData.highprobab = 410;
                        StaticData.lowlevel = 2;
                        StaticData.averagelevel = 3;
                        StaticData.averageprobab = 810;
                        StaticData.highlevel = 4;
                        StaticData.NameLevel = "средней";
                        break;
                    case 2:
                        StaticData.highprobab = 200;
                        StaticData.lowlevel = 3;
                        StaticData.averagelevel = 4;
                        StaticData.averageprobab = 750;
                        StaticData.highlevel = 5;
                        StaticData.NameLevel = "сложной";
                        break;

                }
                if (selectbtn != null)
                {
                    StaticData.selectskillslen = selecctckillsbtn;
                    for (int i = 0; i < selecctckillsbtn; i++)
                    {
                        StaticData.selectbtn[i] = selectbtn[i];
                    }
                    this.Close();
                    th = new Thread(openAttackForm);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
            }
            else
            {
                MessageBox.Show("Выберите уровень");
            }
                  
        }
        //функция открытия формы атаки
        public void openAttackForm()
        {
            Application.Run(new AttackForm());
        }
        //функция загрыщки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            selectbtn = null;    
            BDupdate();
            tooltipmainmenu();
        }
        //функция взаимодействия с кнопками скилов
        private void skill5_Click(object sender,  EventArgs e)
        {
            int statusskills=0;
            int costskills = 0;
            int costskillspoint = 0;

           
            Button btn = sender as Button;
            ts = btn.Name;
            ts=ts.Replace("skill", "");
            MySqlCommand command2 = new MySqlCommand("SELECT cost_table.valiecost FROM cost_table LEFT JOIN skills ON (cost_table.id_cost=skills.id_cost) WHERE skills.id=" + ts, db1.GetConnection());
            db1.OpenConnection();
            costskills = Convert.ToInt32(command2.ExecuteScalar());
            db1.CloseConnection();
            db1.OpenConnection();
            MySqlDataReader command = new MySqlCommand("SELECT status,Level c FROM `skills` WHERE`id`=" + ts, db1.GetConnection()).ExecuteReader();
            while (command.Read())
            {
                statusskills = Convert.ToInt32(command.GetValue(0));
                costskillspoint = Convert.ToInt32(command.GetValue(1));
            }

            db1.CloseConnection();
            if (statusskills == 1)
            {
                BeginningSelectSkills(btn);
            }
            else
            {
                
                BuySkills(btn,costskills, costskillspoint);
                BDupdate();

            }
        }
        //функция покупки скилов часть 1
        private void BuySkills(Button btn, int costskills,int costskillspoint)
        {
            String ts_temp = "";
            int i = 0;
            if ((Convert.ToInt32(a_label_moneyvalue.Text) - costskills) >= 0)
            {
                if ((Convert.ToInt32(valueSkilpointlabel.Text) - costskillspoint) >= 0)
                {
                    BuySK(costskills, costskillspoint);
                    btn.BackColor = Color.Green;
                    MySqlCommand command = new MySqlCommand("UPDATE `skills` SET `status`=1  WHERE `id` =" + ts, db1.GetConnection());
                    db1.OpenConnection();
                    command.ExecuteNonQuery();
                    MySqlDataReader command1 = new MySqlCommand("SELECT Name FROM `skills` WHERE`id`=" + ts, db1.GetConnection()).ExecuteReader();
                    while (command1.Read())
                    {
                        btn.Text = Convert.ToString(command1.GetValue(0));
                    }
                    db1.CloseConnection();
                    MassivButtonAIN();
                    if (ts != "5" || ts != "10" || ts != "15" || ts != "20")
                    {
                        ts_temp = Convert.ToString(Convert.ToInt32(ts));
                        i = Convert.ToInt32(ts_temp);
                        skillsmain[i].Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Недостаточно очков умения");
                }
            }
            else
            {
                MessageBox.Show("Недостаточно средств");
            }
        }
        //Подфункция покупки скилов часть 2
        private void BuySK(int costskills,int costskillspoint)
        {
            String cost_st = Convert.ToString(Convert.ToInt32(a_label_moneyvalue.Text)-costskills);
            String costskill_st = Convert.ToString(Convert.ToInt32(valueSkilpointlabel.Text) - costskillspoint);
            if (cost_st != "0")
            {
                MySqlCommand command = new MySqlCommand("UPDATE `player` SET `Money`= " + cost_st+" ,SkillPoint="+ costskill_st, db1.GetConnection());
                db1.OpenConnection();
                command.ExecuteNonQuery();
                db1.CloseConnection();
            }
        }
        //Функция выбора скилов
        private void BeginningSelectSkills(Button btn)
             {
                if (selectbtn == null)
                selectbtn = new Button[5];
                switch (selecctckillsbtn)
                {
                    case 0:
                        selectskills1.Name = btn.Name;
                        skillsbtn[selecctckillsbtn] = btn;
                        selectbtn[selecctckillsbtn] = selectskills1;
                        selecctckillsbtn += 1;
                        SelectSkillfun(btn, selectskills1);
                        break;
                    case 1:
                         selectskills2.Name = btn.Name;
                         skillsbtn[selecctckillsbtn] = btn;
                        selectbtn[selecctckillsbtn] = selectskills2;
                        selecctckillsbtn += 1;
                        SelectSkillfun(btn, selectskills2);
                        break;
                    case 2:
                         selectskills3.Name = btn.Name;
                         skillsbtn[selecctckillsbtn] = btn;
                        selectbtn[selecctckillsbtn] = selectskills3;
                         selecctckillsbtn += 1;
                        SelectSkillfun(btn, selectskills3);
                        break;
                    case 3:
                    selectskills4.Name = btn.Name;
                    skillsbtn[selecctckillsbtn] = btn;
                        selectbtn[selecctckillsbtn] = selectskills4;
                         selecctckillsbtn += 1;
                        SelectSkillfun(btn, selectskills4);
                        break;
                    case 4:
                         selectskills5.Name = btn.Name;
                        skillsbtn[selecctckillsbtn] = btn;
                        selectbtn[selecctckillsbtn] = selectskills5;
                        selecctckillsbtn += 1;
                        SelectSkillfun(btn, selectskills5);
                        break;
                }      
        }
        //Функция выбора скилов
        private void SelectSkillfun(Button btn,Button btnselect)
        {
            btn.Enabled = false;
            btnselect.BackColor = Color.DarkGreen;
            btnselect.Text = btn.Text; 
        }
        //Функция кнопки сделать ход
        private void btn_makemove_Click(object sender, EventArgs e)
        {
            String tmp= Convert.ToString(Convert.ToInt32(a_label_moneyvalue.Text) -100);
            String tmp1= Convert.ToString(Convert.ToInt32(a_label_energyvalue.Text) +4);
            String pursuit = Convert.ToString(Convert.ToInt32(value_pointpurse.Text) - 6);
            if (Convert.ToInt32(tmp1) > 100) tmp1 = "100";
            if (Convert.ToInt32(pursuit) < 0) pursuit = "0";
            a_label_moneyvalue.Text = tmp;
            a_label_energyvalue.Text = tmp1;
            MySqlCommand command = new MySqlCommand("UPDATE `player` SET `Money` =" + tmp + ", `Endurance` ="+tmp1+ " ,Points_pursuit=" + pursuit+" WHERE `id` = 0", db1.GetConnection());
            db1.OpenConnection();
            command.ExecuteNonQuery();
            db1.CloseConnection();
            BDupdate();
        }

        //стартовая выгрузка параметров из Базы данных расчет левела и условие проигыша
        public void BDupdate()
        {
            int exp = 0 ;
            int a=0;
            int b=0;
            int c=0;
            MassivButtonAIN();
            db1.OpenConnection();
            MySqlDataReader command = new MySqlCommand("SELECT Money,Endurance,Experiense,SkillPoint,Level,	Points_pursuit,CostExpLevelUP, LoseAttack FROM `player` WHERE`id`=0", db1.GetConnection()).ExecuteReader();
            //MySqlDataReader command1 = new MySqlCommand("SELECT LoseAttack FROM `player` WHERE`id`=0", db1.GetConnection()).ExecuteReader();
            a_label_moneyvalue.Text = "1";
            value_pointpurse.Text = "0";
            while (command.Read())
            {
                a = Convert.ToInt32(command.GetValue(0));
                b= Convert.ToInt32(command.GetValue(5)); 
                a_label_moneyvalue.Text = Convert.ToString(command.GetValue(0));
                a_label_energyvalue.Text = Convert.ToString(command.GetValue(1));
                exp = Convert.ToInt32(command.GetValue(2));
                valueSkilpointlabel.Text = Convert.ToString(command.GetValue(3));
                levellable.Text = Convert.ToString(command.GetValue(4));
                value_pointpurse.Text = Convert.ToString(command.GetValue(5)); 
                progressBar1.Maximum= Convert.ToInt32(command.GetValue(6));
                c = Convert.ToInt32(command.GetValue(7));
            }
            db1.CloseConnection();
            if (exp < progressBar1.Maximum)
                progressBar1.Value = exp;
            else
            {
                do
                {
                    exp = UpdateEXP(exp);
                    richTextBox1.Text += "Level Up\n";
                    BDupdate();
                    // MessageBox.Show("LEVEL UP!!");
                } while (exp > progressBar1.Maximum);
                progressBar1.Value = exp;       
            
            }
             //a = Convert.ToInt32(a_label_moneyvalue.Text);
             //b = Convert.ToInt32(value_pointpurse.Text);
            Gameover(a,b,c);
            GameWin();
        }
        private void GameWin()
        {
            String temp;
            skillwin = true;   
            MySqlCommand command1 = new MySqlCommand("SELECT `gamewin` FROM `player`", db1.GetConnection());
            MySqlCommand command3 = new MySqlCommand("SELECT `money` FROM `player`", db1.GetConnection());
            db1.OpenConnection();
            int f = Convert.ToInt32(command3.ExecuteScalar());
            for (int i=5; i<21; i+=5 ) {
                temp = Convert.ToString(i);
                MySqlCommand command = new MySqlCommand("SELECT `Status` FROM `skills` WHERE id=" + temp, db1.GetConnection());
                if (0 == Convert.ToInt32(command.ExecuteScalar()))
                {
                    skillwin = false;
                    
                }
            }
            if (Convert.ToInt32(command1.ExecuteScalar()) !=1)
             {  
                
                if (skillwin)
                    {
                        StaticData.explanationgamewin = StaticData.gamewinskills5;
                        this.Close();
                        th = new Thread(openGameWin);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                       
                }
                 if (f > 2000000)
                 {
                        StaticData.explanationgamewin = StaticData.gamewin_money;
                        this.Close();
                        th = new Thread(openGameWin);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                        
                 }
                
            }          
            db1.CloseConnection();

            
        }

        public void openGameWin()
        {
            Application.Run(new GameWin());
        }
        //функция проигрыша
        private void Gameover(int a, int b,int c)
        {
            if (a <= 0)
            {
                StaticData.explanationgameover = StaticData.gameover_money;          
                this.Close();
                th = new Thread(openGameOver);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }else
            if (b>= 100)
            {
                StaticData.explanationgameover = StaticData.gameover_purst;
                this.Close();
                th = new Thread(openGameOver);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            if (c == 1)
            {
                StaticData.explanationgameover = StaticData.gameover_purst;
                this.Close();
                th = new Thread(openGameOver);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }
        //функция открытия формы проигрыша
        public void openGameOver()
        {
            Application.Run(new GameOverForm());
        }
        //Функция отвечающая за опыт левелап и увеличении стоимости левела
        private int UpdateEXP(int exp)
        { 
            int exptmp = Convert.ToInt32( exp - progressBar1.Maximum);
          //  if (exptmp < 0) exptmp = 0;
            String tmp = Convert.ToString(exptmp);
            String tmp1 =Convert.ToString(Convert.ToInt32(valueSkilpointlabel.Text)+1);
            String tmp2 = Convert.ToString(Convert.ToInt32(levellable.Text) + 1);
            String tmp4 = Convert.ToString(progressBar1.Maximum + Convert.ToInt32(levellable.Text)*70);
            MySqlCommand command = new MySqlCommand("UPDATE `player` SET `Experiense` =" + tmp + " ,SkillPoint="+ tmp1 + " ,Level=" + tmp2 + " ,CostExpLevelUP=" + tmp4, db1.GetConnection());
            db1.OpenConnection();
            command.ExecuteNonQuery();
            db1.CloseConnection();
            return exp- progressBar1.Maximum;
        }
        //вывод значение неотрытых скилов
        private void skill1_Layout(object sender, LayoutEventArgs e)
        {
            ToolTip t = new ToolTip();
            var btn = sender as Button;
            String ts = btn.Name;
            ts = ts.Replace("skill", "");        
            MySqlCommand command2 = new MySqlCommand("SELECT cost_table.valiecost FROM cost_table LEFT JOIN skills ON (cost_table.id_cost=skills.id_cost) WHERE skills.id=" + ts, db1.GetConnection());
            db1.OpenConnection();
            String rer=Convert.ToString(command2.ExecuteScalar());
            db1.CloseConnection();
            db1.OpenConnection();
            MySqlDataReader command = new MySqlCommand("SELECT Name,	Description,Status FROM `skills` WHERE`id`=" + ts, db1.GetConnection()).ExecuteReader();    
            while (command.Read())
                {
                    
                    t.SetToolTip(btn, Convert.ToString(command.GetValue(1))+"\n");
                if (Convert.ToInt32(command.GetValue(2)) == 1)
                {
                    btn.BackColor = Color.Green;
                    btn.Text = Convert.ToString(command.GetValue(0));

                }
                else
                {
                  btn.Text = Convert.ToString(command.GetValue(0))+"\nЦена "+ Convert.ToString(rer) +"$";
                }
                }
            db1.CloseConnection();
        }
        // отмена выбора скилов
        private void btn_selectreset_Click(object sender, EventArgs e)
        {   
            for (int i = 0; i < selecctckillsbtn; i++)
            {
                skillsbtn[i].Enabled = true;
                selectbtn[i].Text = "";
                selectbtn[i].BackColor = Color.Silver;
            }
            selecctckillsbtn = 0;
            selectbtn = null;
        }
        //призвоение кнопок скилов в масив и окрытие следующего для покупки скила;
        private void MassivButtonAIN()
        {
            int status=0;
            skillsmain[0] = skill1;
            skillsmain[1] = skill2;
            skillsmain[2] = skill3;
            skillsmain[3] = skill4;
            skillsmain[4] = skill5;
            skillsmain[5] = skill6;
            skillsmain[6] = skill7;
            skillsmain[7] = skill8;
            skillsmain[8] = skill9;
            skillsmain[9] = skill10;
            skillsmain[10] = skill11;
            skillsmain[11] = skill12;
            skillsmain[12] = skill13;
            skillsmain[13] = skill14;
            skillsmain[14] = skill15;
            skillsmain[15] = skill16;
            skillsmain[16] = skill17;
            skillsmain[17] = skill18;
            skillsmain[18] = skill19;
            skillsmain[19] = skill20;
            db1.OpenConnection();
            for (int i = 1; i < 20; i++)
            {
                String ts = "";
                db1.OpenConnection();
                ts = Convert.ToString(i);
                MySqlDataReader command = new MySqlCommand("SELECT status c FROM `skills` WHERE`id`=" + ts, db1.GetConnection()).ExecuteReader();
                while (command.Read())
                {
                    status = Convert.ToInt32(command.GetValue(0));
                }
                if (status == 1 ) skillsmain[i].Enabled = true;
                db1.CloseConnection();
            }
        }
        //описание скилов
        private void skill1_MouseEnter(object sender, EventArgs e)
        {
            
            var btn = sender as Button;
            String ts = btn.Name;
            String descriptoin = "";
            richTextBox2.Text = descriptoin;
            if (btn.Enabled)
            {
                ts = ts.Replace("skill", "");
                MySqlCommand command2 = new MySqlCommand("SELECT skills.Description FROM skills WHERE id=" + ts, db1.GetConnection());
                db1.OpenConnection();
                descriptoin = Convert.ToString(command2.ExecuteScalar());
                db1.CloseConnection();
                richTextBox2.Text = descriptoin;

            }
   
            
        }
        //отмена вывода описания скила
        private void skill1_MouseLeave(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }
        private void tooltipmainmenu()
        {
            t.SetToolTip(lbl_selectskills, "Умения выбранные для атаки");
            t.SetToolTip(a_label_money, "Денежный баланс");
            t.SetToolTip(a_label_moneyvalue, "Денежный баланс");
            t.SetToolTip(a_label_energyvalue, "Количество выносливости для дейстий при атаке");
            t.SetToolTip(a_label_energy, "Количество выносливости для дейстий при атаке");
            t.SetToolTip(label_pointpurse, "Показатель преследования праворанительными органами");
            t.SetToolTip(value_pointpurse, "Показатель преследования праворанительными органами");
            t.SetToolTip(labelOS, "Умения направленные на операционные системы");
            t.SetToolTip(labelSYBD, "Умения направленные на системы управления базами данных");
            t.SetToolTip(labelPO, "Умения направленные на програмное обеспечения");
            t.SetToolTip(labelPO, "Умения направленные на сеть и сетевые устройства");
            t.SetToolTip(label_level1, "Умения низшего потенциала угрозы");
            t.SetToolTip(label_level2, "Умения низкого потенциала угрозы");
            t.SetToolTip(label_level3, "Умения среднего потенциала угрозы");
            t.SetToolTip(label_level4, "Умения высокого потенциала угрозы");
            t.SetToolTip(label_level5, "Умения крайне высокого потенциала угрозы");
            t.SetToolTip(progressBar1, "Шкала опыта показывающая прогресс до нового уровня");
            t.SetToolTip(a_label_lvl, "Показатель текущего уровня хакера");
            t.SetToolTip(levellable, "Показатель текущего уровня хакера");
            t.SetToolTip(skilpointlabel, "Показатель очков умения на прокачку");
            t.SetToolTip(valueSkilpointlabel, "Показатель очков умения на прокачку");
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `skills` SET `Status`=0 WHERE 1", db1.GetConnection());
            MySqlCommand command1 = new MySqlCommand("UPDATE `player` SET `Endurance`=100,`Level`=1,`Experiense`=0,`SkillPoint`=2,`Points_pursuit`=0,`Money`=16000,`CostExpLevelUP`=1000,LoseAttack=0,gamewin=0 ", db1.GetConnection());
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
    }
}
