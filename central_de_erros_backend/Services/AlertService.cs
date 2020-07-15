using System;
using System.Collections.Generic;
using System.IO;
using central_de_erros_backend.Models;
using Newtonsoft.Json;

namespace central_de_erros_backend.Services
{
    public class AlertService
    {

        private readonly CentralContext context;

        public AlertService(CentralContext context)
        {
            this.context = context;
        }

        public Alert Add(Alert alert)
        {
            Alert ret =  context.Add<Alert>(alert).Entity;

            context.SaveChanges();

            return ret;
        }

        public void AddTestAlerts()
        {
            string file = File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/TestData/alerts.json");

            List<Alert> alerts = JsonConvert.DeserializeObject<List<Alert>>(file);
            foreach(Alert alert in alerts)
            {
                Add(alert);
            }
        }
    }
}
