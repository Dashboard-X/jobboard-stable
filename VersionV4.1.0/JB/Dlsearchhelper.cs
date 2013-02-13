using System;
using System.Collections;
using System.Linq;

namespace JB
{
    public class Dlsearchhelper
    {
        private int?[] Alist(ArrayList alist)
        {
            var arr = new int?[alist.Count];
            for (int i = 0; i < alist.Count; i++)
            {
                arr[i] = Convert.ToInt32(alist[i]);
            }

            return arr;
        }

        public object Applycriteriafilter(ArrayList addedcrit, int _lowlimit, int _highlimit)
        {
            int?[] arr = Alist(addedcrit);

            var __res = new joblightEntities();
            IQueryable<VW_AGGREGATEDMULTI> __query = (from a in __res.VW_AGGREGATEDMULTI
                                                   orderby a.IDJOBS
                                                   where arr.Contains(a.TERMID)
                                                   select a).Skip(_lowlimit).Take(_highlimit).Distinct();

            return __query.ToList();
        }

        public object Applytitlefilter(string titles, int _lowlimit, int _highlimit)
        {
            //ideally we should use full text instead of contains!
            var __res = new joblightEntities();
            IQueryable<VW_AGGREGATEDMULTI> __query = (from a in __res.VW_AGGREGATEDMULTI
                                                   orderby a.IDJOBS
                                                   where a.SFREETEXT.Contains(titles)
                                                   select a).Skip(_lowlimit).Take(_highlimit).Distinct();

            return __query.ToList();
        }

        public object Applytitlefilter(string titles, ArrayList addedcrit, int _lowlimit, int _highlimit)
        {
            int?[] arr = Alist(addedcrit);

            //ideally we should use full text instead of contains!
            var __res = new joblightEntities();
            IQueryable<VW_AGGREGATEDMULTI> __query = (from a in __res.VW_AGGREGATEDMULTI
                                                   orderby a.IDJOBS
                                                   where a.SFREETEXT.Contains(titles) && arr.Contains(a.TERMID)
                                                   select a).Skip(_lowlimit).Take(_highlimit).Distinct();

            return __query.ToList();
        }

        public int Applycriteriafiltercount(ArrayList addedcrit, int _lowlimit, int _highlimit)
        {
            int?[] arr = Alist(addedcrit);

            var __res = new joblightEntities();
            int __query = ((from a in __res.VW_AGGREGATEDMULTI
                            orderby a.IDJOBS
                            where arr.Contains(a.TERMID)
                            select a).Skip(_lowlimit).Take(_highlimit).Distinct()).Count();

            return __query;
        }

        public int Applytitlefiltercount(string titles, int _lowlimit, int _highlimit)
        {
            //ideally we should use full text instead of contains!
            var __res = new joblightEntities();
            int __query = ((from a in __res.VW_AGGREGATEDMULTI
                            orderby a.IDJOBS
                            where a.SFREETEXT.Contains(titles)
                            select a).Skip(_lowlimit).Take(_highlimit).Distinct()).Count();

            return __query;
        }

        public int Applytitlefiltercount(string titles, ArrayList addedcrit, int _lowlimit, int _highlimit)
        {
            int?[] arr = Alist(addedcrit);

            //ideally we should use full text instead of contains!
            var __res = new joblightEntities();
            int __query = ((from a in __res.VW_AGGREGATEDMULTI
                            orderby a.IDJOBS
                            where a.SFREETEXT.Contains(titles) && arr.Contains(a.TERMID)
                            select a).Skip(_lowlimit).Take(_highlimit).Distinct()).Count();

            return __query;
        }
    }
}