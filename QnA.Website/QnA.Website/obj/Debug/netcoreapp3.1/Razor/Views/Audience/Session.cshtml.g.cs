#pragma checksum "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Audience\Session.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8d07231a336fc53382cf39a6d9c6e65bb7997d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Audience_Session), @"mvc.1.0.view", @"/Views/Audience/Session.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8d07231a336fc53382cf39a6d9c6e65bb7997d2", @"/Views/Audience/Session.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b51d997c8f34d5c980b4819560f5a13a8cfc8824", @"/Views/_ViewImports.cshtml")]
    public class Views_Audience_Session : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QnA.Application.Audience.Queries.GetSession.GetSessionResult>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Audience\Session.cshtml"
  
    ViewData["Title"] = "Session";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card mb-2\">\r\n    <div class=\"card-body\">\r\n        <h4 class=\"card-title\">");
#nullable restore
#line 11 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Audience\Session.cshtml"
                          Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        <div id=\"add-question-form-wrapper\">\r\n            ");
#nullable restore
#line 13 "C:\Users\Crash\Desktop\QnA\QnA.Website\QnA.Website\Views\Audience\Session.cshtml"
       Write(await Html.PartialAsync("_AskQuestion", Model.AddQuestionCommand));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    </div>
</div>

<div id=""questions-container"" class=""list-group list-group-flush""></div>

<script type=""text/template"" data-template=""question"">
    <div id=""${id}"" class=""list-group-item"" data-score=""${score}"">
        <div class=""row"">
            <div class=""col-xs-1"">
                <i class=""far fa-arrow-alt-circle-up fa-2x mb-3 js-btn-vote"" data-questionId=""${id}"" data-canvote=""${canVote}"" data-not-already-voted=""${notAlreadyVoted}""></i>
                <p><small class=""text-muted""><i class=""fa fa-thumbs-up fa-2x mr-1"" aria-hidden=""true""></i><score>${score}</score></small></p>
            </div>
            <div class=""col"">
                <p class=""text-justify"">${text} <span class=""badge badge-pill badge-info js-owner-label"" data-isowner=""${isCreatedByUser}"">Own question</span></p>
            </div>
        </div>

    </div>
</script>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>

        let $grid;

        getQuestions();

        var connection = new signalR.HubConnectionBuilder().withUrl(""/applicationHub"").build();

        connection.on(""AddQuestion"", getQuestions);

        connection.on(""PromoteQuestion"", getQuestions);

        connection.start().catch(function (err) {
            return console.error(err.toString());
        });

        $(document).delegate('.js-btn-vote', 'click', function () {
            const canVote = $(this).attr('data-canvote');
            if (canVote == 'true') {
                const questionId = $(this).attr('data-questionId');
                promoteQuestion(questionId);
            }
        });

        function updateVoteButtons() {
            $('.js-btn-vote').each(function () {
                const canVote = $(this).attr('data-canvote');
                if (canVote == 'false') {
                    $(this).hide();
                } else {
                    const notAlreadyVoted = $(this).att");
                WriteLiteral(@"r('data-not-already-voted');
                    if (notAlreadyVoted == 'true') {
                        $(this).css('color', 'black');
                    } else {
                        $(this).css('color', 'green');
                    }
                }
            });
        }

        function updateOwnerLabels() {
            $('.js-owner-label').each(function () {
                const isOwner = $(this).attr('data-isowner');
                if (isOwner == 'false') {
                    $(this).hide();
                }
            });
        }

        function getQuestions() {
            $.get('/api/audience/questions/sessionId/' + getSessionId(),
                function (result) {
                    const questionsContainer = $('#questions-container');
                    questionsContainer.empty();
                    TemplateBuilder.Build(result.questions, ""question"", questionsContainer);
                    updateVoteButtons();
                    updateOwnerLabe");
                WriteLiteral(@"ls();
                });
        }

        function promoteQuestion(questionId) {
            const data = {
                questionId: questionId,
                sessionId: getSessionId()
            }

            $.post('/api/audience/questions/promote', data)
                .done(function () {

                })
                .fail(function (jqxhr, status, error) {
                    alert(error);
                });
        }

        function getSessionId() {
            const url = window.location.href;
            const lastslashindex = url.lastIndexOf('/');
            return url.substring(lastslashindex + 1).toLowerCase();
        }

        function onQuestionAsked() {
            $('#question-input').val("""");
        }

        function onAskingQuestionFailure(error) {
            console.log(error);
        }

        const TemplateBuilder = function () {
            ""use strict"";

            function findTemplate(templateName) {
                retu");
                WriteLiteral(@"rn $('script[data-template=""' + templateName + '""]').text().split(/\$\{(.+?)\}/g);
            }

            function render(props) {
                return function (tok, i) { return (i % 2) ? props[tok] : tok; };
            }

            function build(data, templateName, targetSelector) {

                const template = findTemplate(templateName);

                if (template == """" || template == null || template == 'undefined')
                    console.log('Error: cound not find the script template with attribute data-template: ""' +
                        templateName +
                        '"" on page');

                if (!Array.isArray(data)) data = [data];

                $(targetSelector).append(data.map(function (item) {
                    return template.map(render(item)).join('');
                }));
            }

            return {
                Build: build
            }

        }();


    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QnA.Application.Audience.Queries.GetSession.GetSessionResult> Html { get; private set; }
    }
}
#pragma warning restore 1591
