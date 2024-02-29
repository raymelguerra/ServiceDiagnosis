using CuallimexManagement.Entities;
using Microsoft.AspNetCore.Components;

namespace CuallimexManagement.Pages
{
    public partial class ReportPage : ComponentBase
    {
        public Report Model { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Model == null)
            {
                Model = new();
            }
        }

        public void Save()
        {
            var t = Model;
            Console.WriteLine("Algo");
        }
        //private DateTime? ExecDate
        //{
        //    set { if (value.HasValue) job.ExecDate = DateOnly.FromDateTime(value.Value); }
        //    get { return job.ExecDate.ToDateTime(TimeOnly.MinValue); }
        //}
        //public DateTime ReportDate
        //{
        //    get { return Model.EntryReason != null ? Model.ReportDate : DateTime.Now; }
        //    set { if (value.has) job.ExecDate = DateOnly.FromDateTime(value.Value); } 
        //}
    }
}
