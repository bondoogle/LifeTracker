using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LifeTracker.Models
{
    public class DB
    {
        public class Context : DbContext
        {
            public DbSet<User> Users { get; set; }

            public Context() : base("DefaultConnection") { }
        }
        
        public class User
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime DateCreated { get; set; }
            public string UserName { get; set; }
            public virtual List<UserSettings> UserSettings { get; set; }
            public virtual List<Chore> Chores { get; set; }
        }

        public enum UserSettingType
        {
            AccountOption, ContactOptions, ChoreOptions
        }
        public class UserSettings
        {
            public int UserSettingsId { get; set; }
            public UserSettingType UserSettingType { get; set; }
            public string UserSettingName { get; set; }
            public string UserSettingValue { get; set; }
        }

        public enum ChoreType
        {
            Daily, Weekly, Monthly, BiYearly, Yearly, OneTime
        }

        public class Chore
        {
            public int ChoreId { get; set; }
            public string ChoreName { get; set; }
            public string ChoreDescription { get; set; }
            public ChoreType ChoreType { get; set; }
            public DateTime DateCreated { get; set; }

            public Chore()
            {
                DateCreated = DateTime.Now;
            }
        }
    }
}