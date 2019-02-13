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
    public class ServicePost
    {
        private ILayqaRepository context;

        public ServicePost()
        {
            context = new EFLayqaRepository();
        }

        public IEnumerable<Dto.PostDto> GetList()
        {
            return context.PostRepository.GetAll().ProjectTo<Dto.PostDto>();
        }

        public IEnumerable<Dto.PostDto> GetWebList()
        {
            return context.PostRepository.GetAll().Where(e=>e.Active).ProjectTo<Dto.PostDto>();
        }

        public Dto.PostDto GetItem(int Id)
        {
            //return eventos.FirstOrDefault(e => e.EventoId == id);
            var post = context
                .PostRepository.Find(e => e.Id == Id)
                .ProjectTo<PostDto>().FirstOrDefault();

            return post;
        }

        public void Add(PostDto request)
        {
            context.PostRepository.Add(Mapper.Map<PostDto, Post>(request));
            context.Commit();
        }

        public void Edit(PostDto request)
        {
            context.PostRepository.Update(Mapper.Map<PostDto, Post>(request));
            context.Commit();
        }

        public void Delete(int Id)
        {
            var post = context
                .PostRepository
                .Find(e => e.Id == Id).FirstOrDefault();

            context.PostRepository.Delete(post);
            context.Commit();
        }

    }


}
