using System.ComponentModel.DataAnnotations;

namespace HappyBdayMyFriend.Model
{
    public class Card : IEntity
    {
        public int Id { get; set; }
        [Required]
        public int Cover { get; set; }
        [Required]
        [MaxLength(255)]
        public string Message { get; set; }
        [Required]
        [MaxLength(100)]
        public string Signature { get; set; }
    }
}
