namespace JB
{
    public class DlArticles
    {
        //Add articles to database, they can be anything from resumes to other iternarys
        public void AddArticle(string sArticleID, string ArticleName, string Article_data)
        {
            var __ent = new joblightEntities();
            var __rtab = new TB_ARTICLES {SARTICLEID = sArticleID, ARTICLENAME = ArticleName, ARTICLE_DATA = Article_data};

            __ent.TB_ARTICLES.Add(__rtab);
            __ent.SaveChanges();
        }
    }
}