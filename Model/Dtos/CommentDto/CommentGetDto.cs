using CommonTypes.Model;

namespace Model.Dtos.CommentDto
{
    public class CommentGetDto : IDto
    {
        public short Yorumid { get; set; }

        public string? CommentNameSurname { get; set; }

        public string? CommentMail { get; set; }

        public DateTime? CommentDate { get; set; }

        public bool? CommentApproval { get; set; }

        public string? CommentContents { get; set; }

        public short? TripName { get; set; }
    }
}
