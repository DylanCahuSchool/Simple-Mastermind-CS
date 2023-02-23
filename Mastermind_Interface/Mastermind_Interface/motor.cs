namespace Mastermind_Interface
{
    using System.Collections.Generic;

    using System;

    using System.Linq;


    public class Motor
    {
        public static int[] choixPC = randomTab();
        public static int[] choixJoueur = { 0, 0, 0, 0 };
        public static int[] indic = { 8, 8, 8, 8 };
        public static bool phaseJeu = false;
        public static int nbJeu = 0;

        public static int genererRandom()
        {//permet de générer un chiffre aléatoire entre 1 et 6
            Random rd = new Random();
            int rand_num = rd.Next(1, 7);
            return rand_num;
        }
        public static int[] randomTab()
        {//génère un tableau de 4 chiffres aléatoires
            int[] tab = { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                tab[i] = genererRandom();
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
        public static int nbCommun(int[] TabPC, int[] TabJoueur)
        {//pour chaque chiffre du tableau, si il est dans le tableau du joueur, on incrémente le compteur
            //variables locale
            int cpt = 0;
            int[] choixPC2 = { 0, 0, 0, 0 };
            int[] choixPC3 = { 0, 0, 0, 0 };
            int[] choixJoueur2 = { 0, 0, 0, 0 };
            int[] choixJoueur3 = { 0, 0, 0, 0 };
            TabPC.CopyTo(choixPC2, 0);
            TabPC.CopyTo(choixPC3, 0);
            TabJoueur.CopyTo(choixJoueur2, 0);
            TabJoueur.CopyTo(choixJoueur3, 0);
            for (int i = 0; i < 4; i++)
            {
                if (choixPC2[i] == choixJoueur2[i])
                {
                    choixPC2[i] = -1;
                    choixJoueur2[i] = -2; //Pour supprimer les doublons
                    cpt = cpt + 1;
                    //indic[i] = 1;
                }
            }
            if (cpt == 4)
            {
                //execute fail() in Form1
                Program.form1.win();
            }
            else if (cpt > 0)
            {
                //for i in cpt indic[i]=1
                for (int i = 0; i < cpt; i++)
                {
                    indic[returnEmptyHint()] = 1;
                }

            }
            for (int i = 0; i < 4; i++)
            {//return white hint

                if (choixPC3[i] == choixJoueur3[0] && choixJoueur2[0] != -2 && choixPC2[i] != -1)
                {
                    choixPC3[i] = -1;
                    indic[returnEmptyHint()] = 7;
                    continue;
                }
                if (choixPC3[i] == choixJoueur3[1] && choixJoueur2[1] != -2 && choixPC2[i] != -1)
                {
                    choixPC3[i] = -1;
                    indic[returnEmptyHint()] = 7;
                    continue;
                }
                if (choixPC3[i] == choixJoueur3[2] && choixJoueur2[2] != -2 && choixPC2[i] != -1)
                {
                    choixPC3[i] = -1;
                    indic[returnEmptyHint()] = 7;
                    continue;
                }
                if (choixPC3[i] == choixJoueur3[3] && choixJoueur2[3] != -2 && choixPC2[i] != -1)
                {
                    choixPC3[i] = -1;
                    indic[returnEmptyHint()] = 7;
                    continue;
                }
            }
            return cpt;
        }
        public static void game()
        {
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