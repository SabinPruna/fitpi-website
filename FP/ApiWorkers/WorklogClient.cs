using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FP.Models;
using FP.Models.Fitbit;
using FP.Models.Worklog;

namespace FP.ApiWorkers
{
    public partial class ApiClient
    {
        public async Task<List<WorklogModel>> GetWorklogMonth(string month)
        {
            Uri requestUrl = CreateWorklogRequestUri(string.Format(CultureInfo.InvariantCulture, $"list/{month}"));
            return await GetAsync<List<WorklogModel>>(requestUrl);
        }

        public async Task<List<WorklogModel>> GetWorklog()
        {
            Uri requestUrl = CreateWorklogRequestUri(string.Format(CultureInfo.InvariantCulture, $"list"));
            return await GetAsync<List<WorklogModel>>(requestUrl);
        }

        public  async Task<Message<WorklogModel>> SaveWorklog(WorklogModel model)
        {

                Uri requestUrl = CreateWorklogRequestUri(string.Format(CultureInfo.InvariantCulture,
                    $"addlog/{model.Month}/{model.Date}/{model.Start}/{model.End}/{model.Duration}"));
                 return await PostAsync(requestUrl, model);

        }
    }
}