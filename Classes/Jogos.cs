using System;

namespace dio.games
{
    public class Jogos : EntidadeBase
    {
        private Genero Genero { get; set; }
        private Plataforma Plataforma { get; set; }
        private string Titulo { get; set; }
        private string Estudio { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }  

        public Jogos(int id, Genero genero, Plataforma plataforma, string titulo, string estudio, string descricao, int ano)
        {
            this.Id         = id;
            this.Genero     = genero;
            this.Plataforma = plataforma;
            this.Titulo     = titulo;
            this.Estudio    = estudio;
            this.Descricao  = descricao;
            this.Ano        = ano;
            this.Excluido   = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: "        + this.Genero     + Environment.NewLine;
            retorno += "Plataforma: "    + this.Plataforma + Environment.NewLine;
            retorno += "Título: "        + this.Titulo     + Environment.NewLine;
            retorno += "Estudio: "       + this.Estudio    + Environment.NewLine;
            retorno += "Descrição: "     + this.Descricao  + Environment.NewLine;
            retorno += "Ano de inicio: " + this.Ano        + Environment.NewLine;
            retorno += "Excluido: "      + this.Excluido;
            return retorno;                
        }

         public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}