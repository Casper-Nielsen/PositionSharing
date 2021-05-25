using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PositionSharingServer.Storage
{
    class MSSQLManager : IStorageManager
    {
        private string con;
        public MSSQLManager(string db)
        {
            con = @"Server=" + db + ";Database=PositionSharing;User Id=SecureExecuter;Password=k6UwAf4K*puBTEb^";
        }

        /// <summary>
        /// Addes a user to a group
        /// </summary>
        /// <param name="groupKey">the key of the group</param>
        /// <param name="user">the User Group Key</param>
        public void AddToGroup(string groupKey, string user)
        {
            using (SqlConnection con = new SqlConnection(this.con))
            {
                using (SqlCommand cmd = new SqlCommand("SPAddUserToGroup", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GroupKey", SqlDbType.NVarChar).Value = groupKey;
                    cmd.Parameters.Add("@UserGroupKey", SqlDbType.NVarChar).Value = user;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
        }

        /// <summary>
        /// looks if the database have a group with that key
        /// </summary>
        /// <param name="key">the key to check for</param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            bool contain = false;
            using (SqlConnection con = new SqlConnection(this.con))
            {
                using (SqlCommand cmd = new SqlCommand("SPContainsGroup", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GroupKey", SqlDbType.NVarChar).Value = key;

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        contain = reader.GetBoolean(0);
                    }
                    reader.Close();
                    cmd.Dispose();
                }
            }
            return contain;
        }

        /// <summary>
        /// creates a group in the database
        /// </summary>
        /// <param name="groupName">the name of the group</param>
        /// <param name="groupKey">the key of the group</param>
        public void CreateGroup(string groupName, string groupKey)
        {
            using (SqlConnection con = new SqlConnection(this.con))
            {
                using (SqlCommand cmd = new SqlCommand("SPInsertGroup", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GroupKey", SqlDbType.NVarChar).Value = groupKey;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = groupName;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
        }
    }
}
