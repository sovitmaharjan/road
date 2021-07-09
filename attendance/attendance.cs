using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace attendance
{

    public class attendance
    {
        int j;
        string query;

        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString);


        public string baseUrl()
        {

            return System.Configuration.ConfigurationManager.AppSettings["baseUrl"];
        }

        public string projectName()
        {

            return System.Configuration.ConfigurationManager.AppSettings["projectName"];
        }
        public string dbName()
        {

            return System.Configuration.ConfigurationManager.AppSettings["dbName"];
        }
        public string backupPath()
        {

            return System.Configuration.ConfigurationManager.AppSettings["backupPath"];
        }
        public string AdminName()
        {

            return System.Configuration.ConfigurationManager.AppSettings["AdminName"];
        }

        //************************** Admin Portal *************************
        public DataTable getAdmininfo()
        {
            string query = "select * from Tbl_admin_info";
            return queryFunction(query);
        }

        public DataTable saveAdminInfo(string companyName, string address1, string address2, string telephone1, string telephone2, string telephone3, string fax, string email1, string email2, string website, string
            fullName)
        {
            string query = "update Tbl_admin_info set "
                + "name = '" + companyName + "', "
                + "address1 = '" + address1 + "', "
                + "address2 = '" + address2 + "', "
                + "contact1 = '" + telephone1 + "', "
                + "contact2 = '" + telephone2 + "', "
                + "contact3 = '" + telephone3 + "', "
                + "fax = '" + fax + "', "
                + "email1 = '" + email1 + "', "
                + "email2 = '" + email2 + "', "
                + "website = '" + website + "', "
                + "fullName = '" + fullName + "' "
                + "where id = 1";
            return queryFunction(query);
        }
        public int mainMenu(int id, string titleName, string url, string iconName, int sortOrder, int subMenu, int status)
        {
            string query = "exec mainMenu '"
                + id + "', '"
                + titleName + "', '"
                + url + "', '"
                + iconName + "', '"
                + sortOrder + "', '"
                + subMenu + "', '"
                + status + "'";
            return intQueryFunction(query);
        }

        public DataTable getOrgInfo()
        {
            query = "SELECT Org_Address,Org_Address2,Org_Code,Org_Email,Org_Fax, Org_Name,Org_Phone,Org_Website, Org_Address + case when Org_Address2='' then '' else','+Org_Address2 end as Full_Address from Tbl_Org";
            return queryFunction(query);
        }

        public DataTable changestatus(int id)
        {
            string query = "UPDATE tblMenu set [status] = case when [status] = 0 then 1 when [status] = 1 then 0 end WHERE id = " + id;
            return queryFunction(query);
        }

        public DataTable getMenuById(int id)
        {
            string query = "SELECT * FROM  tblMenu WHERE id = " + id;
            return queryFunction(query);
        }

        //========================== begin global function ==========================
        public DataTable queryFunction(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                cmd.CommandTimeout = 500;
                dataAdapter.Fill(dataTable);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return dataTable;
        }

        public void voidQueryFunction(string query)
        {
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            con.Close();
        }

        public int intQueryFunction(string query)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int j = cmd.ExecuteNonQuery();
            con.Close();
            return j;
        }
        public DataTable getList(string tableName, string tableId, int paramId)
        {
            if (paramId == 0)
            {
                query = " SELECT * FROM " + @tableName;
            }
            else
            {
                query = " SELECT * FROM " + @tableName + " WHERE " + @tableId + " = " + @paramId;
            }
            return queryFunction(query);
        }
        //========================== End global function ==========================



        public DataTable getNotification(string status)
        {
            string query = "SELECT *,dbo.fn_GetNAMEBYID(EMP_ID) as emp_name FROM  tbl_notification WHERE date  >= DATEADD(day,-30, getdate()) and   date  <= getdate()";
            return queryFunction(query);
        }

        //==========================login==========================
        public DataTable getLoginData(string userId, string password)
        {

            string query = "select * from tbl_emp_off_info where login_id = '" + userId + "' and login_password = '" + password + "'";
            return queryFunction(query);
        }

        //==========================grade==========================
        public void password(

            int userId,
            string oldPassword,
            string newPassword
        )
        {
            string query = "update Tbl_Org_Grade set "
                    + "login_password = '" + newPassword + "' "
                    + "where GRADE_ID = '" + userId + "'";
            queryFunction(query);
        }

        //==========================userType==========================
        public DataTable userTypeList()
        {

            string query = "select * from tblUserType";
            return queryFunction(query);
        }

        public DataTable saveUserType(

            int id,
            string department,
            string dateTime
        )
        {

            string query = "exec saveUserType '"
                + id + "', '"
                + department + "', '"
                + dateTime + "'";
            return queryFunction(query);
        }

        public DataTable userType(int id)
        {

            string query = "select * from tblUserType where id =" + id;
            return queryFunction(query);
        }

        //==========================sidebar==========================
        public DataTable sidebarMenu()
        {

            string query = "select * from tblMenu where status = 1";
            return queryFunction(query);
        }

        public DataTable sidebarSubMenu1(int id)
        {

            string query = "select tblSubMenu1.id,tblSubMenu1.title,tblSubMenu1.url,tblSubMenu1.sortOrderNumber,tblSubMenu1.subMenu, tblMenu.title as Menu from tblSubMenu1 join tblMenu on tblSubMenu1.menuId = tblMenu.id where tblSubMenu1.menuId = " + id + "and tblSubMenu1.status = 1";
            return queryFunction(query);
        }

        public DataTable sidebarSubMenu2(int id)
        {

            string query = "select * from tblSubMenu2 where subMenu1Id = " + id + "and status = 1";
            return queryFunction(query);
        }

        public DataTable employeeList(int id)
        {

            string query;
            if (id == 0)
            {

                query = "select EMP_ID, EMP_FULLNAME from view_emp_info where status_id = 1";
            }
            else
            {

                query = "select EMP_ID, EMP_FULLNAME from view_emp_info where status_id = 1 and EMP_ID = " + id;
            }
            return queryFunction(query);
        }

        //==========================company==========================
        public DataTable company()
        {

            string query = "select * from tbl_org";
            return queryFunction(query);
        }

        public DataTable saveCompany(string companyName, string address1, string address2, string telephone, string fax, string email, string website)
        {

            string query = "update tbl_org set "
                + "Org_Name = '" + companyName + "', "
                + "Org_address = '" + address1 + "', "
                + "Org_address2 = '" + address2 + "', "
                + "Org_Phone = '" + telephone + "', "
                + "Org_Fax = '" + fax + "', "
                + "Org_Email = '" + email + "', "
                + "Org_Website = '" + website + "' "
                + "where Org_Id = 1";
            return queryFunction(query);
        }

        //==========================branch==========================
        public DataTable branch(int id)
        {

            string query;
            if (id == 0)
            {

                query = "select *, sta as status from tbl_comp_branch";
            }
            else
            {

                query = "select *, sta as status from tbl_comp_branch where BRANCH_ID =" + id;
            }
            return queryFunction(query);
        }

        public void manageBranch(

            int id,
            string branchCode,
            string branchName,
            int isOutBranch,
            int status
        )
        {
            string query;
            if (id == 0)
            {
                int branchId = Convert.ToInt32(queryFunction("SELECT max(BRANCH_ID)+1 FROM Tbl_Comp_Branch").Rows[0][0]);
                query = "insert into Tbl_Comp_Branch (BRANCH_ID, BRANCH_NAME, ISOUTBRANCH, serial_no, BRANCH_CODE, sta ) values('"
                    + branchId + "', '"
                    + branchName + "', '"
                    + isOutBranch + "', 0, '"
                    + branchCode + "', '"
                    + status + "')";
            }
            else
            {

                query = "update Tbl_Comp_Branch set "
                    + "BRANCH_CODE = '" + branchCode + "', "
                    + "ISOUTBRANCH = '" + isOutBranch + "', "
                    + "serial_no = '', "
                    + "BRANCH_NAME = '" + branchName + "', "
                    + "sta = '" + status + "' "
                    + "where BRANCH_ID = '" + id + "'";
            }
            queryFunction(query);
        }

        //==========================department==========================
        public DataTable department(int id)
        {

            string query;
            if (id == 0)
            {

                query = "Select * from Tbl_Org_Dept where LEVEL = 1";
            }
            else
            {

                query = "select * from Tbl_Org_Dept where BRANCH_ID =" + id;
            }
            return queryFunction(query);
        }

        public void saveDepartment(

            int branchId,
            string branchCode,
            string branchName,
            int serialNo,
            string dmlOption,
            int isOutBranch,
            int status
        )
        {

            string query = "exec proc_ManageBranch '"
                + branchId + "', '"
                + branchCode + "', '"
                + branchName + "', '"
                + serialNo + "', '"
                + dmlOption + "', '"
                + isOutBranch + "', '"
                + status + "'";
            queryFunction(query);
        }

        //==========================grade==========================
        public DataTable grade(int id)
        {

            string query;
            if (id == 0)
            {

                query = "Select *, sta as status from Tbl_Org_Grade";
            }
            else
            {

                query = "select *, sta as status from Tbl_Org_Grade where GRADE_ID =" + id;
            }
            return queryFunction(query);
        }

        public void manageGrade(

            int id,
            string gradeName,
            string gradeType,
            int status
        )
        {
            string query;
            if (id == 0)
            {

                query = "insert into Tbl_Org_Grade (GRADE_NAME,GRADE_TYPE,LEVEL,FLDTYPE,SERIAL_NO,sta) values('"
                    + gradeName + "', '"
                    + gradeType + "', '', '', '', '"
                    + status + "')";
            }
            else
            {

                query = "update Tbl_Org_Grade set "
                    + "GRADE_NAME = '" + gradeName + "', "
                    + "GRADE_TYPE = '" + gradeType + "', "
                    + "LEVEL = '', "
                    + "FLDTYPE = '', "
                    + "SERIAL_NO = '', "
                    + "sta = '" + status + "' "
                    + "where GRADE_ID = '" + id + "'";
            }
            queryFunction(query);
        }

        //==========================designation==========================
        public DataTable designation(int id)
        {

            string query;
            if (id == 0)
            {

                query = "select *, sta as status from Tbl_Org_Desg order by DEG_ID desc";
            }
            else
            {

                query = "select *, sta as status from Tbl_Org_Desg where DEG_ID =" + id;
            }
            return queryFunction(query);
        }

        public void manageDesignation(

            int id,
            string designationName,
            int status
        )
        {
            string query;
            if (id == 0)
            {
                query = "insert into Tbl_Org_Desg (DEG_PARENT, DEG_NAME, level, serial_no, sta) values ('Emp Designation', '" + designationName + "',0 ,(select (MAX(serial_no)+1) from Tbl_Org_Desg), " + status + ")";
            }
            else
            {
                query = "update tbl_org_desg set deg_name= '"+ designationName +"' where DEG_ID= " + id;
            }
            queryFunction(query);
        }

        //==========================leave==========================
        public DataTable leave(int id)
        {

            string query;
            if (id == 0)
            {

                query = "select t.*,(case when t.LEAVE_TYPE='1' then 'Expire Yearly' when t.LEAVE_TYPE='2' then 'Accumulative' else 'Service Period' end) as TYPE, t.sta as status from Tbl_Org_Leave_info t";
            }
            else
            {

                query = "select t.*,(case when t.LEAVE_TYPE='1' then 'Expire Yearly' when t.LEAVE_TYPE='2' then 'Accumulative' else 'Service Period' end) as TYPE, t.sta as status from Tbl_Org_Leave_info t where LEAVE_ID =" + id;
            }
            return queryFunction(query);
        }

        public void manageLeave(

            string leaveName,
            int leaveType,
            int daysAnually,
            int maxAccumulationDays,
            int monthlyEarning,
            int maxDaysAtATime,
            int cashable,
            int mustExhaustAllLeaves,
            int id,
            int status
        )
        {

            string query = "exec proc_AddUpdateLeave_web '"
                + leaveName + "', '"
                + leaveType + "', '"
                + daysAnually + "', '"
                + maxAccumulationDays + "', '"
                + monthlyEarning + "', '"
                + maxDaysAtATime + "', '"
                + cashable + "', '0', '"
                + mustExhaustAllLeaves + "', '"
                + id + "', '"
                + status + "'";
            queryFunction(query);
        }

        //==========================holiday==========================
        public DataTable holiday(int id)
        {

            string query;
            if (id == 0)
            {

                query = "select t.*,(case when t.holidayType='1' then 'Standard' when t.holidayType='2' then 'Specific' else 'Unofficial' end) as TYPE from Tbl_Org_Holiday t order by HOLIDAY_DATE ASC";
            }
            else
            {

                query = "select * from Tbl_Org_Holiday where HOLIDAY_ID =" + id;
            }
            return queryFunction(query);
        }

        public void manageHoliday(

            int id,
            string holidayEnglishDate,
            string holidayName,
            int holidayType,
            int femaleOnly,
            int holidayquantity,
            int status
        )
        {

            string query = "exec proc_ManageHolidayInfo '"
                + holidayName + "', '"
                + holidayEnglishDate + "', '"
                + holidayquantity + "', '"
                + holidayType + "', '"
                + id + "', '"
                + femaleOnly + "', '"
                + status + "'";
            queryFunction(query);
        }

        //==========================assign==========================
        public DataTable employeeByBranchId(int id)
        {

            string query;
            query = "select EMP_ID, EMP_FULLNAME from view_emp_info where status_id = 1 and BRANCH_ID = " + id;
            return queryFunction(query);
        }

        public void manageAssign(

            int id,
            string holidayEnglishDate,
            string holidayName,
            int holidayType,
            int femaleOnly,
            int holidayquantity,
            int status
        )
        {

            string query = "exec proc_ManageHolidayInfo '"
                + holidayName + "', '"
                + holidayEnglishDate + "', '"
                + holidayquantity + "', '"
                + holidayType + "', '"
                + id + "', '"
                + femaleOnly + "', '"
                + status + "'";
            queryFunction(query);
        }

        //==========================workHour==========================

        public DataTable workHourList(int id)
        {

            string query = "exec proc_WorkHourList '" + id + "'";
            return queryFunction(query);
        }
        public DataTable workHour(int id)
        {

            string query = "exec proc_WorkHourWithGroup '" + id + "'";
            return queryFunction(query);
        }

        public void manageWorkHour(

            int id,
            string groupName,
            string inTime,
            string inTime2,
            string outTime,
            string outTime2,
            string hour,
            string minute,
            string lunchTime,
            int nightShift,
            int defaultForAllWeekend,
            int status
        )
        {

            int aFlag = 0;
            string query = "exec proc_SaveWorkingShift_Group '"
                + aFlag + "', '"
                + id + "', '"
                + inTime + "', '"
                + inTime2 + "', '"
                + outTime + "', '"
                + outTime2 + "', '"
                + hour + "', '"
                + minute + "', '"
                + lunchTime + "', '"
                + nightShift + "', '"
                + defaultForAllWeekend + "', '"
                + status + "', '"
                + groupName + "'";
            queryFunction(query);
        }

        public void workHourStatus(int workId)
        {

            string query = "update Tbl_Org_Working_Hrs set [status] = case when [status] = 0 then 1 when [status] = 1 then 0 end where WORK_ID = " + workId;
            queryFunction(query);
        }

        public void workHourDelete(int workId)
        {

            string query = "update Tbl_Org_Working_Hrs set [status] = 3 where WORK_ID = " + workId;
            queryFunction(query);
        }


        //==========================permission==========================
        public DataTable menuList()
        {

            string query = "select * from tblMenu";
            return queryFunction(query);
        }

        public DataTable subMenu1(int id)
        {

            string query = "select * from tblSubMenu1 where menuId = " + id;
            return queryFunction(query);
        }

        public DataTable subMenu2(int id)
        {

            string query = "select * from tblSubMenu1 where id = " + id;
            return queryFunction(query);
        }

        public void deletePermission()
        {

            string query = "delete from tblPermission";
            queryFunction(query);
        }

        public void savePermission(

            string permission,
            string dateTime,
            int empId
        )
        {

            string query = "exec savePermission '"
                + permission + "', '"
                + dateTime + "', '"
                + empId + "'";
            queryFunction(query);
        }
        public DataTable getPageId(string page_name)
        {
            string query = "exec permisssionId '"
                + page_name + "'";
            return queryFunction(query);
        }

        public DataTable checkPermission(string page_id, string EMP_ID)
        {
            string query = "exec checkPermission '"

                + page_id + "', '"
                + EMP_ID + "'";
            return queryFunction(query);
        }

        public DataTable permission(int empId)
        {

            string query = "select * from tblPermission where empId =" + empId;
            return queryFunction(query);
        }

        public void imageSave(Byte[] bytes, int emp_id)
        {
            string sql = "insert into tbl_emp_info (EMP_ID, EMP_PHOTO) values (@emp_id, @bytes)";
            connection.Open();
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
            cmd.Parameters.AddWithValue("@bytes", bytes);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void imageUpdate(Byte[] bytes, int emp_id)
        {
            string sql = "Update tbl_emp_info set EMP_PHOTO = @bytes where EMP_ID =@emp_id";
            connection.Open();
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
            cmd.Parameters.AddWithValue("@bytes", bytes);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public DataSet LoadPhoto(int EMP_ID)
        {
            try
            {
                string sql = "Select EMP_PHOTO from Tbl_Emp_Info where EMP_ID=@EMP_ID";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda = new SqlDataAdapter(cmd);
                sda.TableMappings.Add("Table", "Photo");
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.Dispose();
                sda.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            finally
            {
                con.Close();
            }
        }


        //==========================LogHistory==========================//
        public DataTable logHistoryList(int empId, string fromDate, string toDate)
        {
            string query = "Select Distinct Emp_ID,indx, InOutMode, VerifyMode, LogTime, Cast(LogDate as DateTime) as LD, Cast(LogTime as DateTime) as LT   From Tbl_DeviceAttenLog Where EMp_ID=" + empId + " And LogDate Between '" + fromDate + "' And '" + toDate + "' ORDER BY LD, LT";
            return queryFunction(query);
        }
        public DataTable updateLogHistory(string indexId)
        {

            string query = "UPDATE Tbl_DeviceAttenLog set InOutMode = case when INOUTMODE = '1' THEN '0' when INOUTMODE = '0' then '1' end where indx=" + indexId;
            return queryFunction(query);
        }

        public DataTable getAttendanceLog(int empId, string date)
        {

            string query = "select * from Tbl_Emp_Attn_Log_General where EMP_ID = " + empId + " and TDATE = '" + date + "'";
            return queryFunction(query);
        }

        public DataTable updateAttendanceLog(string inTime, string inMode, string inRemarks, int empId, string date, string dateOut)
        {

            string query = "update Tbl_Emp_Attn_Log_General set OUTTIME = '" + inTime + "',TDATE_OUT = '" + dateOut + "', OUTMODE = '" + inMode + "', OUTREMARKS = '" + inRemarks + "' where EMP_ID = " + empId + " and COUNTER = 1 and TDATE = '" + date + "'";
            return queryFunction(query);
        }

        public DataTable deleteAttendanceLog(int empId, string date)
        {

            string query = "delete from Tbl_Emp_Attn_Log_General where EMP_ID = " + empId + " and COUNTER = 2 and TDATE = '" + date + "'";
            return queryFunction(query);
        }

        public int deleteEmployee(string EMP_ID)
        {
            string sql = "sp_DeleteEmployee";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", EMP_ID);
            int j = cmd.ExecuteNonQuery();
            con.Close();
            return j;
        }

        public DataTable deleteDeviceAttendanceLog(string time)
        {

            string query = "delete from Tbl_DeviceAttenLog where LogTime = '" + time + "'";
            return queryFunction(query);
        }

        //==========================forceAttendance==========================
        public DataTable getEmployeeDataById(int empId)
        {

            string query = "select * from view_emp_info where status_id = 1 and EMP_ID=" + empId;
            return queryFunction(query);
        }

        //==========================id==========================
        public DataTable getNextEmployeeId()
        {

            string query = "select EMP_ID, DEPT_ID, EMP_FULLNAME, DEPT_NAME, BRANCH_NAME from view_emp_info where status_id = 1 order by DEPT_ID asc, EMP_ID asc";
            return queryFunction(query);
        }

        public DataTable getPreviousEmployeeId()
        {

            string query = "select EMP_ID, DEPT_ID, EMP_FULLNAME, DEPT_NAME, BRANCH_NAME from view_emp_info where status_id = 1 order by DEPT_ID desc , EMP_ID desc";
            return queryFunction(query);
        }

        //==========================test==========================
        public DataTable test()
        {

            string query = "exec SP_DATEWISE_LEAVEBALANCE_SUMMARY '2019-11-01','2019-11-30','ACCOUNTS'";
            return queryFunction(query);
        }

        public DataTable getEmployeeListByDepartmentId(string id)
        {

            string query = "select EMP_ID, EMP_FULLNAME, DEPT_NAME from view_emp_info where DEPT_ID  IN (" + id + ") and STATUS_ID = 1 order by DEPT_NAME ASC";
            return queryFunction(query);
        }


        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================
        //=======================================================================================================

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString);


        public DataTable TestLogin(string username, string password)
        {
            string sql = "select * from tbl_userlist where LoginName=@username and Password=@password";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Login(string username, string password)
        {
            string sql = "select * from view_emp_info where EMP_USERID=@username and EMP_PASSWORD=@password and status_id = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //Authenticating User for login
        public DataTable Authenticate(string username, string password, int userTypeId)
        {
            string sql = "select * from view_emp_info where EMP_USERID=@username and EMP_PASSWORD=@password and userTypeId=@userTypeId and status_id = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@userTypeId", userTypeId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int updatePassword(int EMP_ID, string newPassword)
        {
            string sql = "update Tbl_Emp_off_Info set login_password=@newPassword  where login_id=@EMP_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable countBranch()
        {
            string sql = "select COUNT(BRANCH_ID) as Branch from Tbl_Comp_Branch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countInBranch()
        {
            string sql = "select COUNT(BRANCH_ID) as Branch from Tbl_Comp_Branch where ISOUTBRANCH = 0";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countOutBranch()
        {
            string sql = "select COUNT(BRANCH_ID) as Branch from Tbl_Comp_Branch where ISOUTBRANCH = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countDepartment()
        {
            string sql = "select COUNT(DEPT_ID) as dept from Tbl_Org_Dept where FLDTYPE='D' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countActiveDepartment()
        {
            string sql = "select COUNT(DEPT_ID) as dept from Tbl_Org_Dept where FLDTYPE='D' and sta = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countInactiveDepartment()
        {
            string sql = "select COUNT(DEPT_ID) as dept from Tbl_Org_Dept where FLDTYPE='D' and sta = 0";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countSection()
        {
            string sql = "select COUNT(DEPT_ID) as section from Tbl_Org_Dept where FLDTYPE='S' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countActiveSection()
        {
            string sql = "select COUNT(DEPT_ID) as section from Tbl_Org_Dept where FLDTYPE='S' and sta = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countInactiveSection()
        {
            string sql = "select COUNT(DEPT_ID) as section from Tbl_Org_Dept where FLDTYPE='S' and sta = 0";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countEmployee()
        {
            string sql = "select COUNT(EMP_ID) as emp from view_Emp_Info where STATUS_ID=1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countEmployeeMale()
        {
            string sql = "select COUNT(EMP_ID) as emp from view_Emp_Info where STATUS_ID=1 and EMP_GENDER='M'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countEmployeeFemale()
        {
            string sql = "select COUNT(EMP_ID) as emp from view_Emp_Info where STATUS_ID=1 and EMP_GENDER='F'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getEvents(int flag)
        {
            if (flag == 1)
            {
                DateTime tdate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                string sql = "Select EventId,Date,Title,Description,created_on from Tbl_Org_event where Date >= @tdate order by Date";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@tdate", tdate);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            else
            {
                string sql = "Select * from Tbl_Org_event order by Date";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

        public DataTable getOutstation()
        {
            string sql = "Select * from tbl_emp_outstation";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int saveOutstation(int VNO, int EMPID, int DEPARTMENTID, int DESIGNATIONID, string STATION, DateTime SDATE, DateTime EDATE, int DAYS, string PURPOSE, int APPROVED_BY, int user_id)
        {
            string sql = "proc_ManageBranch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VNO", VNO);
            cmd.Parameters.AddWithValue("@EMPID", EMPID);
            cmd.Parameters.AddWithValue("@DEPARTMENTID", DEPARTMENTID);
            cmd.Parameters.AddWithValue("@DESIGNATIONID", DESIGNATIONID);
            cmd.Parameters.AddWithValue("@STATION", STATION);
            cmd.Parameters.AddWithValue("@SDATE", SDATE);
            cmd.Parameters.AddWithValue("@EDATE", EDATE);
            cmd.Parameters.AddWithValue("@DAYS", DAYS);
            cmd.Parameters.AddWithValue("@PURPOSE", PURPOSE);
            cmd.Parameters.AddWithValue("@APPROVED_BY", APPROVED_BY);
            cmd.Parameters.AddWithValue("@user_id", user_id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable birthday()
        {
            string sql = "select EMP_ID,emp_Fullname, EMP_PHOTO, DEG_NAME, BRANCH_NAME, section_name, DEPT_NAME, EMP_DOB from view_emp_info where STATUS_ID = 1 and month(EMP_DOB) = month(getdate()) and day(EMP_DOB) >= day(getdate()) ORDER BY day(EMP_DOB)";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable contractPeriod()
        {
            string sql = "SELECT EMP_ID, emp_photo, emp_Fullname, EMP_PCOUNTRY, EMP_JOINDATE,(case when EMP_PCOUNTRY='India' then DATEADD(day,365, EMP_JOINDATE) else DATEADD(day,730, EMP_JOINDATE) end) as contractExpiryDate,DATEDIFF(day,  GETDATE(), (case when EMP_PCOUNTRY='India' then DATEADD(day,365, EMP_JOINDATE)else DATEADD(day,730, EMP_JOINDATE) end)) as Datedifference FROM view_emp_info where STATUS_ID = 1 and MODE_ID=3 ORDER BY Datedifference ASC";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //system setup//
        public DataTable GetAllOrg()
        {
            string sql = "select Org_Id,Org_Address,Org_Address2,Org_Code,Org_Email,Org_Fax,Org_Logo,Org_Name,Org_Phone,Org_Website,Org_Prefix, Org_Address + case when Org_Address2='' then '' else','+Org_Address2 end as Full_Address from Tbl_Org";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int CreateCompany(string Org_Name, string Org_Address, string Org_Address2, string Org_Phone, string Org_Fax, string Org_Email, string Org_Website)
        {
            string sql = "insert into Tbl_Org (Org_Name,Org_Address,Org_Address2,Org_Phone,Org_Fax,Org_Email,Org_Website) values(@Org_Name,@Org_Address,@Org_Address2, @Org_Phone,@Org_Fax,@Org_Email,@Org_Website)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Org_Name", Org_Name);
            cmd.Parameters.AddWithValue("@Org_Address", Org_Address);
            cmd.Parameters.AddWithValue("@Org_Address2", Org_Address2);
            cmd.Parameters.AddWithValue("@Org_Phone", Org_Phone);
            cmd.Parameters.AddWithValue("@Org_Fax", Org_Fax);
            cmd.Parameters.AddWithValue("@Org_Email", Org_Email);
            cmd.Parameters.AddWithValue("@Org_Website", Org_Website);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable GetOrgbyOrgId(int Org_Id)
        {
            string sql = "select *from Tbl_Org  where Org_Id=@Org_Id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Org_Id", Org_Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int UpdateCompany(string Org_Name, string Org_Address, string Org_Address2, string Org_Phone, string Org_Fax, string Org_Email, string Org_Website, int Org_Id)
        {
            string sql = "update Tbl_Org set Org_Name=@Org_Name, Org_Address=@Org_Address, Org_Address2=@Org_Address2,Org_Phone=@Org_Phone,Org_Fax=@Org_Fax,Org_Email=@Org_Email,Org_Website=@Org_Website where Org_Id=@Org_Id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Org_Name", Org_Name);
            cmd.Parameters.AddWithValue("@Org_Address", Org_Address);
            cmd.Parameters.AddWithValue("@Org_Address2", Org_Address2);
            cmd.Parameters.AddWithValue("@Org_Phone", Org_Phone);
            cmd.Parameters.AddWithValue("@Org_Fax", Org_Fax);
            cmd.Parameters.AddWithValue("@Org_Email", Org_Email);
            cmd.Parameters.AddWithValue("@Org_Website", Org_Website);
            cmd.Parameters.AddWithValue("@Org_Id", Org_Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable getBranch()
        {
            string sql = "Select BRANCH_ID, BRANCH_NAME, BRANCH_CODE, ISOUTBRANCH, status from tbl_comp_branch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int CreateBranch(string BRANCH_CODE, int ISOUTBRANCH, int serial_no, string BRANCH_NAME, int status, string BType)
        {
            con.Open();
            string sql = "insert into Tbl_Comp_Branch (BRANCH_CODE, ISOUTBRANCH, serial_no, BRANCH_NAME, status ) values(@BRANCH_CODE, @ISOUTBRANCH, @serial_no, @BRANCH_NAME, @status)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", BRANCH_CODE);
            cmd.Parameters.AddWithValue("@ISOUTBRANCH", ISOUTBRANCH);
            cmd.Parameters.AddWithValue("@serial_no", serial_no);
            cmd.Parameters.AddWithValue("@BRANCH_NAME", BRANCH_NAME);
            cmd.Parameters.AddWithValue("@status", status);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public DataTable GetbranchbybranchId(int branchid)
        {

            string sql = "select * from Tbl_Comp_Branch where BRANCH_ID=@branchid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@branchid", branchid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public void UpdateBranchSetup(string BRANCH_NAME, int ISOUTBRANCH, int serial_no, string BRANCH_CODE, int status, int branchid)
        {
            con.Open();
            string sql = "update Tbl_Comp_Branch set BRANCH_NAME=@BRANCH_NAME, ISOUTBRANCH=@ISOUTBRANCH, serial_no=@serial_no,BRANCH_CODE=@BRANCH_CODE,status=@status where BRANCH_ID=@branchid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@BRANCH_NAME", BRANCH_NAME);
            cmd.Parameters.AddWithValue("@ISOUTBRANCH", ISOUTBRANCH);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", BRANCH_CODE);
            cmd.Parameters.AddWithValue("@serial_no", serial_no);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@branchid", branchid);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable getDepartmentInfo(string DEPT_NAME)
        {
            string sql = "select * from Tbl_Org_Dept where DEPT_PARENT = @DEPT_NAME";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@DEPT_NAME", DEPT_NAME);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void AddDepartment(string deptparent, string deptname, int FLAG, string selectednode, int status)
        {
            string sql = "Proc_managedept";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deptparent", deptparent);
            cmd.Parameters.AddWithValue("@deptname", deptname);
            cmd.Parameters.AddWithValue("@FLAG", FLAG);
            cmd.Parameters.AddWithValue("@selectednode", selectednode);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable GetdepartmentbydepartmentId(int departmentid)
        {
            string sql = "select *from Tbl_Org_Dept where DEPT_ID=@departmentid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@departmentid", departmentid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getGradeList()
        {
            string sql = "select * from Tbl_Org_Grade";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void CreateGrade(string GRADE_NAME, string GRADE_TYPE, int LEVEL, string FLDTYPE, int SERIAL_NO, int status)
        {
            con.Open();
            string sql = "insert into Tbl_Org_Grade (GRADE_NAME,GRADE_TYPE,LEVEL,FLDTYPE,SERIAL_NO,status) values(@GRADE_NAME,@GRADE_TYPE,@LEVEL,@FLDTYPE,@SERIAL_NO,@status)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@GRADE_NAME", GRADE_NAME);
            cmd.Parameters.AddWithValue("@GRADE_TYPE", GRADE_TYPE);
            cmd.Parameters.AddWithValue("@LEVEL", LEVEL);
            cmd.Parameters.AddWithValue("@FLDTYPE", FLDTYPE);
            cmd.Parameters.AddWithValue("@SERIAL_NO", SERIAL_NO);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateGrade(string GRADE_NAME, string GRADE_TYPE, int LEVEL, string FLDTYPE, int SERIAL_NO, int sta, int gradeid)
        {
            con.Open();
            string sql = "update Tbl_Org_Grade set GRADE_NAME=@GRADE_NAME, GRADE_TYPE=@GRADE_TYPE, LEVEL=@LEVEL,FLDTYPE=@FLDTYPE,SERIAL_NO=@SERIAL_NO,sta=@sta where GRADE_ID=@gradeid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@GRADE_NAME", GRADE_NAME);
            cmd.Parameters.AddWithValue("@GRADE_TYPE", GRADE_TYPE);
            cmd.Parameters.AddWithValue("@LEVEL", LEVEL);
            cmd.Parameters.AddWithValue("@FLDTYPE", FLDTYPE);
            cmd.Parameters.AddWithValue("@SERIAL_NO", SERIAL_NO);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.Parameters.AddWithValue("@gradeid", gradeid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable GetGradebygradeId(int gradeid)
        {
            string sql = "select *from Tbl_Org_Grade where GRADE_ID=@gradeid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@gradeid", gradeid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable getDesignationList()
        {
            string sql = "select * from Tbl_Org_Desg order by DEG_ID desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Designation(string DEG_NAME, int DEG_ID, int Status)
        {
            con.Open();
            string sql = "proc_managedeg";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DEG_NAME", DEG_NAME);
            cmd.Parameters.AddWithValue("@DEG_ID", DEG_ID);
            cmd.Parameters.AddWithValue("@Status", Status);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetDesignationbyDesignationId(int DEG_ID)
        {
            string sql = "select *from Tbl_Org_Desg where DEG_ID=@DEG_ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@DEG_ID", DEG_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable getLeaveSetup()
        {
            string sql = "select t.*,(case when t.LEAVE_TYPE='1' then 'Expire Yearly' when t.LEAVE_TYPE='2' then 'Accumulative' else 'Service Period' end) as TYPE from Tbl_Org_Leave_info t";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int SaveLeave(string leavename, int leavetype, int leavedays, int maxacc, int monthly, int maxdays, int iscashable, int service, int must_all_leave, int leave_id, int status)
        {
            string sql = "proc_AddUpdateLeave_web";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@leavename", leavename);
            cmd.Parameters.AddWithValue("@leavetype", leavetype);
            cmd.Parameters.AddWithValue("@leavedays", leavedays);
            cmd.Parameters.AddWithValue("@maxacc", maxacc);
            cmd.Parameters.AddWithValue("@monthly", monthly);
            cmd.Parameters.AddWithValue("@maxdays", maxdays);
            cmd.Parameters.AddWithValue("@iscashable", iscashable);
            cmd.Parameters.AddWithValue("@service", service);
            cmd.Parameters.AddWithValue("@must_all_leave", must_all_leave);
            cmd.Parameters.AddWithValue("@leave_id", leave_id);
            cmd.Parameters.AddWithValue("@Status", status);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int UpdateLeaveSetup(string LEAVE_NAME, int LEAVE_DAYS, int LEAVE_TYPE, int LEAVE_MAX, int ISPAIDLEAVE, int MAX_DAYS_AT_A_TIME, int ISCashable, int service_period, int mustexhaustotherleaves, int LEAVE_PREFIXING, int sta, int others, string Leave_Category, int leaveid)
        {
            string sql = "proc_SaveBranchwiseHoliday";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LEAVE_NAME", LEAVE_NAME);
            cmd.Parameters.AddWithValue("@LEAVE_DAYS", LEAVE_DAYS);
            cmd.Parameters.AddWithValue("@LEAVE_TYPE", LEAVE_TYPE);
            cmd.Parameters.AddWithValue("@LEAVE_MAX", LEAVE_MAX);
            cmd.Parameters.AddWithValue("@ISPAIDLEAVE", ISPAIDLEAVE);
            cmd.Parameters.AddWithValue("@MAX_DAYS_AT_A_TIME", MAX_DAYS_AT_A_TIME);
            cmd.Parameters.AddWithValue("@ISCashable", ISCashable);
            cmd.Parameters.AddWithValue("@service_period", service_period);
            cmd.Parameters.AddWithValue("@mustexhaustotherleaves", mustexhaustotherleaves);
            cmd.Parameters.AddWithValue("@LEAVE_PREFIXING", 0);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.Parameters.AddWithValue("@others", others);
            cmd.Parameters.AddWithValue("@Leave_Category", Leave_Category);
            cmd.Parameters.AddWithValue("@leaveid", leaveid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable getHolidayList()
        {
            string sql = "select t.*,(case when t.holidayType='1' then 'Standard' when t.holidayType='2' then 'Specific' else 'Unofficial' end) as TYPE from Tbl_Org_Holiday t";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetAllHoliday(int HOLIDAY_ID)
        {
            string sql = "select HOLIDAY_NAME,HOLIDAY_DATE,HOLIDAY_QTY,holidayType,Female_Only from Tbl_Org_Holiday where HOLIDAY_ID=@HOLIDAY_ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@HOLIDAY_ID", HOLIDAY_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable getEmployeeIdByGender(int DeptID, int flag)
        {
            string sql;
            SqlDataAdapter da;
            SqlCommand cmd;
            if (flag == 0)//Male
            {
                sql = "select emp_fullname,EMP_ID from view_Emp_Info where STATUS_ID = 1 and DEPT_ID=@dept";
                con.Open();
                cmd = new SqlCommand(sql, con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@dept", DeptID);
            }
            else//Female
            {

                sql = "select emp_fullname,EMP_ID from view_Emp_Info where STATUS_ID = 1 and DEPT_ID=@dept and GENDER=@Gender";
                con.Open();
                cmd = new SqlCommand(sql, con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@dept", DeptID);
                cmd.Parameters.AddWithValue("@Gender", "Female");
            }

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int HolidayAssign(string flag, string OldHoliday, string holidayname, DateTime holidaydate, string holidaytype, string remark, int branchid, int checkflag, int HOLIDAYID, int EMP_ID)
        {
            string sql = "proc_SaveBranchwiseHoliday";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.Parameters.AddWithValue("@OldHoliday", OldHoliday);
            cmd.Parameters.AddWithValue("@holidayname", holidayname);
            cmd.Parameters.AddWithValue("@holidaydate", holidaydate);
            cmd.Parameters.AddWithValue("@holidaytype", holidaytype);
            cmd.Parameters.AddWithValue("@remark", remark);
            cmd.Parameters.AddWithValue("@branchid", branchid);
            cmd.Parameters.AddWithValue("@checkflag", checkflag);
            cmd.Parameters.AddWithValue("@HOLIDAYID", HOLIDAYID);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public void Holiday(int holid, string HolidayName, DateTime HolidayDate, int Qty, int holidayType, int status, int Female_Only)
        {
            con.Open();
            string sql = "proc_ManageHolidayInfo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@holid", holid);
            cmd.Parameters.AddWithValue("@HolidayName", HolidayName);
            cmd.Parameters.AddWithValue("@HolidayDate", HolidayDate);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Type", holidayType);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@Female_Only", Female_Only);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable GetHolidaysetupbyholidayId(int holidayid)
        {
            string sql = "select *from Tbl_Org_Holiday where HOLIDAY_ID=@holidayid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@holidayid", holidayid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable MgmtWorkingHour(int group_id)
        {
            con.Open();
            string sql = "proc_WorkHourWithGroup";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@groupid", 0);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void WorkingHour(int AFlag, int ID, string instart, string inend, string outstart, string outend, int hour, int minute, int lunch, int Shift, int DefaultWorkId, int sta, string GroupName)
        {
            con.Open();
            string sql = "proc_SaveWorkingShift_Group";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AFlag", 0);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@instart", instart);
            cmd.Parameters.AddWithValue("@inend", inend);
            cmd.Parameters.AddWithValue("@outstart", outstart);
            cmd.Parameters.AddWithValue("@outend", outend);
            cmd.Parameters.AddWithValue("@hour", hour);
            cmd.Parameters.AddWithValue("@minute", minute);
            cmd.Parameters.AddWithValue("@lunch", lunch);
            cmd.Parameters.AddWithValue("@Shift", Shift);
            cmd.Parameters.AddWithValue("@DefaultWorkId", DefaultWorkId);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.Parameters.AddWithValue("@GroupName", GroupName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int ManageWeekend(int EmpId, DateTime StartDate, DateTime EndDate, DateTime CurDate, int Flag)
        {
            con.Open();
            string sql = "proc_ManageWeekend";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@CurDate", CurDate);
            cmd.Parameters.AddWithValue("@Flag", Flag);
            int j = cmd.ExecuteNonQuery();
            con.Close();
            return j;
        }
        public int ManageOpenRoosteroff(int EmpId, DateTime date, int groupid)
        {
            con.Open();
            string sql = "proc_ManageOpenRoster_off";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@groupid", groupid);
            int k = cmd.ExecuteNonQuery();
            con.Close();
            return k;
        }
        public int ManageOpenRooster(int empid, DateTime date, int groupid)
        {
            con.Open();
            string sql = "proc_ManageOpenRoster";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@groupid", groupid);
            int j = cmd.ExecuteNonQuery();
            con.Close();
            return j;
        }

        public DataTable getweekday(DateTime start_date, DateTime end_date)
        {
            string sql = "proc_getWeekData";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date_start", start_date);
            cmd.Parameters.AddWithValue("@date_end", end_date);
            cmd.CommandTimeout = 500;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //************** Human Resources Management*******************//
        public DataTable getAllEmployeesList()
        {
            try
            {
                string sql = "select * from view_emp_info order by EMP_ID asc";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getNationality()
        {
            string sql = "SELECT * from Tbl_Emp_Nationality";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getBloodGroup()
        {
            string sql = "SELECT * from Tbl_Blood_Group";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getSalutationList()
        {
            string sql = "SELECT id, salutation from Tbl_Emp_Salutation";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getDesignation()
        {
            string sql = "SELECT DEG_ID, DEG_NAME from Tbl_Org_Desg";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetUserType()
        {
            string sql = "select * from Tbl_UserTypes where status = 1 and  id not in (1)";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getStateList()
        {
            string sql = "select StateName,StateId from Tbl_Org_State";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getBloodgroup()
        {
            string sql = "select * from tbl_blood_group";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getUserTypeList(int UserTypeId)
        {
            string sql = "select emp_Fullname, EMP_ID, DEG_NAME, DEPT_NAME, BRANCH_NAME,STATUS_NAME,MODE_NAME from view_emp_info where UserTypeId = @UserTypeId and status_id = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@UserTypeId", UserTypeId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getHODList()
        {
            string sql = "SELECT EMP_ID, emp_Fullname from view_emp_info where usertypeid = 3 and status_id = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getHODbyID(int emp_id)
        {
            string sql = "SELECT HOD_ID, HOD_NAME from view_emp_info where EMP_ID =@emp_id and status_id = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDistrictList()
        {
            string sql = "select DistrictId,DistrictName,StateId from  Tbl_org_state_district  order by DistrictName asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getReligionList()
        {
            string sql = "select RELIGION_ID,RELIGION_NAME from Tbl_Org_Religion order by RELIGION_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getDistrict(int StateId)
        {
            string sql = "select distinct DistrictId, DistrictName,StateId from Tbl_org_state_district where StateId=@StateId";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@StateId", StateId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getEthnicityList()
        {
            string sql = "select * from Tbl_emp_Ethnicity";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool CheckDuplicateEmpId(string EMP_ID)
        {

            con.Open();
            string sql = "select 1 from Tbl_Emp_Info where EMP_ID=@EMP_ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            SqlDataReader reader = cmd.ExecuteReader();

            int cn = 0;
            while (reader.Read())
            {
                cn = int.Parse(reader.GetValue(0).ToString());

            }
            cmd.Dispose();
            con.Close();
            if (cn == 1)
                return true;
            return false;


        }
        public DataTable getMaxPid()
        {
            con.Open();
            string sql = "select (MAX(PID)+1) from Tbl_Emp_DBID";
            SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void insertedu(int pid, string schoolCollege, string board, string division, string percentage, string date, string degree)
        {
            con.Open();
            string sql = " insert into tblEmpEducation (pid,schoolCollege,board,division,percentage,date,degree) values(@pid,@schoolCollege,@board,@division,@percentage,@date,@degree)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@schoolCollege", schoolCollege);
            cmd.Parameters.AddWithValue("@board", board);
            cmd.Parameters.AddWithValue("@division", division);
            cmd.Parameters.AddWithValue("@percentage", percentage);
            cmd.Parameters.AddWithValue("date", date);
            cmd.Parameters.AddWithValue("@degree", degree);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateEdu(int pid)
        {
            con.Open();
            string sql = "delete from tblEmpEducation where pid=@pid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateTraining(int pid)
        {
            con.Open();
            string sql = "delete from tblEmpTraining where pid=@pid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.ExecuteNonQuery();
        }

        public void updateWorkExp(int pid)
        {
            con.Open();
            string sql = "delete from tblEmpJobExperience where pid=@pid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable getBankBranch(int Bank_Id)
        {
            string sql = "select * from Tbl_Bank_Branch where Bank_Id=@Bank_Id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Bank_Id", Bank_Id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetbankbranchbyId(int Branch_Id)
        {
            string sql = "select *from Tbl_Bank_Branch where Branch_Id=@Branch_Id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Branch_Id", Branch_Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void CreateEmpGeneralInfo(
            string EMP_ID,
            string EMP_PHOTO,
            string EMP_TITLE,
            string FNAME,
            string MNAME,
            string LNAME,
            DateTime DATE,
            DateTime JOINDATE,
            string GENDER,
            string MSTATUS,
            string Mobile,
            string Telephone,
            string emp_pcountry,
            string emp_bloodGroup,
            string mName,
            string fName,
            string sName,
            string gfName,
            string c1Name,
            string c2Name,
            string Pstate,
            string PDistrict,
            string Pstreet,
            string PMUN,
            string PWard,
            string PTole,
            string Tstate,
            string TDistrict,
            string Tstreet,
            string TMUN,
            string TWard,
            string TTole,
            string docType,
            string cNumber,
            string cDateIssued,
            string cPlaceIssued,
            string pNumber,
            string PIssued,
            string pIDate,
            string pEDate,
            string pEmail

            )
        {
            con.Open();
            string sql = "proc_manage_Emp_info";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@EMP_PHOTO", EMP_PHOTO);
            cmd.Parameters.AddWithValue("@EMP_TITLE", EMP_TITLE);
            cmd.Parameters.AddWithValue("@FNAME", FNAME);
            cmd.Parameters.AddWithValue("@MNAME", MNAME);
            cmd.Parameters.AddWithValue("@LNAME", LNAME);
            cmd.Parameters.AddWithValue("@DATE", DATE);
            cmd.Parameters.AddWithValue("@JOINDATE", JOINDATE);
            cmd.Parameters.AddWithValue("@GENDER", GENDER);
            cmd.Parameters.AddWithValue("@MSTATUS", MSTATUS);
            cmd.Parameters.AddWithValue("@MOBILE", Mobile);
            cmd.Parameters.AddWithValue("@PHONE", Telephone);
            cmd.Parameters.AddWithValue("@EMP_PCOUNTRY", emp_pcountry);
            cmd.Parameters.AddWithValue("@BLOODGROUP", emp_bloodGroup);
            cmd.Parameters.AddWithValue("@Mother_Name", mName);
            cmd.Parameters.AddWithValue("@Father_Name", fName);
            cmd.Parameters.AddWithValue("@Spouse_Name", sName);
            cmd.Parameters.AddWithValue("@Grandfather_Name", gfName);
            cmd.Parameters.AddWithValue("@Children_Name1", c1Name);
            cmd.Parameters.AddWithValue("@Children_Name2", c2Name);
            cmd.Parameters.AddWithValue("@PZONE ", Pstate);
            cmd.Parameters.AddWithValue("@PDISTRICT ", PDistrict);
            cmd.Parameters.AddWithValue("@PSTREET", Pstreet);
            cmd.Parameters.AddWithValue("@PVDC_municipality ", PMUN);
            cmd.Parameters.AddWithValue("@PWard_Number", PWard);
            cmd.Parameters.AddWithValue("@PVillage_Tole", PTole);
            cmd.Parameters.AddWithValue("@TZONE", Tstate);
            cmd.Parameters.AddWithValue("@TDISTRICT", TDistrict);
            cmd.Parameters.AddWithValue("@TSTREET", Tstreet);
            cmd.Parameters.AddWithValue("@TVDC_municipality", TMUN);
            cmd.Parameters.AddWithValue("@TWard_Number", TWard);
            cmd.Parameters.AddWithValue("@TVillage_Tole", TTole);
            cmd.Parameters.AddWithValue("@docType ", docType);
            cmd.Parameters.AddWithValue("@CITIZENNO", cNumber);
            cmd.Parameters.AddWithValue("@CITIZENDATE", cDateIssued);
            cmd.Parameters.AddWithValue("@CitizenshipDistrict", cPlaceIssued);
            cmd.Parameters.AddWithValue("@Passport_Number", pNumber);
            cmd.Parameters.AddWithValue("@Passport_ISSUED", PIssued);
            cmd.Parameters.AddWithValue("@Passport_ISSUED_DATE", pIDate);
            cmd.Parameters.AddWithValue("@Passport_EXPIRY_DATE", pEDate);
            cmd.Parameters.AddWithValue("@EMAIL", pEmail);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertEmpRelativeInfo(string EMP_ID, string NAME, string ADDRESS, string RELATION, string CONTACT, string IMAGE, string MOBILE)
        {
            con.Open();
            string sql = "proc_manage_relative_info";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@NAME", NAME);
            cmd.Parameters.AddWithValue("@ADDRESS", ADDRESS);
            cmd.Parameters.AddWithValue("@RELATION", RELATION);
            cmd.Parameters.AddWithValue("@CONTACT ", CONTACT);

            cmd.Parameters.AddWithValue("@IMAGE", IMAGE);
            cmd.Parameters.AddWithValue("@MOBILE ", MOBILE);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void CreateOfficialInfo(int deg_id, int HOD_ID, int mode_id, int dept_id, int branch_id, int status_id, int Grade_id, int emp_id, int PID, int usertypeid, int login_id, string login_password, string pf, string cit, string ss, string pan, string bankAc, string offEmail, int webLogin)
        {
            con.Open();
            string sql = "proc_manage_Official_info";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deg_id", deg_id);
            cmd.Parameters.AddWithValue("@HOD_ID", HOD_ID);
            cmd.Parameters.AddWithValue("@mode_id", mode_id);
            cmd.Parameters.AddWithValue("@dept_id", dept_id);
            cmd.Parameters.AddWithValue("@branch_id", branch_id);
            cmd.Parameters.AddWithValue("@status_id", status_id);
            cmd.Parameters.AddWithValue("@Grade_id", Grade_id);
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@usertypeid", usertypeid);
            cmd.Parameters.AddWithValue("@login_id", login_id);
            cmd.Parameters.AddWithValue("@login_password", login_password);
            cmd.Parameters.AddWithValue("@pf", pf);
            cmd.Parameters.AddWithValue("@cit", cit);
            cmd.Parameters.AddWithValue("@ss", ss);
            cmd.Parameters.AddWithValue("@pan", pan);
            cmd.Parameters.AddWithValue("@bankAc", bankAc);
            cmd.Parameters.AddWithValue("@offEmail", offEmail);
            cmd.Parameters.AddWithValue("@webLogin", webLogin);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void insertTraining(int pid, string organization, string place, string startDate, string endDate, string Title, string Days)
        {
            con.Open();
            string sql = "insert into tblEmpTraining (pid,organization,place,startDate,endDate,Title,Days) values(@pid,@organization,@place,@startDate,@endDate,@Title,@Days)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@organization", organization);
            cmd.Parameters.AddWithValue("@place", place);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Days", Days);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void insertJobExperience(int pid, string organization, string designation, string startDate, string endDate, string Salary, string Contact)
        {
            con.Open();
            string sql = "insert into tblEmpJobExperience (pid,organization,designation,startDate,endDate,Salary,Contact) values(@pid,@organization,@designation,@startDate,@endDate,@Salary,@Contact)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@organization", organization);
            cmd.Parameters.AddWithValue("@designation", designation);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            cmd.Parameters.AddWithValue("@Salary", Salary);
            cmd.Parameters.AddWithValue("@Contact", Contact);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void insertLeaveManagement(int PID, int Leaveid, int Days, int MaxDays, int flag)
        {
            con.Open();
            string sql = "Proc_Insert_Tbl_Emp_Leave_info";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", Leaveid);
            cmd.Parameters.AddWithValue("@Days", Days);
            cmd.Parameters.AddWithValue("@MaxDays", MaxDays);
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void CreateOfcInfo(DateTime date, string EMP_ID, string PID)
        {
            con.Open();
            string sql = "Proc_Insert_Tbl_DBID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable getPromotionList()
        {
            try
            {

                string sql = "select * from view_emp_promotion_details  where  IsCurrent=1";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EmployeePromotion(string EMP_ID, DateTime date, string PromotionalTitle, int FNC_ID, int DEG_ID, int Iscurrent, int P_FNC_ID, int P_DEG_ID, int Old_Salary, int New_Salary)
        {
            try
            {
                con.Open();
                string sql = "Proc_Promotion_Info";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@PromotionalTitle", PromotionalTitle);
                cmd.Parameters.AddWithValue("@FNC_ID", FNC_ID);
                cmd.Parameters.AddWithValue("@DEG_ID", DEG_ID);
                cmd.Parameters.AddWithValue("@Iscurrent", Iscurrent);
                cmd.Parameters.AddWithValue("@P_FNC_ID", P_FNC_ID);
                cmd.Parameters.AddWithValue("@P_DEG_ID", P_DEG_ID);
                cmd.Parameters.AddWithValue("@Old_Salary", Old_Salary);
                cmd.Parameters.AddWithValue("@New_Salary", New_Salary);
                int j = cmd.ExecuteNonQuery();
                con.Close();
                return j;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getTransferList()
        {
            try
            {
                string sql = "select * from view_emp_transfer_details where isCurrent = 1";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CreateTransfer(DateTime tDate, string Trans_desc, int Iscurrent, string Eid, int Branch_ID_To, int DEPT_ID, int Section_ID_To, int Function_ID_To, int Branch_id_from, int Section_id_From, int FNC_ID_From)
        {
            try
            {
                con.Open();
                string sql = "Proc_Transfer_Info";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tDate", tDate);
                cmd.Parameters.AddWithValue("@Trans_desc", Trans_desc);
                cmd.Parameters.AddWithValue("@Iscurrent", Iscurrent);
                cmd.Parameters.AddWithValue("@Eid", Eid);
                cmd.Parameters.AddWithValue("@Branch_ID_To", Branch_ID_To);
                cmd.Parameters.AddWithValue("@DEPT_ID", DEPT_ID);
                cmd.Parameters.AddWithValue("@Section_ID_To", Section_ID_To);
                cmd.Parameters.AddWithValue("@Function_ID_To", Function_ID_To);
                cmd.Parameters.AddWithValue("@Branch_id_from", Branch_id_from);
                cmd.Parameters.AddWithValue("@Section_id_From", Section_id_From);
                cmd.Parameters.AddWithValue("@FNC_ID_From", FNC_ID_From);
                int j = cmd.ExecuteNonQuery();
                con.Close();
                return j;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getDepartment()
        {
            string sql = "Select DEPT_ID,DEPT_NAME, DEPT_PARENT, sta as status from Tbl_Org_Dept where LEVEL=1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getSupervisorDepartment(int sessionUserId)
        {
            string sql = "Select DEPT_ID,DEPT_NAME from view_emp_info where EMP_ID =" + sessionUserId;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getDeptName()
        {
            string sql = "Select DEPT_ID,DEPT_NAME, DEPT_PARENT, sta from Tbl_Org_Dept where LEVEL=2";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetBank()
        {
            string sql = "select * from Tbl_Bank_Info";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getPid(int EMP_ID)
        {
            con.Open();
            string sql = "select * from Tbl_Emp_DBID where EMP_ID=@EMP_ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Education(int PID)
        {
            string sql = "select * from tblEmpEducation  where PID=@PID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Training(int PID)
        {
            string sql = "select * from tblEmpTraining  where PID=@PID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable jobexperience(int PID)
        {
            string sql = "select * from tblEmpJobExperience  where PID=@PID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getEmpLeave(int PID)
        {
            con.Open();
            string sql = "view_leaveName_assigned";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PID", PID);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getLeavebyId(int PID, int LEAVEID)
        {

            string sql = "select * from Tbl_Emp_Leave where PID =@PID and LEAVEID=@LEAVEID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@LEAVEID", LEAVEID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getLeaveInfo()
        {
            string sql = "select LEAVE_ID,LEAVE_NAME,LEAVE_DAYS,LEAVE_MAX from Tbl_Org_Leave_Info";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //*************** Attendance Management **************//

        public DataTable getForceAttendanceRooster(int EMP_ID, DateTime Startdate, DateTime Enddate, int counter)
        {

            string query = "exec Proc_working_shift '"
                + EMP_ID + "', '"
                + Startdate + "', '"
                + Enddate + "', '"
                + counter + "'";
            return queryFunction(query);
        }

        public DataTable getForceData(string effectiveDate, int empId)
        {

            DateTime date = Convert.ToDateTime(effectiveDate);
            string query = "select * from Tbl_Emp_Attn_Log_general inner join Tbl_Org_Working_Hrs on Tbl_Emp_Attn_Log_general.workhour_id=Tbl_Org_Working_Hrs.work_id where tdate = '" + date + "' AND emp_id= " + empId + " order by Tbl_Emp_Attn_Log_general.Counter";
            return queryFunction(query);
        }

        public DataTable getSessionIDtoEmpName(int EMP_ID)
        {
            string query = "select EMP_FULLNAME from view_Emp_Info where status_id = 1 and EMP_ID=" + EMP_ID;
            return queryFunction(query);

        }

        public void ForceAttendance(string EMP_ID, DateTime TDATE, DateTime INTIME, string INREMARKS, string INMODE, DateTime TDATE_OUT, DateTime OUTTIME, string OUTMODE, string OUTREMARKS, int flag, int manualin, int manualout, int counter)
        {
            con.Open();
            string sql = "Proc_Manage_EMP_Attn";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@TDATE", TDATE);
            cmd.Parameters.AddWithValue("@INTIME", INTIME);
            cmd.Parameters.AddWithValue("@INREMARKS", INREMARKS);
            cmd.Parameters.AddWithValue("@INMODE", INMODE);
            cmd.Parameters.AddWithValue("@TDATE_OUT", TDATE_OUT);
            cmd.Parameters.AddWithValue("@OUTTIME", OUTTIME);
            cmd.Parameters.AddWithValue("@OUTMODE", OUTMODE);
            cmd.Parameters.AddWithValue("@OUTREMARKS", OUTREMARKS);
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.Parameters.AddWithValue("@manualin", 0);
            cmd.Parameters.AddWithValue("@manualout", 0);
            cmd.Parameters.AddWithValue("@counter", counter);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable proc_forcebatch(DateTime date, string branch, string department, string time, int mode)
        {
            string sql = "proc_forcebatch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@branch", branch);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@mode", mode);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable proc_AllDepartment(DateTime date, string branch, string time, int mode)
        {
            string sql = "proc_AllDepartment";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@branch", branch);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@mode", mode);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Proc_Get_Default_Time(int EMP_ID, DateTime date)
        {
            string sql = "Proc_Get_Default_Time";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@date", date);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int proc_Getworkid(int empid, DateTime date, string time, string remark, int mode)
        {
            con.Open();
            string sql = "proc_Getworkid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@remark", remark);
            cmd.Parameters.AddWithValue("@mode", mode);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable getEmployeeByBranch(int BranchID)
        {
            string sql = "select emp_fullname, EMP_ID from view_Emp_Info where STATUS_ID = 1 and BRANCH_ID=@branch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch", BranchID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getLeaveApplication()
        {
            string sql = "select tbl_org_leave_log.*,Tbl_Org_Leave_Info.LEAVE_NAME, dbo. fn_GetHOD(tbl_org_leave_log.EMP_ID) as EmpName ,dbo. fn_GetHOD(tbl_org_leave_log.ApprovedBy)as ApprovedName from tbl_org_leave_log inner join Tbl_Org_Leave_Info on tbl_org_leave_log.LEAVE_ID=Tbl_Org_Leave_Info.LEAVE_ID where tbl_org_leave_log.status = 1 and Leave_Date is not null";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getLeaveDate(int EMP_ID)
        {
            string sql = "select Leave_Date from tbl_org_leave_log where EMP_ID = @EMP_ID and Leave_Date is not null";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void LeaveApplication(DateTime DATE, string EMP_ID, int LEAVE_ID, string TAKEN, string REMARKS, string Senior_EMP_ID, string DAYPART, string LEAVETYPE, int STATUS)
        {
            con.Open();
            string sql = "Proc_Insert_Tbl_Org_Leave_Log";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DATE", DATE);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@TAKEN", TAKEN);
            cmd.Parameters.AddWithValue("@REMARKS", REMARKS);
            cmd.Parameters.AddWithValue("@Senior_EMP_ID", Senior_EMP_ID);
            cmd.Parameters.AddWithValue("@DAYPART", DAYPART);
            cmd.Parameters.AddWithValue("@LEAVETYPE", LEAVETYPE);
            cmd.Parameters.AddWithValue("@STATUS", STATUS);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int updateLeaveApplication(int status, int SNo)
        {
            string sql = "update Tbl_org_leave_log set status = @status  where SNo=@SNo";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SNo", SNo);
            cmd.Parameters.AddWithValue("@status", status);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable proc_LeaveShow(int empid, int year, int month, int date_type)
        {
            con.Open();
            string sql = "proc_LeaveShow";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@date_type", date_type);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void deleterow(int SNo)
        {
            string sql = "Delete from tbl_org_leave_log where SNo=@SNo";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SNo", SNo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void ForceLeaveAssign(int ActionFlag, int SNo, int LEAVE_ID, decimal GIVEN, int GIVENMONTH, int GIVENYEAR, int APPROVEDBY, string IsOpening, int EMP_ID)
        {
            con.Open();
            string sql = "Proc_Manage_Opening_Leave";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActionFlag", ActionFlag);
            cmd.Parameters.AddWithValue("@SNo", SNo);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@GIVEN", GIVEN);
            cmd.Parameters.AddWithValue("@GIVENMONTH", GIVENMONTH);
            cmd.Parameters.AddWithValue("@GIVENYEAR", GIVENYEAR);
            cmd.Parameters.AddWithValue("@APPROVEDBY", APPROVEDBY);
            cmd.Parameters.AddWithValue("@IsOpening", IsOpening);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable getMonthList()
        {
            string sql = "select MONTH_ID,MONTH_NAME from Tbl_english_month";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getNepaliMonthList()
        {
            string sql = "select MONTH_ID,MONTH_NAME from tbl_nepali_month";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable checkWeekend(int EMP_ID, DateTime date)
        {
            string sql = "SELECT * FROM tbl_org_weekend where EMP_ID = @EMP_ID and DATE = @sdate";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@sdate", date);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable checkAttendance(int EMP_ID, DateTime date)
        {
            string sql = "select dbo.fn_GetNAMEBYID(EMP_ID) as emp_name, EMP_ID, TDATE, INTIME, INMODE, INREMARKS, OUTTIME, OUTMODE, OUTREMARKS, TDATE_OUT, (case when COUNTER=1 then '1st Shift' else '2nd Shift' end) as Shift from tbl_emp_attn_log_general where EMP_ID = @EMP_ID and TDATE = @tdate";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@tdate", date);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable checkForDeleteAttendance(int EMP_ID, DateTime startDate, DateTime endDate)
        {
            string sql = "select dbo.fn_GetNAMEBYID(EMP_ID) as emp_name, EMP_ID, TDATE, convert(char(8),cast(INTIME as DateTime),108) as INTIME, INMODE, INREMARKS, convert(char(8),cast(OUTTIME as DateTime),108) as OUTTIME, OUTMODE, OUTREMARKS, TDATE_OUT, (case when COUNTER=1 then '1st Shift' else '2nd Shift' end) as Shift from tbl_emp_attn_log_general where EMP_ID = @EMP_ID and TDATE BETWEEN @startDate and @endDate ORDER BY TDATE ASC";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int saveWeekendSubsitute(DateTime date, string EMP_ID, int LEAVE_ID, string TAKEN, string REMARKS, string Senior_EMP_ID, string DAYPART, string LEAVETYPE, DateTime Week_day)
        {
            con.Open();
            string sql = "Proc_Insert_Tbl_Org_Leave_Log_sub";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@TAKEN", TAKEN);
            cmd.Parameters.AddWithValue("@REMARKS", REMARKS);
            cmd.Parameters.AddWithValue("@Senior_EMP_ID", Senior_EMP_ID);
            cmd.Parameters.AddWithValue("@DAYPART", DAYPART);
            cmd.Parameters.AddWithValue("@LEAVETYPE", LEAVETYPE);
            cmd.Parameters.AddWithValue("@Week_day", Week_day);
            j = cmd.ExecuteNonQuery();
            con.Close();
            return j;
        }
        public int saveDoubleDutysSubsitute(DateTime date, string EMP_ID, DateTime Week_day)
        {
            con.Open();
            string sql = "Proc_Insert_Tbl_Org_Leave_Log_sub_Double";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DDDATE", date);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", 4);
            cmd.Parameters.AddWithValue("@TAKEN", "1");
            cmd.Parameters.AddWithValue("@REMARKS", "Double Duty Subtitute");
            cmd.Parameters.AddWithValue("@Senior_EMP_ID", "0");
            cmd.Parameters.AddWithValue("@DAYPART", "1");
            cmd.Parameters.AddWithValue("@LEAVETYPE", "Normal Leave");
            cmd.Parameters.AddWithValue("@Sub_day", Week_day);
            j = cmd.ExecuteNonQuery();
            con.Close();
            return j;
        }
        public DataTable getHolidayname(int emp_id)
        {
            string sql = "Proc_Load_HolName_Emp";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void InsertSubHoliday(int EMPID, DateTime HDate, DateTime ADate, int EarnPH, string holiday)
        {
            con.Open();
            string sql = "proc_Substitute";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMPID", EMPID);
            cmd.Parameters.AddWithValue("@HDate", HDate);
            cmd.Parameters.AddWithValue("@ADate", ADate);
            cmd.Parameters.AddWithValue("@EarnPH", EarnPH);
            cmd.Parameters.AddWithValue("@holiday", holiday);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //************** Reports*******************//
        public DataTable getBranchList()
        {
            string sql = "select BRANCH_ID,BRANCH_NAME from Tbl_Comp_Branch where sta = 1 order by BRANCH_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getDepartmentList(int BranchID)
        {
            string sql = "select distinct DEPT_ID, DEPT_NAME from view_Emp_Info where BRANCH_ID=@branch and status_id = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch", BranchID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getBranch_DepartmentList(int branch_id)
        {
            string sql = "select distinct DEPT_ID, DEPT_NAME from view_Emp_Info where STATUS_ID = 1 and BRANCH_ID=@branch order by DEPT_NAME ASC";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch", branch_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getDept_EmployeeList(int dept_id, int branch_id)
        {

            string sql;
            if (dept_id == 0)
            {

                sql = "select emp_fullname,EMP_ID from view_Emp_Info where STATUS_ID = 1 order by emp_id asc";
            }
            else
            {

                sql = "select emp_fullname,EMP_ID from view_Emp_Info where DEPT_ID=@department and BRANCH_ID =@branch and STATUS_ID = 1 order by emp_id asc";
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@department", dept_id);
            cmd.Parameters.AddWithValue("@branch", branch_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getAllInfo(int emp_id)
        {
            string sql = "select * from view_Emp_Info where EMP_ID=@EMP_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        // for report
        public DataTable getAll_Info(int emp_id)
        {
            string sql = "select * from view_Emp_Info where status_id = 1 and EMP_ID=@EMP_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //for entry
        //public DataTable getAllInfoo(string emp_id)
        //{
        //    string sql = "select * from view_Emp_Info where EMP_ID=@EMP_ID and status_id = 1";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        public DataSet QuickAttnReport(int emp_id, int BranchId, int DeptId, DateTime date_from, DateTime date_to, int Aflag)
        {
            string sql = "proc_Attn_Mon_General";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@date_from", date_from);
            cmd.Parameters.AddWithValue("@date_to", date_to);
            cmd.Parameters.AddWithValue("@Aflag", Aflag);
            cmd.CommandTimeout = 500;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda = new SqlDataAdapter(cmd);
            //sda.TableMappings.Add("Table", "Attendance");
            //sda.TableMappings.Add("Table1", "Count");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.Dispose();
            sda.Dispose();
            return ds;

        }
        public DataTable countdays(int emp_id, DateTime sdate, DateTime edate)
        {
            string sql = "proc_countdays";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.CommandTimeout = 500;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getQuickAttendanceData()
        {
            string sql = "select * from rpt_attendance_data";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable CheckDoubleDuty(int empid, DateTime Date)
        {
            string sql = "select * from Tbl_DoubleSub where Emp_ID=@EMP_ID and Leave_id=4 and DSub_Day=@Sub_day";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_ID", empid);
            cmd.Parameters.AddWithValue("@Sub_Day", Date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataSet Monthlyattendance(int emp_id, int BranchId, int DeptId, DateTime date_from, DateTime date_to, int Aflag)
        {
            string sql = "proc_Attn_Mon_General";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@date_from", date_from);
            cmd.Parameters.AddWithValue("@date_to", date_to);
            cmd.Parameters.AddWithValue("@Aflag", Aflag);
            cmd.CommandTimeout = 500;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda = new SqlDataAdapter(cmd);
            //sda.TableMappings.Add("Table", "Attendance");
            //sda.TableMappings.Add("Table1", "Count");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.Dispose();
            sda.Dispose();
            return ds;
        }

        public DataTable ForceAttendance(DateTime startDate, DateTime endDate, string dept_id, int emp_id)
        {
            con.Open();
            string sql = "proc_ForceAttendanceReport";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 500;
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            cmd.Parameters.AddWithValue("@dept_id", dept_id);
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LeaveTakenDetail(DateTime sdate, DateTime edate, int EMP_ID, int LEAVE_ID, int BRANCH_ID, int DEPT_ID)
        {
            con.Open();
            string sql = "Proc_leave_monthly_report ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@BRANCH_ID", BRANCH_ID);
            cmd.Parameters.AddWithValue("@DEPT_ID", DEPT_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }



        //InOut Reports
        public DataTable Reports_InOutInfo(int branch_id, DateTime StartDate, DateTime EndDate)
        {
            con.Open();
            string sql = "proc_emp_list_Null";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@branch_id", branch_id);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getleave_emp(int EMP_ID)
        {
            con.Open();
            string sql = "proc_load_leavename_emp";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }
        public DataTable getLeaveList()
        {
            string sql = "SELECT LEAVE_ID, LEAVE_NAME, LEAVE_DAYS, LEAVE_MAX from Tbl_Org_Leave_Info where status = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable proc_Pay_LeaveLog_web(int empid, int LvType)
        {
            con.Open();
            string sql = "proc_Pay_LeaveLog_web";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@LvType", LvType);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getEmployees()
        {
            string sql = "SELECT EMP_ID, emp_fullname from view_emp_info where status_id = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getSupervisorEmployees(string DEPT_ID)
        {
            string sql = "SELECT EMP_ID, emp_fullname from view_emp_info where status_id = 1 and DEPT_ID =" + DEPT_ID;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getWorkingEmployees()
        {
            string sql = "SELECT EMP_ID, emp_fullname from view_emp_info where status_id = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getRooster(int emp_id, DateTime date)
        {
            string sql = "Proc_workHrs";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@date", date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LeaveInformation(int BRANCHID, int DEPTID, int EMPID)
        {
            con.Open();
            string sql = "proc_Pay_LeaveLog";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BRANCHID", BRANCHID);
            cmd.Parameters.AddWithValue("@DEPTID", DEPTID);
            cmd.Parameters.AddWithValue("@EMPID", EMPID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LeaveMonthlyreport(DateTime sdate, DateTime edate, int EMP_ID, int LEAVE_ID, int BRANCH_ID, int DEPT_ID)
        {
            con.Open();
            string sql = "Proc_leave_monthly_report";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@BRANCH_ID", BRANCH_ID);
            cmd.Parameters.AddWithValue("@DEPT_ID", DEPT_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Getstatus()
        {
            string sql = "select * from Tbl_stat";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetType()
        {
            string sql = "select * from Tbl_Emp_Type";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable EmployeeReport(string query)
        {
            string sql = query;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //Datewise Report
        public DataTable DatewiseAttendance(DateTime date_from, DateTime date_to, string dept_id)
        {
            con.Open();
            string sql1 = "proc_Datewise_Att_Report";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandTimeout = 500;
            cmd1.Parameters.AddWithValue("@dept_id", dept_id);
            cmd1.Parameters.AddWithValue("@date_from", date_from);
            cmd1.Parameters.AddWithValue("@date_to", date_to);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //OverTimeSummary
        public DataTable OverTimeSummary(int EID, DateTime DT1, DateTime DT2, int FLG, int branch_id, int dept_id)
        {
            con.Open();
            string sql = "proc_OverTime_Monthly";
            SqlCommand cmd1 = new SqlCommand(sql, con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@EID", EID);
            cmd1.Parameters.AddWithValue("@DT1", DT1);
            cmd1.Parameters.AddWithValue("@DT2", DT2);
            cmd1.Parameters.AddWithValue("@FLG", FLG);
            cmd1.Parameters.AddWithValue("@branch", branch_id);
            cmd1.Parameters.AddWithValue("@dept", dept_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable DailyAbsent(DateTime sdate, DateTime edate, string dept_id, int flag, int emp_id)
        {
            string query = "exec SP_DEPARTMENTWISEABSENT_REPORT '"
                + sdate + "', '"
                + edate + "', '"
                + dept_id + "', '"
                + 0 + "', '"
                + emp_id + "'";
            return queryFunction(query);
        }
        public DataTable DutyShortage(DateTime sdate, DateTime edate, string deptname, int flag)
        {
            string query = "exec SP_DATEWISE_DUTYSHORTAGE_REPORT '"
                + sdate + "', '"
                + edate + "', '"
                + deptname + "', '"
                + flag + "'";
            return queryFunction(query);
        }
        public DataTable DutyShortageData()
        {
            string sql = "select * from tempDutyShortage";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //public DataTable AbsentReportData()
        //{
        //    string sql = "select * from tmpabsentreport";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        public DataTable EmployeeDetailInformation(int emp_id)
        {
            string sql = "select * from view_emp_info where EMP_ID=@emp_id and status_id = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Report_LateAttendance(int branch, int department, DateTime date_from, DateTime date_to, int condition)
        {
            con.Open();
            string sql = "proc_late_Record";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@branch", branch);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@date_from", date_from);
            cmd.Parameters.AddWithValue("@date_to", date_to);
            cmd.Parameters.AddWithValue("@condition", condition);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //Rooster Shift Report
        public void Report_RoosterShift(DateTime startdate, DateTime tilldate, int empid, int Aflag)
        {
            string sql = "proc_rptRosterShiftInfo";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@tilldate", tilldate);
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@flag", Aflag);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable Report_Promotion(DateTime sdate, DateTime edate, int branch_id, int dept_id, int EMP_ID)
        {
            string sql = "proc_Promotion_report";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@branch_id", branch_id);
            cmd.Parameters.AddWithValue("@dept_id", dept_id);
            cmd.Parameters.AddWithValue("@EMP_ID", 0);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Report_Transfer(DateTime sdate, DateTime edate, int EMP_ID, int deptFrom, int deptTo, int BranchFrom, int BranchTo)
        {
            string sql = "proc_transfer_report";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@deptFrom", deptFrom);
            cmd.Parameters.AddWithValue("@deptTo", deptTo);
            cmd.Parameters.AddWithValue("@BranchFrom", BranchFrom);
            cmd.Parameters.AddWithValue("@BranchTo", BranchTo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void shiftChange(DateTime tdate, int emp_id, int approver_id, int prev_rooser_id, DateTime rooster_date, int current_rooster_id, int status, int session_id, int flag)
        {
            string sql = "Org_ShiftChange";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tdate", tdate);
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@approver_id", approver_id);
            cmd.Parameters.AddWithValue("@prev_rooster_id", prev_rooser_id);
            cmd.Parameters.AddWithValue("@rooster_date", rooster_date);
            cmd.Parameters.AddWithValue("@current_rooster_id", current_rooster_id);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@session_id", session_id);
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable getOutstandingId()
        {
            string sql = "select ISNULL(MAX(VNO) + 1, 1) as travel_id from Tbl_Emp_Outstation;";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetRoosterData()
        {
            string sql = "select * from tbl_rptRosterShift";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable BackupLocation()
        {
            string sql = "select * from Tbl_Backup_Location";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int BackupDatabase(string backupDestination, string dbNAme)
        {

            if (!System.IO.Directory.Exists(backupDestination))
            {
                System.IO.Directory.CreateDirectory(backupDestination);
            }

            string sql = "BACKUP database " + dbNAme + " to disk='" + backupDestination + "\\" + dbNAme + " of " + DateTime.Now.ToString("yyyy-MM-dd@HH_mm") + ".Bak'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int j = cmd.ExecuteNonQuery();
            con.Close();
            return j = 1;
        }
        public DataTable ExportIDS(int emp_id, DateTime date_from, DateTime date_to, int Aflag)
        {
            string sql = "proc_IDS";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@date_from", date_from);
            cmd.Parameters.AddWithValue("@date_to", date_to);
            cmd.Parameters.AddWithValue("@Aflag", Aflag);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getExportData()
        {
            string sql = "select * from rpt_attendance_IDS";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void deleteAttendance(string EMP_ID, string tdate, string counter)
        {
            string sql = "Proc_Delete_Emp_Attn";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@tdate", tdate);
            cmd.Parameters.AddWithValue("@counter", counter);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable loadOt(DateTime date, string dept)
        {
            string sql = "SP_OT_CALCULATE";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@dept", dept);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable manageOverTime(

            int EMP_ID,
            DateTime OT_InDate,
            string HrsMin,
            string OT_Values,
            int OT_APPROVEDBY
        )
        {

            string query = "exec proc_save_overtime '"
                + EMP_ID + "', '"
                + OT_InDate + "', '"
                + HrsMin + "', '"
                + OT_Values + "', '"
                + OT_APPROVEDBY + "' ";
            return queryFunction(query);
        }

        public void updatelogHistory(string indx)
        {
            con.Open();
            string sql = "UPDATE Tbl_DeviceAttenLog set InOutMode = case when INOUTMODE = '1' THEN '0' when INOUTMODE = '0' then '1' end where indx=" + indx;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@indx", indx);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable DepartmentwiseLeaveTakenSummary(DateTime sdate, DateTime edate)
        {
            string sql = "SP_DEPARTMENTWISE_LEAVETAKEN_SUMMARY";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable DepartmentwiseLeaveBalanceSummary(DateTime sdate, DateTime edate)
        {
            string sql = "SP_DEPARTMENTWISE_LEAVETAKEN_SUMMARY";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable IndividualLeaveTakenSummary(DateTime sdate, DateTime edate, string deptname, int flag)
        {
            string sql = "SP_INDIVIDUAL_LEAVETAKEN_SUMMARY";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@deptname", deptname);
            cmd.Parameters.AddWithValue("@flag", flag);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }



        public DataTable IndividualLeaveTakenSummaryData()
        {
            string sql = "select * from tmpIndividualLeaveTakenSummayReport";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable IndividualLeaveBalanceSummary(DateTime sdate, DateTime edate, string dept_id)
        {
            string sql = "SP_DATEWISE_LEAVEBALANCE_SUMMARY";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@deptname", dept_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }



        //public DataTable IndividualLeaveBalanceSummaryData()
        //{
        //    string sql = "select * from tmpIndividualLeaveBalanceSummary";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}



        public DataTable DatewiseLeaveTakenReport(DateTime sdate, DateTime edate, string dept_name, int flag)
        {
            string sql = "SP_DAILY_ONLEAVE_REPORT";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@deptname", dept_name);
            cmd.Parameters.AddWithValue("@flag", flag);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DatewiseLeaveTakenReportData()
        {
            string sql = "select * from tmpDatewiseLeaveTakenReport";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //********** Super Admin **********
        public DataTable getMainMenu()
        {
            string sql = "SELECT * FROM tblMenu";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getSubMenu(int menuId)
        {
            string query = "SELECT p.id, p.title, p.url, p.subMenu,  q.title as menu  FROM tblSubMenu1 p left JOIN tblMenu q ON p.menuId =q.id where p.menuId ='" + @menuId + "'";
            return queryFunction(query);
        }

        public DataTable getMenuName(int menuId)
        {
            string query = "SELECT title  FROM tblMenu where id ='" + @menuId + "'";
            return queryFunction(query);
        }

        public string GetMACAddress()
        {
            string mac_src = "";
            string macAddress = "";

            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    mac_src += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            while (mac_src.Length < 12)
            {
                mac_src = mac_src.Insert(0, "0");
            }

            for (int i = 0; i < 11; i++)
            {
                if (0 == (i % 2))
                {
                    if (i == 10)
                    {
                        macAddress = macAddress.Insert(macAddress.Length, mac_src.Substring(i, 2));
                    }
                    else
                    {
                        macAddress = macAddress.Insert(macAddress.Length, mac_src.Substring(i, 2)) + "-";
                    }
                }
            }
            return macAddress;
        }

        string EncryptionKey = "AvighnaAttendance";
        public string EncryptString(string clearText)
        {

            clearText = clearText.Replace(" ", "#");
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string DecryptString(string cipherText)
        {
            //cipherText = cipherText.Replace(" ", "#");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public int Activate(string macAddress, string serialkey, string period, string date, string encryptDay)
        {
            string sql = "proc_WebActivation";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@macAddress", macAddress);
            cmd.Parameters.AddWithValue("@serialkey", serialkey);
            cmd.Parameters.AddWithValue("@encryptDate", date);
            cmd.Parameters.AddWithValue("@encryptPeriod", period);
            cmd.Parameters.AddWithValue("@encryptDay", encryptDay);
            int j = cmd.ExecuteNonQuery();
            con.Close();
            return j;
        }


        public DataTable checkActivation()
        {
            string sql = "SELECT * FROM activation";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public void changeNotificationStatus(string id)
        {
            string query = "UPDATE Tbl_notification set status = 0 where id = '" + @id + "' ";
            queryFunction(query);
        }

        public DataTable getLogItems()
        {
            string query = " SELECT * FROM Tbl_System_Log_item where Status = 1";
            return queryFunction(query);
        }



        public void systemLog(string remarks, int emp_id, string event_info, string event_date, string event_type, int login_id)
        {
            string query = "exec proc_systemLog '"
                + remarks + "', '"
                + emp_id + "', '"
                + event_info + "', '"
                + event_date + "', '"
                + event_type + "', '"
                + login_id + "'";
            queryFunction(query);
        }

        public DataTable getLeaveForDelete(string emp_id, string leave_id, string isOpening)
        {
            if (isOpening == "1")
            {
                query = "select EMP_ID,dbo.fn_GetNAMEBYID(EMP_ID) as emp_name,Tbl_Org_Leave_Log.LEAVE_ID,LEAVE_NAME,GIVEN,TAKEN,REMARKS,GIVENMONTH,GIVENYEAR,GIVENDAY,dbo.fn_GetNAMEBYID(ApprovedBy) as ApprovedBy,OP_FLAG from Tbl_Org_Leave_Log left join Tbl_Org_Leave_Info ON Tbl_Org_Leave_Log.LEAVE_ID =  Tbl_Org_Leave_Info.LEAVE_ID where emp_id =" + @emp_id + " and Tbl_Org_Leave_Log.LEAVE_ID =" + @leave_id + " and OP_FLAG = 1";
            }
            else
            {
                query = "select EMP_ID,dbo.fn_GetNAMEBYID(EMP_ID) as emp_name,Tbl_Org_Leave_Log.LEAVE_ID,LEAVE_NAME,GIVEN,TAKEN,REMARKS,GIVENMONTH,GIVENYEAR,GIVENDAY,dbo.fn_GetNAMEBYID(ApprovedBy) as ApprovedBy,OP_FLAG from Tbl_Org_Leave_Log left join Tbl_Org_Leave_Info ON Tbl_Org_Leave_Log.LEAVE_ID =  Tbl_Org_Leave_Info.LEAVE_ID where emp_id =" + @emp_id + " and Tbl_Org_Leave_Log.LEAVE_ID =" + @leave_id + " and OP_FLAG = 0";
            }
            return queryFunction(query);
        }


        public int deleteLeave(string emp_id, string leave_id, string isOpening)
        {
            query = "DELETE FROM Tbl_Org_Leave_Log WHERE EMP_ID =" + @emp_id + " and LEAVE_ID=" + @leave_id + " and OP_FLAG=" + @isOpening;
            return intQueryFunction(query);
        }

        public DataSet getPhoto(string emp_id, string columnName, string tableName)
        {
            //query = "SELECT " + @columnName + " FROM " + @tableName + " WHERE EMP_ID =" + @emp_id;
            //con.Open();
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
            //cmd.Parameters.AddWithValue("@columnName", columnName);
            //cmd.Parameters.AddWithValue("@tableName", tableName);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //sda = new SqlDataAdapter(cmd);
            //sda.TableMappings.Add("Table", "Photo");
            //DataSet ds = new DataSet();
            //sda.Fill(ds);
            //cmd.Dispose();
            //sda.Dispose();
            //return ds;

            string sql = "Select EMP_PHOTO from Tbl_Emp_Info where EMP_ID=@EMP_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda = new SqlDataAdapter(cmd);
            sda.TableMappings.Add("Table", "Photo");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.Dispose();
            sda.Dispose();
            con.Close();
            con.Close();
            return ds;
        }


        public DataTable getSubsitutedHolidays(int EMP_ID)
        {
            query = "SELECT * FROM Tbl_Emp_ForceDuty WHERE EarnPH = 1 and EMP_ID = " + EMP_ID;
            return queryFunction(query);
        }

        public DataTable getSubsitutedHolidaysName(string holiday_name, int EMP_ID)
        {
            query = "SELECT *, dbo.fn_GetNAMEBYID(emp_id) as emp_name FROM Tbl_Emp_ForceDuty WHERE EMP_ID =" + EMP_ID + " and holiday_name = " + "'" + holiday_name + "'";
            return queryFunction(query);
        }

        public int cancelPhSubsitute(int EMP_ID, string HolidayDate)
        {
            query = "exec proc_subPh_cancel '"
                + EMP_ID + "', '"
                + HolidayDate + "' ";
            return intQueryFunction(query);
        }

        public DataTable getSubsitutedWeekend(int EMP_ID)
        {
            query = "SELECT CONVERT(VARCHAR(10), week_day, 111) as week_day FROM Tbl_SubWeek WHERE EMP_ID = " + EMP_ID;
            return queryFunction(query);
        }

        public DataTable getSubsitutedWeekendDate(int EMP_ID, string week_day)
        {
            query = "SELECT CONVERT(VARCHAR(10), week_day, 111) as week_day, sub_day, remarks FROM Tbl_SubWeek WHERE EMP_ID =" + EMP_ID + " and week_day = " + "'" + week_day + "'";
            return queryFunction(query);
        }

        public int cancelWeekendSubsitute(string week_day, int EMP_ID)
        {
            query = "exec proc_subweek_cancel '"
                + week_day + "', '"
                + EMP_ID + "' ";
            return intQueryFunction(query);
        }

        public DataTable getLeaveCancellation(int EMP_ID, int LEAVE_ID)
        {
            query = "select Tbl_Org_Leave_Log.LEAVE_ID, Tbl_Org_Leave_Log.SNO, dbo.fn_GetNAMEBYID(EMP_ID) as emp_name, EMP_ID, Tbl_Org_Leave_Log.LEAVE_ID,LEAVE_NAME,GIVEN, REMARKS, dbo.fn_GetNAMEBYID(ApprovedBy) as ApprovedBy FROM Tbl_Org_Leave_Log left join Tbl_Org_Leave_Info ON Tbl_Org_Leave_Log.LEAVE_ID =  Tbl_Org_Leave_Info.LEAVE_ID where taken is null and emp_id =" + EMP_ID + " and Tbl_Org_Leave_Log.LEAVE_ID =" + LEAVE_ID;
            return queryFunction(query);
        }

        public void LeaveAdjustment(string days, int sno, string flag)
        {
            string query = "exec proc_LeaveAdjustment '"
                + days + "', '"
                + sno + "', '"
                + flag + "'";
            queryFunction(query);
        }


        public DataTable getAssignedPH(int EMP_ID)
        {
            query = "SELECT * FROM Tbl_Emp_ForceDuty WHERE EarnPH = 0 and Emp_ID = " + EMP_ID;
            return queryFunction(query);

        }

        public int deleteAssignedPh(string fDutyId)
        {
            query = "DELETE FROM Tbl_Emp_ForceDuty WHERE fduty_id = " + fDutyId;
            return intQueryFunction(query);
        }

        public DataTable getState()
        {
            query = "SELECT * from tbl_org_state";
            return queryFunction(query);
        }

        public DataTable getDistrict(string StateId)
        {
            query = "SELECT * from Tbl_org_state_district WHERE StateId = " + StateId;
            return queryFunction(query);
        }

        public DataTable checkHodStatus(string HOD_ID)
        {
            query = "SELECT * from view_emp_info WHERE usertypeid = 3 and  EMP_ID = " + HOD_ID;
            return queryFunction(query);
        }

        public DataTable getHODAssigned()
        {
            query = "SELECT tbl_hod_assign.dept_id, dept_name,dbo.Fn_getnamebyid(emp_id) AS emp_name,emp_id FROM tbl_hod_assign JOIN tbl_org_dept ON tbl_hod_assign.dept_id = tbl_org_dept.dept_id ";
            return queryFunction(query);
        }

        public int manageHOD(string dept_id, string emp_id)
        {
            string query = "exec manageHOD '"
                + dept_id + "', '"
                + emp_id + "'";
            return intQueryFunction(query);
        }
        public DataTable SubsituteLeaveLapse(int dept_id, int emp_id)
        {
            string query = "exec SubsituteLeaveLapse '"
                + dept_id + "', '"
                + emp_id + "'";
            return queryFunction(query);
        }

        public DataTable checkWebLoginStatus(int @emp_id)
        {
            string query = "Select enable_web_login from tbl_emp_off_info WHERE EMP_ID =" + @emp_id;

            return queryFunction(query);
        }
    }
}