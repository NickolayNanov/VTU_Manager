namespace VTU_Manager.Domain.Entities
{
    public class DropDownSource : EntityBase<int>
    {
        public string SourceName { get; set; }
        public bool IsActive { get; set; }
        public bool IsReserved { get; set; }
        public IEnumerable<DropDownItem> Items { get; set; }
    }
}
