using IncubadoraApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace IncubadoraApp.Services
{
    public class IncubadoraService
    {
        static Incubadora minhaIncubadora = new Incubadora();

        public static int t;




        public void Temperatura(Object b)
        {

            t += 1;

            minhaIncubadora.Temperatura = 100;

        }
    }
}
