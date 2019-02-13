using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Layqa.Repository;
using Layqa.Entity;
using Layqa.Service.Dto;

namespace Layqa.Service
{
    public class ServiceAdmMenu
    {
        private ILayqaRepository context;

        public ServiceAdmMenu()
        {
            context = new EFLayqaRepository();
        }

        public IEnumerable<Dto.AdmMenuDto> GetList()
        {
            return context.AdmMenuRepository.GetAll().OrderBy(field => field.Position).ProjectTo<Dto.AdmMenuDto>();
        }

        public Dto.AdmMenuDto GetItem(int Id)
        {
            var user = context
                .AdmMenuRepository.Find(e => e.Id == Id)
                .ProjectTo<AdmMenuDto>().Single();

            return user;
        }

        /*
        public void Add(AdmMenuDto request)
        {
            var user = context
                .AdmMenuRepository
                .SingleOrDefault(x => x.Id == request.MenuId);

            context.AdmMenuRepository.Update(user);
            context.Commit();
        }

        public void Edit(AdmMenuDto request)
        {
            context.AdmMenuRepository.Update(Mapper.Map<AdmMenuDto, AdmMenu>(request));
            context.Commit();
        }

        public void Delete(int Id)
        {
            var AdmProfile = context
                .AdmMenuRepository
                .Find(e => e.Id == Id).FirstOrDefault();

            context.AdmMenuRepository.Delete(AdmProfile);
            context.Commit();
        }
        */ 
    }

}
