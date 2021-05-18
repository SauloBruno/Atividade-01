using Atividade1.Data;

namespace Atividade1.Models.Situacao
{
    public class SituacaoEventoService
    {
        private readonly DataBaseContext _dataBaseContext;

        public SituacaoEventoService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
    }
}