using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Primitives;
using StarTech.Application.Interface.RepositoryInterface.HR;
using StarTech.Model.Attendance;
using StarTech.Model.HR.Attendance;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.BLL.Repository.HR
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public IDbConnection db;
        public AttendanceRepository() => db = new SqlConnection(Connection.ConnectionString());

        public async Task<bool> ApproveAttendance(int ID)
        {


            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))
            {

                string sql = $"UPDATE AttendencDetails SET approveByHr=1  WHERE ID={ID}";
                int rowAffect = con.Execute(sql);
                return rowAffect > 0;


            }
           
        }
        public async Task<bool> RejectAttendance(int ID)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString()))
            {
                string sql = $"UPDATE AttendencDetails SET approveByHr=3  WHERE ID={ID}";
                int rowAffect = con.Execute(sql);
                return rowAffect > 0;

            }
        }
        public async Task<bool> SaveManualAttendence(ManualAttendenceModel model)
        {

            int rowAffect = 0;
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        //var vonne = new
                        //{
                        //    model.EmpCod,
                        //    model.DDMMYYYY,
                        //    TYPEE = 0,
                        //};
                        //int test = con.Execute("DeleteManualAttendance", param: vonne, transaction: tran, commandType: CommandType.StoredProcedure);

                        var param = new
                        {
                            //PerID = 0,
                            model.EmpCod,
                            //TYPEE = 0,
                            model.Typee,
                            model.DDMMYYYY,
                            MachineName = "HRMApps",
                            model.CompanyID,
                            model.punch_time,
                            model.Latitude,
                            model.Longitude,
                            model.GPRSLocation,
                            model.AppType,
                            //model.ApplyTo,
                            //model.Remarks

                        };
                        int result = con.Execute("sp_SaveManualAttendence", param: param, transaction: tran, commandType: CommandType.StoredProcedure);

                        tran.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        return false;
                    }
                }
            }
        }

        public async Task<IEnumerable<IndEmpInOutModel>> GetIndividualInOutReport(string EmpCode, int CompanyID, string StartDate, string EndDate)
        {

            var ds = await db.QueryAsync<IndEmpInOutModel>("SP_API_GetIndInOutReport_NI", new
            {
                EmpCode,
                CompanyID,
                StartDate,
                EndDate
            }, commandType: CommandType.StoredProcedure);
            return ds.ToList();

        }


        public async Task<IEnumerable<AttendanceSummaryModel>> GetSummaryReport(string EmpCode, int PeriodID, int CompanyID)
        {
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                var peram = new
                {
                    EmpCode,
                    PeriodID,
                    CompanyID

                };


                List<AttendanceSummaryModel> ds = con.Query<AttendanceSummaryModel>("SP_API_GetAttendenceSummary", param: peram, commandType:CommandType.StoredProcedure).ToList();
                return ds;
            }

        }
        public async Task<IEnumerable<AttendanceApprovalModel>> GetAttendanceApproval(int CompanyID, string ApplyTo, string FromDate, string ToDate, int AnyDate)
        {
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                var peram = new
                {
                    CompanyID,
                    ApplyTo,
                    FromDate,
                    ToDate,
                    AnyDate

                };
                List<AttendanceApprovalModel> ds = con.Query<AttendanceApprovalModel>("sp_GetAttendanceWaitforApproveAll", param: peram, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return ds;
            }
        }

       
    }
}

        
    

