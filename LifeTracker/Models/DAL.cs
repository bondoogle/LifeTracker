using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifeTracker.Models;

namespace LifeTracker.DAL
{
    public class UserRepository : IDisposable
    {

        private DB.Context _context;

        public UserRepository(DB.Context context)
        {
            _context = context;
        }

        public DB.User GetUser(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault<DB.User>();
        }

        public void AddUser(DB.User user)
        {
            _context.Users.Add(user);
        }

        public List<DB.Chore> GetUserChores(DB.User user)
        {
            return user.Chores.ToList();
        }

        public DB.Chore GetUserChore(DB.User user, int choreid)
        {
            return user.Chores.FirstOrDefault(c => c.ChoreId == choreid);
        }
        
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}