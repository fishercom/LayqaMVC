namespace Layqa.Repository.Migrations
{
    using Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Layqa.Repository.EFLayqaRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Layqa.Repository.EFLayqaRepository context)
        {
            //  This method will be called after migrating to the latest version.
            #region AdmProfile
            var sa = new AdmProfile()
            {
                Name = "Administrador"
            };
            var Author = new AdmProfile()
            {
                Name = "Author"
            };
            #endregion

            #region WebUser
            var adminuser = new AdmUser()
            {
                Name = "Fischer",
                LastName = "Tirado",
                Email = "fishdev@gmail.com",
                RegisterDate = DateTime.Now,
                Active = true,
                AdmProfile = sa
            };
            #endregion

            #region AdmMenu
            var menu01 = new AdmMenu()
            {
                Name = "Dashboard",
                Controller = "Home",
                IconCss = "dashboard",
                Position = 1,
                Active = true
            };
            var menu02 = new AdmMenu()
            {
                Name = "Posts",
                Controller = "Post",
                IconCss = "tags",
                Position = 2,
                Active = true
            };
            var menu03 = new AdmMenu()
            {
                Name = "Páginas",
                Controller = "Article",
                IconCss = "globe",
                Position = 3,
                Active = true
            };
            var menu04 = new AdmMenu()
            {
                Name = "Configuración",
                IconCss = "edit",
                Position = 4,
                Active = true
            };
            var menu0401 = new AdmMenu()
            {
                Name = "Administradores",
                Controller = "AdmUser",
                Position = 1,
                Active = true,

                MenuParent = menu04
            };
            var menu0402 = new AdmMenu()
            {
                Name = "Usuarios Web",
                Controller = "WebUser",
                Position = 2,
                Active = true,

                MenuParent = menu04
            };
            var menu0403 = new AdmMenu()
            {
                Name = "Perfiles",
                Controller = "AdmProfile",
                Position = 3,
                Active = true,

                MenuParent = menu04
            };
            var menu0404 = new AdmMenu()
            {
                Name = "Esquemas del CMS",
                Controller = "Schema",
                Position = 4,
                Active = true,

                MenuParent = menu04
            };
            var menu0405 = new AdmMenu()
            {
                Name = "Plantillas del CMS",
                Controller = "Template",
                Position = 5,
                Active = true,

                MenuParent = menu04
            };
            #endregion

            #region Template
            var Template_SectionHome = new Template()
            {
                Name = "Sección Home Page",
                AdminView = "section",
                FrontView = "section_home",
                IsSection = true,
                Active = true
            };
            var Template_SectionServices = new Template()
            {
                Name = "Sección Servicios",
                AdminView = "section",
                FrontView = "section_services",
                IsSection = true,
                Active = true
            };
            var Template_SectionPortfolio = new Template()
            {
                Name = "Sección Portafolio",
                AdminView = "section",
                FrontView = "section_portfolio",
                IsSection = true,
                Active = true
            };
            var Template_SectionAbout = new Template()
            {
                Name = "Sección Acerca de",
                AdminView = "section",
                FrontView = "section_about",
                IsSection = true,
                Active = true
            };
            var Template_SectionTeam = new Template()
            {
                Name = "Sección Equipo",
                AdminView = "section",
                FrontView = "section_team",
                IsSection = true,
                Active = true
            };
            var Template_SectionContact = new Template()
            {
                Name = "Sección Contacto",
                AdminView = "section",
                FrontView = "section_contact",
                IsSection = true,
                Active = true
            };
            var Template_SectionBlog = new Template()
            {
                Name = "Sección Blog",
                AdminView = "section",
                FrontView = "section_blog",
                IsSection = true,
                Active = true
            };
            var Template_Parrafo = new Template()
            {
                Name = "Párrafo",
                AdminView = "parrafo",
                FrontView = "parrafo",
                Active = true
            };
            var Template_Pagina = new Template()
            {
                Name = "Página",
                AdminView = "pagina",
                FrontView = "pagina",
                Active = true
            };
            var Template_Contenedor = new Template()
            {
                Name = "Contenedor",
                AdminView = "contenedor",
                FrontView = "contenedor",
                Active = true
            };
            var Template_Enlace = new Template()
            {
                Name = "Enlace (link)",
                AdminView = "enlace",
                FrontView = "enlace",
                Active = true
            };
            var Template_Foto = new Template()
            {
                Name = "Foto de Galería",
                AdminView = "imagen",
                FrontView = "imagen",
                Active = true
            };
            var Template_Intro = new Template()
            {
                Name = "Párrafo de Intro",
                AdminView = "intro",
                FrontView = "intro",
                Active = true
            };
            var Template_Documento = new Template()
            {
                Name = "Documento",
                AdminView = "documento",
                FrontView = "documento",
                Active = true
            };
            var Template_Acceso = new Template()
            {
                Name = "Acceso Directo",
                AdminView = "acceso",
                FrontView = "acceso",
                Active = true
            };
            var Template_Noticia = new Template()
            {
                Name = "Noticia",
                AdminView = "noticia",
                FrontView = "noticia",
                Active = true
            };
            var Template_Widget = new Template()
            {
                Name = "Widget",
                AdminView = "widget",
                FrontView = "widget",
                Active = true
            };
            var Template_WidgetEnlace = new Template()
            {
                Name = "Widget con Enlace",
                AdminView = "widget_enlace",
                FrontView = "widget_enlace",
                Active = true
            };
            var Template_AnimacionHome = new Template()
            {
                Name = "Animación Home",
                AdminView = "contenedor",
                FrontView = "bloque_animacion",
                Active = true
            };
            var Template_BloqueAccesos = new Template()
            {
                Name = "Bloque de Accesos",
                AdminView = "contenedor",
                FrontView = "bloque_accesos",
                Active = true
            };
            var Template_BloqueWidgets = new Template()
            {
                Name = "Bloque de Widgets",
                AdminView = "contenedor",
                FrontView = "bloque_widgets",
                Active = true
            };
            var Template_BloqueNoticias = new Template()
            {
                Name = "Bloque de Noticias",
                AdminView = "contenedor",
                FrontView = "bloque_noticias",
                Active = true
            };
            var Template_Portafolio = new Template()
            {
                Name = "Portafolio",
                AdminView = "portafolio",
                FrontView = "portafolio",
                Active = true
            };
            var Template_Servicio = new Template()
            {
                Name = "Servicio",
                AdminView = "servicio",
                FrontView = "servicio",
                Active = true
            };
            var Template_Historia = new Template()
            {
                Name = "Historia",
                AdminView = "historia",
                FrontView = "historia",
                Active = true
            };
            var Template_Equipo = new Template()
            {
                Name = "Equipo",
                AdminView = "equipo",
                FrontView = "equipo",
                Active = true
            };
            var Template_Cliente = new Template()
            {
                Name = "Cliente",
                AdminView = "cliente",
                FrontView = "cliente",
                Active = true
            };
            var Template_PaginaNoticias = new Template()
            {
                Name = "Página de Noticias",
                AdminView = "contenedor",
                FrontView = "pagina_noticias",
                Active = true
            };
            var Template_FormularioContacto = new Template()
            {
                Name = "Formulario de Contacto",
                AdminView = "contenedor",
                FrontView = "form_contacto",
                Active = true
            };
            var Template_PaginaError = new Template()
            {
                Id = 98,
                Name = "Página de Error",
                AdminView = "contenedor",
                FrontView = "pagina_error",
                Active = true
            };
            var Template_Error = new Template()
            {
                Id = 99,
                Name = "Error",
                AdminView = "error",
                FrontView = "error",
                Active = true
            };
            #endregion

            #region Schema
            var Schema_Home = new Schema()
            {
                //Section = Section_Home,
                Template = Template_SectionHome,
                //Alias = "Sección Home",
                Iterations = 1,
                Position = 1,
                IsPage = false,
                Active = true,
            };
            var Schema_Services = new Schema()
            {
                //Section = Section_Services,
                Template = Template_SectionServices,
                //Alias = "Sección Servicios",
                Iterations = 1,
                Position = 2,
                IsPage = true,
                Active = true,
            };
            var Schema_Portfolio = new Schema()
            {
                //Section = Section_Portfolio,
                Template = Template_SectionPortfolio,
                //Alias = "Sección Portafolio",
                Iterations = 1,
                Position = 3,
                IsPage = true,
                Active = true,
            };
            var Schema_About = new Schema()
            {
                //Section = Section_About,
                Template = Template_SectionAbout,
                //Alias = "Sección Acerca de",
                Iterations = 1,
                Position = 4,
                IsPage = true,
                Active = true,
            };
            var Schema_Team = new Schema()
            {
                //Section = Section_Team,
                Template = Template_SectionTeam,
                //Alias = "Sección El Equipo",
                Iterations = 1,
                Position = 5,
                IsPage = true,
                Active = true,
            };
            var Schema_Contact = new Schema()
            {
                //Section = Section_Contact,
                Template = Template_SectionContact,
                //Alias = "Sección Contáctenos",
                Iterations = 1,
                Position = 6,
                IsPage = true,
                Active = true,
            };
            var Schema_Blog = new Schema()
            {
                //Section = Section_Blog,
                Template = Template_SectionBlog,
                //Alias = "Sección Blog",
                Iterations = 1,
                Position = 7,
                IsPage = true,
                Active = true,
            };
            var Schema_Home1 = new Schema()
            {
                SchemaParent = Schema_Home,
                //Section = Section_Home,
                Template = Template_AnimacionHome,
                Iterations = 1,
                Position = 1,
                IsPage = false,
                Active = true,
            };
            var Schema_Home11 = new Schema()
            {
                SchemaParent = Schema_Home1,
                //Section = Section_Home,
                Template = Template_Intro,
                Iterations = 1,
                Position = 1,
                IsPage = false,
                Active = true,
            };
            var Schema_Services1 = new Schema()
            {
                SchemaParent = Schema_Services,
                //Section = Section_Services,
                Template = Template_Servicio,
                Position = 1,
                IsPage = true,
                Active = true,
            };
            var Schema_Portfolio1 = new Schema()
            {
                SchemaParent = Schema_Portfolio,
                //Section = Section_Portfolio,
                Template = Template_Portafolio,
                Position = 1,
                IsPage = true,
                Active = true,
            };
            var Schema_About1 = new Schema()
            {
                SchemaParent = Schema_About,
                //Section = Section_About,
                Template = Template_Historia,
                Position = 1,
                IsPage = true,
                Active = true,
            };
            var Schema_Team1 = new Schema()
            {
                SchemaParent = Schema_Team,
                //Section = Section_Team,
                Template = Template_Contenedor,
                Alias = "Bloque Nuestro Equipo",
                Iterations = 1,
                Position = 1,
                IsPage = true,
                Active = true,
            };
            var Schema_Team2 = new Schema()
            {
                SchemaParent = Schema_Team,
                //Section = Section_Team,
                Template = Template_Contenedor,
                Alias = "Bloque Nuestros Clientes",
                Iterations = 1,
                Position = 1,
                IsPage = true,
                Active = true,
            };
            var Schema_Team11 = new Schema()
            {
                SchemaParent = Schema_Team1,
                //Section = Section_Team,
                Template = Template_Equipo,
                Position = 1,
                IsPage = false,
                Active = true,
            };
            var Schema_Team21 = new Schema()
            {
                SchemaParent = Schema_Team2,
                //Section = Section_Team,
                Template = Template_Cliente,
                Position = 1,
                IsPage = false,
                Active = true,
            };
            var Schema_Contact1 = new Schema()
            {
                SchemaParent = Schema_Contact,
                //Section = Section_Contact,
                Template = Template_FormularioContacto,
                Iterations = 1,
                Position = 1,
                IsPage = true,
                Active = true,
            };
            #endregion

            #region Article
            var Article_Home = new Article()
            {
                Schema = Schema_Home,
                Title = "Inicio",
                XmlParams = "<root><item key=\"hashtag\" value=\"#home\" /></root>",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Services = new Article()
            {
                Schema = Schema_Services,
                Title = "Servicios",
                SubTitle = "Lorem ipsum dolor sit amet consectetur.",
                XmlParams = "<root><item key=\"hashtag\" value=\"#services\" /></root>",
                Author = adminuser,
                Position = 2,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Portfolio = new Article()
            {
                Schema = Schema_Portfolio,
                Title = "Portafolio",
                SubTitle = "Lorem ipsum dolor sit amet consectetur.",
                XmlParams = "<root><item key=\"hashtag\" value=\"#portfolio\" /></root>",
                Author = adminuser,
                Position = 3,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_About = new Article()
            {
                Schema = Schema_About,
                Title = "Acerca de",
                SubTitle = "Lorem ipsum dolor sit amet consectetur.",
                XmlParams = "<root><item key=\"hashtag\" value=\"#about\" /></root>",
                Author = adminuser,
                Position = 4,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Team = new Article()
            {
                Schema = Schema_Team,
                Title = "El Equipo",
                SubTitle = "Lorem ipsum dolor sit amet consectetur.",
                XmlParams = "<root><item key=\"hashtag\" value=\"#team\" /></root>",
                Author = adminuser,
                Position = 5,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Contact = new Article()
            {
                Schema = Schema_Contact,
                Title = "Contáctenos",
                SubTitle = "Lorem ipsum dolor sit amet consectetur.",
                XmlParams = "<root><item key=\"hashtag\" value=\"#contact\" /></root>",
                Author = adminuser,
                Position = 6,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Home01 = new Article()
            {
                Schema = Schema_Home1,
                ArticleParent = Article_Home,
                Title = "Animación Home",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Home0101 = new Article()
            {
                Schema = Schema_Home11,
                ArticleParent = Article_Home01,
                Title = "Bienvenido a Nuestro Estudio!",
                SubTitle = "Es bueno conocerte",
                XmlParams = "<root><item key=\"url\" value=\"#services\" /><item key=\"tag\" value=\"Dime Más\" /></root>",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Services01 = new Article()
            {
                Schema = Schema_Services1,
                ArticleParent = Article_Services,
                Title = "E-Commerce",
                XmlParams = "<root><item key=\"css\" value=\"fa-shopping-cart\" /></root>",
                Resumen = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minima maxime quam architecto quo inventore harum ex magni, dicta impedit.",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Services02 = new Article()
            {
                Schema = Schema_Services1,
                ArticleParent = Article_Services,
                Title = "Responsive Design",
                XmlParams = "<root><item key=\"css\" value=\"fa-laptop\" /></root>",
                Resumen = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minima maxime quam architecto quo inventore harum ex magni, dicta impedit.",
                Author = adminuser,
                Position = 2,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Services03 = new Article()
            {
                Schema = Schema_Services1,
                ArticleParent = Article_Services,
                Title = "Web Security",
                XmlParams = "<root><item key=\"css\" value=\"fa-lock\" /></root>",
                Resumen = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minima maxime quam architecto quo inventore harum ex magni, dicta impedit.",
                Author = adminuser,
                Position = 3,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Portfolio01 = new Article()
            {
                Schema = Schema_Portfolio1,
                ArticleParent = Article_Portfolio,
                Title = "Round Icons",
                XmlParams = "<root><item key=\"image\" value=\"/img/portfolio/roundicons.png\" /></root>",
                SubTitle = "Graphic Design",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Portfolio02 = new Article()
            {
                Schema = Schema_Portfolio1,
                ArticleParent = Article_Portfolio,
                Title = "Startup Framework",
                XmlParams = "<root><item key=\"image\" value=\"/img/portfolio/startup-framework.png\" /></root>",
                SubTitle = "Website Design",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Portfolio03 = new Article()
            {
                Schema = Schema_Portfolio1,
                ArticleParent = Article_Portfolio,
                Title = "Treehouse",
                XmlParams = "<root><item key=\"image\" value=\"/img/portfolio/treehouse.png\" /></root>",
                SubTitle = "Website Design",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Portfolio04 = new Article()
            {
                Schema = Schema_Portfolio1,
                ArticleParent = Article_Portfolio,
                Title = "Golden",
                XmlParams = "<root><item key=\"image\" value=\"/img/portfolio/golden.png\" /></root>",
                SubTitle = "Website Design",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Portfolio05 = new Article()
            {
                Schema = Schema_Portfolio1,
                ArticleParent = Article_Portfolio,
                Title = "Escape",
                XmlParams = "<root><item key=\"image\" value=\"/img/portfolio/escape.png\" /></root>",
                SubTitle = "Website Design",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Portfolio06 = new Article()
            {
                Schema = Schema_Portfolio1,
                ArticleParent = Article_Portfolio,
                Title = "Dreams",
                XmlParams = "<root><item key=\"image\" value=\"/img/portfolio/dreams.png\" /></root>",
                SubTitle = "Website Design",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_About01 = new Article()
            {
                Schema = Schema_About1,
                ArticleParent = Article_About,
                Title = "Our Humble Beginnings",
                SubTitle = "2009-2011",
                XmlParams = "<root><item key=\"image\" value=\"/img/about/1.jpg\" /></root>",
                Resumen = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sunt ut voluptatum eius sapiente, totam reiciendis temporibus qui quibusdam, recusandae sit vero unde, sed, incidunt et ea quo dolore laudantium consectetur!",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_About02 = new Article()
            {
                Schema = Schema_About1,
                ArticleParent = Article_About,
                Title = "An Agency is Born",
                SubTitle = "March 2011",
                XmlParams = "<root><item key=\"image\" value=\"/img/about/2.jpg\" /><item key=\"align\" value=\"right\" /></root>",
                Resumen = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sunt ut voluptatum eius sapiente, totam reiciendis temporibus qui quibusdam, recusandae sit vero unde, sed, incidunt et ea quo dolore laudantium consectetur!",
                Author = adminuser,
                Position = 2,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_About03 = new Article()
            {
                Schema = Schema_About1,
                ArticleParent = Article_About,
                Title = "Transition to Full Service",
                SubTitle = "December 2012",
                XmlParams = "<root><item key=\"image\" value=\"/img/about/3.jpg\" /></root>",
                Resumen = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sunt ut voluptatum eius sapiente, totam reiciendis temporibus qui quibusdam, recusandae sit vero unde, sed, incidunt et ea quo dolore laudantium consectetur!",
                Author = adminuser,
                Position = 3,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_About04 = new Article()
            {
                Schema = Schema_About1,
                ArticleParent = Article_About,
                Title = "Phase Two Expansion",
                SubTitle = "July 2014",
                XmlParams = "<root><item key=\"image\" value=\"/img/about/4.jpg\" /><item key=\"align\" value=\"right\" /></root>",
                Resumen = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sunt ut voluptatum eius sapiente, totam reiciendis temporibus qui quibusdam, recusandae sit vero unde, sed, incidunt et ea quo dolore laudantium consectetur!",
                Author = adminuser,
                Position = 4,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Team01 = new Article()
            {
                Schema = Schema_Team1,
                ArticleParent = Article_Team,
                Title = "Nuestro Equipo",
                Resumen = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aut eaque, laboriosam veritatis, quos non quis ad perspiciatis, totam corporis ea, alias ut unde.",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Team02 = new Article()
            {
                Schema = Schema_Team2,
                ArticleParent = Article_Team,
                Title = "Nuestros Clientes",
                Author = adminuser,
                Position = 2,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Team0101 = new Article()
            {
                Schema = Schema_Team11,
                ArticleParent = Article_Team01,
                Title = "Kay Garland",
                SubTitle = "Lead Designer",
                XmlParams = "<root><item key=\"image\" value=\"/img/team/1.jpg\" /><item key=\"twitter\" value=\"#\" /><item key=\"facebook\" value=\"#\" /><item key=\"linkedin\" value=\"#\" /></root>",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Team0102 = new Article()
            {
                Schema = Schema_Team11,
                ArticleParent = Article_Team01,
                Title = "Larry Parker",
                SubTitle = "Lead Marketer",
                XmlParams = "<root><item key=\"image\" value=\"/img/team/2.jpg\" /><item key=\"twitter\" value=\"#\" /><item key=\"facebook\" value=\"#\" /><item key=\"linkedin\" value=\"#\" /></root>",
                Author = adminuser,
                Position = 2,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Team0103 = new Article()
            {
                Schema = Schema_Team11,
                ArticleParent = Article_Team01,
                Title = "Diana Pertersen",
                SubTitle = "Lead Developer",
                XmlParams = "<root><item key=\"image\" value=\"/img/team/3.jpg\" /><item key=\"twitter\" value=\"#\" /><item key=\"facebook\" value=\"#\" /><item key=\"linkedin\" value=\"#\" /></root>",
                Author = adminuser,
                Position = 3,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Team0201 = new Article()
            {
                Schema = Schema_Team21,
                ArticleParent = Article_Team02,
                Title = "evanto",
                XmlParams = "<root><item key=\"image\" value=\"/img/logos/envato.jpg\" /></root>",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Team0202 = new Article()
            {
                Schema = Schema_Team21,
                ArticleParent = Article_Team02,
                Title = "designmodo",
                XmlParams = "<root><item key=\"image\" value=\"/img/logos/designmodo.jpg\" /></root>",
                Author = adminuser,
                Position = 2,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Team0203 = new Article()
            {
                Schema = Schema_Team21,
                ArticleParent = Article_Team02,
                Title = "themeforest",
                XmlParams = "<root><item key=\"image\" value=\"/img/logos/themeforest.jpg\" /></root>",
                Author = adminuser,
                Position = 3,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Team0204 = new Article()
            {
                Schema = Schema_Team21,
                ArticleParent = Article_Team02,
                Title = "creative-market",
                XmlParams = "<root><item key=\"image\" value=\"/img/logos/creative-market.jpg\" /></root>",
                Author = adminuser,
                Position = 4,
                Active = true,
                RegisterDate = DateTime.Now
            };
            var Article_Contact01 = new Article()
            {
                Schema = Schema_Contact1,
                ArticleParent = Article_Contact,
                Title = "Formulario de Contacto",
                Author = adminuser,
                Position = 1,
                Active = true,
                RegisterDate = DateTime.Now
            };

            #endregion

            #region Post
            #endregion

            context.AdmProfileRepository.Add(sa);
            context.AdmProfileRepository.Add(Author);

            context.AdmUserRepository.Add(adminuser);
            context.AdmMenuRepository.Add(menu01);
            context.AdmMenuRepository.Add(menu02);
            context.AdmMenuRepository.Add(menu03);
            context.AdmMenuRepository.Add(menu04);
            context.AdmMenuRepository.Add(menu0401);
            context.AdmMenuRepository.Add(menu0402);
            context.AdmMenuRepository.Add(menu0403);
            context.AdmMenuRepository.Add(menu0404);
            context.AdmMenuRepository.Add(menu0405);

            context.TemplateRepository.Add(Template_SectionHome);
            context.TemplateRepository.Add(Template_SectionServices);
            context.TemplateRepository.Add(Template_SectionPortfolio);
            context.TemplateRepository.Add(Template_SectionAbout);
            context.TemplateRepository.Add(Template_SectionTeam);
            context.TemplateRepository.Add(Template_SectionContact);
            context.TemplateRepository.Add(Template_SectionBlog);
            context.TemplateRepository.Add(Template_Pagina);
            context.TemplateRepository.Add(Template_Parrafo);
            context.TemplateRepository.Add(Template_Contenedor);
            context.TemplateRepository.Add(Template_Enlace);
            context.TemplateRepository.Add(Template_Foto);
            context.TemplateRepository.Add(Template_Intro);
            context.TemplateRepository.Add(Template_Documento);
            context.TemplateRepository.Add(Template_Acceso);
            context.TemplateRepository.Add(Template_Noticia);
            context.TemplateRepository.Add(Template_Portafolio);
            context.TemplateRepository.Add(Template_Servicio);
            context.TemplateRepository.Add(Template_Equipo);
            context.TemplateRepository.Add(Template_Cliente);
            context.TemplateRepository.Add(Template_Widget);
            context.TemplateRepository.Add(Template_WidgetEnlace);
            context.TemplateRepository.Add(Template_AnimacionHome);
            context.TemplateRepository.Add(Template_BloqueAccesos);
            context.TemplateRepository.Add(Template_BloqueWidgets);
            context.TemplateRepository.Add(Template_BloqueNoticias);
            context.TemplateRepository.Add(Template_PaginaNoticias);
            context.TemplateRepository.Add(Template_FormularioContacto);
            context.TemplateRepository.Add(Template_PaginaError);
            context.TemplateRepository.Add(Template_Error);

            context.SchemaRepository.Add(Schema_Home);
            context.SchemaRepository.Add(Schema_Services);
            context.SchemaRepository.Add(Schema_Portfolio);
            context.SchemaRepository.Add(Schema_About);
            context.SchemaRepository.Add(Schema_Team);
            context.SchemaRepository.Add(Schema_Contact);
            context.SchemaRepository.Add(Schema_Blog);
            context.SchemaRepository.Add(Schema_Home1);
            context.SchemaRepository.Add(Schema_Home11);
            context.SchemaRepository.Add(Schema_Services1);
            context.SchemaRepository.Add(Schema_Portfolio1);
            context.SchemaRepository.Add(Schema_About1);
            context.SchemaRepository.Add(Schema_Team1);
            context.SchemaRepository.Add(Schema_Team2);
            context.SchemaRepository.Add(Schema_Contact1);

            context.ArticleRepository.Add(Article_Home);
            context.ArticleRepository.Add(Article_Services);
            context.ArticleRepository.Add(Article_Portfolio);
            context.ArticleRepository.Add(Article_About);
            context.ArticleRepository.Add(Article_Team);
            context.ArticleRepository.Add(Article_Contact);
            context.ArticleRepository.Add(Article_Home01);
            context.ArticleRepository.Add(Article_Home0101);
            context.ArticleRepository.Add(Article_Services01);
            context.ArticleRepository.Add(Article_Services02);
            context.ArticleRepository.Add(Article_Services03);
            context.ArticleRepository.Add(Article_Portfolio01);
            context.ArticleRepository.Add(Article_Portfolio02);
            context.ArticleRepository.Add(Article_Portfolio03);
            context.ArticleRepository.Add(Article_Portfolio04);
            context.ArticleRepository.Add(Article_Portfolio05);
            context.ArticleRepository.Add(Article_Portfolio06);
            context.ArticleRepository.Add(Article_About01);
            context.ArticleRepository.Add(Article_About02);
            context.ArticleRepository.Add(Article_About03);
            context.ArticleRepository.Add(Article_About04);
            context.ArticleRepository.Add(Article_Team01);
            context.ArticleRepository.Add(Article_Team02);
            context.ArticleRepository.Add(Article_Team0101);
            context.ArticleRepository.Add(Article_Team0102);
            context.ArticleRepository.Add(Article_Team0103);
            context.ArticleRepository.Add(Article_Team0201);
            context.ArticleRepository.Add(Article_Team0202);
            context.ArticleRepository.Add(Article_Team0203);
            context.ArticleRepository.Add(Article_Team0204);
            context.ArticleRepository.Add(Article_Contact01);

            context.Commit();

        }
    }
}
