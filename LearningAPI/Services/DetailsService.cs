using LearningAPI.DTO;
using LearningAPI.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace LearningAPI.Services
{
    public class DetailsService : IDetails
    {
        private readonly LearningContext _context;
        public SqlConnection sqlCon;
        public IConfiguration _config;
        public DetailsService(LearningContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        #region("Asynchronous")
        public async Task<IEnumerable<Datum>> GetAllData()
        {
            var data = await _context.Data.ToListAsync(); 

            return data; 
        }

        public async Task<Datum> PostData(Datum datum)
        {
            await _context.AddAsync(datum);   
            await _context.SaveChangesAsync();
            return datum;

        }

        public async Task<int> DeleteData(int ID)
        {
            var data = await _context.Data.FirstOrDefaultAsync(id => id.Id == ID);
            if(data != null)
            {
                _context.Data.Remove(data);
                _context.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public async Task<Datum> UpdateData(int id, Datum datum)
        {
            var data = await _context.Data.FirstOrDefaultAsync(Id => Id.Id == id);
            if (data != null)
            {
                data = datum;
                _context.Data.Update(data);

                await _context.SaveChangesAsync();
                return datum;
            }
            else
            {
                return null;
            }

        }

        public async Task<IEnumerable<Datum>> GetDataById(int Id)
        {
            var data = await _context.Data.Where(res => res.Id == Id).ToListAsync();

            if(data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<TableData>> GetTableNames()
        {
            var data = await _context.TableData.ToListAsync();

            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            };
        }

        public async Task<List<SPData>> GetSPNames()
        {
            var data = await _context.SPData.ToListAsync();

            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            };

        }

        public async Task<string> SaveSpData(string sqlQuery, string spName)
        {
            try
            {
                await using (sqlCon = new SqlConnection(_config.GetConnectionString("MyConn")))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("[dbo].[usp_CreateSPwithJSONInputs]", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@sqlQuery", SqlDbType.NVarChar).Value = sqlQuery;
                    sql_cmnd.Parameters.AddWithValue("@spName", SqlDbType.VarChar).Value = spName;
                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                return "Success";
            }
            catch(Exception ex)
            {
                return "Failed";
            }
        }

        #endregion

        #region("Synchronous")

        public List<Datum> GetData()
        {
            var data = _context.Data.ToList();

            return data;
        }

        public int PostDataSync(Datum datum)
        {
            var data = _context.Add(datum);
            _context.SaveChanges();
            return 1;
        }

        public int DeleteDataSync(int id)
        {
            var data = _context.Data.FirstOrDefault(Id => Id.Id == id);
            if (data != null)
            {
                _context.Data.Remove(data);
                _context.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        public string UpdateDataSync(int id, Datum datum)
        {
            var data =  _context.Data.FirstOrDefault(Id => Id.Id == id);
            if(data != null) {
                data.Id = id;
                data.Name = datum.Name;
                data.ExpiryDate = datum.ExpiryDate;
                data.Gender = datum.Gender;
                _context.SaveChanges();
                return "Success";
            }
            else
            {
                return "Unsuccessful"; 
            }
            
        }

        #endregion
    }
}
