using System.Collections.Generic;
using TraitementFichierClient.Client;

namespace TraitementFichierClient.Interface
{
    public interface ILecteurFichier
    {
        IList<ClientBase> ObtenirListeClient();
    }
}
