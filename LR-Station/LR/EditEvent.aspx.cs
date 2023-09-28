using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LR
{
    public partial class EditEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString.Count > 0)
                    {
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtDateTime.Value = Request.QueryString["datetime"].ToString();
                        cbxBabyFHS.Value = Request.QueryString["fhs"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtHN.Text = Request.QueryString["hn"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }
    }
}