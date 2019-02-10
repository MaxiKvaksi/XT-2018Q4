using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.BLL
{
    public class ImageLogic : IImageLogic
    {
        private const string ALL_IMAGES_CACHE_KEY = "GetAllImages";
        private readonly IImageDao imagesDao;
        private readonly ICacheLogic cacheLogic;      

        public ImageLogic(IImageDao imageDao, ICacheLogic cacheLogic)
        {
            this.imagesDao = imageDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(Image image)
        {
            try
            {
                if (image == null)
                {
                    throw new NullReferenceException("User is null");
                }

                this.imagesDao.Add(image);
                this.cacheLogic.Delete(ALL_IMAGES_CACHE_KEY);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            this.imagesDao.Delete(id);
            this.cacheLogic.Delete(ALL_IMAGES_CACHE_KEY);
        }

        public IEnumerable<Image> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<Image>>(ALL_IMAGES_CACHE_KEY);

            if (cacheResult == null)
            {
                var result = this.imagesDao.GetAll();
                this.cacheLogic.Add(ALL_IMAGES_CACHE_KEY, this.imagesDao.GetAll());
                return result;
            }

            return cacheResult;
        }

        public Image GetById(int id)
        {
            return this.imagesDao.GetById(id);
        }
    }
}
