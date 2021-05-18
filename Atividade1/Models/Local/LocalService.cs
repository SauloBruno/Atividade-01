using System;
using System.Collections.Generic;
using System.Linq;
using Atividade1.Data;

namespace Atividade1.Models.Local
{
    public class LocalService
    {
        private readonly DataBaseContext _dataBaseContext;

        public LocalService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public void InserirLocal(string nome, string cidade, string bairro, int capacidade)
        {
            var local = new LocalEntity()
            {
                Nome = nome,
                Cidade = cidade,
                Bairro = bairro,
                Capacidade = capacidade
            };

            _dataBaseContext.Local.Add(local);
            _dataBaseContext.SaveChanges();
            
        }

        public LocalEntity BuscarPeloNome(string nome)
        {
            try
            {
                return _dataBaseContext.Local.Single(l => l.Nome.Equals(nome));
            }
            catch (Exception e)
            {
                var local = new LocalEntity();
                local.Nome = "vazio";
                return local;
            }
            
        }
        
        public List<LocalEntity> BuscarTodos()
        {
            return _dataBaseContext.Local.ToList();
        }

        public void Remover(Guid id)
        {
            var local = _dataBaseContext.Local.Find(id);
            _dataBaseContext.Local.Remove(local);
            _dataBaseContext.SaveChanges();
        }

        public LocalEntity BuscarPeloId(Guid id)
        {
            var lc = _dataBaseContext.Local.Single(l => l.Id.Equals(id));
            return lc;
        }

        public void Editar(Guid ac, string nome, string cidade, string bairro, int capacidade)
        {
            var local = _dataBaseContext.Local.Find(ac);
            local.Nome = nome;
            local.Cidade = cidade;
            local.Bairro = bairro;
            local.Capacidade = capacidade;

            _dataBaseContext.Local.Update(local);
            _dataBaseContext.SaveChanges();
        }

        public List<LocalEntity> BuscarLocalFiltro(string p2, string p3)
        {
            var lc = _dataBaseContext.Local.AsQueryable();

            if (p2 != null)
            {
                lc = lc.Where(l => l.Nome.Contains(p2));
            }
            
            if (p3 != null)
            {
                lc = lc.Where(l => l.Bairro.Contains(p3));
            }

            return lc.ToList();
        }
    }
}