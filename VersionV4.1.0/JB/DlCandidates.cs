using System;
using System.Linq;

namespace JB
{
    public class DlCandidates
    {
        private string CandidateHelper(string __uname)
        {
            var __res = new joblightEntities();
            string __sb = string.Empty;
            var __query = from usr in __res.TB_USERS
                          join can in __res.TB_CANDIDATES
                              on usr.UCANDIDATEID equals can.IDCANDIDATES
                          where usr.UUSERTYPE == 2 && usr.UUSERNAME == __uname
                          select new
                              {
                                  can.IDCANDIDATES
                              };

            foreach (var _item in __query)
            {
                __sb = _item.IDCANDIDATES;
            }

            return __sb;
        }

        //this updates candidates profiles
        public void Runcandidateupdate(string cfirstname, string clastname, string address1, string address2,
                                       string address3, string town, string county, string country, string dateofbirth,
                                       string postcode, string hometel, string worktel, string uusername)
        {
            string __tempcanid = CandidateHelper(uusername);

            var __res = new joblightEntities();
            var __rval = __res.TB_CANDIDATES.FirstOrDefault(_c => _c.IDCANDIDATES == __tempcanid);

            __rval.CFIRSTNAME = cfirstname;
            __rval.CLASTNAME = clastname;
            __rval.CADDRESS1 = address1;
            __rval.CADDRESS2 = address2;
            __rval.CADDRESS3 = address3;
            __rval.CTOWN = town;
            __rval.CCOUNTY = county;
            __rval.CCOUNTRY = country;
            __rval.CPOSTCODE = postcode;
            __rval.CDATEOFBIRTH = Convert.ToDateTime(dateofbirth);
            __rval.CHOMEPHONE = hometel;
            __rval.CWORKPHONE = worktel;
            __rval.CCANDIDATENAME = cfirstname + ' ' + clastname;

            __res.SaveChanges();
        }

        //user to get direct applications for candidates who have registered as can.
        public string[] Getcandidatesindb(string uusername)
        {
            var __res = new joblightEntities();
            var _alist = new string[5];
            var __query = from itema in __res.TB_CANDIDATES
                          join itemb in __res.TB_USERS
                              on itema.IDCANDIDATES equals itemb.UCANDIDATEID
                          where itemb.UUSERNAME == uusername
                          select new
                              {
                                  itemb.UUSERNAME,
                                  itema.CFIRSTNAME,
                                  itema.CLASTNAME,
                                  itema.CDATEOFBIRTH,
                                  itema.IDCANDIDATES
                              };

            foreach (var _item in __query)
            {
                _alist[0] = _item.UUSERNAME;
                _alist[1] = _item.CFIRSTNAME;
                _alist[2] = _item.CLASTNAME;
                _alist[3] = _item.CDATEOFBIRTH.ToString();
                _alist[4] = _item.IDCANDIDATES;
            }

            return _alist;
        }
    }
}