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
using System.ComponentModel.DataAnnotations;

namespace Coloc.Models
{
    [ModelMetadataType(typeof(TodosMetadata))]
    public partial class Todos
    {
    }
}

public class TodosMetadata
{
    [Required(ErrorMessage = "Veuillez insérer un titre.")]
    [DisplayName("Titre")]
    [StringLength(50, MinimumLength=1, ErrorMessage = "Maximum 50 lettres autorisées.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Veuillez insérer une description.")]
    [DisplayName("Description")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "La description doit comporter entre 10 à 500 lettres.")]
    public string Description { get; set; }

}
