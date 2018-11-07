using System;
using System.Collections.Generic;
using Stubble.Core.Loaders;

namespace StubblePartialBug
{
    class Program
    {
        static string BaseTemplate = "<div>\n    {{>Body}}\n</div>";
        static string BodyTemplate = "<a href=\"{{Url}}\" target=\"_blank\">\n    My Link\n</a>\n";

        static void Main(string[] args)
        {
            var builder = new Stubble.Core.Builders.StubbleBuilder();
            builder.Configure(opts =>
            {
                opts.SetPartialTemplateLoader(new DictionaryLoader(
                    new Dictionary<string, string>{
                        {"Body", BodyTemplate},
                    }
                ));
            });
            var renderer = builder.Build();

            var data = new Dictionary<string, object> { { "Url", "https://github.com" } };

            var output = renderer.Render(BaseTemplate, data);
            Console.WriteLine(output);
        }
    }
}
