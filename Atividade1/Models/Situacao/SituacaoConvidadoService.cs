using Atividade1.Data;

namespace Atividade1.Models.Situacao
{
    public class SituacaoConvidadoService
    {
        private readonly DataBaseContext _dataBaseContext;

        public SituacaoConvidadoService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
    }
}