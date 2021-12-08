using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IAnnouncementService
    {
        Task<AnnouncementDto> Get(int id);
        Task<IEnumerable<AnnouncementDto>> GetAll();
        Task<AnnouncementDto> Post(AnnouncementDtoCreate item);
        Task<AnnouncementDto> Put(int id, AnnouncementDtoUpdate item);
        Task<bool> Delete(int id);
    }
}
