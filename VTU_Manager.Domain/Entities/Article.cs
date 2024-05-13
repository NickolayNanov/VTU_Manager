using System.ComponentModel.DataAnnotations;

namespace VTU_Manager.Domain.Entities
{
    public class Article : EntityBase<int>
    {
        [Required]
        [MaxLength(300)]
        public string PublishName { get; set; }
        [Required]
        [MaxLength(100)]
        public string AuthorName { get; set; }
        public bool IsPlagiat { get; set; }
        public int ProtoclId { get; set; }
        public Protocol Protocol { get; set; }
    }
}