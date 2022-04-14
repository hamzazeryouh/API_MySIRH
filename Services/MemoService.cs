using API_MySIRH.DTOs;
using API_MySIRH.Entities;
using API_MySIRH.Interfaces;
using AutoMapper;

namespace API_MySIRH.Services
{
    public class MemoService : IMemoService
    {
        private readonly IMemoRepository _memoRepository;
        private readonly IMapper _mapper;

        public MemoService(IMemoRepository memoRepository, IMapper mapper)
        {
            this._memoRepository = memoRepository;
            this._mapper = mapper;
        }
        public async Task<MemoDTO> AddMemo(MemoDTO memoDTO)
        {
            var returnedMemo = await _memoRepository.AddMemo(_mapper.Map<Memo>(memoDTO));
            return _mapper.Map<MemoDTO>(returnedMemo);
        }

        public async Task DeleteMemo(int id)
        {
            await _memoRepository.DeleteMemo(id);
        }

        public async Task<MemoDTO> GetMemo(int id)
        {
            var result = await _memoRepository.GetMemo(id);
            return _mapper.Map<MemoDTO>(result);
        }

        public async Task<IEnumerable<MemoDTO>> GetMemos()
        {
            var result = await _memoRepository.GetMemos();
            return _mapper.Map<IEnumerable<Memo>, IEnumerable<MemoDTO>>(result);
        }

        public async Task UpdateMemo(int id, MemoDTO memoDTO)
        {
            var memo = _mapper.Map<Memo>(memoDTO);
            await _memoRepository.UpdateMemo(id, memo);
        }
    }
}
