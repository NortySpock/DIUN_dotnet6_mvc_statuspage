using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
// using MvcDiunUpdate.Data;
using DIUN_dotnet_mvc_statuspage.Models;
using System;
using System.Linq;

namespace MvcDiunUpdate.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcDiunUpdateContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcDiunUpdateContext>>()))
            {
                // Look for any movies.
                if (context.DiunUpdateModel.Any())
                {
                    return;   // DB has been seeded
                }

                //TODO add model builder or some sort of default 
                var testData1 = new DiunUpdateModel();
                testData1.diun_version = "4.0.0";
                testData1.hostname = "myserver";
                testData1.status="new";
                testData1.provider="file";
                testData1.image="docker.io/crazymax/diun:latest";
                testData1.hub_link="https://hub.docker.com/r/crazymax/diun";
                testData1.mime_type="application/vnd.docker.distribution.manifest.list.v2+json";
                testData1.digest="sha256:216e3ae7de4ca8b553eb11ef7abda00651e79e537e85c46108284e5e91673e01";
                testData1.created=DateTime.Parse("2020-03-26T12:23:56Z");
                testData1.platform="linux/amd64";

                var testData2 = new DiunUpdateModel();
                testData2.diun_version = "4.0.0";
                testData2.hostname = "myserver";
                testData2.status="new";
                testData2.provider="file";
                testData2.image="https://hub.docker.com/r/pihole/pihole";
                testData2.hub_link="https://hub.docker.com/r/pihole/pihole";
                testData2.mime_type="application/vnd.docker.distribution.manifest.list.v2+json";
                testData2.digest="sha256:9bcb7924e862a376860430d318335e00853942eb4523529fc5fa028537d4de7d";
                testData2.created=DateTime.Parse("2020-04-26T12:23:56Z");
                testData2.platform="linux/arm64";
                    

                context.DiunUpdateModel.AddRange(testData1,testData2);        
                context.SaveChanges();
            }
        }
    }
}