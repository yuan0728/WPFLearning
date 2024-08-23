using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XH.AdoNetDemo.Models;

public partial class ScoreInfo
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Course { get; set; }

    public int? Score { get; set; }
}
