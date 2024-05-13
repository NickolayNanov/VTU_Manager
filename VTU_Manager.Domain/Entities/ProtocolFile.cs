namespace VTU_Manager.Domain.Entities
{
    public class ProtocolFile : EntityBase<int>
    {
        public string FileDir { get; set; }
        public int ProtocolId { get; set; }
        public Protocol Protocol { get; set; }
    }
}
