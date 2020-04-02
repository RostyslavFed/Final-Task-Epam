using Hospital.WEB.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace Hospital.WEB.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            if (pageInfo.TotalPages > 1)
            {
                if (pageInfo.TotalPages < 10)
                {
                    CreatePageLinks(result, 1, pageInfo.TotalPages, pageInfo.PageNumber, pageUrl);
                }
                else
                {
                    const int numberPagesPerSide = 7;

                    CreatePageLink(result, 1, pageInfo.PageNumber, pageUrl);
                    
                    int start;
                    if (pageInfo.PageNumber - numberPagesPerSide < 1)
                    {
                        start = 2;
                    }
                    else
                    {
                        start = pageInfo.PageNumber - 5;
                        CreatePass(result);
                        if (pageInfo.PageNumber > numberPagesPerSide)
                        {
                            int itemNumber = pageInfo.PageNumber - 5;
                            CreateQuickRewind(result, itemNumber, "5 <<", pageUrl);
                        }
                    }

                    int finish;
                    if (pageInfo.PageNumber + numberPagesPerSide > pageInfo.TotalPages)
                    {
                        finish = pageInfo.TotalPages;
                        CreatePageLinks(result, start, finish, pageInfo.PageNumber, pageUrl);
                    }
                    else
                    {
                        finish = pageInfo.PageNumber + 5;

                        CreatePageLinks(result, start, finish, pageInfo.PageNumber, pageUrl);
                        CreatePass(result);

                        if (pageInfo.PageNumber + numberPagesPerSide < pageInfo.TotalPages)
                        {
                            int itemNumber = pageInfo.PageNumber + 5;
                            CreateQuickRewind(result, itemNumber, ">> 5", pageUrl);
                        }
                        CreatePageLink(result, pageInfo.TotalPages, pageInfo.PageNumber, pageUrl);
                    }
                }
            }

            return MvcHtmlString.Create(result.ToString());
        }

        private static void CreateQuickRewind(StringBuilder stringBuilder, int itemNumber, 
            string label, Func<int, string> pageUrl)
        {
            CreatePageLink(stringBuilder, itemNumber, label, pageUrl);
            CreatePass(stringBuilder);
        }

        private static void CreatePageLink(StringBuilder stringBuilder, int itemNumber,
            string text, Func<int, string> pageUrl)
        {
            CreateItem(stringBuilder, itemNumber, text, -1, pageUrl);
        }

        private static void CreatePageLink(StringBuilder stringBuilder, int page, 
            int pageNumber, Func<int, string> pageUrl)
        {
            CreateItem(stringBuilder, page, pageNumber, pageUrl);
        }

        private static void CreatePageLinks(StringBuilder stringBuilder, int start, int finish, 
            int pageNumber, Func<int, string> pageUrl)
        {
            for(;start <= finish; start++)
            {
                CreateItem(stringBuilder, start, pageNumber, pageUrl);
            }
        }

        private static void CreatePass(StringBuilder stringBuilder)
        {
            var tag = new TagBuilder("a");
            tag.InnerHtml = "...";
            tag.AddCssClass("btn btn-default");
            stringBuilder.Append(tag.ToString());
        }

        private static void CreateItem(StringBuilder stringBuilder, int itemNumber, 
            int pageNumber, Func<int, string> pageUrl)
        {
            CreateItem(stringBuilder, itemNumber, itemNumber.ToString(), pageNumber, pageUrl);
        }

        private static void CreateItem(StringBuilder stringBuilder, int itemNumber, 
            string text, int pageNumber, Func<int, string> pageUrl)
        {
            TagBuilder tag = new TagBuilder("a");
            tag.MergeAttribute("href", pageUrl(itemNumber));
            tag.InnerHtml = text;
            // если текущая страница, то выделяем ее,
            // например, добавляя класс
            if (itemNumber == pageNumber)
            {
                tag.AddCssClass("selected");
                tag.AddCssClass("btn-primary");
            }
            tag.AddCssClass("btn btn-default");
            stringBuilder.Append(tag.ToString());
        }
    }
}