using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class VoteModel
    {
        [Key]
        public int VoteId { get; set; }

        public int Vote { get; set; }

        public int AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public virtual AnswerModel Answer { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

    }

}
