using Layqa.Entity;

namespace Layqa.Repository
{
    public class ArticleRepository : GenericRepository<EFLayqaRepository, Article>
    {
        public ArticleRepository(EFLayqaRepository context)
            : base(context)
        {
        }
    }

}
