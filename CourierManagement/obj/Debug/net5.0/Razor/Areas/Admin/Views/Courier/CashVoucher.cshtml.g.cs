#pragma checksum "E:\CourierManagement\CourierManagement\CourierManagement\Areas\Admin\Views\Courier\CashVoucher.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc0f5d48c2b60be1fc0620e54782d7b16c7f99fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Courier_CashVoucher), @"mvc.1.0.view", @"/Areas/Admin/Views/Courier/CashVoucher.cshtml")]
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
#line 1 "E:\CourierManagement\CourierManagement\CourierManagement\Areas\Admin\Views\_ViewImports.cshtml"
using CourierManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\CourierManagement\CourierManagement\CourierManagement\Areas\Admin\Views\_ViewImports.cshtml"
using CourierManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\CourierManagement\CourierManagement\CourierManagement\Areas\Admin\Views\_ViewImports.cshtml"
using CourierManagement.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc0f5d48c2b60be1fc0620e54782d7b16c7f99fb", @"/Areas/Admin/Views/Courier/CashVoucher.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b7df09723a08ccdc55e9f97926ffad98c5aa7aa", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Courier_CashVoucher : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Courier", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\CourierManagement\CourierManagement\CourierManagement\Areas\Admin\Views\Courier\CashVoucher.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "CashVoucher";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<h3>CashVoucher</h3>
<div align=""center"">
    <div class=""col-md-8 "">
        <div class=""card card-info"">
            <div class=""card-header"">
            </div>
            <!-- /.card-header -->
            <!-- form start -->

            <div class=""card-body"">

                <div class=""form-group row"">
                    <label class=""col-sm-2 col-form-label"">Voucher No</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control""
                               id=""from"" placeholder=""0 "">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label class=""col-sm-2 col-form-label"">Customer Name</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control""
                               id=""from"" placeholder="" Name"">
                    </div>
                </div>
                <div class=""form-group r");
            WriteLiteral(@"ow"">
                    <label class=""col-sm-2 col-form-label"">Amount</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control""
                               id=""from"" placeholder=""0"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label class=""col-sm-2 col-form-label"">Amount in Words</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control""
                               id=""from"" placeholder=""Amount in Words"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label class=""col-sm-2 col-form-label"">Payment Method</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control""
                               id=""from"" placeholder=""Bkash/Nagad"">
                    </div>
                </div");
            WriteLiteral(@">
                <div class=""form-group row"">

                    <label class=""col-sm-2 col-form-label"">  Product Quantity</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control""
                               id=""from"" placeholder=""0"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label class=""col-sm-2 col-form-label"">Order Id</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control""
                               id=""from"" placeholder=""0"">
                    </div>
                </div>
                <div class=""form-group row"">
                    <label class=""col-sm-2 col-form-label"">Date</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control""
                               id=""from"" placeholder=""dd/mm/yyyy"">
                    </di");
            WriteLiteral(@"v>
                </div>
                <div>
                </div>
                <div class=""form-group row"">
                    <label class=""col-sm-2 col-form-label"">Signature</label>
                    <div class=""col-sm-3"">
                        <input type=""text"" class=""form-control""
                               id=""from""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 3528, "\"", 3542, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                </div>
            </div>

        </div>


        <!-- /.card-body -->
        <div class=""card-footer"">
            <button type=""submit"" class=""btn btn-primary w-80 "" style=""float: left;"">Print</button>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc0f5d48c2b60be1fc0620e54782d7b16c7f99fb8829", async() => {
                WriteLiteral("Cancel");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <!-- /.card-footer -->\r\n\r\n    </div>\r\n</div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
