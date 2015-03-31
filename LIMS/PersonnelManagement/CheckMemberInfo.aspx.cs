using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LIMS.PersonnelManagement
{
    /// <summary>
    ///  本页面担任两个功能，一是获取所有成员的信息列表，二是查询成员的信息列表
    /// </summary>
    public partial class CheckMemberInfo : System.Web.UI.Page
    {
        public string EditStr = "";
        public string DeleteStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //生成语句
            GetPage();
            string IsPost = Request["IsPost"];
            string IsSearch = Request["IsSearch"];

            if (!string.IsNullOrEmpty(IsPost))
            {
                /*获取所有成员的信息列表*/
                if (string.IsNullOrEmpty(IsSearch))
                {
                    int rows = Convert.ToInt32(Request["rows"]);
                    int page = Convert.ToInt32(Request["page"]);
                    int sum = 0;
                    List<CheckMemberInfor> allMenmber = new List<CheckMemberInfor>();
                    allMenmber = new BLL.Operator.CInformationManger().CheckMemberInfo(rows, page,ref sum);
                    //判断是否有数据，这里还需要在处理
                    if (allMenmber.Count <= 0)
                    {
                        Response.Write("数据错误");
                    }
                    else
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        string json = js.Serialize(allMenmber);
                        StringBuilder res = new StringBuilder();
                        res.Append("{\"rows\":").Append(json).Append(",\"total\":\"").Append(sum.ToString()).Append("\"}");
                        Response.Write(res.ToString());
                        Response.End();
                    }
                }
                else {
                    /*查询制定条件的成员，即搜索功能*/
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string checkName = Request["checkName"];
                    string value = Request["value"];
                    List<CheckMemberInfor> selectMember = new List<CheckMemberInfor>();
                    selectMember = new BLL.Operator.CInformationManger().SelectMember(checkName, value);
                    if (selectMember.Count <= 0)
                    {
                        Response.Write("数据错误");
                    }
                    else
                    {
                        string json = js.Serialize(selectMember);
                        StringBuilder res = new StringBuilder();
                        res.Append("{\"rows\":").Append(json).Append(",\"total\":\"").Append("1").Append("\"}");
                        Response.Write(res.ToString());
                        Response.End();
                    }

                }

            }
        }

//循环进行判断是否有权限
        public void GetPage()
        {
            List<string> sessionID = (List<string>)Session["sessionDutyId"];
            foreach (string str in sessionID)
            {
                //如果职务是10001或者是10002则具有权限
                if (str.Equals("BLL.Role.CAdmin") || str.Equals("BLL.Role.CCEO"))
                {
                    EditStr ="<a id=\"edit\" href=\"#\" title=\"编辑\" class=\"easyui-linkbutton\" iconcls=\"icon-edit\" plain=\"true\"></a>";
                    DeleteStr = "<a id=\"remove\" href=\"#\" class=\"easyui-linkbutton\" title=\"删除成员\" iconcls=\"icon-remove\"   plain=\"true\"></a>";
                }
            }
        }


    }
}