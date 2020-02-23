using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;
using DAL.Entity;
using DAL.Helper;

namespace DAL.Operations
{
    public class CommentOperations
    {
        private BookReadingEventManagementContext db = new BookReadingEventManagementContext();
        private CommentMapper CommentMapper = new CommentMapper();
        public void AddComment(CommentDTO commentDTO)
        {
            Comment Comment = CommentMapper.CommentDTO2Comment(commentDTO);
            db.Comments.Add(Comment);
            db.SaveChanges();
        }

        public List<CommentDTO> GetCommentsForEvent(int EventID)
        {
            var CommentList = db.Comments
                                        .Where(comment => comment.EventID == EventID)
                                        .OrderBy(comment => comment.Date)
                                        .ToList();
            List<CommentDTO> CommentDTOs = new List<CommentDTO>();
            foreach(Comment comment in CommentList)
            {
                CommentDTO CommentDTO = CommentMapper.Comment2CommentDTO(comment);
                CommentDTOs.Add(CommentDTO);
            }
            return CommentDTOs;
        }

        public void DeleteCommentsForEvent(int eventID)
        {
            if(db.Comments.Any(comment => comment.EventID == eventID))
            {
                return;
            }
            var CommentList = db.Comments.Where(comment => comment.EventID == eventID).ToList();
            foreach(Comment comment in CommentList)
            {
                db.Comments.Remove(comment);
            }
            db.SaveChanges();
        }
    }
}
