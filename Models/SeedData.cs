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
                testData1.status = "new";
                testData1.provider = "file";
                testData1.image = "docker.io/crazymax/diun:latest";
                testData1.hub_link = "https://hub.docker.com/r/crazymax/diun";
                testData1.mime_type = "application/vnd.docker.distribution.manifest.list.v2+json";
                testData1.digest = "sha256:216e3ae7de4ca8b553eb11ef7abda00651e79e537e85c46108284e5e91673e01";
                testData1.created = DateTime.Parse("2020-03-26T12:23:56Z");
                testData1.platform = "linux/amd64";

                var testData2 = new DiunUpdateModel();
                testData2.diun_version = "4.0.0";
                testData2.hostname = "myserver";
                testData2.status = "new";
                testData2.provider = "file";
                testData2.image = "https://hub.docker.com/r/itzg/minecraft-server:java11";
                testData2.hub_link = "https://hub.docker.com/r/itzg/minecraft-server";
                testData2.mime_type = "application/vnd.docker.distribution.manifest.list.v2+json";
                testData2.digest = "sha256:9bcb7924e862a376860430d318335e00853942eb4523529fc5fa028537d4de7d";
                testData2.created = DateTime.Parse("2020-04-26T12:23:56Z");
                testData2.platform = "linux/mips";


                var testData3 = new DiunUpdateModel();
                testData3.diun_version = "4.0.0";
                testData3.hostname = "myserver";
                testData3.status = "new";
                testData3.provider = "file";
                testData3.image = "https://hub.docker.com/r/dozzle/dozzle";
                testData3.hub_link = "https://hub.docker.com/r/dozzle/dozzle";
                testData3.mime_type = "application/vnd.docker.distribution.manifest.list.v2+json";
                testData3.digest = "sha256:8e27c59c835d81148eb0ad8f7da77afb96262ba7e5c12eaa59034ee3b88b5e87";
                testData3.created = DateTime.Parse("2020-04-25T12:23:56Z");
                testData3.platform = "linux/x86";

                var testData4 = new DiunUpdateModel();
                testData4.diun_version = "4.0.0";
                testData4.hostname = "myserver";
                testData4.status = "new";
                testData4.provider = "file";
                testData4.image = "lscr.io/linuxserver/dokuwiki";
                testData4.hub_link = "https://hub.docker.com/r/linuxserver/dokuwiki";
                testData4.mime_type = "application/vnd.docker.distribution.manifest.list.v2+json";
                testData4.digest = "sha256:5ac23ba94f1a8b24c4ab9a66f09914c6f195fb776d18bd7f9238fbe5f53e4980";
                testData4.created = DateTime.Parse("2020-07-25T12:23:56Z");
                testData4.platform = "linux/x86";

                var testData5 = new DiunUpdateModel();
                testData5.diun_version = "4.0.0";
                testData5.hostname = "myserver";
                testData5.status = "new";
                testData5.provider = "file";
                testData5.image = "lscr.io/linuxserver/dokuwiki";
                testData5.hub_link = "https://hub.docker.com/r/linuxserver/dokuwiki";
                testData5.mime_type = "application/vnd.docker.distribution.manifest.list.v2+json";
                testData5.digest = "sha256:67f3e9008cdd14b4cd3842632c5dcfe3e6c1726dc953ae37dc55b13c6fa5a214";
                testData5.created = DateTime.Parse("2020-08-26T12:23:56Z");
                testData5.platform = "linux/x86";

                var testData6 = new DiunUpdateModel();
                testData6.diun_version = "4.0.0";
                testData6.hostname = "myserver";
                testData6.status = "new";
                testData6.provider = "file";
                testData6.image = "ghcr.io/linuxserver/scrutiny";
                testData6.hub_link = "https://hub.docker.com/r/linuxserver/scrutiny";
                testData6.mime_type = "application/vnd.docker.distribution.manifest.list.v2+json";
                testData6.digest = "sha256:8e27c59c835d81148eb0ad8f7da77afb96262ba7e5c12eaa59034ee3b88b5e87";
                testData6.created = DateTime.Parse("2020-08-25T12:23:56Z");
                testData6.platform = "linux/x86";




                context.DiunUpdateModel.AddRange(testData1, testData2, testData3, testData4, testData5, testData6);
                context.SaveChanges();

            }
        }
    }
}