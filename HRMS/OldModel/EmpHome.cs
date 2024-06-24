using Blazored.LocalStorage;
using HRMS;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Drawing;
using System.Reflection.Metadata;
using System.Xml.Linq;


namespace HRMS
{

    public class Loginpage
    {
        //Forget Page 👇
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter the valid email address")]
        public string ForgetEmail { get; set; }
        [Required]
        public string ForgetOtp { get; set; }
        public string ForgetPass { get; set; }

        //Login Page 👇
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter the valid email address")]
        public string LoginEmail { get; set; }

        //Signup Page 👇
        [RegularExpression(@"[0-9]{10}$", ErrorMessage = "Mobile Number contains number only")]
        public string SignupMobilenumber { get; set; }

        public string SignupPassword { get; set; }
    }
    public class Taskdetails
    {
        public int? complete {  get; set; }
        public int? incomplete {  get; set; }
        public int? pending { get; set; }
        public int? details { get; set; }

    }

    public class Appointment
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string Text { get; set; }
    }

	public class holiday
	{
		public int? Sno { get; set; }
		public string Holiday { get; set; }
        public string Day { get; set; }
        public string HolidayDate { get; set;}
	}



	public class Interview
	{
		public string name { get; set; }
		public string role { get; set; }
		public string status { get; set; }

	}

	public class MyData
	{
		public string Name { get; set; }
		public int? LeaveTaken { get; set; }
		public int? RemainingLeave { get; set; }
	}

	public class hodteamlev
	{
		public string Name { get; set; }
		public int? Noofleave { get; set; }
		public int? Noofpresent { get; set; }
	}

	public class totalteamlev
	{
		public string Name { get; set; }
		public int? Totalleave { get; set; }
		public int? Totalpresent { get; set; }
	}

	public class Totalemp
	{
		public string Gender { get; set; }
		public int? Male { get; set; }
		public int? Female { get; set; }
	}

	public class TotalStatistics
	{
		public string Department { get; set; }
		public int? Total { get; set; }
		public int? Finish { get; set; }
		public double a { get; set; }
		public double b { get; set; }

	}


	public class login
	{
		public int? Roleid { get; set; }
		public string Name { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		
		public string NewPassword { get; set; }


		public string NewRePassword { get; set; }
		public string Role { get; set; }


	}

	

	public class policy
	{
		public string RolePolicy { get; set; }
		public string NamePolicy { get; set; }
	}


	public class ticket
	{
		public string Name { get; set; }
		public string Subject { get; set; }
		public string Priority { get; set; }
		public string Prioritycolor { get; set; }
		public string Status { get; set; }
		public string Statuscolor { get; set; }
	}

	public class attendance
	{
		public string Name { get; set; }
		public DateOnly? Date { get; set; }
		public TimeOnly? TimeIn { get; set; }
		public TimeOnly? TimeOut { get; set; }

	}


	public class completestatus
	{
		public string Name { get; set; }
		public int? Projects { get; set; }
		public int? Clients { get; set; }
		public int? Employee { get; set; }

	}



	/*Vivin*/
	public class Roles
	{
		public string Role { get; set; } = string.Empty;
	}


    public class Searchproject
    {
        public string Projectname { get; set; } = string.Empty;
        public string Empname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

    }

    public class Createprojects
    {
        public string Projectname { get; set; } = string.Empty;
        public string Clientname { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Desc { get; set; } = string.Empty;
    }
    public class Complete
	{
		public int Sno { get; set; } = 0;
		public string Projectname { get; set; } = string.Empty;
		public string Due { get; set; } = string.Empty;
		public string Completeddate { get; set; } = string.Empty;
		public string Duration { get; set; } = string.Empty;
		public string Client { get; set; } = string.Empty;
	}

	public class Members
	{
		public int Sno { get; set; } = 0;
		public string Path { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Role { get; set; } = string.Empty;
		public string Module { get; set; } = string.Empty;

	}

	public class Image
	{
		public string Lead { get; set; } = string.Empty;
	}

	public class Pendingtask
	{
		public int Sno { get; set; } = 0;
		public string Taskname { get; set; } = string.Empty;
		public int Progress { get; set; } = 0;
		public string Due { get; set; } = string.Empty;
		public string Path { get; set; } = string.Empty;
	}

	public class Onprocess
	{
		public int Sno { get; set; } = 0;
		public string Taskname { get; set; } = string.Empty;
		public int Progress { get; set; } = 0;
		public string Due { get; set; } = string.Empty;
		public string Path { get; set; } = string.Empty;
	}

	public class Review
	{
		public int Sno { get; set; } = 0;
		public string Taskname { get; set; } = string.Empty;
		public int Progress { get; set; } = 0;
		public string Due { get; set; } = string.Empty;
		public string Path { get; set; } = string.Empty;
	}

	public class Completed
	{
		public int Sno { get; set; } = 0;
		public string Taskname { get; set; } = string.Empty;
		public int Progress { get; set; } = 0;
		public string Due { get; set; } = string.Empty;
		public string Path { get; set; } = string.Empty;
	}

	public class Addtasks
	{
		public int Id { get; set; } = 0;
		public string Members { get; set; } = string.Empty;
		public DateTime? Date { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Path { get; set; } = string.Empty;
	}

	public class Tasks
	{
		public int Id { get; set; } = 0;
		public string Status { get; set; } = string.Empty;
		public string Task { get; set; } = string.Empty;
		public string Trash { get; set; } = string.Empty;
		public string Icon { get; set; } = MudBlazor.Icons.Material.Filled.CheckCircleOutline;
	}


    /*Nivetha*/
    public class barchartmodel
    {
        public string Attendence { get; set; }
        public int Absent { get; set; }
        public int Present { get; set; }
    }
    public class donutmodel
    {
        public string donutleavetype { get; set; }
        public double[] data { get; set; }
        public string[] labels { get; set; }

    }
    public class LeaveModel
    {
        public string Name { get; set; }

        public string startdate { get; set; }

        public string enddate { get; set; }

        public string leavetype { get; set; }

        public string reason { get; set; }
        public string DetailedReason { get; set; }

        public string status { get; set; }
    }
    public class EmployeeModel
    {
        public string EmpId { get; set; }
        public string image { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }
		public string EmployeeCode { get; set; }
        public string email { get; set; }

        public string Department { get; set; }

        public string joiningdate { get; set; }

        public string mobile { get; set; }
        public int? Salary { get; set; }
    }
    public class progressmodel
    {
        public string title { get; set; }
        public int consumeddays { get; set; }
        public int remainingdays { get; set; }
        public int days { get; set; }

    }
    public class cardmodel
    {
        public string Empid { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string leavetype { get; set; }
        public string role { get; set; }
        public string reason { get; set; }
        public string DetailedReason { get; set; }
        public int dayscount { get; set; }
        public string date { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public string status { get; set; }

    }

    /*Nandha*/

    public class Models
	{
		public string TicketType { get; set; } = string.Empty;
		public string TicketCount { get; set; } = string.Empty;
		public int progressvalue { get; set; }
		public string TicketColor { get; set; } = string.Empty;
		public string ProgressColor { get; set; } = string.Empty;

	}
	public class TicketDescription1
	{
		public string Icon { get; set; } = string.Empty;
		public string Heading { get; set; } = string.Empty;
		public string StatusMethod { get; set; } = string.Empty;
		public string CreatedBy { get; set; } = string.Empty;



	}
	public class AttachedFiles
	{
		public string imagename { get; set; } = string.Empty;
	}
    public class Element
	{
		public int? Sno {  get; set; }
		public string TicketId { get; set; } = string.Empty;
		public string TicketSubject { get; set; } = string.Empty;
		public string EmployeeName { get; set; } = string.Empty;
		public string Department { get; set; } = string.Empty;
        public bool btn { get; set; }
        public string RaiseDate { get; set; } = string.Empty;
		public string SolvedDate { get; set; } = string.Empty;
		public string Priority { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;
		public string Edit { get; set; } = string.Empty;
		public string Delete { get; set; } = string.Empty;


	}
	public class BioData
	{
		/*BioData*/
		[Required(ErrorMessage = "First Name is required")]
		[MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
		[MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
		[RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Last Name is required")]
		[MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
		[MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
		[RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
		public string LastName { get; set; } = string.Empty;
		[Required]

		public int Age { get; set; }
		[Required(ErrorMessage = "Enter the Gender")]
		public string Gender { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string State { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		[Required]
		[RegularExpression(@"[0-9]{6}$", ErrorMessage = "PinCode contains number only")]
		public string Pincode { get; set; } = string.Empty;
		[Required]
		[RegularExpression(@"[0-9]{10}$", ErrorMessage = "Mobile Number contains number only")]
		public string MobileNumber { get; set; } = string.Empty;
		public string Department { get; set; } = string.Empty;
		public string Designation { get; set; } = string.Empty;
		public string Reportsto { get; set; } = string.Empty;
		public string EmployeeId { get; set; } = string.Empty;
		public string DOJ { get; set; } = string.Empty;

		/*Personal Information*/
		public string PassportNo { get; set; } = string.Empty;
		public string Passportexpdate { get; set; } = string.Empty;
		public string PersonalNumber { get; set; } = string.Empty;
		public string Nationality { get; set; } = string.Empty;
		public string Religion { get; set; } = string.Empty;
		public string MaritalStatus { get; set; } = string.Empty;

		/*Emergency Contact*/
		public string PrimaryName { get; set; } = string.Empty;
		public string Relationship { get; set; } = string.Empty;
		public string EmgNumber1 { get; set; } = string.Empty;
		public string SecondaryName { get; set; } = string.Empty;
		public string Relationship1 { get; set; } = string.Empty;
		public string EmgNumber2 { get; set; } = string.Empty;

		/*Bank Information*/
		public string BankName { get; set; } = string.Empty;
		public string Accountno { get; set; } = string.Empty;
		public string IFSCcode { get; set; } = string.Empty;
		public string PANno { get; set; } = string.Empty;


	}

	/*Jega*/
	public class AttendanceDetails
	{
		public int Sno { get; set; }
		public string EmpId { get; set; }
		public string EmpName { get; set; }
		public DateOnly date { get; set; }
		public TimeOnly PunchIn { get; set; }
		public TimeOnly PunchOut { get; set; }
		public string Image { get; set; }
		public string WorkingHours { get; set; }
	}

	/*Gokul*/

	public class ReimbursementModel
	{
		public string img { get; set; } = string.Empty;

		public string Employeename { get; set; } = string.Empty;

	}

	public class Reimbursementclaim
	{
		public string img { get; set; }

		public string employeename { get; set; }

		public string empid { get; set; }


		public string ExpenseType { get; set; }

		public string[] ExpenceDropdown = { "Internet", "Travel" };


		public int? BillNo { get; set; }

		public DateTime? PickedDate { get; set; }

		public int? BillAmount { get; set; }


	}

	public class Reimbursementhistory
	{
		public int ClaimId { get; set; }

		public DateOnly BillDate { get; set; }

		public string Expense { get; set; }

		public string Status { get; set; }

		public int ClaimAmount { get; set; }

	}

	public class Reimbursementrequest
	{
		public string Empid { get; set; }

		public string EmployeeName { get; set; }

		public string Designation { get; set; }

		public int ClaimAmount { get; set; }

		public string BillNo { get; set; }

		public string Expense { get; set; }

		public DateOnly Billdate { get; set; }

		public string Status { get; set; } = "Pending";

		public bool Accpt { get; set; }

		public bool declin { get; set; }

		public string color { get; set; } = "background-color:#ffaa00;";
	}


	public class Companypolicy
	{
		public String Roles { get; set; }

		public int? LeaveLimit { get; set; }

		public int? leaveeditvalue { get; set; }



		public String Role { get; set; }

		public int? internet { get; set; }

		public int? Travel { get; set; }




		public int? reimInternetvalue { get; set; }


		public int? reimTravelvalue { get; set; }

	}


	/*deepak*/

	public class JobApplicationForm
	{
		[Required]
		[StringLength(15, ErrorMessage = "Length should be less and equal to 15")]
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
		public string FirstName { get; set; }

		[StringLength(15, ErrorMessage = "Length should be less and equal to 15")]
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
		public string MiddleName { get; set; }
		[Required]
		[StringLength(15, ErrorMessage = "Length should be less and equal to 15")]
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
		public string LastName { get; set; }
		[Required]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter valid email")]
		public string Email { get; set; }

		[RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Only 10 digit number is required")]
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
		public string City { get; set; }
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
		public string state { get; set; }
		[RegularExpression(@"[0-9]{6}$", ErrorMessage = "Only Number is required")]
		public string pinCode { get; set; }
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
		public string country { get; set; }
		public string position { get; set; }

		public string Referalid { get; set; }


	}
	public class recruiterpage
	{
		public int serialnum { get; set; }
		public string AppliedName { get; set; }
		public string AppliedEmail { get; set; }
		public string AppliedRole { get; set; }
		public string Resume { get; set; }
		public string status { get; set; }

	}
    /*public class Hrdetails1 { 
		public string img { get; set;}
		public string hrid {  get; set;}
		public string hrname { get; set;}
	}*/
    public class Onboardingform
    {
        [Required]
        [StringLength(15, ErrorMessage = "Length should be less and equal to 15")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string ConfiredFirstname { get; set; }


        [StringLength(15, ErrorMessage = "Length should be less and equal to 15")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string ConfiredMiddlename { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Length should be less and equal to 15")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string ConfiredLastname { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter valid email")]
        public string ConfiredEmail { get; set; }
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Only 10 digit number is required")]
        public string ConfiredPhone { get; set; }
        [Required]
        public string ConfiredAddress { get; set; }




        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string ConfiredCity { get; set; }
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string ConfiredState { get; set; }
        [RegularExpression(@"[0-9]{6}$", ErrorMessage = "Only Number is required")]
        public string Confiredpincode { get; set; }
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string Confiredcountry { get; set; }
        public string ConfiredRole { get; set; }
        public string ConfiredDepartment { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{2}$", ErrorMessage = "Only Number is required")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "Enter the Gender")]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string Religion { get; set; }


        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string Nationality { get; set; }


        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string MaritalStatus { get; set; }

        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string Pgcollagename { get; set; }

        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string Pgcourse { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string ugcollagename { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string ugcourse { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string Hsrschoolname { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string Hsrcourse { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string Sslcschoolname { get; set; }
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Only 10 digit number is required")]
        public string EmergencyContact { get; set; }


        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string Relation { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
        public string Bankname { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]$", ErrorMessage = "Only number is required")]
        public string Salary { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{18}$", ErrorMessage = "Only 18 number is required")]
        public string AccountNumber { get; set; }
        [Required]
        public string Ifsccode { get; set; }
        public string pfaccountnumber { get; set; }




    }
    public class HronboardingApproval
	{
		public int serialnum { get; set; }
		public string Approvalname { get; set; }
		public string Approvalemail { get; set; }
		public string Approvalrole { get; set; }
		public string Approvaldepartment { get; set; }
		public string ApprovalDateofjoining { get; set; }
	}
	public class Voluntaryresignation
	{
		[Required]
		[StringLength(15, ErrorMessage = "Length should be less and equal to 15")]
		[RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Enter a vaild Id")]
		public string Employeeid { get; set; }
		[Required]
		[StringLength(15, ErrorMessage = "Length should be less and equal to 15")]
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
		public string Employeename { get; set; }
		[Required]
		[StringLength(15, ErrorMessage = "Length should be less and equal to 15")]
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
		public string EmployeeDepartment { get; set; }
		[Required]
		[StringLength(15, ErrorMessage = "Length should be less and equal to 15")]
		[RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only Alphabets is required")]
		public string Employeerole { get; set; }


		public DateTime DateofJoining { get; set; }
		public DateTime Lastdateofwork { get; set; }
		public string reason { get; set; }
		public bool isChecked1 { get; set; }
		public bool isChecked2 { get; set; }
		public bool isChecked3 { get; set; }
		public bool isChecked4 { get; set; }
		public bool isChecked5 { get; set; }
	}
	public class ResignationAccpect
	{
		public int serialnum { get; set; }
		public string empid { get; set; }
		public string employeename { get; set; }
		public string joiningdate { get; set; }
		public string lastworkingdate { get; set; }
		public string reason { get; set; }
	}

	/*Hema*/

	public class payslip
	{
		public int? Number { get; set; }
		public string empimage { get; set; }
		public string Name { get; set; }
		public string Id { get; set; }

		public string Email { get; set; }

		public DateOnly Joindate { get; set; }
		public string Role { get; set; }
		public SqlMoney Salary { get; set; }
		public string PFACno { get; set; }
		public string BankAC { get; set; }

		public string UAN { get; set; }
		public bool slipdisable { get; set; }
		public bool show { get; set; }
	}
	public class payslipdet
	{
		public Decimal basicsalary { get; set; }
		public Decimal houserent { get; set; }
		public Decimal conveyance { get; set; }
		public Decimal otherallowance { get; set; }
		public Decimal tax { get; set; }
		public Decimal providentfund { get; set; }

		public Decimal ESI { get; set; }

		public Decimal loan { get; set; }
		public Decimal TotalEarnings => (basicsalary + houserent + conveyance + otherallowance);
		public Decimal TotalDeductions => (tax + providentfund + ESI + loan);
		public Decimal NetSalary => TotalEarnings - TotalDeductions;

	}
	public class editsalary
	{
		public string EmployeeCode { get; set; }
		public string Name { get; set; }

		public decimal NetSalary { get; set; }
		public decimal Basic { get; set; }
		public decimal HouseRent { get; set; }
		public decimal Conveyance { get; set; }
		public decimal OtherAllowance { get; set; }
		public decimal ESI { get; set; }
		public decimal Tax { get; set; }
		public decimal pf { get; set; }
		public decimal Others { get; set; }
		public decimal Loan { get; set; }

		public decimal Reimbursement { get; set; }

	}
	public class addemployee
	{
		public string Name { get; set; }
		public string Id { get; set; }
		public string role { get; set; }
		public string Email { get; set; }
		public DateOnly Joindate { get; set; }
	}
	public class salarydet
	{
		public string Name { get; set; }
		public String Id { get; set; }
		public decimal? Basic { get; set; }
		public decimal houserent { get; set; }
		public decimal conveyance { get; set; }
		public int? experiance { get; set; }
		public decimal reimbursement { get; set; }
		public decimal? totalearnings => (Basic + houserent + conveyance + experiance * 1000 + reimbursement);

		public decimal ESI { get; set; }
		public decimal PF { get; set; }

		public int? Leave { get; set; }

		public decimal tax { get; set; }
		public decimal? totaldeductions => ESI + Basic * 5 % +Leave * 200 + tax - PF;
		public decimal? NetSalary => totalearnings - totaldeductions;
	}
}
