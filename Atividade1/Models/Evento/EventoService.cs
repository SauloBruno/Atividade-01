using System;
using System.Collections.Generic;
using System.Linq;
using Atividade1.Data;
using Atividade1.Models.Local;
using Atividade1.Models.Situacao;
using Microsoft.EntityFrameworkCore;

namespace Atividade1.Models.Evento
{
    public class EventoService
    {
        private readonly DataBaseContext _dataBaseContext;

        public EventoService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public EventoEntity BuscarPeloDescricao(string descricao)
        {
            try
            {
                return _dataBaseContext.Evento.Single(e => e.Descricao.Equals(descricao));
            }
            catch (Exception e)
            {
                var ev = new EventoEntity();
                ev.Descricao = "vazio";
                return ev;
            }
            
        }

        public void InserirEvento(Guid clienteid, string descricao, string tipo, string situacao, string observacao, string dataHoraInicio, string dataHoraTermino, string nome, string cidade, string bairro, int capacidade)
        {
            
            var clienteE = _dataBaseContext.Cliente.Find(clienteid);
            
            var tipoE = new TipoEventoEntity();
            tipoE.Tipo = tipo;

            _dataBaseContext.TipoEvento.Add(tipoE);
            
            var situacaoE = new SituacaoEventoEntity();
            situacaoE.Descricao = situacao;

            _dataBaseContext.SituacaoEvento.Add(situacaoE);
            
            var localE = new LocalEntity();
            localE.Nome = nome;
            localE.Cidade = cidade;
            localE.Bairro = bairro;
            localE.Capacidade = capacidade;

            _dataBaseContext.Local.Add(localE);

            var e = new EventoEntity();
            e.Cliente = clienteE;
            e.Descricao = descricao;
            e.TipoEvento = tipoE;
            e.Situacao = situacaoE;
            e.TextoObservacao = observacao;
            e.DataHoraInicio = DateTime.Parse(dataHoraInicio);
            e.DataHoraTermino = DateTime.Parse(dataHoraTermino);
            e.DataInsercao = DateTime.Now;
            e.DataUltimaModificacao = DateTime.Now;
            e.Local = localE;

            _dataBaseContext.Evento.Add(e);
            _dataBaseContext.SaveChanges();
        }

        public List<EventoEntity> BuscarTodos()
        {
            return _dataBaseContext.Evento
                .Include(e=> e.TipoEvento)
                .Include(e=> e.Situacao)
                .Include(e=> e.Local)
                .ToList();
        }

        public void Remover(Guid id)
        {
            var evento = _dataBaseContext.Evento.Find(id);
            _dataBaseContext.Evento.Remove(evento);
            _dataBaseContext.SaveChanges();
        }

        public EventoEntity BuscarPeloId(Guid id)
        {
            var ev = _dataBaseContext.Evento
                .Include(e=> e.TipoEvento)
                .Include(e=> e.Situacao)
                .Include(e=> e.Local)
                .Single(e => e.Id.Equals(id));

            return ev;
        }

        public void Editar(Guid id, string descricao, string tipoEvento, string situacaoEvento, string obs, string dhInicio, string dhTermino)
        {
            var ev = BuscarPeloId(id);

            ev.Descricao = descricao;
            ev.TipoEvento.Tipo = tipoEvento;
            ev.Situacao.Descricao = situacaoEvento;
            ev.TextoObservacao = obs;
            ev.DataHoraInicio = DateTime.Parse(dhInicio);
            ev.DataHoraTermino = DateTime.Parse(dhTermino);
            ev.DataUltimaModificacao = DateTime.Now;

            _dataBaseContext.Evento.Update(ev);
            _dataBaseContext.SaveChanges();

        }

        public List<EventoEntity> BuscarFiltro(string p2)
        {
            var ev = _dataBaseContext.Evento
                .Include(e=> e.TipoEvento)
                .Include(e=> e.Situacao)
                .Include(e=> e.Local)
                .AsQueryable();

            if (p2 != null)
            {
                ev = ev.Where(e => e.Descricao.Contains(p2));
            }

            return ev.ToList();
        }
    }
}