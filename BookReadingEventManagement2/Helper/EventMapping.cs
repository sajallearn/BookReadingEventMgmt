using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReadingEventManagement2.Models;
using Shared.DTOs;
using AutoMapper;

namespace BookReadingEventManagement2.Helper
{
    public class EventMapping
    {
        public EventDTO EventViewModel2EventDTO(EventViewModel eventViewModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventViewModel, EventDTO>());
            var mapper = config.CreateMapper();

            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<EventViewModel, EventDTO>());
            var mapper2 = config.CreateMapper();

            EventDTO EventDTO =  mapper.Map<EventDTO>(eventViewModel);
            DateTime StartDate = eventViewModel.StartDate;
            DateTime StartTime = eventViewModel.StartTime;
            DateTime StartDateAndTime = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartTime.Hour, StartTime.Minute, StartTime.Second);
            EventDTO.StartDateAndTime = StartDateAndTime;
            EventDTO.isPublic = eventViewModel.Type == "Public" ? true : false;
            //List<CommentDTO> Comments = new List<CommentDTO>();
            //foreach (CommentViewModel commentViewModel in eventViewModel.CommentList)
            //{
            //    CommentDTO CommentDTO = mapper2.Map<CommentDTO>(commentViewModel);
            //    Comments.Add(CommentDTO);
            //}
            //EventDTO.Comments = Comments;
            return EventDTO;
        }

        public EventViewModel EventDTO2EventViewModel(EventDTO eventDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, EventViewModel>());
            var mapper = config.CreateMapper();

            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
            var mapper2 = config2.CreateMapper();
            EventViewModel EventViewModel = mapper.Map<EventViewModel>(eventDTO);
            EventViewModel.StartDate = new DateTime(eventDTO.StartDateAndTime.Year, eventDTO.StartDateAndTime.Month, eventDTO.StartDateAndTime.Day);
            TimeSpan timeSpan = eventDTO.StartDateAndTime.TimeOfDay;
            EventViewModel.StartTime += timeSpan;
            EventViewModel.Type = eventDTO.isPublic ? "Public" : "Private";
            
            return EventViewModel;
        }

        public EventDetailViewModel EventDTO2EventDetailViewModel(EventDTO eventDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, EventDetailViewModel>());
            var mapper = config.CreateMapper();

            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
            var mapper2 = config2.CreateMapper();
            EventDetailViewModel EventDetailViewModel = mapper.Map<EventDetailViewModel>(eventDTO);
            EventDetailViewModel.StartDate = new DateTime(eventDTO.StartDateAndTime.Year, eventDTO.StartDateAndTime.Month, eventDTO.StartDateAndTime.Day);
            TimeSpan timeSpan = eventDTO.StartDateAndTime.TimeOfDay;
            EventDetailViewModel.StartTime += timeSpan;
            EventDetailViewModel.Type = eventDTO.isPublic ? "Public" : "Private";
            List<CommentViewModel> CommentList = new List<CommentViewModel>();
            foreach (CommentDTO commentDTO in eventDTO.Comments)
            {
                CommentViewModel commentViewModel = mapper2.Map<CommentViewModel>(commentDTO);
                CommentList.Add(commentViewModel);
            }
            EventDetailViewModel.CommentList = CommentList;
            return EventDetailViewModel;
        }

        public CommentDTO CommentViewModel2CommentDTO(CommentViewModel commentViewModel)
        {
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
            var mapper2 = config2.CreateMapper();
            CommentDTO CommentDTO = mapper2.Map<CommentDTO>(commentViewModel);
            return CommentDTO;
        }

        public PartialEventViewModel EventDTO2PartialEventViewModel(EventDTO eventDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, PartialEventViewModel>());
            var mapper = config.CreateMapper();

            PartialEventViewModel PartialEventViewModel = mapper.Map<PartialEventViewModel>(eventDTO);
            PartialEventViewModel.StartDate = new DateTime(eventDTO.StartDateAndTime.Year, eventDTO.StartDateAndTime.Month, eventDTO.StartDateAndTime.Day);
            TimeSpan timeSpan = eventDTO.StartDateAndTime.TimeOfDay;
            PartialEventViewModel.StartTime += timeSpan;


            return PartialEventViewModel;
        }

        public List<PartialEventViewModel> EventDTOList2PartialEventList(List<EventDTO> eventDTOs)
        {
            List<PartialEventViewModel> PartialEventViewModels = new List<PartialEventViewModel>();
            foreach(EventDTO eventDTO in eventDTOs)
            {
                PartialEventViewModel partialEventViewModel = this.EventDTO2PartialEventViewModel(eventDTO);
                PartialEventViewModels.Add(partialEventViewModel);
            }
            return PartialEventViewModels;
        }

        
    }
}