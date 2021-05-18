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
    }
}