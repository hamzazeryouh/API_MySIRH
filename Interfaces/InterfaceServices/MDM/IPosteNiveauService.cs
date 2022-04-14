using API_MySIRH.DTOs.MDM;

namespace API_MySIRH.Interfaces.InterfaceServices.MDM
{
    public interface IPosteNiveauService
    {
        Task<IEnumerable<PosteNiveauDTO>> GetPosteNiveaus();
        Task<PosteNiveauDTO> GetPosteNiveau(int id);
        Task UpdatePosteNiveau(int id, PosteNiveauDTO PosteNiveau);
        Task<PosteNiveauDTO> AddPosteNiveau(PosteNiveauDTO PosteNiveau);
        Task DeletePosteNiveau(int id);
    }
}
