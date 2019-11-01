using System.Threading.Tasks;
using TraitementFichierClient.Interface;

namespace TraitementFichierClient
{
    public class TraiteurFichier
    {
        private readonly ILecteurFichier _lecteurFichier;
        private readonly IBaseDonnee _baseDonnee;

        public TraiteurFichier(ILecteurFichier lecteurFichier, IBaseDonnee baseDonnee)
        {
            _lecteurFichier = lecteurFichier;
            _baseDonnee = baseDonnee;
        }

        public void Executer()
        {
            var listeClient = _lecteurFichier.ObtenirListeClient();

            Parallel.ForEach(listeClient, (client) => _baseDonnee.AjouterClient(client));

        }
    }
}
