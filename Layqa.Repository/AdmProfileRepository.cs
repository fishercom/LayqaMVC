using Layqa.Entity;

namespace Layqa.Repository
{
    public class AdmProfileRepository : GenericRepository<EFLayqaRepository, AdmProfile>
    {
        public AdmProfileRepository(EFLayqaRepository context)
            : base(context)
        {
        }
    }

}
