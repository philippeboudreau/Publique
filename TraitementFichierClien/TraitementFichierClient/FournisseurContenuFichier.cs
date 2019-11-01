using System.Collections.Generic;
using System.IO;
using TraitementFichierClient.Interface;

namespace TraitementFichierClient
{
    public class FournisseurContenuFichier : IFournisseurContenuFichier
    {
        public IList<string> LireContenuFichier(string nomFichier)
        {
            List<string> contenuFichier = new List<string>();
            if (File.Exists(nomFichier))
            {
                contenuFichier.AddRange(File.ReadAllLines(nomFichier));
            }

            return contenuFichier;
        }
    }
}
