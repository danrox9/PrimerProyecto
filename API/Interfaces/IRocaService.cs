using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

public interface IRocaService
{
    public IEnumerable<RocaDTO> GetAll();

    public RocaDTO GetByID(int guid);

    public RocaDTO Add(BaseRocaDTO guid);

    public void Delete(int guid);

    public RocaDTO Modify(BaseRocaDTO roca, int guid);
}