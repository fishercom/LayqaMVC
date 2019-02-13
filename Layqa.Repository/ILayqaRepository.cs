using Layqa.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layqa.Repository
{
    public interface ILayqaRepository : IDisposable
    {
        IGenericRepository<AdmProfile> AdmProfileRepository { get; }
        IGenericRepository<AdmUser> AdmUserRepository { get; }
        IGenericRepository<WebUser> WebUserRepository { get; }
        IGenericRepository<AdmMenu> AdmMenuRepository { get; }
        IGenericRepository<Post> PostRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<Template> TemplateRepository { get; }
        IGenericRepository<Schema> SchemaRepository { get; }
        IGenericRepository<Article> ArticleRepository { get; }

        void Commit();
    }
}
