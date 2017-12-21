using System;
using System.Collections.Generic;
using System.Linq;
using VulnerableCoreApp.Models;
using VulnerableCoreApp.ViewModels;

namespace VulnerableCoreApp.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        private List<Comment> Comments;

        public CommentsRepository()
        {
            Comments = new List<Comment>();
        }

        public CommentsViewModel GetAll()
        {
            CommentsViewModel comments = new CommentsViewModel();
            comments.Comments = new  List<CommentViewModel>();
            foreach (Comment comment in Comments)
            {
                CommentViewModel commentViewModel = new CommentViewModel();
                commentViewModel.ID = comment.ID;
                commentViewModel.Username = comment.Username;
                commentViewModel.CreatedAt = comment.CreatedAt;
                commentViewModel.Text = comment.Text;
                comments.Comments.Add(commentViewModel);
            }

            return comments;
        }

        public Comment Save(Comment comment)
        {
            Comments.Add(comment);
            
            return comment;
        }

        public void Delete(String ID)
        {
            Comments.Remove(Comments.Where(comment => comment.ID == ID).First());
        }
    }
}