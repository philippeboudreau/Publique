using System;

namespace Composante
{
    public class Classe
    {
        private readonly ICollaborateur _collaborateur;

        public Classe(ICollaborateur collaborateur)
        {
            _collaborateur = collaborateur;
        }

        public void Methode(string valeur, int repetition)
        {
            for (int cpt = 0; cpt < repetition; cpt++)
            {
                _collaborateur.Methode(valeur);
            }
           
        }

        public int Methode2(string valeur, int repetition)
        {
            int retour = 0;
            for (int cpt = 0; cpt < repetition; cpt++)
            {
                retour += _collaborateur.Methode2(valeur);
            }

            return retour;
        }
    }
}
