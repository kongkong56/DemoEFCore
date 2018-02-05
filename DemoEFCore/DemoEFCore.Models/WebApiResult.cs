using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace DemoEFCore.Models
{
    [DataContract]
    public class WebApiResult<T>
    {

        [DataMember]
        public virtual T Data { get; set; }

        [DataMember]
        public bool Success { get; set; } = true;
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string Time { get; set; } = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);
        [DataMember]
        public string TimeSpan { get; set; }
    }
}
