using DataAccess.Interfaces;
using Domain.Models;
using DTOs.TrainingDtos;
using Mappers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TrainingService : ITrainingService
    {
        private IRepository<Training> _trainingRepository;
        private IPersonRepository<Trainer> _trainerRepository;

        public TrainingService(IRepository<Training> trainingRepository, IPersonRepository<Trainer> trainerRepository)
        {
            _trainingRepository = trainingRepository;
            _trainerRepository = trainerRepository;
        }

        public void CreateTraining(CreateTrainingDto createTrainingDto)
        {
            Training newTraining = createTrainingDto.ToTraining();
            Trainer newEmailTrainer = createTrainingDto.ToEmailTrainer();
            _trainerRepository.GetById(createTrainingDto.TrainerId);
            newTraining.Trainer = newEmailTrainer;

            newEmailTrainer.Trainings.Add(newTraining);

            _trainerRepository.Update(newEmailTrainer);
            _trainingRepository.Insert(newTraining);
        }

        public void DeleteTraining(int id)
        {
            _trainingRepository.Delete(_trainingRepository.GetById(id));
        }

        public void EditTraining(EditTrainingDto editTrainingDto)
        {
            Training editedTraining = editTrainingDto.ToTraining();
            Trainer trainerDb = _trainerRepository.GetById(editedTraining.TrainerId);
            editedTraining.Trainer = trainerDb;

            _trainingRepository.Update(editedTraining);
        }
    }
}
