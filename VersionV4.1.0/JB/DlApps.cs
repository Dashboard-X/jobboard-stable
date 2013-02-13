using System;
using System.Globalization;
using System.Linq;

namespace JB
{
    public class DlApps
    {
        //this adds applications to apps table
        public void AddApplication(string guids, string firstname, string lastname, string dateofbirth,
                                   string profilesummary,
                                   string mxdocid, string aAppEmail)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_APPLICATIONS
                {
                    DTENTERED = DateTime.Now.Date,
                    AFIRSTNAME = firstname,
                    ALASTNAME = lastname,
                    ADATEOFBIRTH = Convert.ToDateTime(dateofbirth).Date,
                    APROFILESUMMARY = profilesummary,
                    DOCUMENTID = mxdocid,
                    AAPPLICATIONEMAIL = aAppEmail,
                    IDAPPLICATIONS = guids
                };

            __ent.TB_APPLICATIONS.Add(__rtab);
            __ent.SaveChanges();
        }

        //this adds applications for candidates, who are registered in db.
        public void AddApplicationcan(string guids, string licandidateid, string firstname, string lastname,
                                      string dateofbirth,
                                      string profilesummary, string mxdocid, string aAppEmail)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_APPLICATIONS
                {
                    DTENTERED = DateTime.Now.Date,
                    AFIRSTNAME = firstname,
                    ALASTNAME = lastname,
                    ADATEOFBIRTH = Convert.ToDateTime(dateofbirth).Date,
                    APROFILESUMMARY = profilesummary,
                    DOCUMENTID = mxdocid,
                    AAPPLICATIONEMAIL = aAppEmail,
                    LICANDIDATEID = licandidateid,
                    IDAPPLICATIONS = guids
                };

            __ent.TB_APPLICATIONS.Add(__rtab);
            __ent.SaveChanges();
        }

        //This maps applications table to jobs table, update lookup
        public void AddApplicationMapping(string guids ,string jobid, string applicationid)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_APPJOBMAPPER {IDAPPLICATIONS = applicationid, IDJOBS = jobid, IDAPPJOBMAPPER = guids};

            __ent.TB_APPJOBMAPPER.Add(__rtab);
            __ent.SaveChanges();
        }

        //get maximum document id
        /* public int Getmaxdocid()
        {
            var __res = new joblightEntities();
            var __query = (from item in __res.documents
                           select item).Max();

            return Convert.ToInt32(__query) + 1;
        }

        //get maximum application id
        public int Getmaxappid()
        {
            var __res = new joblightEntities();
            var __query = (from item in __res.applications
                           select item).Max();

            return Convert.ToInt32(__query) + 1;
        }
        */

        //add document like resumes etc.
        public void Adddocuments(string guids, string documentname, string doc_url)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_DOCUMENTS {DOCUMENTNAME = documentname, DOC_URL = doc_url, DOCUMENTID = guids};

            __ent.TB_DOCUMENTS.Add(__rtab);
            __ent.SaveChanges();
        }

        //this get current application from it's id
        public object GetApplication(string applicationname, int _lowlimit, int _highlimit)
        {
            var __res = new joblightEntities();

            IQueryable<VW_GETAPP> __query = (from gap in __res.VW_GETAPP
                                          where gap.EMPID == applicationname
                                          orderby gap.IDAPPLICATIONS
                                          select gap).Skip(_lowlimit).Take(_highlimit);
            return __query.ToList();
        }

        //this get current application count for dataset
        public int GetApplicationcount(string applicationname)
        {
            var __res = new joblightEntities();
            int __query = (from item in __res.VW_GETAPP
                           where item.EMPID == applicationname
                           select item).Count();

            return Convert.ToInt32(__query);
        }

        //get get application details for jobseeker
        public string[] Getapplicationdetails(string applyid)
        {
            var __res = new joblightEntities();
            var _alist = new string[2];
            IQueryable<VW_GETAPP> __query = from item in __res.VW_GETAPP
                                         where item.IDAPPLICATIONS == applyid
                                         select item;

            foreach (var _item in __query)
            {
                _alist[0] = _item.IDAPPLICATIONS.ToString(CultureInfo.InvariantCulture);
                _alist[1] = _item.APROFILESUMMARY;
                break;
            }

            return _alist;
        }
    }
}