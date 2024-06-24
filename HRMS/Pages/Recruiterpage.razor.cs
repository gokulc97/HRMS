using HRMS.Model;

using Microsoft.JSInterop;
using MudBlazor;
using System.Net.Http.Json;

namespace HRMS.Pages
{
	public partial class Recruiterpage
	{
		public string success = "Accepted";
		public string Reject = "Declined";

		recruiterpage obj2 = new recruiterpage();


		List<recruiterpage> Hraccept = new List<recruiterpage>
	{
		new recruiterpage{serialnum=1,AppliedName="Deepak",AppliedEmail="deepak@gmail.com",AppliedRole="Sales",Resume="Deepak.pdf",status="pending"},
		new recruiterpage{serialnum=2,AppliedName="bavan",AppliedEmail="deepak@gmail.com",AppliedRole="Sales",Resume="Deepak.pdf",status="pending"},
		new recruiterpage{serialnum=3,AppliedName="gokul",AppliedEmail="deepak@gmail.com",AppliedRole="Sales",Resume="Deepak.pdf",status="pending"},
		new recruiterpage{serialnum=4,AppliedName="Deepak",AppliedEmail="deepak@gmail.com",AppliedRole="Sales",Resume="Deepak.pdf",status="pending"},

	};
		
		public string serach;
		private Func<recruiterpage, bool> qf => y =>
		{
			if (string.IsNullOrWhiteSpace(serach))

				return true;

			if (y.AppliedName.Contains(serach, StringComparison.OrdinalIgnoreCase))

				return true;
			return false;
		};

		List<HronboardingApproval> Hronboard = new List<HronboardingApproval>
	{
		new HronboardingApproval{serialnum=1,Approvalname="Deepak",Approvalemail="deepak@gmail.com",Approvalrole="Sales",Approvaldepartment="TL",ApprovalDateofjoining="2024-09-23"},
		new HronboardingApproval{serialnum=2,Approvalname="bavan",Approvalemail="deepak@gmail.com",Approvalrole="Sales",Approvaldepartment="HR",ApprovalDateofjoining="2024-09-23"},
		new HronboardingApproval{serialnum=3,Approvalname="gokul",Approvalemail="deepak@gmail.com",Approvalrole="Sales",Approvaldepartment="Project head",ApprovalDateofjoining="2024-09-23"},
		new HronboardingApproval{serialnum=4,Approvalname="Deepak",Approvalemail="deepak@gmail.com",Approvalrole="Sales",Approvaldepartment="UI/UX",ApprovalDateofjoining="2024-09-23"},

	};


		List<ResignationAccpect> resign = new List<ResignationAccpect>
	{
		new ResignationAccpect{serialnum=1,empid="kpr101",employeename="Deepak",joiningdate="2024-06-12",lastworkingdate="2024-8-12",reason="salary"},
		new ResignationAccpect{serialnum=2,empid="kpr102",employeename="Bavan",joiningdate="2024-06-12",lastworkingdate="2024-8-12",reason="salary"},
		new ResignationAccpect{serialnum=3,empid="kpr103",employeename="Mukesh",joiningdate="2024-06-12",lastworkingdate="2024-8-12",reason="salary"},
		new ResignationAccpect{serialnum=4,empid="kpr104",employeename="Rakesh",joiningdate="2024-06-12",lastworkingdate="2024-8-12",reason="salary"}
	};

		private async Task GoBack()
		{
			await JSRuntime.InvokeVoidAsync("history.back");
		}
		public void accept()
		{
			Snackbar.Add("Data is Accepted Successfully", Severity.Success);
		}
		public void Reject1()
		{
			Snackbar.Add("Data is Reject Successfully", Severity.Error);
		}
		List<HRMS.Model.EmployeeList> Onboardingaccept = new List<HRMS.Model.EmployeeList>();
		HRMS.Model.EmployeeList Hronboarding = new HRMS.Model.EmployeeList();
		public async Task Employeeview()
		{
			const string apiUrl = "api/EmployeeDetailsTable";
			using var client = HttpClientFactory.CreateClient("API");

			var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadFromJsonAsync<List<HRMS.Model.EmployeeList>>();
				Onboardingaccept = json;
				StateHasChanged();
			}
			else
			{
				Snackbar.Add("Failed");
			}
		}
		private Func<HRMS.Model.EmployeeList, bool> qf1 => z =>
		{
			if (string.IsNullOrWhiteSpace(serach))

				return true;

			if ($"{z.Employeecode}{z.Firstname1}{z.Dateofjoining}".Contains(serach, StringComparison.OrdinalIgnoreCase))

				return true;


			return false;
		};
		public bool afteraccept = false;
		public bool afterreject = false;
		protected override async Task OnInitializedAsync()
		{
			await Employeeview();
			await resignation();
		}
		List<HRMS.Model.ResignationTableview> Resignation = new List<HRMS.Model.ResignationTableview>();
		HRMS.Model.ResignationTableview Resignationapprove = new HRMS.Model.ResignationTableview();
		public async Task resignation()
		{
			const string apiUrl = "api/Resignation";
			using var client = HttpClientFactory.CreateClient("API");

			var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadFromJsonAsync<List<HRMS.Model.ResignationTableview>>();
				Resignation = json;
				StateHasChanged();
			}
			else
			{
				Snackbar.Add("Failed");
			}
		}

		private Func<HRMS.Model.ResignationTableview, bool> qf2 => x =>
		{
			if (string.IsNullOrWhiteSpace(serach))

				return true;

			if ($"{x.EmployeeCode}{x.EmployeeName}{x.LastDateOfWorking}{x.Designation}{x.ReasonForResign}".Contains(serach, StringComparison.OrdinalIgnoreCase))

				return true;

			return false;
		};
		//put//
		public async void Acceptput(string Empcode)
		{
			var Accept = Resignation.FirstOrDefault(x => x.EmployeeCode == Empcode).EmpId;

			if (Accept != null)
			{

				string apiUrl5 = $"api/Resignation/ {Accept}";
				using var client = HttpClientFactory.CreateClient("API");
				var response = await client.PutAsJsonAsync(apiUrl5, Resignationapprove).ConfigureAwait(false);
				if (response.IsSuccessStatusCode)
				{


					Snackbar.Add($"{Resignationapprove.EmployeeCode} Data is Accepted Successfully", Severity.Success);
					afteraccept = true;
					afterreject = true;

					await resignation();
					StateHasChanged();
				}
			}
			else
			{
				Snackbar.Add("Failed");
			}

		}

		//Delete
		public async void RejectPut(string Empcode)
		{
			var deleteid = Resignation.FirstOrDefault(x => x.EmployeeCode == Empcode).EmpId;

			if (deleteid != null)
			{

				string apiUrl5 = $"api/Resignation/Reject/{deleteid}";
				using var client = HttpClientFactory.CreateClient("API");
				var response = await client.PutAsJsonAsync(apiUrl5, Resignationapprove).ConfigureAwait(false);
				if (response.IsSuccessStatusCode)
				{


					Snackbar.Add($"{Resignationapprove.EmployeeCode} Data is Rejected Successfully", Severity.Error);
					afteraccept = true;
					afterreject = true;

					await resignation();
					StateHasChanged();
				}
			}
			else
			{
				Snackbar.Add("Failed");
			}

		}

		//Dialog box//
		private bool visible;
		private void OpenDialog() => visible = true;
		void Submit() => visible = false;
		private DialogOptions dialogOptions = new() { FullWidth = true };

		public string Religion;
		public string Nationality;
		public string Emergencycontact;
		public string Salary;
		public string Bankname;
		public string Accountnumber;
		public string Ifsccode;
		public string Pfaccount;


		public void Dialogfunc(string Employeecode)
		{
			var list = Onboardingaccept.FirstOrDefault(x => x.Employeecode == Employeecode);
			Religion = list.Religion1;
			Nationality = list.Nationality1;
			Emergencycontact = list.Emergencycontact1;
			Salary = list.Salary1;
			Bankname = list.Bankname1;
			Accountnumber = list.Accountnumber1;
			Ifsccode = list.Ifsccode1;
			Pfaccount = list.Pfaccount1;
			OpenDialog();
		}

	}
}