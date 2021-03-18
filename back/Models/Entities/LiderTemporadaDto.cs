using System;
using back.Models.DB;

namespace back.Models.Entities
{
    public class LiderTemporadaDto
    {
        public LiderDto[] Bateo { get; set; } 
        public LiderDto[] Pitcheo { get; set; }
        public LiderDto[] Fildeo { get; set; }
    }
}