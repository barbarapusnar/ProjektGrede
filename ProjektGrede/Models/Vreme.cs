using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGrede
{
    public class Vreme
    {

            private System.DateTime dateField;

            private decimal bATTField;

            private byte measurementsField;

            private decimal temp2Field;

            private decimal temp2_MinField;

            private decimal temp2_MaxField;

            private decimal humidity2Field;

            private decimal humidity2_MinField;

            private decimal humidity2_MaxField;

            private decimal leafwetness2Field;

            private decimal leafwetness2_MinField;

            private decimal leafwetness2_MaxField;

            private decimal precipitationField;

            private decimal precipitation_MinField;

            private decimal precipitation_MaxField;

            /// <remarks/>
            public System.DateTime Date
            {
                get
                {
                    return this.dateField;
                }
                set
                {
                    this.dateField = value;
                }
            }

            /// <remarks/>
            public decimal BATT
            {
                get
                {
                    return this.bATTField;
                }
                set
                {
                    this.bATTField = value;
                }
            }

            /// <remarks/>
            public byte Measurements
            {
                get
                {
                    return this.measurementsField;
                }
                set
                {
                    this.measurementsField = value;
                }
            }

            /// <remarks/>
            public decimal Temp2
            {
                get
                {
                    return this.temp2Field;
                }
                set
                {
                    this.temp2Field = value;
                }
            }

            /// <remarks/>
            public decimal Temp2_Min
            {
                get
                {
                    return this.temp2_MinField;
                }
                set
                {
                    this.temp2_MinField = value;
                }
            }

            /// <remarks/>
            public decimal Temp2_Max
            {
                get
                {
                    return this.temp2_MaxField;
                }
                set
                {
                    this.temp2_MaxField = value;
                }
            }

            /// <remarks/>
            public decimal Humidity2
            {
                get
                {
                    return this.humidity2Field;
                }
                set
                {
                    this.humidity2Field = value;
                }
            }

            /// <remarks/>
            public decimal Humidity2_Min
            {
                get
                {
                    return this.humidity2_MinField;
                }
                set
                {
                    this.humidity2_MinField = value;
                }
            }

            /// <remarks/>
            public decimal Humidity2_Max
            {
                get
                {
                    return this.humidity2_MaxField;
                }
                set
                {
                    this.humidity2_MaxField = value;
                }
            }

            /// <remarks/>
            public decimal Leafwetness2
            {
                get
                {
                    return this.leafwetness2Field;
                }
                set
                {
                    this.leafwetness2Field = value;
                }
            }

            /// <remarks/>
            public decimal Leafwetness2_Min
            {
                get
                {
                    return this.leafwetness2_MinField;
                }
                set
                {
                    this.leafwetness2_MinField = value;
                }
            }

            /// <remarks/>
            public decimal Leafwetness2_Max
            {
                get
                {
                    return this.leafwetness2_MaxField;
                }
                set
                {
                    this.leafwetness2_MaxField = value;
                }
            }

            /// <remarks/>
            public decimal Precipitation
            {
                get
                {
                    return this.precipitationField;
                }
                set
                {
                    this.precipitationField = value;
                }
            }

            /// <remarks/>
            public decimal Precipitation_Min
            {
                get
                {
                    return this.precipitation_MinField;
                }
                set
                {
                    this.precipitation_MinField = value;
                }
            }

            /// <remarks/>
            public decimal Precipitation_Max
            {
                get
                {
                    return this.precipitation_MaxField;
                }
                set
                {
                    this.precipitation_MaxField = value;
                }
            }
        }


    }
