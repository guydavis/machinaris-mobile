using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Machinapp.MarkupExtensions
{
    [ContentProperty(nameof(ResourceID))]
    internal class EmbeddedImage : IMarkupExtension
    {
        public string ResourceID { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(ResourceID))
            return null;

            return ImageSource.FromResource(ResourceID, typeof(EmbeddedImage).GetTypeInfo().Assembly);
        }
    }
}
