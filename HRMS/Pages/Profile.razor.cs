using Microsoft.JSInterop;
using MudBlazor;
using System.Net.Http.Json;
using System.Net.Http;
using HRMS.Model;
using System.Text.Json;

namespace HRMS.Pages
{
    public partial class Profile
    {

        BioData biodata = new BioData();
        List<HRMS.Model.EmployeeList> ProfileList = new List<HRMS.Model.EmployeeList>();
        string[] Familytable = { "Name", "Relationship", "Date of Birth", "Phone" };
        string[] Familyvalue = { @"Mathan Brother 21-12-2001 7402109346", };

        List<BioData> biodatas = new List<BioData>
        {
             new BioData{FirstName="Mithun",LastName="selvan",Age=23,Gender="Male",Email="mithun@gmail.com",Address="8/A Sitra Airport, Coimbatore",State="TamilNadu",City="India",Pincode="641001",MobileNumber="8056391763",Department="Team Leader",Designation="UI/UX Developer",Reportsto="Hemalatha",EmployeeId="BYT001",DOJ="1st Jan 2023"}
        };

        List<BioData> personalinfo = new List<BioData>
        {
            new BioData{PassportNo="9876543210",Passportexpdate="2030-05-01",PersonalNumber="8056391763",Nationality="Indian",Religion="Hindu",MaritalStatus="Unmarried"}
        };
        List<BioData> emergencycontact = new List<BioData>
        {
            new BioData{PrimaryName="John",Relationship="Father",EmgNumber1="9876543210",SecondaryName="Doe",Relationship1="Brother",EmgNumber2="9876543210"}
        };
        List<BioData> bankinfo = new List<BioData>
        {
            new BioData{BankName="HDFC Bank",Accountno="1234567891112",IFSCcode="HDFC001234",PANno="6GBDA219870"}
        };


        public async Task ProfileDetails()
        {
            try
            {
                string apiUrl = $"api/EmployeeDetailsTable/Employeeoveralldetails/{User.UserName}";
                using var client = HttpClientFactory.CreateClient("API");
                var response = await client.GetAsync(apiUrl).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadFromJsonAsync<List<HRMS.Model.EmployeeList>>();
                    ProfileList = json;
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
        protected override async Task OnInitializedAsync()
        {
            var userJson = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "user");
            User = JsonSerializer.Deserialize<LoginDetails>(userJson);
            await ProfileDetails();
        }
            private void OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, Position = DialogPosition.TopCenter, MaxWidth = MaxWidth.Medium, FullWidth = true };
            DialogService.Show<EditProfile>("", options);
        }
        private async Task GoBack()
        {
            await JSRuntime.InvokeVoidAsync("history.back");
        }

    }

}