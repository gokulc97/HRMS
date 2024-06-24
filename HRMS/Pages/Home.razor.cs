using HRMS.Model;
using ApexCharts;

using Microsoft.JSInterop;
using MudBlazor;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using static MudBlazor.CategoryTypes;


namespace HRMS.Pages
{

	public partial class Home
	{

		List<HRMS.Model.CardModel> LeaveList = new List<HRMS.Model.CardModel>();
		List<HRMS.Model.Barchart> TodayLeave01 = new List<HRMS.Model.Barchart>();
		CardModel cardobj = new CardModel();
		HRMS.Model.CardModel cardlist = new HRMS.Model.CardModel();
		List<HRMS.Model.Chartmodel> chartmodel = new List<HRMS.Model.Chartmodel>();
		HRMS.Model.Chartmodel chartlist = new HRMS.Model.Chartmodel();


		List<HRMS.Model.Dashboard> AnnualLeaveCount = new List<HRMS.Model.Dashboard>();

		//Leave cards

		public async Task chart()
		{
			string apiUrl = $"api/Leave/chartviewsick/{User.UserName}";
			using var client = HttpClientFactory.CreateClient("API");
			var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadFromJsonAsync<List<HRMS.Model.Chartmodel>>();
				chartmodel = json;
				StateHasChanged();
			}
			else
			{
				Snackbar.Add("Failed");
			}
		}

		//apex chart
		public async Task AnnualCount()
		{
			try
			{
				string apiUrl = $"api/Dashboards/EmpLeaveDetails/{User.Id}";
				using var client = HttpClientFactory.CreateClient("API");
				var response = await client.GetAsync(apiUrl).ConfigureAwait(false);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadFromJsonAsync<List<HRMS.Model.Dashboard>>();
					AnnualLeaveCount = json;
					StateHasChanged();
				}
				else
				{
					Console.WriteLine("Failed to fetch data from API.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
		}


		//the barchart method
		public async Task TodayLeaveCount()
		{
			try
			{
				const string apiUrl = "api/Leave/Barchart";
				using var client = HttpClientFactory.CreateClient("API");
				var response = await client.GetAsync(apiUrl).ConfigureAwait(false);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadFromJsonAsync<List<HRMS.Model.Barchart>>();
					TodayLeave01 = json;
					StateHasChanged();
				}
				else
				{
					Console.WriteLine("Failed");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		//the card model
		public async Task Leave()
		{
			try
			{
				string apiUrl = $"api/Leave/Cards/{User.RoleId}/{User.Id}";

				using var client = HttpClientFactory.CreateClient("API");

				var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadFromJsonAsync<List<HRMS.Model.CardModel>>();
					LeaveList = json;
					StateHasChanged();
				}
				else
				{
					Snackbar.Add("Failed");
				}
			}
			catch (Exception ex)
			{
				Snackbar.Add($"Exception: {ex.Message}");
			}
		}

		//update the status=reject
		public async Task updateStatus()
		{
			try
			{
				visible = false;
				cardlist.Status = "Rejected";
				string apiUrl = $"api/Leave/{cardlist.EmpId}";
				using var client = HttpClientFactory.CreateClient("API");
				var response = await client.PutAsJsonAsync(apiUrl, cardlist).ConfigureAwait(false);
				if (response.IsSuccessStatusCode)
				{
					await Leave();
					Snackbar.Add("Updated Successfully");
				}
				else
				{
					Snackbar.Add("Failed To Update");
				}
			}
			catch (Exception ex)
			{
				Snackbar.Add($"Exception: {ex.Message}");
			}
		}
		//update status=accept
		public async Task updateStatusapprove()
		{
			try
			{
				visible = false;
				cardlist.Status = "Accepted";
				string apiUrl = $"api/Leave/{cardlist.EmpId}";
				using var client = HttpClientFactory.CreateClient("API");
				var response = await client.PutAsJsonAsync(apiUrl, cardlist).ConfigureAwait(false);
				if (response.IsSuccessStatusCode)
				{
					await Leave();
					Snackbar.Add("Updated Successfully");
				}
				else
				{
					Snackbar.Add("Failed To Update");
				}
			}
			catch (Exception ex)
			{
				Snackbar.Add($"Exception: {ex.Message}");
			}
		}

		private bool visible;
		private void Dialog() => visible = true;
		void Submit() => visible = false;

		private DialogOptions dialogOptions = new()
		{
			FullWidth = true
		};

		//getting value and assigning to card
		public void valuefunc(int Empid)
		{
			foreach (var items in LeaveList)
			{
				var list = LeaveList.FirstOrDefault(x => x.EmpId == Empid);
				if (list != null)
				{
					cardlist.EmpId = list.EmpId;
					cardlist.EmployeeCode = list.EmployeeCode;
					cardlist.FirstName = list.FirstName;
					cardlist.Leavetypename = list.Leavetypename;
					cardlist.Reason = list.Reason;
					cardlist.Detailedreason = list.Detailedreason;
					cardlist.StartDate = list.StartDate;
					cardlist.NoOfDays = list.NoOfDays;
					cardlist.Designation = list.Designation;
				}
			}
			Dialog();


		}


		public bool emptycard = true;
		public string id;


		private void OpenDialog()
		{
			var options = new DialogOptions { CloseOnEscapeKey = true, Position = DialogPosition.TopCenter, MaxWidth = MaxWidth.Medium, FullWidth = true };
			DialogService.Show<Applyleave>("", options);
		}

		protected override async Task OnInitializedAsync()
		{
			var userJson = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "user");
			User = JsonSerializer.Deserialize<LoginDetails>(userJson);
			await TodayLeaveCount();
			await chart();
			await AnnualCount();
			await Leave();
        }




		private async Task GoBack()
		{
			await JSRuntime.InvokeVoidAsync("history.back");
		}
	}
}