using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Shared.DTOs;
using DAL.Entity;

namespace DAL.Helper
{
    public class EventMapper
    {
        public Event EventDTO2Event(EventDTO eventDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>());
            var mapper = config.CreateMapper();
  
            var Event = mapper.Map<Event>(eventDTO);
            return Event;
        }

        public EventDTO Event2EventDTO(Event @event)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventDTO>());
            var mapper = config.CreateMapper();

            var EventDTO = mapper.Map<EventDTO>(@event);
            return EventDTO;
        }

        public List<EventDTO> EventList2EventDTOList(List<Event> events)
        {
            List<EventDTO> EventDTOs = new List<EventDTO>();
            foreach(Event @event in events)
            {
                EventDTO eventDTO =  this.Event2EventDTO(@event);
                EventDTOs.Add(eventDTO);
            }
            return EventDTOs;
        }
    }
}
