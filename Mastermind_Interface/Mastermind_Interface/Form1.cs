namespace Mastermind_Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialize all picture boxes to image 1
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

    }
}