namespace OvertimeTracker.Models
{
	public class OvertimeData
	{
		public DateOnly Date { get; set; }
		public TimeOnly Start { get; set; }
		public TimeOnly End { get; set; }
		public float Overtime { get; set; }

		public void FromJson() { }
	}
}
