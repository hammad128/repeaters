using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestGridBinding.App_Code;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace TestGridBinding
{
    public partial class EditCategory : System.Web.UI.Page
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["InventoryMgmtConnectionString"].ToString();
            }
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int categoyId = Convert.ToInt32(Request.QueryString["catId"]);
                DataTable dt = getCategoryById(categoyId);
                txt_Category.Text = dt.Rows[0]["CategoryName"].ToString();
            }
        }
        private DataTable getCategoryById(int categoyId)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters =
                         {  
                             new SqlParameter("@CategoryID", SqlDbType.Int) { Value = categoyId }
                            
                         };
            dt = DataAccess.GetDataSet(ConnectionString, "IM_Select_Categories", parameters).Tables[0];
            return dt;                 

        }
        public void btn_Update_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters =
                         {  
                             new SqlParameter("@CategoryID", SqlDbType.Int) { Value = Convert.ToInt32(Request.QueryString["catId"])  },
                             new SqlParameter("@CategoryName", SqlDbType.VarChar) { Value = txt_Category.Text }
                            
                         };
            if (DataAccess.ExecuteNonQuery(ConnectionString, "IM_InsertUpdate_Category", parameters))
            {
                Response.Redirect("~/Category.aspx");    
            }
             
            
        }
    }
}
