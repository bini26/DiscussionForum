using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class ACommentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ACommentId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }
        public int AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public virtual AnswerModel Answer { get; set; }


        [Required(ErrorMessage = "Comment is required")]

        public String Comment { get; set; }
    }
}