using System;
using System.Linq;
using System.Text;

namespace JB
{
    public class DlEmailprocessor
    {
        private readonly Clemail _clemail = new Clemail();

        public Clemail Clemail
        {
            get { return _clemail; }
        }

        //get recruiter details for jobemails subjects
        public StringBuilder Dbemailgenerator(string jobid)
        {
            var __res = new joblightEntities();
            var sbr = new StringBuilder();
            IQueryable<VW_GETSUBJECTEMAILAPPS> __query = from item in __res.VW_GETSUBJECTEMAILAPPS
                                                         where item.IDJOBS == jobid
                                                         select item;

            foreach (var _item in __query)
            {
                sbr.Append(_item.SREF);
                sbr.Append("/");
                sbr.Append(_item.STITLE);
            }

            return sbr;
        }

        //this is for processing password change notifications.
        public StringBuilder Emailpwdnotify(string passwordlink, string uusername)
        {
            var __res = new joblightEntities();
            var sbr = new StringBuilder();
            IQueryable<TB_EMAILTEMPLATES> __query = from item in __res.TB_EMAILTEMPLATES
                                                    where item.ETEMPLATECHKID == "2"
                                                    select item;

            foreach (TB_EMAILTEMPLATES _item in __query)
            {
                sbr.Append(_item.EHEADER);
                sbr.Append(uusername);
                sbr.Append(_item.EDESCRIPTION);
                sbr.Append(passwordlink);
                sbr.Append(_item.EFOOTER);
            }

            return sbr;
        }

        //user activation email
        public StringBuilder Emailactivateusr(string activationlink, string uusername)
        {
            var __res = new joblightEntities();
            var sbr = new StringBuilder();
            IQueryable<TB_EMAILTEMPLATES> __query = from item in __res.TB_EMAILTEMPLATES
                                                    where item.ETEMPLATECHKID == "3"
                                                    select item;

            foreach (TB_EMAILTEMPLATES _item in __query)
            {
                sbr.Append(_item.EHEADER);
                sbr.Append(uusername);
                sbr.Append(_item.EDESCRIPTION);
                sbr.Append(activationlink);
                sbr.Append(_item.EFOOTER);
            }

            return sbr;
        }


        //this is for processing application notifications.
        public StringBuilder Emaildirapps(int typeofemail, string username)
        {
            var __res = new joblightEntities();
            var sbr = new StringBuilder();
            string _tempemail = typeofemail.ToString();

            IQueryable<TB_EMAILTEMPLATES> __query = from item in __res.TB_EMAILTEMPLATES
                                                    where item.ETEMPLATECHKID == _tempemail
                                                    select item;

            foreach (TB_EMAILTEMPLATES _item in __query)
            {
                sbr.Append(_item.EHEADER);
                sbr.Append(username);
                sbr.Append(_item.EDESCRIPTION);
                sbr.Append(_item.EFOOTER);
            }

            return sbr;
        }

        //on success of application email sent out, log to db.
        public void Sendappemaildbupdate(string guids, string emailaddress, int rEmailtype)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_EMAILRESPONSE
                {
                    RSTATUS = 0,
                    REMAILTYPE = rEmailtype,
                    REMAILADDRESS = emailaddress,
                    IDEMAILRESPONSE = guids
                };

            __ent.TB_EMAILRESPONSE.Add(__rtab);
            __ent.SaveChanges();
        }
    }
}