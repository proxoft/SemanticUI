using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.Blazor
{
    public abstract class ButtonBase<T> : ContainerSemanticComponent
        where T: ButtonBaseData
    {
        public ButtonBase(string cssName) : base(cssName)
        {
        }

        private T _data = Activator.CreateInstance<T>();

        [Parameter]
        public T Data
        {
            get => _data;
            set => _data = value ?? Activator.CreateInstance<T>();
        }

        [Parameter]
        public bool IsVisible
        {
            get => _data.IsVisible;
            set => _data.IsVisible = value;
        }

        [Parameter]
        public Color Color
        {
            get => _data.Color;
            set => _data.Color = value;
        }

        [Parameter]
        public Size Size {
            get => _data.Size;
            set => _data.Size = value;
        }

        [Parameter]
        public ButtonDecoration Decoration
        {
            get => _data.Decoration;
            set => _data.Decoration = value;
        }

        [Parameter]
        public bool Fluid
        {
            get => _data.Fluid;
            set => _data.Fluid = value;
        }

        [Parameter]
        public Position Floated
        {
            get => _data.Floated;
            set => _data.Floated = value;
        }

        [Parameter]
        public Position Attached
        {
            get => _data.Attached;
            set => _data.Attached = value;
        }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Decoration.ToClass();
            yield return "fluid".ToClassIf(this.Fluid);
            yield return this.Color.ToClass();
            yield return this.Size.ToClass();
            yield return this.Floated.ToFloatedClass();
            yield return this.Attached.ToAttachedClass();
        }
    }
}
