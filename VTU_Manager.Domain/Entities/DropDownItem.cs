namespace VTU_Manager.Domain.Entities
{
    public class DropDownItem : EntityBase<int>
    {
        public string Label { get; set; }
        public string Code { get; set; }
        public int DropDownSourceId { get; set; }
        public bool IsReserved { get; set; }
        public DropDownSource DropDownSource { get; set; }
    }
}
