using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBased
{
    public static class StaticData
    {
        public static int selectskillslen; //количество скилов
        public static Button[] selectbtn = new Button[5]; //передача скилов
        public static String explanationgameover = "";
        public static String explanationgamewin = "";
        public static String gameover_purst = "Вам домой вломились несколько отрядр ФСБ, повязали, вы сядете на многие годы, мне вас жаль";
        public static String Attac_lose = "После неуачной атаки вас начали искать и потом к вам домой вломились несколько отрядр ФСБ, повязали. Теперь вы сядете на многие годы, мне вас жаль";
        public static String gameover_money = "Вы потратели все деньги, и теперь вам не начего вести ваше жалкое сушествование, ваша хакерская деятельность окончена";
        public static String gamewin_money = "Вы разбогатели, благодаря вашему таланту и умением хакера. Теерь вы можете уйти на покой";
        public static String gamewinskills5= "Вы стали абсолютным мастеров взлома, теперь вас не остановить";
        public static int lowlevel;
        public static int averagelevel;
        public static int highlevel;
        public static int averageprobab;
        public static int highprobab;
        public static String NameLevel;
    }
}
