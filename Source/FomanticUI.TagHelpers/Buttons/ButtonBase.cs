using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

public abstract class ButtonBase<T> : FomanticTagHelper
    where T : ButtonBaseData, new()
{
    protected ButtonBase(
        string cssName,
        string tagName) : base(cssName, tagName)
    {
    }

    /// <summary>
    ///     All settings in one value; attributes written on the element override its values.
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
    ///     <see cref="Data" /> with the attributes written on the element applied.
    /// </summary>
    protected T Effective { get; private set; } = new();

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        Effective = ApplyProperties(context, Data ?? new T());
        base.Process(context, output);
    }

    /// <summary>
    ///     Overrides values of <paramref name="data" /> with the attributes that are set; derived buttons add their own.
    /// </summary>
    protected virtual T ApplyProperties(TagHelperContext context, T data)
    {
        // 'with' on the base record clones the runtime type, so the cast back to T is safe
        ButtonBaseData applied = data with
        {
            IsVisible = IsSet(context, nameof(IsVisible)) ? IsVisible : data.IsVisible,
            Color = IsSet(context, nameof(Color)) ? Color : data.Color,
            Size = IsSet(context, nameof(Size)) ? Size : data.Size,
            Decoration = IsSet(context, nameof(Decoration)) ? Decoration : data.Decoration,
            Fluid = IsSet(context, nameof(Fluid)) ? Fluid : data.Fluid,
            Floated = IsSet(context, nameof(Floated)) ? Floated : data.Floated,
            Attached = IsSet(context, nameof(Attached)) ? Attached : data.Attached
        };

        return (T)applied;
    }

    protected override IEnumerable<string> Classes()
    {
        yield return Effective.Decoration.ToClass();
        yield return "fluid".ToClassIf(Effective.Fluid);
        yield return Effective.Color.ToClass();
        yield return Effective.Size.ToClass();
        yield return Effective.Floated.ToFloatedClass();
        yield return Effective.Attached.ToAttachedClass();
    }
}