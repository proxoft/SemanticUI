using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor
{
    public abstract class ItemBase : ContainerFomanticComponent
    {
        protected ItemBase(string cssName, bool prefixUiClass) : base(cssName, prefixUiClass)
        {
        }

        [Parameter]
        public Color Color { get; set; }

        [Parameter]
        public bool IsActive { get; set; }

        [Parameter]
        public string RightIcon { get; set; } = "";

        [Parameter]
        public ItemDecorations Decorations { get; set; }

        protected bool HasRightIcon => !string.IsNullOrWhiteSpace(this.RightIcon);

        protected override IEnumerable<string> Classes()
        {
            yield return this.Color.ToClass();
            yield return "active".ToClassIf(this.IsActive);
            yield return this.Decorations.ToClass();
        }
    }
}
