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
    public class ServiceAdmProfile
    {
        private ILayqaRepository context;

        public ServiceAdmProfile()
        {
            context = new EFLayqaRepository();
        }

        public IEnumerable<Dto.AdmProfileDto> GetList()
        {
            return context.AdmProfileRepository.GetAll().ProjectTo<Dto.AdmProfileDto>();
        }

        public Dto.AdmProfileDto GetItem(int Id)
        {
            var user = context
                .AdmProfileRepository.Find(e => e.Id == Id)
                .ProjectTo<AdmProfileDto>().Single();

            return user;
        }

        public void Add(AdmProfileDto request)
        {
            var user = context
                .AdmProfileRepository
                .SingleOrDefault(x => x.Id == request.AdmProfileId);

            context.AdmProfileRepository.Update(user);
            context.Commit();
        }

        public void Edit(AdmProfileDto request)
        {
            context.AdmProfileRepository.Update(Mapper.Map<AdmProfileDto, AdmProfile>(request));
            context.Commit();
        }

        public void Delete(int Id)
        {
            var AdmProfile = context
                .AdmProfileRepository
                .Find(e => e.Id == Id).FirstOrDefault();

            context.AdmProfileRepository.Delete(AdmProfile);
            context.Commit();
        }
    }


}
