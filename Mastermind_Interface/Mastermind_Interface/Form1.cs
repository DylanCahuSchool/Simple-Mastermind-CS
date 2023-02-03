using System;
using System.Windows.Forms;

namespace Mastermind_Interface
{
    public partial class Form1 : Form
    {

        private int nbBoxesEmpty;
        private int nbHintsEmpty;
        private int nbBoxes;
        private int nbHints;
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //create 4 picture boxes and initialize them to green
            for (int i = 0; i < 4; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Name = "pb" + i;
                pb.Size = new Size(100, 100);
                pb.Location = new Point(50 + i * returnPosition(25, "w"), returnPosition(65, "h"));
                pb.Image = Image.FromFile(selectImage(0));
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(pb);
            }
            //create 8 button and initialize 4 to + and 4 to -
            for (int i = 0; i < 8; i++)
            {

                Button btn = new Button();
                btn.Name = "btn" + i;
                btn.Size = new Size(50, 50);
                if (i % 2 == 0)
                {
                    btn.Text = "-";
                    btn.Location = new Point(PicBox(i).Location.X, PicBox(i).Location.Y + 100);
                }
                else
                {
                    btn.Text = "+";
                    btn.Location = new Point(PicBox(i).Location.X + 50, PicBox(i).Location.Y + 100);
                }
                btn.Click += new EventHandler(btn_Click);
                this.Controls.Add(btn);
            }
            for (int i = 0; i < 16; i++)
            {
                displayBallsStart();
            }
            //create a button on the top right corner to reset the game
            Button btnReset = new Button();
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 30);
            btnReset.Text = "Reset";
            btnReset.Location = new Point(returnPosition(95, "w"), returnPosition(3, "h"));
            btnReset.Click += new EventHandler(btnReset_Click);
            this.Controls.Add(btnReset);


            //------------------------------------------------------
            displayBallsEnd();// A RETIRER
            //------------------------------------------------------

        }
        public void btnReset_Click(object sender, EventArgs e)
        {
            //reset the game
            Application.Restart();
        }

        private int returnPosition(int num, string c)
        {
            if (c[0] == 'w') //c[0] is the first letter of the string so is it a converter to char
            {
                return Convert.ToInt32(this.Size.Width * num / 100);
            }
            else
            {
                return Convert.ToInt32(this.Size.Height * num / 100);
            }
        }

        private string selectImage(int num)
        {
            //switch to return image name
            switch (num)
            {
                case 0: return "green.png";
                case 1: return "red.png";
                case 2: return "blue.png";
                case 3: return "pink.png";
                case 4: return "yellow.png";
                case 5: return "purple.png";
                case 6: return "orange.png";
                case 7: return "white.png";
                case 8: return "none.png";
                default: return "error.png";
            }
        }

        private int returnIndex(int num)
        {
            int index = 0;
            switch (num)
            {
                case 0:
                case 1: return index = 0;
                case 2:
                case 3: return index = 1;
                case 4:
                case 5: return index = 2;
                case 6:
                case 7: return index = 3;
                default: return index = 455;//bidouille
            }
        }

        private PictureBox PicBox(int num)
        {
            return (PictureBox)this.Controls.Find("pb" + returnIndex(num), true)[0];
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Motor.game();
            displayBalls();
        }

        private void displayBallsStart()
        {
            PictureBox[] pictureBoxes = new PictureBox[nbBoxesEmpty + 4];
            for (int j = nbBoxesEmpty; j < nbBoxesEmpty + 4; j++)
            {
                pictureBoxes[j] = new PictureBox();
                pictureBoxes[j].Name = "pictureB" + (j + 1).ToString();
                pictureBoxes[j].Size = new Size(50, 50);
                pictureBoxes[j].Location = new Point((nbBoxesEmpty * 15) + 25, (j * 50) - (nbBoxesEmpty * 50) + 50);
                pictureBoxes[j].Image = Image.FromFile(selectImage(8));
                pictureBoxes[j].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(pictureBoxes[j]);
            }
            nbBoxesEmpty += 4;

            PictureBox[] hintBoxes = new PictureBox[nbHintsEmpty + 4];
            for (int j = nbHintsEmpty; j < nbHintsEmpty + 4; j++)
            {
                hintBoxes[j] = new PictureBox();
                hintBoxes[j].Name = "hintBox" + (j + 1).ToString();
                hintBoxes[j].Size = new Size(25, 25);
                hintBoxes[j].Image = Image.FromFile(selectImage(8));
                //hintBoxes[j].Image = Image.FromFile("error.png");
                hintBoxes[j].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(hintBoxes[j]);
            }
            hintBoxes[nbHintsEmpty].Location = new Point((nbHintsEmpty * 15) + 25, 0);
            hintBoxes[nbHintsEmpty + 2].Location = new Point((nbHintsEmpty * 15) + 50, 0);
            hintBoxes[nbHintsEmpty + 1].Location = new Point((nbHintsEmpty * 15) + 25, 25);
            hintBoxes[nbHintsEmpty + 3].Location = new Point((nbHintsEmpty * 15) + 50, 25);

            nbHintsEmpty += 4;
        }

        private void displayBalls()
        {
            for (int i = nbBoxes; i < nbBoxes + 4; i++)
            {
                //use the collection picturebox to find the picturebox
                PictureBox pb = (PictureBox)this.Controls.Find("pictureB" + (i + 1).ToString(), true)[0];
                pb.Image = Image.FromFile(selectImage(Motor.choixJoueur[i - nbBoxes]));
            }
            nbBoxes += 4;


            for (int i = nbHints; i < nbHints + 4; i++)
            {
                //use the collection hintboxes to find the hintboxes
                PictureBox hb = (PictureBox)this.Controls.Find("hintBox" + (i + 1).ToString(), true)[0];
                hb.Image = Image.FromFile(selectImage(Motor.indic[i - nbHints]));
            }
            nbHints += 4;

        }

        public void displayBallsEnd()
        {
            PictureBox[] pictureBoxes = new PictureBox[nbBoxes + 4];
            for (int i = nbBoxes; i < nbBoxes + 4; i++)
            {
                pictureBoxes[i] = new PictureBox();
                pictureBoxes[i].Name = "pictureB" + (i + 1).ToString();
                pictureBoxes[i].Size = new Size(50, 50);
                pictureBoxes[i].Location = new Point(returnPosition(90, "w"), (i * 50) - (nbBoxes * 50) + 50);
                pictureBoxes[i].Image = Image.FromFile(selectImage(Motor.choixPC[i - nbBoxes]));
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(pictureBoxes[i]);
            }

        }

        public void win()
        {

            /* this.Controls.Remove(Submit);
             //for each pb, remove them
             for (int i = 0; i < 4; i++)
             {
                 this.Controls.Remove(this.Controls.Find("pb" + i, true)[0]);
             }
             //for each button, remove them
             for (int i = 0; i < 8; i++)
             {
                 this.Controls.Remove(this.Controls.Find("btn" + i, true)[0]);
             }

             PictureBox winPic = new PictureBox();
             winPic.Name = "pictureB" + (nbBoxes + 1).ToString();
             winPic.Size = new Size(750, 200);
             winPic.Location = new Point(250, 250);
             winPic.Image = Image.FromFile("win.png");
             winPic.SizeMode = PictureBoxSizeMode.Zoom;
             this.Controls.Add(winPic);

             //create a new button "yes"
             Button yes = new Button();
             yes.Name = "yes";
             yes.Size = new Size(100, 50);
             yes.Location = new Point(510, 460);
             yes.Text = "Oui";
             yes.Click += new EventHandler(yes_Click);
             this.Controls.Add(yes);

             //create a new button "no"
             Button no = new Button();
             no.Name = "no";
             no.Size = new Size(100, 50);
             no.Location = new Point(610, 460);
             no.Text = "Non";
             no.Click += new EventHandler(no_Click);
             this.Controls.Add(no);

             displayBallsEnd();*/
        }

        public void fail()
        {

            this.Controls.Remove(Submit);
            //for each pb, remove them
            for (int i = 0; i < 4; i++)
            {
                this.Controls.Remove(this.Controls.Find("pb" + i, true)[0]);
            }
            //for each button, remove them
            for (int i = 0; i < 8; i++)
            {
                this.Controls.Remove(this.Controls.Find("btn" + i, true)[0]);
            }

            PictureBox failPic = new PictureBox();
            failPic.Name = "failbox";
            failPic.Size = new Size(750, 200);
            failPic.Location = new Point(250, 250);
            failPic.Image = Image.FromFile("fail.png");
            failPic.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(failPic);

            //create a new button "yes"
            Button yes = new Button();
            yes.Name = "yes";
            yes.Size = new Size(100, 50);
            yes.Location = new Point(510, 460);
            yes.Text = "Oui";
            yes.Click += new EventHandler(yes_Click);
            this.Controls.Add(yes);

            //create a new button "no"
            Button no = new Button();
            no.Name = "no";
            no.Size = new Size(100, 50);
            no.Location = new Point(610, 460);
            no.Text = "Non";
            no.Click += new EventHandler(no_Click);
            this.Controls.Add(no);

            displayBallsEnd();
        }

        private void yes_Click(object sender, EventArgs e)
        {//reload form1
            Application.Restart();
        }

        private void no_Click(object sender, EventArgs e)
        {//close the application
            Application.Exit();
        }

        private void btn_Click(object sender, EventArgs e)
        {//create btn_Click function with num parameter

            //get the button name
            string name = ((Button)sender).Name;
            //get the number of the button
            int num = Convert.ToInt32(name.Substring(3));
            if (num % 2 == 0)
            {
                Motor.choixJoueur[returnIndex(num)]--;
            }
            else
            {
                Motor.choixJoueur[returnIndex(num)]++;
            }

            if (Motor.choixJoueur[returnIndex(num)] > 6)
            {
                Motor.choixJoueur[returnIndex(num)] = 0;
            }
            else if (Motor.choixJoueur[returnIndex(num)] < 0)
            {
                Motor.choixJoueur[returnIndex(num)] = 6;
            }

            if (num < 8)
            {
                PicBox(num).Image = Image.FromFile(selectImage(Motor.choixJoueur[returnIndex(num)]));
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {//foreach item in controller, adapt the position
            Submit.Location = new Point(Width - 110, Height - 100);
            foreach (Control c in this.Controls)
            {
                if (c.Name.Contains("pb"))
                {
                    int num = Convert.ToInt32(c.Name.Substring(2));
                    c.Location = new Point(50 + num * returnPosition(25, "w"), returnPosition(65, "h"));
                }
                else if (c.Name.Contains("btn"))
                {
                    int num = Convert.ToInt32(c.Name.Substring(3));
                    if (c.Text == "+")
                    {
                        c.Location = new Point(PicBox(num).Location.X + 50, PicBox(num).Location.Y + 100);
                    }
                    else if (c.Text == "-")
                    {
                        c.Location = new Point(PicBox(num).Location.X, PicBox(num).Location.Y + 100);
                    }
                }

                /*else if (c.Name.Contains("pictureB"))
                {
                    c.Location = new Point(Width / 2 - c.Width / 2, Height / 2 - c.Height / 2);
                }*/
            }
        }
    }
}