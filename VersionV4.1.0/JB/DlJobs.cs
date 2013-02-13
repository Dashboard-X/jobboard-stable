using System.Collections;
using System.Linq;

namespace JB
{
    public class DlJobs
    {
        //get details
        public ArrayList Getmultitexts(string jobid)
        {
            var __res = new joblightEntities();
            var _alist = new ArrayList();
            IQueryable<TB_JOBTABLE> __query = from item in __res.TB_JOBTABLE
                                           where item.IDJOBS == jobid
                                           select item;

            foreach (TB_JOBTABLE _item in __query)
            {
                _alist.Add(_item.TERMID);
            }

            return _alist;
        }

        //make sure job belongs to current recruiter
        public string Checkrecruiter(string __jobid)
        {
            var __res = new joblightEntities();
            IQueryable<VW_JOBTORECRUITER> __query = from item in __res.VW_JOBTORECRUITER
                                                 where item.IDJOBS == __jobid
                                                 select item;

            return Enumerable.FirstOrDefault(__query.Select(_item => _item.EMPID));
        }
    }
}