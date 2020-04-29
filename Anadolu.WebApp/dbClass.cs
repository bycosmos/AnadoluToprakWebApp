using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class dbClass : IDisposable
{
    public SqlConnection cnn;

    public dbClass()
    {
        cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BaglantiAdi"].ConnectionString);
    }

    public bool SQLExecute(string SQLSorgu)
    {
        try
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand(SQLSorgu, cnn))
            {
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        catch
        {
            if (System.Diagnostics.Debugger.IsAttached)
                throw;
            return false;
        }
        finally
        {
            cnn.Close();
        }
    }

    public object SQLExecuteScalar(string SQLSorgu)
    {
        try
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand(SQLSorgu, cnn))
            {
                return cmd.ExecuteScalar();
            }
        }
        catch
        {
            if (System.Diagnostics.Debugger.IsAttached)
                throw;
            return null;
        }
        finally
        {
            cnn.Close();
        }
    }

    public DataTable LoadDataTable(string SQLSorgu)
    {
        try
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand(SQLSorgu, cnn))
            {
                DataTable dtTemp = new DataTable("TTemp");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTemp);
                return dtTemp;
            }
        }
        catch
        {
            if (System.Diagnostics.Debugger.IsAttached)
                throw;
            return null;
        }
        finally
        {
            cnn.Close();
        }
    }

    public DataRow LoadDataRow(string SQLSorgu)
    {
        try
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand(SQLSorgu, cnn))
            {
                DataTable dtTemp = new DataTable("TTemp");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTemp);
                if (dtTemp.Rows.Count > 0)
                    return dtTemp.Rows[0];
                else return null;
            }
        }
        catch
        {
            if (System.Diagnostics.Debugger.IsAttached)
                throw;
            return null;
        }
        finally
        {
            cnn.Close();
        }
    }

    public void Dispose()
    {
        if (cnn != null)
        {
            if (cnn.State != ConnectionState.Closed)
                cnn.Close();
            cnn.Dispose();
        }
        GC.SuppressFinalize(this);
    }
}
