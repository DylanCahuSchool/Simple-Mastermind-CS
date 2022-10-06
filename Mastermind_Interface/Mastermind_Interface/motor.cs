namespace Mastermind_Interface
{

   // using Random ;

    using System.Collections.Generic;

    using System;

    using System.Linq;


    public class Motor
    {

        public static int[] choixPC = randomTab();

        public static int[] choixJoueur = {0,0,0,0};

        public static int[] indic = {0,0,0,0};

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


        public static int nbCommun(int[] TabPC, int[] TabJoueur)
        {//pour chaque chiffre du tableau, si il est dans le tableau du joueur, on incrémente le compteur
            //variables locale
            int cpt = 0;
            int[] choixPC2 = { 0, 0, 0, 0 };
            int[] choixJoueur2 = { 0, 0, 0, 0 };
            TabPC.CopyTo(choixPC2, 0);
            TabJoueur.CopyTo(choixJoueur2, 0);
            for (int i = 0; i < 4; i++)
            {
                if (choixPC2[i] == choixJoueur2[i])
                {
                    choixPC2[i] = -1;
                    choixJoueur2[i] = -2; //Pour supprimer les doublons
                    cpt = cpt + 1;
                    indic[i] = 1;
                }
            }
            if (cpt == 4)
            {
                Console.WriteLine("Bravo ! Tu as réussi. La solution été : ");
                Console.ReadLine();
            }
            else if (cpt > 1)
            {
                Console.WriteLine(cpt + " bonnes réponses, essaye encore !");
            }
            else
            {
                Console.WriteLine(cpt + " bonne réponse, essaye encore !");
            }
            for (int i = 0; i < 4; i++)
            {

                if (choixPC2[i] == choixJoueur2[0] || choixPC2[i] == TabJoueur[1] || choixPC2[i] == TabJoueur[2] || choixPC2[i] == TabJoueur[3])
                {   //TODO : Regarder si l'index de choixJoueur2 est bien celui a pointer en rouge.
                    Console.WriteLine("Mais " + choixJoueur2[i] + " est mal placé");
                }
            }
            return cpt;
        }

        public static void Jeu()
        {   
            if (nbJeu <= 10)
            {
                //soit 11 manches 
                nbJeu += 1;

                nbCommun(choixPC, choixJoueur);

            }
            else
            {
                //perdu
            }
        }
    }
}