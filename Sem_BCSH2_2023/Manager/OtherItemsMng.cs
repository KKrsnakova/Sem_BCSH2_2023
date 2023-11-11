using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using System.Collections.ObjectModel;

namespace Sem_BCSH2_2023.Manager
{
    public class OtherItemsMng
    {
        public Repo2<OtherItems> OtherItemsRepo { get; set; }

        public OtherItemsMng(Repo goodsRepo) 
        {
            OtherItemsRepo = new Repo2<OtherItems>();
            OtherItemsRepo.Collection = goodsRepo.GetInstance().GetCollection<OtherItems>("OtherItems");
        }

        public OtherItems GetByIdOtherItems(int id)
        {
            return OtherItemsRepo.GetById(id);
        }

        public ObservableCollection<OtherItems> GetAllOtherItems()
        {
            return OtherItemsRepo.GetAll();
        }

        public void AddAllOtherIrems(ObservableCollection<OtherItems> list)
        {
            OtherItemsRepo.AddAll(list);
        }

        public void RemoveAllOtherItems()
        {
            OtherItemsRepo.RemoveAll();
        }
    }
}
