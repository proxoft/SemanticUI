using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.Blazor
{
    public class InputComponent : SemanticComponent
    {
        public InputComponent(string cssName, bool prefixUiClass = true) : base(cssName, prefixUiClass)
        {
        }

        [Parameter]
        public Size Size { get; set; }

        [Parameter]
        public EditState State { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Size.ToClass();
            yield return this.State.ToClass();
        }
    }
}
