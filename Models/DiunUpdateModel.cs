using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DIUN_dotnet_mvc_statuspage.Models;
public class DiunUpdateModel
{
  public DiunUpdateModel()
  {
      Id = Guid.NewGuid().ToString();
  }



  [Key]
  public string Id {get; set;}

  public string? diun_version { get; set; }
  public string? hostname { get; set; }
  public string? status { get; set; }
  public string? provider { get; set; }
  public string? image { get; set; }
  public string? hub_link { get; set; }
  public string? mime_type { get; set; }
  public string? digest { get; set; }

  [DataType(DataType.Date)]
  public DateTime? created { get; set; }
  public string? platform { get; set; }

}
