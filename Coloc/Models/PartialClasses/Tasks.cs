using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Coloc.Models
{
    [ModelMetadataType(typeof(TasksMetadata))]
    public partial class Tasks
    {

    }
}

public class TasksMetadata
{
    [DisplayName("Titre")]
    public string Title { get; set; }
    [DisplayName("Description")]
    public string Description { get; set; }

}
