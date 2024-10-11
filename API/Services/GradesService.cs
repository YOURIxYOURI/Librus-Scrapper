﻿using API.DBOs;
using API.DTOs;
using API.Repositories.interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class GradesService : IGradesServices
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradesService(IGradeRepository gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GradesDTO>> GetAllGradesAsync()
        {
            var gradeDbos = await _gradeRepository.GetAllGradesAsync();
            return _mapper.Map<IEnumerable<GradesDTO>>(gradeDbos);
        }

        public async Task<GradesDTO> GetGradeByIdAsync(Guid id)
        {
            var gradeDbo = await _gradeRepository.GetGradeByIdAsync(id);
            if (gradeDbo == null) return null;

            return _mapper.Map<GradesDTO>(gradeDbo);
        }

        public async Task AddGradeAsync(GradesDTO gradeDto)
        {
            var gradeDbo = _mapper.Map<GradesDBO>(gradeDto);
            await _gradeRepository.AddGradeAsync(gradeDbo);
            await _gradeRepository.SaveChangesAsync();
        }

        public async Task UpdateGradeAsync(GradesDTO gradeDto)
        {
            var gradeDbo = await _gradeRepository.GetGradeByIdAsync(gradeDto.Id);
            if (gradeDbo == null) return;

            _mapper.Map(gradeDto, gradeDbo);
            await _gradeRepository.UpdateGradeAsync(gradeDbo);
            await _gradeRepository.SaveChangesAsync();
        }

        public async Task DeleteGradeAsync(Guid id)
        {
            var gradeDbo = await _gradeRepository.GetGradeByIdAsync(id);
            if (gradeDbo == null) return;

            await _gradeRepository.DeleteGradeAsync(gradeDbo);
            await _gradeRepository.SaveChangesAsync();
        }
    }
}