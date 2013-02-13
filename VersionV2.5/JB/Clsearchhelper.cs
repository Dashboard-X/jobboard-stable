using System.Data;

namespace JB
{
    public class Clsearchhelper
    {
        /// <summary>
        /// move get jobssingle in here
        /// </summary>
        /// <param name="addedcrit"></param>

        public DataSet Applycriteriafilter(string addedcrit, int lowlimit, int highlimit)
        {
            var _qry = @"select distinct idjobs,stitle,sshortdescription,sfreetext, sdescription,dtentereddate,ssalarytext,sminsal,employeeid, smaxsal, applicationvolume from aggregatedmulti where "
                  + addedcrit + " limit "+lowlimit+","+highlimit+"; ";
            var __dls = new DlSearchfilters();
            return __dls.QuerySearch(_qry);
        }

        public DataSet Applytitlefilter(string titles, int lowlimit, int highlimit)
        {
            var _qry = @"select distinct idjobs,stitle,sshortdescription,sfreetext, sdescription,dtentereddate,ssalarytext,sminsal,employeeid, smaxsal, applicationvolume from aggregatedmulti where match(sfreetext) against('" +
                    titles + "') limit "+lowlimit+","+highlimit+"; ";
            var __dls = new DlSearchfilters();
            return __dls.QuerySearch(_qry);
        }

        public DataSet Applytitlefilter(string titles, string addedcrit, int lowlimit, int highlimit)
        {
            var _qry =
                @"select distinct idjobs,stitle,sshortdescription,sfreetext, sdescription,dtentereddate,ssalarytext,sminsal,employeeid, smaxsal, applicationvolume from aggregatedmulti where match(sfreetext) against('" +
                titles + "') and " + addedcrit + " limit "+lowlimit+","+highlimit+"; ";
            var __dls = new DlSearchfilters();
            return __dls.QuerySearch(_qry);
        }

        public int Applycriteriafiltercount(string addedcrit, int lowlimit, int highlimit)
        {
            var _qry = @"select count(distinct(idjobs)) as total from aggregatedmulti where "
                  + addedcrit + " limit " + lowlimit + "," + highlimit + "; ";
            var __dls = new DlSearchfilters();
            return __dls.Getalljobcount(_qry);
        }

        public int Applytitlefiltercount(string titles, int lowlimit, int highlimit)
        {
            var _qry = @"select count(distinct(idjobs)) as total from aggregatedmulti where match(sfreetext) against('" +
                    titles + "') limit " + lowlimit + "," + highlimit + "; ";
            var __dls = new DlSearchfilters();
            return __dls.Getalljobcount(_qry);
        }

        public int Applytitlefiltercount(string titles, string addedcrit, int lowlimit, int highlimit)
        {
            var _qry =
                @"select count(distinct(idjobs)) as total from aggregatedmulti where match(sfreetext) against('" +
                titles + "') and " + addedcrit + " limit " + lowlimit + "," + highlimit + "; ";
            var __dls = new DlSearchfilters();
            return __dls.Getalljobcount(_qry);
        }
    
    }
}