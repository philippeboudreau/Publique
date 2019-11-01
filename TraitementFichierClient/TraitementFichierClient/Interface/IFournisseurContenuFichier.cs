using System;
using System.Collections.Generic;
using System.Text;

namespace TraitementFichierClient.Interface
{
    public interface IFournisseurContenuFichier
    {
        IList<string> LireContenuFichier(string nomFichier);
    }
}
