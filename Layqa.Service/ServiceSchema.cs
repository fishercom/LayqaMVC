using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Layqa.Repository;
using Layqa.Entity;
using Layqa.Service.Dto;

namespace Layqa.Service
{
    public class ServiceSchema
    {
        private ILayqaRepository context;

        public ServiceSchema()
        {
            context = new EFLayqaRepository();
        }

        public IEnumerable<Dto.SchemaDto> GetList(Nullable<int> SchemaParentId)
        {
            return context.SchemaRepository
                .Find(e => e.SchemaParentId==SchemaParentId)
                .ProjectTo<Dto.SchemaDto>();
        }

        public IEnumerable<Dto.SchemaTemplateDto> GetList_Template(Nullable<int> SchemaParentId)
        {
            var schema = context.SchemaRepository.GetAll().Where(x => x.SchemaParentId == SchemaParentId);
            var schmtpl = schema.Join(context.TemplateRepository.GetAll(),
                s => s.TemplateId, t => t.Id,
                    (s, t) => new SchemaTemplateDto()
                    {
                        SchemaId = s.Id,
                        TemplateId = s.TemplateId,
                        SchemaAlias = s.Alias,
                        Iterations = s.Iterations,
                        IsPage = s.IsPage,
                        Active = s.Active,
                        TemplateName = t.Name,
                        AdminView = t.AdminView,
                        FrontView = t.FrontView
                    })
                    .ProjectTo<SchemaTemplateDto>();

            return schmtpl;
        }

        public Dto.SchemaDto GetItem(int Id)
        {
            return context
                .SchemaRepository.Find(e => e.Id == Id)
                .ProjectTo<SchemaDto>().FirstOrDefault();
        }

        public void Add(SchemaDto request)
        {
            context.SchemaRepository.Add(Mapper.Map<SchemaDto, Schema>(request));
            context.Commit();
        }

        public void Edit(SchemaDto request)
        {
            context.SchemaRepository.Update(Mapper.Map<SchemaDto, Schema>(request));
            context.Commit();
        }

        public void Delete(int Id)
        {
            var post = context
                .SchemaRepository
                .Find(e => e.Id == Id).FirstOrDefault();

            context.SchemaRepository.Delete(post);
            context.Commit();
        }

    }


}
