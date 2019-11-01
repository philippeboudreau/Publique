namespace TraitementFichierClient.Client
{
    public class ClientSourceDeux : ClientBase
    {
        private const int POSITION_NOM = 2;
        private const int POSITION_PRENOM = 3;
        private const char CARACTERE_SEPARATION = '|';

        public ClientSourceDeux(string contenuLigne)
        {
            var contenuLigneDivise = contenuLigne.Split(CARACTERE_SEPARATION);
            Nom = contenuLigneDivise[POSITION_NOM];
            Prenom = contenuLigneDivise[POSITION_PRENOM];
        }
    }
}
