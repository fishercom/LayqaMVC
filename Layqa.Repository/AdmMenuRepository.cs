using Layqa.Entity;

namespace Layqa.Repository
{
    public class AdmMenuRepository : GenericRepository<EFLayqaRepository, AdmMenu>
    {
        public AdmMenuRepository(EFLayqaRepository context)
            : base(context)
        {
        }
    }

}
