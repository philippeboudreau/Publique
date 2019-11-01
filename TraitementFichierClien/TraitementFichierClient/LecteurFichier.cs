using System.Collections.Generic;
using System.Linq;
using TraitementFichierClient.Client;
using TraitementFichierClient.Interface;
using System.Threading.Tasks;

namespace TraitementFichierClient
{
    public class LecteurFichier : ILecteurFichier
    {
        private readonly IFournisseurContenuFichier _fournisseurContenuFichier;
        private const string NOM_FICHIER_SOURCE_UN = "FichierSourceUn.txt";
        private const string NOM_FICHIER_SOURCE_DEUX = "FichierSourceDeux.txt";
        private const string NOM_FICHIER_SOURCE_TROIS = "FichierSourceTrois.txt";

        public LecteurFichier(IFournisseurContenuFichier fournisseurContenuFichier)
        {
            _fournisseurContenuFichier = fournisseurContenuFichier;
        }
               
        public IList<ClientBase> ObtenirListeClient()
        {
            var listeClient = new System.Collections.Concurrent.ConcurrentBag<ClientBase>();

            var contenuFichierSourceUn = _fournisseurContenuFichier.LireContenuFichier(NOM_FICHIER_SOURCE_UN);
            var contenuFichierSourceDeux = _fournisseurContenuFichier.LireContenuFichier(NOM_FICHIER_SOURCE_DEUX);
            var contenuFichierSourceTrois = _fournisseurContenuFichier.LireContenuFichier(NOM_FICHIER_SOURCE_TROIS);

            if (contenuFichierSourceUn.Any())
            {
                Parallel.ForEach(contenuFichierSourceUn, (ligne) => listeClient.Add(new ClientSourceUn(ligne)));
            }
            if (contenuFichierSourceDeux.Any())
            {
                Parallel.ForEach(contenuFichierSourceDeux, (ligne) => listeClient.Add(new ClientSourceDeux(ligne)));
            }
            if (contenuFichierSourceTrois.Any())
            {
                Parallel.ForEach(contenuFichierSourceTrois, (ligne) => listeClient.Add(new ClientSourceTrois(ligne)));
            }

            return listeClient.AsParallel().ToList();

        }
    }
}
