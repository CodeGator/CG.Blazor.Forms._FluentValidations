using Blazored.FluentValidation;
using CG.Blazor.Forms.Services;
using CG.Validations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CG.Blazor.Forms.Attributes
{
    /// <summary>
    /// This class is an attribute that indicates the form should be 
    /// rendered with a <see cref="FluentValidationValidator"/> tag.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Decorating the top-level model's class with this attribute causes 
    /// the form generator to render a <see cref="FluentValidationValidator"/>
    /// inside the generated form.
    /// </para>
    /// <para>
    /// This attribute is only valid when placed on the class definition for
    /// the top-level model class.
    /// </para>
    /// </remarks>    
    /// <example>
    /// Here is an example of decorating a model class to render a fluent style
    /// validator:
    /// <code>
    /// using CG.Blazor.Forms.Attributes;
    /// 
    /// [RenderFluentValidationValidator]
    /// class MyModel
    /// {
    ///     
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RenderFluentValidationValidatorAttribute : FormValidationAttribute
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <inheritdoc/>
        public override int Generate(
            RenderTreeBuilder builder,
            int index,
            IHandleEvent eventTarget,
            Stack<object> path,
            PropertyInfo prop,
            ILogger<IFormGenerator> logger
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(builder, nameof(builder))
                .ThrowIfLessThanZero(index, nameof(index))
                .ThrowIfNull(path, nameof(path))
                .ThrowIfNull(logger, nameof(logger));

            try
            {
                // Should never happen, but, pffft, check it anyway.
                if (false == path.Any())
                {
                    // Let the world know what we're doing.
                    logger.LogDebug(
                        "RenderFluentValidationValidatorAttribute::Generate called with an empty path!"
                        );

                    // Return the index.
                    return index;
                }

                // Let the world know what we're doing.
                logger.LogDebug(
                    "Rendering a fluent validator for the '{ObjType}' view-model.",
                    path.First().GetType().Name
                    );

                // Render the component.
                builder.OpenComponent<FluentValidationValidator>(index++);
                builder.CloseComponent();

                // Make the HTML purdy.
                builder.AddMarkupContent(index++, "\r\n    ");

                // Return the index.
                return index;
            }
            catch (Exception ex)
            {
                // Provide better context for the error.
                throw new FormGenerationException(
                    message: "Failed to render a fluent validation validator! " +
                        "See inner exception(s) for more detail.",
                    innerException: ex
                    );
            }
        }

        #endregion
    }
}
