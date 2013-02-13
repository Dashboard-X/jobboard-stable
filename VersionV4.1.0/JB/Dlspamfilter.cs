using System;

namespace JB
{
    public class Dlspamfilter
    {
        //add to spam table for later review of jobs voilating rules
        public void Addspamrec(string guids, int spamid, string spamreason, string remaddr, string usragnt, string pageid)
        {
            var __res = new joblightEntities();
            var __rtab = new TB_SPAMREPORT
                {
                    SPAMINDEX = spamid,
                    SPAMREASON = spamreason,
                    DTENTERED = DateTime.Now,
                    IPUSER = remaddr,
                    USERAGENTS = usragnt,
                    JOBID = pageid,
                    IDTB_SPAMREPORT = guids
                };

            __res.TB_SPAMREPORT.Add(__rtab);
            __res.SaveChanges();
        }
    }
}