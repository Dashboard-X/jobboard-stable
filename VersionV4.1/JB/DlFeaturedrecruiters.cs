using System;
using System.Globalization;
using System.Linq;

namespace JB
{
    public class DlFeaturedrecruiters
    {
        //get recruiters logo for profiles form
        public string Getrecformimage(string recsids)
        {
            string __temprecid = recsids.ToString(CultureInfo.InvariantCulture);

            var __res = new joblightEntities();
            string _alist = string.Empty;
            IQueryable<VW_RECARTICLES> __query = from item in __res.VW_RECARTICLES
                                                 where item.ARTICLE_DATA == __temprecid
                                                 select item;

            foreach (VW_RECARTICLES _item in __query)
            {
                _alist = _item.ARTICLE_DATA;
            }

            return _alist;
        }

        //this gets featured recruiters
        public object GetFRecs()
        {
            var __res = new joblightEntities();
            DateTime _tempdate = DateTime.Now.Date;
            var __query = (from rec in __res.TB_RECRUITERS
                           join art in __res.TB_ARTICLES
                               on rec.SARTICLEID equals art.SARTICLEID
                           join jt in __res.TB_JOBTABLE
                               on rec.EMPID equals jt.EMPID
                           join j in __res.TB_JOBS
                               on jt.IDJOBS equals j.IDJOBS
                           where j.SJOBENDDATE >= _tempdate && jt.CATID == 10000
                           select new
                               {
                                   Sponsored = rec.SRECRUITERNAME,
                                   art.ARTICLE_DATA,
                                   j.STITLE,
                                   descr = j.SSHORTDESCRIPTION,
                                   j.IDJOBS
                               }).Take(2);
            return __query.ToList();
        }
    }
}