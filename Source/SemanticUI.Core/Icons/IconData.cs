using System.Collections.Generic;

namespace Proxoft.SemanticUI.Core
{
    public class IconData
    {
        public string Name { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; } = Color.NoColor;

        public Position Corner { get; set; } = Position.Default;

        public IconDecorations Decorations { get; set; }

        public string ToClass() => this.Classes().ToClass();

        private IEnumerable<string> Classes()
        {
            yield return this.Name;
            yield return this.Size.ToClass();
            yield return this.Color.ToClass();
            yield return this.Decorations.ToClass();
            yield return this.Corner.ToCornerClass();
        }
    }
}
