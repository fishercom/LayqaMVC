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
    public class ServiceTemplate
    {
        private ILayqaRepository context;

        public ServiceTemplate()
        {
            context = new EFLayqaRepository();
        }

        public IEnumerable<Dto.TemplateDto> GetList()
        {
            return context.TemplateRepository.GetAll()
                .ProjectTo<Dto.TemplateDto>();
        }

        public IEnumerable<Dto.TemplateDto> GetList(Nullable<int> SchemaParentId)
        {
            return context.TemplateRepository.GetAll().Where(e => e.IsSection == (SchemaParentId==null))
                .ProjectTo<Dto.TemplateDto>();
        }

        public Dto.TemplateDto GetItem_Schema(int SchemaId)
        {
            var schema=context.SchemaRepository.Find(s=>s.Id==SchemaId).ProjectTo<SchemaDto>().Single();

            return context
                .TemplateRepository.Find(e => e.Id == schema.TemplateId)
                .ProjectTo<TemplateDto>().FirstOrDefault();
        }

        public Dto.TemplateDto GetItem(int Id)
        {
            return context.TemplateRepository
                .Find(s => s.Id == Id)
                .ProjectTo<TemplateDto>().Single();
        }

        public void Add(TemplateDto request)
        {
            context.TemplateRepository.Add(Mapper.Map<TemplateDto, Template>(request));
            context.Commit();
        }

        public void Edit(TemplateDto request)
        {
            context.TemplateRepository.Update(Mapper.Map<TemplateDto, Template>(request));
            context.Commit();
        }

        public void Delete(int Id)
        {
            var post = context
                .TemplateRepository
                .Find(e => e.Id == Id).FirstOrDefault();

            context.TemplateRepository.Delete(post);
            context.Commit();
        }

    }


}
