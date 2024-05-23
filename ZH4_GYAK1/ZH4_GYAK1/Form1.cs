namespace ZH4_GYAK1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox player = new PictureBox();
        PictureBox cel = new PictureBox();
        PictureBox start = new PictureBox();
        List<PictureBox> falak = new List<PictureBox>();
        int mp = 0;
        int p = 0;
        int lepes = 0;
        int cel_x = 0;
        int cel_y = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(ofd.FileName);
                    int y = 0;
                    while (!sr.EndOfStream)
                    {
                        string sor = sr.ReadLine();
                        for (int x = 0; x < sor.Length; x++)
                        {
                            if (sor[x] == '#')
                            {
                                PictureBox kd = new PictureBox();
                                kd.Location = new Point(x * 20, y * 20);
                                kd.Size = new Size(20, 20);
                                kd.BackColor = Color.Black;
                                this.Controls.Add(kd);
                                falak.Add(kd);
                                cel_x = x * 20;
                            }

                        }
                        y++;
                        cel_y = y * 20;
                    }
                    player.Location = new Point(0, 0);
                    player.Size = new Size(20, 20);
                    player.BackColor = Color.Fuchsia;
                    Controls.Add(player);

                    cel.Location = new Point(cel_x+20, cel_y-20);
                    cel.BackColor = Color.Fuchsia;
                    cel.Size = new Size(20, 20);
                    Controls.Add(cel);

                    start.Location = new Point(0, 0);
                    start.BackColor = Color.Red;
                    start.Size = new Size(20, 20);
                    Controls.Add (start);

                    KeyDown += Form1_KeyDown;

                    Controls.Remove(button1);

                    timer1.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            int player_x = player.Location.X;
            int player_y = player.Location.Y;

            if (e.KeyCode == Keys.Right)
            {
                player_x += 20;
            }
            if (e.KeyCode == Keys.Left)
            {
                player_x -= 20;
                
            }
            if (e.KeyCode == Keys.Up)
            {
                player_y -= 20;
              
            }
            if (e.KeyCode == Keys.Down)
            {
                player_y += 20;
              
            }

           

            var fal = falak.FirstOrDefault(w => w.Location.X == player_x && w.Location.Y == player_y);
            if (fal == null)
            {
                
                if (player_y >= ClientRectangle.Y && player_x >= ClientRectangle.X)
                {
                    player.Location = new Point(player_x, player_y);
                    lepes++;
                    label4.Text = lepes.ToString();
                    if (player.Bounds.IntersectsWith(cel.Bounds))
                    {
                        timer1.Enabled = false;
                        MessageBox.Show($"Gratutálok,kijutottál. Az idõd: {p} perc {mp} másodperc, lépéseid száma: {lepes}");
                        Restart();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mp++;
            if (mp == 60)
            {
                p++;
                mp = 0;
            }
            string ido = $"{p}:{mp}";
            label3.Text = ido;
        }
        private void Restart()
        {
            player.Location = new Point(0, 0);
            mp = 0;
            p = 0;
            lepes = 0;
            label3.Text = "0";
            label4.Text = "0";
            timer1.Enabled = true;

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Restart();
        }
    }

}
