using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel
    {
        private IWeatherRepository _weather;

        public WeatherLatestViewModel() : this(new WeatherSQLite())
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            _weather = weather;
        }

        public string AreaIdText { get; set; } = String.Empty;
        public string DataDateText { get; set; } = String.Empty;
        public string ConditionText { get; set; } = String.Empty;
        public string TemperatureText { get; set; } = String.Empty;

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));
            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }
    }
}
