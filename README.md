# 图片批量上传

##核心代码

###index.html
```
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Flash图片批量上传</title>
</head>
<body>
    <div id="content"></div>
</body>
</html>
<script src="swfobject.js"></script>
<script>
    window.onload = function () {
        var params = {
            uploadServerUrl: "upload.aspx",
            jsFunction: "CallBack",
            filter: "*.jpg;*.gif;*.png"
        }
        swfobject.embedSWF("uploadImage.swf", "content", "1000", "300", "10.0.0", "expressInstall.swf", params);
    }

    function CallBack() {
        alert('上传成功！');
    }
</script>
```

###upload.aspx.cs
```
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
```
