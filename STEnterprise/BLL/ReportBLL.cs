using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using STEnterprise.DAL;
using STEnterprise.Models;
using ReportObject = STEnterprise.CommonObject.ReportObject;

namespace STEnterprise.BLL
{
    public class ReportBLL
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;
        private DataTable dtCommonDataTable;

        public ReportModel GetTypeWiseReportShow(ReportModel objReportModel)
        {
            if (objReportModel.ReportType != null)
            {
                switch (objReportModel.ReportType)
                {
                    case "DailyBuyReport":
                        objReportModel.dtCommon = this.GetDailyBuyReport(objReportModel);
                        break;
                    case "DailyLocalSaleReport":
                        objReportModel.dtCommon = this.GetDailyLocalSaleReport(objReportModel);
                        break;
                    case "DailyPartlyLedger":
                        objReportModel.dtCommon = this.GetDailyPartlyLedgerReport(objReportModel);
                        break;
                    case "ConsignmentWiseSale":
                        objReportModel.dtCommon = this.GetConsignmentWiseSaleReport(objReportModel);
                        break;
                    case "DailyStockReport":
                        objReportModel.dtCommon = this.GetDailyStockReport(objReportModel);
                        break;
                    case "DailyDueStatement":
                        objReportModel.dtCommon = this.GetDailyDueStatementReport(objReportModel);
                        break;
                    case "DailyPayStatement":
                        objReportModel.dtCommon = this.GetDailyPayStatementReport(objReportModel);
                        break;
                    case "DailyForeignSaleReport":
                        objReportModel.dtCommon = this.GetDailyForeignSaleReport(objReportModel);
                        break;
                    case "SalesLedgerAccount":
                        objReportModel.dtCommon = this.GetSalesLedgerAccount(objReportModel);
                        break;
                    case "PurchaseLedgerAccount":
                        objReportModel.dtCommon = this.GetPurchaseLedgerAccount(objReportModel);
                        break;
                    case "ChequePayment":
                        objReportModel.dtCommon = this.GetChequePaymentForPurchase(objReportModel);
                        break;
                    case "ChequeReceived":
                        objReportModel.dtCommon = this.GetChequeReceivedForSale(objReportModel);
                        break;
                    case "ConsignmentWiseTruckFare":
                        objReportModel.dtCommon = this.GetConsignmentWiseTruckFare(objReportModel);
                        break;
                    case "DailyTotalCostEverySubject":
                        objReportModel.dtCommon = this.GetDailyTotalCostEverySubject(objReportModel);
                        break;
                    case "BuyerDetail":
                        objReportModel.dtCommon = this.GetBuyerDetail(objReportModel);
                        break;

                    default:
                        break;
                }
            }
            return objReportModel;
        }

    public DataTable GetDailyBuyReport(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt=new DataTable();
            try
            {
                objDbCommand.AddInParameter("ConsignmentNumber", objReportModel.ConsignmentNumber);
                objDbCommand.AddInParameter("SupplierId", objReportModel.SupplierId);
                objDbCommand.AddInParameter("ProductId", objReportModel.ProductId);
                objDbCommand.AddInParameter("TruckDetailId", objReportModel.TruckDetailId);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetDailyBuyReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        public DataTable GetDailyLocalSaleReport(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("ConsignmentNumber", objReportModel.ConsignmentNumber);
                objDbCommand.AddInParameter("ProductId", objReportModel.ProductId);
                objDbCommand.AddInParameter("TruckDetailId", objReportModel.TruckDetailId);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                objDbCommand.AddInParameter("CustomerId", objReportModel.CustomerId);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetDailyLocalSaleReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }
        public DataTable GetDailyPartlyLedgerReport(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetDailyPartyLedgerReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }


        public DataTable GetConsignmentWiseSaleReport(ReportModel objReportModel)
        {

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("ConsignmentNumber", objReportModel.ConsignmentNumber);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetDailyForeignSaleReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        public DataTable GetDailyStockReport(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                
                objDbCommand.AddInParameter("ProductId", objReportModel.ProductId);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetDailyStockReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        public DataTable GetDailyDueStatementReport(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("ConsignmentNumber", objReportModel.ConsignmentNumber);
                //objDbCommand.AddInParameter("SupplierId", ReportObject.SupplierId);
                objDbCommand.AddInParameter("CustomerId", objReportModel.CustomerId);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetDailyDueStatementReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }
            return dt;
        }

        public DataTable GetDailyPayStatementReport(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("ConsignmentNumber", objReportModel.ConsignmentNumber);
                objDbCommand.AddInParameter("SupplierId", objReportModel.SupplierId);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetDailyPayStatementReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        public DataTable GetDailyForeignSaleReport(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("ConsignmentNumber", objReportModel.ConsignmentNumber);
                objDbCommand.AddInParameter("CustomerId", objReportModel.CustomerId);
                objDbCommand.AddInParameter("CountryId", objReportModel.CountryId);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetDailyForeignSaleReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

       
        public DataTable GetDailyTotalProductionCostReport()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("FromDate", ReportObject.FromDate);
                objDbCommand.AddInParameter("ToDate", ReportObject.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspDailyTotalProductionCostReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }
        public DataTable GetIncomeStatementReport()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("FromDate", ReportObject.FromDate);
                //objDbCommand.AddInParameter("ToDate", ReportObject.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspIncomeStatementReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        public DataTable GetSalesLedgerAccount(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspSalesLedgerAccountReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }
        public DataTable GetPurchaseLedgerAccount(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspPurchaseLedgerAccountReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }


        //ataur
        public DataTable GetChequePaymentForPurchase(ReportModel objReportModel)
        {

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("ConsignmentNumber", objReportModel.ConsignmentNumber);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetChequePaymentForPurchaseReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        //ataur
        public DataTable GetChequeReceivedForSale(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("ConsignmentNumber", objReportModel.ConsignmentNumber);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetChequeReceivedForSaleReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        //ataur
        public DataTable GetConsignmentWiseTruckFare(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("ConsignmentNumber", objReportModel.ConsignmentNumber);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetConsignmentWiseTruckFairReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        public DataTable GetDailyTotalCostEverySubject(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("FromDate", ReportObject.FromDate);
                objDbCommand.AddInParameter("ToDate", ReportObject.ToDate);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetDailyTotalCostEverySubjectReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

        public DataTable GetBuyerDetail(ReportModel objReportModel)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var dt = new DataTable();
            try
            {
                objDbCommand.AddInParameter("ConsignmentNumber", objReportModel.ConsignmentNumber);
                objDbCommand.AddInParameter("FromDate", objReportModel.FromDate);
                objDbCommand.AddInParameter("ToDate", objReportModel.ToDate);
                objDbCommand.AddInParameter("CustomerId", objReportModel.CustomerId);
                objDbCommand.AddInParameter("CountryId", objReportModel.CountryId);
                dt = objDataAccess.ExecuteTable(objDbCommand, "[dbo].uspGetBuyerDetailReport", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }

            return dt;
        }

    }
}