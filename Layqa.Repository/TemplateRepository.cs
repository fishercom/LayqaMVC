using Layqa.Entity;

namespace Layqa.Repository
{
    public class TemplateRepository : GenericRepository<EFLayqaRepository, Template>
    {
        public TemplateRepository(EFLayqaRepository context)
            : base(context)
        {
        }
    }

}
