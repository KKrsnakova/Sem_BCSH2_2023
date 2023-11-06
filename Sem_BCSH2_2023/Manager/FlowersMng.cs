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
    public class FlowersMng
    {
        public Repo2<Flower> FlowersRepo { get; set; }

        public FlowersMng(Repo goodsRepo) 
        {
            FlowersRepo = new Repo2<Flower>();
            FlowersRepo.Collection = goodsRepo.GetInstance().GetCollection<Flower>("Flower");
        }

        public Flower GetByIdFlowers(int id)
        {
            return FlowersRepo.GetById(id);
        }

        public ObservableCollection<Flower> GetAllFlowers()
        {
            return FlowersRepo.GetAll();
        }

        public void AddAllFlowers(ObservableCollection<Flower> list)
        {
            FlowersRepo.AddAll(list);
        }

        public void RemoveAllFlowers()
        {
            FlowersRepo.RemoveAll();
        }
    }
}
