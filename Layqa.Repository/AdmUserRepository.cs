using Layqa.Entity;

namespace Layqa.Repository
{
    public class AdmUserRepository : GenericRepository<EFLayqaRepository, AdmUser>
    {
        public AdmUserRepository(EFLayqaRepository context)
            : base(context)
        {
        }
    }

}
