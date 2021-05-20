using System;
using System.Collections.Generic;
using System.Linq;
using Atividade1.Data;

namespace Atividade1.Models.Evento
{
    public class TipoEventoService
    {
        private readonly DataBaseContext _dataBaseContext;

        public TipoEventoService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public void inserir(string descricao)
        {
            var te = new TipoEventoEntity();
            te.Tipo = descricao;

            _dataBaseContext.TipoEvento.Add(te);
            _dataBaseContext.SaveChanges();
        }

        public List<TipoEventoEntity> BuscarFiltro(string val)
        {
            var ls = _dataBaseContext.TipoEvento
                .AsQueryable();

            if (val != null)
            {
                ls = ls.Where(l => l.Tipo.Contains(val));
            }

            return ls.ToList();

        }
        
        public List<TipoEventoEntity> BuscarTodos()
        {
            return _dataBaseContext.TipoEvento.ToList();
        }
        
        public TipoEventoEntity BuscarPeloTipo(string tipo)
        {
            try
            {
                return _dataBaseContext.TipoEvento.Single(e => e.Tipo.Equals(tipo));
            }
            catch (Exception e)
            {
                var tev = new TipoEventoEntity();
                tev.Tipo = "vazio";
                return tev;
            }
            
        }

        public TipoEventoEntity BuscarPeloId(Guid id)
        {
            return _dataBaseContext.TipoEvento.Find(id);
        }
    }
}