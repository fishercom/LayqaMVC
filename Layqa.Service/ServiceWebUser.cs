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
    public class ServiceUser
    {
        private ILayqaRepository context;

        public ServiceUser()
        {
            context = new EFLayqaRepository();
        }

        public IEnumerable<Dto.WebUserDto> GetList()
        {
            return context.WebUserRepository.GetAll().ProjectTo<Dto.WebUserDto>();
        }

        public Dto.WebUserDto GetItem(int Id)
        {
            var user = context
                .WebUserRepository.Find(e => e.Id == Id)
                .ProjectTo<WebUserDto>().Single();

            return user;
        }

        public void Add(WebUserDto request)
        {
            context.WebUserRepository.Add(Mapper.Map<WebUserDto, WebUser>(request));
            context.Commit();
        }

        public void Edit(WebUserDto request)
        {
            context.
                WebUserRepository.Update(Mapper.Map<WebUserDto, WebUser>(request));
            context.Commit();
        }

        public void Delete(int Id)
        {
            var User = context
                .WebUserRepository
                .Find(e => e.Id == Id).FirstOrDefault();

            context.WebUserRepository.Delete(User);
            context.Commit();
        }
    }


}
