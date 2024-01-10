using Dapper;
using Digitize.Server.SQL;
using Digitize.Shared.Data;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Digitize.Server.Interface
{
    public class DigitizeInterface : IDigitizeInterface
    {
        private readonly SQLServerConfiguration _digitizeconfiguration;

        public DigitizeInterface(SQLServerConfiguration digitizeconfiguration)
        {
            _digitizeconfiguration = digitizeconfiguration;
        }

        public async Task<IEnumerable<Aadhaar>> GetAllAdhaar()
        {
            IEnumerable<Aadhaar> myAadhaar;
            using (var conn = new SqlConnection(_digitizeconfiguration.MyDBValue))
            {

                const string query = @"SELECT * FROM [dbo].[Aadhaar]";


                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    myAadhaar = await conn.QueryAsync<Aadhaar>(query, commandType: CommandType.Text);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return myAadhaar;
        }
        public async Task<Aadhaar> GetAdhaar(int Uid)
        {
            Aadhaar myAadhaar;
            using (var conn = new SqlConnection(_digitizeconfiguration.MyDBValue))
            {

                const string query = @"SELECT * FROM [dbo].[Aadhaar] where UidNo=@Uid";//3650

                //Using system.Data required to check the ConnectionStat
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    myAadhaar = await conn.QuerySingleAsync<Aadhaar>(query, new { Uid }, commandType: CommandType.Text);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return myAadhaar;
        }


        public async Task<Birth> GetBirth(int id)
        {
            Birth myBirth;
            using (var conn = new SqlConnection(_digitizeconfiguration.MyDBValue))
            {

                const string query = @"SELECT * FROM [dbo].[Birth] where RegNo=@id";//3650

                //Using system.Data required to check the ConnectionStat
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    myBirth = await conn.QuerySingleAsync<Birth>(query, new { id }, commandType: CommandType.Text);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return myBirth;
        }

        public async Task<Voter> GetVoter(int id)
        {
            Voter myVoter;
            using (var conn = new SqlConnection(_digitizeconfiguration.MyDBValue))
            {

                const string query = @"SELECT * FROM [dbo].[VoterId] where VoterId=@id";//3650

                //Using system.Data required to check the ConnectionStat
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    myVoter = await conn.QuerySingleAsync<Voter>(query, new { id }, commandType: CommandType.Text);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return myVoter;
        }
        public async Task<int> RemoveVoter(int id)
        {
            int myVoter;
            using (var conn = new SqlConnection(_digitizeconfiguration.MyDBValue))
            {

                const string query = @"Delete * FROM [dbo].[VoterId] where VoterId=@id";//3650

                //Using system.Data required to check the ConnectionStat
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    myVoter = await conn.QuerySingleAsync<int>(query, new { id }, commandType: CommandType.Text);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return myVoter;
        }
        public async Task<int> RemoveBirth(int id)
        {
            int myBirth;
            using (var conn = new SqlConnection(_digitizeconfiguration.MyDBValue))
            {

                const string query = @"Delete * FROM [dbo].[Birth] where RegNo=@id";//3650

                //Using system.Data required to check the ConnectionStat
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    myBirth = await conn.QuerySingleAsync<int>(query, new { id }, commandType: CommandType.Text);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return myBirth;
        }
        public async Task<int> RemoveAdhaar(int Uid)
        {
            int myAadhaar;
            using (var conn = new SqlConnection(_digitizeconfiguration.MyDBValue))
            {

                const string query = @"Delete from [dbo].[Aadhaar] where UidNo=@Uid";//3650

                //Using system.Data required to check the ConnectionStat
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    myAadhaar = await conn.QuerySingleAsync<int>(query, new { Uid }, commandType: CommandType.Text);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return myAadhaar;
        }
        public async Task<Aadhaar> CreateAdhaar(Aadhaar aadharData)
        {
            var parameters = new DynamicParameters();

            parameters.Add("Name", aadharData.Name, DbType.String);
            parameters.Add("FatherName", aadharData.FatherName, DbType.String);
            parameters.Add("DOB", aadharData.DOB, DbType.DateTime);
            parameters.Add("Address", aadharData.Address, DbType.String);
            parameters.Add("UidNo", aadharData.UidNo, DbType.Int64);
            parameters.Add("Phone", aadharData.Phone, DbType.String);

            using (var conn = new SqlConnection(_digitizeconfiguration.MyDBValue))
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var id = await conn.ExecuteAsync("AddAdhaar", parameters, commandType: CommandType.StoredProcedure);

                    Aadhaar? adhaarInput = new()
                    {
                        IdAdhar = id,
                        Name = aadharData.Name,
                        FatherName = aadharData.FatherName,
                        DOB = aadharData.DOB,
                        Address = aadharData.Address,
                        UidNo = aadharData.UidNo,
                        Phone = aadharData.Phone
                    };

                    return adhaarInput;

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }


        public async Task<Voter> CreateVoter(Voter voterData)
        {
            var parameters = new DynamicParameters();

            parameters.Add("Name", voterData.Name, DbType.String);
            parameters.Add("FatherName", voterData.FatherName, DbType.String);
            parameters.Add("DOB", voterData.DOB, DbType.DateTime);
            parameters.Add("Address", voterData.Address, DbType.String);
            parameters.Add("VoterId", voterData.VoterId, DbType.Int64);
            parameters.Add("Phone", voterData.Phone, DbType.String);

            using (var conn = new SqlConnection(_digitizeconfiguration.MyDBValue))
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var id = await conn.ExecuteAsync("AddVoter", parameters, commandType: CommandType.StoredProcedure);

                    Voter? voterInput = new()
                    {
                        Id = id,
                        Name = voterData.Name,
                        FatherName = voterData.FatherName,
                        DOB = voterData.DOB,
                        Address = voterData.Address,
                        VoterId = voterData.VoterId,
                        Phone = voterData.Phone
                    };

                    return voterInput;

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }

        }
        public async Task<Birth> CreateBirth(Birth birthData)
        {
            var parameters = new DynamicParameters();

            parameters.Add("Name", birthData.Name, DbType.String);
            parameters.Add("FatherName", birthData.FatherName, DbType.String);
            parameters.Add("DOB", birthData.DOB, DbType.DateTime);
            parameters.Add("Address", birthData.Address, DbType.String);
            parameters.Add("RegNo", birthData.RegNo, DbType.Int64);
            parameters.Add("MotherName", birthData.MotherName, DbType.String);
            parameters.Add("Approval", birthData.Approval, DbType.String);
            parameters.Add("Issue", birthData.Issue, DbType.String);

            using (var conn = new SqlConnection(_digitizeconfiguration.MyDBValue))
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var id = await conn.ExecuteAsync("AddBirth", parameters, commandType: CommandType.StoredProcedure);

                    Birth? birthInput = new()
                    {
                        Id = id,
                        Name = birthData.Name,
                        FatherName = birthData.FatherName,
                        DOB = birthData.DOB,
                        Address = birthData.Address,
                        RegNo = birthData.RegNo,
                        MotherName = birthData.MotherName,
                        Approval = birthData.Approval,
                        Issue = birthData.Issue

                    };

                    return birthInput;

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }
    }
}



