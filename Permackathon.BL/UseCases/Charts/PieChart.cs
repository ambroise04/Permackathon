using Permackathon.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permackathon.BL.UseCases.Charts
{
    public class PieChart
    {
        private IUnitOfWork UnitOfWork { get; set; }
        public PieChart(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public double[] InitilizePie(int year)
        {
            var sumTotal = UnitOfWork.FinancialRepository
                                .GetAll()
                                .Where(f => f.ReportDate.Year == year)
                                .Sum(a => a.ActualSale);

            var sumEat = UnitOfWork.FinancialRepository
                                .GetAll()
                                .Where(f => f.Activity.Id == 1)
                                .Sum(a => a.ActualSale);

            var sumGrow = UnitOfWork.FinancialRepository
                                .GetAll()
                                .Where(f => f.Activity.Id == 2 && f.ReportDate.Year == year)
                                .Sum(a => a.ActualSale);

            var sumLearn = UnitOfWork.FinancialRepository
                                .GetAll()
                                .Where(f => f.Activity.Id == 3 && f.ReportDate.Year == year)
                                .Sum(a => a.ActualSale);

            return new double[] {Math.Round((double)((sumEat*100)/sumTotal), 2), Math.Round((double)((sumGrow*100)/sumTotal),2), Math.Round((double)((sumLearn*100)/sumTotal),2) };
        }

    }
}