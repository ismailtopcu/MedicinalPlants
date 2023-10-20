using MedicinalPlants.DataAccessLayer.Abstract;
using MedicinalPlants.DataAccessLayer.Concrete;
using MedicinalPlants.DataAccessLayer.Repositories;
using MedicinalPlants.EntityLayer.Concrete;

namespace MedicinalPlants.DataAccessLayer.EntityFramework
{
    public class EfAilmentDal : GenericRepository<Ailment>, IAilmentDal
    {
        public EfAilmentDal(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
