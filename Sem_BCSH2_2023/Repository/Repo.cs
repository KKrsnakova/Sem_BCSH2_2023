using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_BCSH2_2023.Repository
{
    public class Repo
    {
        public LiteDatabase Databaze
        {
            get; set;
        }

        public Repo()
        {
            string _BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Databaze = new LiteDatabase(Path.GetFullPath(Path.Combine(_BaseDirectory, @"..\..\..\..\Db\MyDb.db")));
        }

        public LiteDatabase GetInstance()
        {
            return Databaze;
        }
    }

    public class Repo2<T>
    {
        public ILiteCollection<T> Collection { get; set; }
        public T GetById(int id)
        {
            try
            {
                return Collection.FindById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ObservableCollection<T> GetAll()
        {
            try
            {
                IEnumerable<T> ienu = Collection.FindAll();
                ObservableCollection<T> collection = new();
                foreach (var item in ienu)
                {
                    collection.Add(item);
                }
                return collection;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddAll(ObservableCollection<T> list)
        {
            try
            {
                foreach (var item in list)
                {
                    Collection.Insert(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveAll()
        {
            try
            {
                Collection.DeleteAll();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

