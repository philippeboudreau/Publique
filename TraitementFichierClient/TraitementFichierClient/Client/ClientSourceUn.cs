namespace TraitementFichierClient.Client
{
    public class ClientSourceUn : ClientBase
    {
        private const int POSITION_NOM = 0;
        private const int POSITION_PRENOM = 1;
        private const char CARACTERE_SEPARATION = ';';

        public ClientSourceUn(string contenuLigne)
        {
            var contenuLigneDivise = contenuLigne.Split(CARACTERE_SEPARATION);
            Nom = contenuLigneDivise[POSITION_NOM];
            Prenom = contenuLigneDivise[POSITION_PRENOM];
        }
    }
}
