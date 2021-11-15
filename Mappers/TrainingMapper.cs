using Domain.Models;
using DTOs.TrainingDtos;

namespace Mappers
{
    public static class TrainingMapper
    {
        public static Training ToTraining(this CreateTrainingDto createTrainingDto)
        {
            return new Training()
            {
                Title = createTrainingDto.Title,
                Comments = createTrainingDto.Comments,
                Date = createTrainingDto.Date,
                NumberOfTotalSpots = createTrainingDto.NumberOfTotalSpots,
                TrainerId = createTrainingDto.TrainerId
            };
        }

        public static Trainer ToEmailTrainer(this CreateTrainingDto createTrainingDto)
        {
            return new Trainer()
            {
                Email = createTrainingDto.Email
            };
        }

        public static Training ToTraining(this EditTrainingDto editTrainingDto)
        {
            return new Training()
            {
                Title = editTrainingDto.Title,
                Comments = editTrainingDto.Comments,
                Date = editTrainingDto.Date,
                NumberOfTotalSpots = editTrainingDto.NumberOfTotalSpots,
                TrainerId = editTrainingDto.TrainerId
            };
        }
    }
}
