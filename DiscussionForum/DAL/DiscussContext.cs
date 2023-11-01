using DiscussionForum.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DiscussionForum.DAL
{
    public class DiscussContext : DbContext
    {

        public DiscussContext() : base("DiscussContext")
        {
            this.Configuration.UseDatabaseNullSemantics = true;

        }

        public DbSet<QuestionModel> Question { get; set; }
        //public DbSet<LoginModel> Login { get; set; }
        public DbSet<UserModel> User_Details { get; set; }
        public DbSet<AdminModel> Admin { get; set; }
        public DbSet<AnswerModel> Answer { get; set; }
        public DbSet<ACommentModel> Answer_Comment { get; set; }
        public DbSet<QCommentModel> Question_Comment { get; set; }
        public DbSet<VoteModel> Vote { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<VoteModel>()
        .HasRequired(v => v.Answer)
        .WithMany()
        .HasForeignKey(v => v.AnswerId)
        .WillCascadeOnDelete(false); // Adjust cascade delete behavior if needed

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
