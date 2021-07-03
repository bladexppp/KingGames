using System;
using System.Collections.Generic;
using dio.games.Interfacess;

namespace dio.games
{
    public class JogosRepositorio : IRepositorio<Jogos>
    {
        private List<Jogos> listaJogos = new List<Jogos>();
        public void Atualiza(int id, Jogos entidade)
        {
            listaJogos[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaJogos[id].Excluir();
        }

        public void Insere(Jogos entidade)
        {
            listaJogos.Add(entidade);
        }

        public List<Jogos> Lista()
        {
            return listaJogos;
        }

        public int ProximoId()
        {
            return listaJogos.Count;
        }

        public Jogos RetornaPorId(int id)
        {
            return listaJogos[id];
        }
    }
}