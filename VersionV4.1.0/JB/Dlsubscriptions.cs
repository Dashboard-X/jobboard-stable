namespace JB
{
    public class Dlsubscriptions
    {
        //add email subscriptions
        public void Addsubscriptions(string emailaddr, int catid, int termid)
        {
            var __res = new joblightEntities();
            var __rtab = new TB_SUBSCRIPTIONS {EMAILADDRESS = emailaddr, CATID = catid, TERMID = termid};

            __res.TB_SUBSCRIPTIONS.Add(__rtab);
            __res.SaveChanges();
        }
    }
}