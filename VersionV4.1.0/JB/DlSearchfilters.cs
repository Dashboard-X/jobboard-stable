using System;
using System.Linq;

namespace JB
{
    public class DlSearchfilters
    {
        public int Getalljobcount()
        {
            var __res = new joblightEntities();
            int _alist = 0;
            int __query = (from item in __res.VW_AGGREGATEDMPAGE
                           select item).Count();

            _alist = Convert.ToInt32(__query);
            return _alist;
        }

        //simple single job
        public object GetJobssingle(int _lowlimit, int _highlimit)
        {
            var __res = new joblightEntities();
            IQueryable<VW_AGGREGATEDMPAGE> __query = (from apage in __res.VW_AGGREGATEDMPAGE
                                                   orderby apage.DTENTEREDDATE
                                                   select apage).Skip(_lowlimit).Take(_highlimit);

            return __query.ToList();
        }
    }
}