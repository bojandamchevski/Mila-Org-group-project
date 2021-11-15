using System;

namespace DTOs.TrainingDtos
{
    public class EditTrainingDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int NumberOfTotalSpots { get; set; }
        public int TrainerId { get; set; }
    }
}
