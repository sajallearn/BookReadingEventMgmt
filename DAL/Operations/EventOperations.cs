using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using DAL.Helper;
using DAL.Exceptions;
using Shared.DTOs;

namespace DAL.Operations
{
    public class EventOperations
    {
        private BookReadingEventManagementContext db = new BookReadingEventManagementContext();
        private EventMapper EventMapper = new EventMapper();
        private InviteOperations InviteOperations = new InviteOperations();
        private CommentOperations CommentOperations = new CommentOperations();
        public int Create(EventDTO eventDTO)
        {
            Event Event = EventMapper.EventDTO2Event(eventDTO);
            string[] InviteList = eventDTO.Invites;

            db.Events.Add(Event);
            db.SaveChanges();
            int EventID = Event.EventID;
            InviteOperations.AddInvites(InviteList, EventID);

            db.SaveChanges();
            return EventID;
        }

        public EventDTO GetEventByID(int ID)
        {
            Event Event;
            try
            {
                Event = db.Events.Where(@event => @event.EventID == ID).SingleOrDefault();
            }
            catch(Exception ex)
            {
                throw new NoSuchEventException("", ex);
            }
           
            EventDTO EventDTO = EventMapper.Event2EventDTO(Event);
            EventDTO.Invites = InviteOperations.GetInvitesForEvent(Event.EventID);
            EventDTO.Comments = CommentOperations.GetCommentsForEvent(ID);
            db.SaveChanges();
            return EventDTO;
        }

        public IEnumerable<EventDTO> GetAllPublicEvents()
        {
            var EventList = db.Events.Where(@event => @event.isPublic).OrderBy(@event => @event.StartDateAndTime).ToList();
            List<EventDTO> EventDTOs = EventMapper.EventList2EventDTOList(EventList);
            return EventDTOs;
        }

        public IEnumerable<EventDTO> GetAllEvents()
        {
            var EventList = db.Events.Where(@event => true).OrderBy(@event => @event.StartDateAndTime).ToList();
            List<EventDTO> EventDTOs = EventMapper.EventList2EventDTOList(EventList);
            return EventDTOs;
        }

        public void Delete(int id)
        {
            Event Event = db.Events.Find(id);
            db.Events.Remove(Event);
            InviteOperations.RemoveInvitesForEvent(id);
            CommentOperations.DeleteCommentsForEvent(id);
            db.SaveChanges();
        }

        public IEnumerable<EventDTO> GetUserEvents(int userID)
        {
            var EventList = db.Events.Where(@event => @event.UserID == userID).ToList();
            List<EventDTO> UserEventDTOs = EventMapper.EventList2EventDTOList(EventList);
            return UserEventDTOs;
        }

        public IEnumerable<EventDTO> GetInvitedEvents(string email)
        {
            //Optimize into single query
            var EventIds = InviteOperations.GetEventIds(email);
            List<EventDTO> EventDTOs = new List<EventDTO>();
            foreach(int eventId in EventIds)
            {
                EventDTOs.Add(this.GetEventByID(eventId));
            }
            return EventDTOs;
        }

        public void Update(EventDTO eventDTO)
        {
            Event Event = db.Events.First(@event => @event.EventID == eventDTO.EventID);
            Event.Title = eventDTO.Title;
            Event.StartDateAndTime = eventDTO.StartDateAndTime;
            Event.Location = eventDTO.Location;
            Event.Duration = eventDTO.Duration;
            Event.Description = eventDTO.Description;
            Event.OtherDetails = eventDTO.OtherDetails;
            Event.InviteCount = eventDTO.InviteCount;
            Event.isPublic = eventDTO.isPublic;
            db.SaveChanges();
            InviteOperations.RemoveInvitesForEvent(Event.EventID);
            InviteOperations.AddInvites(eventDTO.Invites, Event.EventID);
            db.SaveChanges();
        }

    }
}
