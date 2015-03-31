/**  。
* V_MemberInformation.cs
*
* 功 能： N/A
* 类 名： V_MemberInformation
*
* Ver    变更日期2014年7月26日
* ───────────────────────────────────
* V0.01  2014-07-26 10:48:38 
*/
using System;
namespace Model
{
	/// <summary>
	/// V_MemberInformation:实体类
	/// </summary>
	
	public partial class V_MemberInformation
	{
		public V_MemberInformation()
		{}
		#region Model
		private string _stunum;
		private string _stuname;
		private string _gender;
		private string _qqnum;
		private string _email;
		private string _loginpwd;
		private DateTime _birthday;
		private string _photopath;
		private string _class;
		private DateTime _jointime;
		private DateTime _endtime;
		private string _major;
		private string _counselor;
		private string _headteacher;
		private string _undergraduatetutor;
		private string _telephonenumber;
		private string _homphonenumber;
		private string _familyaddress;
		private string _techdirename;
		private string _techlevelname;
		private string _guidename;
        //private int _dutyid;
		/// <summary>
		/// 
		/// </summary>
		public string StuNum
		{
			set{ _stunum=value;}
			get{return _stunum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StuName
		{
			set{ _stuname=value;}
			get{return _stuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQNum
		{
			set{ _qqnum=value;}
			get{return _qqnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginPwd
		{
			set{ _loginpwd=value;}
			get{return _loginpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhotoPath
		{
			set{ _photopath=value;}
			get{return _photopath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Class
		{
			set{ _class=value;}
			get{return _class;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime JoinTime
		{
			set{ _jointime=value;}
			get{return _jointime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Major
		{
			set{ _major=value;}
			get{return _major;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Counselor
		{
			set{ _counselor=value;}
			get{return _counselor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HeadTeacher
		{
			set{ _headteacher=value;}
			get{return _headteacher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UndergraduateTutor
		{
			set{ _undergraduatetutor=value;}
			get{return _undergraduatetutor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TelephoneNumber
		{
			set{ _telephonenumber=value;}
			get{return _telephonenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HomPhoneNumber
		{
			set{ _homphonenumber=value;}
			get{return _homphonenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyAddress
		{
			set{ _familyaddress=value;}
			get{return _familyaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TechDireName
		{
			set{ _techdirename=value;}
			get{return _techdirename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TechLevelName
		{
			set{ _techlevelname=value;}
			get{return _techlevelname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuideName
		{
			set{ _guidename=value;}
			get{return _guidename;}
		}
		/// <summary>
		/// 
		/// </summary>
        //public int DutyId
        //{
        //    set{ _dutyid=value;}
        //    get{return _dutyid;}
        //}
		#endregion Model

	}
}

