using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Coloc.Models
{
    [ModelMetadataType(typeof(TodosMetadata))]
    public partial class Todos
    {
    }
}

public class TodosMetadata
{
    [DisplayName("Titre")]
    public string Title { get; set; }
    [DisplayName("Description")]
    public string Description { get; set; }

}
