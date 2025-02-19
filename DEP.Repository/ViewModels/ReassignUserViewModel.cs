namespace DEP.Repository.ViewModels
{
    public class ReassignUserViewModel
    {
        public int DeletedUserId { get; set; }
        public int? NewEducationalConsultantId { get; set; }
        public int? NewEducationalLeaderId { get; set; }
        public int? NewOperationCoordinatorId { get; set; }
    }
}
