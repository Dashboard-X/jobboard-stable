using System;
using System.Linq;

namespace JB
{
    public class DlLogins
    {
        //activate accounts for users and recruitersm
        public void ActivateAcc(int uusertype, string uusername, string keytopass)
        {
            var __res = new joblightEntities();
            var __rval =
                __res.TB_USERS.FirstOrDefault(
                    _c => _c.UFIRSTNAME == uusername && _c.UUSERTYPE == uusertype && _c.UACTIVATION != keytopass);

            __rval.UACTIVATION = null;
            __res.SaveChanges();
        }

        //get user orginal name for welcome //only for candidates
        public string Userwelcomename(string pusername, int uusertype)
        {
            var __res = new joblightEntities();
            string _alist = string.Empty;
            var __query = from c in __res.TB_CANDIDATES
                          join u in __res.TB_USERS
                              on c.IDCANDIDATES equals u.UCANDIDATEID
                          where u.UUSERNAME == pusername && u.UUSERTYPE == uusertype
                          select new
                              {
                                  completename = c.CFIRSTNAME + " " + c.CLASTNAME
                              };

            foreach (var _item in __query)
            {
                _alist = _item.completename;
            }

            return _alist;
        }

        //get employee id ony for employees
        public string Ewelcomename(string pusername, int uusertype)
        {
            var __res = new joblightEntities();
            string _alist = string.Empty;
            IQueryable<TB_USERS> __query = from u in __res.TB_USERS
                                       where u.UUSERNAME == pusername && u.UUSERTYPE == uusertype
                                       select u;

            foreach (var _item in __query)
            {
                _alist = _item.UFIRSTNAME + ' ' + _item.ULASTNAME;
            }

            return _alist;
        }

        //check the password key against the database
        public string Getkeyuser(string keyids, int utype)
        {
            var __res = new joblightEntities();
            string _alist = string.Empty;
            IQueryable<TB_USERS> __query = from u in __res.TB_USERS
                                       where u.UACTIVATION == keyids && u.UUSERTYPE == utype
                                       select u;

            foreach (var _item in __query)
            {
                _alist = _item.UACTIVATION;
            }

            return _alist;
        }

        //set seed key for user
        public void Chgkeyuser(string uusername, string keys)
        {
            var __res = new joblightEntities();
            var __rval = __res.TB_USERS.FirstOrDefault(_c => _c.UUSERNAME == uusername && _c.UUSERTYPE == 2);

            __rval.UACTIVATION = keys;
            __res.SaveChanges();
        }

        //set seed key for recruiters
        public void Chgkeyrec(string uusername, string keys)
        {
            var __res = new joblightEntities();
            var __rval = __res.TB_USERS.FirstOrDefault(_c => _c.UUSERNAME == uusername && _c.UUSERTYPE == 1);

            __rval.UACTIVATION = keys;
            __res.SaveChanges();
        }

        //this is admin user
        //1 is admin
        public string Getuser(string userns, string pwds)
        {
            var __res = new joblightEntities();
            string _alist = string.Empty;
            IQueryable<TB_USERS> __query = from u in __res.TB_USERS
                                       where u.UUSERNAME == userns && u.UUSERTYPE == 1
                                       select u;

            foreach (var _item in __query)
            {
                _alist = _item.UUSERNAME;
            }

            return _alist;
        }

        //jobseeker user
        //2 is jobseeker
        public string Getjobuser(string usns, string pwds)
        {
            var __res = new joblightEntities();
            string _alist = string.Empty;
            IQueryable<TB_USERS> __query = from u in __res.TB_USERS
                                       where u.UUSERNAME == usns && u.UUSERTYPE == 2
                                       select u;

            foreach (var _item in __query)
            {
                _alist = _item.UUSERNAME;
            }

            return _alist;
        }

        //change passwords
        //rec password or admin 1
        public void Chgpwdrec(string uUserName, string pwds)
        {
            //recalc password hash
            var clpdh = new ClPwdhash();

            string hashedpwd = clpdh.GetMd5Hash(pwds);

            var __res = new joblightEntities();
            var __rval = __res.TB_USERS.FirstOrDefault(_c => _c.UUSERNAME == uUserName && _c.UUSERTYPE == 1);

            __rval.UPASSWORD = hashedpwd;
            __res.SaveChanges();
        }

        //jobseeker password or admin 2
        public void Chgpwdjs(string uUserName, string pwds)
        {
            //recalc password hash
            var clpdh = new ClPwdhash();

            string hashedpwd = clpdh.GetMd5Hash(pwds);

            var __res = new joblightEntities();
            var __rval = __res.TB_USERS.FirstOrDefault(_c => _c.UUSERNAME == uUserName && _c.UUSERTYPE == 2);

            __rval.UPASSWORD = hashedpwd;
            __res.SaveChanges();
        }

        //change passwords with keys.....
        //change passwords
        public void Chgpwdrecwkey(string keyval, string pwds)
        {
            //recalc password hash
            var clpdh = new ClPwdhash();

            string hashedpwd = clpdh.GetMd5Hash(pwds);

            var __res = new joblightEntities();
            var __rval = __res.TB_USERS.FirstOrDefault(_c => _c.UACTIVATION == keyval && _c.UUSERTYPE == 1);

            __rval.UPASSWORD = hashedpwd;
            __res.SaveChanges();
        }

        //jobseeker password or admin 2
        public void Chgpwdjswkey(string keyval, string pwds)
        {
            //recalc password hash
            var clpdh = new ClPwdhash();

            string hashedpwd = clpdh.GetMd5Hash(pwds);

            var __res = new joblightEntities();
            var __rval = __res.TB_USERS.FirstOrDefault(_c => _c.UACTIVATION == keyval && _c.UUSERTYPE == 2);

            __rval.UPASSWORD = hashedpwd;
            __res.SaveChanges();
        }

        //check if the recruiter exists in the database
        public string Checkrecusern(string userns)
        {
            var __res = new joblightEntities();
            string _alist = string.Empty;
            IQueryable<TB_USERS> __query = from item in __res.TB_USERS
                                       where item.UUSERNAME == userns && item.UUSERTYPE == 1
                                       select item;

            foreach (var _item in __query)
            {
                _alist = _item.UUSERNAME;
            }

            return _alist;
        }

        //check if the candidate exists in the database
        public string Checkcanusern(string userns)
        {
            var __res = new joblightEntities();
            string _alist = string.Empty;
            IQueryable<TB_USERS> __query = from item in __res.TB_USERS
                                       where item.UUSERNAME == userns && item.UUSERTYPE == 2
                                       select item;

            foreach (var _item in __query)
            {
                _alist = _item.UUSERNAME;
            }

            return _alist;
        }

        //check the usertype for the main windows like is it recruiter of single user
        public int Checkusertype(string uusername, int uusertypes)
        {
            var __res = new joblightEntities();
            IQueryable<TB_USERS> __query = from item in __res.TB_USERS
                                       where item.UUSERNAME == uusername && item.UUSERTYPE == uusertypes
                                       select item;

            return Convert.ToInt32(Enumerable.FirstOrDefault(__query.Select(_item => _item.UUSERTYPE)));
        }
    }
}