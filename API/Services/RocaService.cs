using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

public class RocaService : IRocaService
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;

    public RocaService(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public RocaDTO Add(BaseRocaDTO baseRoca)
    {
        var _mappedRoca = _mapper.Map<RocaEntity>(baseRoca);
        var entityAdded = _context.Rocas.Add(_mappedRoca);
        _context.SaveChanges();
        return _mapper.Map<RocaDTO>(entityAdded);
    }

    public void Delete(int guid)
    {
        RocaEntity roca = _context.Rocas.FirstOrDefault(x => x.Id == guid);

        if (roca == null)
            throw new ApplicationException($"Bokk with id {guid} not found");

        _context.Rocas.Remove(roca);
        _context.SaveChanges();
    }

    public IEnumerable<RocaDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<RocaDTO>>(_context.Rocas.Select(x => x));
    }

    public RocaDTO GetByID(int guid)
    {
        return _mapper.Map<RocaDTO>(_context.Rocas.FirstOrDefault(x => x.Id == guid));
    }

    public RocaDTO Modify(BaseRocaDTO roca, int guid)
    {
        var _mappedRoca = _mapper.Map<RocaEntity>(roca);
        _mappedRoca.Id = guid;

        RocaEntity modifiedRoca = _context.Rocas.FirstOrDefault(x => x.Id == guid);

        if (modifiedRoca == null)
            return null;

        _context.Entry(modifiedRoca).CurrentValues.SetValues(_mappedRoca);

        _context.SaveChanges();

        return _mapper.Map<RocaDTO>(_mappedRoca);
    }

}