using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Game.GameObjects
{
    public class PlayingField : GameObject
    {
        private int width;
        private int height;

        public int Width { get => this.width; set => this.width = value; }

        public int Height { get => this.height; set => this.height = value; }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }
}
