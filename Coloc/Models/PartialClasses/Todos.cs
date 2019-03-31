/*
 * Description : Partial Model to avoid overriding models on Scaffold models
 * Translate words to french, test validation
 * 
 * Author : Julien Richoz / SI-T2a / CPNV-ES
 * Date : 31.03.2019
 * */

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
