using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Layqa.Service.Dto;
using Layqa.Web.Models;
using Layqa.Web.Areas.Admin.Models;
using AutoMapper;

namespace Layqa.Web.Map
{
    public class MapConfig
    {
        public static void Config()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<TemplateDto, TemplateListViewModel>();

                config.CreateMap<TemplateDto, TemplateFormViewModel>();

                config.CreateMap<SchemaDto, SchemaListViewModel>()
                    .ForMember(dest => dest.TemplateName, exp => exp.MapFrom(orig => orig.Alias != "" ? orig.Alias : orig.Template.Name));

                config.CreateMap<SchemaDto, SchemaFormViewModel>();

                config.CreateMap<ArticleDto, ArticleListViewModel>()
                    .ForMember(dest => dest.Status, exp => exp.MapFrom(orig => orig.Active ? "Activo" : "Inactivo"));

                config.CreateMap<ArticleDto, ArticleFormViewModel>();

                config.CreateMap<PostDto, PostListViewModel>()
                    .ForMember(dest => dest.Status, exp => exp.MapFrom(orig => orig.Active ? "Activo" : "Inactivo"));

                config.CreateMap<PostDto, PostFormViewModel>();

                config.CreateMap<AdmUserDto, AdmUserListViewModel>()
                    .ForMember(dest => dest.FullName, exp => exp.MapFrom(orig => orig.Name + " " + orig.LastName));

                config.CreateMap<AdmUserDto, AdmUserFormViewModel>();

                config.CreateMap<WebUserDto, WebUserListViewModel>()
                    .ForMember(dest => dest.FullName, exp => exp.MapFrom(orig => orig.Name + " " + orig.LastName));

                config.CreateMap<WebUserDto, WebUserFormViewModel>();

                config.CreateMap<AdmProfileDto, AdmProfileListViewModel>();
                config.CreateMap<AdmProfileDto, AdmProfileFormViewModel>();

            });
        }
    }
}