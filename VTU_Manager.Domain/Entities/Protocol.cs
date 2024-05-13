using System.ComponentModel.DataAnnotations;

namespace VTU_Manager.Domain.Entities
{
    public class Protocol : EntityBase<int>
    {
        [Required]
        public string ProtocolNumber { get; set; }

        [Required]
        public bool IsPhdProtocol { get; set; } = false;
        [Required]
        public bool IsScienceDegreeProtocol { get; set; } = false;
        [Required]
        public bool IsBookPublishingProtocol { get; set; } = false;
        [Required]
        public bool IsAcademicPositionProtocol { get; set; } = false;
        [Required]
        public bool IsForPhDPlagiarism { get; set; } = false;
        [Required]
        public bool IsForSciencePhDPlagiarism { get; set; } = false;
        [Required]
        public bool IsPublicationPlagiarism { get; set; } = false;
        [Required]
        public bool IsAcademicWorkPlagiarism { get; set; } = false;
        [Required]
        public bool IsPlagiarism { get; set; } = false;
        public bool Habilitation { get; set; }
        public bool NonHabilitation { get; set; }
        public bool PublishedBook { get; set; }
        public bool ArticleReviewsNonRelated { get; set; }
        public bool ArticleReviewsRelated { get; set; }
        public bool PaperRelated { get; set; }
        public bool PaperNonRelated { get; set; }
        public bool CollectiveMonographic { get; set; }
        public bool UniversityBook { get; set; }
        public bool UniversityWorkBook { get; set; }
        public string AcademicPosition { get; set; }
        public Guid UserId { get; set; }
        public VTUser User { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? ArticleId { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<ProtocolFile> ProtocolFiles { get; set; }
    }
}
