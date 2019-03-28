using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Coloc.Models
{
    [ModelMetadataType(typeof(UserTasksMetadata))]
    public partial class UserTasks
    {
    }
}

public class UserTasksMetadata
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public string UserId { get; set; }

    [DisplayName("Débute le ")]
    [Required(ErrorMessage = "Veuillez entrer une date de début.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime BeginTask { get; set; }

    [DisplayName("Débute le ")]
    [Required(ErrorMessage = "Veuillez enter une date de fin")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime EndTask { get; set; }
    public DateTime? FinishTask { get; set; }
    public byte State { get; set; }
}
