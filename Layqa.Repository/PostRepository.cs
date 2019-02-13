using Layqa.Entity;

namespace Layqa.Repository
{
    public class PostRepository : GenericRepository<EFLayqaRepository, Post>
    {
        public PostRepository(EFLayqaRepository context)
            : base(context)
        {
        }
    }

}
