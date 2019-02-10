using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Entities
{
    public class Award
    {
        private int id;
        private string title;
        private int idImage;

        public int Id { get => this.id; set => this.id = value; }

        public string Title { get => this.title; set => this.title = value; }
        public int IdImage { get => this.idImage; set => this.idImage = value; }

        public override string ToString()
        {
            return $"{id}: {this.title} {this.IdImage}";
        }
    }
}
