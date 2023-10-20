using MedicinalPlants.BusinessLayer.Abstract;
using MedicinalPlants.DataAccessLayer.Abstract;
using MedicinalPlants.EntityLayer.Concrete;

namespace MedicinalPlants.BusinessLayer.Concrete
{
    public class AilmentService : IAilmentService
    {
        private readonly IAilmentDal _ailmentDal;

        public AilmentService(IAilmentDal ailmentDal)
        {
            _ailmentDal = ailmentDal;
        }

        public async Task TDeleteAsync(Ailment t)
        {
            await _ailmentDal.DeleteAsync(t);
        }

        public async Task<Ailment> TGetByIdAsync(int id)
        {
            return await _ailmentDal.GetByIdAsync(id);
        }

        public async Task<List<Ailment>> TGetListAsync()
        {
            return await _ailmentDal.GetListAsync();
        }

        public async Task TInsertAsync(Ailment t)
        {
            await _ailmentDal.InsertAsync(t);
        }

        public async Task TUpdateAsync(Ailment t)
        {
            await _ailmentDal.UpdateAsync(t);
        }
    }
}
