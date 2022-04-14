using API_MySIRH.Entities.MDM;

namespace API_MySIRH.Interfaces
{
    public interface ISkillCenterRepository
    {
        Task<IEnumerable<SkillCenter>> GetSkillCenters();
        Task<SkillCenter> GetSkillCenter(int id);
        Task UpdateSkillCenter(int id, SkillCenter SkillCenter);
        Task<SkillCenter> AddSkillCenter(SkillCenter SkillCenter);
        Task DeleteSkillCenter(int id);
        Task<bool> SkillCenterExists(int id);
    }
}
