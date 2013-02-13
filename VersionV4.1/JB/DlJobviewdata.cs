using System;
using System.Linq;

namespace JB
{
    public class DlJobviewdata
    {
        //this adds detail page views
        public void Addview(string recid, string guids)
        {
            var __res = new joblightEntities();
            var __rtab = new TB_JOBVIEWS {EMPID = recid, DTENTERED = DateTime.Now.Date, IDJOBVIEWS = guids};

            __res.TB_JOBVIEWS.Add(__rtab);
            __res.SaveChanges();
        }

        //this gets detail page views for a job
        public object GetJobviewdata(string sEmpId)
        {
            var __res = new joblightEntities();

            var __query = from j in __res.TB_JOBVIEWS
                          where j.EMPID == sEmpId
                          group j by j.DTENTERED
                          into nitem
                          select new
                              {
                                  empid = nitem.Max(o => o.EMPID),
                                  dtentered = nitem.Key,
                                  jobviews = nitem.Select(q => q.IDJOBVIEWS)
                              };

            return __query.ToList();
        }
    }
}