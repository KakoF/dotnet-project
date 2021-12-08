using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepository<AnnouncementEntity> _repository;
        private readonly IMapper _mapper;
        public AnnouncementService(IRepository<AnnouncementEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<AnnouncementDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<AnnouncementDto>(entity) ?? new AnnouncementDto();
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAll()
        {
            var entityList = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<AnnouncementDto>>(entityList);
        }

        public async Task<AnnouncementDto> Post(AnnouncementDtoCreate item)
        {
            try
            {
                var entity = _mapper.Map<AnnouncementEntity>(item);
                var result = await _repository.InsertAsync(entity);
                return _mapper.Map<AnnouncementDto>(result);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<AnnouncementDto> Put(int id, AnnouncementDtoUpdate item)
        {
            try
            {
                var entity = _mapper.Map<AnnouncementEntity>(item);
                var Announcementpassword = await _repository.SelectAsync(id);
                var result = await _repository.UpdasteAsync(id, entity);
                return _mapper.Map<AnnouncementDto>(result);

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}