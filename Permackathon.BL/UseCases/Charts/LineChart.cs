using Newtonsoft.Json;
using Permackathon.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Permackathon.BL.UseCases.Charts
{
    public class LineChart
    {
        private readonly IUnitOfWork UnitOfWork;
        public enum Mois
        {
            Jan, Fev, Mar, Avr, Mai, Jui, Juil, Aoû, Sep, Oct, Nov, Déc
        }
        public enum Activities
        {
            EAT, GROW, LEARN
        }

        public LineChart(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public string Line(int year)
        {
            Dictionary<string, List<KeyValuePair<string, double>>> dictionary = new Dictionary<string, List<KeyValuePair<string, double>>>();

            List<KeyValuePair<string, double>> objectives = MonthValuesForObjectives(year);
            List<KeyValuePair<string, double>> realSales = MonthValuesForRealSales(year);

            dictionary.Add("Objectives", objectives);
            dictionary.Add("RealSales", realSales);

            var jsonData = JsonConvert.SerializeObject(dictionary);

            return jsonData;
        }

        private decimal GetMonthSumForActualSales(int year, int month)
        {
            return UnitOfWork.FinancialRepository
                             .GetAll()
                             .Where(f => f.ReportDate.Year == year && f.ReportDate.Month == month)
                             .Sum(f => f.ActualSale);
        }

        private decimal GetMonthSumForObjectives(int year, int month)
        {
            return UnitOfWork.FinancialRepository
                             .GetAll()
                             .Where(f => f.ReportDate.Year == year && f.ReportDate.Month == month)
                             .Sum(f => f.Objective);
        }

        private List<KeyValuePair<string, double>> MonthValuesForObjectives(int year)
        {
            var dataValuePair = new List<KeyValuePair<string, double>>();

            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Jan.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 1), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Fev.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 2), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Mar.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 3), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Avr.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 4), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Mai.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 5), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Jui.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 6), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Juil.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 7), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Aoû.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 8), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Sep.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 9), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Oct.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 10), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Nov.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 11), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Déc.ToString(), Math.Round((double)GetMonthSumForObjectives(year, 12), 2)));

            return dataValuePair;
        }

        private List<KeyValuePair<string, double>> MonthValuesForRealSales(int year)
        {
            var dataValuePair = new List<KeyValuePair<string, double>>();

            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Jan.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 1), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Fev.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 2), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Mar.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 3), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Avr.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 4), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Mai.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 5), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Jui.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 6), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Juil.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 7), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Aoû.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 8), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Sep.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 9), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Oct.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 10), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Nov.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 11), 2)));
            dataValuePair.Add(new KeyValuePair<string, double>(Mois.Déc.ToString(), Math.Round((double)GetMonthSumForActualSales(year, 12), 2)));

            return dataValuePair;
        }
    }
}