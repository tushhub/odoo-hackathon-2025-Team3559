using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StackIt.Models
{
    public class StackItContext : IdentityDbContext<ApplicationUser>
    {
        public StackItContext() : base("DefaultConnection") { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public static StackItContext Create()
        {
            return new StackItContext();
        }
    }

}