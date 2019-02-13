using Layqa.Entity;

namespace Layqa.Repository
{
    public class SchemaRepository : GenericRepository<EFLayqaRepository, Schema>
    {
        public SchemaRepository(EFLayqaRepository context)
            : base(context)
        {
        }
    }

}
