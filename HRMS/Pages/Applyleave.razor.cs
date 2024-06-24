using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using System.Net.Http;
using HRMS.Model;
using Microsoft.JSInterop;
using System.Text.Json;

namespace HRMS.Pages
{


    public partial class Applyleave
    {

        HRMS.Model.Leave leaveEvent = new HRMS.Model.Leave();
        List<HRMS.Model.LeaveTypeDetails> leaveType = new List<HRMS.Model.LeaveTypeDetails>();
        HRMS.Model.LeaveTypeDetails LeaveId = new HRMS.Model.LeaveTypeDetails();
        protected override async Task OnInitializedAsync()
        {
            var userJson = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "user");
            User = JsonSerializer.Deserialize<LoginDetails>(userJson);
            await LeaveType();


        }
        public async Task LeaveType()
        {
            try
            {
                const string apiUrl = "api/Leave/LeaveTypeDetails";
                using var client = HttpClientFactory.CreateClient("API");
                var response = await client.GetAsync(apiUrl).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadFromJsonAsync<List<HRMS.Model.LeaveTypeDetails>>();
                    leaveType = json;
                  
                    StateHasChanged();
                }
                else
                {
                    Snackbar.Add("Saved Failed");
                    Console.WriteLine("EOM Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task Saves()
        {
            try
            {
                var selectedLeaveType = leaveType.FirstOrDefault(x => x.Id == LeaveId.Id);
                leaveEvent.LeaveType = selectedLeaveType.Id;
                leaveEvent.Id = User.Id;
                const string apiUrl = "api/Leave";
                using var client = HttpClientFactory.CreateClient("API");
                var response = await client.PostAsJsonAsync(apiUrl, leaveEvent).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Snackbar.Add("Saved Successfully");
                }
                else
                {
                    Snackbar.Add("Failed");
                }
            }
            catch (Exception ex)
            {
				Snackbar.Add("Form not Filled",Severity.Error);
			}
			Cancel();
        }



        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();

        LeaveModel obj = new LeaveModel();
    }
}