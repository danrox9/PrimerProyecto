using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

public class PujaService : IPujaService
{
    private readonly PujaContext _context;
    private readonly IMapper _mapper;

    public PujaService(PujaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public PujaDTO Add(BasePujaDTO basePuja)
    {
        var _mappedPuja = _mapper.Map<PujaEntity>(basePuja);
        var entityAdded = _context.Pujas.Add(_mappedPuja);
        _context.SaveChanges();
        return _mapper.Map<PujaDTO>(entityAdded);
    }

    public void Delete(int guid)
    {
        PujaEntity puja = _context.Pujas.FirstOrDefault(x => x.Id == guid);

        if (puja == null)
            throw new ApplicationException($"Bokk with id {guid} not found");

        _context.Pujas.Remove(puja);
        _context.SaveChanges();
    }

    public IEnumerable<PujaDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<PujaDTO>>(_context.Pujas.Select(x => x));
    }

    public IEnumerable<PujaDTO> GetAllOf(int guid)
    {
        return _mapper.Map<IEnumerable<PujaDTO>>(_context.Pujas.Where(x => x.IdPiedra == guid));
    }

    public PujaDTO GetByID(int guid)
    {
        return _mapper.Map<PujaDTO>(_context.Pujas.FirstOrDefault(x => x.Id == guid));
    }

    public PujaDTO Modify(BasePujaDTO puja, int guid)
    {
        var _mappedPuja = _mapper.Map<PujaEntity>(puja);
        _mappedPuja.Id = guid;

        PujaEntity modifiedPuja = _context.Pujas.FirstOrDefault(x => x.Id == guid);

        if (modifiedPuja == null)
            return null;

        _context.Entry(modifiedPuja).CurrentValues.SetValues(_mappedPuja);

        _context.SaveChanges();

        return _mapper.Map<PujaDTO>(_mappedPuja);
    }

}