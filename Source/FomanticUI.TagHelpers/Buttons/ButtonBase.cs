using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers
{
    public abstract class ButtonBase<T> : FomanticTagHelper
        where T : ButtonBaseData, new()
    {
        protected ButtonBase(
            string cssName,
            string tagName) : base(cssName, tagName)
        {
        }

        /// <summary>
        /// All settings in one value; attributes written on the element override its values.
        /// </summary>
        public T? Data { get; set; }

        public bool IsVisible { get; set; } = true;

        public Color Color { get; set; }

        public Size Size { get; set; }

        public ButtonDecoration Decoration { get; set; }

        public bool Fluid { get; set; }

        public Position Floated { get; set; }

        public Position Attached { get; set; }

        /// <summary>
        /// <see cref="Data"/> with the attributes written on the element applied.
        /// </summary>
        protected T Effective { get; private set; } = new();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            this.Effective = this.ApplyProperties(context, this.Data ?? new T());
            base.Process(context, output);
        }

        /// <summary>
        /// Overrides values of <paramref name="data"/> with the attributes that are set; derived buttons add their own.
        /// </summary>
        protected virtual T ApplyProperties(TagHelperContext context, T data)
        {
            // 'with' on the base record clones the runtime type, so the cast back to T is safe
            ButtonBaseData applied = data with
            {
                IsVisible = IsSet(context, nameof(this.IsVisible)) ? this.IsVisible : data.IsVisible,
                Color = IsSet(context, nameof(this.Color)) ? this.Color : data.Color,
                Size = IsSet(context, nameof(this.Size)) ? this.Size : data.Size,
                Decoration = IsSet(context, nameof(this.Decoration)) ? this.Decoration : data.Decoration,
                Fluid = IsSet(context, nameof(this.Fluid)) ? this.Fluid : data.Fluid,
                Floated = IsSet(context, nameof(this.Floated)) ? this.Floated : data.Floated,
                Attached = IsSet(context, nameof(this.Attached)) ? this.Attached : data.Attached
            };

            return (T)applied;
        }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Effective.Decoration.ToClass();
            yield return "fluid".ToClassIf(this.Effective.Fluid);
            yield return this.Effective.Color.ToClass();
            yield return this.Effective.Size.ToClass();
            yield return this.Effective.Floated.ToFloatedClass();
            yield return this.Effective.Attached.ToAttachedClass();
        }
    }
}
