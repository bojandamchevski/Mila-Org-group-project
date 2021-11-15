using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Training : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int NumberOfTotalSpots { get; set; }
        public int NumberOfTakenSpots { get; set; }
        public int NumberOfSpotsRemaining { get; set; }
        public Trainer Trainer { get; set; }
        public int TrainerId { get; set; }
        public List<UserTraining> UserTrainings { get; set; }
        public Training()
        {
            NumberOfSpotsRemaining = NumberOfTotalSpots - NumberOfTakenSpots;
            UserTrainings = new List<UserTraining>();
        }
    }
}
