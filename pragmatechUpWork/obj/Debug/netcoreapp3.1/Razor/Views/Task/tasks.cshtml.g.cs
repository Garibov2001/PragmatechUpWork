#pragma checksum "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d27fd276fc31d602561ee7fd5f8cb9a4df4a13c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Task_tasks), @"mvc.1.0.view", @"/Views/Task/tasks.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\_ViewImports.cshtml"
using pragmatechUpWork_Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\_ViewImports.cshtml"
using pragmatechUpWork_CoreMVC.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\_ViewImports.cshtml"
using pragmatechUpWork_GeneralLayer.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\_ViewImports.cshtml"
using System.Threading.Tasks;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d27fd276fc31d602561ee7fd5f8cb9a4df4a13c6", @"/Views/Task/tasks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b0700075ed264c337c37e3b1a5dadd263b55b37", @"/Views/_ViewImports.cshtml")]
    public class Views_Task_tasks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Project>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Profile_sidebar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "project-single_project", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "project-edit_project", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/twitter-bootstrap/js/bootstrap.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/projects.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- Transparent Header Spacer -->\r\n<div class=\"transparent-header-spacer\"></div>\r\n\r\n\r\n<!-- Dashboard Container -->\r\n<div class=\"dashboard-container\">\r\n\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d27fd276fc31d602561ee7fd5f8cb9a4df4a13c65766", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <!-- Dashboard Content
    ================================================== -->
    <div class=""dashboard-content-container"" data-simplebar>
        <div class=""dashboard-content-inner"">

            <!-- Dashboard Headline -->
            <div class=""dashboard-headline"">
                <h3>Layihələr</h3>
            </div>

            <!-- Row -->
            <div class=""row"">
                <div class=""col-xl-12"">
                    <div class=""dashboard-box margin-top-0"">
                        <!-- Headline -->
                        <div class=""headline"">
                            <h3><i class=""icon-feather-bar-chart-2""></i> Layihələr</h3>
                        </div>

                        <div class=""content with-padding padding-bottom-10"">
                            <div class=""row"">
                                <table id=""projects_table"" class=""table table-striped text-center"">
                                    <thead>
                               ");
            WriteLiteral(@"         <tr>
                                            <th>Ad</th>
                                            <th>Rəhbər</th>
                                            <th>Deadline</th>
                                            <th>Github</th>
                                            <th>Status</th>
                                            <th>Texniki.T</th>
                                            <th>Alətlər</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 46 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                         if (Model != null)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                             foreach (var projectRecord in Model)
                                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27fd276fc31d602561ee7fd5f8cb9a4df4a13c69336", async() => {
#nullable restore
#line 52 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                                                                                                                 Write(projectRecord.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Route = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                                                                                WriteLiteral(projectRecord.ProjectId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                                    <td><a href=\"#\">");
#nullable restore
#line 53 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                                               Write(projectRecord.ProjectManager);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 55 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                                   Write(projectRecord.StartDate.Value.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 55 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                                                                                           Write(projectRecord.EndDate.Value.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        <a");
            BeginWriteAttribute("href", " href=\"", 2790, "\"", 2821, 1);
#nullable restore
#line 58 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
WriteAttributeValue("", 2797, projectRecord.GithubUrl, 2797, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"icon-feather-github\" style=\"font-size:24px !important;\"></i></a>\r\n                                                    </td>\r\n");
#nullable restore
#line 60 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                                      
                                                        var projStatus = (ProjectStatus)@projectRecord.Status;
                                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td>");
#nullable restore
#line 63 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                                   Write(projStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                                    <td>
                                                        <a href=""#""><i class=""icon-line-awesome-download"" style=""font-size:24px !important;""></i></a>
                                                    </td>
                                                    <td>
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27fd276fc31d602561ee7fd5f8cb9a4df4a13c615021", async() => {
                WriteLiteral("<i class=\"icon-line-awesome-edit\" style=\"font-size:24px !important;\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Route = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                                                                              WriteLiteral(projectRecord.ProjectId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                        <a style=\"cursor: pointer;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3875, "\"", 4003, 4);
            WriteAttributeValue("", 3885, "event.preventDefault();", 3885, 23, true);
            WriteAttributeValue(" ", 3908, "RemoveProject(\'", 3909, 16, true);
#nullable restore
#line 69 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
WriteAttributeValue("", 3924, Url.RouteUrl("project-remove_project", new { id = projectRecord.ProjectId}), 3924, 76, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4000, "\');", 4000, 3, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"icon-material-outline-delete\" style=\"font-size:24px !important; color: red !important;\"></i></a>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27fd276fc31d602561ee7fd5f8cb9a4df4a13c618284", async() => {
                WriteLiteral("<i class=\"icon-material-outline-my-location\" style=\"font-size:24px !important; \"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Route = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                                                                                WriteLiteral(projectRecord.ProjectId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
                                             
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!-- Row / End -->
            <!-- Footer -->
            <div class=""dashboard-footer-spacer""></div>
            <div class=""small-footer margin-top-15"">
                <div class=""small-footer-copyrights"">
                    © 2018 <strong>Hireo</strong>. All Rights Reserved.
                </div>
                <ul class=""footer-social-links"">
                    <li>
                        <a href=""#"" title=""Facebook"" data-tippy-placement=""top"">
                            <i class=""icon-brand-facebook-f""></i>
                        </a>
                    </li>
                    <li>
                        <a href=""#"" title=""Twitter"" data-tippy-placement=""top"">
                            <i class=""icon-brand-twitter""></i>
                 ");
            WriteLiteral(@"       </a>
                    </li>
                    <li>
                        <a href=""#"" title=""Google Plus"" data-tippy-placement=""top"">
                            <i class=""icon-brand-google-plus-g""></i>
                        </a>
                    </li>
                    <li>
                        <a href=""#"" title=""LinkedIn"" data-tippy-placement=""top"">
                            <i class=""icon-brand-linkedin-in""></i>
                        </a>
                    </li>
                </ul>
                <div class=""clearfix""></div>
            </div>
            <!-- Footer / End -->

        </div>
    </div>
    <!-- Dashboard Content / End -->

</div>
<!-- Dashboard Container / End -->



");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27fd276fc31d602561ee7fd5f8cb9a4df4a13c623221", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 126 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d27fd276fc31d602561ee7fd5f8cb9a4df4a13c625205", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 127 "C:\Users\Es-Selamun Aleykum\Desktop\SamirKerimov-GitHub_UpWork\pragmatechUpWork\Views\Task\tasks.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Project>> Html { get; private set; }
    }
}
#pragma warning restore 1591
