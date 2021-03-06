﻿using System.ComponentModel.DataAnnotations;

namespace GRA.Domain.Model
{
    public class PsPerformerImage : Abstract.BaseDomainEntity
    {
        public int PerformerId { get; set; }

        [MaxLength(255)]
        public string Filename { get; set; }
    }
}
