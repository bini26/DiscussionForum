using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class QCommentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QCommentId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }
        public int QId { get; set; }
        [ForeignKey("QId")]
        public virtual QuestionModel Question { get; set; }

        [Required(ErrorMessage = "Comment is required")]
 public String Comment { get; set; }

    }
    //public class QuestionCommentModel
    //{
    //    public List<QCommentModel> QuestionComments { get; set; }
    //    public int QId { get; set; }
    //}
}