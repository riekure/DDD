using DDD.Domain.ValueObjects;
using System;

namespace DDD.WinForm.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        public WeatherSaveViewModel()
        {
            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemparatureText = string.Empty;
        }
        public object SelectedAreaId { get; set; }
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemparatureText { get; set; }
    }
}
