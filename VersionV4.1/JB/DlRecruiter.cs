using System;
using System.Linq;

namespace JB
{
    public class DlRecruiter
    {
        //get advertizing rec count
        public int Getcountrecswadvert()
        {
            var __res = new joblightEntities();
            int __query = (from item in __res.VW_GETALLREC
                           select item).Count();

            return __query;
        }

        //get recruiter count
        public int Getrecwjobscount()
        {
            var __res = new joblightEntities();
            int __query = (from item in __res.VW_GETALLREC
                           select item).Count();

            return __query;
        }

        //get recid via email/name
        public string Getrecid(string recname)
        {
            var __res = new joblightEntities();
            IQueryable<TB_RECRUITERS> __query = from item in __res.TB_RECRUITERS
                                            where item.SRECRUITERNAME == recname
                                            select item;

            string __totalrec = Enumerable.FirstOrDefault(__query.Select(_item => _item.EMPID));

            return __totalrec;
        }

        //this may not be used anymore, as we changed one to one from one to many relation, please review.
        public object RecUsers(string userns)
        {
            var __res = new joblightEntities();

            var __query = from rec in __res.TB_RECRUITERS
                          join rmap in __res.TB_RECUSERMAPPER
                              on rec.EMPID equals rmap.EMPID
                          join usr in __res.TB_USERS
                              on rmap.IDUSERS equals usr.IDUSERS
                          where usr.UUSERNAME == userns
                          select new
                              {
                                  usr.UUSERNAME,
                                  usr.UFIRSTNAME,
                                  usr.ULASTNAME,
                                  usr.UISPRIMARY,
                                  usr.IDUSERS
                              };
            return __query;
        }

        //get all recruiters with jobs
        public object Getallrecwithjobs(int lowerlimit, int higherlimit)
        {
            var __res = new joblightEntities();

            IQueryable<VW_GETALLREC> __query = (from gar in __res.VW_GETALLREC
                                             orderby gar.EMPID
                                             select gar).Skip(lowerlimit).Take(higherlimit);

            return __query.ToList();
        }

        //get one rec detail with recid
        public object Getcurrrecwithempid(string empid)
        {
            var __res = new joblightEntities();

            IQueryable<VW_GETALLREC> __query = from gar in __res.VW_GETALLREC
                                            where gar.EMPID == empid
                                            select gar;

            return __query.ToList();
        }

        //get contact person details page
        public string Contactperson(string jobid)
        {
            var __res = new joblightEntities();
            string _alist = string.Empty;
            IQueryable<VW_RECUSERS> __query = from item in __res.VW_RECUSERS
                                          where item.IDJOBS == jobid
                                          select item;

            foreach (var _item in __query)
            {
                _alist = ' ' + _item.UFIRSTNAME + ' ' + _item.ULASTNAME;
                break;
            }

            return _alist;
        }

        //update recuser with id = 1;
        public void Runrecuserupdate(string fname, string lname, string uusername)
        {
            var __res = new joblightEntities();
            var __rval = __res.TB_USERS.FirstOrDefault(_u => _u.UUSERNAME == uusername && _u.UUSERTYPE == 1);

            __rval.UFIRSTNAME = fname;
            __rval.ULASTNAME = lname;
            __res.SaveChanges();
        }

        //get article id for updating
        private string LogoHelper(string uusername)
        {
            //get emp id for table update below
            var __res = new joblightEntities();
            var __query = from art in __res.TB_ARTICLES
                          join rec in __res.TB_RECRUITERS
                              on art.SARTICLEID equals rec.SARTICLEID
                          join rmap in __res.TB_RECUSERMAPPER
                              on rec.EMPID equals rmap.EMPID
                          join usr in __res.TB_USERS
                              on rmap.IDUSERS equals usr.IDUSERS
                          where usr.UUSERNAME == uusername && usr.UUSERTYPE == 1
                          select new
                              {
                                  art.SARTICLEID
                              };

            return Enumerable.FirstOrDefault(__query.Select(_item => _item.SARTICLEID));
        }


        //logo update for recruiters with id = 1;
        public void Runreclogoupdate(string articleData, string articlename, string uusername)
        {
            //get article id against user then update
            string __TempArticleId = LogoHelper(uusername);

            var __res = new joblightEntities();
            var __rval = __res.TB_ARTICLES.FirstOrDefault(_a => _a.SARTICLEID == __TempArticleId);

            __rval.ARTICLENAME = articlename;
            __rval.ARTICLE_DATA = articleData;
        }

        //get ids for update
        private string EmployeeHelper(string uusername)
        {
            //get emp id for table update below
            var __res = new joblightEntities();
            var __query = from usr in __res.TB_USERS
                          join rmap in __res.TB_RECUSERMAPPER
                              on usr.IDUSERS equals rmap.IDUSERS
                          join rec in __res.TB_RECRUITERS
                              on rmap.EMPID equals rec.EMPID
                          where usr.UUSERNAME == uusername && usr.UUSERTYPE == 1
                          select new
                              {
                                  rec.EMPID
                              };

            return Enumerable.FirstOrDefault(__query.Select(_item => _item.EMPID));
        }


        //update recruiter table information
        public void Runrectableupdate(string add1, string add2, string add3, string town, string county, string postcode,
                                      string compname, string compwebsite, string companyintro, string businessdetail,
                                      string uusername)
        {
            string _tempempid = EmployeeHelper(uusername);

            var __res = new joblightEntities();
            TB_RECRUITERS __rval = __res.TB_RECRUITERS.FirstOrDefault(_r => _r.EMPID == _tempempid);

            __rval.SRECRUITERNAME = compname;
            __rval.SADDRESS1 = add1;
            __rval.SADDRESS2 = add2;
            __rval.SADDRESS3 = add3;
            __rval.STOWN = town;
            __rval.SPOSTCODE = postcode;
            __rval.SWEBSITE = compwebsite;
            __rval.SDESCRIPTION = companyintro;
            __rval.SCOMPLETEDESC = businessdetail;

            __res.SaveChanges();
        }

        //get article id to update the logo
        public int Getarticleids(string uusername)
        {
            var __res = new joblightEntities();
            var __query = from rec in __res.TB_RECRUITERS
                          join rmap in __res.TB_RECUSERMAPPER
                              on rec.EMPID equals rmap.EMPID
                          join usr in __res.TB_USERS
                              on rmap.IDUSERS equals usr.IDUSERS
                          select new
                              {
                                  rec.SARTICLEID
                              };

            return Convert.ToInt32(Enumerable.FirstOrDefault(__query.Select(v => v.SARTICLEID)));
        }
    }
}