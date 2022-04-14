using API_MySIRH.DTOs.MDM;
using API_MySIRH.Entities;
using API_MySIRH.Entities.MDM;

namespace API_MySIRH.Interfaces
{
    public interface ISkillCenterService
    {
        Task<IEnumerable<SkillCenterDTO>> GetSkillCenters();
        Task<SkillCenterDTO> GetSkillCenter(int id);
        Task UpdateSkillCenter(int id, SkillCenterDTO SkillCenter);
        Task<SkillCenterDTO> AddSkillCenter(SkillCenterDTO SkillCenter);
        Task DeleteSkillCenter(int id);
    }
}
