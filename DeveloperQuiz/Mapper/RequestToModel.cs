using System;
using AutoMapper;
using DeveloperQuiz.Domains.Models;
using DeveloperQuiz.Domains.Request;

namespace DeveloperQuiz.Mapper
{
    public class RequestToModel : Profile
    {
        public RequestToModel()
        {
            CreateMap<BookRequest, Book>(); // means you want to map from User to UserDTO
        }
    }
}
