
namespace Core.Repositories
{
    public interface IAlertaRepository
    {

        public Task<IActionResult> GetAllAlerta();

        public Task<Alerta> CreateAlerta(Alerta alerta);

        public Task<Alerta> UpdateAlertas(Alerta alerta);
        public Task<IActionResult> DeleteAlertas(Guid Id);
    }
}

