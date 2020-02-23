using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Business;
using Shared.DTOs;
using BookReadingEventManagement2.Models;
using BookReadingEventManagement2.Helper;
using BookReadingEventManagement2.AuthData;
using System.Diagnostics;

namespace BookReadingEventManagement2.Controllers
{
    public class EventController : Controller
    {
        private EventService EventService = new EventService();
        private EventMapping EventMapping = new EventMapping();

        // GET: Event
        public ActionResult Home()
        {
            var Events =  EventService.GetAllPublicEvents();
            var UpcomingEvents = Events.Where(@event => @event.StartDateAndTime >= DateTime.Now).ToList();
            var PastEvents = Events.Where(@event => @event.StartDateAndTime < DateTime.Now).ToList();
            EventListViewModel EventListViewModel = new EventListViewModel();
            EventListViewModel.PastEvents = EventMapping.EventDTOList2PartialEventList(PastEvents);
            EventListViewModel.UpcomingEvents = EventMapping.EventDTOList2PartialEventList(UpcomingEvents);

            return View("Index",EventListViewModel);
        }

        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDTO EventDTO = EventService.GetEventID((int)id);
            if (EventDTO == null)
            {
                return HttpNotFound();
            }
            UserViewModel User = (UserViewModel)Session["User"];
            EventDetailViewModel EventDetailViewModel = EventMapping.EventDTO2EventDetailViewModel(EventDTO);
            Session["EventID"] = EventDetailViewModel.EventID;
            if (User != null)
            {
                EventDetailViewModel.CurrentUser = User.FullName;
            }
            else
            {
                EventDetailViewModel.CurrentUser = null;
            }
            
            return View(EventDetailViewModel);
        }

        [HttpPost]
        public ActionResult CommentPost(EventDetailViewModel eventDetailViewModel)
        {
            CommentViewModel commentViewModel = eventDetailViewModel.Comment;
            UserViewModel User = (UserViewModel)Session["User"];
            commentViewModel.Date = DateTime.Now;
            commentViewModel.UserID = (int)User.UserID;
            commentViewModel.UserFullName = User.FullName;
            commentViewModel.EventID = (int)Session["EventID"];
            CommentDTO CommentDTO = EventMapping.CommentViewModel2CommentDTO(commentViewModel);
            EventService.AddComment(CommentDTO);
            Session["EventID"] = null;
            return RedirectToAction("Details", new { id = commentViewModel.EventID});
        }

        [Auth]
        // GET: Event/Create
        public ActionResult Created()
        {
            return View("create");
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,StartDate,StartTime,Location,Duration,Description,OtherDetails,Type,InviteString")] EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel User = (UserViewModel)Session["User"];
                eventViewModel.InviteString = eventViewModel.InviteString.Replace(" ", ""); //Removing White Spaces
                eventViewModel.Invites = eventViewModel.InviteString.Split(',');
                eventViewModel.InviteCount = eventViewModel.Invites.Count();
                eventViewModel.UserFullName = User.FullName;
                eventViewModel.UserID = (int)User.UserID;
                EventDTO EventDTO = EventMapping.EventViewModel2EventDTO(eventViewModel);
                EventService.Create(EventDTO);
                
                return RedirectToAction("Home");
            }

            return View(eventViewModel);
        }

        [Auth]
        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDTO EventDTO = EventService.GetEventID((int)id);
            if (EventDTO == null)
            {
                return HttpNotFound();
            }
            EventViewModel EventViewModel = EventMapping.EventDTO2EventViewModel(EventDTO);
            Session["EventID"] = EventViewModel.EventID;
            return View(EventViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Title,StartDate,StartTime,Location,Duration,Description,OtherDetails,Type,InviteString")] EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel User = (UserViewModel)Session["User"];
                eventViewModel.InviteString = eventViewModel.InviteString.Replace(" ", ""); //Removing White Spaces
                eventViewModel.Invites = eventViewModel.InviteString.Split(',');
                eventViewModel.InviteCount = eventViewModel.Invites.Count();
                eventViewModel.UserFullName = User.FullName;
                eventViewModel.UserID = (int) User.UserID;
                eventViewModel.EventID = (int)Session["EventID"];
                EventDTO EventDTO = EventMapping.EventViewModel2EventDTO(eventViewModel);
                EventService.Update(EventDTO);
                Session["EventID"] = null;
                return RedirectToAction("Home");
            }
            return View(eventViewModel);
        }

        [Auth]
        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDTO EventDTO = EventService.GetEventID((int)id);
            if (EventDTO == null)
            {
                return HttpNotFound();
            }
            EventViewModel EventViewModel = EventMapping.EventDTO2EventViewModel(EventDTO);
            return View(EventViewModel);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventDTO EventDTO = EventService.GetEventID(id);
            EventService.Delete(id);
            return RedirectToAction("Home");
        }

        [Auth]
        public ActionResult MyEvents()
        {
            UserViewModel User = (UserViewModel)Session["User"];
            var EventDTOs = EventService.GetUserEvents((int)User.UserID);
            var UpcomingEvents = EventDTOs.Where(@event => @event.StartDateAndTime >= DateTime.Now).ToList();
            var PastEvents = EventDTOs.Where(@event => @event.StartDateAndTime < DateTime.Now).ToList();
            EventListViewModel EventListViewModel = new EventListViewModel();
            EventListViewModel.PastEvents = EventMapping.EventDTOList2PartialEventList(PastEvents);
            EventListViewModel.UpcomingEvents = EventMapping.EventDTOList2PartialEventList(UpcomingEvents);

            return View(EventListViewModel);
        }

        [Auth]
        public ActionResult InvitedEvents()
        {
            UserViewModel User = (UserViewModel)Session["User"];
            var EventDTOs = EventService.GetInvitedEvents(User.Email);
            var UpcomingEvents = EventDTOs.Where(@event => @event.StartDateAndTime >= DateTime.Now).ToList();
            var PastEvents = EventDTOs.Where(@event => @event.StartDateAndTime < DateTime.Now).ToList();
            EventListViewModel EventListViewModel = new EventListViewModel();
            EventListViewModel.PastEvents = EventMapping.EventDTOList2PartialEventList(PastEvents);
            EventListViewModel.UpcomingEvents = EventMapping.EventDTOList2PartialEventList(UpcomingEvents);

            return View(EventListViewModel);
        }

        [Auth]
        public ActionResult AllEvents()
        {
            var EventDTOs = EventService.GetAllEvents();
            var UpcomingEvents = EventDTOs.Where(@event => @event.StartDateAndTime >= DateTime.Now).ToList();
            var PastEvents = EventDTOs.Where(@event => @event.StartDateAndTime < DateTime.Now).ToList();
            EventListViewModel EventListViewModel = new EventListViewModel();
            EventListViewModel.PastEvents = EventMapping.EventDTOList2PartialEventList(PastEvents);
            EventListViewModel.UpcomingEvents = EventMapping.EventDTOList2PartialEventList(UpcomingEvents);
            return View("Events",EventListViewModel);

        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
