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
    public class Repo : IDisposable
    {
        public LiteDatabase Databaze
        {
            get; private set;
        }

        public Repo( )
        {
            string _BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Databaze = new LiteDatabase(Path.GetFullPath(Path.Combine(_BaseDirectory, @"..\..\..\..\Sem_BCSH2_2023\Db\MyDb.db")));
        }



        public LiteDatabase GetInstance()
        {
            return Databaze;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Uvolnění prostředků ovládaných
                Databaze?.Dispose();
            }
        }
    }

    //_______Repo Login______________

    public class RepoLogin : IDisposable
    {
        public LiteDatabase Databaze { get; private set; }

        public RepoLogin()
        {
            string _BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Databaze = new LiteDatabase(Path.GetFullPath(Path.Combine(_BaseDirectory, @"..\..\..\..\Sem_BCSH2_2023\Db\LoginDb.db")));
        }

        public LiteDatabase GetInstance()
        {
            return Databaze;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void CloseConnection()
        {
            Databaze?.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Uvolnění prostředků ovládaných
                Databaze?.Dispose();
            }
        }
    }


    //_______End Repo Login______________




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

