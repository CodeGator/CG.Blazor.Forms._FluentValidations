using CG.Blazor.Forms.Attributes;
using System;

namespace CG.Blazor.Forms._FluentValidations.QuickStart.ViewModels
{
    /// <summary>
    /// This class is a view-model for rendering blazored fluent validators.
    /// </summary>
    [RenderValidationSummary()]
    [RenderFluentValidationValidator]
    public class ValidatorVM
    {
        [RenderInputText(Placeholder = "try to submit with this field empty.")]
        public string A1 { get; set; }
    }
}
