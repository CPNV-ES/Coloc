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
    [ModelMetadataType(typeof(TasksMetadata))]
    public partial class Tasks
    {

    }
}

public class TasksMetadata
{
    [DisplayName("Titre")]
    [Required(ErrorMessage = "Veuillez insérer un titre de tâche.")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Maximum 50 lettres autorisées.")]
    public string Title { get; set; }

    [DisplayName("Description")]
    [Required(ErrorMessage = "Veuillez insérer une description.")]
    [StringLength(500, MinimumLength = 5, ErrorMessage = "La description doit comporter plus de 5 lettres (Max: 500).")]
    public string Description { get; set; }

}
