using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Entities
{
    public class Image
    {
        private int id;
        private string value;

        public int Id { get => this.id; set => this.id = value; }

        public string Value { get => this.value; set => this.value = value; }

        public override string ToString()
        {
            return $"{id}: {this.value}";
        }
    }
}
