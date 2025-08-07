namespace LeaveManagementSystem.Application.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(150, ErrorMessage = "Name cannot exceed 150 characters")]
        [MinLength(4, ErrorMessage = "Name must be at least 3 characters long")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Number of days is required")]
        [Range(1, 90, ErrorMessage = "Number of days must be between 1 and 90")]
        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }
    }
}
