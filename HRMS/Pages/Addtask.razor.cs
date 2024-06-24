using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HRMS.Pages
{
    public partial class Addtask
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        void Cancel() => MudDialog.Close(DialogResult.Ok(true));

        Addtasks add = new Addtasks();

        List<Addtasks> task = new List<Addtasks>
    {
        new Addtasks {Id=1,Members="Kannna" ,Path="images/Project/member1.cms"},
        new Addtasks {Id=2,Members="Jega",Path="images/Project/member2.jpg"},
        new Addtasks {Id=3,Members="Nandha",Path="images/Project/member3.jpg"},
        new Addtasks {Id=4,Members="Gokul",Path="images/Project/member4.jpg"},
    };

        public string mem;

        private string[] members =
        {
       "Kannna","Jega","Nandha","Gokul"
    };



        private async Task<IEnumerable<string>> Search1(string value)
        {
            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(value))
                return members;
            return members.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }

        private IEnumerable<Addtasks> avatar => task.Where(a => a.Members == add.Name);

    }
}