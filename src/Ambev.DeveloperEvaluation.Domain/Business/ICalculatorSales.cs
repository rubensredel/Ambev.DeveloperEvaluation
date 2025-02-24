using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Business;

public interface ICalculatorSales
{
    void CalculateTotals(Sales sale);
}
