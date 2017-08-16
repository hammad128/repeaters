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
    public partial class Category : System.Web.UI.Page
    {   
        public string ConnectionString {         
            get {
              return ConfigurationManager.ConnectionStrings["InventoryMgmtConnectionString"].ToString();
            }
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        public void BindData() {

            DataSet ds = new DataSet();

            ds = DataAccess.GetDataSet(ConnectionString, "IM_Select_Categories", null);
            if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count > 0)
            {
                Repeater1.DataSource = ds.Tables[0];
                Repeater1.DataBind();
            }           
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblCategoryID = (Label)e.Item.FindControl("lblCategoryID");

                HyperLink hyperlnk = (HyperLink)e.Item.FindControl("hlEdit");
                hyperlnk.NavigateUrl = "~/EditCategory?catId=" + lblCategoryID.Text;

                LinkButton lnkbtn = (LinkButton)e.Item.FindControl("lnkdelete");
                lnkbtn.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this record?')");
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                Label lblCategoryID = (Label)e.Item.FindControl("lblCategoryID");
                DeleteCategoryById(Convert.ToInt32(lblCategoryID.Text));
            }
        }
        private void DeleteCategoryById(int CategoryId)
        {
            SqlParameter[] parameters =
                         {  
                             new SqlParameter("@CategoryID", SqlDbType.Int) { Value = CategoryId }                           
                         };

            if (DataAccess.ExecuteNonQuery(ConnectionString, "IM_Delete_Category", parameters))
            {
                BindData();
            }
        }
    }
}
