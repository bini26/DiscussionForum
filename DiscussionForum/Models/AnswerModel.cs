using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class AnswerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AnswerDate { get; set; } = DateTime.Now;

        public int QId { get; set; }
        public virtual QuestionModel Question { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

        [Required(ErrorMessage = "Answer is required")]
        public string Answer { get; set; }

        [NotMapped]
        public int upvoteCount { get; set; }
        [NotMapped]
        public int downvoteCount { get; set; }


    }

    public class AnswerModelNew
    {

        public int QId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

    }

}
