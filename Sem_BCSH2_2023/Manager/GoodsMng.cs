using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Manager
{
    public class GoodsMng
    {
        public Repo2<Good> GoodsRepo { get; set; }

        public GoodsMng(Repo goodsRepo) 
        {
            GoodsRepo = new Repo2<Good>
            {
                Collection = goodsRepo.GetInstance().GetCollection<Good>("Goods")
            };
        }

        public Good GetByIdGoods(int id)
        {
            return GoodsRepo.GetById(id);
        }

        public ObservableCollection<Good> GetAllGoods()
        {
            return GoodsRepo.GetAll();
        }

        public void AddAllGoods(ObservableCollection<Good> list)
        {
            GoodsRepo.AddAll(list);
        }

        public void RemoveAllGoods()
        {
            GoodsRepo.RemoveAll();
        }
    }
}
