namespace Mastermind_Interface
{
    using System;

    using System.Linq;

    public class choixUnit
    {
        public bool estCommun { get; set; }
        public bool estIndic { get; set; }
        public int idColor { get; set; }

        public string getColor()
        {
            //switch to return color name
            switch (idColor)
            {
                case 0: return "green ";
                case 1: return "red ";
                case 2: return "blue ";
                case 3: return "pink ";
                case 4: return "yellow ";
                case 5: return "purple ";
                case 6: return "orange ";
                case 7: return "white ";
                case 8: return "none ";
                default: return "error ";
            }
        }
    }



    public class Motor
    {
        public static choixUnit[] choixPC = randomTab();
        public static int[] choixJoueurEnter = { 0, 0, 0, 0 };
        public static int[] indic = { 8, 8, 8, 8 };
        //public static bool phaseJeu = false;
        public static int nbJeu = 0;

        public static int genererRandom()
        {//permet de générer un chiffre aléatoire entre 1 et 6
            Random rd = new Random();
            int rand_num = rd.Next(0, 7);
            return rand_num;
        }
        public static choixUnit[] randomTab()
        {
            choixUnit[] tab = new choixUnit[4];
            for (int i = 0; i < 4; i++)
            {
                tab[i] = new choixUnit
                {
                    estCommun = false,
                    estIndic = false,
                    idColor = genererRandom()
                };
            }
            return tab;
        }
        public static void resetHint()
        {
            //set indic to 8
            for (int i = 0; i < 4; i++)
            {
                indic[i] = 8;
            }
        }
        public static int returnEmptyHint()
        {
            for (int i = 0; i < 4; i++)
            {
                if (indic[i] == 8)
                {
                    return i;
                }
            }
            return 0; //bidouille
        }

        public static string listToString(choixUnit[] tab)
        {
            string str = "";
            foreach (choixUnit choix in tab)
            {
                str +=" , " + choix.getColor();
            }
            return str;
        }


        public static int nbCommun(choixUnit[] TabPC, choixUnit[] TabJoueur)
        {//pour chaque chiffre du tableau, si il est dans le tableau du joueur, on incrémente le compteur
            //variables locale
            int cpt = 0;
            choixUnit[] choixPC2 = TabPC.ToArray();
            choixUnit[] choixJoueur2 = TabJoueur.ToArray();

            Console.WriteLine("choix PC : " + listToString(choixPC2));
            Console.WriteLine("choix Joueur : " + listToString(choixJoueur2));
            Console.WriteLine("========================================");

            for (int i = 0; i < 4; i++)
            {
                if (choixPC2[i].idColor == choixJoueur2[i].idColor && choixJoueur2[i].estCommun == false && choixPC2[i].estCommun == false)
                {
                    choixPC2[i].estCommun = true;
                    choixJoueur2[i].estCommun = true;
                    cpt++;
                    Console.WriteLine("indice rouge pour pc :" + choixPC2[i].getColor() + " et joueur : " + choixJoueur2[i].getColor());
                }
            }

            if (cpt == 4)
            {
                Program.form1.win();
            }
            else
            {



                foreach (choixUnit choixJ in choixJoueur2)
                {

                    foreach (choixUnit choixP in choixPC2)
                    {

                        if (choixJ.idColor == choixP.idColor && choixJ.estIndic == false && choixP.estIndic == false)
                        {
                            choixJ.estIndic = true;
                            choixP.estIndic = true;
                            //indic[returnEmptyHint()] = 7;
                            //Console.WriteLine("indice blanc pour pc :" + choixP.getColor() + " et joueur : " + choixJ.getColor());
                        }
                        Console.WriteLine("Couleur pc : "+choixP.getColor() + " Commun : "+choixP.estCommun +" et Indic : "+choixP.estIndic);
                    }
                    if (choixJ.estCommun == true || choixJ.estIndic ==true)
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Couleur joueur : "+choixJ.getColor() + " Commun : "+choixJ.estCommun +" et Indic : "+choixJ.estIndic);
                        Console.ResetColor();
                    }
                    Console.WriteLine("Couleur joueur : "+choixJ.getColor() + " Commun : "+choixJ.estCommun +" et Indic : "+choixJ.estIndic);

                    if (choixJ.estIndic==true)
                    {
                        choixJ.estIndic = false;
                        indic[returnEmptyHint()] = 7;
                    }
                    else if (choixJ.estCommun==true)
                    {
                        choixJ.estCommun = false;
                        indic[returnEmptyHint()] = 1;
                    }
                }
            }
            return cpt;
        }
        public static void game()
        {
            choixUnit[] choixJoueur = new choixUnit[4];
            for (int i = 0; i < 4; i++)
            {
                choixJoueur[i] = new choixUnit
                {
                    estCommun = false,
                    estIndic = false,
                    idColor = choixJoueurEnter[i]
                };
            }

            if (nbJeu <= 14)
            {
                //soit 16 manches 
                nbJeu += 1;
                resetHint();
                nbCommun(choixPC, choixJoueur);
            }
            else
            {
                resetHint();
                if (nbCommun(choixPC, choixJoueur) != 4)
                {
                    //execute fail() in Form1
                    Program.form1.fail();
                }
            }
        }
    }
}