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
    public partial class AttackForm : Form
    {
        Thread th; //для открытия первой формы
        DataBase1 db1 = new DataBase1(); //обьект для связи с дазой дланных    
        ToolTip t = new ToolTip(); //для всплывающих описаний
        Random rnd = new Random(); //для генерации случайных чисел
        Button[] slillatak = new Button[5]; //массив начальных кнопок  скилов
        String[] id = new String[5]; //масив id уязвимостей
        String[] desckipt = new String[5]; //масив id уязвимостей
        String ts = ""; //переменная для получения числа скила в зависимоти от имения кнопки
        String idactivateskill ="";
        bool usinresearch = false;
        Button temp;
        String ExpFinaly="0";
        int lose=0;
        public AttackForm()
        {
            InitializeComponent();
            
        }
      //функция при загрузке окна
        private void AttackForm_Load(object sender, EventArgs e)
        {
         
            slillatak[0]= skill1;
            slillatak[1] = skill2;
            slillatak[2] = skill3;
            slillatak[3] = skill4;
            slillatak[4] = skill5;
            SkillAtack();
            BDupdate();// обновление значений из базы данных
            tooltipmainmenu(); //описание всплывающее
            vulnerabil();//функция распределения уязвимостей
        }
        
        //распределения по кнопкам уязвимостей
        public void vulnerabil()
        {
            int level = 0;
            int[] levelprobab = new int[5];
            //генерация числа для распределения уязвимостей
            labelnamelevel.Text = "Уязвимости " + StaticData.NameLevel + " информационной системы";
            // распределение уязвимостей 1 уровень -52% 2 уровень- 41% 3 уровень- 7%
            for (int i = 0; i < 5; i++)
            {
                levelprobab[i] = rnd.Next(1, 1000);
                if (levelprobab[i] < StaticData.highprobab)
                {
                    level = StaticData.lowlevel;

                }
                else if (levelprobab[i] < StaticData.averageprobab)
                {
                    level = StaticData.averagelevel;
                }
                else
                {
                    level = StaticData.highlevel;
                }
                switch (i+1)
                {
                    case 1:
                        vulndest(vuln1, level, i );
                        break;
                    case 2:
                        vulndest(vuln2, level, i );
                        break;
                    case 3:
                        vulndest(vuln3, level, i );
                        break;
                    case 4:
                        vulndest(vuln4, level, i );

                        break;
                    case 5:
                        vulndest(vuln5, level, i );
                        break;
                }
            }
           
        }
        // взятие случайных уязвимостей в зависимости от ранее сгенерированого уровня 
        private void vulndest(Button name, int level,int numid)
        {
            String tip = Convert.ToString(level);
            db1.OpenConnection();
            MySqlDataReader command = new MySqlCommand("SELECT 	`Description`, `id`,Name, GroupsVulner FROM `vulnerabilities` WHERE `Level`=" + tip + " order by rand() limit 1", db1.GetConnection()).ExecuteReader();
            while (command.Read())
            {           
                desckipt[numid]= Convert.ToString(command.GetValue(0));
                id[numid] = Convert.ToString(command.GetValue(1));
                name.Text =  Convert.ToString(command.GetValue(2));
            }
            db1.CloseConnection();               
        } 
        //визуальный и функциональный выбор скила
        private void VisualChoiceSkills(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ts = btn.Name;
            ts = ts.Replace("skill", "");
                if (temp != btn && temp != null)
                {     
                    DescripSkilParametrs();
                    temp.BackColor = Color.Green;
                    btn.BackColor = Color.LightYellow;
                    temp = btn;
                    idactivateskill = ts;
                }
                else
                {
                    DescripSkilParametrs();
                    btn.BackColor = Color.LightYellow;
                    temp = btn;
                    idactivateskill = ts;
                }
          
        }
        //описание выбранного скила
        private void DescripSkilParametrs()
        {
            int energycost = 0;
            int Attactcostmoney = 0;
            String description = "";
            db1.OpenConnection();
            MySqlDataReader skillcommand = new MySqlCommand(" SELECT Description,EnergoCost,Attackcostmoney FROM `skills` WHERE `id`=" + ts, db1.GetConnection()).ExecuteReader();
            while (skillcommand.Read())
            {
                description = Convert.ToString(skillcommand.GetValue(0));
                energycost = Convert.ToInt32(skillcommand.GetValue(1));
                Attactcostmoney = Convert.ToInt32(skillcommand.GetValue(2));
            }
            db1.CloseConnection();
            DescripAttackCost.Text = "Стоимтость применения скила " + Convert.ToString(Attactcostmoney) + " $";
            DescripEnergyCost.Text = "Количество энергии нужное для скила " + Convert.ToString(energycost);
            DescripSkills.Text = description;
        }
        //функция взаимодействия с уязвимостью
        private void vuln1_Click(object sender, EventArgs e)
        {
            if (idactivateskill != "")
            {
                int levelskills = 1;
                int groupsskills = 1;
               
                int energycost = 0;
                int Attactcostmoney = 0;
                var btn = sender as Button;
                ts = btn.Name;
                int numid = Convert.ToInt32(ts.Replace("vuln", ""));    
                db1.OpenConnection();
                MySqlDataReader skillcommand = new MySqlCommand(" SELECT `Level`, `GroupsSkills`,EnergoCost,Attackcostmoney FROM `skills` WHERE `id`=" + idactivateskill, db1.GetConnection()).ExecuteReader();
                while (skillcommand.Read())
                {
                    levelskills = Convert.ToInt32(skillcommand.GetValue(0));
                    groupsskills = Convert.ToInt32(skillcommand.GetValue(1));
                    energycost= Convert.ToInt32(skillcommand.GetValue(2));
                    Attactcostmoney = Convert.ToInt32(skillcommand.GetValue(3));
                }
                db1.CloseConnection();            
               // MessageBox.Show("Левел скила-" + Convert.ToString(levelskills) + "Группа скила-" + Convert.ToString(groupsskills));
                if ((Convert.ToInt32(a_label_energyvalue.Text) - energycost) < 0)
                    {
                        if (Convert.ToInt32(a_label_moneyvalue.Text) - Attactcostmoney >= 0)
                            MessageBox.Show("Недостаточно выносливости");
                        else MessageBox.Show("Недостаточно выносливости и денег");
                    }
                else
                {
                     if (Convert.ToInt32(a_label_moneyvalue.Text) - Attactcostmoney < 0)
                     {
                            MessageBox.Show("Недостаточно денег");
                     }
                     else
                     {
                        int prize = 0;
                     
                        if (idactivateskill != "21")
                        {
                            
                            prize = UsingSkils(groupsskills, levelskills, numid, btn);
                            DeductionEneryandMoney(energycost, Attactcostmoney, prize);
                        }
                        else
                        {
                            if (!usinresearch)
                                DeductionEneryandMoney(energycost, Attactcostmoney, 0);
                            Reservervoid(groupsskills, numid, btn);
                          
                        }                       
                         BDupdate();
                     }              
                }       
            }
        }
        //кнопка иследования
        private void Reservervoid(int groupsskills, int numid, Button btn)
        {
            int n = 0;
            db1.OpenConnection();
            MySqlDataReader command = new MySqlCommand(" SELECT  `GroupsVulner` FROM `vulnerabilities` WHERE `id`=" + id[numid - 1], db1.GetConnection()).ExecuteReader();
            while (command.Read())
            {
                n = Convert.ToInt32(command.GetValue(0));
            }
            db1.CloseConnection();
            if (!usinresearch)
            {
                switch (n)
                {
                    case 1:
                        MessageBox.Show("Уязвимость связана с операционными системами");
                        break;
                    case 2:
                        MessageBox.Show("Уязвимость связана с базами данных");
                        break;
                    case 3:
                        MessageBox.Show("Уязвимость связана програмным обеспечением");
                        break;
                    case 4:
                        MessageBox.Show("Уязвимость связана сетевыми устройствами");
                        break;

                }
                usinresearch = true;
            }
            else MessageBox.Show("Разветка уже была проведена");
        }
        //обновление значения денег и энергии и очков преследования после примениения скила
        private void DeductionEneryandMoney(int energycost, int Attactcostmoney,int prize)
        {
            String money_now;
            String enegy_now;
            String pursuit_now;
            if (prize > 0)
            {
                money_now = Convert.ToString(Convert.ToInt32(a_label_moneyvalue.Text) + prize);
                pursuit_now = Convert.ToString(Convert.ToInt32(value_pointpurse.Text) +10);
            }
            else
            {
                money_now = Convert.ToString(Convert.ToInt32(a_label_moneyvalue.Text) - Attactcostmoney);
                pursuit_now = Convert.ToString(Convert.ToInt32(value_pointpurse.Text) + 6);
            }    
            enegy_now = Convert.ToString(Convert.ToInt32(a_label_energyvalue.Text) - energycost);
            if (money_now != "0" || Convert.ToInt32(pursuit_now) >= 100)
            {
                MySqlCommand command = new MySqlCommand("UPDATE `player` SET `Money`= " + money_now + " ,Endurance=" + enegy_now + " ,Points_pursuit=" + pursuit_now, db1.GetConnection());
                db1.OpenConnection();
                command.ExecuteNonQuery();
                db1.CloseConnection();
            }     
        }
        //мезаника расчета вероятности и взлома уязвимости
        private int UsingSkils(int groupsskills, int levelskills,int numid,Button btn)
        {
            int vulnlevel = 1;
            int vulngroups = 1;
            int prize = 0;
            int probabilityhacking;
            int ret = 1;
            int exp=0;
            db1.OpenConnection();
            MySqlDataReader command = new MySqlCommand(" SELECT `Level`, `GroupsVulner`, `Prize`,Exp FROM `vulnerabilities` WHERE `id`=" + id[numid - 1], db1.GetConnection()).ExecuteReader();
            while (command.Read())
            {
                vulnlevel = Convert.ToInt32(command.GetValue(0));
                vulngroups = Convert.ToInt32(command.GetValue(1));
                prize = Convert.ToInt32(command.GetValue(2));
                exp =Convert.ToInt32(command.GetValue(3));
            }
            db1.CloseConnection();
            if (groupsskills == vulngroups)
            {
                probabilityhacking = 650;
            }     
            else
            {
               probabilityhacking = 100;
            }
            switch (levelskills)
            {
                case 1:
                    probabilityhacking += SkillvLevel1_vs_Vuln(vulnlevel);
                    break;
                case 2:
                    probabilityhacking += SkillvLevel2_vs_Vuln(vulnlevel);
                    break;
                case 3:
                    probabilityhacking += SkillvLevel3_vs_Vuln(vulnlevel);
                    break;
                case 4:
                    probabilityhacking += SkillvLevel4_vs_Vuln(vulnlevel);
                    break;
                case 5:
                    probabilityhacking += SkillvLevel5_vs_Vuln(vulnlevel);
                    break;
            }
            if (probabilityhacking > rnd.Next(-1, 999))
            {
                MessageBox.Show("Харош, взломал. Твоя награда " + Convert.ToString(prize));
                ExpFinaly = Convert.ToString(2*exp + Convert.ToInt32(ExpFinaly));
                explabelval.Text = ExpFinaly;
                btn.Enabled = false;
                ret= prize;
            }
            else
            {
                ExpFinaly =Convert.ToString(exp/10+Convert.ToInt32(ExpFinaly));
                explabelval.Text = ExpFinaly;
                lose += 1;
                switch (lose)
                {
                    case 1:
                        gamelosepanel1.Visible = true;
                        break;
                    case 2:
                        gamelosepanel2.Visible = true;
                        break;
                    case 3:
                        gamelosepanel3.Visible = true;
                        break;
                }     
                MessageBox.Show("Неудача");
                ret= 0;
            }
           // MessageBox.Show(ExpFinaly);
            return ret;
        }
        //функция проигрыша 
        private void LoseGame()
        {
            MySqlCommand command = new MySqlCommand("UPDATE `player` SET `LoseAttack`= 1" , db1.GetConnection());
            db1.OpenConnection();
            command.ExecuteNonQuery();
            db1.CloseConnection();
            StaticData.explanationgameover = StaticData.Attac_lose;
            this.Close();
            th = new Thread(openGameOver);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public void openGameOver()
        {
            Application.Run(new GameOverForm());
        }

        //расчет вероятности для случая левел -2 с разными левелами уязвимостей
        private int SkillvLevel1_vs_Vuln(int vulnlevel)
        {
            int proz=0;
            switch (vulnlevel)
            {
                case 1:
                    proz=200;
                    break;
                case 2:
                    proz = 100;
                    break;
                case 3:
                    proz = -100;
                    break;
                case 4:
                    proz = -800;
                break;
                case 5:
                    proz = -1000;
                break;
            }
            return proz;
        }
        //расчет вероятности для случая левел -2 с разными левелами уязвимостей
        private int SkillvLevel2_vs_Vuln(int vulnlevel)
        {
            int proz = 0;
            switch (vulnlevel)
            {
                case 1:
                    proz = 300;
                    break;
                case 2:
                    proz = 200;
                    break;
                case 3:
                    proz = -100;
                    break;
                case 4:
                    proz = -500;
                    break;
                case 5:
                    proz = -1000;
                    break;
            }
            return proz;
        }
        //расчет вероятности для случая левел -3 с разными левелами уязвимостей
        private int SkillvLevel3_vs_Vuln(int vulnlevel)
        {
            int proz = 0;
            switch (vulnlevel)
            {
                case 1:
                    proz = 400;
                    break;
                case 2:
                    proz = 300;
                    break;
                case 3:
                    proz = 200;
                    break;
                case 4:
                    proz = -100;
                    break;
                case 5:
                    proz = -500;
                    break;
            }
            return proz;
        }
        //расчет вероятности для случая левел -4 с разными левелами уязвимостей
        private int SkillvLevel4_vs_Vuln(int vulnlevel)
        {
            int proz = 0;
            switch (vulnlevel)
            {
                case 1:
                    proz = 500;
                    break;
                case 2:
                    proz = 400;
                    break;
                case 3:
                    proz = 300;
                    break;
                case 4:
                    proz = 200;
                    break;
                case 5:
                    proz = -200;
                    break;
            }
            return proz;
        }
        //расчет вероятности для случая левел -5 с разными левелами уязвимостей
        private int SkillvLevel5_vs_Vuln(int vulnlevel)
        {
            int proz = 0;
            switch (vulnlevel)
            {
                case 1:
                    proz = 700;
                    break;
                case 2:
                    proz = 500;
                    break;
                case 3:
                    proz = 400;
                    break;
                case 4:
                    proz = 300;
                    break;
                case 5:
                    proz = 200;
                    break;
            }
            return proz;
        }
        //функция настроек кнопок скилов в зависимости от выбраных скилов на главной форме
        private void SkillAtack()
        {
            for(int i=0; i < 5; i++)
            {
                if (StaticData.selectskillslen >= i+1)
                {
                    Button a = slillatak[i];
                    a.Name = StaticData.selectbtn[i].Name;
                    String ts = StaticData.selectbtn[i].Name;        
                    a.BackColor = StaticData.selectbtn[i].BackColor;
                    a.Text = StaticData.selectbtn[i].Text;
                }
                else
                {
                    slillatak[i].Visible = false;
                    slillatak[i].Enabled = false;
                }
            }
        }
        //кнопка отступления
        private void lack0f_Click(object sender, EventArgs e)
        {
            ExpSelect();
            this.Close();
            th = new Thread(openForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void ExpSelect()
        {
            int exp=0;
            int pursuit=0;
            db1.OpenConnection();
            MySqlDataReader command = new MySqlCommand(" SELECT `Experiense`, Points_pursuit FROM `player` ", db1.GetConnection()).ExecuteReader();
            while (command.Read())
            {
                exp =Convert.ToInt32( command.GetValue(0));
                pursuit = Convert.ToInt32(command.GetValue(1));
            }
            db1.CloseConnection();
            ExpFinaly = Convert.ToString(exp + Convert.ToInt32(ExpFinaly));
            Button[] vultbtn = new Button[5];
            vultbtn[0] = vuln1;
            vultbtn[1] = vuln2;
            vultbtn[2] = vuln3;
            vultbtn[3] = vuln4;
            vultbtn[4] = vuln5;
            bool hackin = false;
            for (int i=0;i<5;i++)
            {
                if (!vultbtn[i].Enabled)
                {
                    pursuit += 6;
                    hackin = true;
                }
            }
            if (hackin)
            pursuit += 5;
            else
            pursuit += 25;
            ts = Convert.ToString(pursuit);
            MySqlCommand command1 = new MySqlCommand("UPDATE `player` SET `Experiense` ="+ExpFinaly+" ,Points_pursuit="+ ts, db1.GetConnection());
            db1.OpenConnection();
            command1.ExecuteNonQuery();
            db1.CloseConnection();
        }
        //функция открытия главного окна
        public void openForm1() 
        {
            Application.Run(new Form1());
        }
        //стартовая выгрузка параметров из Базы данных
        public void BDupdate()
        {
            db1.OpenConnection();
            MySqlDataReader command = new MySqlCommand("SELECT Money,Endurance,	Points_pursuit FROM `player` WHERE`id`=0", db1.GetConnection()).ExecuteReader();
            while (command.Read())
            {
                a_label_moneyvalue.Text = Convert.ToString(command.GetValue(0));
                a_label_energyvalue.Text = Convert.ToString(command.GetValue(1));
                value_pointpurse.Text = Convert.ToString(command.GetValue(2));
            }
            db1.CloseConnection();
            if (lose == 3) LoseGame();
        }

        private void vuln1_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ts = btn.Name;
            int i = Convert.ToInt32(ts.Replace("vuln", ""));
            deckvuln_richTextBox.Text = desckipt[i - 1];
        }

        private void vuln1_MouseLeave(object sender, EventArgs e)
        {
            deckvuln_richTextBox.Text = "";
        }
        private void tooltipmainmenu()
        {       
            t.SetToolTip(a_label_money, "Денежный баланс");
            t.SetToolTip(a_label_moneyvalue, "Денежный баланс");
            t.SetToolTip(a_label_energyvalue, "Количество выносливости для дейстий при атаке");
            t.SetToolTip(a_label_energy, "Количество выносливости для дейстий при атаке");
            t.SetToolTip(label_pointpurse, "Показатель преследования праворанительными органами");
            t.SetToolTip(value_pointpurse, "Показатель преследования праворанительными органами");
            t.SetToolTip(indicator, "Показатель провала при нападении, при 3 показателях проигрых");
        }
    }
}
