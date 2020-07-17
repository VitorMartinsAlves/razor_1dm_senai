using System.Collections.Generic;
using Models;

namespace Interfaces {
    public interface INoticias {
        void Create (Noticias e);

        List<Noticias> ReadAll ();

        void Update (Noticias e);

        void Delete (int id);
    }
}