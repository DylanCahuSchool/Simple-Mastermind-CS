using System;
using System.Windows.Forms;

namespace Mastermind_Interface
{
    public partial class Form1 : Form
    {

        private int nbBoxes;
        private int nbHints;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int Percent25Height = Convert.ToInt32(this.Size.Height * 0.25);
            int Percent50Height = Convert.ToInt32(this.Size.Height * 0.5);
            int Percent75Height = Convert.ToInt32(this.Size.Height * 0.75);
            int Percent25Width = Convert.ToInt32(this.Size.Width * 0.25);
            int Percent50Width = Convert.ToInt32(this.Size.Width * 0.5);
            int Percent75Width = Convert.ToInt32(this.Size.Width * 0.75);
            
            //create 4 picture boxes and initialize them to green
            for (int i = 0; i < 4; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Name = "pb" + i;
                pb.Size = new Size(100, 100);
                pb.Location = new Point(50 + i * Percent25Width, Percent50Height);
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
                    //btn.Location = new Point(50 + i * Percent25Width, Percent75Height);
                }
                else
                {
                    btn.Text = "+";
                    //place the button to the right of the previous one
                    btn.Location = new Point(PicBox(i).Location.X + 50, PicBox(i).Location.Y + 100);
                }
                btn.Click += new EventHandler(btn_Click);
                this.Controls.Add(btn);
            }

        }
        private string selectImage(int num)
        {
            //switch to return image name
            switch (num)
            {
                case 0:
                    return "green.png";
                    break;
                case 1:
                    return "red.png";
                    break;
                case 2:
                    return "blue.png";
                    break;
                case 3:
                    return "pink.png";
                    break;
                case 4:
                    return "yellow.png";
                    break;
                case 5:
                    return "purple.png";
                    break;
                case 6:
                    return "white.png";
                    break;
                default:
                    return "error.png";
                    break;
            }
        }

        private int returnIndex(int num)
        {
            int index = 0;
            switch (num)
            {
                case 0:
                case 1:
                    return index = 0;
                    break;
                case 2:
                case 3:
                    return index = 1;
                    break;
                case 4:
                case 5:
                    return index = 2;
                    break;
                case 6:
                case 7:
                    return index = 3;
                    break;
                default:
                    return index = 455;//bidouille
            }
        }

        private PictureBox PicBox(int num)
        {
            return (PictureBox)this.Controls.Find("pb" + returnIndex(num), true)[0];
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            //Motor.game();
            displayBalls();
        }

        //game phase function
        private void displayBalls()
        {
            
            PictureBox[] pictureBoxes = new PictureBox[nbBoxes+4];
            for (int i = nbBoxes; i < nbBoxes + 4 ; i++)
            {
                pictureBoxes[i] = new PictureBox();
                pictureBoxes[i].Name = "pictureB" + (i + 1).ToString();
                pictureBoxes[i].Size = new Size(50, 50);
                pictureBoxes[i].Location = new Point((nbBoxes * 15) + 25 , (i * 50) - (nbBoxes * 50) + 50);
                pictureBoxes[i].Image = Image.FromFile(selectImage(Motor.choixJoueur[i - nbBoxes]));
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(pictureBoxes[i]);
            }
            nbBoxes += 4;
            
            for (int i = nbHints; i < nbHints; i++)
            {
                pictureBoxes[i] = new PictureBox();
                pictureBoxes[i].Name = "pictureB" + (nbBoxes + nbHints + 1).ToString();
                pictureBoxes[i].Size = new Size(25, 25);
                //if i isn't even
                if (i % 2 != 0)
                {
                    pictureBoxes[i].Location = new Point((nbHints * 15), 0);
                }
                else
                {
                    pictureBoxes[i].Location = new Point(10, 25);
                }
                pictureBoxes[i].Image = Image.FromFile(selectImage(Motor.indic[i - nbHints]));
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(pictureBoxes[i]);
            }
            nbHints += 4;
        }

        public void win()
        {   
      
            this.Controls.Remove(Submit);
            
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
        }
        
        public void fail()
        {   
            
            this.Controls.Remove(Submit);
            
            PictureBox failPic = new PictureBox();
            failPic.Name = "pictureB" + (nbBoxes + 1).ToString();
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
        }

        private void yes_Click(object sender, EventArgs e)
        {//reload form1
            Application.Restart();
        }

        private void no_Click(object sender, EventArgs e)
        {//close the application
            Application.Exit();
        }

        //create btn_Click function with num parameter
        private void btn_Click(object sender, EventArgs e)
        {
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
            
            if (Motor.choixJoueur[returnIndex(num)] > 5)
            {
                Motor.choixJoueur[returnIndex(num)] = 0;
            }
            else if(Motor.choixJoueur[returnIndex(num)] < 0)
            {
                Motor.choixJoueur[returnIndex(num)] = 6;
            }
            PicBox(returnIndex(num)).Image = Image.FromFile(selectImage(Motor.choixJoueur[returnIndex(num)]));
        }
    }
}