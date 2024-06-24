using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using System.Net.Http;
using HRMS.Model;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Reflection.Emit;

namespace HRMS.Pages
{
    public partial class EditProfile
    {
        public int? age;
        bool success;
        string[] errors = { };
        MudForm form;


        BioData biodata = new BioData();
        List<HRMS.Model.EmployeeList> ProfileList = new List<HRMS.Model.EmployeeList>();
        EmployeeList profie=new EmployeeList();

        protected override async Task OnInitializedAsync()
        {
            var userJson = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "user");
            User = JsonSerializer.Deserialize<LoginDetails>(userJson);
            await ProfileDetails();
           foreach(var i in ProfileList)
            {
                profie.Firstname1 = i.Firstname1;
                profie.Lastname1 = i.Lastname1;
                profie.Email1 = i.Email1;
                profie.Accountnumber1 = i.Accountnumber1;
                profie.Pfaccount1 = i.Pfaccount1;
                profie.Bankname1 = i.Bankname1;
                profie.Ifsccode1= i.Ifsccode1;
                profie.Pgcollegename1 = i.Pgcollegename1;
                profie.Pgcoursename1 = i.Pgcoursename1;
                profie.Pgstartdate1 = i.Pgstartdate1;
                profie.Pgenddate1 = i.Pgenddate1;
                profie.Ugcollagename1 = i.Ugcollagename1;
                profie.Ugcoursename1 = i.Ugcoursename1;
                profie.Ugstartdate1 = i.Ugstartdate1;
                profie.Ugenddate1 = i.Ugenddate1;
                profie.HSCschoolname1 = i.HSCschoolname1;
                profie.HSCcoursename1 = i.HSCcoursename1;
                profie.HSCstartdate1 = i.HSCstartdate1;
                profie.HSCenddate1 = i.HSCenddate1;
                profie.SSLCschoolname1 = i.SSLCschoolname1;
                profie.SSLCstartdate1 = i.SSLCstartdate1;
                profie.SSLCenddate1 = i.SSLCenddate1;
                profie.Emergencycontact1 = i.Emergencycontact1;
                profie.Relationship1 = i.Relationship1;
                profie.Maritalstatus1 = i.Maritalstatus1;
                profie.Nationality1 = i.Nationality1;
                profie.Dateofbirth1 = i.Dateofbirth1;
                profie.Role1 = i.Role1;
                profie.Designation1 = i.Designation1;
                profie.Experience=i.Experience;
                profie.Mobilenumber1 = i.Mobilenumber1;
            };


        }
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

        //put

        public async Task Editput1()
        {
            try
            {
                 
                 profie.EmpId = User.Id;
                

                    string apiUrl5 = $"api/EmployeeDetailsTable/{User.Id}";
                    using var client = HttpClientFactory.CreateClient("API");
                    var response = await client.PutAsJsonAsync(apiUrl5, profie).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {

                    await ProfileDetails();
                        Snackbar.Add($"Data is Updated Successfully", Severity.Success);


                        StateHasChanged();
                    }
                    else
                    {
                        Snackbar.Add("ERROR" ,Severity.Error);
                    }
                

            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

        }
       
        public async Task Editput2()
        {
            profie.EmpId = User.Id;
            try
            {
                
                

                    string apiUrl5 = $"api/EmployeeDetailsTable/Edit1/{User.Id}";
                    using var client = HttpClientFactory.CreateClient("API");
                    var response = await client.PutAsJsonAsync(apiUrl5, profie).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {

                    await ProfileDetails();
                    Snackbar.Add($"Data is Updated Successfully", Severity.Success);


                        StateHasChanged();
                    }
              
               
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

        }

        public async Task Editput3()
        {
        
            try
            {

                

                    string apiUrl5 = $"api/EmployeeDetailsTable/Edit2/{User.Id}";
                    using var client = HttpClientFactory.CreateClient("API");
                    var response = await client.PutAsJsonAsync(apiUrl5, profie).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {

                    await ProfileDetails();
                    Snackbar.Add("Data is Updated Successfully", Severity.Success);


                        StateHasChanged();
                    }
               
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

        }

        //
      

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();


        List<BioData> biodatas = new List<BioData>
        {
             new BioData{FirstName="Mithun",LastName="selvan",Age=23,Gender="Male",Email="mithun07@gmail.com",Address="8/A Chitra Airport, Coimbatore",State="TamilNadu",City="India",Pincode="641001",MobileNumber="8056391763",Department="TL",Designation="UI/UX Developer",Reportsto="Hemalatha",EmployeeId="Bytes420",DOJ="1st Jan 2023",
            PassportNo="9876543210",Passportexpdate="2030-05-01",PersonalNumber="8056391763",Nationality="Indian",Religion="Hindu",MaritalStatus="Unmarried",
           PrimaryName="John",Relationship="Father",EmgNumber1="9876543210",SecondaryName="Doe",Relationship1="Brother",EmgNumber2="9876543210",BankName="HDFC Bank",Accountno="1234567891112",IFSCcode="HDFC001234",PANno="6GBDA219870"}
        };


    }
}