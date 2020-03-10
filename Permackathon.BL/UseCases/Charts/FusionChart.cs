using Permackathon.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Text;

namespace Permackathon.BL.UseCases.Charts
{
    public partial class FusionChart
    {
        private readonly IUnitOfWork UnitOfWork;

        public FusionChart(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public string EatFusion()
        {
            var s = UnitOfWork.FinancialRepository.
            //store label-value pair
            var dataValuePair = new List<KeyValuePair<string, double>>();

            dataValuePair.Add(new KeyValuePair<string, double>("Jan", 290));
            dataValuePair.Add(new KeyValuePair<string, double>("Fév", 260));
            dataValuePair.Add(new KeyValuePair<string, double>("Mar", 180));
            dataValuePair.Add(new KeyValuePair<string, double>("Avr", 140));
            dataValuePair.Add(new KeyValuePair<string, double>("Mai", 115));
            dataValuePair.Add(new KeyValuePair<string, double>("Jui", 100));
            dataValuePair.Add(new KeyValuePair<string, double>("Juil", 30));
            dataValuePair.Add(new KeyValuePair<string, double>("Aoû", 30));
            dataValuePair.Add(new KeyValuePair<string, double>("Sep", 30));
            dataValuePair.Add(new KeyValuePair<string, double>("Oct", 30));
            dataValuePair.Add(new KeyValuePair<string, double>("Nov", 30));
            dataValuePair.Add(new KeyValuePair<string, double>("Déc", 30));

            StringBuilder jsonData = new StringBuilder();
            StringBuilder data = new StringBuilder();
            // store chart config name-config value pair

            Dictionary<string, string> chartConfig = new Dictionary<string, string>();
            chartConfig.Add("caption", "Countries With Most Oil Reserves [2017-18]");
            chartConfig.Add("subCaption", "In MMbbl = One Million barrels");
            chartConfig.Add("xAxisName", "Country");
            chartConfig.Add("yAxisName", "Reserves (MMbbl)");
            chartConfig.Add("numberSuffix", "k");
            chartConfig.Add("theme", "fusion");

            // json data to use as chart data source
            jsonData.Append("{'chart':{");
            foreach (var config in chartConfig)
            {
                jsonData.AppendFormat("'{0}':'{1}',", config.Key, config.Value);
            }
            jsonData.Replace(",", "},", jsonData.Length - 1, 1);

            // build  data object from label-value pair
            data.Append("'data':[");

            foreach (KeyValuePair<string, double> pair in dataValuePair)
            {
                data.AppendFormat("{{'label':'{0}','value':'{1}'}},", pair.Key, pair.Value);
            }
            data.Replace(",", "]", data.Length - 1, 1);

            jsonData.Append(data.ToString());
            jsonData.Append("}");

            return jsonData.ToString();
        }
    }
}