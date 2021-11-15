using DTOs.TrainingDtos;

namespace Services.Interfaces
{
    public interface ITrainingService
    {
        void CreateTraining(CreateTrainingDto createTrainingDto);
        void EditTraining(EditTrainingDto editTrainingDto);
        void DeleteTraining(int id);
    }
}
