#pragma checksum "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Sessions\Active.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9224f4a46b0a98cf2903b0e7096477972a345114"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sessions_Active), @"mvc.1.0.view", @"/Views/Sessions/Active.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\_ViewImports.cshtml"
using QnA.Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\_ViewImports.cshtml"
using QnA.Website.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9224f4a46b0a98cf2903b0e7096477972a345114", @"/Views/Sessions/Active.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b51d997c8f34d5c980b4819560f5a13a8cfc8824", @"/Views/_ViewImports.cshtml")]
    public class Views_Sessions_Active : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QnA.Application.Admin.Queries.GetActiveSession.GetActiveSessionResult>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Sessions\Active.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9224f4a46b0a98cf2903b0e7096477972a3451143545", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>Board - QnA</title>\r\n    ");
#nullable restore
#line 12 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Sessions\Active.cshtml"
Write(await Html.PartialAsync("_Css"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9224f4a46b0a98cf2903b0e7096477972a3451144908", async() => {
                WriteLiteral("\r\n    <header>\r\n        <nav class=\"navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3\">\r\n            <blockquote class=\"blockquote\">\r\n                <p class=\"mb-0\">");
#nullable restore
#line 18 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Sessions\Active.cshtml"
                           Write(Model.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                <footer class=\"blockquote-footer\">Access Code: <cite title=\"Source Title\">");
#nullable restore
#line 19 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Sessions\Active.cshtml"
                                                                                     Write(Model.Password);

#line default
#line hidden
#nullable disable
                WriteLiteral("</cite></footer>\r\n            </blockquote>\r\n        </nav>\r\n    </header>\r\n\r\n");
#nullable restore
#line 24 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Sessions\Active.cshtml"
     if (Model.IsOffline)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"alert alert-danger text-center\">\r\n            <strong>This session if offline.</strong> The audience is unable to participate.\r\n        </div>\r\n");
#nullable restore
#line 29 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Sessions\Active.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <div id=\"questions-container\"></div>\r\n\r\n    ");
#nullable restore
#line 33 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Sessions\Active.cshtml"
Write(await Html.PartialAsync("_Scripts"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>

<script type=""text/template"" data-template=""question"">
    <div id=""${id}"" class=""card card-question"" data-score=""${score}"">
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col"">
                    <p class=""card-text text-justify"">${text}</p>
                    <p class=""card-text""><small class=""text-muted""><i class=""fa fa-thumbs-up mr-1"" aria-hidden=""true""></i><score>${score}</score></small></p>
                </div>
            </div>
        </div>
    </div>
</script>

<script>

    let $grid;

    getQuestions();

    var connection = new signalR.HubConnectionBuilder().withUrl(""/applicationHub"").build();

    connection.on(""AddQuestion"", function (dto) {

        if (dto.sessionId == getSessionId()) {

            const questionsContainer = $('#questions-container');
            TemplateBuilder.Build(dto, ""question"", questionsContainer);
            questionsContainer.isotope('reloadItems').isotope({ sortBy: '[data-scor");
            WriteLiteral(@"e]' });
        }
    });

    connection.on(""PromoteQuestion"", function (dto) {

        $('#' + dto.id + ' score').text(dto.score);
        $('#' + dto.id).attr(""data-score"", dto.score);
        $grid.isotope('updateSortData');
        $grid.isotope({ sortBy: ""category"", sortAscending: false });

    });

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });

    function getQuestions() {
        $.get('/api/questions/sessionId/' + getSessionId(),
            function (result) {
                const questionsContainer = $('#questions-container');
                questionsContainer.empty();
                TemplateBuilder.Build(result.questions, ""question"", questionsContainer);
                initIsotop();
            });
    }

    function initIsotop() {
        $grid = $('#questions-container').isotope({
            itemSelector: '.card-question',
            layoutMode: 'fitRows',
            getSortData: {
                ca");
            WriteLiteral(@"tegory: '[data-score]'
            }
        });
    }

    function getSessionId() {
        const url = window.location.href;
        const lastslashindex = url.lastIndexOf('/');
        return url.substring(lastslashindex + 1).toLowerCase();
    }

    const TemplateBuilder = function () {
        ""use strict"";

        function findTemplate(templateName) {
            return $('script[data-template=""' + templateName + '""]').text().split(/\$\{(.+?)\}/g);
        }

        function render(props) {
            return function (tok, i) { return (i % 2) ? props[tok] : tok; };
        }

        function build(data, templateName, targetSelector) {

            const template = findTemplate(templateName);

            if (template == """" || template == null || template == 'undefined')
                console.log('Error: cound not find the script template with attribute data-template: ""' + templateName + '"" on page');

            if (!Array.isArray(data)) data = [data];

          ");
            WriteLiteral("  $(targetSelector).append(data.map(function (item) {\r\n                return template.map(render(item)).join(\'\');\r\n            }));\r\n        }\r\n\r\n        return {\r\n            Build: build\r\n        }\r\n\r\n    }();\r\n\r\n\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QnA.Application.Admin.Queries.GetActiveSession.GetActiveSessionResult> Html { get; private set; }
    }
}
#pragma warning restore 1591
