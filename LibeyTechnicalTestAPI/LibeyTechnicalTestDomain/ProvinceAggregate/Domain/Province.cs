﻿namespace LibeyTechnicalTestDomain.ProvinceAggregate.Domain;
public class Province
{
    public string ProvinceCode { get; private set; }
    public string RegionCode { get; private set; }
    public string ProvinceDescription { get; private set; }
    public Province(
        string provinceCode,
        string regionCode,
        string provinceDescription
    ) {
        ProvinceCode = provinceCode;
        RegionCode = regionCode;
        ProvinceDescription = provinceDescription;
    }
}