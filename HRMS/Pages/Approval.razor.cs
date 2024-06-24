using ApexCharts;

using HRMS.Model;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using MudBlazor;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using static MudBlazor.CategoryTypes;



namespace HRMS.Pages;

public partial class Approval
{
	List<HRMS.Model.ListModel> SingleLeaveList = new List<HRMS.Model.ListModel>();
	List<HRMS.Model.Chartmodel> chartmodel = new List<HRMS.Model.Chartmodel>();
	HRMS.Model.Chartmodel chartlist = new HRMS.Model.Chartmodel();


	List<HRMS.Model.Dashboard> AnnualLeaveCount = new List<HRMS.Model.Dashboard>();

	public async Task Leavelist()
	{
		string apiUrl = $"api/Leave/Employeelist/{User.Id}";
		using var client = HttpClientFactory.CreateClient("API");
		var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

		if (response.IsSuccessStatusCode)
		{
			var json = await response.Content.ReadFromJsonAsync<List<HRMS.Model.ListModel>>();
			SingleLeaveList = json;
			StateHasChanged();
		}
		else
		{
			Snackbar.Add("Failed");
		}
	}


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


	protected override async Task OnInitializedAsync()
	{
		var userJson = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "user");
		User = JsonSerializer.Deserialize<LoginDetails>(userJson);
		await LoadDataAsync();




	}
	private async Task LoadDataAsync()
	{
		var tasks = new List<Task>
			{
			  AnnualCount(),
			 Leavelist(),
			 chart()

	};

		await Task.WhenAll(tasks).ConfigureAwait(false);
	}


	private int Index = -1;
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
				Console.WriteLine("Leave Graph Done");
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


	private void OpenDialog()
	{
		var options = new DialogOptions { CloseOnEscapeKey = true, Position = DialogPosition.TopCenter, MaxWidth = MaxWidth.Medium, FullWidth = true };
		DialogService.Show<Applyleave>("", options);
	}

	private async Task GoBack()
	{
		await JSRuntime.InvokeVoidAsync("history.back");
	}
}