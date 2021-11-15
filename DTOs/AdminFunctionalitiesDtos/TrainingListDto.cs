using System;

namespace DTOs.AdminFunctionalitiesDtos
{
    public class TrainingListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfTotalSpots { get; set; }
        public int NumberOfTakenSpots { get; set; }
        public int NumberOfSpotsRemaining { get; set; }
    }
}
