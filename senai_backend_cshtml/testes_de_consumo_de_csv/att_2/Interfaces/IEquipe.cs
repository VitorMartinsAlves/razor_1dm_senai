using System.Collections.Generic;
using Models;

namespace Interfaces {
    public interface IEquipe {
        void Create (Equipe e);

        List<Equipe> ReadAll ();

        void Update (Equipe e);

        void Delete (int id);
    }
}