using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.Entities;

namespace Epam.Task7.BLL.Interface
{
    public interface IImageLogic
    {
        void Add(Image image);

        void Delete(int id);

        Image GetById(int id);

        IEnumerable<Image> GetAll();
    }
}
