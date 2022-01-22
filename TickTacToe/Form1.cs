using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TickTacToe
{
    public partial class Form1 : Form
    {

        char p = 'O';
        char c = 'X';
        string P = "O";
        string C = "X";

        SortedDictionary<int,  Tuple<bool, Tuple<char, Button>>> data = new SortedDictionary<int, Tuple<bool, Tuple<char, Button>>>();
            
        
        public Form1()
        {
            InitializeComponent();

            this.CenterToScreen();

            //for (int i = 1; i <= 9; i++) data.Add(i, new Tuple<bool, Tuple<char, Button>>(false, new Tuple<char, Button>(' ',button1 )));
            data.Add(1, new Tuple<bool, Tuple<char, Button>>(false, new Tuple<char, Button>(' ', button1)));
            data.Add(2, new Tuple<bool, Tuple<char, Button>>(false, new Tuple<char, Button>(' ', button2)));
            data.Add(3, new Tuple<bool, Tuple<char, Button>>(false, new Tuple<char, Button>(' ', button3)));
            data.Add(4, new Tuple<bool, Tuple<char, Button>>(false, new Tuple<char, Button>(' ', button4)));
            data.Add(5, new Tuple<bool, Tuple<char, Button>>(false, new Tuple<char, Button>(' ', button5)));
            data.Add(6, new Tuple<bool, Tuple<char, Button>>(false, new Tuple<char, Button>(' ', button6)));
            data.Add(7, new Tuple<bool, Tuple<char, Button>>(false, new Tuple<char, Button>(' ', button7)));
            data.Add(8, new Tuple<bool, Tuple<char, Button>>(false, new Tuple<char, Button>(' ', button8)));
            data.Add(9, new Tuple<bool, Tuple<char, Button>>(false, new Tuple<char, Button>(' ', button9)));
        }


        private int get_button_num(Button b)
        {
            string num = b.AccessibleName;

            int button_num = int.Parse(num);
            if (button_num > 0 && button_num < 10) return button_num;
            else return 0;
        }

        bool play_check(int count, int cnt, Button b, int num)
        {
            
            if (count == 2 || cnt == 2)
            {
                b = data[num].Item2.Item2;
                b.Text = C;
                data[num] = new Tuple<bool, Tuple<char, Button>>(true, new Tuple<char, Button>(c, b));
                return true;
            }
            else
            {
                return false;
            }
        }

        private int smart_play()
        {
            int count = 0;
            int cnt = 0;
            Button b = null;
            int num = 0;
            int empty = 0;
            bool a = false;

            

            for(int i=1; i<=3; i++)
            {
                for(int j=1; j<=3; j++)
                {
                    if (data[3 * i - 3 + j].Item2.Item1 == p) count++;
                    else if (data[3 * i - 3 + j].Item2.Item1 == c) cnt++;
                    else
                    {
                        num = 3 * i - 3 + j;
                        empty++;
                    }

                }
                if (empty != 0) a = play_check(count, cnt, b, num);
                count = 0;
                cnt = 0;
                empty = 0;
                if (a) return 1;
            }
            

            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    if (data[3 * j - 3 + i].Item2.Item1 == p) count++;
                    else if (data[3 * j - 3 + i].Item2.Item1 == c) cnt++;
                    else
                    {
                        num = 3 * j - 3 + i;
                        empty++;
                    }

                }
                if (empty != 0) a = play_check(count, cnt, b, num);
                count = 0;
                empty = 0;
                cnt = 0;
                if (a) return 1;
            }
            

            {
                empty = 0;
                count = 0;
                cnt = 0;
                for (int i = 0; i <= 2; i++)
                {
                    if (data[1 + i * 4].Item2.Item1 == p) count++;
                    else if (data[1 + i * 4].Item2.Item1 == c) cnt++;
                    else
                    {
                        num = 1 + i * 4;
                        empty++;
                    }
                }
                if (empty != 0) a = play_check(count, cnt, b, num);
                if (a) return 1;
            }
           

            {
                count = 0;
                empty = 0;
                cnt = 0;
                for (int i = 0; i <= 2; i++)
                {
                    if (data[3 + i * 2].Item2.Item1 == p) count++;
                    else if (data[3 + i * 2].Item2.Item1 == c) cnt++;
                    else
                    {
                        num = 3 + i * 2;
                        empty++;
                    }
                }
                if (empty != 0) a = play_check(count, cnt, b, num);
                if (a) return 1;
            }

            return 0;
        }

    

        private void play()
        {
            int count = 0;
            int n = 0;

            for (int i = 1; i <= 9; i++)
            {
                if (!data[i].Item1) { count++; }
            }
            Random rd = new Random();
            int num = rd.Next(1, count);

            for (int i = 1; i <= 9; i++)
            {
                if (!data[i].Item1) n++;
                if (n == num) 
                {
                    Button temp = data[i].Item2.Item2;
                    data[i] = new Tuple<bool, Tuple<char, Button>>(true, new Tuple<char, Button>(c, temp));
                    n = i;
                    break;
                }
                
            }

         
            Button final = data[n].Item2.Item2;
            final.Text = C;


        }

        int check(int count, int cnt)
        {
            if (count == 3)
            {
                return 1;
            }
            else if (cnt == 3)
            {
                return 2;
            }
            else 
            { 
                return 0; 
            }
        }

        private int check_winner()
        {
            int count = 0;
            int cnt = 0;
            int result = 0;

            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    if (data[3 * i - 3 + j].Item2.Item1 == p) count++;
                    else if (data[3 * i - 3 + j].Item2.Item1 == c) cnt++;
                }
               
                result = check(count, cnt);
                count = 0;
                cnt = 0;
                if (result != 0) { return result; }
            }


            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    if (data[3 * j - 3 + i].Item2.Item1 == p) count++;
                    else if (data[3 * j - 3 + i].Item2.Item1 == c) cnt++;
                    
                }
                result = check(count, cnt);
                count = 0;
                cnt = 0;
                if (result != 0) { return result; }
            }


            for (int i = 0; i <= 2; i++)
            {
                if (data[1 + i * 4].Item2.Item1 == p) count++;
                else if (data[1 + i * 4].Item2.Item1 == c) cnt++;
                    
            }
            result = check(count, cnt);
            count = 0;
            cnt = 0;
            if (result != 0) { return result; }


            for (int i = 0; i <= 2; i++)
            {
                if (data[3 + i * 2].Item2.Item1 == p) count++;
                else if (data[3 + i * 2].Item2.Item1 == c) cnt++;
                    
            }
            result = check(count, cnt);
            count = 0;
            cnt = 0;
            if (result != 0) { return result; }

            return 0;
        }

        private bool check_full()
        {
            int count = 0;
            for(int i =1; i<10; i++)
            {
                if (!(data[i].Item1)) count++;
            }

            if (count == 0) return true;

            return false;
        }

        void show_info(int winner)
        {
           
            Info info = new Info(this.Location.X + 247, this.Location.Y + 520);

            if (winner == 1) info.give_text("You win!");
            else if (winner == 2) info.give_text("You lose...");
            else info.give_text("It's a draw.");

            info.ShowDialog();

            if (info.DialogResult == DialogResult.Yes)
            {
                Application.Restart();
            }
            else if (info.DialogResult == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int button_num = get_button_num(b);
            if (b.Text == "")
            {

                Button temp = data[button_num].Item2.Item2;
                data[button_num] = new Tuple<bool, Tuple<char, Button>>(true, new Tuple<char, Button>(p, temp));
                b.Text = P;
                bool stop = check_full();
                int winner = check_winner();
                if (winner==0)
                {
                    if (!stop)
                    {
                        if (smart_play() == 0) { play(); }
                        winner = check_winner();
                        if (winner != 0) { show_info(winner); }
                    }
                    else show_info(winner);
                    
                }
                else if(winner != 0) { show_info(winner); }

            }
        }

    }
}
//WHY DOESN'T SECOND DIAGONAL WORK??????
//everything ready except for the fucking smart pally that is still shit...
