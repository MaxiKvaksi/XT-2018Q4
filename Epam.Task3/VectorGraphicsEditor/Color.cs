namespace Epam.Task3.VectorGraphicsEditor
{
    public class Color
    {
        private string color;

        public Color(string color)
        {
            this.Color_ = color;
        }

        public string Color_ { get => this.color; set => this.color = value; }

        public override string ToString()
        {
            return this.color;
        }
    }
}