using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.Blazor
{
    public abstract class SemanticComponent : ComponentBase
    {
        private Tooltip _tooltip = new ();

        protected SemanticComponent(string cssName, bool prefixUiClass = true)
        {
            this.CssName = cssName;
            this.PrefixUiClass = prefixUiClass;
        }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> UnmatchedAttributes { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public Tooltip Tooltip
        {
            get => _tooltip;
            set => _tooltip = value ?? new Tooltip();
        }

        [Parameter]
        public string TooltipContent
        {
            get => this.Tooltip.Content;
            set => this.Tooltip.Content = value;
        }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        protected string CssName { get; set; }

        protected bool PrefixUiClass { get; set; }

        protected string Class()
        {
            return new[]
            {
                this.PrefixUiClass.ToClassIf("ui")
            }
            .Concat(this.Classes())
            .Concat(new [] { this.CssName })
            .Concat(this.AfterCssNameClasses())
            .ToClass();
        }

        protected abstract IEnumerable<string> Classes();

        protected virtual IEnumerable<string> AfterCssNameClasses()
        {
            yield break;
        }

        protected Dictionary<string, object> Attributes()
        {
            var attributes = this.UnmatchedAttributes ?? new Dictionary<string, object>();
            InitializeAttributes(attributes);
            return attributes;
        }

        protected virtual void InitializeAttributes(Dictionary<string, object> attributes)
        {
            this.Tooltip.SetAttributes(attributes);
            this.Title.SetAsAttribute("title", attributes);
        }
    }
}
