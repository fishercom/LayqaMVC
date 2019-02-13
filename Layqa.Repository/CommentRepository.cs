using Layqa.Entity;

namespace Layqa.Repository
{
    public class CommentRepository : GenericRepository<EFLayqaRepository, Comment>
    {
        public CommentRepository(EFLayqaRepository context)
            : base(context)
        {
        }
    }

}
