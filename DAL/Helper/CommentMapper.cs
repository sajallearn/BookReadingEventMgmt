using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entity;
using Shared.DTOs;

namespace DAL.Helper
{
    public class CommentMapper
    {
        public Comment CommentDTO2Comment(CommentDTO commentDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>());
            var mapper = config.CreateMapper();

            Comment Comment = mapper.Map<Comment>(commentDTO);
            return Comment;
        }

        public CommentDTO Comment2CommentDTO(Comment comment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>());
            var mapper = config.CreateMapper();

            CommentDTO CommentDTO = mapper.Map<CommentDTO>(comment);
            return CommentDTO;
        }
    }
}
