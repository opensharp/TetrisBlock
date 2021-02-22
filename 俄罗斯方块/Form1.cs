using System;
using System.Drawing;
using System.Windows.Forms;
namespace 俄罗斯方块
{
    public partial class Form1 : Form
    {
        Label[] block = new Label[300];
        int[] flag = new int[300];
        int[] cubex = new int[4];
        int[] cubey = new int[4];
        int time = 0, score = 0;
        int finish = 0, type = 0;
        int centerx = 0, centery = 0;
        int direction = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Create();
            for (int i = 0; i < 300; i++)
            {
                block[i] = new Label();
                Controls.Add(block[i]);
                block[i].Location = new Point(15 + 25 * (i % 15), 15 + 25 * (i / 15));
                block[i].Size = new Size(26, 26);
                block[i].BorderStyle = BorderStyle.FixedSingle;
                if (i < 15)
                {
                    block[i].Visible = false;
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (finish != 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    block[cubex[i] + cubey[i] * 15].BackColor = SystemColors.Control;
                }
                switch (e.KeyValue)
                {
                    case 32:
                        Drop();
                        break;
                    case 38:
                        Rotation();
                        break;
                    case 40:
                        Tick(2);
                        break;
                    case 37:
                        Tick(3);
                        break;
                    case 39:
                        Tick(4);
                        break;
                }
                for (int i = 0; i < 4; i++)
                {
                    block[cubex[i] + cubey[i] * 15].BackColor = Color.Red;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            label1.Text = "Game Time：" + time.ToString();
            Tick(2);
        }
        private void Create()
        {
            int over = 0;
            Random ran = new Random();
            int RandKey = ran.Next() % 7 + 1;
            type = RandKey;
            if (RandKey == 1)
            {
                cubex[0] = 6;
                cubex[1] = 6;
                cubex[2] = 7;
                cubex[3] = 8;
                cubey[0] = 0;
                cubey[1] = 1;
                cubey[2] = 1;
                cubey[3] = 1;
            }
            else if (RandKey == 2)
            {
                cubex[0] = 7;
                cubex[1] = 6;
                cubex[2] = 7;
                cubex[3] = 8;
                cubey[0] = 0;
                cubey[1] = 1;
                cubey[2] = 1;
                cubey[3] = 1;
            }
            else if (RandKey == 3)
            {
                cubex[0] = 8;
                cubex[1] = 6;
                cubex[2] = 7;
                cubex[3] = 8;
                cubey[0] = 0;
                cubey[1] = 1;
                cubey[2] = 1;
                cubey[3] = 1;
            }
            else if (RandKey == 4)
            {
                cubex[0] = 6;
                cubex[1] = 6;
                cubex[2] = 7;
                cubex[3] = 7;
                cubey[0] = 0;
                cubey[1] = 1;
                cubey[2] = 1;
                cubey[3] = 0;
            }
            else if (RandKey == 5)
            {
                cubex[0] = 5;
                cubex[1] = 6;
                cubex[2] = 7;
                cubex[3] = 8;
                cubey[0] = 1;
                cubey[1] = 1;
                cubey[2] = 1;
                cubey[3] = 1;
            }
            else if (RandKey == 6)
            {
                cubex[0] = 6;
                cubex[1] = 7;
                cubex[2] = 7;
                cubex[3] = 8;
                cubey[0] = 0;
                cubey[1] = 0;
                cubey[2] = 1;
                cubey[3] = 1;
            }
            else
            {
                cubex[0] = 6;
                cubex[1] = 7;
                cubex[2] = 7;
                cubex[3] = 8;
                cubey[0] = 1;
                cubey[1] = 1;
                cubey[2] = 0;
                cubey[3] = 0;
            }
            centerx = 7;
            centery = 1;
            direction = 1;
            for (int i = 0; i < 4; i++)
            {
                if(flag[cubex[i] + (cubey[i]+1) * 15] == 1)
                {
                    over = 1;
                }
            }
            if (over == 1)
            {
                finish = 1;
                timer1.Enabled = false;
                MessageBox.Show("Press Enter Or Space To Continue", "Game Over");
                Application.Restart();
            }
        }
        private void Tick(int key)
        {
            int drop = 0, gap = 0, count = 0;
            for (int i = 0; i < 300; i++)
            {
                if (flag[i] == 1)
                {
                    block[i].BackColor = Color.Black;
                }
                else
                {
                    block[i].BackColor = SystemColors.Control;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                block[cubex[i] + cubey[i] * 15].BackColor = SystemColors.Control;
            }
            for (int i = 0; i < 4; i++)
            {
                if (key == 3)
                {
                    if (flag[cubex[i] - 1 + cubey[i] * 15] == 1)
                    {
                        gap = 1;
                    }
                    if (cubex[i] == 0)
                    {
                        gap = 1;
                    }
                }
                else if (key == 4)
                {
                    if (flag[cubex[i] + 1 + cubey[i] * 15] == 1)
                    {
                        gap = 1;
                    }
                    if (cubex[i] == 14)
                    {
                        gap = 1;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (key == 2)
                {
                    cubey[i]++;
                    centery++;
                }
                else if (key == 3)
                {
                    if (gap == 0)
                    {
                        cubex[i]--;
                        centerx--;
                    }
                }
                else if (key == 4)
                {
                    if (gap == 0)
                    {
                        cubex[i]++;
                        centerx++;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                block[cubex[i] + cubey[i] * 15].BackColor = Color.Red;
            }
            for (int i = 0; i < 4; i++)
            {
                if ((cubey[i] == 19) || (flag[cubex[i] + (cubey[i] + 1) * 15] == 1))
                {
                    drop = 1;
                }
            }
            if (drop == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    flag[cubex[i] + cubey[i] * 15] = 1;
                }
                score += 5;
                label2.Text = "Score：" + score.ToString();
                Create();
            }
            for (int i = 0; i < 15; i++)
            {
                if (flag[285 + i] == 1)
                {
                    count++;
                }
            }
            if (count == 15)
            {
                for (int i = 18; i > -1; i--)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        flag[15 * i + 15 + j] = flag[15 * i + j];
                    }
                }
                score += 50;
                label2.Text = "Score：" + score.ToString();
            }
        }
        private void Drop()
        {
            int flag0 = 0,count=0;
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    if ((cubey[i] == 19) || (flag[cubex[i] + (cubey[i] + 1) * 15] == 1))
                    {
                        flag0 = 1;
                    }
                }
                if (flag0 == 1)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        flag[cubex[i] + cubey[i] * 15] = 1;
                    }
                    score += 5;
                    label2.Text = "Score：" + score.ToString();

                    for (int i = 0; i < 15; i++)
                    {
                        if (flag[285 + i] == 1)
                        {
                            count++;
                        }
                    }
                    if (count == 15)
                    {
                        for (int i = 18; i > -1; i--)
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                flag[15 * i + 15 + j] = flag[15 * i + j];
                            }
                        }
                        score += 50;
                        label2.Text = "Score：" + score.ToString();
                    }
                    Create();
                    for (int i = 0; i < 300; i++)
                    {
                        if (flag[i] == 1)
                        {
                            block[i].BackColor = Color.Black;
                        }
                        else
                        {
                            block[i].BackColor = SystemColors.Control;
                        }
                    }
                    return;
                }
                for (int i = 0; i < 4; i++)
                {
                    cubey[i]++;
                    centery++;
                }
            }
        }
        private void Rotation()
        {
            //if (RandKey == 1) 1号
            //if (RandKey == 2) 6号
            //if (RandKey == 3) 2号
            //if (RandKey == 4) 5号
            //if (RandKey == 5) 7号
            //if (RandKey == 6) 3号
            //if (RandKey == 7) 4号
            if (type == 1)
            {
                if (direction == 1)
                {
                    direction = 2;
                }
                else if (direction == 2)
                {
                    direction = 3;
                }
                else if (direction == 3)
                {
                    direction = 4;
                }
                else if (direction == 4)
                {
                    direction = 4;
                }
            }
            else if (type == 2)
            {
                if (direction == 1)
                {
                    direction = 2;
                }
                else if (direction == 2)
                {
                    direction = 3;
                }
                else if (direction == 3)
                {
                    direction = 4;
                }
                else if (direction == 4)
                {
                    direction = 4;
                }
            }
            else if (type == 3)
            {
                if (direction == 1)
                {
                    direction = 2;
                }
                else if (direction == 2)
                {
                    direction = 3;
                }
                else if (direction == 3)
                {
                    direction = 4;
                }
                else if (direction == 4)
                {
                    direction = 4;
                }
            }
            else if (type == 4)
            {
                if (direction == 1)
                {
                    direction = 2;
                }
                else if (direction == 2)
                {
                    direction = 3;
                }
                else if (direction == 3)
                {
                    direction = 4;
                }
                else if (direction == 4)
                {
                    direction = 4;
                }
            }
            else if (type == 5)
            {
                if (direction == 1)
                {
                    direction = 2;
                }
                else if (direction == 2)
                {
                    direction = 3;
                }
                else if (direction == 3)
                {
                    direction = 4;
                }
                else if (direction == 4)
                {
                    direction = 4;
                }
            }
            else if (type == 6)
            {
                if (direction == 1)
                {
                    direction = 2;
                }
                else if (direction == 2)
                {
                    direction = 3;
                }
                else if (direction == 3)
                {
                    direction = 4;
                }
                else if (direction == 4)
                {
                    direction = 4;
                }
            }
            else if (type == 7)
            {
                if (direction == 1)
                {
                    direction = 2;
                }
                else if (direction == 2)
                {
                    direction = 3;
                }
                else if (direction == 3)
                {
                    direction = 4;
                }
                else if (direction == 4)
                {
                    direction = 4;
                }
            }
        }
    }
}