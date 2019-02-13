using Layqa.Entity;

namespace Layqa.Repository
{
    public class WebUserRepository : GenericRepository<EFLayqaRepository, WebUser>
    {
        public WebUserRepository(EFLayqaRepository context)
            : base(context)
        {
        }
    }

}
