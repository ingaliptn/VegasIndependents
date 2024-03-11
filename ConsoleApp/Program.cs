using ConsoleApp.Lib;
using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = new ServiceCollection()
                .AddDbContext<EfDbContext>(options =>
                    options.UseSqlServer(Constants.DefaultConnection))
                .AddSingleton<ISettingRepository, EfSettingRepository>()
                .AddSingleton<IEscortRepository, EfEscortRepository>()
                .AddSingleton<ITextRepository, EfTextRepository>()
                .AddSingleton<IMenuRepository, EfMenuRepository>()
                .AddSingleton<IFileImageRepository, EfFileImageRepository>()
                .BuildServiceProvider();

            
            var l = new CsvToBd(serviceProvider);
            await l.RemoveBad(Constants.SiteName);
            //await l.TextBuildMenuEscorts(Constants.SiteName);
            //await l.TextBuildMenuHome(Constants.SiteName);
            //await l.AddEscort1(Constants.SiteName, "escorts.csv");
            //await l.AddEscort2(Constants.SiteName, "dreamportland2m.csv");
            await l.AddSiteTitleSiteDescription(Constants.SiteName, "vegasindependents.csv");
            //await l.BuildEscorts(Constants.SiteName, @"C:\Work2020\Solution-DreamGirls\WebUi\wwwroot\images\escort_pic");
            //await l.AddParserTexts(Constants.SiteName);
            //await l.BuildSection(Constants.SiteName);
        }
    }
}
