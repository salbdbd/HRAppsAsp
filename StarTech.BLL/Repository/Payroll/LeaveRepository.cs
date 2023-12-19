using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StarTech.Application.Interface.RepositoryInterface.HR;
using StarTech.Application.Interface.RepositoryInterface.Payroll;
using StarTech.Model.HR;
using StarTech.Model.HR.Attendance;
using StarTech.Model.Leave;
using StarTech.Model.Payroll;
using StarTech.Model.Payroll.Leave;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.BLL.Repository.Payroll
{
    public class LeaveRepository : ILeaveRepository
    {
        public IDbConnection db;
        public LeaveRepository()
        {
            db = new SqlConnection(Connection.ConnectionString());
        }
        public async Task<bool> SaveLeaveApplication(LeaveApplyModel ent)
        {
            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            
            var leaveEntryObj = new
            {
                ent.ID,
                ent.EmpCode,

                ent.StartDate,
                ent.EndDate,
                ent.ApplicationDate,
                ent.AccepteDuration,
                LTypedID = ent.LeaveTypedID,
                ent.AppType,
                ent.CompanyID,

                //ent.StartDate,
                //ent.EndDate,
                //ent.ApplicationDate,
                //ent.AccepteDuration,
                //ent.LeaveTypedID,
                //ent.AppType,
                //ent.CompanyID,

                ent.ApplyTo,
                ent.Reason,
                ent.EmgContructNo,
                ent.EmgAddress,
                //ent.UserName
            };
            //SP_API_AddEditLeaveApplication
            int rowaffect = await con.ExecuteAsync("SP_API_AddEditLeaveApplication", param: leaveEntryObj, commandType: CommandType.StoredProcedure);
            return rowaffect > 0;
            
        } 
        
        public async Task<IEnumerable<LeaveTypeModel>> GetLeaveType(int gradeValue, int gender)
        {
            var con = new SqlConnection(Connection.ConnectionString());
            var result = await con.QueryAsync<LeaveTypeModel>("sp_getLeaveType",param: new { Grade = gradeValue, gender },
            commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<LeaveReportModel>> GetLeaveReport(string Empcode, string StartDate, string EndDate, int CompanyID)
        {
            var con = new SqlConnection(Connection.ConnectionString());
            var peram = new
            {
                Empcode,
                StartDate,
                EndDate,
                CompanyID
            };
            var ds = await con.QueryAsync<LeaveReportModel>("SP_API_GetLeaveReport", param: peram, commandType:CommandType.StoredProcedure);
            return ds.ToList();
            
        }
        public async Task<IEnumerable<EmpGradeModel>> GetEmpGrade()
        {
            var con = new SqlConnection(Connection.ConnectionString());
            var ds = await con.QueryAsync<EmpGradeModel>("Usp_Api_GetEmpGrade",commandType:CommandType.StoredProcedure);
            return ds.ToList();
            
        }
        public async Task<bool> LeaveApply(LeaveApplyModel leaveApply)
        {
            var con = new SqlConnection(Connection.ConnectionString());
            
            var applyObj = new
            {
                leaveApply.ID,
                leaveApply.EmpCode,
                LSDate = leaveApply.StartDate,
                LEDate = leaveApply.EndDate,
                LADate = leaveApply.ApplicationDate,
                LTypedID = leaveApply.LeaveTypedID,
                leaveApply.AccepteDuration,
                leaveApply.UnAccepteDuration,
                referanceEmpcode =leaveApply.ReferanceEmpcode,
                leaveApply.Withpay,
                AppType=0,
                CompanyID=1,
                YYYYMMDD="",
                leaveApply.ApplyTo,
                leaveApply.Reason,
                leaveApply.EmgContructNo,
                leaveApply.EmgAddress,
                
            };
            int rowAffect = await con.ExecuteAsync("INSertupdateLeaveInfo_IN", param: applyObj, commandType: CommandType.StoredProcedure);
            return rowAffect > 0;
            

        }

        public async Task<IEnumerable<LeaveApplicationListModel>> GetLeaveApplicationList(int compId,string reportTo)
        {
            var con = new SqlConnection(Connection.ConnectionString());
            var peram = new
            {
                companyid = compId,
                ReportTo = reportTo
            };
            var applications = await con.QueryAsync<LeaveApplicationListModel>("sp_GetLeaveApproveForHR", param:peram , commandType: CommandType.StoredProcedure);
            return applications.ToList();  
        }

        public async Task<bool> UpdateLeaveStatus(ApprovedModel approve)
        {
            SqlConnection con = new SqlConnection(Connection.ConnectionString());
            var peram = new
            {
             
                approve.ID,
                approve.ReqFrom,
                approve.CompanyID,
                approve.ReqTo,
                approve.Remarks
            };
            int rowaffect = await con.ExecuteAsync("SP_API_UpdateLeaveStatus", param: peram, commandType: CommandType.StoredProcedure);
            return rowaffect > 0;
        }
    
        public async Task<IEnumerable<GetLeaveStatusModel>> GetLeaveStatus(string EmpCode, int CompanyID, int PeriodID)
        {
            var con = new SqlConnection(Connection.ConnectionString());
            var peram = new
            {
                EmpCode,
                CompanyID,
                PeriodID
            };
            var applications = await con.QueryAsync<GetLeaveStatusModel>("spRptLeaveStatusShow", param: peram, commandType: CommandType.StoredProcedure);
            return applications.ToList();
        }
  
        public async Task<List<LeaveApplyModel>> GetLeaveInfo(int compId, string empCode)
        {
            var con = new SqlConnection(Connection.ConnectionString());
            var peram = new
            {
                CompanyID = compId,
                EmpCode = empCode
            };
            var leaveInfo = await con.QueryAsync<LeaveApplyModel>("sp_LeaveInfo_List_NI", param: peram, commandType: CommandType.StoredProcedure);
            return leaveInfo.ToList();
        }
     
        public async Task<List<LeaveStatus>> getLeaveInfoStatus(string empCode, int companyId)
        {
            var con = new SqlConnection(Connection.ConnectionString());
            var peram = new
            {
                Type = 4,
                ID = 0,
                ReqFrom = "",
                ReqTo = empCode,
                CompanyID = companyId,
                Remarks = ""
            };
            var dataset = await con.QueryAsync<LeaveStatus>("INSertupdateLeaveInfoStatus", param: peram, commandType: CommandType.StoredProcedure);
            return dataset.ToList();    
        }

        public async Task<List<LeaveApplyViewModel>> GetWaitingLeaveForApprove(int compId, string year, string empCode)
        {


            var paramObj = new
            {
                CompanyID = compId,
                YEAR = year,
                EmpCode = empCode
            };


            var applications = await GetData<LeaveApplyViewModel, dynamic>("sp_GetLeaveWaitforApproveAll_NI", paramObj);

            return applications.ToList();



        }



        public async Task<bool> UpdateLeaveInfoStatus(LeaveInfoStatusModel lsi)
        {
            var paramObj = new
            {
                lsi.Type,
                ID = lsi.LeaveID,
                CompanyID = lsi.COmpanyID,
                lsi.ReqFrom,
                lsi.ReqTo,
                lsi.Remarks
            };
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                int rowAffect = await con.ExecuteAsync("INSertupdateLeaveInfoStatus", param: paramObj, commandType: CommandType.StoredProcedure);
                return rowAffect > 0;
            }
        }

        public async Task<bool> ApproveByHr(LeaveDetailsViewModel leaveDetailsVm)
        {
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        DateTime leaveDate = leaveDetailsVm.StartDate.Date;
                        while (leaveDate <= leaveDetailsVm.EndDate.Date)
                        {
                            string sql = $"INSERT INTO LeaveDetails (LeaveID, EmpCode, LeaveDate) VALUES({leaveDetailsVm.LeaveID}, '{leaveDetailsVm.EmpCode}', '{leaveDate.ToString("MM/dd/yyyy")}')";
                            await con.ExecuteAsync(sql, transaction: tran);
                            leaveDate = leaveDate.AddDays(1);
                        }

                        string sql2 = $"UPDATE leaveinfo SET AppType=1 , Grandtype =1  WHERE ID={leaveDetailsVm.LeaveID}";

                        await con.ExecuteAsync(sql2, transaction: tran);

                        string sql3 = $"UPDATE LeaveinfoStatus SET Status=1  WHERE LeaveID={leaveDetailsVm.LeaveID}";

                        await con.ExecuteAsync(sql3, transaction: tran);

                        tran.Commit();
                        return true;
                    }
                    catch (Exception err)
                    {
                        tran.Rollback();
                        throw new Exception(err.Message);
                    }
                }
            }
        }

        public async Task<List<LeaveApplyViewModel>> GetLeaveInfoForHrApprove(int compId, string ReportTo)
        {

           

            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                var applications = await con.QueryAsync<LeaveApplyViewModel>("sp_GetLeaveApproveForHR", param: new { companyid = compId, ReportTo =  ReportTo }, commandType: CommandType.StoredProcedure);
                return applications.ToList();
            }

        }

        public async Task<bool> CancelByHr(int leaveId)
        {
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                    try
                    {

                        string sql = $"UPDATE leaveinfo SET AppType=2 WHERE ID={leaveId}";

                        con.Execute(sql, transaction: tran);

                        string sql2 = $"UPDATE LeaveinfoStatus SET SET Status=3 WHERE ID={leaveId}";

                        con.Execute(sql2, transaction: tran);

                        tran.Commit();
                        return true;
                    }
                    catch (Exception err)
                    {
                        tran.Rollback();
                        throw new Exception(err.Message);
                    }
            }
        }

        public async Task<bool> UpdateByAuthority(UpdateByAuthorityModel leaveInfo)
        {
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                var paramObj = new
                {
                    leaveInfo.ID,
                    LSDate = leaveInfo.StartDate,
                    LEDate = leaveInfo.EndDate,
                    LADate = leaveInfo.ApplicationDate,
                    LTypedID = leaveInfo.LeaveTypedID,
                    leaveInfo.Withpay,
                    leaveInfo.AccepteDuration,
                    leaveInfo.UnAccepteDuration,
                    //leaveInfo.AuthorityEmpcode,
                    leaveInfo.CompanyID,
                    leaveInfo.Grandtype,
                    leaveInfo.AppType
                };
                int rowAffect = con.Execute("updateLeaveInfoDHEdite_NI", param: paramObj, commandType: CommandType.StoredProcedure);
                return rowAffect > 0;
            }
        }



        public async Task<IEnumerable<T>> GetData<T, P>(string SName, P parameters)
        {
            return await db.QueryAsync<T>(SName, parameters, commandType: CommandType.StoredProcedure);
        }

        

    }
}
     