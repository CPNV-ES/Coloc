/*
 * Description : Partial Model to avoid overriding models on Scaffold models
 * Translate words to french, test validation, format DateTime
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
    [ModelMetadataType(typeof(UserTasksMetadata))]
    public partial class UserTasks
    {
        public static string stateToString(int state)
        {
            switch (state)
            {
                case 0: return "Pas commencé";

                case 1: return "En cours";

                case 2: return "Terminé";

                default: return "Pas commencé";
            }
        }
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
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BeginTask { get; set; }

    [DisplayName("Termine le ")]
    [Required(ErrorMessage = "Veuillez enter une date de fin")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EndTask { get; set; }
    [Range(0, 2)]
    public byte State { get; set; }
}
