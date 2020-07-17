using System;
using System.Collections.Generic;
using System.IO;
using Interfaces;

namespace Models {
    public class Noticias : EplayersBase, INoticias {

        public Noticias () {
            CreateFolderAndFile (PATH);
        }
        public void Create (Noticias e) {
            string[] linha = { PrepararLinha (e) };
            File.AppendAllLines (PATH, linha);
        }

        public void Delete (int id) {
            List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (x => x.Split (";") [0] == id.ToString ());
            RewriteCSV (PATH, linhas);
        }

        public List<Noticias> ReadAll () {
            List<Noticias> noticias = new List<Noticias> ();
            string[] linhas = File.ReadAllLines (PATH);
            foreach (var item in linhas) {
                string[] linha = item.Split (";");
                Noticias noticia = new Noticias ();
                noticia.IdNoticia = Int32.Parse (linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add (noticia);
            }
            return noticias;
        }

        public void Update (Noticias e) {
            List<string> linhas = ReadAllLinesCSV (PATH);
            linhas.RemoveAll (x => x.Split (";") [0] == e.IdNoticia.ToString ());
            linhas.Add (PrepararLinha (e));
            RewriteCSV (PATH, linhas);
        }

        private string PrepararLinha (Noticias e) {
            return $"{e.IdNoticia};{e.Titulo};{e.Texto};{e.Imagem}";
        }
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/noticias.csv";
    }
}