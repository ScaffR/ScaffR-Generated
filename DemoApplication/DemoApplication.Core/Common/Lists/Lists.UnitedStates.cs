#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Common.Lists
{
    #region

    using System.Collections.Generic;

    #endregion

    public static partial class Lists
    {
        public static readonly IDictionary<string, string> CanadianProvinces = new Dictionary<string, string>
            {
                {"Manatoba", "MB"},
                {"British Columbia", "CA"},
                {"Sescatchewan", "S"}
            };

    public static readonly IDictionary<string, string> UnitedStates = new Dictionary<string, string> 
        {
            {"Alabama", "AL"},
            {"Alaska", "AK"},
            {"American Samoa", "AS"},
            {"Arizona", "AZ"},
            {"Arkansas", "AR"},
            {"California", "CA"},
            {"Colorado", "CO"},
            {"Connecticut", "CT"},
            {"Delaware", "DE"},
            {"District of Columbia", "DC"},
            {"Federated States of Micronesia", "FM"},
            {"Florida", "FL"},
            {"Georgia", "GA"},
            {"Guam", "GU"},
            {"Hawaii", "HI"},
            {"Idaho", "ID"},
            {"Illinois", "IL"},
            {"Indiana", "IN"},
            {"Iowa", "IA"},
            {"Kansas", "KS"},
            {"Kentucky", "KY"},
            {"Louisiana", "LA"},
            {"Maine", "ME"},
            {"Marshall Islands", "MH"},
            {"Maryland", "MD"},
            {"Massachusetts", "MA"},
            {"Michigan", "MI"},
            {"Minnesota", "MN"},
            {"Mississippi", "MS"},
            {"Missouri", "MO"},
            {"Montana", "MT"},
            {"Nebraska", "NE"},
            {"Nevada", "NV"},
            {"New Hampshire", "NH"},
            {"New Jersey", "NJ"},
            {"New Mexico", "NM"},
            {"New York", "NY"},
            {"North Carolina", "NC"},
            {"North Dakota", "ND"},
            {"Northern Mariana Islands", "MP"},
            {"Ohio", "OH"},
            {"Oklahoma", "OK"},
            {"Oregon", "OR"},
            {"Palau", "PW"},
            {"Pennsylvania", "PA"},
            {"Puerto Rico", "PR"},
            {"Rhode Island", "RI"},
            {"South Carolina", "SC"},
            {"South Dakota", "SD"},
            {"Tennessee", "TN"},
            {"Texas", "TX"},
            {"Utah", "UT"},
            {"Vermont", "VT"},
            {"Virgin Islands", "VI"},
            {"Virginia", "VA"},
            {"Washington", "WA"},
            {"West Virginia", "WV"},
            {"Wisconsin", "WI"},
            {"Wyoming", "WY"}
        };
    }
}