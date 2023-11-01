using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class QuestionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Body is required")]
        public string Question { get; set; }
        public string Identity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AskedDate { get; set; } = DateTime.Now;


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

        [InverseProperty("Question")]
        public virtual ICollection<AnswerModel> Answers { get; set; }
    }
    public class QuestionWithUserModel
    {
        public int QId { get; set; }
        public DateTime AskedDate { get; set; }
        public string Question { get; set; }
        public string Title { get; set; }
        public string Identity { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } // User's first name
        public string LastName { get; set; } // User's last name
        public UserModel User { get; set; } // Add this property
    }
    //public class EditQuestion
    //{

    //    public string Question { get; set; }
    //    public string Title { get; set; }
    //    public string Identity { get; set; }
    //}
}