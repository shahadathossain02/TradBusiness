using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using STEnterprise.Areas.Inventory.BLL;
using STEnterprise.Areas.Inventory.Models;
using STEnterprise.Areas.Purchase.BLL;
using STEnterprise.Areas.Purchase.Models;
using STEnterprise.Areas.Sale.BLL;
using STEnterprise.Areas.Sale.Models;
using STEnterprise.AuthData;
using STEnterprise.BLL;
using STEnterprise.CommonObject;
using STEnterprise.Models;

namespace STEnterprise.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        [AuthenticationFilter]
       
        public ActionResult Index()
        {
            SupplierBLL objSupplierBLL = new SupplierBLL();
            List<Supplier> SupplierList = objSupplierBLL.GetAllSupplier();
            ViewBag.supplierList = SupplierList;
            ProductBLL objProductBll = new ProductBLL();
            List<Product> ProductList = objProductBll.GetAllProduct();
            ViewBag.productList = ProductList;
            CustomerDetailBLL objCustomerBLL = new CustomerDetailBLL();
            ViewBag.customerList = objCustomerBLL.GetAllCustomerInfo();
            CountryBLL objCountryBLL = new CountryBLL();
            ViewBag.countryList = objCountryBLL.GetAllCountry();

            return View();
        }
        
        [HttpPost]
        public ActionResult Index(ReportModel objReportModel)
        {
            if (ModelState.IsValid)
            {
                ReportBLL objReportBLL=new ReportBLL();
                objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            }
            return View(objReportModel.ReportType, objReportModel);
        }
        public ActionResult ExportPDF(ReportModel objReportModel)
        {
            if (objReportModel.ReportType != null)
            {
                switch (objReportModel.ReportType)
                {
                    case "DailyBuyReport":
                        return new Rotativa.MVC.ActionAsPdf("DailyBuyReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/DailyBuyReport.pdf")
                        };
                        break;
                    case "DailyLocalSaleReport":
                        return new Rotativa.MVC.ActionAsPdf("DailyLocalSaleReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/DailyLocalSaleReport.pdf")
                        };
                        break;
                    case "DailyPartlyLedger":
                        return new Rotativa.MVC.ActionAsPdf("DailyPartlyLedgerReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/DailyPartlyLedgerReport.pdf")
                        };
                        break;
                    case "ConsignmentWiseSale":
                        return new Rotativa.MVC.ActionAsPdf("ConsignmentWiseSaleReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/ConsignmentWiseSaleReport.pdf")
                        };
                        break;
                    case "DailyStockReport":
                        return new Rotativa.MVC.ActionAsPdf("DailyStockReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/DailyStockReport.pdf")
                        };
                        break;
                    case "DailyDueStatement":
                        return new Rotativa.MVC.ActionAsPdf("DailyDueStatementReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/DailyDueStatement.pdf")
                        };
                        break;
                    case "DailyPayStatement":
                        return new Rotativa.MVC.ActionAsPdf("DailyPayStatementReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/DailyPayStatement.pdf")
                        };
                        break;
                    case "DailyForeignSaleReport":
                        return new Rotativa.MVC.ActionAsPdf("DailyForeignSaleReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/DailyForeignSaleReport.pdf")
                        };
                        break;
                    case "SalesLedgerAccount":
                        return new Rotativa.MVC.ActionAsPdf("SalesLedgerAccountReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/SalesLedgerAccountReport.pdf")
                        };
                        break;
                    case "PurchaseLedgerAccount":
                        return new Rotativa.MVC.ActionAsPdf("PurchaseLedgerAccountReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/PurchaseLedgerAccountReport.pdf")
                        };
                        break;
                    case "ChequePayment":
                        return new Rotativa.MVC.ActionAsPdf("ChequePaymentReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/ChequePaymentReport.pdf")
                        };
                        break;
                    case "ChequeReceived":
                        return new Rotativa.MVC.ActionAsPdf("ChequeReceivedReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/ChequeReceivedReport.pdf")
                        };
                        break;
                    case "ConsignmentWiseTruckFare":
                        return new Rotativa.MVC.ActionAsPdf("ConsignmentWiseTruckFareReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/ConsignmentWiseTruckFareReport.pdf")
                        };
                        break;
                    case "DailyTotalCostEverySubject":
                        return new Rotativa.MVC.ActionAsPdf("DailyTotalCostEverySubjectReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/DailyTotalCostEverySubjectReport.pdf")
                        };
                        break;
                    case "BuyerDetail":
                        return new Rotativa.MVC.ActionAsPdf("BuyerDetailReportPDF", new { FromDate = objReportModel.FromDate, ToDate = objReportModel.ToDate, ReportType = objReportModel.ReportType })
                        {
                            FileName = Server.MapPath("~/Content/BuyerDetailReport.pdf")
                        };
                        break;

                    default:
                        break;
                }
            }
            return View(); 
        }
        public ActionResult DailyBuyReportPDF(ReportModel objReportModel)
        {            
                ReportBLL objReportBLL = new ReportBLL();
                objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);           
            return View(objReportModel);
        }
        public ActionResult DailyLocalSaleReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult DailyPartlyLedgerReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult ConsignmentWiseSaleReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult DailyStockReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult DailyDueStatementReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult DailyPayStatementReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult DailyForeignSaleReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult SalesLedgerAccountReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult PurchaseLedgerAccountReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult ChequePaymentReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult ChequeReceivedReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult ConsignmentWiseTruckFareReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult DailyTotalCostEverySubjectReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
        public ActionResult BuyerDetailReportPDF(ReportModel objReportModel)
        {
            ReportBLL objReportBLL = new ReportBLL();
            objReportModel = objReportBLL.GetTypeWiseReportShow(objReportModel);
            return View(objReportModel);
        }
    }
}