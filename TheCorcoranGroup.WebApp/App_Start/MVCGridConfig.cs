[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TheCorcoranGroup.WebApp.MVCGridConfig), "RegisterGrids")]

namespace TheCorcoranGroup.WebApp
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using TheCorcoranGroup.Model;
    using TheCorcoranGroup.WebApp.Controllers;

    public static class MVCGridConfig
    {
        public static void RegisterGrids()
        {
            try
            {
                ColumnDefaults colDefauls = new ColumnDefaults()
                {
                    EnableSorting = true
                };

                MVCGridDefinitionTable.Add("PresidentsGrid", new MVCGridBuilder<PresidentModel>(colDefauls)
                   .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                   .AddColumns(cols =>
                   {
                       cols.Add("Id").WithSorting(false)
                            .WithHeaderText("Id").WithValueExpression(i => i.id.ToString());
                       cols.Add("Name").WithHeaderText("President")
                            .WithValueExpression(i => i.Name);
                       cols.Add("Birthday").WithSorting(false)
                            .WithHeaderText("Birth Day").WithValueExpression(i => i.Birthday);
                       cols.Add("Birthplace").WithSorting(false)
                            .WithHeaderText("Birth Place").WithValueExpression(i => i.Birthplace);
                       cols.Add("Deathday").WithSorting(false)
                            .WithHeaderText("Death Day").WithValueExpression(i => i.Deathday);
                       cols.Add("Deathplace").WithSorting(false)
                            .WithHeaderText("Death Place").WithValueExpression(i => i.Deathplace);
                   })
                   .WithSorting(true, "Name")
                   .WithRetrieveDataMethod((context) =>
                   {
                       List<PresidentModel> presidents =  HomeController.GetAllPresident();

                       var options = context.QueryOptions;
                       var result = new QueryResult<PresidentModel>();

                       if (!String.IsNullOrWhiteSpace(options.SortColumnName))
                       {
                           if (options.SortDirection.ToString() == "Asc")
                           {
                               presidents = presidents.OrderBy(x => x.Name).ToList();
                           }
                           else if (options.SortDirection.ToString() == "Dsc")
                           {
                               presidents = presidents.OrderByDescending(x => x.Name).ToList();
                           }

                           result.Items = presidents;
                       }
                       else
                       {
                           result.Items = presidents;
                       }

                       result.TotalRecords = presidents.Count;

                       return result;

                   })
               );

            }
            catch (Exception ex)
            {
            }
        }
    }
}