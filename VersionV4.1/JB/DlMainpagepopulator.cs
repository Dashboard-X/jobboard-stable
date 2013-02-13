using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace JB
{
    public class DlMainpagepopulator
    {
        //delete jobs
        public void Deletejobs(string jobid)
        {
            var __res = new joblightEntities();
            IQueryable<TB_JOBTABLE> __rval =
                __res.TB_JOBTABLE.Where(_c => _c.IDJOBS == jobid && _c.CATID != 10000 && _c.TERMID != 10000);

            foreach (var _jobitem in __rval)
            {
                __res.TB_JOBTABLE.Remove(_jobitem);
            }
            __res.SaveChanges();
        }

        //get total recs
        public int Getcountrecs()
        {
            var __res = new joblightEntities();
            int __query = (from item in __res.TB_RECRUITERS
                           select item).Count();

            return __query;
        }

        //gets max jobs
        /*
        public int Getmaxjobid()
        {
            var __res = new joblightEntities();
            var __query = (from item in __res.jobs
                           select item).Max();

            return Convert.ToInt32(__query) + 1;
        }
          */

        //add jobs
        public void Insertjobs(string idjobs, string sTitle, string sShortDescription, string sDescription,
                               string ssalarytext, int ssalarymin, int ssalarymax, string sref, string startdate,
                               string enddate)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_JOBS
                {
                    IDJOBS = idjobs,
                    STITLE = sTitle,
                    SSHORTDESCRIPTION = sShortDescription,
                    SDESCRIPTION = sDescription,
                    DTENTEREDDATE = DateTime.Now,
                    SSALARYTEXT = ssalarytext,
                    SMINSAL = ssalarymin,
                    SMAXSAL = ssalarymax,
                    SREF = sref,
                    SJOBSTARTDATE = Convert.ToDateTime(startdate),
                    SJOBENDDATE = Convert.ToDateTime(enddate)
                };

            __ent.TB_JOBS.Add(__rtab);
            __ent.SaveChanges();
        }

        //add job rec assignments
        public void Insertjobmapping(string idjobs, int catid, int litermid, string empid)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_JOBTABLE() {IDJOBS = idjobs, CATID = catid, TERMID = litermid, EMPID = empid};

            __ent.TB_JOBTABLE.Add(__rtab);
            __ent.SaveChanges();
        }

        //get jobdetails page
        public string Getcurrrec(string empid)
        {
            var __res = new joblightEntities();
            string _alist = string.Empty;
            var __query = from itema in __res.TB_RECRUITERS
                          join itemb in __res.TB_ARTICLES
                              on itema.SARTICLEID equals itemb.SARTICLEID
                          where itema.EMPID == empid
                          select new
                              {
                                  itemb.ARTICLE_DATA
                              };

            foreach (var _item in __query)
            {
                _alist = _item.ARTICLE_DATA;
                break;
            }

            return _alist;
        }

        //get rec details page
        public string[] Getdetailspage(string jobid)
        {
            var __res = new joblightEntities();
            var _alist = new string[8];
            var __query = from j in __res.TB_JOBS
                          join jt in __res.TB_JOBTABLE
                              on j.IDJOBS equals jt.IDJOBS
                          join rec in __res.TB_RECRUITERS
                              on jt.EMPID equals rec.EMPID
                          where j.IDJOBS == jobid
                          select new
                              {
                                  j.STITLE,
                                  j.SREF,
                                  j.SDESCRIPTION,
                                  j.SJOBSTARTDATE,
                                  rec.SRECRUITERNAME,
                                  rec.SEMAILADDRESS,
                                  rec.SWEBSITE,
                                  rec.EMPID
                              };

            foreach (var _item in __query)
            {
                _alist[0] = _item.STITLE;
                _alist[1] = _item.SREF;
                _alist[2] = _item.SDESCRIPTION;
                _alist[3] = _item.SJOBSTARTDATE.ToString();
                _alist[4] = _item.SRECRUITERNAME;
                _alist[5] = _item.SEMAILADDRESS;
                _alist[6] = _item.SWEBSITE;
                _alist[7] = _item.EMPID.ToString(CultureInfo.InvariantCulture);
                break;
            }

            return _alist;
        }

        //get details page
        public string Getdetailspagecats(string jobid, int cats)
        {
            var __res = new joblightEntities();
            var __sb = new StringBuilder();
            IQueryable<VW_GETDETAILSPAGES> __query = from item in __res.VW_GETDETAILSPAGES
                                                 where item.IDJOBS == jobid && item.CATID == cats
                                                 select item;

            foreach (var _item in __query)
            {
                __sb.Append(_item.STERM);
                __sb.Append("<br/>");
            }

            return __sb.ToString();
        }

        //get details page
        public string Getdetailspagecats(string jobid, int cats, int jobsal)
        {
            var __res = new joblightEntities();
            var __sb = new StringBuilder();
            IOrderedQueryable<VW_GETDETAILSPAGES> __query = from item in __res.VW_GETDETAILSPAGES
                                                        where item.IDJOBS == jobid && item.CATID == cats
                                                        orderby item.MINRANGE
                                                        select item;
            int i = 0;
            int j = 0;
            int k = 0;
            foreach (var _item in __query)
            {
                if (i == 0)
                {
                    k = Convert.ToInt32(_item.MINRANGE);
                }

                j = Convert.ToInt32(_item.MAXRANGE);
                i++;

                __sb.Append(k);
                __sb.Append(" • ");
                __sb.Append(j);
            }

            return __sb.ToString();
        }

        //fill in jobs form
        public string[] Filljobform(string jobid)
        {
            var __res = new joblightEntities();
            var _alist = new string[7];
            IQueryable<TB_JOBS> __query = from item in __res.TB_JOBS
                                      where item.IDJOBS == jobid
                                      select item;

            foreach (TB_JOBS _item in __query)
            {
                _alist[0] = _item.STITLE;
                _alist[1] = _item.SSHORTDESCRIPTION;
                _alist[2] = _item.SJOBSTARTDATE.ToString();
                _alist[3] = _item.SJOBENDDATE.ToString();
                _alist[4] = _item.SSALARYTEXT;
                _alist[5] = _item.SREF;
                _alist[6] = _item.SDESCRIPTION;
                break;
            }

            return _alist;
        }

        public object GetSalary()
        {
            var __res = new joblightEntities();

            IQueryable<TB_TERMS> __query = from t in __res.TB_TERMS
                                       where t.TERMID >= 6000 && t.TERMID < 7000
                                       select t;
            return __query.ToList();
        }

        //location checkbox populate
        public object GetLocations()
        {
            var __res = new joblightEntities();

            IQueryable<TB_TERMS> __query = from t in __res.TB_TERMS
                                       where t.TERMID > 4000 && t.TERMID < 5000
                                       select t;

            return __query.ToList();
        }

        //industries checkbox populate
        public object GetIndustries()
        {
            var __res = new joblightEntities();

            IQueryable<TB_TERMS> __query = from t in __res.TB_TERMS
                                       where t.TERMID >= 5000 && t.TERMID < 6000
                                       select t;

            return __query.ToList();
        }

        //get jobs
        public object GetJobs()
        {
            var __res = new joblightEntities();

            IQueryable<VW_GETJOBS> __query = from j in __res.VW_GETJOBS
                                         select j;

            return __query;
        }

        //get recruiterid by name
        public string RecName(string usrname)
        {
            var __res = new joblightEntities();
            string _alist = string.Empty;
            var __query = (from rec in __res.TB_RECRUITERS
                           join rmap in __res.TB_RECUSERMAPPER
                               on rec.EMPID equals rmap.EMPID
                           join usr in __res.TB_USERS
                               on rmap.IDUSERS equals usr.IDUSERS
                           where usr.UUSERNAME == usrname
                           select new
                               {
                                   rec.EMPID
                               }).Take(1);

            foreach (var _item in __query)
            {
                _alist = _item.EMPID;
            }

            return _alist;
        }

        //get recruiter inactive jobs
        public object GetrecArchive(string sEmpID, int _lowlimit, int _highlimit)
        {
            var __res = new joblightEntities();

            IQueryable<VW_GETJOBSSINGLE> __query = (from g in __res.VW_GETJOBSSINGLE
                                                 where g.EMPID == sEmpID
                                                 select g
                                                ).Skip(_lowlimit).Take(_highlimit);
            return __query.ToList();
        }

        //get recruiter inactiv job count
        public int GetrecArchivecount(string sEmpID)
        {
            var __res = new joblightEntities();

            int __query = (from g in __res.VW_GETJOBSSINGLE
                           where g.EMPID == sEmpID
                           select g).Count();

            return __query;
        }

        //get recruiter active jobs
        public object GetrecActive(string sEmpID, int _lowlimit, int _highlimit)
        {
            var __res = new joblightEntities();

            IQueryable<VW_GETJOBSSINGLEARCH> __query = (from g in __res.VW_GETJOBSSINGLEARCH
                                                     where g.EMPLOYEEID == sEmpID
                                                     orderby g.IDJOBS
                                                     select g).Skip(_lowlimit).Take(_highlimit);
            return __query.ToList();
        }

        //get recruiter inactiv job count
        public int GetrecActivecount(string sEmpID)
        {
            var __res = new joblightEntities();
            int __query =
                (from g in __res.VW_GETJOBSSINGLE
                 where g.EMPID == sEmpID
                 select g).Count();

            return __query;
        }

        //gets max recruiters
        /*public int RecHasRows()
        {
            var __res = new joblightEntities();

            var __query =
                (from g in __res.recruiters
                 select g).Max(_o => _o.EmpID);

            return Convert.ToInt32(__query);
        }*/

        //max user id
        /*public int Maxuserid()
        {
            var __res = new joblightEntities();

            var __query =
                (from g in __res.users
                 select g).Max(_o => _o.idUsers);

            return Convert.ToInt32(__query) + 1;
        }

        //max candidate id
        public int Maxcandidateid()
        {
            var __res = new joblightEntities();

            var __query =
                (from g in __res.users
                 select g).Max(_o => _o.uCandidateID);

            return Convert.ToInt32(__query) + 1;
        }
        */

        //add candidates
        public void Insertcandidates(string maxcanid, string cCandidateName, string cFirstName, string cLastName,
                                     string cAddress1, string cAddress2, string cAddress3, string cTown, string cCounty,
                                     string cCountry, string cPostcode, string sWebsite, string hphone, string wphone,
                                     string dateofbirth)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_CANDIDATES
                {
                    IDCANDIDATES = maxcanid,
                    CCANDIDATENAME = cCandidateName,
                    CFIRSTNAME = cFirstName,
                    CLASTNAME = cLastName,
                    CADDRESS1 = cAddress1,
                    CADDRESS2 = cAddress2,
                    CADDRESS3 = cAddress3,
                    CTOWN = cTown,
                    CCOUNTY = cCounty,
                    CPOSTCODE = cPostcode,
                    CCOUNTRY = cCountry,
                    CHOMEPHONE = hphone,
                    CWORKPHONE = wphone,
                    CDTENTERED = DateTime.Now,
                    CDATEOFBIRTH = Convert.ToDateTime(dateofbirth)
                };

            __ent.TB_CANDIDATES.Add(__rtab);
            __ent.SaveChanges();
        }

        //add recruiters
        public void Insertrecruiters(string maxrec, string sRecruiterName, string sAddress1, string sAddress2,
                                     string sAddress3, string sTown, string sCounty, string sCountry, string sPostcode,
                                     string sEmailAddress, string sWebsite, string sDescription, string sCompleteDesc,
                                     int sEnteredbyId, string sArticleId)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_RECRUITERS
                {
                    EMPID = maxrec,
                    SRECRUITERNAME = sRecruiterName,
                    SADDRESS1 = sAddress1,
                    SADDRESS2 = sAddress2,
                    SADDRESS3 = sAddress3,
                    STOWN = sTown,
                    SCOUNTY = sCounty,
                    SPOSTCODE = sPostcode,
                    SCOUNTRY = sCountry,
                    SEMAILADDRESS = sEmailAddress,
                    SWEBSITE = sWebsite,
                    SDESCRIPTION = sDescription,
                    SCOMPLETEDESC = sCompleteDesc,
                    SDTENTERED = DateTime.Now,
                    SENTEREDBYID = sEnteredbyId,
                    SARTICLEID = sArticleId
                };

            __ent.TB_RECRUITERS.Add(__rtab);
            __ent.SaveChanges();
        }

        //add users
        public void Insertusers(string rusername, string fname, int uisprimary, string lname, string rpassword,
                                int rtype, string idUsers, string pwdhint, string ucandidateid, string uhash)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_USERS
                {
                    IDUSERS = idUsers,
                    UUSERTYPE = rtype,
                    UUSERNAME = rusername,
                    UPASSWORDHINT = pwdhint,
                    UPASSWORD = rpassword,
                    UFIRSTNAME = fname,
                    ULASTNAME = lname,
                    UCANDIDATEID = ucandidateid,
                    UACTIVATION = uhash
                };

            __ent.TB_USERS.Add(__rtab);
            __ent.SaveChanges();
        }

        //add rec user mapping
        public void Insertrecusermapping(string userid, string empid)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_RECUSERMAPPER {EMPID = empid, IDUSERS = userid};

            __ent.TB_RECUSERMAPPER.Add(__rtab);
            __ent.SaveChanges();
        }

        //getrecruiterdetails
        public string[] RecDetails(string usrname)
        {
            var __res = new joblightEntities();
            var _alist = new string[15];
            var __query = from rec in __res.TB_RECRUITERS
                          join rmap in __res.TB_RECUSERMAPPER
                              on rec.EMPID equals rmap.EMPID
                          join usr in __res.TB_USERS
                              on rmap.IDUSERS equals usr.IDUSERS
                          where usr.UUSERNAME == usrname
                          select new
                              {
                                  usr.UFIRSTNAME,
                                  usr.ULASTNAME,
                                  rec.SRECRUITERNAME,
                                  rec.SADDRESS1,
                                  rec.SADDRESS2,
                                  rec.SADDRESS3,
                                  rec.STOWN,
                                  rec.SCOUNTY,
                                  rec.SPOSTCODE,
                                  pwd = "xxxxxx",
                                  usr.UPASSWORDHINT,
                                  rec.SEMAILADDRESS,
                                  rec.SWEBSITE,
                                  rec.SDESCRIPTION,
                                  rec.SCOMPLETEDESC
                              };

            foreach (var _item in __query)
            {
                _alist[0] = _item.UFIRSTNAME;
                _alist[1] = _item.ULASTNAME;
                _alist[2] = _item.SRECRUITERNAME;
                _alist[3] = _item.SADDRESS1;
                _alist[4] = _item.SADDRESS2;
                _alist[5] = _item.SADDRESS3;
                _alist[6] = _item.STOWN;
                _alist[7] = _item.SCOUNTY;
                _alist[8] = _item.SPOSTCODE;
                _alist[9] = _item.pwd;
                _alist[10] = _item.UPASSWORDHINT;
                _alist[11] = _item.SEMAILADDRESS;
                _alist[12] = _item.SWEBSITE;
                _alist[13] = _item.SDESCRIPTION;
                _alist[14] = _item.SCOMPLETEDESC;
            }

            return _alist;
        }

        //update jobs
        public void Updatejobs(string idjobs, string sTitle, string sShortDescription, string sDescription,
                               string ssalarytext, int ssalarymin, int ssalarymax, string sref, string sdate,
                               string edate)
        {
            var __res = new joblightEntities();
            var __rval = __res.TB_JOBS.FirstOrDefault(_j => _j.IDJOBS == idjobs);

            __rval.STITLE = sTitle;
            __rval.SSHORTDESCRIPTION = sShortDescription;
            __rval.SDESCRIPTION = sDescription;
            __rval.DTENTEREDDATE = DateTime.Now.Date;
            __rval.SSALARYTEXT = ssalarytext;
            __rval.SMINSAL = ssalarymin;
            __rval.SMAXSAL = ssalarymax;
            __rval.SREF = sref;
            __rval.SJOBSTARTDATE = Convert.ToDateTime(sdate);
            __rval.SJOBENDDATE = Convert.ToDateTime(edate);

            __res.SaveChanges();
        }

        //get user my applications
        public object Getmyapps(string uusername, int _lowlimit, int _highlimit)
        {
            var __res = new joblightEntities();

            IQueryable<VW_GETMYAPPS> __query = (from gap in __res.VW_GETMYAPPS
                                            orderby gap.IDAPPLICATIONS
                                            where gap.UUSERNAME == uusername
                                            select gap).Skip(_lowlimit).Take(_highlimit);

            return __query.ToList();
        }

        //get user my applications
        public int Getmyappscount(string uusername)
        {
            var __res = new joblightEntities();
            int __query = (from item in __res.VW_GETMYAPPS
                           where item.UUSERNAME == uusername
                           select item).Count();

            return __query;
        }

        //get candidate detail page
        public string[] Getcandidatedetails(string susername)
        {
            var __res = new joblightEntities();
            var _alist = new string[12];
            IQueryable<VW_GETUSERCANS> __query = (from item in __res.VW_GETUSERCANS
                                              where item.UUSERNAME == susername
                                              select item).Take(1);

            foreach (var _item in __query)
            {
                _alist[0] = _item.CFIRSTNAME;
                _alist[1] = _item.CLASTNAME;
                _alist[2] = _item.CADDRESS1;
                _alist[3] = _item.CADDRESS2;
                _alist[4] = _item.CADDRESS3;
                _alist[5] = _item.CTOWN;
                _alist[6] = _item.CCOUNTY;
                _alist[7] = _item.CCOUNTRY;
                _alist[8] = _item.CPOSTCODE;
                _alist[9] = _item.CHOMEPHONE;
                _alist[10] = _item.CWORKPHONE;
                _alist[11] = _item.CDATEOFBIRTH.ToString();
            }

            return _alist;
        }
    }
}