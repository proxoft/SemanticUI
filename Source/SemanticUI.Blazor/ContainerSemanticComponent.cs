using Microsoft.AspNetCore.Components;

namespace Proxoft.SemanticUI.Blazor
{
    public abstract class ContainerSemanticComponent : SemanticComponent
    {
        protected ContainerSemanticComponent(string cssName, bool prefixUiClass = true) : base(cssName, prefixUiClass)
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
