using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Integracion_Gemini_y_Apis.Models;

    public class HuggingsReponse_ContextoBaseDeDatos : DbContext
    {
        public HuggingsReponse_ContextoBaseDeDatos (DbContextOptions<HuggingsReponse_ContextoBaseDeDatos> options)
            : base(options)
        {
        }

        public DbSet<Integracion_Gemini_y_Apis.Models.HuggingResponseModel> HuggingResponseModel { get; set; } = default!;
    }
