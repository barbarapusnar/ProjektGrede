using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektGrede.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class AGROMET
    {

        private AGROMETLocation locationField;

        private AGROMETDATA[] dATAField;

        /// <remarks/>
        public AGROMETLocation Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DATA")]
        public AGROMETDATA[] DATA
        {
            get
            {
                return this.dATAField;
            }
            set
            {
                this.dATAField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AGROMETLocation
    {

        private byte locationIDField;

        private string locationNameField;

        private decimal locationAltitudeField;

        private string locationDescrField;

        private string timeFormatField;

        private string uRLField;

        /// <remarks/>
        public byte LocationID
        {
            get
            {
                return this.locationIDField;
            }
            set
            {
                this.locationIDField = value;
            }
        }

        /// <remarks/>
        public string LocationName
        {
            get
            {
                return this.locationNameField;
            }
            set
            {
                this.locationNameField = value;
            }
        }

        /// <remarks/>
        public decimal LocationAltitude
        {
            get
            {
                return this.locationAltitudeField;
            }
            set
            {
                this.locationAltitudeField = value;
            }
        }

        /// <remarks/>
        public string LocationDescr
        {
            get
            {
                return this.locationDescrField;
            }
            set
            {
                this.locationDescrField = value;
            }
        }

        /// <remarks/>
        public string TimeFormat
        {
            get
            {
                return this.timeFormatField;
            }
            set
            {
                this.timeFormatField = value;
            }
        }

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AGROMETDATA
    {

        private System.DateTime dateField;

        private decimal bATTField;

        private bool bATTFieldSpecified;

        private byte measurementsField;

        private bool measurementsFieldSpecified;

        private decimal temp2Field;

        private bool temp2FieldSpecified;

        private decimal temp2_MinField;

        private bool temp2_MinFieldSpecified;

        private decimal temp2_MaxField;

        private bool temp2_MaxFieldSpecified;

        private decimal humidity2Field;

        private bool humidity2FieldSpecified;

        private decimal humidity2_MinField;

        private bool humidity2_MinFieldSpecified;

        private decimal humidity2_MaxField;

        private bool humidity2_MaxFieldSpecified;

        private decimal leafwetness2Field;

        private bool leafwetness2FieldSpecified;

        private decimal leafwetness2_MinField;

        private bool leafwetness2_MinFieldSpecified;

        private decimal leafwetness2_MaxField;

        private bool leafwetness2_MaxFieldSpecified;

        private decimal precipitationField;

        private bool precipitationFieldSpecified;

        private decimal precipitation_MinField;

        private bool precipitation_MinFieldSpecified;

        private decimal precipitation_MaxField;

        private bool precipitation_MaxFieldSpecified;

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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BATTSpecified
        {
            get
            {
                return this.bATTFieldSpecified;
            }
            set
            {
                this.bATTFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MeasurementsSpecified
        {
            get
            {
                return this.measurementsFieldSpecified;
            }
            set
            {
                this.measurementsFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Temp2Specified
        {
            get
            {
                return this.temp2FieldSpecified;
            }
            set
            {
                this.temp2FieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Temp2_MinSpecified
        {
            get
            {
                return this.temp2_MinFieldSpecified;
            }
            set
            {
                this.temp2_MinFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Temp2_MaxSpecified
        {
            get
            {
                return this.temp2_MaxFieldSpecified;
            }
            set
            {
                this.temp2_MaxFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Humidity2Specified
        {
            get
            {
                return this.humidity2FieldSpecified;
            }
            set
            {
                this.humidity2FieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Humidity2_MinSpecified
        {
            get
            {
                return this.humidity2_MinFieldSpecified;
            }
            set
            {
                this.humidity2_MinFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Humidity2_MaxSpecified
        {
            get
            {
                return this.humidity2_MaxFieldSpecified;
            }
            set
            {
                this.humidity2_MaxFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Leafwetness2Specified
        {
            get
            {
                return this.leafwetness2FieldSpecified;
            }
            set
            {
                this.leafwetness2FieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Leafwetness2_MinSpecified
        {
            get
            {
                return this.leafwetness2_MinFieldSpecified;
            }
            set
            {
                this.leafwetness2_MinFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Leafwetness2_MaxSpecified
        {
            get
            {
                return this.leafwetness2_MaxFieldSpecified;
            }
            set
            {
                this.leafwetness2_MaxFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PrecipitationSpecified
        {
            get
            {
                return this.precipitationFieldSpecified;
            }
            set
            {
                this.precipitationFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Precipitation_MinSpecified
        {
            get
            {
                return this.precipitation_MinFieldSpecified;
            }
            set
            {
                this.precipitation_MinFieldSpecified = value;
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

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Precipitation_MaxSpecified
        {
            get
            {
                return this.precipitation_MaxFieldSpecified;
            }
            set
            {
                this.precipitation_MaxFieldSpecified = value;
            }
        }
    }


}