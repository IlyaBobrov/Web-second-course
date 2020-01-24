using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Program_5.ViewModels
{
    public enum SortState
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        PriceAsc,   // по price по возрастанию
        PriceDesc,  // по price по убыванию
        PowerAsc,   // по power по возрастанию
        PowerDesc,  // по power по убыванию
        BrandAsc,   // по компании по возрастанию
        BrandDesc   // по компании по убыванию
    }
    public class SortViewModel
    {
        public SortState NameSort { get; private set; }     // значение для сортировки по имени
        public SortState PriceSort { get; private set; }    // значение для сортировки по price
        public SortState PowerSort { get; private set; }    // значение для сортировки по power
        public SortState BrandSort { get; private set; }    // значение для сортировки по компании
        public SortState Current { get; private set; }      // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            PowerSort = sortOrder == SortState.PowerAsc ? SortState.PowerDesc : SortState.PowerAsc;
            BrandSort = sortOrder == SortState.BrandAsc ? SortState.BrandDesc : SortState.BrandAsc;
            Current = sortOrder;
        }
    }
}
