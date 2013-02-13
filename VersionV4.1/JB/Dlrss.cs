using System;
using System.Globalization;
using System.Linq;

namespace JB
{
    public class Dlrss
    {
        public string[,] Getrss()
        {
            var __res = new joblightEntities();
            var _alist = new string[4,10];
            IQueryable<TB_JOBS> __query = (from item in __res.TB_JOBS
                                       where item.SJOBENDDATE > DateTime.Now
                                       orderby item.SJOBENDDATE descending
                                       select item).Take(10);
            int i = 0;
            foreach (var _item in __query)
            {
                _alist[0, i] = _item.IDJOBS.ToString(CultureInfo.InvariantCulture);
                _alist[1, i] = _item.STITLE;
                _alist[2, i] = _item.SSHORTDESCRIPTION;
                _alist[3, i] = _item.SJOBENDDATE.ToString();
                i++;
            }

            return _alist;
        }
    }
}