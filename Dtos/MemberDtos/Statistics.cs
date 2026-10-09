namespace LibraryManagementSys.Dtos.MemberDtos
{
    public class Statistics
    {
        public string Name { get; set; }
        public int totalborrowedbooks { get; set; }
        public int returnedbooks { get; set; }
        public int currentlyborrowedbooks { get; set; }
    }
}
