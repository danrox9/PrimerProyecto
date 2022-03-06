using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

public interface IPujaService
{
    public IEnumerable<PujaDTO> GetAll();

    public IEnumerable<PujaDTO> GetAllOf(int guid);

    public PujaDTO GetByID(int guid);

    public PujaDTO Add(BasePujaDTO guid);

    public void Delete(int guid);

    public PujaDTO Modify(BasePujaDTO puja, int guid);
}