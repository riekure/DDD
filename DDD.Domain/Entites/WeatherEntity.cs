﻿using DDD.Domain.ValueObjects;
using System;

namespace DDD.Domain.Entites
{
    public sealed class WeatherEntity
    {
        // 完全コンストラクタパターン
        public WeatherEntity(int areaId, 
                             DateTime dataDate,
                             int condition,
                             float temperature)
            :this(areaId, string.Empty, dataDate, condition, temperature)
        {
        }

        public WeatherEntity(int areaId,
                             string areaName,
                             DateTime dataDate,
                             int condition,
                             float temperature)
        {
            AreaId = areaId;
            AreaName = areaName;
            DataDate = dataDate;
            Condition = new Condition(condition);
            Temperature = new Temperature(temperature);
        }

        public int AreaId { get; }
        public string AreaName { get; }
        public DateTime DataDate { get; }
        public Condition Condition { get; }
        public Temperature Temperature { get; }

        public bool IsOK()
        {
            if (DataDate < DateTime.Now.AddMonths(-1))
            {
                if (Temperature.Value < 10)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
