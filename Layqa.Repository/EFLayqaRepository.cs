namespace Layqa.Repository
{
    using Entity;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFLayqaRepository : DbContext, ILayqaRepository
    {
        private readonly AdmProfileRepository _AdmProfileRepo;
        private readonly AdmUserRepository _AdmUserRepo;
        private readonly AdmMenuRepository _AdmMenuRepo;
        private readonly WebUserRepository _WebUserRepo;
        private readonly CommentRepository _CommentRepo;
        private readonly TemplateRepository _TemplateRepo;
        private readonly SchemaRepository _SchemaRepo;
        private readonly ArticleRepository _ArticleRepo;
        private readonly PostRepository _PostRepo;

        public DbSet<AdmProfile> AdmProfilees { get; set; }
        public DbSet<AdmUser> AdmUser { get; set; }
        public DbSet<AdmMenu> AdmMenus { get; set; }
        public DbSet<WebUser> WebUser { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Schema> Schemas { get; set; }
        public DbSet<Article> Articles { get; set; }

        public EFLayqaRepository()
            : base("name=EFLayqaRepository")
        {
            _AdmProfileRepo = new AdmProfileRepository(this);
            _AdmUserRepo = new AdmUserRepository(this);
            _AdmMenuRepo = new AdmMenuRepository(this);
            _WebUserRepo = new WebUserRepository(this);

            _CommentRepo = new CommentRepository(this);
            _TemplateRepo = new TemplateRepository(this);
            _SchemaRepo = new SchemaRepository(this);
            _ArticleRepo = new ArticleRepository(this);
            _PostRepo = new PostRepository(this);
        }

        #region IUnitOfWork Implementation
        public void Commit()
        {
            this.SaveChanges();
        }
        #endregion

        public IGenericRepository<AdmProfile> AdmProfileRepository
        {
            get { return _AdmProfileRepo; }
        }

        public IGenericRepository<AdmUser> AdmUserRepository
        {
            get { return _AdmUserRepo; }
        }

        public IGenericRepository<WebUser> WebUserRepository
        {
            get { return _WebUserRepo; }
        }

        public IGenericRepository<AdmMenu> AdmMenuRepository
        {
            get { return _AdmMenuRepo; }
        }

        public IGenericRepository<Comment> CommentRepository
        {
            get { return _CommentRepo; }
        }

        public IGenericRepository<Template> TemplateRepository
        {
            get { return _TemplateRepo; }
        }
        public IGenericRepository<Schema> SchemaRepository
        {
            get { return _SchemaRepo; }
        }
        public IGenericRepository<Article> ArticleRepository
        {
            get { return _ArticleRepo; }
        }

        public IGenericRepository<Post> PostRepository
        {
            get { return _PostRepo; }
        }

    }
}