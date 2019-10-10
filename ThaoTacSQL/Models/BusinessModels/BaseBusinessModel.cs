using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ThaoTacSQL.Models.BusinessModels
{
    public abstract class BaseBusinessModel
    {
        /// <summary>
        /// Chuỗi kết nối lưu trong web.config
        /// </summary>
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ThinhPhatConStr"].ConnectionString;

        protected SqlConnection connection;

        public BaseBusinessModel()
        {
            connection = new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Thực thi lấy data: Select, Function, Proc có trả về dữ liệu
        /// </summary>
        /// <param name="query">Câu truy vấn</param>
        /// <param name="type">Loại truy vấn</param>
        /// <param name="parameters">Tham số truy</param>
        /// <returns>Kết quả</returns>
        protected DataTable ExecuteQuery(string query, CommandType type, params SqlParameter[] parameters)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.CommandType = type;
                command.Parameters.AddRange(parameters);

                using (var adapter = new SqlDataAdapter(command))
                {
                    var dtbResult = new DataTable();
                    adapter.Fill(dtbResult);

                    return dtbResult;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Thực thi chỉnh sửa dữ liệu: Insert, Update, Delete, Proc ko trả về dữ liệu
        /// </summary>
        /// <param name="query">Câu truy vấn</param>
        /// <param name="type">Loại truy vấn</param>
        /// <param name="parameters">Tham số truy</param>
        /// <returns>Số dòng ảnh hưởng</returns>
        protected int ExecuteNonQuery(string query, CommandType type, params SqlParameter[] parameters)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = connection.CreateCommand();
                command.CommandText = query;
                command.CommandType = type;
                command.Parameters.AddRange(parameters);

                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}