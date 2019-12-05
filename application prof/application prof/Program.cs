using System;
using System.Collections.Generic;
using System.Linq;
using DLLAccess;
using System.Text;
using System.Threading.Tasks;

namespace Test1_Console
{
    class Program
    {
        private const string CODE_EXIT = "EXIT";
        private const int NB_OPTIONS_MENU = 5;          // Nombre d'options dans le menu de 1 à 5

        //****************************************
        // sSaisieValeur
        // Gestion de la saisie des champs
        // TypeControl : 1 = Nombre  2=Alphanumérique 3=Libre, 4=Date 5=Menu
        // Parm2 :
        //********************************************
        static string sSaisieValeur(int TypeControl)
        {
            string sValeurSaisie = "";
            int iNombre = 0;
            bool bExitWhile = false;

            do
            {
                sValeurSaisie = Console.ReadLine();
                if (sValeurSaisie.ToUpper() != CODE_EXIT)
                {
                    switch (TypeControl)
                    {
                        case 1: //Entier
                            {
                                if (int.TryParse(sValeurSaisie, out iNombre) == true)
                                {
                                    bExitWhile = true;
                                }
                                else
                                {
                                    Console.WriteLine("Ce n'est pas un chiffre veuillez réssayer ");
                                }

                                break;
                            }
                        case 2: //Alphanumérique
                            {

                                break;
                            }
                        case 3: // Libre
                            {
                                bExitWhile = true;
                                break;
                            }
                        case 4: //Date
                            {
                                break;
                            }
                        case 5: //Controle Menu
                            {
                                if (int.TryParse(sValeurSaisie, out iNombre) == true)
                                {
                                    if ((iNombre >= 1) && (iNombre <= NB_OPTIONS_MENU))
                                    {
                                        bExitWhile = true;
                                    }
                                    else
                                        Console.WriteLine("Vous devez saisir une option entre 1 et 5");
                                }

                                break;
                            }
                    }
                }
                else
                {
                    sValeurSaisie = sValeurSaisie.ToUpper();        // On force la saisie en majuscule pour qu'il renvoie EXIT systématiquement
                    bExitWhile = true;
                }
            }
            while (bExitWhile == false);

            return (sValeurSaisie);
        }

        /*************************************/
        // AFFICHER LES TABLES
        /*********************************/
        static void AfficherTableProfesseur(int iNumColone, int iNumColone1, int iNumColone2, int iNumColone3, int iNumColone4, int iNumColone5, int iNumColone6)
        {
            string[][] sListEnreg;

            sListEnreg = Access.Execute("SELECT * FROM PROFESSEUR");

            foreach (string[] sColonne in sListEnreg)
            {
                Console.WriteLine("n° " + sColonne[iNumColone] + " " + sColonne[iNumColone1] + " , " + sColonne[iNumColone2] + " , " + sColonne[iNumColone3] + " , " + sColonne[iNumColone4] + " , " + sColonne[iNumColone5] + " , " + sColonne[iNumColone6]);
            }

            Console.WriteLine("");
        }
        //*************************************/
        // INSERER UN PROFESSEUR
        /*********************************/
        static void InsererUnProfesseur()
        {
            bool bExitWhile = false;
            string sCommandSQL = "";
            string sValeurSaisie = "";
            string sValeurNom = "";
            string sValeurPrenom = "";
            string sValeurRue = "";
            string sValeurCP = "";
            string sValeurVille = "";
            string sValeurSalle = "";

            do
            {
                Console.WriteLine("Saisissez votre nom ");
                sValeurPrenom = sSaisieValeur(3);
                if (sValeurNom == CODE_EXIT)
                {
                    bExitWhile = true;      //Fin de la boucle
                }
                Console.WriteLine("Saisissez votre prenom ");
                sValeurNom = sSaisieValeur(3);
                if (sValeurNom == CODE_EXIT)
                {
                    bExitWhile = true;      //Fin de la boucle
                }
                Console.WriteLine("Saisissez votre rue");
                sValeurRue = sSaisieValeur(3);
                if (sValeurNom == CODE_EXIT)
                {
                    bExitWhile = true;      //Fin de la boucle
                }
                Console.WriteLine("Saisissez votre Code Postal");
                sValeurCP = sSaisieValeur(3);
                if (sValeurNom == CODE_EXIT)
                {
                    bExitWhile = true;      //Fin de la boucle
                }
                Console.WriteLine("Saisissez votre ville");
                sValeurVille = sSaisieValeur(3);
                if (sValeurNom == CODE_EXIT)
                {
                    bExitWhile = true;      //Fin de la boucle
                }
                Console.WriteLine("Saisissez votre Salle");
                sValeurSalle = sSaisieValeur(3);
                if (sValeurNom == CODE_EXIT)
                {
                    bExitWhile = true;      //Fin de la boucle
                }

                else
                {
                    Console.WriteLine("Voulez vous saisir ces données :");
                    Console.WriteLine("Le nom du professeur est" + " " + sValeurNom + "  ," + "Le prenom du professeur est" + " " + sValeurPrenom + "  ," + "La rue du professeur est" + " " + sValeurRue + "  ," + "Le code postal du professeur est" + " " + sValeurCP + "  ," + "La ville du professeur est" + " " + sValeurVille + "  ," + "La salle que vous avez si il y en a une" + " " + sValeurSalle);

                    sValeurSaisie = Console.ReadLine();

                    if (sValeurSaisie == "oui")
                    {
                        sCommandSQL = "INSERT INTO PROFESSEUR (ProfNom, ProfPrenom, ProfRue, ProfCP, ProfVille, ProfSalleDefaut  ) VALUES(\"" + sValeurNom + "\",  \"" + sValeurPrenom + "\", \"" + sValeurRue + "\", " + sValeurCP + ", \"" + sValeurVille + "\" , " + sValeurSalle + ")";

                        Access.Execute(sCommandSQL);

                        bExitWhile = true;  //Fin de la Boucle
                    }
                }
            }
            while (bExitWhile == false);

            //Access.Insertion("professeur", "ProfNom", "\""+ sNomDeLaValeur + "\"");
        }
        /*************************************/
        // SUPPRIMER UN PROFESSEUR
        /*********************************/
        static void SupprimerUnprofesseur()
        {
            bool bExitWhile = false;
            long lNumIdToDelete = 0;
            string sValeurSaisie = "";


            AfficherTableProfesseur(0, 1, 2, 3, 4, 5, 6);

            do
            {
                Console.WriteLine("Quelle professeur voulez-vous supprimer ?");
                sValeurSaisie = sSaisieValeur(1);
                if (sValeurSaisie == CODE_EXIT)
                {
                    bExitWhile = true;      //Je sors !!
                }
                else
                {
                    lNumIdToDelete = long.Parse(sValeurSaisie);    // On récupére la valeur saisie et on convertit


                    Console.WriteLine("êtes vous sur de vouloir supprimer " + sValeurSaisie);
                    sValeurSaisie = sSaisieValeur(3);
                    if (sValeurSaisie == "oui")
                    {
                        Access.ExecuteNoQuery("DELETE FROM professeur WHERE ProfId  = " + lNumIdToDelete);

                        bExitWhile = true;  //Sortie de boucle
                    }
                }
            }
            while (bExitWhile == false);
        }

        /*************************************/
        // MODIFIER UN professeur
        /*********************************/
        static void ModifierUnprofesseur()
        {
            string sValeurSaisie = "";
            long lngNumeroprofesseur = 0;
            string strNouvelleValeurprofesseur = "";
            string strNouvelleValeurprofNom = "";
            string strNouvelleValeurprofPrenom = "";
            string strNouvelleValeurprofRue = "";
            int strNouvelleValeurprofCP = 0;
            string strNouvelleValeurprofVille = "";
            int strNouvelleValeurprofSalle = 0;
            bool bExitWhile = false;

            do
            {
                AfficherTableProfesseur(0, 1, 2, 3, 4, 5, 6);

                Console.WriteLine("Saisissez le chiffre du professeur à modifier ?");
                sValeurSaisie = sSaisieValeur(1);
                if (sValeurSaisie == CODE_EXIT)
                {
                    bExitWhile = true;
                }
                else
                {
                    lngNumeroprofesseur = long.Parse(sValeurSaisie);

                    Console.WriteLine("Entrez votre modification");
                    sValeurSaisie = sSaisieValeur(3);
                    if (sValeurSaisie == CODE_EXIT)
                    {
                        bExitWhile = true;
                    }
                    else
                    {
                        strNouvelleValeurprofesseur = sValeurSaisie;

                        Console.WriteLine("êtes vous sur de modifier pour : " + strNouvelleValeurprofesseur);
                        sValeurSaisie = sSaisieValeur(3);
                        if (sValeurSaisie == CODE_EXIT)
                        {
                            bExitWhile = true;
                        }
                        else
                        {
                            if (sValeurSaisie == "oui")
                            {
                                {
                                    Console.WriteLine("Nom du professeur à ajouter ?");
                                    strNouvelleValeurprofNom = Console.ReadLine();
                                    Console.WriteLine("Prenom du professeur à ajouter ?");
                                    strNouvelleValeurprofPrenom = Console.ReadLine();
                                    Console.WriteLine("Adresse du professeur à ajouter ?");
                                    strNouvelleValeurprofRue = Console.ReadLine();
                                    Console.WriteLine("Code postale du professeur à ajouter ?");
                                    strNouvelleValeurprofCP = int.Parse(Console.ReadLine());
                                    Console.WriteLine("ville du professeur à ajouter ?");
                                    strNouvelleValeurprofVille = Console.ReadLine();
                                    Console.WriteLine("salle du professeur à ajouter ?");
                                    strNouvelleValeurprofSalle = int.Parse(Console.ReadLine());
                                    Access.Insertion("Professeur", "ProfNom, ProfPrenom,ProfRue,ProfCP,ProfVille,ProfSalleDefaut", "\"" + strNouvelleValeurprofNom + "\",\"" + strNouvelleValeurprofPrenom + "\",\"" + strNouvelleValeurprofRue + "\", " + strNouvelleValeurprofCP + ", \"" + strNouvelleValeurprofVille + "\", " + strNouvelleValeurprofSalle);
                                    bExitWhile = true;
                                }
                            }
                        }
                    }
                }
            } while (bExitWhile == false);
        }

        /*************************************/
        // CHOIX DE L'UTILISATEUR
        /*********************************/
        static int iSaisieChoixMenu()
        {
            int iValeurUtilisateur = 0;
            string sValeurSaisie = "";

            Console.WriteLine("Faites votre choix");

            sValeurSaisie = sSaisieValeur(5);       //Appel fonction avec Type MENU
            if (sValeurSaisie != CODE_EXIT)
            {
                iValeurUtilisateur = int.Parse(sValeurSaisie);
            }
            else
            {
                iValeurUtilisateur = 5;     //On simule que l'utilisateur a tapé 5
            }

            return (iValeurUtilisateur);
        }
        static void AfficheMenuprofesseur()
        {
            Console.Clear();    //Efface l'écran // caca lol mdr fallait pas laisser ton pc allumé sale merde

            Console.WriteLine("Gestion des professeurs", Console.Title);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);   //Agrandir l'écran de la console
            Console.WriteLine("Gestion des professeurs", Console.Title);

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("--||---------------- MENU PRINCIPAL -------------------||--");
            Console.WriteLine("--||-- 1- Afficher les professeurs                   --||--");
            Console.WriteLine("--||-- 2- Insérer un professeur                      --||--");
            Console.WriteLine("--||-- 3- Modifier un professeur                     --||--");
            Console.WriteLine("--||-- 4- Supprimer une valeleur                     --||--");
            Console.WriteLine("--||-- 5- Quitter                                    --||--");
            Console.WriteLine("------------------- Faites votre choix --------------------\n");
            Console.WriteLine("A tout moment vous tapez \"EXIT\"\n\n");
        }
        static void Main(string[] args)
        {
            bool bQuitter = false;
            int iValeurUtilisateur;

            Access.Init(@"D:\BTS SIO\PPE\Mission 5\Database_PPE1.accdb");

            while (!bQuitter)
            {
                AfficheMenuprofesseur();

                iValeurUtilisateur = iSaisieChoixMenu();

                switch (iValeurUtilisateur)
                {
                    case 1:
                        {
                            AfficherTableProfesseur(0, 1, 2, 3, 4, 5, 6);
                            break;
                        }
                    case 2:
                        {
                            InsererUnProfesseur();
                            break;
                        }

                    case 3:
                        {
                            ModifierUnprofesseur();
                            break;
                        }
                    case 4:
                        {
                            SupprimerUnprofesseur();
                            break;
                        }
                    case 5:
                        {
                            bQuitter = true;
                            break;
                        }
                }

                if (bQuitter == false)   //Si Sortie de menu, pas la peine de demander de saisir au clavier. On sort !
                {
                    Console.WriteLine("Tapez \"ENTRER\" pour revenir au menu principal ");
                    Console.ReadKey();
                }
            }
        }
    }
}
