using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor;

public abstract class ButtonBase<T> : ContainerFomanticComponent
    where T : ButtonBaseData, new()
{
    public ButtonBase(string cssName) : base(cssName)
    {
    }

    /// <summary>
    ///     All settings in one value; individual parameters override its values.
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
    ///     <see cref="Data" /> with the individual parameters applied.
    /// </summary>
    protected T Effective { get; private set; } = new();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        Effective = ApplyParameters(Data ?? new T());
    }

    /// <summary>
    ///     Overrides values of <paramref name="data" /> with the parameters that are set; derived buttons add their own.
    /// </summary>
    protected virtual T ApplyParameters(T data)
    {
        // 'with' on the base record clones the runtime type, so the cast back to T is safe
        ButtonBaseData applied = data with
        {
            IsVisible = IsVisible ?? data.IsVisible,
            Color = Color ?? data.Color,
            Size = Size ?? data.Size,
            Decoration = Decoration ?? data.Decoration,
            Fluid = Fluid ?? data.Fluid,
            Floated = Floated ?? data.Floated,
            Attached = Attached ?? data.Attached
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