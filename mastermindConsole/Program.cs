namespace Namespace
{

   // using Random ;

    using System.Collections.Generic;

    using System;

    using System.Linq;


    public class Module
    {

        public static int[] choixPC = {0,0,0,0};

        public static int[] choixJoueur = {0,0,0,0};

        public static int genererRandom()
        {//permet de générer un chiffre aléatoire entre 1 et 6
            Random rd = new Random();
            int rand_num = rd.Next(1, 7);
            return rand_num;
        }
        
        public static void choixOrdinateur()
        {//génère un tableau de 4 chiffres aléatoires
            for (int i = 0; i < 4; i++)
            {
                choixPC[i] = genererRandom();
            }
        }


        public static int[] ChoixJoueur()
        {//transforme un int de 4 chiffre en tableau de ces 4 même chiffres

            Console.WriteLine("Veuillez taper chiffres entre 1 et 6"); 
            
            //variables locale
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(n);

            int choixvalide = 0;
            for (int i = 0; i < 4; i++)
            {
                choixJoueur[3 - i] = n % 10;
                n = (n - choixJoueur[3 - i]) / 10;
            }
            for (int i = 0; i < 4; i++)
            {
                if (0 < choixJoueur[i] && choixJoueur[i] < 7)
                {
                    choixvalide = choixvalide + 1;
                }
            }
            if (choixvalide == 4 && choixJoueur.Length == 4)
            {
                Console.WriteLine("Vous avez choisi : " + PrintValues(choixJoueur));
                Console.WriteLine("Et l'ordi a choisi : " + PrintValues(choixPC));
                return choixJoueur;
            }
            else
            {
                Console.WriteLine("entré invalide");
                ChoixJoueur();
                return choixJoueur; //bidouille
            }
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
                }
            }
            if (cpt == 4)
            {
                Console.WriteLine("Bravo ! Tu as réussi. La solution été : "+ PrintValues(TabPC));
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
                {
                    Console.WriteLine("Mais " + choixJoueur2[i] + " est mal placé");
                }
            }
            return cpt;
        }
        
        public static string PrintValues(int[] myArr)
        {
            string result = null;
            foreach (int i in myArr)
            {
                result = result + i;
            }
            return result;
        }

    public static void Jeu()
        {
            //variables locale
            var nbJeu = 0;
            choixOrdinateur();
            Console.WriteLine(PrintValues(choixPC)); //debug
            ChoixJoueur(); //1ère manche
            while (nbCommun(choixPC, choixJoueur) != 4)
            {
                if (nbJeu <= 10)
                {
                    //soit 11 manches de plus donc 12 manches totals
                    nbJeu += 1;
                    ChoixJoueur();
                }
                else
                {
                    Console.WriteLine("Perdu, c'était : "+ PrintValues(choixPC));
                }
            }
        }
        
        static void Main()
        {
            Jeu();
        }
    }
}