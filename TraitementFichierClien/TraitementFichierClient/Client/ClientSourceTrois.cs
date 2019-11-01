namespace TraitementFichierClient.Client
{
    public class ClientSourceTrois : ClientBase
    {
        private const int POSITION_NOM = 5;
        private const int POSITION_PRENOM = 6;
        private const char CARACTERE_SEPARATION = '&';

        public ClientSourceTrois(string contenuLigne)
        {
            var contenuLigneDivise = contenuLigne.Split(CARACTERE_SEPARATION);
            Nom = contenuLigneDivise[POSITION_NOM];
            Prenom = contenuLigneDivise[POSITION_PRENOM];
        }
    }
}
