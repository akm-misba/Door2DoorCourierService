#pragma checksum "E:\CourierManagement\CourierManagement\CourierManagement\Areas\Admin\Views\Courier\ManagePickup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6b2f14b77a6c01e25bc0631b6cdf3ee46a30de5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Courier_ManagePickup), @"mvc.1.0.view", @"/Areas/Admin/Views/Courier/ManagePickup.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6b2f14b77a6c01e25bc0631b6cdf3ee46a30de5", @"/Areas/Admin/Views/Courier/ManagePickup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b7df09723a08ccdc55e9f97926ffad98c5aa7aa", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Courier_ManagePickup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PickupListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_DeletePopupPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\CourierManagement\CourierManagement\CourierManagement\Areas\Admin\Views\Courier\ManagePickup.cshtml"
  
    ViewData["Title"] = "Manage Pickup";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\n    <link rel=\"stylesheet\" href=\"/admin/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css\">\n");
            }
            );
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""/admin/plugins/datatables/jquery.dataTables.min.js""></script>
    <script src=""/admin/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js""></script>
    <script src=""/admin/plugins/datatables-responsive/js/dataTables.responsive.min.js""></script>
    <script src=""/admin/plugins/datatables-responsive/js/responsive.bootstrap4.min.js""></script>
    <script src=""/admin/plugins/datatables-buttons/js/dataTables.buttons.min.js""></script>
    <script src=""/admin/plugins/datatables-buttons/js/buttons.bootstrap4.min.js""></script>
    <script src=""/admin/plugins/jszip/jszip.min.js""></script>
    <script src=""/admin/plugins/pdfmake/pdfmake.min.js""></script>
    <script src=""/admin/plugins/pdfmake/vfs_fonts.js""></script>
    <script src=""/admin/plugins/datatables-buttons/js/buttons.html5.min.js""></script>
    <script src=""/admin/plugins/datatables-buttons/js/buttons.print.min.js""></script>
    <script src=""/admin/plugins/datatables-buttons/js/buttons.colVis.min.js""></script>

    <script>
        $(fun");
                WriteLiteral(@"ction () {
            $('#pickups').DataTable({
                ""processing"": true,
                ""serverSide"": true,
                dom: 'Bfrtip',
                buttons: [
                    {
                        extend: 'pdfHtml5',
                        orientation: 'landscape',
                        pageSize: 'LEGAL'
                    }
                ]
                ,
                ""ajax"": ""/Admin/Courier/GetPickupData"",

                ""columnDefs"": [
                    {
                        ""orderable"": false,
                        ""targets"": 4,
                        ""render"": function (data, type, row) {

                            return `<button type=""submit"" class=""btn btn-info btn-sm"" onclick=""window.location.href='/admin/Courier/EditPickup/${data}'"" value='${data}'>
                                            <i class=""fas fa-pencil-alt"">
                                            </i>
                                            Edit
                              ");
                WriteLiteral(@"          </button>
                                        <button type=""submit"" class=""btn btn-danger btn-sm show-bs-modal"" href=""#"" data-id='${data}' value='${data}'>
                                            <i class=""fas fa-trash"">
                                            </i>
                                            Delete
                                        </button>`;
                        }
                    }
                ]
            });

            $('#pickups').on('click', '.show-bs-modal', function (event) {
                var id = $(this).data(""id"");
                var modal = $(""#modal-default"");
                modal.find('.modal-body p').text('Are you sure you want to delete this record?')
                $(""#deleteId"").val(id);
                $(""#deleteForm"").attr(""action"", ""/admin/Courier/DeletePickup"")
                modal.modal('show');
            });

            $(""#deleteButton"").click(function () {
                $(""#deleteForm"").submit();
            });
 ");
                WriteLiteral("       });\n    </script>\n");
            }
            );
            WriteLiteral(@"

<!-- Content Header (Page header) -->
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>All Couriers</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""DashBoard"">DashBoard</a></li>
                    <li class=""breadcrumb-item active"">Couriers</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<!-- Main content -->
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">All Couriers</h3>
                    </div>
                    <!-- /.card-header -->
                    <div class=""card-body"">
                        <table id=""pickups");
            WriteLiteral(@""" class=""table table-bordered table-striped"">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Order Id</th>
                                    <th>Courier Id</th>
                                    <th>DateAndTime</th>
                                    <th>Action</th>
                                </tr>
                            </thead>

                            <tfoot>
                                <tr>
                                    <th>Id</th>
                                    <th>Order Id</th>
                                    <th>Courier Id</th>
                                    <th>DateAndTime</th>
                                    <th>Action</th>
                                </tr>
                            </tfoot>
                        </table>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a6b2f14b77a6c01e25bc0631b6cdf3ee46a30de59704", async() => {
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
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
</section>
<!-- /.content -->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PickupListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
