using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor
{
    public abstract class ButtonBase<T> : ContainerFomanticComponent
        where T: ButtonBaseData, new()
    {
        public ButtonBase(string cssName) : base(cssName)
        {
        }

        /// <summary>
        /// All settings in one value; individual parameters override its values.
        /// </summary>
        [Parameter]
        public T? Data { get; set; }

        [Parameter]
        public bool? IsVisible { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        [Parameter]
        public ButtonDecoration? Decoration { get; set; }

        [Parameter]
        public bool? Fluid { get; set; }

        [Parameter]
        public Position? Floated { get; set; }

        [Parameter]
        public Position? Attached { get; set; }

        /// <summary>
        /// <see cref="Data"/> with the individual parameters applied.
        /// </summary>
        protected T Effective { get; private set; } = new();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            this.Effective = this.ApplyParameters(this.Data ?? new T());
        }

        /// <summary>
        /// Overrides values of <paramref name="data"/> with the parameters that are set; derived buttons add their own.
        /// </summary>
        protected virtual T ApplyParameters(T data)
        {
            // 'with' on the base record clones the runtime type, so the cast back to T is safe
            ButtonBaseData applied = data with
            {
                IsVisible = this.IsVisible ?? data.IsVisible,
                Color = this.Color ?? data.Color,
                Size = this.Size ?? data.Size,
                Decoration = this.Decoration ?? data.Decoration,
                Fluid = this.Fluid ?? data.Fluid,
                Floated = this.Floated ?? data.Floated,
                Attached = this.Attached ?? data.Attached
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
