using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpFileCollection files = Request.Files;
            if (files.Count == 0)
            {
                Response.Write("错误请求，未检查到客户端提交的文件信息！");
                Response.End();
            }


            string path = Server.MapPath("UploadImagesList");

            HttpPostedFile file = files[0];

            if (file != null && file.ContentLength > 0)
            {
                string savePath = path + "/" + Guid.NewGuid().ToString() + "_" + Request.Form["fileName"];
                file.SaveAs(savePath);
            }
        }
    }
}