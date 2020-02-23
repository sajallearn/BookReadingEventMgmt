using System;
using System.Collections.Generic;

using DAL.Operations;
using Shared.DTOs;
using DAL.Exceptions;
using Business.Exceptions;

namespace Business
{
    public class EventService
    {
        private EventOperations EventOperations = new EventOperations();
        private CommentOperations CommentOperations = new CommentOperations();
        public void Create(EventDTO eventDTO)
        {
            EventOperations.Create(eventDTO);
        }

        public IEnumerable<EventDTO> GetAllPublicEvents()
        {
            return EventOperations.GetAllPublicEvents();
        }

        public IEnumerable<EventDTO> GetUserEvents(int userID)
        {
            return EventOperations.GetUserEvents(userID);
        }

        public IEnumerable<EventDTO> GetInvitedEvents(string email)
        {
            return EventOperations.GetInvitedEvents(email);
        }

        public EventDTO GetEventID(int ID)
        {
            try
            {
                return EventOperations.GetEventByID(ID);
            }
            catch (NoSuchEventException ex)
            {
                throw new InvalidEventException("No such event exists");
            }
            
        }

        public IEnumerable<EventDTO> GetAllEvents()
        {
            return EventOperations.GetAllEvents();
        }

        //public EventDTO Edit(EventDTO eventDTO)
        //{
        //    EventDTO EventDTO = eventDTO;   
        //}
        public void AddComment(CommentDTO commentDTO)
        {
            CommentOperations.AddComment(commentDTO);
        }

        public void Delete(int id)
        {
            EventOperations.Delete(id);
        }

        public void Update(EventDTO eventDTO)
        {
            EventOperations.Update(eventDTO);
        }

    }
}
