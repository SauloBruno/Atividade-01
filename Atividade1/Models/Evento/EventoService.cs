using Atividade1.Data;

namespace Atividade1.Models.Evento
{
    public class EventoService
    {
        private readonly DataBaseContext _dataBaseContext;

        public EventoService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
    }
}