namespace Mastermind_Interface
{
    public partial class Form1 : Form
    {

        private int nbBoxes;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialize 4 fist picture boxes to image 0
            pictureBox1.Image = Image.FromFile(selectImage(0));
            pictureBox2.Image = Image.FromFile(selectImage(0));
            pictureBox3.Image = Image.FromFile(selectImage(0));
            pictureBox4.Image = Image.FromFile(selectImage(0));
        }

        private string selectImage(int num)
        {
            //take number and return the name of the image
            switch (num)
            {
                case 0:
                    return "green.png";
                case 1:
                    return "red.png";
                case 2:
                    return "blue.png";
                case 3:
                    return "pink.png";
                case 4:
                    return "yellow.png";
                case 5:
                    return "purple.png";
                case 6:
                    return "white.png";
                default:
                    return "green.png";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {// frame 1 -
            
            if (Motor.choixJoueur[0] <= 0)
            {
                Motor.choixJoueur[0]=5;
            }
            else
            {

                Motor.choixJoueur[0]--;
            }
            pictureBox1.Image = Image.FromFile(selectImage(Motor.choixJoueur[0]));
        }

        private void button2_Click(object sender, EventArgs e)
        {// frame 1 +

            if (Motor.choixJoueur[0] >= 5)
            {
                Motor.choixJoueur[0] = 0;
            }
            else
            {

                Motor.choixJoueur[0]++;
            }
            pictureBox1.Image = Image.FromFile(selectImage(Motor.choixJoueur[0]));
        }

        private void button3_Click(object sender, EventArgs e)
        {// frame 2 -

            if (Motor.choixJoueur[1] <= 0)
            {
                Motor.choixJoueur[1] = 5;
            }
            else
            {

                Motor.choixJoueur[1]--;
            }
            pictureBox2.Image = Image.FromFile(selectImage(Motor.choixJoueur[1]));
        }

        private void button4_Click(object sender, EventArgs e)
        {// frame 2 +

            if (Motor.choixJoueur[1] >= 5)
            {
                Motor.choixJoueur[1] = 0;
            }
            else
            {

                Motor.choixJoueur[1]++;
            }
            pictureBox2.Image = Image.FromFile(selectImage(Motor.choixJoueur[1]));

        }

        private void button5_Click(object sender, EventArgs e)
        {// frame 3 -

            if (Motor.choixJoueur[2] <= 0)
            {
                Motor.choixJoueur[2] = 5;
            }
            else
            {

                Motor.choixJoueur[2]--;
            }
            pictureBox3.Image = Image.FromFile(selectImage(Motor.choixJoueur[2]));

        }

        private void button6_Click(object sender, EventArgs e)
        {// frame 3 +

            if (Motor.choixJoueur[2] >= 5)
            {
                Motor.choixJoueur[2] = 0;
            }
            else
            {

                Motor.choixJoueur[2]++;
            }
            pictureBox3.Image = Image.FromFile(selectImage(Motor.choixJoueur[2]));

        }

        private void button7_Click(object sender, EventArgs e)
        {// frame 4 -

            if (Motor.choixJoueur[3] <= 0)
            {
                Motor.choixJoueur[3] = 5;
            }
            else
            {

                Motor.choixJoueur[3]--;
            }
            pictureBox4.Image = Image.FromFile(selectImage(Motor.choixJoueur[3]));

        }
        private void button8_Click(object sender, EventArgs e)
        {// frame 4 +

            if (Motor.choixJoueur[3] >= 5)
            {
                Motor.choixJoueur[3] = 0;
            }
            else
            {

                Motor.choixJoueur[3]++;
            }
            pictureBox4.Image = Image.FromFile(selectImage(Motor.choixJoueur[3]));

        }
        private void button13_Click(object sender, EventArgs e)
        {//submit
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
                pictureBoxes[i].Name = "pictureBox" + (i + 1).ToString();
                pictureBoxes[i].Size = new Size(50, 50);
                pictureBoxes[i].Location = new Point((nbBoxes * 15) + 25 , (i * 50) - (nbBoxes * 50) + 50);
                pictureBoxes[i].Image = Image.FromFile(selectImage(Motor.choixJoueur[i - nbBoxes]));
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(pictureBoxes[i]);
            }
            nbBoxes += 4;
        }

        private void yes_Click(object sender, EventArgs e)
        {//reload form1
            Application.Restart();
        }

        private void no_Click(object sender, EventArgs e)
        {//close the application
            Application.Exit();
        }

        public void win()
        {   
            this.Controls.Remove(pictureBox1);
            this.Controls.Remove(pictureBox2);
            this.Controls.Remove(pictureBox3);
            this.Controls.Remove(pictureBox4);
            this.Controls.Remove(button1);
            this.Controls.Remove(button2);
            this.Controls.Remove(button3);
            this.Controls.Remove(button4);
            this.Controls.Remove(button5);
            this.Controls.Remove(button6);
            this.Controls.Remove(button7);
            this.Controls.Remove(button8);
            this.Controls.Remove(button13);
            
            PictureBox winPic = new PictureBox();
            winPic.Name = "pictureBox" + (nbBoxes + 1).ToString();
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
            this.Controls.Remove(pictureBox1);
            this.Controls.Remove(pictureBox2);
            this.Controls.Remove(pictureBox3);
            this.Controls.Remove(pictureBox4);
            this.Controls.Remove(button1);
            this.Controls.Remove(button2);
            this.Controls.Remove(button3);
            this.Controls.Remove(button4);
            this.Controls.Remove(button5);
            this.Controls.Remove(button6);
            this.Controls.Remove(button7);
            this.Controls.Remove(button8);
            this.Controls.Remove(button13);
            
            PictureBox failPic = new PictureBox();
            failPic.Name = "pictureBox" + (nbBoxes + 1).ToString();
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
    }
}