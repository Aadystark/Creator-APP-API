namespace LearningAPI.Repository
{
    public interface IDetails
    {

        #region("Async")
        Task<IEnumerable<Datum>> GetAllData();

       Task<IEnumerable<Datum>> GetDataById(int Id); 

       Task<Datum> PostData(Datum datum);

       Task<int> DeleteData(int ID);

       Task<Datum> UpdateData(int id, Datum datum);
        #endregion

        Task<List<TableData>> GetTableNames();
        Task<List<SPData>> GetSPNames();
        Task<string> SaveSpData(string sqlQuery, string spName);

        #region("Sync")
        public List<Datum> GetData();

       public int PostDataSync(Datum datum);

       public int DeleteDataSync(int id);

       public string UpdateDataSync(int id, Datum datum);
        #endregion
    }
}
