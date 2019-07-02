using System.Collections.Generic;
using FP.Models.Worklog;

namespace FP.ViewModels
{
    public class WorklogViewModel
    {
        #region  Properties

        public List<WorklogModel> Worklogs { get; set; }
        public int WeeklyQuota { get; set; }
        public int MonthlyQuota { get; set; }

        #endregion
    }
}