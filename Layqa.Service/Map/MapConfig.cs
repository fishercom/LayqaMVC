using AutoMapper;
using Layqa.Entity;
using Layqa.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layqa.Service.Map
{
    public class MapConfig
    {
        public static void Config()
        {
            Mapper.Initialize(conf =>
            {
                conf.CreateMap<AdmMenu, AdmMenuDto>()
                    .ForMember(dest => dest.MenuId,
                    map => map.MapFrom(orig => orig.Id))
                    .ForMember(dest => dest.Controller, map =>
                    map.MapFrom(orig => string.IsNullOrEmpty(orig.Controller) ? string.Empty : orig.Controller));

                conf.CreateMap<AdmProfile, AdmProfileDto>()
                    .ForMember(dest => dest.AdmProfileId,
                    map => map.MapFrom(orig => orig.Id));

                conf.CreateMap<AdmProfileDto, AdmProfile>()
                .ForMember(dest => dest.Id,
                map => map.MapFrom(orig => orig.AdmProfileId));

                conf.CreateMap<AdmUser, AdmUserDto>()
                .ForMember(dest => dest.UserId,
                map => map.MapFrom(orig => orig.Id));

                conf.CreateMap<AdmUserDto, AdmUser>()
                .ForMember(dest => dest.Id,
                map => map.MapFrom(orig => orig.UserId));

                conf.CreateMap<WebUser, WebUserDto>()
                .ForMember(dest => dest.UserId,
                map => map.MapFrom(orig => orig.Id));

                conf.CreateMap<WebUserDto, WebUser>()
                .ForMember(dest => dest.Id,
                map => map.MapFrom(orig => orig.UserId));

                conf.CreateMap<Template, TemplateDto>()
                .ForMember(dest => dest.TemplateId,
                map => map.MapFrom(orig => orig.Id));

                conf.CreateMap<TemplateDto, Template>()
                .ForMember(dest => dest.Id,
                map => map.MapFrom(orig => orig.TemplateId));

                conf.CreateMap<SchemaTemplateDto, SchemaTemplateDto>();

                conf.CreateMap<Schema, SchemaDto>()
                .ForMember(dest => dest.SchemaId,
                map => map.MapFrom(orig => orig.Id))
                .ForMember(dest => dest.Alias, map =>
                map.MapFrom(orig => string.IsNullOrEmpty(orig.Alias) ? string.Empty : orig.Alias));

                conf.CreateMap<SchemaDto, Schema>()
                .ForMember(dest => dest.Id,
                map => map.MapFrom(orig => orig.SchemaId));

                conf.CreateMap<Article, ArticleDto>()
                .ForMember(dest => dest.ArticleId, map => map.MapFrom(orig => orig.Id));

                conf.CreateMap<ArticleDto, Article>()
                .ForMember(dest => dest.Id, map => map.MapFrom(orig => orig.ArticleId));

                conf.CreateMap<Post, PostDto>()
                .ForMember(dest => dest.PostId,
                map => map.MapFrom(orig => orig.Id));

                conf.CreateMap<PostDto, Post>()
                .ForMember(dest => dest.Id,
                map => map.MapFrom(orig => orig.PostId));

                conf.CreateMap<Comment, CommentDto>();
            });
        }

    }
}
