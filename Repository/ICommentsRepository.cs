using System;
using System.Collections.Generic;
using VulnerableCoreApp.Models;
using VulnerableCoreApp.ViewModels;

namespace VulnerableCoreApp.Repository
{
    public interface ICommentsRepository
    {
        CommentsViewModel GetAll();
        Comment Save(Comment comment);
        void Delete(String ID);
    }
}
