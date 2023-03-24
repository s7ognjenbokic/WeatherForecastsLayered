﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecasts.Domain.Abstractions;
using WeatherForecasts.Domain.Models;

namespace WeatherForecasts.Service
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repo;

        public WeatherForecastService(IWeatherForecastRepository repo)
        {
            _repo = repo;
        }

        public List<WeatherForecast> ProcessFTemperature()
        {
            var forecasts = _repo.GetForecasts();
            var processed = new List<WeatherForecast>();
            foreach (var forecast in forecasts) 
            {
                forecast.TemperatureF = 32 + (int)(forecast.TemperatureC / 0.5556);
                processed.Add(forecast);
            }

            return processed;
        }
    }
}
